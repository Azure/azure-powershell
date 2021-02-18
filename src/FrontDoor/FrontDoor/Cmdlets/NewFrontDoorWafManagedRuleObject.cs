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

using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzFrontDoorWafManagedRuleObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorWafManagedRuleObject"), OutputType(typeof(PSAzureManagedRule))]
    public class NewFrontDoorWafManagedRuleObject : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// Type of the ruleset (e.g.: DefaultRuleSet)
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Type of the ruleset")]
        [PSArgumentCompleter("BotProtection", "DefaultRuleSet", "Microsoft_DefaultRuleSet")]
        public string Type { get; set; }

        /// <summary>
        /// Version of the ruleset (e.g.: preview-0.1)
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Version of the ruleset")]
        [PSArgumentCompleter("2.0", "1.1", "1.0", "preview-0.1")]
        public string Version { get; set; }

        /// <summary>
        /// List of azure managed provider override configuration
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "List of azure managed provider override configuration")]
        public PSAzureRuleGroupOverride[] RuleGroupOverride { get; set; }

        /// <summary>
        /// Exclusions
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Exclusions")]
        public PSManagedRuleExclusion[] Exclusion { get; set; }

        public override void ExecuteCmdlet()
        {
            var rule = new PSAzureManagedRule
            {
                RuleSetType = Type,
                RuleSetVersion = Version,
                RuleGroupOverrides = RuleGroupOverride?.ToList(),
                Exclusions = Exclusion?.ToList()
            };
            WriteObject(rule);
        }

    }
}
