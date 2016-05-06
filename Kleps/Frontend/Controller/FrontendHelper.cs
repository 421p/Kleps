using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private Sound Music;

        public void MusicStart() {
            Music = new Sound();
            Music.Start();
        }

        public void MusicMute() {
            Music.Mute();
        }

        public void MusicVolume(int val) {
            Music.Volume(val);
        }

    }
}
