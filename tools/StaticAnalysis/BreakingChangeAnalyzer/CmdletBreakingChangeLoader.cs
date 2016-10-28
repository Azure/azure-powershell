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
using StaticAnalysis.help;
using StaticAnalysis.HelpAnalyzer;

namespace StaticAnalysis.BreakingChangeAnalyzer
{
    public class CmdletBreakingChangeLoader : MarshalByRefObject
    {
        /// <summary>
        /// Get cmdlets from the given assembly
        /// </summary>
        /// <param name="assmeblyPath"></param>
        /// <returns></returns>
        public IList<CmdletBreakingChangeMetadata> GetCmdlets(string assemblyPath)
        {
            IList<CmdletBreakingChangeMetadata> results = new List<CmdletBreakingChangeMetadata>();
            try
            {
                var assembly = Assembly.LoadFrom(assemblyPath);
                foreach (var type in assembly.GetCmdletTypes())
                {
                    var cmdlet = type.GetAttribute<CmdletAttribute>();
                    var outputs = type.GetAttributes<OutputTypeAttribute>();
                    var parameters = type.GetParameters();

                    var cmdletMetadata = new CmdletBreakingChangeMetadata
                    {
                        VerbName = cmdlet.VerbName,
                        NounName = cmdlet.NounName,
                        ConfirmImpact = cmdlet.ConfirmImpact,
                        SupportsPaging = cmdlet.SupportsPaging,
                        SupportsShouldProcess = cmdlet.SupportsShouldProcess,
                        ClassName = type.FullName
                    };

                    if (type.HasAttribute<AliasAttribute>())
                    {
                        var aliases = type.GetAttributes<AliasAttribute>();
                        cmdletMetadata.AliasList.AddRange(
                            aliases.SelectMany(a => a.AliasNames));
                    }

                    foreach (var output in outputs)
                    {
                        foreach (var outputType in output.Type)
                        {
                            var outputMetadata = new OutputMetadata
                            {
                                Type = outputType.Type
                            };
                            outputMetadata.ParameterSets.AddRange(output.ParameterSetName);
                            cmdletMetadata.OutputTypes.Add(outputMetadata);
                        }
                    }

                    foreach (var parameter in parameters)
                    {
                        var parameterData = new ParameterMetadata
                        {
                            Type = parameter.PropertyType,
                            Name = parameter.Name
                        };

                        if (parameter.HasAttribute<AliasAttribute>())
                        {
                            var aliases = parameter.GetAttributes<AliasAttribute>();
                            parameterData.AliasList.AddRange(
                                aliases.SelectMany(a => a.AliasNames));
                        }

                        cmdletMetadata.Parameters.Add(parameterData);
                    }

                    results.Add(cmdletMetadata);
                }
            }
            catch
            {
            }

            return results;
        }
    }
}
