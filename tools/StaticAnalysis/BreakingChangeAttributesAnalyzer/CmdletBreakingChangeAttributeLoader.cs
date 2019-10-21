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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
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
        public List<GenericBreakingChangeAttribute> BreakingChangeAttributes { get; set; }
        public List<BreakingChangeAttributesInParameter> BreakingChangeParameterList { get; set; }
    }

    public class BreakingChangeAttributesInParameter
    {
        public Type ParameterType { get; set; }
        public string ParameterName { get; set; }
        public List<CmdletParameterBreakingChangeAttribute> BreakingChangeParameters { get; set; }
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
            var breakingChangeAttributesInCmdletList = new List<BreakingChangeAttributesInCmdlet>();

            try
            {
                var assembly = Assembly.LoadFrom(assemblyPath);
                foreach (var type in assembly.GetCmdletTypes())
                {
                    var cmdlet = type.GetAttribute<CmdletAttribute>();
                    var attributes = type.GetAttributes<GenericBreakingChangeAttribute>();

                    var cmdletMetadata = new BreakingChangeAttributesInCmdlet
                    {
                        CmdletType = type,
                        CmdletName = cmdlet.VerbName + "-" + cmdlet.NounName,
                        BreakingChangeAttributes = new List<GenericBreakingChangeAttribute>(),
                        BreakingChangeParameterList = new List<BreakingChangeAttributesInParameter>()
                    };

                    if (attributes != null && (attributes.Count() > 0))
                    {
                        cmdletMetadata.BreakingChangeAttributes = attributes.ToList();
                    }

                    foreach (var parameter in type.GetParameters())
                    {
                        var breakingChangeAttrs = parameter.GetAttributes<CmdletParameterBreakingChangeAttribute>();
                        if (breakingChangeAttrs != null && breakingChangeAttrs.Count() > 0)
                        {
                            var parameterMatadata = new BreakingChangeAttributesInParameter
                            {
                                ParameterType = parameter.GetType(),
                                ParameterName = parameter.Name,
                                BreakingChangeParameters = breakingChangeAttrs.ToList(),
                            };
                            cmdletMetadata.BreakingChangeParameterList.Add(parameterMatadata);
                        }
                    }
                    if (cmdletMetadata.BreakingChangeAttributes.Count() > 0 || cmdletMetadata.BreakingChangeParameterList.Count() > 0)
                    {
                        breakingChangeAttributesInCmdletList.Add(cmdletMetadata);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!breakingChangeAttributesInCmdletList.Any()) return null;

            var attributesInTheModule = new BreakingChangeAttributesInModule
            {
                ModuleName = assemblyPath, CmdletList = breakingChangeAttributesInCmdletList
            };

            return attributesInTheModule;
        }
    }
}
