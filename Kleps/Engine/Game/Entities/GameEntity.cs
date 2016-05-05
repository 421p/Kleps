using System;

namespace Kleps.Engine.Game.Entities
{
    public class GameEntity
    {
        public Game game { get; set; }
        public string id { get; set; }
        public string name { get; set; }

        private int _health;
    
        public int health {
            get { return _health; }
            set {
                if (value <= 0) {
                    _health = 0;
                    OnDeath(this, new EventArgs());
                }
                else {
                    _health = value;
                }
            }
        }

        public EventHandler OnDeath { get; set; }
    }
}
