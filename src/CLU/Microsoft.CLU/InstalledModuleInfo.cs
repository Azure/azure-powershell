using Microsoft.CLU.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Microsoft.CLU
{
    internal class InstalledModuleInfo
    {
        public LocalPackage Package { get; set; }
        public IList<InstalledCmdletInfo> Cmdlets { get; set; }
    }

    internal class InstalledCmdletInfo
    {
        public string Keys { get; set; }
        public string CommandName { get; set; }
        public string AssemblyName { get; set; }
        public Type Type { get; set; }
        public Help.MAMLReader.CommandHelpInfo Info { get; set; }
    }
}
