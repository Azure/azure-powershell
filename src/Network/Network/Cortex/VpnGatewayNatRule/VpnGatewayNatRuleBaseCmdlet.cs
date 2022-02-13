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
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Net;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class VpnGatewayNatRuleBaseCmdlet : VpnGatewayBaseCmdlet
    {
        public INatRulesOperations NatRuleClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.NatRules;
            }
        }

        public PSVpnGatewayNatRule ToPsVpnGatewayNatRule(Management.Network.Models.VpnGatewayNatRule vpnGatewayNatRule)
        {
            return NetworkResourceManagerProfile.Mapper.Map<PSVpnGatewayNatRule>(vpnGatewayNatRule);
        }

        public PSVpnGatewayNatRule GetVpnGatewayNatRule(string resourceGroupName, string parentVpnGatewayName, string name)
        {
            var vpnGatewayNatRule = this.NatRuleClient.Get(resourceGroupName, parentVpnGatewayName, name);
            return this.ToPsVpnGatewayNatRule(vpnGatewayNatRule);
        }

        public List<PSVpnGatewayNatRule> ListVpnGatewayNatRules(string resourceGroupName, string parentVpnGatewayName)
        {
            var vpnGatewayNatRules = this.NatRuleClient.ListByVpnGateway(resourceGroupName, parentVpnGatewayName);

            List<PSVpnGatewayNatRule> vpnGatewayNatRulesToReturn = new List<PSVpnGatewayNatRule>();
            if (vpnGatewayNatRules != null)
            {
                foreach (MNM.VpnGatewayNatRule vpnGatewayNatRule in vpnGatewayNatRules)
                {
                    vpnGatewayNatRulesToReturn.Add(ToPsVpnGatewayNatRule(vpnGatewayNatRule));
                }
            }

            return vpnGatewayNatRulesToReturn;
        }

        public bool IsVpnGatewayNatRulePresent(string resourceGroupName, string parentVpnGatewayName, string name)
        {
            return NetworkBaseCmdlet.IsResourcePresent(() => { GetVpnGatewayNatRule(resourceGroupName, parentVpnGatewayName, name); });
        }
    }
}
