using System;
using System.Collections.Generic;
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
            _interval = 2000;
            _chance = 40;
        }

        protected GameEvent GenerateEvent() {
            
            var student = _game.students[new Random().Next(0, _game.students.Count - 1)];
            _game.students.Remove(student);

            bool isPidgornyak = student.name.Contains("Підгорняк");

            var ev = new GameEvent {
                owner = student,
                lifeTime = isPidgornyak ? 3 : 10,
                type = "question",
                rightAnswer = isPidgornyak? "die" : "reflection",
                question = isPidgornyak ? "Alias for 'exit' in PHP." : "Механизм позволяющий получить доступ к приватным полям." ,
                answers = isPidgornyak ? 
                new List<string> {"quit", "leave", "escape", "die"} : 
                new List<string> {"inflection", "reflection", "inheriting", "implementing"}
            };

            ev.OnTimerEnds += (s, e) => {
                _game.events.Remove(ev);
                _game.teacher.health -= isPidgornyak ? 200 : 20;
                _game.students.Add(ev.owner);
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
