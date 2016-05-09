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
        public MainForm Window;
        public ChromiumWebBrowser Browser;

        public int ScreenWidth;
        public int ScreenHeight;

        public void MusicStart() {
            Music = new Sound();
            Music.StartBackground();
        }

        public void Select(string val) {
            switch (val) {
                case "start":
                    Browser.Load(("file:///" + System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location
                ) + @"\html5\html\history.html").Replace('\\', '/'));
                    break;
                case "exit":
                    this.Window.BeginInvoke(new Action(() => this.Window.Close()));
                    this.Music.MuteAll();
                    break;
            }
        }
        public void LoadGame() {
            Browser.Load(("file:///" + System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location
                ) + @"\html5\html\game.html").Replace('\\', '/'));
        }

        public void LoadStart() {
            Browser.Load(("file:///" + System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location
                ) + @"\html5\html\main.html").Replace('\\', '/'));
        }

        public void ChangeWindowMode(bool state) {
            switch (state) {
                case true:
                    this.Window.BeginInvoke(new Action(() => {
                        this.Window.Width = ScreenWidth;
                        this.Window.Height = ScreenHeight;
                        this.Browser.Parent.Width = this.Window.Width;
                        this.Browser.Parent.Height = this.Window.Height;
                        this.Window.FormBorderStyle = FormBorderStyle.None;
                        this.Window.WindowState = FormWindowState.Maximized;
                        this.Window.btnClose.Show();
                    }));
                    break;
                case false:
                    this.Window.BeginInvoke(new Action(() => {
                        this.Window.Width = 1366;
                        this.Window.Height = 768;
                        this.Browser.Parent.Width = 1366;
                        this.Browser.Parent.Height = 768;
                        this.Window.FormBorderStyle = FormBorderStyle.FixedSingle;
                        this.Window.WindowState = FormWindowState.Normal;
                        this.Window.SetDesktopLocation((this.ScreenWidth - this.Window.Width) / 2, (this.ScreenHeight - this.Window.Height) / 2);
                        this.Window.btnClose.Hide();
                    }));
                   
                    break;
            }
            
        }

    }
}
