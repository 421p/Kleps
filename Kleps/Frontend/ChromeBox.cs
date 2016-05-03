using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Kleps.Engine;

namespace Kleps.Frontend
{
    public partial class ChromeBox : UserControl
    {
        public ChromiumWebBrowser Browser { get; private set; }

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

            Browser = new ChromiumWebBrowser(path);

            Browser.RegisterJsObject("backend", new Backend());

            this.Controls.Add(Browser);
        }
    }
}
