using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kleps.Engine.Events;
using Kleps.Engine.Game.Entities;

namespace Kleps.Engine.Game
{
    public class Game {
        public Teacher teacher { get; set; }
        public List<Student> students { get; set; }
        public List<GameEvent> events { get; set; }

        public Game() {
            
        }

        public Game(Teacher teacher, List<Student> students ) {
            this.teacher = teacher;
            this.students = students;
        }
    }
}
