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

using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSVirtualNetworkRule
    {
        public PSVirtualNetworkRule()
        {
        }

        public PSVirtualNetworkRule(VirtualNetworkRule virtualNetworkRule)
        {
            Id = virtualNetworkRule.Id;
            IgnoreMissingVNetServiceEndpoint = virtualNetworkRule.IgnoreMissingVNetServiceEndpoint;
        }

        //
        // Summary:
        //     Gets or sets resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}.
        public string Id { get; set; }
        //
        // Summary:
        //     Gets or sets create firewall rule before the virtual network has vnet service
        //     endpoint enabled.
        public bool? IgnoreMissingVNetServiceEndpoint { get; set; }

        static public VirtualNetworkRule ConvertPSVirtualNetworkRuleToVirtualNetworkRule(PSVirtualNetworkRule psVirtualNetworkRule)
        {
            return new VirtualNetworkRule
            {
                Id = psVirtualNetworkRule.Id,
                IgnoreMissingVNetServiceEndpoint = psVirtualNetworkRule.IgnoreMissingVNetServiceEndpoint
            };
        }
    }
}