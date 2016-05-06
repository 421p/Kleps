using System;
using Kleps.Frontend.Controller;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Kleps.Engine
{
    public class Gate {

        private readonly Backend _backend ;

        private FrontendHelper FEH => FrontendHelper.Instance;

        private Game.Game game => _backend.game;

        public Gate(Backend back) {
            _backend = back;
        }

        public void log(string data) {
            Console.WriteLine(data);
        }

        public void alert(string data){
            MessageBox.Show(data);
        }

        public Game.Game getGame(){
            return game;
        }

        public string getGameEventsJson(){
            return JsonConvert.SerializeObject(game.events);
        }

        public string getTeacherJson(){
            return JsonConvert.SerializeObject(game.teacher);
        }

        public void stopEventCountingById(string id){
            game.getEventById(id).CountStop();
        }

        public void startEventCountingById(string id){
            game.getEventById(id).CountStart();
        }

        public void startGame(){
            game.run();
        }

        #region Frontend

        public void musicStart() {
            FEH.MusicStart();
            FEH.MusicVolume(50);
        }
        public void musicMute() {
            FEH.MusicMute();
        }
        public void musicVolume(int val) {
            Console.WriteLine(val);
            FEH.MusicVolume(val);
        }



        #endregion


    }
}
