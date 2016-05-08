using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Kleps.Engine.Game
{
    public class Names {
        [YamlAlias("teacher")]
        public string Teacher { get; set; }

        [YamlAlias("evil-student")]
        public string EvilStudent { get; set; }

        [YamlAlias("students")]
        public List<string> Students { get; set; }
    }

    public class GameConfig
    {
        [YamlAlias("names")]
        public Names Names { get; set; }
    }
}
