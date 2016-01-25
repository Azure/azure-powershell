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
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StaticAnalysis.HelpGenerator
{
    public class CmdletHelp
    {
        private IList<string> _aliases = new List<string>();
        private IList<ParameterSetHelp> _parameterSets = new List<ParameterSetHelp>();
        private IList<ParameterHelp> _parameters = new List<ParameterHelp>();
        private IList<ExampleHelp> _examples = new List<ExampleHelp>();
        private IList<CmdletHelpReference> _references = new List<CmdletHelpReference>();
        private IList<Type> _output = new List<Type>();
        private string _noun;
        public string ClassName { get; set; }
        public string AssemblyName { get; set; }
        public string NounName
        {
            get
            {
                return _noun;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.ToLower().Contains("azurerm"))
                {
                    NounPrefix = "AzureRm";
                    _noun = value.Remove(0, "AzureRm".Length);
                }
                else if (!string.IsNullOrWhiteSpace(value) && value.ToLower().Contains("azure"))
                {
                    NounPrefix = "Azure";
                    _noun = value.Remove(0, "Azure".Length);
                }
                else
                {
                    NounPrefix = String.Empty;
                    _noun = value;
                }
            }
        }

        public string VerbName { get; set; }
        public string PowerShellName {  get { return $"{VerbName}-{NounName}"; } }
        public string CluName { get; set; }  
        public IList<string> Aliases { get { return _aliases; } } 
        public string Synopsis { get; set; }
        public string Description { get; set; } 
        public IList<Type> OutputTypes { get { return _output; } }
        private string NounPrefix { get; set; }
        public IList<ParameterSetHelp> ParameterSets
        {
            get
            {
                return _parameterSets;
            }
        }

        public IList<ParameterHelp> Parameters
        {
            get { return _parameters; }
        }

        public IList<ExampleHelp> Examples {  get { return _examples;} } 

        public IList<CmdletHelpReference> References { get { return _references; } }

        public string GetDefaultSynopsis()
        {
            var result = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(VerbName) && !string.IsNullOrWhiteSpace(NounName))
            {
                string noun = NormalizeNounName(NounName);
                if (string.Equals("Get", VerbName, StringComparison.OrdinalIgnoreCase))
                {
                    result.Append($"Get {noun} details.");
                }
                else
                {
                    result.Append($"{NormalizeVerbName(VerbName)} {GetArticle(noun)} {noun}.");
                }
            }

            return result.ToString();
        }

        private string GetArticle(string noun)
        {
            return (noun.StartsWith("a", StringComparison.OrdinalIgnoreCase) ||
             noun.StartsWith("e", StringComparison.OrdinalIgnoreCase) ||
             noun.StartsWith("i", StringComparison.OrdinalIgnoreCase) ||
             noun.StartsWith("o", StringComparison.OrdinalIgnoreCase) ||
             noun.StartsWith("u", StringComparison.OrdinalIgnoreCase))
                ? "an"
                : "a";
        }

        private string NormalizeNounName(string nounName)
        {
            var result = Regex.Replace(nounName, "([a-z])([A-Z])", "$1 $2");
            result = Regex.Replace(result, "VM([A-Z])", "VM $1");
            return Regex.Replace(result, "AD([A-Z])", "Active Directory $1");
        }

        private string NormalizeVerbName(string verb)
        {
            var result = verb;
            if (string.Equals("New", VerbName, StringComparison.OrdinalIgnoreCase))
            {
                result = "Create";
            }

            if (string.Equals("Set", VerbName, StringComparison.OrdinalIgnoreCase))
            {
                result = "Update";
            }
            return result;
        }

        public string ToString(string cluName)
        {
            cluName = $"az {cluName}";
            using (var writer = new StringWriter())
            {
                writer.WriteLine(cluName);
                writer.WriteLine();
                writer.WriteLine(Synopsis);
                writer.WriteLine();
                writer.WriteLine("USAGE:");
                writer.WriteLine();
                foreach (var parameterSet in ParameterSets)
                {
                    writer.WriteLine($"{cluName} {parameterSet}");
                    writer.WriteLine();
                }

                if (Parameters != null && Parameters.Count > 0)
                {
                    writer.WriteLine("PARAMETERS:");
                    writer.WriteLine();
                    foreach (var parameter in Parameters.OrderBy(p => p.PreferredName))
                    {
                        writer.Write(GetParameterDisplay(parameter.PreferredName));
                        StringBuilder aliasString = new StringBuilder();
                        foreach (var alias in parameter.Aliases)
                        {
                            if (!string.Equals(alias, parameter.PreferredName))
                            {
                                aliasString.Append($"{GetParameterDisplay(alias)}, ");
                            }
                        }
                        if (!string.Equals(parameter.Name, parameter.PreferredName))
                        {
                            aliasString.Append($"{GetParameterDisplay(parameter.Name)}");
                        }
                        else if (aliasString.Length > 2)
                        {
                            aliasString.Remove(aliasString.Length - 2, 2);
                        }
                        if (aliasString.Length > 0)
                        {
                            writer.WriteLine($" ({aliasString})");
                        }
                        else
                        {
                            writer.WriteLine();
                        }
                        writer.WriteLine($"  [{parameter.Type.GetDisplayName()}] {parameter.Description}");
                        writer.WriteLine();
                    }
                }

                if (References.Any(r=>r.HelpTarget == HelpTarget.CLU))
                {
                    writer.WriteLine("RELATED COMMANDS:");
                    foreach (var reference in References.Where(r => r.HelpTarget == HelpTarget.CLU))
                    {
                        writer.WriteLine(reference.Name);
                        writer.WriteLine();
                    }
                }

                return writer.ToString();
            }
        }

        private static string GetParameterDisplay(string name)
        {
            var builder = new StringBuilder();
            builder.Append("-");
            if (name != null && name.Length > 1)
            {
                builder.Append("-");
            }
            builder.Append(name.ToCamelCase());
            return builder.ToString();
        }
    }
}
