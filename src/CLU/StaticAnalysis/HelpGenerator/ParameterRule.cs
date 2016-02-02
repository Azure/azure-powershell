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
using System.Threading.Tasks;
using Microsoft.Cci.MutableCodeModel;

namespace StaticAnalysis.HelpGenerator
{
    public abstract class ParameterRule : HelpRule<ParameterHelp>
    {
        protected ParameterRule(string name)
        {
            MatchString = name;
        }
        protected string MatchString { get; set; }
        public override bool Match(ParameterHelp helpTarget)
        {
            return string.Equals(helpTarget.Name, MatchString, StringComparison.OrdinalIgnoreCase);
        }

        public static HelpRule<ParameterHelp> CreateDescriptionRules(CmdletHelp cmdlet, IDictionary<string, string> defaultDescriptions)
        {
            HelpRule<ParameterHelp>[] rules = new HelpRule<ParameterHelp>[defaultDescriptions.Count + 1];
            for (int i = 0; i < defaultDescriptions.Count; ++i)
            {
                var name = defaultDescriptions.Keys.ElementAt(i);
                var description = defaultDescriptions[name];
                rules[i] = new ParameterChangeDescriptionRule(name, description);
            }

            rules[rules.Length -1] = new ParameterNameDescriptionRule(cmdlet);
            return CreateChain(rules);
        }

        public static HelpRule<ParameterHelp> CreateAliasRules(IToolsLogger logger, IDictionary<string, IEnumerable<string>> defaultAliases)
        {
            HelpRule<ParameterHelp>[] rules = new HelpRule<ParameterHelp>[defaultAliases.Count + 1];
            for (int i = 0; i < defaultAliases.Count; ++i)
            {
                var name = defaultAliases.Keys.ElementAt(i);
                var aliases = defaultAliases[name];
                rules[i] = new DefaultAliasCheckRule(name, logger, aliases);
            }

            rules[rules.Length - 1] = new NameAliasCheckRule(logger);
            return CreateChain(rules);
        }

        class ParameterChangeDescriptionRule : ParameterRule
        {
            string _description;
            public ParameterChangeDescriptionRule(string name, string description) : base(name)
            {
                _description = description;
            }
            public override void ApplyRule(ParameterHelp helpTarget)
            {
                helpTarget.Description = _description;
            }
        }

        class ParameterNameDescriptionRule : ParameterRule
        {
            CmdletHelp _cmdlet;
            public ParameterNameDescriptionRule(CmdletHelp cmdlet) : base(string.Empty)
            {
                _cmdlet = cmdlet;
            }

            public override bool Match(ParameterHelp helpTarget)
            {
                return helpTarget.Name.EndsWith("name", StringComparison.OrdinalIgnoreCase);
            }

            public override void ApplyRule(ParameterHelp helpTarget)
            {
                if (string.IsNullOrEmpty(helpTarget.Description))
                {
                    helpTarget.Description = $"The {_cmdlet.NounName.GetEntityName()} name.";
                }
            }
        }

        class DefaultAliasCheckRule : ParameterRule
        {
            private IEnumerable<string> _expectedAliases;
            private IToolsLogger _logger;

            public DefaultAliasCheckRule(string name, IToolsLogger logger, 
                IEnumerable<string> aliases) : base(name)
            {
                _logger = logger;
                _expectedAliases = aliases;
            }
            public override void ApplyRule(ParameterHelp helpTarget)
            {
                foreach (var expectedAlias in _expectedAliases)
                {
                    if (!helpTarget.Aliases.Contains(expectedAlias, 
                        StringComparer.OrdinalIgnoreCase))
                    {
                        _logger.LogRecord(new ValidationRecord
                        {
                            Description = $"Missing expected alias {expectedAlias} for parameter {helpTarget.Name}",
                            Severity = 1,
                            Remediation = $"Add Alias attibute with value '{expectedAlias}' for parameter {helpTarget.Name}"
                        });
                    }
                }
            }
        }

        class NameAliasCheckRule : DefaultAliasCheckRule
        {
            public NameAliasCheckRule(IToolsLogger logger) : base(string.Empty, logger, new[] {"name", "n"})
            {
            }

            public override bool Match(ParameterHelp helpTarget)
            {
                return helpTarget.Name.EndsWith("Name");
            }
        }
    }
}
