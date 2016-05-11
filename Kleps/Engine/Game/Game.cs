using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kleps.Engine.Events;
using Kleps.Engine.Events.Spawner;
using Kleps.Engine.Game.Entities;
using Newtonsoft.Json;

namespace Kleps.Engine.Game
{
    public class Game {
        public Teacher teacher { get; set; }
        public List<Student> students { get; set; }
        public List<GameEvent> events { get; set; }
        public EventSpawner spawner { get; set; }
        public EventHandler OnGameOver { get; set; }
        public GameConfig Config { get; set; }

        public string State { get; private set; }

        public Game(GameConfig cfg):this(cfg, null, null){}

        public Game(GameConfig cfg, Teacher teacher, List<Student> students ) {
            Config = cfg;
            this.teacher = teacher;
            this.students = students;
            this.events = new List<GameEvent>();
            spawner = new EventSpawner(this);
            State = "not started";
        }

        public GameEvent getEventById(string id) {
            return events.FirstOrDefault(e => e.id == id);
        }

        /// <summary>
        /// Starts game.
        /// </summary>
        public void run()
        {
            State = "runnig";
            this.spawner.OnSpawn += (s, e) => {
                this.events.Add(e.Event);
            };
            this.spawner.SpawnOn();
        }

        /// <summary>
        /// Ends game.
        /// </summary>
        public void Over(bool isWinned)
        {
            State = isWinned ? "winned" : "losed";

            this.spawner.SpawnOff();
            this.events.ToArray().ToList().ForEach(e => e.timer.Dispose());
            this.events.Clear();

            OnGameOver?.Invoke(this, new EventArgs());
        }
    }
}
