using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Kleps.Frontend.Controller {
    class Sound {
        public Sound() {
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            //player.SoundLocation = "html5/sound/DevilsDance.mp3";
            //player.Play();

            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

            wplayer.URL = "html5/sound/DevilsDance.mp3";
            wplayer.controls.play();
        }
    }
}
