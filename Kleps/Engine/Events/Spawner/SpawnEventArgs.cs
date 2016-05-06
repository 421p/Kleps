using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kleps.Engine.Events.Spawner
{
    public class SpawnEventArgs : EventArgs
    {
        public GameEvent Event { get; }

        public SpawnEventArgs(GameEvent e) {
            Event = e;
        }
    }
}
