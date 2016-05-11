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
            Music.Background.controls.play();
        }

        public void Load(string page) {
            var path = String.Format(
                @"file:///{0}\html5\html\{1}.html", 
                System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), 
                page
                ).Replace('\\', '/');
            Browser.Load(path);
         }

        public void Select(string val) {
            switch (val) {
                case "start":
                    this.Load("history");
                    break;
                case "exit":
                    this.Window.BeginInvoke(new Action(() => this.Window.Close()));
                    this.Music.MuteAll();
                    break;
            }
        }

        public void ChangeWindowMode(bool state) {
            switch (state) {
                case true:
                    this.Window.BeginInvoke(new Action(() => {
                        this.Window.FormBorderStyle = FormBorderStyle.None;
                        this.Window.WindowState = FormWindowState.Maximized;
                        this.Window.Width = ScreenWidth;
                        this.Window.Height = ScreenHeight;
                        this.Browser.Parent.Width = this.Window.Width;
                        this.Browser.Parent.Height = this.Window.Height;
                        this.Window.btnClose.Show();
                    }));
                    break;
                case false:
                    this.Window.BeginInvoke(new Action(() => {
                        this.Window.FormBorderStyle = FormBorderStyle.FixedSingle;
                        this.Window.WindowState = FormWindowState.Normal;
                        this.Window.Width = 1366;
                        this.Window.Height = 768;
                        this.Browser.Parent.Width = this.Window.Width;
                        this.Browser.Parent.Height = this.Window.Height - 50;
                        this.Window.SetDesktopLocation((this.ScreenWidth - this.Window.Width) / 2, (this.ScreenHeight - this.Window.Height) / 2);
                        this.Window.btnClose.Hide();
                    }));
                   
                    break;
            }
            
        }     

    }
}
