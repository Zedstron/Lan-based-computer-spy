using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteServer
{
    class ClientContext
    {
        public TcpClient Client;
        public Stream Stream;
        public byte[] Buffer = new byte[102400];
        public MemoryStream Message = new MemoryStream();
        public int ol;
        public ByteArrayBuilder bab = new ByteArrayBuilder();
    }
}
