using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Kleps.Engine.Events
{
    public class GameEventData
    {
        public string text { get; set; }
        public List<string> answers { get; set; }

        [YamlAlias("right_answer")]
        public string rightAnswer { get; set; }

    }
}
