using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Kleps.Engine
{
    public class Gate {

        private readonly Backend _backend ;

        private Game.Game game => _backend.game;

        public Gate(Backend back) {
            _backend = back;
        }

        public void log(string data)
        {
            Console.WriteLine(data);
        }

        public void alert(string data)
        {
            MessageBox.Show(data);
        }

        public Game.Game getGame()
        {
            return game;
        }

        public string getGameEventsJson()
        {
            return JsonConvert.SerializeObject(game.events);
        }

        public string getTeacherJson()
        {
            return JsonConvert.SerializeObject(game.teacher);
        }

        public void stopEventCountingById(string id)
        {
            game.getEventById(id).CountStop();
        }

        public void startEventCountingById(string id)
        {
            game.getEventById(id).CountStart();
        }

        public void startGame()
        {
            game.run();
        }
    }
}
