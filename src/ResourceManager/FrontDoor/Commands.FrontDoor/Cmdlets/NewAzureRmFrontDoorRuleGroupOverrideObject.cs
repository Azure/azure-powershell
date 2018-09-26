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
    /// Defines the New-AzureRmFrontDoorRuleGroupOverrideObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorRuleGroupOverrideObject"), OutputType(typeof(PSAzureRuleGroupOverride))]
    public class NewAzureRmFrontDoorRuleGroupOverrideObject : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// Describes overrideruleGroup. Possible values include: 'SqlInjection', 'XSS'
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Describes overrideruleGroup. Possible values include: 'SqlInjection', 'XSS'")]
        public PSRuleGroupOverride Override { get; set; }

        /// <summary>
        /// Type of Actions. Possible values include: 'Allow', 'Block', 'Log'
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Type of Actions. Possible values include: 'Allow', 'Block', 'Log'")]
        public PSAction Action { get; set; }

        public override void ExecuteCmdlet()
        {
            var ruleGroupOverride = new PSAzureRuleGroupOverride 
            {
               RuleGroupOverride = Override,
               Action = Action
            };
            WriteObject(ruleGroupOverride);
        }
        
    }
}
