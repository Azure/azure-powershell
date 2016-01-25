using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CLU.Help;

namespace Microsoft.CLU.Test
{
    internal class MockPkgInfo : Help.CommandDispatchHelper.PkgInfo
    {
        public MockPkgInfo(string name, string version, string fullPath) : base(name, version, fullPath)
        {

        }

        public override IEnumerable<CommandDispatchHelper.CommandInfo> GetCommands()
        {
            yield return new CommandDispatchHelper.CommandInfo()
            {
                Discriminators = Name,
                Package = this
            };
        }

        public override IEnumerable<CommandDispatchHelper.HelpInfo> GetHelp()
        {
            yield return new CommandDispatchHelper.HelpInfo(Path);
        }
    }
}
