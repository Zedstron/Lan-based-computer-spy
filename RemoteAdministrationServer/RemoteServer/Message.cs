using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RemoteServer
{
    public class Message : EventArgs
    {
        private byte[] raw;
        private string key;
        private TransferRate tr;

        public Message(byte[] obj, string key)
        {
            raw = obj;
            this.key = key;
            tr = null;
        }

        public Message(object tr, string key)
        {
            raw = null;
            this.key = key;
            this.tr = (TransferRate)tr;
        }

        public Object Data
        {
            get 
            {
                if (tr == null)
                    return ByteArrayToObject(raw);
                else
                    return tr;
            }
        }

        public string Key
        {
            get 
            {
                return key;
            }
        }

        private Object ByteArrayToObject(byte[] arrBytes)
        {
            try
            {
                MemoryStream memStream = new MemoryStream(arrBytes);
                BinaryFormatter binForm = new BinaryFormatter();
                binForm.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
                binForm.Binder = new DeserializationBinder();
                memStream.Seek(0, SeekOrigin.Begin);
                //Object obj = ProtoBuf.Serializer.Deserialize(typeof(object), memStream);
                Object obj = binForm.Deserialize(memStream);
                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
