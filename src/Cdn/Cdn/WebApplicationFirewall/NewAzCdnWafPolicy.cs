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
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Cdn.WebApplicationFirewall
{
    /// <summary>
    /// Defines the New-AzCdnWafPolicy cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnWafPolicy", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSPolicy))]
    public class NewAzCdnWafPolicy : AzureCdnCmdletBase
    {
        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        [Parameter(ParameterSetName = FieldsParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Azure CDN WAF policy name.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string PolicyName { get; set; }

        /// <summary>
        /// The resource group name of the profile.
        /// </summary>
        [Parameter(ParameterSetName = FieldsParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group of the Azure CDN profile will be created in.")]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the CDN WAF policy")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// The tags to associate with the Azure Cdn Profile.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the CDN WAF policy.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Disable the policy.")]
        public SwitchParameter Disable { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether the policy prevents or just reports violations.")]
        public PSPolicyMode Mode { get; set; }

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

        public override void ExecuteCmdlet()
        {
            // Parse ResourceId for ResourceIdParameterSet
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var parsed = new WafPolicyResourceId(ResourceId);
                ResourceGroupName = parsed.ResourceGroupName;
                PolicyName = parsed.PolicyName;
            }

            if (!(new Regex("^[A-Za-z][A-Za-z0-9]*$").IsMatch(PolicyName)))
            {
                throw new PSArgumentException(Resources.Error_PolicyNameInvalid);
            }

            // Verify the policy doesn't already exist.
            try
            {
                var existingPolicy = CdnManagementClient.Policies.Get(ResourceGroupName, PolicyName);
                throw new PSArgumentException(string.Format(Resources.Error_CreateExistingPolicy, PolicyName, ResourceGroupName));
            }
            catch (Management.Cdn.Models.ErrorResponseException e)
            {
                if (e.Response.StatusCode != HttpStatusCode.NotFound)
                {
                    throw e;
                }
            }

            ConfirmAction(MyInvocation.InvocationName,
                PolicyName,
                NewPolicy);
        }

        private void NewPolicy()
        {
            var sdkRateLimitRules = RateLimitRule?.Select(r => r.ToSdkRateLimitRule()).ToList();
            var sdkCustomRules = CustomRule?.Select(r => r.ToSdkCustomRule()).ToList();
            var sdkManagedRuleSets = ManagedRuleSet?.Select(r => r.ToSdkManagedRuleSet()).ToList();

            var cdnPolicy = CdnManagementClient.Policies.CreateOrUpdate(
                ResourceGroupName,
                PolicyName,
                new Management.Cdn.Models.CdnWebApplicationFirewallPolicy(
                    location: "Global",
                    sku: new SdkSku(SkuName.StandardMicrosoft),
                    id: null,
                    name: null,
                    type: null,
                    tags: Tag?.ToDictionaryTags(),
                    policySettings: new PolicySettings(
                        enabledState: (Disable.ToBool() ? PSPolicyEnabledState.Disabled : PSPolicyEnabledState.Enabled).ToString(),
                        mode: Mode.ToString(),
                        defaultRedirectUrl: DefaultRedirectUrl,
                        defaultCustomBlockResponseStatusCode: DefaultCustomBlockResponseStatusCode,
                        defaultCustomBlockResponseBody: DefaultCustomBlockResponseBody),
                    rateLimitRules: new RateLimitRuleList(sdkRateLimitRules),
                    customRules: new CustomRuleList(sdkCustomRules),
                    managedRules: new ManagedRuleSetList(sdkManagedRuleSets)));

            var result = cdnPolicy.ToPsPolicy();
            WriteObject(result);
        }
    }
}
