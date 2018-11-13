﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.FrontDoor.Helpers;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.FrontDoor.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.FrontDoor;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzureRmFrontDoorFireWallPolicy cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorFireWallPolicy", SupportsShouldProcess = true), OutputType(typeof(PSPolicy))]
    public class NewAzureRmFrontDoorFireWallPolicy : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// The resource group name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The Policy name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "WebApplicationFireWallPolicy name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Whether the policy is in enabled state or disabled state. Possible values include: 'Disabled', 'Enabled'
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Whether the policy is in enabled state or disabled state. Possible values include: 'Disabled', 'Enabled'")]
        public PSEnabledState EnabledState { get; set; }

        /// <summary>
        /// Describes if it is in detection mode  or prevention mode at policy level. Possible values include:'Prevention', 'Detection'
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Describes if it is in detection mode  or prevention mode at policy level. Possible values include:'Prevention', 'Detection'")]
        public PSMode Mode { get; set; }

        /// <summary>
        /// Custom rules inside the policy
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Custom rules inside the policy")]
        [ValidateNotNullOrEmpty]
        public PSCustomRule[] Customrule { get; set; }

        /// <summary>
        /// Managed rules inside the policy
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Managed rules inside the policy")]
        public PSManagedRule[] ManagedRule { get; set; }



        public override void ExecuteCmdlet()
        {
            var existingPolicy = FrontDoorManagementClient.Policies.List(ResourceGroupName)
                .Where(p => p.Name.ToLower() == Name.ToLower());

            if (existingPolicy.Count() != 0)
            {
                throw new PSArgumentException(string.Format(Resources.Error_CreateExistingWebApplicationFirewallPolicy,
                    Name,
                    ResourceGroupName));
            }
            var updateParameters = new Management.FrontDoor.Models.WebApplicationFirewallPolicy1
            {
                Location = "global",
                CustomRules = new Management.FrontDoor.Models.CustomRules {
                    Rules = Customrule?.ToList().Select(x => x.ToSdkCustomRule()).ToList()
                },
                ManagedRules = new Management.FrontDoor.Models.ManagedRuleSets
                {
                    RuleSets = ManagedRule?.ToList().Select(x => x.ToSdkAzManagedRule()).ToList()
                },
                PolicySettings = new Management.FrontDoor.Models.PolicySettings
                {
                    EnabledState = this.IsParameterBound(c => c.EnabledState) ? EnabledState.ToString() : PSEnabledState.Enabled.ToString(),
                    Mode = this.IsParameterBound(c => c.Mode) ? Mode.ToString() : PSMode.Prevention.ToString()
                }
            };
            if (ShouldProcess(Resources.WebApplicationFirewallPolicyTarget, string.Format(Resources.CreateWebApplicationFirewallPolicy, Name)))
            {
                try
                {
                    var policy = FrontDoorManagementClient.Policies.CreateOrUpdate(
                                    ResourceGroupName,
                                    Name,
                                    updateParameters
                                    );
                    WriteObject(policy.ToPSPolicy());
                }
                catch (Microsoft.Azure.Management.FrontDoor.Models.ErrorResponseException e)
                {
                    throw new PSArgumentException(string.Format(
                        Resources.Error_ErrorResponseFromServer,
                        e.Response.Content));
                }
            }
        }
    }
}
