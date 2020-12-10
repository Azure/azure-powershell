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

using Microsoft.Azure.Commands.ContainerRegistry.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry.Commands
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ContainerRegistryNetworkRule", DefaultParameterSetName = ByVirtualNetworkRule)]
    [OutputType(typeof(IPSNetworkRule))]
    public class NewAzureContainerRegistryNetworkRule : ContainerRegistryCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "The action of network rule.")]
        public string Action { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByIPRule, HelpMessage = "Indicate to create IPRule.")]
        public SwitchParameter IPRule { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByIPRule, HelpMessage = "Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed.")]
        public string IPAddressOrRange { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByVirtualNetworkRule, HelpMessage = "Indicate to create VirtualNetworkRule.")]
        public SwitchParameter VirtualNetworkRule { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByVirtualNetworkRule, HelpMessage = "Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.")]
        public string VirtualNetworkResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            IPSNetworkRule rule = null;

            switch (this.ParameterSetName)
            {
                case ByVirtualNetworkRule:
                    rule = new PSVirtualNetworkRule(VirtualNetworkResourceId, Action);
                    break;
                case ByIPRule:
                    rule = new PSIPRule(IPAddressOrRange, Action);
                    break;
                default:
                    throw new PSArgumentException("Incorrect argument provided");
            }

            WriteObject(rule);
        }
    }
}
