using System;
using System.Windows.Forms;
using Kleps.Engine.Game;
using Kleps.Engine.HelloWoldSayer;

namespace Kleps.Engine {

    public class Backend {
        
        public HelloWorldSayer hws { get; }
        public Game.Game game { get; }

        public Backend() {
            hws = new HelloWorldSayer();
            game = GameFactory.CreateGame();
        }
       
        public void log(string data) {
            Console.WriteLine(data);
        }

        public void alert(string data) {
            MessageBox.Show(data);
        }
    }
}