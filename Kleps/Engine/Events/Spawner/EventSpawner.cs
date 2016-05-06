using System;
using System.Linq;
using System.Threading;


namespace Kleps.Engine.Events.Spawner
{
    public class EventSpawner {
        private readonly Game.Game _game;
        private Timer _timer;
        private readonly int _interval;
        private readonly int _chance;

        public EventHandler<SpawnEventArgs> OnSpawn { get; set; }

        public EventSpawner(Game.Game game) {
            _game = game;
            _interval = 500;
            _chance = 40;
        }

        protected GameEvent GenerateEvent() {
            
            var student = _game.students[new Random().Next(0, _game.students.Count - 1)];
            _game.students.Remove(student);

            var ev = new GameEvent {
                Owner = student,
                lifeTime = student.name.Contains("Підгорняк") ? 3 : 10
            };


            ev.OnTimerEnds += (s, e) => {
                _game.events.Remove(ev);
                _game.teacher.health -= student.name.Contains("Підгорняк") ? 200 : 20;
                _game.students.Add(ev.Owner);
            };
            return ev;
        }

        protected void SpawnCallback(object state) {
            if (new Random().Next(0, 100) < _chance) {
                this.OnSpawn(this, new SpawnEventArgs(GenerateEvent()));
            }
        }

        public void SpawnOn() {
            this._timer = new Timer(SpawnCallback, null, 0, _interval);
        }

        public void SpawnOff() {
            this._timer.Dispose();
        }

    }
}
