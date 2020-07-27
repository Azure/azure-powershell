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
// ------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.SecurityCenter.Models.AdaptiveNetworkHardening;
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.Security.Cmdlets.AdaptiveNetworkHardening
{
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAdaptiveNetworkHardening", DefaultParameterSetName = ParameterSetNames.ResourceGroupLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSSecurityAdaptiveNetworkHardenings))]
    public class AddAdaptiveNetworkHardening : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.AdaptiveNetworkHardeningResourceName)]
        [ValidateNotNullOrEmpty]
        public string AdaptiveNetworkHardeningResourceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string ResourceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceNamespace)]
        [ValidateNotNullOrEmpty]
        public string ResourceNamespace { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceType)]
        [ValidateNotNullOrEmpty]
        public string ResourceType { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.SubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.RulesToEnforce)]
        [ValidateNotNullOrEmpty]
        public PSSecurityAdaptiveNetworkHardeningsRule[] Rule { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.EffectiveNetworkSecurityGroups)]
        [ValidateNotNullOrEmpty]
        public List<string> NetworkSecurityGroup { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            SecurityCenterClient.SubscriptionId = SubscriptionId;
            var rules = Rule.Select(rule => new Rule(rule.Name, rule.Direction, rule.DestinationPort, rule.Protocols, rule.IpAddresses)).ToList();

            if (ShouldProcess(target: AdaptiveNetworkHardeningResourceName, action: $"Add rules to NSG '{AdaptiveNetworkHardeningResourceName}'."))
            {
                var result = SecurityCenterClient.AdaptiveNetworkHardenings
                .BeginEnforceWithHttpMessagesAsync(ResourceGroupName, ResourceNamespace, ResourceType, ResourceName, AdaptiveNetworkHardeningResourceName, rules, NetworkSecurityGroup)
                .GetAwaiter()
                .GetResult(); WriteObject(true);
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
