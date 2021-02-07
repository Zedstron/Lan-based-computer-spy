using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteServer
{
    class Router
    {
        private static List<string> ipPort = new List<string>();
        private static List<string> keys = new List<string>();

        public static void Add(string pair, string key)
        {
            ipPort.Add(pair);
            keys.Add(key);
        }

        public static void Remove(string pair)
        {
            keys.Remove(Key(pair));
            ipPort.Remove(pair);
        }

        public static string Key(string pair)
        {
            string key = null;
            int index = 0;

            foreach(string p in ipPort)
            {
                if(p.Equals(pair))
                {
                    key = keys[index];
                    break;
                }

                index++;
            }

            return key;
        }

        public static void Clear()
        {
            ipPort.Clear();
            keys.Clear();
        }

        public static string Pair(string key)
        {
            string pair = null;
            int index = 0;

            foreach (string k in keys)
            {
                if (k.Equals(key))
                {
                    pair = ipPort[index];
                    break;
                }

                index++;
            }

            return pair;
        }
    }
}
