using System;
using System.Windows.Forms;
using Kleps.Engine.Game;
using Kleps.Engine.HelloWoldSayer;
using Newtonsoft.Json;

namespace Kleps.Engine {

    public class Backend {
        
        public HelloWorldSayer hws { get; }
        protected Game.Game game { get; }

        public Backend(GameConfig cfg) {
            hws = new HelloWorldSayer();
            game = GameFactory.CreateGame(cfg);
        }
       
        public void log(string data) {
            Console.WriteLine(data);
        }

        public void alert(string data) {
            MessageBox.Show(data);
        }

        public Game.Game getGame() {
            return game;
        }

        public string getGameEventsJson()
        {
            return JsonConvert.SerializeObject(game.events);
        }

        public string getTeacherJson() {
            return JsonConvert.SerializeObject(game.teacher);
        }

        public void stopEventCountingById(string id) {
            game.getEventById(id).CountStop();
        }

        public void startEventCountingById(string id)
        {
            game.getEventById(id).CountStart();
        }

        public void startGame() {
            game.run();
        }
    }
}