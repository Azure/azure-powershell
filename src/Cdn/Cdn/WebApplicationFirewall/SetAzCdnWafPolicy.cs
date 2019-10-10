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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall;
using Microsoft.Azure.Commands.Cdn.Models.Profile;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using SdkSku = Microsoft.Azure.Management.Cdn.Models.Sku;
using SdkSkuName = Microsoft.Azure.Management.Cdn.Models.SkuName;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.Cdn.WebApplicationFirewall
{
    /// <summary>
    /// Defines the New-AzCdnWafPolicy cmdlet.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnWafPolicy", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSPolicy))]
    public class SetAzCdnWafPolicy : AzureCdnCmdletBase
    {
        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        [Parameter(ParameterSetName = FieldsParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Azure CDN WAF policy name.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string PolicyName { get; set; }

        /// <summary>
        /// The location in which to create the profile.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The location in which to create the CDN WAF policy.")]
        [LocationCompleter("Microsoft.Cdn/CdnWebApplicationFirewallPolicies")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// The pricing sku name of the policy.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The pricing sku name of the CDN WAF policy. Valid values are StandardVerizon, StandardAkamai, Standard_Microsoft and PremiumVerizon.")]
        public PSSkuName Sku { get; set; }

        /// <summary>
        /// The resource group name of the policy.
        /// </summary>
        [Parameter(ParameterSetName = FieldsParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group of the CDN WAF Policy will be created in.")]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the CDN WAF Policy")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The CDN WAF Policy object.")]
        [ValidateNotNull]
        public PSPolicy CdnWafPolicy { get; set; }


        /// <summary>
        /// The tags to associate with the Azure Cdn Profile.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the CDN WAF policy.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Disable the policy.")]
        public SwitchParameter Disable { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether the policy prevents or just reports violations.")]
        public PSPolicyMode? Mode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The HTTP response status code used for requests blocked by a rule that doesn't specify a block response status code.")]
        public string DefaultRedirectUrl { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The redirect URL used for requests redirected by a rule that doesn't specify a redirect URL.")]
        public int? DefaultCustomBlockResponseStatusCode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The HTTP response body used for requests blocked by a rule that doesn't specify a block response body.")]
        public string DefaultCustomBlockResponseBody { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Rules to rate limit matched requests.")]
        public PSRateLimitRule[] RateLimitRule { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Rule sets managed by CDN to apply to the policy.")]
        public PSManagedRuleSet[] ManagedRuleSet { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Custom rules to apply to the policy.")]
        public PSCustomRule[] CustomRule { get; set; }

        private const string WafPolicyResourceType = "cdnwebapplicationpolicy";

        public override void ExecuteCmdlet()
        {
            var wafPolicy = new CdnWebApplicationFirewallPolicy
            {
                PolicySettings = new PolicySettings()
            };

            // Parse ResourceId for ResourceIdParameterSet
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var parsed = new WafPolicyResourceId(ResourceId);
                ResourceGroupName = parsed.ResourceGroupName;
                PolicyName = parsed.PolicyName;
            }
            // Use object for ObjectParameterSet
            else if (ParameterSetName == ObjectParameterSet) {
                wafPolicy = CdnWafPolicy.ToSdkWebApplicationFirewallPolicy();
                ResourceGroupName = CdnWafPolicy.ResourceGroupName;
                PolicyName = CdnWafPolicy.Name;
            }

            // Overwrite policy object with any arguments that were set.
            wafPolicy.Location = Location.ToString();
            wafPolicy.Sku = new Management.Cdn.Models.Sku(Sku.ToString());
            if (Tag != null)
            {
                wafPolicy.Tags = Tag.ToDictionaryTags();
            }
            if (DefaultCustomBlockResponseBody != null)
            {
                wafPolicy.PolicySettings.DefaultCustomBlockResponseBody = DefaultCustomBlockResponseBody;
            }
            if (DefaultCustomBlockResponseStatusCode != null)
            {
                wafPolicy.PolicySettings.DefaultCustomBlockResponseStatusCode = DefaultCustomBlockResponseStatusCode;
            }
            if (DefaultRedirectUrl != null)
            {
                wafPolicy.PolicySettings.DefaultRedirectUrl = DefaultRedirectUrl;
            }
            if (Disable.IsPresent)
            {
                wafPolicy.PolicySettings.EnabledState = (Disable.ToBool() ? PSPolicyEnabledState.Disabled : PSPolicyEnabledState.Enabled).ToString();
            }
            if (Mode.HasValue)
            {
                wafPolicy.PolicySettings.Mode = Mode.Value.ToString();
            }
            if (RateLimitRule != null)
            {
                wafPolicy.RateLimitRules = new RateLimitRuleList(RateLimitRule.Select(r => r.ToSdkRateLimitRule()).ToList());
            }
            if (ManagedRuleSet != null)
            {
                wafPolicy.ManagedRules = new ManagedRuleSetList(ManagedRuleSet.Select(r => r.ToSdkManagedRuleSet()).ToList());
            }
            if (CustomRule != null)
            {
                wafPolicy.CustomRules = new CustomRuleList(CustomRule.Select(r => r.ToSdkCustomRule()).ToList());
            }

            ConfirmAction(MyInvocation.InvocationName,
                PolicyName,
                () =>
                {
                    wafPolicy = CdnManagementClient.Policies.CreateOrUpdate(ResourceGroupName, PolicyName, wafPolicy);
                    WriteObject(wafPolicy.ToPsPolicy());
                });
        }
    }
}
