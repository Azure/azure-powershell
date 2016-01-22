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
using System.Management.Automation;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Utilities.Common;

namespace StaticAnalysis.HelpGenerator
{
    public class CmdletHelpGenerator : IAssemblyValidator
    {
        private IDictionary<string, CmdletHelp> _helpData = new Dictionary<string, CmdletHelp>(StringComparer.OrdinalIgnoreCase);
        public IToolsLogger Logger { get; set; }

        public string Name
        {
            get { return "Help Validator"; }
        }

        public void Validate(string baseDirectory, string assemblyIdentity)
        {
            Logger.Assembly = assemblyIdentity;
            foreach (var cmdlet in Assembly.Load(new AssemblyName(assemblyIdentity)).GetCmdletTypes())
            {
                if (cmdlet.HasAttribute<CliCommandAliasAttribute>())
                {
                    var help = GenerateHelp(cmdlet);
                    foreach (var name in help.CluNames)
                    {
                        _helpData.Add(name, help);
                    }
                }
                else
                {
                    Logger.LogRecord(new ValidationRecord
                    {
                        Description = $"Cmdlet {cmdlet.FullName} missing CLICommandAlias attribute",
                        Remediation = $"Add CliCommandAlias attribute to cmdlet {cmdlet.FullName}",
                        Severity = 0,
                        Target = cmdlet.FullName
                    });
                }
            }
        }

        public CmdletHelp GenerateHelp(Type cmdlet)
        {
            var result = new CmdletHelp();
            var cmdletAttribute = cmdlet.GetAttribute<CmdletAttribute>();
            var cluAttributes = cmdlet.GetAttributes<CliCommandAliasAttribute>();
            result.NounName = cmdletAttribute.NounName;
            result.VerbName = cmdletAttribute.VerbName;
            cluAttributes.ForEach(a => result.CluNames.Add(a.CommandName));
            var defaultParameterSetName = string.IsNullOrWhiteSpace(cmdletAttribute.DefaultParameterSetName)
                ? "default"
                : cmdletAttribute.DefaultParameterSetName;
            AddParameterHelp(cmdlet, result, defaultParameterSetName);
            return result;
        }

        private void AddParameterHelp(Type cmdlet, CmdletHelp help, string defaultParameterSetName)
        {
            var defaultParameterSet = new ParameterSetHelp {Name = defaultParameterSetName, IsDefault = true};
            var parameterSets = GetParameterSets(cmdlet, defaultParameterSet);
            foreach (var property in cmdlet.GetProperties().Where(p => p.HasAttribute<ParameterAttribute>()))
            {
                var parameter = GetParameterHelp(property);
                help.Parameters.Add(parameter);
                foreach (var parameterAttribute in property.GetAttributes<ParameterAttribute>())
                {
                    var reference = GetParameterReference(parameter, parameterAttribute);
                    var referenceName = parameterAttribute.ParameterSetName;
                    if (string.IsNullOrWhiteSpace(referenceName))
                    {
                        foreach (var targetSet in parameterSets.Values)
                        {
                            targetSet.Parameters.Add(reference);
                        }
                    }
                    else if (parameterSets.ContainsKey(referenceName))
                    {
                        parameterSets[referenceName].Parameters.Add(reference);
                    }
                    else
                    {
                        Logger.LogRecord(new ValidationRecord
                        {
                            Severity = 0,
                            Description = $"Found unknown parameter set {referenceName} for parameter {parameter.Name} in Cmdlet {cmdlet.FullName}",
                            Remediation = $"Verify the parameter sets for cmdlet {cmdlet.FullName}",
                            Target = cmdlet.FullName
                        });
                    }
                }
            }

            parameterSets.Values.ForEach(p => help.ParameterSets.Add(p));
        }

        private ParameterHelp GetParameterHelp(PropertyInfo property)
        {
            ParameterAttribute parameter = property.GetAttributes<ParameterAttribute>().First();
            var result = new ParameterHelp
            {
                Name = property.Name,
                Type = property.PropertyType,
                Description = ResolvePropertyDescription(parameter),
                IsSwitch = property.PropertyType == typeof (SwitchParameter),
                Pipeline = GetPipelineInput(parameter)
            };

            if (property.HasAttribute<AliasAttribute>())
            {
                foreach (var alias in property.GetAttributes<AliasAttribute>())
                {
                    alias.AliasNames.ForEach((n => result.Aliases.Add(n)));
                }
            }

            return result;
        }

        private ParameterReferenceHelp GetParameterReference(ParameterHelp parameter, ParameterAttribute reference)
        {
            var result = new ParameterReferenceHelp {Parameter = parameter, Required = reference.Mandatory};
            if (reference.Position < int.MaxValue)
            {
                result.Order = reference.Position;
            }

            return result;
        }

        private Dictionary<string, ParameterSetHelp> GetParameterSets(Type cmdlet, ParameterSetHelp defaultParameterSet)
        {
            var result = new Dictionary<string, ParameterSetHelp>(StringComparer.OrdinalIgnoreCase);
            result.Add(defaultParameterSet.Name, defaultParameterSet);
            foreach (var property in cmdlet.GetProperties().Where(p => p.HasAttribute<ParameterAttribute>()))
            {
                foreach (var parameter in property.GetAttributes<ParameterAttribute>())
                {
                    var name = parameter.ParameterSetName;
                    if (!string.IsNullOrWhiteSpace(name) && !result.ContainsKey(name) )
                    {
                        result.Add(name, new ParameterSetHelp { Name = name, IsDefault = false});
                    }
                }
            }

            return result;
        }

        private string ResolvePropertyDescription(ParameterAttribute attribute)
        {
            return attribute.HelpMessage;
        }

        public static PipelineInput GetPipelineInput(ParameterAttribute attribute)
        {
            var result = PipelineInput.None;
            if (attribute.ValueFromPipeline)
            {
                result = PipelineInput.ByValue;
            }
            else if (attribute.ValueFromPipelineByPropertyName)
            {
                result = PipelineInput.ByPropertyName;
            }

            return result;
        }
    }
}
