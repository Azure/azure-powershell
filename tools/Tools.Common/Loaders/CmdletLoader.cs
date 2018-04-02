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
using Tools.Common.Models;
using Tools.Common.Extensions;
using System.IO;

namespace Tools.Common.Loaders
{
    public class CmdletLoader : MarshalByRefObject
    {
        public static ModuleMetadata ModuleMetadata;

        private static IDictionary<string, Assembly> _assemblyDictionary = null;

        public ModuleMetadata GetModuleMetadata(string assemblyPath, List<string> commonOutputFolders)
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                foreach (var commonOutputFolder in commonOutputFolders)
                {
                    var assemblyName = args.Name.Substring(0, args.Name.IndexOf(","));
                    var dll = Directory.GetFiles(commonOutputFolder, "*.dll").Where(f => Path.GetFileNameWithoutExtension(f) == assemblyName).FirstOrDefault();
                    if (dll == null)
                    {
                        continue;
                    }

                    return Assembly.LoadFrom(dll);
                }

                return null;
            };

            return GetModuleMetadata(assemblyPath);
        }

        /// <summary>
        /// Get the ModuleMetadata from a cmdlet assembly.
        /// </summary>
        /// <param name="assmeblyPath">Path to the cmdlet assembly.</param>
        /// <returns>ModuleMetadata containing information about the cmdlets found in the given assembly.</returns>
        public ModuleMetadata GetModuleMetadata(string assemblyPath)
        {
            List<CmdletMetadata> results = new List<CmdletMetadata>();

            ModuleMetadata = new ModuleMetadata();
            try
            {
                var assembly = Assembly.LoadFrom(assemblyPath);
                foreach (var type in assembly.GetCmdletTypes())
                {
                    var cmdlet = type.GetAttribute<CmdletAttribute>();
                    var outputs = type.GetAttributes<OutputTypeAttribute>();
                    var parameters = type.GetParameters();

                    var cmdletMetadata = new CmdletMetadata
                    {
                        VerbName = cmdlet.VerbName,
                        NounName = cmdlet.NounName,
                        ConfirmImpact = cmdlet.ConfirmImpact,
                        SupportsPaging = cmdlet.SupportsPaging,
                        SupportsShouldProcess = cmdlet.SupportsShouldProcess,
                        ClassName = type.FullName,
                        DefaultParameterSetName = cmdlet.DefaultParameterSetName ?? "__AllParameterSets"
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

                    List<Parameter> globalParameters = new List<Parameter>();

                    foreach (var parameter in parameters)
                    {
                        if (string.Equals(parameter.Name, "Force", StringComparison.OrdinalIgnoreCase) && parameter.PropertyType == typeof(SwitchParameter))
                        {
                            cmdletMetadata.HasForceSwitch = true;
                        }

                        var parameterData = new Models.ParameterMetadata
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

                        if (parameter.HasAttribute<ValidateSetAttribute>())
                        {
                            var validateSet = parameter.GetAttribute<ValidateSetAttribute>();
                            parameterData.ValidateSet.AddRange(validateSet.ValidValues);
                        }

                        if (parameter.HasAttribute<ValidateRangeAttribute>())
                        {
                            var validateRange = parameter.GetAttribute<ValidateRangeAttribute>();
                            parameterData.ValidateRangeMin = Convert.ToInt64(validateRange.MinRange);
                            parameterData.ValidateRangeMax = Convert.ToInt64(validateRange.MaxRange);
                        }

                        parameterData.ValidateNotNullOrEmpty = parameter.HasAttribute<ValidateNotNullOrEmptyAttribute>();

                        cmdletMetadata.Parameters.Add(parameterData);

                        foreach (var parameterSet in parameter.GetAttributes<ParameterAttribute>())
                        {
                            var parameterSetMetadata = cmdletMetadata.ParameterSets.FirstOrDefault(s => s.Name.Equals(parameterSet.ParameterSetName));

                            if (parameterSetMetadata == null)
                            {
                                parameterSetMetadata = new Models.ParameterSetMetadata()
                                {
                                    Name = parameterSet.ParameterSetName ?? "__AllParameterSets"
                                };
                            }

                            Parameter param = new Parameter
                            {
                                ParameterMetadata = parameterData,
                                Mandatory = parameterSet.Mandatory,
                                Position = parameterSet.Position,
                                ValueFromPipeline = parameterSet.ValueFromPipeline,
                                ValueFromPipelineByPropertyName = parameterSet.ValueFromPipelineByPropertyName
                            };

                            if (parameterSet.ParameterSetName.Equals("__AllParameterSets"))
                            {
                                globalParameters.Add(param);
                            }

                            parameterSetMetadata.Parameters.Add(param);

                            if (parameterSetMetadata.Parameters.Count == 1)
                            {
                                cmdletMetadata.ParameterSets.Add(parameterSetMetadata);
                            }
                        }
                    }

                    foreach (var parameterSet in cmdletMetadata.ParameterSets)
                    {
                        if (parameterSet.Name.Equals("__AllParameterSets"))
                        {
                            continue;
                        }

                        foreach (var parameter in globalParameters)
                        {
                            var param = parameterSet.Parameters.FirstOrDefault(p => p.ParameterMetadata.Name.Equals(parameter.ParameterMetadata.Name));
                            if (param == null)
                            {
                                parameterSet.Parameters.Add(parameter);
                            }
                        }
                    }

                    if (!cmdletMetadata.ParameterSets
                                        .Where(p => p.Name.Equals(cmdletMetadata.DefaultParameterSetName, StringComparison.OrdinalIgnoreCase))
                                        .Any())
                    {
                        var defaultSet = new Models.ParameterSetMetadata()
                        {
                            Name = cmdletMetadata.DefaultParameterSetName
                        };
                        cmdletMetadata.ParameterSets.Add(defaultSet);
                    }

                    results.Add(cmdletMetadata);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ModuleMetadata.Cmdlets = results;
            return ModuleMetadata;
        }
    }
}
