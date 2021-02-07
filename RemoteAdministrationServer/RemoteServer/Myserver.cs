using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Timers;
using NetworkInterfaceEye;

namespace RemoteServer
{
    class Myserver
    {
        private static TcpListener listener = null;
        public static RemoteServer owner;
        private static List<TcpClient> clients = new List<TcpClient>();
        private static List<Controller> formArray = new List<Controller>();
        public delegate void onNewMessageBroadcast(object sender, Message message);
        public static event onNewMessageBroadcast onNewMessageArrived;
        private static bool olReceived = false;
        private static bool open;
        private static bool listening = false;
        private static Random random = new Random();
        private static Stopwatch timer_sub = new Stopwatch();
        private static string activeInterface = null;
        private static Timer timer_main = new Timer();

        public static string Generate(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static void getActiveInterface()
        {
            NetworkInterface[] nfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach(NetworkInterface n in nfaces)
            {
                if(n.OperationalStatus==OperationalStatus.Up)
                {
                    activeInterface = n.Description;
                    break;
                }
            }

            IList<string> interfaces = Utilities.GetNetworkInterfaces();
            foreach (string ni in interfaces)
            {
                if (ni.Substring(0, 7) == activeInterface.Substring(0, 7))
                    activeInterface = ni;
            }
        }

        private static void getNetworkStats()
        {
            IStatistics stats = Utilities.GetNetworkStatistics(activeInterface);
            foreach (Controller c in formArray)
            { 
                c.updateNetworkStats(stats.UploadSpeed, stats.DownloadSpeed);
            }
        }

        public static void Show(int index)
        {
            if (!formArray[index].Visible)
                formArray[index].Show();
            else
                formArray[index].BringToFront();
        }

        private static void OnMessageReceived(ClientContext context, float speed)
        {
            if (onNewMessageArrived != null)
            {
                string key = Router.Key(extractPair(context));

                if (key != null)
                    onNewMessageArrived(null, new Message(new TransferRate(speed), key));
            }
        }

        private static void OnMessageReceived(ClientContext context)
        {
            if (onNewMessageArrived != null)
            {
                string key = Router.Key(extractPair(context));

                if (key != null)
                    onNewMessageArrived(null, new Message(context.Buffer, key));
            }
        }

        private static string extractPair(ClientContext context)
        {
            string port = ((IPEndPoint)context.Client.Client.RemoteEndPoint).Port.ToString();
            string ip = ((IPEndPoint)context.Client.Client.RemoteEndPoint).Address.ToString();

            return ip + ":" + port;
        }

        private static void OnReceive(IAsyncResult ar)
        {
            String content = String.Empty;
            ClientContext context = ar.AsyncState as ClientContext;
            Socket handler = context.Client.Client;
            int bytesRead;

            if (handler.Connected)
            {
                
                // Read data from the client socket. 
                try
                {
                    bytesRead = handler.EndReceive(ar);
                    if (bytesRead > 0)
                    {
                        int bytesRemains = bytesRead;  
                        int bytesProcess = 0;
                        //timer_sub.Start();

                        while (bytesRemains > 0)
                        {
                            if (!olReceived)
                            {
                                byte[] temp = new byte[4];
                                try
                                {
                                    Buffer.BlockCopy(context.Buffer, bytesProcess, temp, 0, 4);
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine(ex.Message, "Information");
                                }

                                context.ol = BitConverter.ToInt32(temp, 0);
                                olReceived = true;
                                bytesProcess += 4;
                                bytesRemains = bytesRead - bytesProcess;
                            }
                            else
                            {
                                if (context.bab.Length < context.ol)
                                {
                                    byte[] temp;
                                    int rl;
                                    if (bytesRemains > context.ol - context.bab.Length)
                                    {
                                        rl = context.ol - context.bab.Length;
                                    }
                                    else
                                    {
                                        rl = bytesRemains;
                                    }

                                    temp = new byte[rl];
                                    try
                                    {
                                        Buffer.BlockCopy(context.Buffer, bytesProcess, temp, 0, rl);
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine(ex.Message, "Information");
                                    }

                                    context.bab.Append(temp);
                                    bytesProcess += rl;
                                    bytesRemains = bytesRead - bytesProcess;
                                    if (context.bab.Length == context.ol)
                                    {
                                        timer_sub.Stop();
                                        try
                                        {
                                            OnMessageReceived(context);
                                            olReceived = false;
                                            context.bab.Clear();
                                        }
                                        catch (Exception ex)
                                        {
                                            Debug.WriteLine(ex.Message, "Information");
                                        }
                                    }
                                }
                            }                            
                        }

                        if (timer_sub.IsRunning)
                            timer_sub.Stop();

                        //int milis = Int32.Parse(timer_sub.Elapsed.ToString().Split('.')[1]);
                       // float speed = (bytesRead * 8) / milis; // kbps
                       // OnMessageReceived(context, speed);
                       // timer_sub.Reset();

                        context.Stream.BeginRead(context.Buffer, 0, context.Buffer.Length, OnReceive, context);
                    }
                }

                catch (SocketException socketException)
                {
                    //WSAECONNRESET, the other side closed impolitely
                    if (socketException.ErrorCode == 10054 ||
                        ((socketException.ErrorCode != 10004) && (socketException.ErrorCode != 10053)))
                    {
                        // Complete the disconnect request.
                        handler.Close();
                        handler = null;
                    }
                }

                    // Eat up exception....Hmmmm I'm loving eat!!!
                catch (Exception exception)
                {
                    Debug.WriteLine("Client Closed Connection :( :( :( :( " + exception.Message, "Information");
                    context.Stream.BeginRead(context.Buffer, 0, context.Buffer.Length, OnReceive, context);
                }
            }
        }

        private static void OnClientAccepted(IAsyncResult ar)
        {
            TcpListener listener = ar.AsyncState as TcpListener;
            if (listener == null && listening)
                return;

            try
            {
                if (listener.Server.IsBound && listening)
                {
                    ClientContext context = new ClientContext();
                    context.Client = listener.EndAcceptTcpClient(ar);
                    context.Stream = context.Client.GetStream();
                    string key = Generate(10);
                    Router.Add(extractPair(context), key);
                    formArray.Add(new Controller(key, ((IPEndPoint)context.Client.Client.RemoteEndPoint).Address.ToString()));
                    clients.Add(context.Client);
                    owner.ClientAdded(null, new MyEventArgs(context.Client));
                    context.Stream.BeginRead(context.Buffer, 0, context.Buffer.Length, OnReceive , context);
                    listener.BeginAcceptTcpClient(OnClientAccepted, listener);

                    if (open)
                        Show(formArray.Count - 1);
                }
            }
            catch(Exception e)
            {
                Debug.Write(e.Message, "Information");
            }
        }

        public static void DisconnectClient(String remoteIP, String remotePort)
        {
            Router.Remove(remoteIP + " : " + remotePort);
            owner.UpdateClientList(remoteIP + " : " + remotePort, "Delete");
            int counter = 0;
            foreach (TcpClient c in clients)
            {
                String remoteIP1 = ((IPEndPoint)c.Client.RemoteEndPoint).Address.ToString();
                String remotePort1 = ((IPEndPoint)c.Client.RemoteEndPoint).Port.ToString();

                if (remoteIP1.Equals(remoteIP) && remotePort1.Equals(remotePort))
                {
                    break;
                }
                counter++;

            }

            formArray.RemoveAt(counter);
            clients.RemoveAt(counter);
        }

        public static void Start(int port)
        {
            listening = true;
            listener = new TcpListener(new IPEndPoint(IPAddress.Any, port));
            listener.Start();
            listener.BeginAcceptTcpClient(OnClientAccepted, listener);
            timer_main.Interval = 1000;
            timer_main.Elapsed += new ElapsedEventHandler(timerMain_Elappsed);
            getActiveInterface();
            Debug.WriteLine(activeInterface, "Information");
           // timer_main.Start();
        }

        private static void timerMain_Elappsed(object sender, EventArgs e)
        {
            getNetworkStats();
        }

        public static void Stop()
        {
            if (listener != null)
            {
                timer_main.Stop();
                listening = false;
                foreach (TcpClient c in clients)
                {
                    c.Client.Close();
                }

                formArray.Clear();
                Router.Clear();
                clients.Clear();
                listener.Stop();
            }
        }

        public static string Resolve(string remoteIP, bool ret)
        {
            try
            {
                return Dns.GetHostEntry(IPAddress.Parse(remoteIP)).HostName;
            }
            catch
            {
                if (ret)
                    return remoteIP;
                else
                    return null;
            }
        }

        public static void SendMessage(object msg, string key)
        {
            int seek = 0;
            const int count = 102400;
            // byte[] buffer;
            Socket handler = getClient(key);
            try
            {
                //   byte[] o = ObjectToByteArray(msg);

                ByteArrayBuilder b = new ByteArrayBuilder();
                b.Append(ObjectToByteArray(msg));

                byte[] ol = BitConverter.GetBytes(b.Length);

                handler.BeginSend(ol, 0, ol.Length, 0, new AsyncCallback(SendCallBack), handler);

                //count = b.Length;
                int length = b.Length;

                while (length > count)
                {
                    handler.BeginSend(b.ToArray(seek, count), 0, count, 0, new AsyncCallback(SendCallBack), handler);
                    //handler.BeginSend(buffer, 0, count, 0, new AsyncCallback(SendCallBack), handler);
                    seek += count;
                    length = length - count;
                }

                handler.BeginSend(b.ToArray(seek, length), 0, length, 0, new AsyncCallback(SendCallBack), handler);
            }
            catch (SocketException socketException)
            {
                //WSAECONNRESET, the other side closed impolitely
                if (socketException.ErrorCode == 10054 ||
                    ((socketException.ErrorCode != 10004) && (socketException.ErrorCode != 10053)))
                {
                    // Complete the disconnect request.
                    String remoteIP = ((IPEndPoint)handler.RemoteEndPoint).Address.ToString();
                    String remotePort = ((IPEndPoint)handler.RemoteEndPoint).Port.ToString();
                    Myserver.DisconnectClient(remoteIP, remotePort);

                    handler.Close();
                    handler = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "Information");
            }
        }

        private static void SendCallBack(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                int bytesSend = handler.EndSend(ar);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message, "Information");
            }
        }

        private static Socket getClient(string key)
        {
            string pair = Router.Pair(key);
            Socket socket = null;
            foreach(TcpClient c in clients)
            {
                String remoteIP1 = ((IPEndPoint)c.Client.RemoteEndPoint).Address.ToString();
                String remotePort1 = ((IPEndPoint)c.Client.RemoteEndPoint).Port.ToString();

                if (remoteIP1 + ":" + remotePort1 == pair)
                    socket = c.Client;
            }

            return socket;
        }

        public static bool OpenASAP
        {
            set
            {
                open = value;
            }
        }

        private static byte[] ObjectToByteArray(Object obj)
        {
            try
            {
                if (obj == null)
                    return null;
                BinaryFormatter bf = new BinaryFormatter();
                bf.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "Information");
                return null;
            }
        } 

    }
}
