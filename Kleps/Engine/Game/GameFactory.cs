using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Kleps.Engine.Game.Entities;

namespace Kleps.Engine.Game
{
    class GameFactory
    {

        public static Game CreateGame(GameConfig cfg) {
            var game = new Game(cfg);
            game.teacher = CreateTeacher(game);
            game.students = CreateStudents(game).ToList();
            return game;
        }

        public static Teacher CreateTeacher(Game game) {
            return new Teacher
            {
                id = Guid.NewGuid().ToString("N"),
                name = game.Config.Names.Teacher,
                game = game,
                health = 1000,
                OnDeath = (s, e) => {
                    game.Over();
                }
            };
        }

        public static IEnumerable<Student> CreateStudents(Game game) {

            var names = game.Config.Names.Students.OrderBy(x => Guid.NewGuid()).Take(14).ToArray();

            for (int i = 0; i < 14; i++)
            {
                yield return CreateStudent(game, names[i]);
            }

            yield return CreateStudent(game, "Дар'я Підгорняк");
        } 

        public static Student CreateStudent(Game game, string name) {
            return new Student {
                id = Guid.NewGuid().ToString("N"),
                name = name,
                game = game,
                health = 100
            };
        }
    }
}
