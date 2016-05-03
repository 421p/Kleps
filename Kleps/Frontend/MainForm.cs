using System;
using System.Windows.Forms;
using CefSharp;

namespace Kleps.Frontend
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            

        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e) {
            Console.WriteLine("End");
            this.Opacity = 100;
            
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void OnLoadChromeBox(object sender, EventArgs e)
        {
            
            Console.WriteLine("START");
            ChromeBox.InitBrowser();
            ChromeBox.Browser.FrameLoadEnd += Browser_FrameLoadEnd;
            
        }
    }
}
