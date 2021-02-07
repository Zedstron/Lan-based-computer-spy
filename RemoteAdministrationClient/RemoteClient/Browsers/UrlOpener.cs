using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteClient.Browsers
{
    class UrlOpener
    {
        private static string getPath(string name)
        {
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
            {
                RegistryKey webClientsRootKey = hklm.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
                if (webClientsRootKey != null)
                    foreach (var subKeyName in webClientsRootKey.GetSubKeyNames())
                    {
                        if (subKeyName.Equals(name))
                        {
                            if (webClientsRootKey.OpenSubKey(subKeyName) != null)
                                if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell") != null)
                                    if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open") != null)
                                        if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command") != null)
                                        {
                                            return (string)webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command").GetValue(null);
                                        }
                        }
                    }
            }

            return null;
        }

        public static bool OpenUrl(string browser, string args)
        {
            try
            {
                string path = getPath(browser);
                if (path != null)
                {
                    Process.Start(path, args);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                RemoteClient.LogError(ex.ToString());
                return false;
            }
        }
    }
}
