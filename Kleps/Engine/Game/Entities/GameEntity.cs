using System;
using Newtonsoft.Json;

namespace Kleps.Engine.Game.Entities
{
    public class GameEntity
    {
        [JsonIgnore]
        public Game game { get; set; }

        public string id { get; set; }
        public string name { get; set; }


        public int _health;

        [JsonIgnore]
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

        [JsonIgnore]
        public EventHandler OnDeath { get; set; }
    }
}
