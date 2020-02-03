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
    /// Defines the Set-AzCdnWafManagedRule cmdlet.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnWafManagedRule", SupportsShouldProcess = false), OutputType(typeof(PSManagedRuleOverride))]
    public class SetAzCdnWafManagedRule : AzureCdnCmdletBase
    {
        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "ID of the CDN WAF managed rule to override.")]
        [ValidateNotNullOrEmpty]
        public string RuleId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enable the CDN WAF Managed Rule.")]
        public SwitchParameter Enabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The action to take when the rule is matched")]
        public PSActionType Action { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(new PSManagedRuleOverride
            {
                RuleId = RuleId,
                EnabledState = Enabled.ToBool() ? PSManagedRuleEnabledState.Enabled : PSManagedRuleEnabledState.Disabled,
                Action = Action,
            });
        }
    }
}
