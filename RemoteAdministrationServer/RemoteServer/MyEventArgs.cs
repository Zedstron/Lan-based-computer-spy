using System;
using System.Net.Sockets;

namespace RemoteServer
{
    class MyEventArgs:EventArgs 
    {
        private TcpClient  sock;
        public TcpClient  clientSock {
            get { return sock; }
            set { sock = value;}
         }

        public MyEventArgs(TcpClient tcpClient) {
            sock = tcpClient;
        }


    }
}
