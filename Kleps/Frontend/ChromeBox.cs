using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Kleps.Engine;

namespace Kleps.Frontend
{
    public partial class ChromeBox : UserControl
    {
        public ChromeBox()
        {
            InitializeComponent();
        }

        public void InitBrowser() {
            Cef.Initialize();

            var path = (
                "file:///" + System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location
                ) + @"\html5\html\main.html").Replace('\\', '/');

            var myBrowser = new ChromiumWebBrowser(path);

            myBrowser.RegisterJsObject("backend", new Backend());

            this.Controls.Add(myBrowser);
        }
    }
}
