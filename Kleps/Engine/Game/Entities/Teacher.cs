using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kleps.Engine.Game.Entities
{
    public class Teacher : GameEntity
    {

        public int _health;

        protected int MaxHealth;

        [JsonIgnore]
        public int health {
            get { return _health; }

            set {
                if (value <= 0) {
                    _health = 0;
                    OnDeath(this, new EventArgs());
                }
                else if (value >= MaxHealth) {
                    _health = MaxHealth;
                }
                else {
                    _health = value;
                }
            }
        }

        public Teacher(int hp)
        {
            MaxHealth = hp;
            health = hp;
        }

        public void IncreaseHealth(int value)
        {
            this.health += value;
        }

        public void DecreaseHealth(int value)
        {
            this.health -= value;
        }
    }
}
