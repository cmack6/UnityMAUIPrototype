using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.UI.Xaml;
using Microsoft.UI.Windowing;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

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
            StartUnity();
        }

        private void StartUnity()
        {
            _unityProcess = new Process();
            _unityProcess.StartInfo.FileName = "PathToYourUnityBuild.exe";
            _unityProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            _unityProcess.Start();
            _unityProcess.WaitForInputIdle();

            IntPtr unityHwnd = _unityProcess.MainWindowHandle;
            IntPtr mauiHwnd = WinRT.Interop.WindowNative.GetWindowHandle(MainWindow.Instance);

            SetParent(unityHwnd, mauiHwnd);
        }
    }
}
