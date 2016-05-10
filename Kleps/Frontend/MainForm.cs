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
        FrontendHelper FEH;

        public MainForm() {
            FEH = FrontendHelper.Instance;
            FEH.Window = this;
            FEH.ScreenWidth = SystemInformation.VirtualScreen.Width;
            FEH.ScreenHeight = SystemInformation.VirtualScreen.Height;

            this.Size = new Size(FEH.ScreenWidth, FEH.ScreenHeight);
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            
            Loader = new SplashScreen();
            Loader.Show();
            
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e) {
            this.BeginInvoke(new Action(() => {
                this.Opacity = 1;
                this.ChromeBox.Focus();
            }));

            Loader.Dispose();
        }

        private void OnClosing(object sender, FormClosingEventArgs e) {
            this.Hide();
            Cef.Shutdown();
        }

        private void OnLoadChromeBox(object sender, EventArgs e) {
            ChromeBox.InitBrowser();
            ChromeBox.Size = new Size(FEH.ScreenWidth, FEH.ScreenHeight);
            ChromeBox.Location = new Point(0,0);
            ChromeBox.Browser.FrameLoadEnd += Browser_FrameLoadEnd;
            FEH.Browser = ChromeBox.Browser;

        }

        private void Exit(object sender, EventArgs e) {
            FEH.Select("exit");
        }

    }
}
