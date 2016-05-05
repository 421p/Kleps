using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kleps.Engine.Game.Entities;

namespace Kleps.Engine.Events
{
    public class GameEvent
    {
        public Student Owner { get; set; }
        public Timer timer { get; set; }

        public EventHandler OnTimerEnds { get; set; }

        public int lifeTime { get; private set; }

        public GameEvent() {
            this.timer = new Timer();
            timer.Interval = 1000;
            lifeTime = 30;

            timer.Tick += (s, e) => {
                lifeTime--;

                if (lifeTime != 0) return;

                timer.Stop();
                OnTimerEnds(this, new EventArgs());
            };

        }
    }
}
