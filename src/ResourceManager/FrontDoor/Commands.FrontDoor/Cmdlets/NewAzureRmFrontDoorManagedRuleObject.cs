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
using System.Collections;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Management.FrontDoor;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzureRmFrontDoorManagedRuleObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorManagedRuleObject"), OutputType(typeof(PSAzureManagedRule))]
    public class NewAzureRmFrontDoorManagedRuleObject : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// Describes priority of the rule
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Describes priority of the rule")]
        public int Priority { get; set; }

        /// <summary>
        /// Version of the ruleset
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Version of the ruleset")]
        public string Version { get; set; }

        /// <summary>
        /// List of azure managed provider override configuration
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "List of azure managed provider override configuration")]
        public PSAzureRuleGroupOverride[] RuleGroupOverride { get; set; }

        public override void ExecuteCmdlet()
        {
            var rule = new PSAzureManagedRule
            {
               Priority = Priority,
               Version = Version,
               RuleGroupOverrides = RuleGroupOverride?.ToList()
            };
            WriteObject(rule);
        }
        
    }
}
