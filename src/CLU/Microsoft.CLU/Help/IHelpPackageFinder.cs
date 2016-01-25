using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.CLU.Help
{
    internal interface IHelpPackageFinder
    {
        IEnumerable<CommandDispatchHelper.PkgInfo> FindPackages();
    }
}
