using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kleps.Engine.Game.Entities;
using Newtonsoft.Json;

namespace Kleps.Engine.Events
{
    public class GameEvent
    {
        public string id { get; private set; }
        public Student owner { get; set; }

        [JsonIgnore]
        public Timer timer { get; set; }

        public string type { get; set; }
        public string rightAnswer { get; set; }
        public string question { get; set; }
        public List<string> answers { get; set; }

        [JsonIgnore]
        public EventHandler OnTimerEnds { get; set; }

        [JsonIgnore]
        public EventHandler OnAccepted { get; set; }

        [JsonIgnore]
        public EventHandler OnRejected { get; set; }

        public int lifeTime { get; set; }

        public GameEvent() {
            id = Guid.NewGuid().ToString("N");
            lifeTime = 30;
            CountStart();
        }

        /// <summary>
        /// Try to resolve question.
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public bool Resolve(string answer)
        {
            if (answer == this.rightAnswer) {
                this.OnAccepted?.Invoke(this, new EventArgs());
                return true;
            }

            this.OnRejected?.Invoke(this, new EventArgs());
            return false;
        }

        /// <summary>
        /// Starts internal timer.
        /// </summary>
        public void CountStart() {
            this.timer = new Timer(state => {

                lifeTime--;
                if (lifeTime != 0) return;

                OnTimerEnds(this, new EventArgs());
                CountStop();
            }, null, 0, 1000);
        }

        /// <summary>
        /// Pauses internal timer.
        /// </summary>
        public void CountStop() {
            this.timer.Dispose();
        }

        /// <summary>
        /// Removes event from a game.
        /// </summary>
        public void Exterminate()
        {
            if (this.timer != null) {
                this.CountStop();
            }

            this.owner.game.events.Remove(this);
            this.owner.game.students.Add(this.owner);
        }
    }
}
