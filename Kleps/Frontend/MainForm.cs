using System;
using System.Windows.Forms;
using CefSharp;
using System.Drawing;

namespace Kleps.Frontend
{
    public partial class MainForm : Form
    {
        SplashScreen Loader;
        public int ScreenWidth = SystemInformation.VirtualScreen.Width;
        public int ScreenHeight = SystemInformation.VirtualScreen.Height;
        public MainForm() {
            this.Size = new Size(ScreenWidth, ScreenHeight);

            InitializeComponent();

            Loader = new SplashScreen();
            Loader.Show();
            
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e) {
            this.BeginInvoke(new Action(() => {
                this.Opacity = 1;
               
                } ));
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
