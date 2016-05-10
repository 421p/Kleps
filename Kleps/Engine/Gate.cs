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


        #region Sound


        public void musicStart() {
            FEH.MusicStart();
            FEH.Music.Volume(10);
        }
        public void musicMute() {
            FEH.Music.Mute();
        }
        public void musicVolume(int val) {
            FEH.Music.Volume(val);
        }

        public void musicClick() {
            FEH.Music.Click.controls.stop();
            FEH.Music.Click.controls.play();
        }

        public void healthSound(bool mute = false) {
            if (mute)
                FEH.Music.FaseHit.settings.mute = true;
            else FEH.Music.FaseHit.settings.mute = false;
            FEH.Music.FaseHit.controls.stop();
            FEH.Music.FaseHit.controls.play();
        }

        public void gameOverSound() {
            FEH.Music.GameOver.settings.mute = false;
            FEH.Music.Fade(FEH.Music.GameBackground, FEH.Music.GameOver, 1000);

        }

        public void startHistory() {
            FEH.Music.Fade(FEH.Music.Background, FEH.Music.Battle, 3000);
        }

        public void historyEngSound() {
            FEH.Music.HistoryEng.controls.play();
        }

        public void historyRusSound() {
            this.historyRusSoundMute();
            FEH.Music.HistoryRus.controls.play();
        }
        public bool historyRusSoundMute() {
            return FEH.Music.HistoryRus.settings.mute = !FEH.Music.HistoryRus.settings.mute;
        }

        public void startSubtitleMusic() {
            FEH.Music.Background.settings.mute = true;
            FEH.Music.Subtitle.controls.play();
        }
        public void stopSubtitleMusic() {
            FEH.Music.Background.settings.mute = false;
            FEH.Music.Subtitle.controls.stop();
        }

        public void toastySound() {
            FEH.Music.Toasty.settings.mute = false;
            FEH.Music.Toasty.controls.stop();
            FEH.Music.Toasty.controls.play();
        }

        #endregion Sound


        #region Game

        public void menuAction(string val) {
            FEH.Select(val);
        }

        public void changeScreenSize(bool state) {
            FEH.ChangeWindowMode(state);
        }

        public void startGame() {
            game.run();
            FEH.Music.GameBackground.settings.mute = false;
            FEH.Music.GameBackground.controls.play();
        }

        public void gameInit() {
            FEH.Music.MuteAll();
            FEH.LoadGame();
        }

        public void setName(string name) {
            this.getGame().teacher.name = name.Substring(0, name.Length > 16 ? 16 : name.Length).Trim();
        }

        public string getEventDataById(string id) {
            return JsonConvert.SerializeObject(game.getEventById(id));
        }

        public bool getAnswer(string id, string val) {
            return this.game.getEventById(id).Resolve(val);
        }

        public void loadStart() {
            FEH.LoadStart();
        }

        public bool isEvil(string id) {
            return game.getEventById(id).owner.name == game.Config.Names.EvilStudent;
        }


        #endregion Game


    }
}
