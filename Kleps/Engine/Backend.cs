using System;
using System.Windows.Forms;
using Kleps.Engine.Game;
using Newtonsoft.Json;

namespace Kleps.Engine {

    public class Backend {
        
        public Game.Game game { get; private set; }

        public Gate Gate { get; private set; }

        public Backend(GameConfig cfg) {
            game = GameFactory.CreateGame(cfg);
            Gate = new Gate(this);
        }
    }
}