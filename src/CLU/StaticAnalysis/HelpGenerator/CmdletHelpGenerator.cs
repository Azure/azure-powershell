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
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using Microsoft.Azure.Commands.Utilities.Common;

namespace StaticAnalysis.HelpGenerator
{
    public class CmdletHelpGenerator : IAssemblyActor
    {
        private IDictionary<string, CmdletHelp> _helpData = new Dictionary<string, CmdletHelp>(StringComparer.OrdinalIgnoreCase);
        private Dictionary<Type, IList<string>> cmdletOutputTypes = new Dictionary<Type, IList<string>>();


        private static readonly IDictionary<string, string> _defaultParameterDescriptions =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "location", "The region that will contain this resource.  Possible values include 'East US', 'North Europe', 'East Asia'" },
                { "resourceGroupName", "The name of the resource group containing this resource"},
                { "resourceGroup", "The name of the resource group containing this resource"},
                { "id", "The identity of this resource. Resource identity is a Uri path that uniquely identifies the resource."},
                { "resourceId",  "The identity of this resource. Resource identity is a Uri path that uniquely identifies the resource."},
                { "subscriptionId", "The subscription identity, a global unique identifier (GUID) that uniquely identifies the subscription."},
                { "subscription", "The subscription identity, a global unique identifier (GUID) that uniquely identifies the subscription."},
                { "subscriptionName", "The friendly name of the subscription."},
                { "tenantId", "The tenant identity (GUID) or the domain name."},
                { "tenant", "The tenant identity (GUID) or the domain name."},
                { "force", "Perform this action without prompting, even if permanent changes are made." },
                { "profile", "A container for azure environments and credentials." },
                { "path", "The path to a file." },
                { "passThru", "Forces true or false output.  Without this flag, the command will return nothing if successful." }
           };

        private static readonly IDictionary<string, IEnumerable<string>> _defaultParameterAliases =
            new Dictionary<string, IEnumerable<string>>
            {
                { "location", new string[] {"l"} },
                { "resourceGroupName", new string[] {"g", "group"}},
                { "resourceGroup", new string[] {"g", "group"}},
                { "id", new string[] {"i"}},
                { "resourceId", new string[] {"i", "id"}},
                { "subscriptionId", new string[] {"s"}},
                { "subscription", new string[] {"s"}},
                { "subscriptionName", new string[] {"n"}},
                { "force", new []{"f"} }
            };

        public IToolsLogger Logger { get; set; }

        public string Name
        {
            get { return "Help Validator"; }
        }

        public void ExecuteAssemblyAction(string baseDirectory, string assemblyIdentity)
        {
            var helpDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..", assemblyIdentity, "content",
                "help");
            Directory.CreateDirectory(helpDirectory);
            _helpData = new Dictionary<string, CmdletHelp>(StringComparer.OrdinalIgnoreCase);
            foreach (var cmdlet in Assembly.Load(new AssemblyName(assemblyIdentity)).GetCmdletTypes())
            {
                Logger.Decorator.AddDecorator(r => r.Target = cmdlet.FullName, "Target");
                if (cmdlet.HasAttribute<CliCommandAliasAttribute>())
                {
                    var cluNames = cmdlet.GetAttributes<CliCommandAliasAttribute>().Select(a => a.CommandName);
                    foreach (var name in cluNames)
                    {
                        var help = GenerateHelp(cmdlet, Name);
                        _helpData.Add(name, help);
                        foreach (var output in help.OutputTypes)
                        {
                            if (cmdletOutputTypes.ContainsKey(output))
                            {
                                cmdletOutputTypes[output].Add(name);
                            }
                            else
                            {
                                cmdletOutputTypes.Add(output, new List<string> { name });
                            }
                        }
                    }
                }
                else
                {
                    Logger.LogRecord(new ValidationRecord
                    {
                        Description = $"Cmdlet {cmdlet.FullName} missing CLICommandAlias attribute",
                        Remediation = $"Add CliCommandAlias attribute to cmdlet {cmdlet.FullName}",
                        Severity = 0
                    });
                }

                Logger.Decorator.Remove("Target");
            }

            foreach (var name in _helpData.Keys)
            {
                var help = _helpData[name];
                if (help.Parameters.Any(p => p.Type.IsComplex() && cmdletOutputTypes.Keys.Any(t => t.Produces(p.Type))))
                {
                    foreach (var parameter in help.Parameters.Where(p => p.Type.IsComplex()
                        && cmdletOutputTypes.Keys.Any(t => t.Produces(p.Type))))
                    {
                        var commands =
                            cmdletOutputTypes.Keys.Where(t => t.Produces(parameter.Type))
                                .SelectMany(k => cmdletOutputTypes[k]).OrderBy(a => a.CommandOrder());
                        var shortCommands = commands.Take(4);
                        if (parameter.Description == null)
                        {
                            parameter.Description = string.Empty;
                        }
                        if (!parameter.Description.EndsWith("."))
                        {
                            parameter.Description += ".";
                        }
                        parameter.Description +=
                            $" You may use commands including {string.Join(" or ", shortCommands.Select(c => $"'az {c}'"))} " +
                            $"to produce a {parameter.Name}. You can pipe the output of one of these " +
                            $"commands to the input of this command, " +
                            $"or you can store the ouput to a file and use 'az {name} " +
                            $"{parameter.GetReference()} @@<file-name>' to pass the file contents. See 'Related Commands' for more information.";

                        foreach (var alias in cmdletOutputTypes.Keys.Where(t => t.Produces(parameter.Type))
                            .SelectMany(k => cmdletOutputTypes[k]).OrderBy(a => a.CommandOrder()))
                        {
                            if (
                                !help.References.Any(
                                    r => r.HelpTarget == HelpTarget.CLU && r.Name != null && r.Name.StartsWith(alias)))
                            {
                                help.References.Add(new CmdletHelpReference
                                {
                                    HelpTarget = HelpTarget.CLU,
                                    Name = $"az {alias} (produces {parameter.Name})"
                                });
                            }
                            else
                            {
                                var reference =
                                    help.References.First(
                                        r =>
                                            r.HelpTarget == HelpTarget.CLU && r.Name != null && r.Name.StartsWith(alias));
                                reference.Name = reference.Name.TrimEnd(')');
                                reference.Name += $", produces {parameter.Name})";
                            }
                        }
                    }
                }

                var helpName = $"{name.Replace(' ', '.')}.hlp";
                var helpFile = Path.Combine(helpDirectory, helpName);
                File.WriteAllText(helpFile, help.ToString(name));
            }
        }

        public CmdletHelp GenerateHelp(Type cmdlet, string cluName)
        {
            var result = new CmdletHelp();
            var cmdletAttribute = cmdlet.GetAttribute<CmdletAttribute>();
            result.NounName = cmdletAttribute.NounName;
            result.VerbName = cmdletAttribute.VerbName;
            result.Synopsis = result.GetDefaultSynopsis();
            result.CluName = cluName;
            if (cmdlet.HasAttribute<OutputTypeAttribute>())
            {
                foreach (
                    var output in
                        cmdlet.GetAttributes<OutputTypeAttribute>().SelectMany(a => a.Type).Select(n => n.Type))
                {
                    result.OutputTypes.Add(output);
                }
            }
            var defaultParameterSetName = cmdletAttribute.DefaultParameterSetName;
            AddParameterHelp(cmdlet, result, defaultParameterSetName);
            return result;
        }

        private void AddParameterHelp(Type cmdlet, CmdletHelp help, string defaultParameterSetName)
        {
            var defaultName = defaultParameterSetName;
            if (string.IsNullOrWhiteSpace(defaultParameterSetName))
            {
                defaultParameterSetName = "default";
            }
            var defaultParameterSet = new ParameterSetHelp { Name = defaultParameterSetName, IsDefault = true };
            var parameterSets = GetParameterSets(cmdlet, defaultParameterSet);
            if (parameterSets != null && parameterSets.Count > 1 && string.IsNullOrWhiteSpace(defaultName))
            {
                Logger.LogRecord(new ValidationRecord
                {
                    Severity = 3,
                    Description = "No default parameter set provided for cmdlet with more than one parameter set.",
                    Remediation = "Set the DefaultParameterSet setting in the Cmdlet attribute for this cmdlet to " +
                                "match the most commonly used parameter set name."
                });
            }
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
                            Remediation = $"Verify the parameter sets for cmdlet {cmdlet.FullName}"
                        });
                    }
                }
            }

            var parameterDescriptionRules = ParameterRule.CreateDescriptionRules(help, _defaultParameterDescriptions);
            var parameterAliasRules = ParameterRule.CreateAliasRules(Logger, _defaultParameterAliases);
            help.Parameters.ForEach(p =>
            {
                parameterAliasRules.Apply(p);
                parameterDescriptionRules.Apply(p);
                if (string.IsNullOrWhiteSpace(p.Description))
                {
                    Logger.LogRecord(new ValidationRecord
                    {
                        Severity = 0,
                        Description = $"No help description for Parameter {p.Name}",
                        Remediation = $"Add a parameter description in the HelpMessage field for property {p.Name}"
                    });
                }
            });

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
                IsSwitch = property.PropertyType == typeof(SwitchParameter),
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
            var result = new ParameterReferenceHelp { Parameter = parameter, Required = reference.Mandatory };
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
                    if (!string.IsNullOrWhiteSpace(name) && !result.ContainsKey(name))
                    {
                        result.Add(name, new ParameterSetHelp { Name = name, IsDefault = false });
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
