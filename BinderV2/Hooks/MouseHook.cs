﻿using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Hooks.Mouse
{
    public static class MouseHook
    {
        #region Declarations
        public static event MouseEventHandler MouseDown;
        public static event MouseEventHandler MouseUp;
        public static event MouseEventHandler MouseMove;

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEHOOKSTRUCT
        {
            public POINT pt;
            public IntPtr hwnd;
            public int wHitTestCode;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

        }

        const int WM_LBUTTONDOWN = 0x201;
        const int WM_LBUTTONUP = 0x202;
        const int WM_MOUSEMOVE = 0x0200;
        const int WM_MOUSEWHEEL = 0x020A;
        const int WM_RBUTTONDOWN = 0x0204;
        const int WM_RBUTTONUP = 0x0205;
        const int WM_MBUTTONUP = 0x208;
        const int WM_MBUTTONDOWN = 0x207;

        static IntPtr hHook = IntPtr.Zero;
        static IntPtr hModule = IntPtr.Zero;
        static bool hookInstall = false;
        static API.HookProc hookDel;
        #endregion

        /// <summary>
        /// Hook install method.
        /// </summary>
        private static void InstallHook()
        {
            if (IsHookInstalled)
                return;

            hModule = Marshal.GetHINSTANCE(Assembly.GetEntryAssembly().ManifestModule);
            hookDel = new API.HookProc(HookProcFunction);

            hHook = API.SetWindowsHookEx(API.HookType.WH_MOUSE_LL,
                    hookDel, hModule, 0);

            if (hHook != IntPtr.Zero)
                hookInstall = true;
            else
                throw new Win32Exception("Can't install low level keyboard hook!");
        }
        /// <summary>
        /// If hook installed return true, either false.
        /// </summary>
        public static bool IsHookInstalled
        {
            get { return hookInstall && hHook != IntPtr.Zero; }
        }
        /// <summary>
        /// Module handle in which hook was installed.
        /// </summary>
        public static IntPtr ModuleHandle
        {
            get { return hModule; }
        }

        /// <summary>
        /// Uninstall hook method.
        /// </summary>
        public static void UnInstallHook()
        {
            if (IsHookInstalled)
            {
                if (!API.UnhookWindowsHookEx(hHook))
                    throw new Win32Exception("Can't uninstall low level keyboard hook!");
                hHook = IntPtr.Zero;
                hModule = IntPtr.Zero;
                hookInstall = false;
            }
        }

        static MouseHook()
        {
            InstallHook();
        }

        /// <summary>
        /// Hook process messages.
        /// </summary>
        /// <returns></returns>
        static IntPtr HookProcFunction(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode == 0)
            {
                MSLLHOOKSTRUCT mhs = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

                #region switch
                switch (wParam.ToInt32())
                {
                    case WM_LBUTTONDOWN:
                        MouseDown?.Invoke(null,
                            new MouseEventArgs(MouseButtons.Left,
                                1,
                                mhs.pt.X,
                                mhs.pt.Y,
                                0));
                        break;
                    case WM_LBUTTONUP:
                        MouseUp?.Invoke(null,
                            new MouseEventArgs(MouseButtons.Left,
                                1,
                                mhs.pt.X,
                                mhs.pt.Y,
                                0));
                        break;
                    case WM_MBUTTONDOWN:
                        MouseDown?.Invoke(null,
                            new MouseEventArgs(MouseButtons.Middle,
                                1,
                                mhs.pt.X,
                                mhs.pt.Y,
                                0));
                        break;
                    case WM_MBUTTONUP:
                        MouseUp?.Invoke(null,
                            new MouseEventArgs(MouseButtons.Middle,
                                1,
                                mhs.pt.X,
                                mhs.pt.Y,
                                0));
                        break;
                    case WM_MOUSEMOVE:
                        MouseMove?.Invoke(null,
                            new MouseEventArgs(MouseButtons.None,
                                1,
                                mhs.pt.X,
                                mhs.pt.Y,
                                0));
                        break;
                    case WM_MOUSEWHEEL:
                        MouseMove?.Invoke(null,
                            new MouseEventArgs(MouseButtons.None, mhs.time,
                                mhs.pt.X, mhs.pt.Y, mhs.mouseData >> 16));
                        //Debug.WriteLine(string.Format("X:{0}; Y:{1}; MD:{2}; Time:{3}; EI:{4}; wParam:{5}; lParam:{6}",
                        //            mhs.pt.X, mhs.pt.Y, mhs.mouseData, mhs.time, mhs.dwExtraInfo, wParam.ToString(), lParam.ToString()));
                        break;
                    case WM_RBUTTONDOWN:
                        MouseDown?.Invoke(null,
                            new MouseEventArgs(MouseButtons.Right,
                                1,
                                mhs.pt.X,
                                mhs.pt.Y,
                                0));
                        break;
                    case WM_RBUTTONUP:
                        MouseUp?.Invoke(null,
                            new MouseEventArgs(MouseButtons.Right,
                                1,
                                mhs.pt.X,
                                mhs.pt.Y,
                                0));
                        break;
                    default:

                        break;
                }
                #endregion
            }

            return API.CallNextHookEx(hHook, nCode, wParam, lParam);
        }
    }

    static class API
    {
        public delegate IntPtr HookProc(int nCode, IntPtr wParam, [In] IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, [In] IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(HookType hookType, HookProc lpfn,
        IntPtr hMod, int dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        public enum HookType : int
        {
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }
    }
}
