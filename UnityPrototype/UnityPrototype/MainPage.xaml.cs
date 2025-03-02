using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.UI.Xaml;
using Microsoft.UI.Windowing;
using WinRT.Interop;

namespace UnityPrototype
{
    public partial class MainPage : ContentPage
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private Process _unityProcess;

        public MainPage()
        {
            InitializeComponent();
            //StartUnity();
        }

        private void StartUnity()
        {
            _unityProcess = new Process();
            _unityProcess.StartInfo.FileName = "PathToYourUnityBuild.exe";
            _unityProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            _unityProcess.Start();
            _unityProcess.WaitForInputIdle();

            IntPtr unityHwnd = _unityProcess.MainWindowHandle;
            var mauiWindow = Microsoft.Maui.Controls.Application.Current.Windows[0].Handler.PlatformView;
            IntPtr hWnd = WindowNative.GetWindowHandle(mauiWindow);

            SetParent(unityHwnd, hWnd);
        }
    }
}
