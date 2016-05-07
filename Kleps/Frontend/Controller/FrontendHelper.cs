using System.Windows.Forms;
using System;
using CefSharp.WinForms;

namespace Kleps.Frontend.Controller {

    public class FrontendHelper {
        private static FrontendHelper instance;

        private FrontendHelper() { }

        public static FrontendHelper Instance {
            get {
                if (instance == null) {
                    instance = new FrontendHelper();
                }
                return instance;
            }
        }

        public Sound Music;
        public Form Window;
        public ChromiumWebBrowser Browser;

        public void MusicStart() {
            Music = new Sound();
            Music.StartBackground();
        }

        public void Select(string val) {
            switch (val) {
                case "start":
                    Browser.Load(("file:///" + System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location
                ) + @"\html5\html\game.html").Replace('\\', '/'));
                    break;
                case "exit":
                    this.Window.BeginInvoke(new Action(() => this.Window.Close()));
                    this.Music.MuteAll();
                    break;
            }
        }

    }
}
