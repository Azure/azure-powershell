using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticAnalysis.HelpGenerator
{
    public class CmdletHelpReference
    {
        public string Name { get; set; }
        public HelpTarget HelpTarget { get; set; }
    }
}
