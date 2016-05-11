using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Kleps.Engine.Game;
using Kleps.Engine.Game.Entities;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Timer = System.Threading.Timer;


namespace Kleps.Engine.Events.Spawner
{
    public class EventSpawner {
        private readonly Game.Game _game;
        private Timer _timer;
        private readonly int _interval;
        private readonly int _chance;
        private List<GameEventData> _eventDataset; 

        public string YamlPath { get; set; }

        public EventHandler<SpawnEventArgs> OnSpawn { get; set; }

        public EventSpawner(Game.Game game) {
            _game = game;
            _interval = 1488;
            _chance = 40;
            YamlPath = "DataRepository/Events.yaml";
        }

        protected GameEvent GenerateEvent() {

            if (_eventDataset == null) {
                _eventDataset = getEventData();
            }

            Student evilStudent;

            bool evilEvent = false;

            if ((
                evilStudent = 
                _game.students.FirstOrDefault(st => st.name == _game.Config.Names.EvilStudent)) != null
                ) {
                    if (new Random().Next(0, 100) < 20) {
                        evilEvent = true;
                }
            }

            var student = evilEvent ? evilStudent : _game.students[new Random().Next(0, _game.students.Count)];
            _game.students.Remove(student);

            var eventData = _eventDataset.OrderBy(x => Guid.NewGuid())
                .FirstOrDefault(x => x.type == (evilEvent ? "evil" : "normal"));

            if (eventData == null) {

                if ((_eventDataset.Count(x => x.type == "normal") == 0) && (_game.events.Count == 0)) {
                    _game.Over(true);
                    return null;
                }

                if (evilEvent) {
                    eventData = _eventDataset.OrderBy(x => Guid.NewGuid())
                        .FirstOrDefault(x => x.type == "normal");
                }
                else {
                    return null;
                }
            }

            _eventDataset.Remove(eventData);

            var ev = new GameEvent {
                owner = student,
                lifeTime = evilEvent ? _game.Config.Params["evil-time"] : _game.Config.Params["normal-time"],
                type = "question",
                rightAnswer = eventData.rightAnswer,
                question = eventData.text,
                answers = eventData.answers
            };

            ev.OnTimerEnds += (s, e) => {
                ev.Exterminate();
                _game.teacher.DecreaseHealth(
                    evilEvent ? _game.Config.Params["evil-dps-timeout"] : _game.Config.Params["normal-dps-timeout"]
                );
            };

            ev.OnRejected += (s, e) => {
                ev.Exterminate();
                _game.teacher.DecreaseHealth(
                    evilEvent ? _game.Config.Params["evil-dps-reject"] : _game.Config.Params["normal-dps-reject"]
                );
            };

            ev.OnAccepted += (s, e) => {
                ev.Exterminate();
                _game.teacher.IncreaseHealth(
                evilEvent ? _game.Config.Params["evil-heal"] : _game.Config.Params["normal-heal"]
                );
            };

            return ev;
        }

        protected void SpawnCallback(object state)
        {
            if (this._game.events.Count >= 4) return;

            if (new Random().Next(0, 100) < _chance) {
                var ev = GenerateEvent();
                if (ev != null) {
                    this.OnSpawn(this, new SpawnEventArgs(ev));
                }
            }
        }

        /// <summary>
        /// Starting event spawning.
        /// </summary>
        public void SpawnOn() {
            this._timer = new Timer(SpawnCallback, null, 0, _interval);
        }

        /// <summary>
        /// Stops event spawning.
        /// </summary>
        public void SpawnOff() {
            this._timer.Dispose();
        }

        private List<GameEventData> getEventData()
        {
            return new Deserializer(namingConvention: new CamelCaseNamingConvention())
                .Deserialize<List<GameEventData>>(
                new StreamReader(
                    new FileStream(
                        YamlPath, 
                        FileMode.Open
                    )
                )
            );
        }
    }
}
