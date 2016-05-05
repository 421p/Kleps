using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kleps.Engine.Events;
using Kleps.Engine.Events.Spawner;
using Kleps.Engine.Game.Entities;

namespace Kleps.Engine.Game
{
    public class Game {
        public Teacher teacher { get; set; }
        public List<Student> students { get; set; }
        public List<GameEvent> events { get; set; }
        public EventSpawner spawner { get; set; }

        public Game():this(null, null){}

        public Game(Teacher teacher, List<Student> students ) {
            this.teacher = teacher;
            this.students = students;
            spawner = new EventSpawner(this);
        }

        public void Run() {
            this.spawner.OnSpawn += (s, e) => {
                Console.WriteLine("Event spawned.");
            };
            this.spawner.SpawnOn();
        }
    }
}
