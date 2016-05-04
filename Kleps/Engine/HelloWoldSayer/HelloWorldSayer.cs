using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kleps.Engine.HelloWoldSayer
{
    public class HelloWorldSayer {
        public Action onSomething { get; set; }

        public string getHelloWorld() {
            return "Hello World!";
        }
    }
}
