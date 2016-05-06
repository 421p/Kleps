using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kleps.Engine;
using Kleps.Engine.Events;
using Kleps.Engine.Game;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GameEventSandbox
{
    class Program
    {
        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.UTF8;
            var d = new Deserializer(namingConvention: new CamelCaseNamingConvention());
            var config = d.Deserialize<GameConfig>(new StreamReader(new FileStream("../../../Kleps/DataRepository/Config.yaml", FileMode.Open)));


            var backend = new Backend(config);
            backend.log("hello?");

            var game = backend.getGame();

            Console.WriteLine(game.teacher.name);
            Console.WriteLine(game.teacher.health);

            game.Run();

            var tt = new Timer(state => {
                Console.Clear();
                Console.Write($"{game.teacher.name}'s hp: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(game.teacher.health);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");
                Console.WriteLine("Event List\n");
                game.events.ToArray().ToList().ForEach(ev => {
                    Console.Write($"[{ev.lifeTime}s] ");
                    Console.ForegroundColor = ev.Owner.name.Contains("Підгорняк")
                        ? ConsoleColor.Yellow
                        : ConsoleColor.Magenta;
                    Console.Write($"{ev.Owner.name} ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("needs your help!\n");

                });
            }, null, 0, 900);
            

            game.OnGameOver += (s, e) => {
                tt.Dispose();
                Console.WriteLine("Ti proigral.");
            };

            Console.ReadLine();
        }
    }
}
