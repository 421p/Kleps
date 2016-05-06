using System;
using System.Windows.Forms;
using Kleps.Engine.Game;
using Kleps.Engine.HelloWoldSayer;
using Newtonsoft.Json;

namespace Kleps.Engine {

    public class Backend {
        
        public HelloWorldSayer hws { get; }
        public Game.Game game { get; private set; }

        public Gate Gate { get; private set; }

        public Backend(GameConfig cfg) {
            hws = new HelloWorldSayer();
            game = GameFactory.CreateGame(cfg);
            Gate = new Gate(this);
        }
    }
}