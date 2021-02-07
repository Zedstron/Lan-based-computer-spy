using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteServer
{
    class BroadcastHelper
    {
        private readonly UdpClient udp = new UdpClient(15000);

        private void StartListening()
        {
            this.udp.BeginReceive(Receive, new object());
        }

        private void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 15000);
            byte[] bytes = udp.EndReceive(ar, ref ip);
            string message = Encoding.ASCII.GetString(bytes);
            StartListening(); 
        }

        public void Send()
        {
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, 15000);
            byte[] bytes = Encoding.ASCII.GetBytes("Foo");
            client.Send(bytes, bytes.Length, ip);
            client.Close();
        }
    }
}
