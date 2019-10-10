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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnWafManagedRuleSet", SupportsShouldProcess = false), OutputType(typeof(PSManagedRuleSet))]
    public class NewAzCdnWafManagedRuleSet : AzureCdnCmdletBase
    {
        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The CDN WAF rule set type.")]
        [ValidateNotNullOrEmpty]
        public string RuleSetType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Version of the rule set type.")]
        public string RuleSetVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Override a rule of the rule set.")]
        public PSManagedRuleGroupOverride[] RuleGroupOverride { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(new PSManagedRuleSet
            {
                RuleSetType = RuleSetType,
                RuleSetVersion = RuleSetVersion,
                RuleGroupOverrides = RuleGroupOverride,
            });
        }
    }
}
