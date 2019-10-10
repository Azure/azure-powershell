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
using System;

namespace Microsoft.Azure.Commands.Cdn.WebApplicationFirewall
{
    /// <summary>
    /// Defines the Set-AzCdnWafManagedRuleOverride cmdlet.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnWafManagedRuleGroup", SupportsShouldProcess = false), OutputType(typeof(PSManagedRuleGroupOverride))]
    public class SetAzCdnWafManagedRuleGroup : AzureCdnCmdletBase
    {

        private const string SpecifyRuleParameterSet = "SpecifyRuleParameterSet";
        private const string DisableAllParameterSet = "DisableAllParameterSet";

        [Parameter(Mandatory = true, HelpMessage = "Name of the CDN WAF rule group to override.")]
        [ValidateNotNullOrEmpty]
        public string RuleGroupName { get; set; }

        [Parameter(ParameterSetName = SpecifyRuleParameterSet, Mandatory = true, HelpMessage = "One or more rules to override.")]
        public PSManagedRuleOverride[] RuleOverride { get; set; }

        [Parameter(ParameterSetName = DisableAllParameterSet, Mandatory = true, HelpMessage = "Disable all rules of the rule group.")]
        public SwitchParameter DisableAll { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == SpecifyRuleParameterSet && (RuleOverride == null || RuleOverride.Length == 0))
            {
                throw new PSArgumentException(Resources.Error_CreateEmptyRuleGroupOverride);
            }

            WriteObject(new PSManagedRuleGroupOverride
            {
                RuleGroupName = RuleGroupName,
                Rules = RuleOverride,
            });
        }
    }
}
