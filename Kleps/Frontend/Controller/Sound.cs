using WMPLib;

namespace Kleps.Frontend.Controller {
    class Sound {
        public WindowsMediaPlayer Player { get; private set; }
        public Sound() {
            Player = new WMPLib.WindowsMediaPlayer();
            Player.settings.playCount = 10;
            Player.settings.autoStart = false;
            Player.URL = "html5/sound/DevilsDance.mp3";
        }
        public void Start() {
            Player.controls.play();
        }
        public void Mute() {
            Player.settings.mute = !Player.settings.mute;
        }

        public void Volume(int value) {
            Player.settings.volume = value;
        }
    }
}
