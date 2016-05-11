using System;
using System.Collections.Generic;
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
        public WindowsMediaPlayer FaseHit { get; private set; }
        public WindowsMediaPlayer GameBackground { get; private set; }
        public WindowsMediaPlayer Toasty { get; private set; }
        public WindowsMediaPlayer GameOver { get; private set; }
        public WindowsMediaPlayer Win { get; private set; }
        public WindowsMediaPlayer WinVoice { get; private set; }
        

        private WindowsMediaPlayer FadeOut;
        private WindowsMediaPlayer FadeIn;
        private Timer Timer;
        private int Duration;
        private int Ticks;

        public Sound() {
            this.Background = this.Init(new Dictionary<string, object>() {
                { "playCount", 10 },
                { "filename", "DevilsDance.mp3" }
            });

            this.Battle = this.Init(new Dictionary<string, object>() {
                { "volume", 50 },
                { "filename", "bgmusic.mp3" }
            });

            this.HistoryEng = this.Init(new Dictionary<string, object>() {
                { "filename", "eng.mp3" }
            });

            this.HistoryRus = this.Init(new Dictionary<string, object>() {
                { "volume", 90 },
                { "filename", "rus.mp3" }
            });

            this.Click = this.Init(new Dictionary<string, object>() {
                { "filename", "Click.mp3" }
            });

            this.Subtitle = this.Init(new Dictionary<string, object>() {
                { "playCount", 10 },
                { "mute", false },
                { "volume", 100 },
                { "filename", "StarWars.mp3" }
            });

            this.FaseHit = this.Init(new Dictionary<string, object>() {
                { "mute", true },
                { "playOnce", true },
                { "volume", 80 },
                { "filename", "hit.mp3" }
            });

            this.GameBackground = this.Init(new Dictionary<string, object>() {
                { "playCount", 10 },
                { "volume", 20 },
                { "filename", "moby.mp3" }
            });

            this.GameOver = this.Init(new Dictionary<string, object>() {
                { "volume", 80 },
                { "filename", "heartstop.mp3" }
            });

            this.Toasty = this.Init(new Dictionary<string, object>() {
                { "volume", 90 },
                { "filename", "toasty.mp3" }
            });

            this.Win = this.Init(new Dictionary<string, object>() {
                { "volume", 80 },
                { "filename", "SmokeWeed.mp3" }
            });
            this.WinVoice = this.Init(new Dictionary<string, object>() {
                { "volume", 90 },
                { "filename", "winervoice.mp3" }
            });

        }

        private WindowsMediaPlayer Init(Dictionary<string, object> options) {
            var sound = new WindowsMediaPlayer();
            sound.settings.autoStart = false;
            sound.settings.playCount = (int)(options.ContainsKey("playCount") ? options["playCount"] : 1);
            sound.settings.mute = (bool)(options.ContainsKey("mute") ? options["mute"] : false);
            sound.URL = String.Format("DataRepository/Sound/{0}", (string)options["filename"]);
            if((bool)(options.ContainsKey("playOnce") ? options["playOnce"] : false))
                sound.controls.play();
            sound.settings.volume = (int)(options.ContainsKey("volume") ? options["volume"] : 100);
            return sound;
        }

        public void Mute() {
            Click.settings.mute = !Click.settings.mute;
            Background.settings.mute = !Background.settings.mute;
        }

        public void StopPreGameSound() {
            Background.controls.stop();
            Click.controls.stop();
            Battle.controls.stop();
            HistoryEng.controls.stop();
            HistoryRus.controls.stop();
            Subtitle.controls.stop();
        }

        public void MuteAll() {
            Background.settings.mute = true;
            Click.settings.mute = true;
            Battle.settings.mute = true;
            HistoryEng.settings.mute = true;
            HistoryRus.settings.mute = true;
            Subtitle.settings.mute = true;
            GameBackground.settings.mute = true;
            GameOver.settings.mute = true;
            Toasty.settings.mute = true;
            FaseHit.settings.mute = true;
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

        public void FadeInEffect(WindowsMediaPlayer sound, int duration) {
            this.FadeIn = sound;
            this.Duration = duration;
            this.FadeIn.settings.volume = 0;
            this.FadeIn.controls.play();
            this.Timer = new Timer();
            this.Ticks = 0;

            this.Timer.Interval = this.Duration / 100;
            this.Timer.Elapsed += FadeInEffectTick;
            this.Timer.Enabled = true;

            this.Timer.Start();
        }

        private void FadeInEffectTick(object sender, ElapsedEventArgs e) {
            try {
                FadeIn.settings.volume += 100 / (this.Duration / 100);
            } catch (Exception x) {
                Console.WriteLine(x.Message);
            }

            this.Ticks += this.Duration / 100;
            if (this.Ticks >= this.Duration)
                this.Timer.Stop();

        }

        private void FadeTick(object sender, ElapsedEventArgs e) {
            try {
                FadeIn.settings.volume += 100 / (this.Duration / 100);
                FadeOut.settings.volume -= 100 / (this.Duration / 100);
            }catch(Exception x) {
                Console.WriteLine(x.Message);
            }
            
            this.Ticks += this.Duration / 100;
            if (this.Ticks >= this.Duration) {
                this.FadeOut.controls.stop();
                this.Timer.Stop();
            }
                
        }
    }
}
