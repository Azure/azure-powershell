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
using System.Runtime.Loader;

namespace Tools.Common.Loaders
{
    public class CmdletLoader
    {
        public static ModuleMetadata ModuleMetadata;

        /// <summary>
        /// Use a custom assembly loader context to load assemblies of each module,
        /// so they do not conflict with each other or build tools.
        /// See https://docs.microsoft.com/en-us/dotnet/standard/assembly/unloadability
        /// and https://docs.microsoft.com/en-us/powershell/scripting/dev-cross-plat/resolving-dependency-conflicts?view=powershell-7#more-robust-solutions
        /// </summary>
        private CmdletLoaderAlc _alc;

        /// <summary>
        /// Get the ModuleMetadata from a cmdlet assembly.
        /// </summary>
        /// <param name="assmeblyPath">Path to the cmdlet assembly.</param>
        /// <returns>ModuleMetadata containing information about the cmdlets found in the given assembly.</returns>
        public ModuleMetadata GetModuleMetadata(string assemblyPath, List<string> commonOutputFolders = null)
        {
            _alc = new CmdletLoaderAlc(commonOutputFolders);
            AssemblyLoadContext.Default.Resolving += CustomResolving;

            var results = new List<CmdletMetadata>();

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

                    var globalParameters = new List<Parameter>();

                    foreach (var parameter in parameters)
                    {
                        if (string.Equals(parameter.MemberInfo.Name, "Force", StringComparison.OrdinalIgnoreCase) && parameter.ParameterType == typeof(SwitchParameter))
                        {
                            cmdletMetadata.HasForceSwitch = true;
                        }

                        var parameterData = new Models.ParameterMetadata
                        {
                            Type = parameter.ParameterType,
                            Name = parameter.MemberInfo.Name
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
                            var parameterSetMetadata = 
                                cmdletMetadata.ParameterSets.FirstOrDefault(s => s.Name.Equals(parameterSet.ParameterSetName))
                                ?? new Models.ParameterSetMetadata
                                {
                                    Name = parameterSet.ParameterSetName ?? "__AllParameterSets"
                                };

                            var param = new Parameter
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

                    if (!cmdletMetadata.ParameterSets.Any(p => p.Name.Equals(cmdletMetadata.DefaultParameterSetName, StringComparison.OrdinalIgnoreCase)))
                    {
                        var defaultSet = new Models.ParameterSetMetadata
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
            finally
            {
                AssemblyLoadContext.Default.Resolving -= CustomResolving;
            }

            ModuleMetadata.Cmdlets = results;
            return ModuleMetadata;
        }

        private Assembly CustomResolving(AssemblyLoadContext assemblyLoadContext, AssemblyName name) => _alc.LoadFromAssemblyName(name);
    }

    internal class CmdletLoaderAlc : AssemblyLoadContext
    {
        private readonly List<string> _assemblyDirectories;

        public CmdletLoaderAlc(List<string> assemblyDirectories = null)
        {
            _assemblyDirectories = assemblyDirectories ?? new List<string>();
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            foreach (var assemblyPath in _assemblyDirectories)
            {
                var dll = Directory.GetFiles(assemblyPath, "*.dll").FirstOrDefault(f => Path.GetFileNameWithoutExtension(f) == assemblyName.Name);
                if (dll == null)
                {
                    continue;
                }

                return LoadFromAssemblyPath(dll);
            }
            return null;
        }
    }
}
