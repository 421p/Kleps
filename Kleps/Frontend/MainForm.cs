using System;
using System.Windows.Forms;
using CefSharp;
using System.Threading.Tasks;
using System.Drawing;

namespace Kleps.Frontend
{
    public partial class MainForm : Form
    {
        SplashScreen Loader;
        public MainForm()
        {
            InitializeComponent();
            Loader = new SplashScreen();
            Loader.Show();

        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e) {
            this.Opacity = 100;
            Loader.Dispose();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Cef.Shutdown();
        }

        private void OnLoadChromeBox(object sender, EventArgs e)
        {
            ChromeBox.InitBrowser();
            ChromeBox.Browser.FrameLoadEnd += Browser_FrameLoadEnd;
            
        }
    }
}
