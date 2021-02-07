using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteClient
{
    class ActivityHook
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;
        private LLKeyboardHook llkh;
        private List<Keys> HookedKeys = new List<Keys>();
        private IntPtr Hook = IntPtr.Zero;
        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;

        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(IntPtr hhk, int code, int wParam, ref keyBoardHookStruct lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LLKeyboardHook callback, IntPtr hInstance, uint theardID);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        public ActivityHook()
        {
            llkh = new LLKeyboardHook(HookProc);

            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                HookedKeys.Add(key);
        }

        ~ActivityHook()
        {
            Unhook();
        }

        private delegate int LLKeyboardHook(int Code, int wParam, ref keyBoardHookStruct lParam);
        public struct keyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;

        }

        public void hook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            Hook = SetWindowsHookEx(WH_KEYBOARD_LL, llkh, hInstance, 0);
        }

        public void Unhook()
        {
            UnhookWindowsHookEx(Hook);
        }

        private int HookProc(int Code, int wParam, ref keyBoardHookStruct lParam)
        {
            if (Code >= 0)
            {
                Keys key = (Keys)lParam.vkCode;
                if (HookedKeys.Contains(key))
                {
                    KeyEventArgs kArg = new KeyEventArgs(key);
                    if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && (KeyDown != null))
                        KeyDown(this, kArg);
                    else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP) && (KeyUp != null))
                        KeyUp(this, kArg);
                    if (kArg.Handled)
                        return 1;
                }
            }
            return CallNextHookEx(Hook, Code, wParam, ref lParam);
        }
    }
}
