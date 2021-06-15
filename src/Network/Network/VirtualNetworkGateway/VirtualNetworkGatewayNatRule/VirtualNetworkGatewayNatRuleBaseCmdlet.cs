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

namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Net;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class VirtualNetworkGatewayNatRuleBaseCmdlet : VirtualNetworkGatewayBaseCmdlet
    {
        public IVirtualNetworkGatewayNatRulesOperations NatRuleClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualNetworkGatewayNatRules;
            }
        }

        public PSVirtualNetworkGatewayNatRule ToPsVirtualNetworkGatewayNatRule(Management.Network.Models.VirtualNetworkGatewayNatRule virtualNetworkGatewayNatRule)
        {
            return NetworkResourceManagerProfile.Mapper.Map<PSVirtualNetworkGatewayNatRule>(virtualNetworkGatewayNatRule);
        }

        public PSVirtualNetworkGatewayNatRule GetVirtualNetworkGatewayNatRule(string resourceGroupName, string parentGatewayName, string name)
        {
            var gatewayNatRule = this.NatRuleClient.Get(resourceGroupName, parentGatewayName, name);
            return this.ToPsVirtualNetworkGatewayNatRule(gatewayNatRule);
        }

        public List<PSVirtualNetworkGatewayNatRule> ListVirtualNetworkGatewayNatRules(string resourceGroupName, string parentGatewayName)
        {
            var virtualNetworkGatewayNatRules = this.NatRuleClient.ListByVirtualNetworkGateway(resourceGroupName, parentGatewayName);

            List<PSVirtualNetworkGatewayNatRule> gatewayNatRulesToReturn = new List<PSVirtualNetworkGatewayNatRule>();
            if (virtualNetworkGatewayNatRules != null)
            {
                foreach (MNM.VirtualNetworkGatewayNatRule gatewayNatRule in virtualNetworkGatewayNatRules)
                {
                    gatewayNatRulesToReturn.Add(ToPsVirtualNetworkGatewayNatRule(gatewayNatRule));
                }
            }

            return gatewayNatRulesToReturn;
        }

        public bool IsVirtualNetworkGatewayNatRulePresent(string resourceGroupName, string parentGatewayName, string name)
        {
            return NetworkBaseCmdlet.IsResourcePresent(() => { GetVirtualNetworkGatewayNatRule(resourceGroupName, parentGatewayName, name); });
        }

        public PSVirtualNetworkGatewayNatRule CreateOrUpdateVirtualNetworkGatewayNatRule(string resourceGroupName, string virtualNetworkGatewayName, string NatRuleName, PSVirtualNetworkGatewayNatRule virtualNetworkGatewayNatRule)
        {
            var gatewayNatRuleModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetworkGatewayNatRule>(virtualNetworkGatewayNatRule);

            var gatewayNatRuleCreatedOrUpdated = this.NatRuleClient.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, NatRuleName, gatewayNatRuleModel);
            PSVirtualNetworkGatewayNatRule gatewayNatRuleToReturn = this.ToPsVirtualNetworkGatewayNatRule(gatewayNatRuleCreatedOrUpdated);
            return gatewayNatRuleToReturn;
        }
    }
}
