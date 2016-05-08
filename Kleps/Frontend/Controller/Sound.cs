using System;
using System.Timers;
using WMPLib;

namespace Kleps.Frontend.Controller {
    public class Sound {
        public WindowsMediaPlayer Background { get; private set; }
        public WindowsMediaPlayer Click { get; private set; }
        public WindowsMediaPlayer Subtitle { get; private set; }

        public WindowsMediaPlayer Battle { get; private set; }
        public WindowsMediaPlayer HistoryEng { get; private set; }
        public WindowsMediaPlayer HistoryRus { get; private set; }

        private WindowsMediaPlayer FadeOut;
        private Timer Timer;
        private WindowsMediaPlayer FadeIn;
        private int Duration;
        private int Ticks;

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
            HistoryEng.settings.volume = 100;

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

            Subtitle = new WindowsMediaPlayer();
            Subtitle.settings.playCount = 1;
            Subtitle.settings.autoStart = false;
            Subtitle.URL = "DataRepository/Sound/StarWars.mp3";
            Subtitle.settings.volume = 100;
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

        public void MuteAll() {
            Background.settings.mute = true;
            Click.settings.mute = true;
            Battle.settings.mute = true;
            HistoryEng.settings.mute = true;
            HistoryRus.settings.mute = true;
        }

        public void Volume(int value) {
            Background.settings.volume = value;
        }

        public void Fade(WindowsMediaPlayer Out, WindowsMediaPlayer In, int duration) {
            this.FadeOut = Out;
            this.FadeIn = In;
            this.Duration = duration;
            this.FadeIn.settings.volume = 0;
            this.FadeIn.controls.play();
            this.Timer = new Timer();
            this.Ticks = 0;

            this.Timer.Interval = this.Duration / 100;
            this.Timer.Elapsed += FadeTick;
            this.Timer.Enabled = true;

            this.Timer.Start();
        }

        private void FadeTick(object sender, ElapsedEventArgs e) {
            try {
                FadeIn.settings.volume += 100 / (this.Duration / 100);
                FadeOut.settings.volume -= 100 / (this.Duration / 100);
            }catch(Exception x) {
                Console.WriteLine("OOPS");
            }
            
            this.Ticks += this.Duration / 100;
            if (this.Ticks >= this.Duration) {
                this.FadeOut.controls.stop();
                this.Timer.Stop();
            }
                
        }
    }
}
