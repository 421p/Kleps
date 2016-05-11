using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Kleps.Engine.Game
{
    public class Names {
        [YamlMember(Alias = "teacher")]
        public string Teacher { get; set; }

        [YamlMember(Alias = "evil-student")]
        public string EvilStudent { get; set; }

        [YamlMember(Alias = "students")]
        public List<string> Students { get; set; }
    }

    public class GameConfig
    {
        [YamlMember(Alias = "names")]
        public Names Names { get; set; }

        [YamlMember(Alias = "params")]
        public Dictionary<string, int> Params { get; set; } 
    }
}
