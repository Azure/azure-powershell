// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Management.Automation;
// TODO: Remove IfDef code
#if !NETSTANDARD
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
#endif
using Tools.Common.Extensions;

namespace StaticAnalysis.BreakingChangeAttributesAnalyzer
{
    public class BreakingChangeAttributesInModule
    {
        public string ModuleName { get; set; }
        public List<BreakingChangeAttributesInCmdlet> CmdletList { get; set; }

        public void FilterCmdlets(Func<string, bool> cmdletFilter)
        {
            CmdletList = CmdletList.Where(cmdlet => cmdletFilter(cmdlet.CmdletName)).ToList();
        }
    }

    public class BreakingChangeAttributesInCmdlet
    {
        public Type CmdletType { get; set; }
        public string CmdletName { get; set; }
// TODO: Remove IfDef code
#if !NETSTANDARD
        public List<GenericBreakingChangeAttribute> BreakingChangeAttributes { get; set; }
#endif
    }

    public class CmdletBreakingChangeAttributeLoader : MarshalByRefObject
    {
        /// <summary>
        /// Get cmdlets from the given assembly
        /// </summary>
        /// <param name="assmeblyPath"></param>
        /// <returns></returns>
        public BreakingChangeAttributesInModule GetModuleBreakingChangeAttributes(string assemblyPath)
        {
            var results = new List<BreakingChangeAttributesInCmdlet>();

            var assembly = Assembly.LoadFrom(assemblyPath);
            foreach (var type in assembly.GetCmdletTypes())
            {
                var cmdlet = type.GetAttribute<CmdletAttribute>();
                // TODO: Remove IfDef code
#if !NETSTANDARD
                    var attributes = type.GetAttributes<GenericBreakingChangeAttribute>();

                    if (attributes != null && (attributes.Count() > 0)) { }
#endif
                var cmdletMetadata = new BreakingChangeAttributesInCmdlet
                {
                    CmdletType = type,
                    CmdletName = cmdlet.VerbName + "-" + cmdlet.NounName,
                    // TODO: Remove IfDef code
#if !NETSTANDARD
                        BreakingChangeAttributes = attributes.ToList()
#endif
                };

                results.Add(cmdletMetadata);
            }            

            if (!results.Any()) return null;

            var attributesInTheModule = new BreakingChangeAttributesInModule
            {
                ModuleName = assemblyPath, CmdletList = results
            };

            return attributesInTheModule;
        }
    }
}
