using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kleps.Engine.Game.Entities;

namespace Kleps.Engine.Game
{
    class GameFactory
    {

        public static Game CreateGame() {
            var game = new Game();
            game.teacher = CreateTeacher(game);
            game.students = CreateStudents(game).ToList();
            return game;
        }

        public static Teacher CreateTeacher(Game game) {
            return new Teacher
            {
                id = Guid.NewGuid().ToString("N"),
                name = Guid.NewGuid().ToString("N"),
                game = game,
                health = 500
            };
    }

        public static IEnumerable<Student> CreateStudents(Game game) {
            for (int i = 0; i < 15; i++)
            {
                yield return CreateStudent(game);
            }
        } 

        public static Student CreateStudent(Game game) {
            return new Student {
                id = Guid.NewGuid().ToString("N"),
                name = Guid.NewGuid().ToString("N"),
                game = game,
                health = 100
            };
        }
    }
}
