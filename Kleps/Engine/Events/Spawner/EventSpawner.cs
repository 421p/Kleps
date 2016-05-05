using System;
using System.Threading;


namespace Kleps.Engine.Events.Spawner
{
    public class EventSpawner {
        private Game.Game _game;
        private Timer _timer;
        private readonly int _interval;
        private readonly int _chance;

        public EventHandler<SpawnEventArgs> OnSpawn { get; set; }

        public EventSpawner(Game.Game game) {
            _game = game;
            _interval = 1000;
            _chance = 40;
        }

        protected GameEvent GenerateEvent() {
            var ev = new GameEvent();
            ev.OnTimerEnds += (s, e) => {
                _game.events.Remove(ev);
                _game.teacher.health -= 10;
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
