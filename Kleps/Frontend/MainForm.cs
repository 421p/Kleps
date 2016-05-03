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

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void OnLoadChromeBox(object sender, EventArgs e)
        {
           ChromeBox.InitBrowser();
        }
    }
}
