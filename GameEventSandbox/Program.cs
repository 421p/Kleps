using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kleps.Engine;

namespace GameEventSandbox
{
    class Program
    {
        static void Main(string[] args) {
            var backend = new Backend();
            backend.log("kek?");

            Console.WriteLine(backend.getGame().teacher.name);
            Console.WriteLine(backend.getGame().teacher.health);
        }
    }
}
