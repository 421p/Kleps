using System.Windows.Forms;
using System;
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

        public void MusicStart() {
            Music = new Sound();
            Music.StartBackground();
        }

        public void Select(string val) {
            switch (val) {
                case "exit":
                    this.Window.BeginInvoke(new Action(() => this.Window.Close()));
                    this.Music.Mute();
                    break;
            }
        }

    }
}
