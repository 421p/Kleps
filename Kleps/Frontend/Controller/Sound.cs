using WMPLib;

namespace Kleps.Frontend.Controller {
    public class Sound {
        public WindowsMediaPlayer Background { get; private set; }
        public WindowsMediaPlayer Click { get; private set; }

        public WindowsMediaPlayer Battle { get; private set; }
        public WindowsMediaPlayer HistoryEng { get; private set; }
        public WindowsMediaPlayer HistoryRus { get; private set; }

        public Sound() {
            Background = new WindowsMediaPlayer();
            Background.settings.playCount = 10;
            Background.settings.autoStart = false;
            Background.URL = "DataRepository/Sound/DevilsDance.mp3";

            Battle = new WindowsMediaPlayer();
            Battle.settings.playCount = 1;
            Battle.settings.autoStart = false;
            Battle.URL = "DataRepository/Sound/bgmusic.mp3";
            Battle.settings.volume = 50;

            HistoryEng = new WindowsMediaPlayer();
            HistoryEng.settings.playCount = 1;
            HistoryEng.settings.autoStart = false;
            HistoryEng.URL = "DataRepository/Sound/eng.mp3";
            HistoryEng.settings.volume = 90;

            HistoryRus = new WindowsMediaPlayer();
            HistoryRus.settings.playCount = 1;
            HistoryRus.settings.autoStart = false;
            HistoryRus.URL = "DataRepository/Sound/rus.mp3";
            HistoryRus.settings.volume = 90;


            Click = new WindowsMediaPlayer();
            Click.settings.playCount = 1;            
            Click.settings.autoStart = false;
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
