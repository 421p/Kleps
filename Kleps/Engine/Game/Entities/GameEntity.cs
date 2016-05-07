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

        [JsonIgnore]
        public EventHandler OnDeath { get; set; }
    }
}
