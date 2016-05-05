using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            backend.log("kek?");

            Console.WriteLine(backend.getGame().teacher.name);
            Console.WriteLine(backend.getGame().teacher.health);

            var d = new Deserializer(namingConvention: new CamelCaseNamingConvention());
            var obj = d.Deserialize<List<GameEventData>>(new StreamReader(new FileStream("../../../Kleps/DataRepository/Events.yaml", FileMode.Open)));

            Console.WriteLine(obj[1].rightAnswer);
        }
    }
}
