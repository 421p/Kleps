using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Kleps.Engine;
using Kleps.Engine.Game;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GameEventVIsualSandbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            Cef.Initialize();


            var browser = new ChromiumWebBrowser("http://customrendering/");
            this.Controls.Add(browser);

            browser.LoadHtml(File.ReadAllText("test.html"), "http://customrendering/");


            var d = new Deserializer(namingConvention: new CamelCaseNamingConvention());
            var config = d.Deserialize<GameConfig>(new StreamReader(new FileStream("../../../../Kleps/DataRepository/Config.yaml", FileMode.Open)));


            var backend = new Backend(config);

            var game = backend.game;

            game.OnGameOver += (sunder, args) => {
                browser.EvaluateScriptAsync("alert('TI PROIGRAL.');");
            };

            browser.RegisterJsObject("backend", backend.Gate);

            browser.FrameLoadEnd += (asd, das) => browser.ShowDevTools();

            this.FormClosing += (s, ee) => Cef.Shutdown();

        }
    }
}
