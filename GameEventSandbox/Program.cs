using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kleps.Engine;
using Kleps.Engine.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GameEventSandbox
{
    class Program
    {
        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.UTF8;
            var backend = new Backend();
            backend.log("hello?");

            var game = backend.getGame();

            Console.WriteLine(game.teacher.name);
            Console.WriteLine(game.teacher.health);

            var d = new Deserializer(namingConvention: new CamelCaseNamingConvention());
            var obj = d.Deserialize<List<GameEventData>>(new StreamReader(new FileStream("../../../Kleps/DataRepository/Events.yaml", FileMode.Open)));

            Console.WriteLine(obj[1].rightAnswer);

            game.Run();

            var tt = new Timer(state => {
                Console.WriteLine("Klepach's hp: " + game.teacher.health);
                Console.WriteLine("Event List");
                game.events.ToArray().ToList().ForEach(ev => Console.WriteLine("Time left: " + ev.lifeTime));
            }, null, 0, 1000);

            game.OnGameOver += (s, e) => {
                tt.Dispose();
                Console.WriteLine("Ti proigral.");
            };

            Console.ReadLine();
        }
    }
}
