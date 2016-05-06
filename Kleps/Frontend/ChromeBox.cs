using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Kleps.Engine;
using Kleps.Engine.Events;
using Kleps.Engine.Game;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Kleps.Frontend
{
    public partial class ChromeBox : UserControl {
        private Backend _backend;
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

            var d = new Deserializer(namingConvention: new CamelCaseNamingConvention());
            var config = d.Deserialize<GameConfig>(new StreamReader(new FileStream("DataRepository/Config.yaml", FileMode.Open)));

            this._backend = new Backend(config);

            Browser.RegisterJsObject("backend", _backend.Gate);

            this.Controls.Add(Browser);
        }
    }
}
