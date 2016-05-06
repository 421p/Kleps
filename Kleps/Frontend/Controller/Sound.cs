using WMPLib;

namespace Kleps.Frontend.Controller {
    public class Sound {
        public WindowsMediaPlayer Background { get; private set; }
        public WindowsMediaPlayer Click { get; private set; }
        public Sound() {
            Background = new WMPLib.WindowsMediaPlayer();
            Click = new WMPLib.WindowsMediaPlayer();

            Background.settings.playCount = 10;
            Click.settings.playCount = 1;

            Background.settings.autoStart = false;
            Click.settings.autoStart = false;

            Background.URL = "DataRepository/Sound/DevilsDance.mp3";
            Click.URL = "DataRepository/Sound/Click.mp3";
            Click.settings.volume = 100;
        }
        public void StartBackground() {
            Background.controls.play();
        }

        public void StartClick() {
            Click.controls.stop();
            Click.controls.play();
        }
        public void Mute() {
            Click.settings.mute = !Click.settings.mute;
            Background.settings.mute = !Background.settings.mute;
        }

        public void Volume(int value) {
            
            Background.settings.volume = value;
        }
    }
}
