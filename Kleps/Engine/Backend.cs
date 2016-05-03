using System;
using System.Windows.Forms;
using Kleps.Engine.HelloWoldSayer;

namespace Kleps.Engine {

    class Backend {

        public HelloWorldSayer hws { get; }

        public Backend() {
            hws = new HelloWorldSayer();
        }
       
        public void log(string data) {
            Console.WriteLine(data);
        }

        public void alert(string data) {
            MessageBox.Show(data);
        }
    }
}