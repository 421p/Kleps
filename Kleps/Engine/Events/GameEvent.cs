using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kleps.Engine.Game.Entities;

namespace Kleps.Engine.Events
{
    public class GameEvent
    {
        public Student Owner { get; set; }
        public Timer timer { get; set; }

        public EventHandler OnTimerEnds { get; set; }

        public int lifeTime { get; set; }

        public GameEvent() {
            lifeTime = 30;
            CountStart();
        }

        public void CountStart() {
            this.timer = new Timer(state => {

                lifeTime--;
                if (lifeTime != 0) return;

                OnTimerEnds(this, new EventArgs());
                CountStop();
            }, null, 0, 1000);
        }

        public void CountStop() {
            this.timer.Dispose();
        }
    }
}
