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

namespace Microsoft.Azure.Commands.Cdn.WebApplicationFirewall
{
    /// <summary>
    /// Defines the New-AzCdnWafManagedRuleOverride cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnWafRateLimitRule", SupportsShouldProcess = false), OutputType(typeof(PSRateLimitRule))]
    public class NewAzCdnWafRateLimitRule : AzureCdnCmdletBase
    {
        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The name of the rate limit rule.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string RateLimitRuleName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Disables the rate limit rule.")]
        public SwitchParameter Disabled { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The priority of the rate limit rule.")]
        public int Priority { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The condition under which the rule is matched.")]
        [ValidateNotNullOrEmpty]
        public PSMatchCondition[] MatchCondition { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The action to take when the rule is matched.")]
        [ValidateNotNull]
        public PSActionType Action { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The rate limit threshold.")]
        [ValidateRange(1, int.MaxValue)]
        public int RateLimitThreshold { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The rate limit duration in minutes.")]
        [ValidateRange(1, 59)]
        public int RateLimitDurationInMinutes { get; set; }


        public override void ExecuteCmdlet()
        {
            WriteObject(new PSRateLimitRule
            {
                Name = RateLimitRuleName,
                EnabledState = Disabled.ToBool() ? PSCustomRuleEnabledState.Disabled : PSCustomRuleEnabledState.Enabled,
                Priority = Priority,
                MatchConditions = MatchCondition,
                Action = Action,
                RateLimitDurationInMinutes = RateLimitDurationInMinutes,
                RateLimitThreshold = RateLimitThreshold,
            });
        }
    }
}
