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

using System.Text.RegularExpressions;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Cdn.Models.Profile;

namespace Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall
{
    /// <summary>
    /// Represents the properties of an Azure Cdn WAF Policy.
    /// </summary>
    public class PSPolicy : PSTrackedResource
    {
        private const string ProfileKeyPatternFormat =
            @"\/subscriptions\/(?<{0}>.*)\/resourcegroups\/(?<{1}>.*)\/providers\/Microsoft\.Cdn\/CdnWebApplicationFirewallPolicies\/(?<{2}>.*)";
        private const string SubscriptionIdGroupKey = "subscriptionId";
        private const string ResourceGroupGroupKey = "resourceGroup";
        private const string WafPolicyNameGroupKey = "WafPolicyName";

        /// <summary>
        /// Gets or sets the policy sku.
        /// </summary>
        public PSSku Sku { get; set; }

        /// <summary>
        /// A unique string that changes whenever the resource is updated.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the policy state.
        /// </summary>
        public PSPolicyResourceState ResourceState { get; set; }

        /// <summary>
        /// Gets or sets the default HTTP response body for blocked requests.
        /// </summary>
        public string DefaultCustomBlockResponseBody { get; set; }

        /// <summary>
        /// Gets or sets the default HTTP response status code for blocked requests.
        /// </summary>
        public int? DefaultCustomBlockResponseStatusCode { get; set; }

        /// <summary>
        /// Gets and sets the default redirect URL for redirected requests.
        /// </summary>
        public string DefaultRedirectUrl { get; set; }

        /// <summary>
        /// Gets or sets whether the policy prevents policy violations or just detects them.
        /// </summary>
        public PSPolicyMode Mode { get; set; }

        /// <summary>
        /// Gets or sets whether the policy is enabled.
        /// </summary>
        public PSPolicyEnabledState EnabledState { get; set; }

        /// <summary>
        /// Gets or sets the rate limit rules.
        /// </summary>
        public ICollection<PSRateLimitRule> RateLimitRules { get; set; }

        /// <summary>
        /// Gets or sets the custom rules.
        /// </summary>
        public ICollection<PSCustomRule> CustomRules { get; set; }

        /// <summary>
        /// Gets or sets the managed rules.
        /// </summary>
        public ICollection<PSManagedRuleSet> ManagedRules { get; set; }

        /// <summary>
        /// Gets or sets the linked endpoints.
        /// </summary>
        public ICollection<string> LinkedEndpointIds { get; set; }

        /// <summary>
        /// Gets the resource group from resource id.
        /// </summary>
        public string ResourceGroupName
        {
            get
            {
                var match = Regex.Match(Id,
                string.Format(ProfileKeyPatternFormat,
                    SubscriptionIdGroupKey,
                    ResourceGroupGroupKey,
                    WafPolicyNameGroupKey), RegexOptions.IgnoreCase);
                return match.Groups[ResourceGroupGroupKey].Value;
            }
        }
    }
}
