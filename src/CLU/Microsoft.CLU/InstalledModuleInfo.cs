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

        public static IEnumerable<InstalledModuleInfo> Enumerate(IEnumerable<string> moduleNames, IEnumerable<string> commandDiscriminators)
        {
            var installedModuleInfos = new List<InstalledModuleInfo>();

            foreach (var packageName in moduleNames)
            {
                var package = LocalPackage.LoadCmdletPackage(packageName);
                if (package != null)
                {
                    var matchedCmdlets = package.FindMatchingCmdlets(commandDiscriminators);
                    if (matchedCmdlets.Count() > 0)
                    {
                        var module = new InstalledModuleInfo { Package = package, Cmdlets = new List<InstalledCmdletInfo>() };
                        foreach (var entry in matchedCmdlets)
                        {
                            var cmdletIdentifier = entry.Value.Split(Constants.CmdletIndexItemValueSeparator);
                            Debug.Assert(cmdletIdentifier.Length == 2);
                            var packageAssembly = package.LoadAssembly(cmdletIdentifier[0]);
                            Debug.Assert(packageAssembly.Assembly != null);
                            var cmdletType = packageAssembly.Assembly.GetType(cmdletIdentifier[1]);

                            module.Cmdlets.Add(new InstalledCmdletInfo
                            {
                                Keys = entry.Key,
                                AssemblyName = cmdletIdentifier[0],
                                Type = cmdletType
                            });
                        }

                        installedModuleInfos.Add(module);
                    }
                }
            }

            return installedModuleInfos;
        }
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
