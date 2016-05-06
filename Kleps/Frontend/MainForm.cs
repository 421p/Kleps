using System;
using System.Windows.Forms;
using CefSharp;
using System.Drawing;
using Kleps.Frontend.Controller;

namespace Kleps.Frontend
{
    public partial class MainForm : Form
    {
        SplashScreen Loader;
        public int ScreenWidth = SystemInformation.VirtualScreen.Width-400;
        public int ScreenHeight = SystemInformation.VirtualScreen.Height-400;
        public MainForm() {
            this.Size = new Size(ScreenWidth, ScreenHeight);
            //this.WindowState = FormWindowState.Maximized;
            InitializeComponent();

            Loader = new SplashScreen();
            Loader.Show();
            new Sound();
            
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e) {
            this.BeginInvoke(new Action(() => {
                this.Opacity = 1;
                }));
            Loader.Dispose();
        }

        private void OnClosing(object sender, FormClosingEventArgs e) {
            this.Hide();
            Cef.Shutdown();
        }

        private void OnLoadChromeBox(object sender, EventArgs e) {
            ChromeBox.InitBrowser();
            ChromeBox.Size = new Size(ScreenWidth, ScreenHeight);
            ChromeBox.Location = new Point(0,0);
            ChromeBox.Browser.FrameLoadEnd += Browser_FrameLoadEnd;

        }

        private void Exit(object sender, EventArgs e) {
            this.Close();
        }

    }
}
