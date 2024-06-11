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
using Microsoft.Azure.Commands.FrontDoor.Helpers;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.FrontDoor.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.FrontDoor;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Management.FrontDoor.Models;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzFrontDoorWafPolicy cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorWafPolicy", SupportsShouldProcess = true), OutputType(typeof(PSPolicy))]
    public class NewFrontDoorWafPolicy : AzureFrontDoorCmdletBase
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
        [PSArgumentCompleter("Prevention", "Detection")]
        public string Mode { get; set; }

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

        /// <summary>
        /// Redirect URL used for redirect actions
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Redirect URL")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Custom block response code used for block actions
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Custom Response Status Code")]
        [ValidateRange(200, 499)]
        public int CustomBlockResponseStatusCode { get; set; }

        /// <summary>
        /// Custom block response body used for block actions
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Custom Response Body")]
        public string CustomBlockResponseBody { get; set; }
        
        /// <summary>
        /// The tags to associate with the Front Door Waf Policy.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The tags associate with the Front Door Waf Policy.")]
        public Hashtable Tag { get; set; }
        
        /// <summary>
        /// Defines if the body should be inspected by managed rules. Possible values include: 'Enabled', 'Disabled'
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Defines if the body should be inspected by managed rules. Possible values include: 'Enabled', 'Disabled'")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string RequestBodyCheck { get; set; }

        /// <summary>
        /// Sets Sku. Possible values include: 'Classic_AzureFrontDoor', 'Standard_AzureFrontDoor', 'Premium_AzureFrontDoor'
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Sets Sku. Possible values include: 'Classic_AzureFrontDoor', 'Standard_AzureFrontDoor', 'Premium_AzureFrontDoor'")]
        [PSArgumentCompleter("Classic_AzureFrontDoor", "Standard_AzureFrontDoor", "Premium_AzureFrontDoor")]
        public string Sku { get; set; }

        /// Defines rules that scrub sensitive fields in the Web Application Firewall
        [Parameter(Mandatory = false, HelpMessage = "Defines rules that scrub sensitive fields in the Web Application Firewall.")]
        public PSFrontDoorWafLogScrubbingSetting LogScrubbingSetting { get; set; }

        /// Defines the JavaScript challenge cookie validity lifetime in minutes. This
        /// setting is only applicable to Premium_AzureFrontDoor. Value must be an
        /// integer between 5 and 1440 with the default value being 30.
        [Parameter(Mandatory = false, HelpMessage = "setting is only applicable to Premium_AzureFrontDoor. Value must be an integer between 5 and 1440 with the default value being 30.")]
        public int? JavascriptChallengeExpirationInMinutes { get; set; }

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

            var scrubbingRule = new List<Management.FrontDoor.Models.WebApplicationFirewallScrubbingRules>();
            if (LogScrubbingSetting != null && LogScrubbingSetting.ScrubbingRule != null && LogScrubbingSetting.ScrubbingRule.Count() > 0)
            {
                foreach (var item in LogScrubbingSetting.ScrubbingRule)
                {
                    scrubbingRule.Add(new Management.FrontDoor.Models.WebApplicationFirewallScrubbingRules(
                        matchVariable: item.MatchVariable,
                        selectorMatchOperator: item.SelectorMatchOperator,
                        selector: item.Selector,
                        state: item.State));
                }
            }
            var updateParameters = new Management.FrontDoor.Models.WebApplicationFirewallPolicy
            {
                Tags = Tag?.ToDictionaryTags(),
                Location = "global",
                CustomRules = new Management.FrontDoor.Models.CustomRuleList()
                {
                    Rules = Customrule?.ToList().Select(x => x.ToSdkCustomRule()).ToList()
                },
                ManagedRules = new Management.FrontDoor.Models.ManagedRuleSetList()
                {
                    ManagedRuleSets = ManagedRule?.ToList().Select(x => x.ToSdkAzManagedRule()).ToList()
                },
                PolicySettings = new Management.FrontDoor.Models.PolicySettings
                {
                    EnabledState = this.IsParameterBound(c => c.EnabledState) ? EnabledState.ToString() : PSEnabledState.Enabled.ToString(),
                    Mode = this.IsParameterBound(c => c.Mode) ? Mode : PSMode.Prevention.ToString(),
                    CustomBlockResponseBody = CustomBlockResponseBody == null ? CustomBlockResponseBody : Convert.ToBase64String(Encoding.UTF8.GetBytes(CustomBlockResponseBody)),
                    CustomBlockResponseStatusCode = this.IsParameterBound(c => c.CustomBlockResponseStatusCode) ? CustomBlockResponseStatusCode : (int?)null,
                    RedirectUrl = RedirectUrl,
                    RequestBodyCheck = this.IsParameterBound(c => c.RequestBodyCheck) ? RequestBodyCheck : PSEnabledState.Enabled.ToString(),
                },
                Sku = this.IsParameterBound(c => c.Sku) ? new Management.FrontDoor.Models.Sku(Sku) : null,
            };

            if (LogScrubbingSetting != null)
            {
                updateParameters.PolicySettings.LogScrubbing = new PolicySettingsLogScrubbing();
                updateParameters.PolicySettings.LogScrubbing.ScrubbingRules = scrubbingRule;
                updateParameters.PolicySettings.LogScrubbing.State = LogScrubbingSetting.State;
            }

            if (JavascriptChallengeExpirationInMinutes != null)
            {
                updateParameters.PolicySettings.JavascriptChallengeExpirationInMinutes = JavascriptChallengeExpirationInMinutes;
            }

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
