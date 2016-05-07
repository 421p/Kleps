using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Kleps.Annotations;
using YamlDotNet.Serialization;

namespace Kleps.Engine.Events
{
    public class GameEventData
    {

        [YamlIgnore]
        public int id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public List<string> answers { get; set; }

        [YamlAlias("right_answer")]
        public string rightAnswer { get; set; }
    }
}
