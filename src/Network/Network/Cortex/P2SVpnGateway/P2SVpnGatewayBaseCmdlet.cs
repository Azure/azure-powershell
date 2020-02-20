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
    using MNM = Microsoft.Azure.Management.Network.Models;
    using System;
    using System.Collections;
    using System.Management.Automation;
    using System.Net;
    using System.Collections.Generic;

    public class P2SVpnGatewayBaseCmdlet : NetworkBaseCmdlet
    {
        public const string P2SConnectionConfigurationName = "P2SConnectionConfigDefault";

        public IP2sVpnGatewaysOperations P2SVpnGatewayClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.P2sVpnGateways;
            }
        }

        public PSP2SVpnGateway ToPsP2SVpnGateway(Management.Network.Models.P2SVpnGateway p2sVpnGateway)
        {
            var pSP2SVpnGateway = NetworkResourceManagerProfile.Mapper.Map<PSP2SVpnGateway>(p2sVpnGateway);
            pSP2SVpnGateway.Tag = TagsConversionHelper.CreateTagHashtable(p2sVpnGateway.Tags);

            return pSP2SVpnGateway;
        }

        public PSP2SVpnConnectionHealth ToPsP2SVpnConnectionHealth(Management.Network.Models.P2SVpnConnectionHealth p2sVpnGatewayConnectionHealth)
        {
            var p2SVpnConnectionHealth = NetworkResourceManagerProfile.Mapper.Map<PSP2SVpnConnectionHealth>(p2sVpnGatewayConnectionHealth);

            return p2SVpnConnectionHealth;
        }

        public PSP2SVpnGateway GetP2SVpnGateway(string resourceGroupName, string name)
        {
            var p2sVpnGateway = this.P2SVpnGatewayClient.Get(resourceGroupName, name);
            var psP2SVpnGateway = this.ToPsP2SVpnGateway(p2sVpnGateway);
            psP2SVpnGateway.ResourceGroupName = resourceGroupName;

            return psP2SVpnGateway;
        }

        public List<PSP2SVpnGateway> ListP2SVpnGateways(string resourceGroupName)
        {
            var p2sVpnGateways = ShouldListBySubscription(resourceGroupName, null) ?
                this.P2SVpnGatewayClient.List() :                                              //// List by sub id
                this.P2SVpnGatewayClient.ListByResourceGroup(resourceGroupName);               //// List by RG name

            List<PSP2SVpnGateway> gatewaysToReturn = new List<PSP2SVpnGateway>();
            if (p2sVpnGateways != null)
            {
                foreach (MNM.P2SVpnGateway gateway in p2sVpnGateways)
                {
                    PSP2SVpnGateway gatewayToReturn = ToPsP2SVpnGateway(gateway);
                    gatewayToReturn.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(gateway.Id);
                    gatewaysToReturn.Add(gatewayToReturn);
                }
            }

            return gatewaysToReturn;
        }

        public PSP2SVpnGateway CreateOrUpdateP2SVpnGateway(string resourceGroupName, string p2sVpnGatewayName, PSP2SVpnGateway p2sVpnGateway, Hashtable tags)
        {
            var p2sVpnGatewayModel = NetworkResourceManagerProfile.Mapper.Map<MNM.P2SVpnGateway>(p2sVpnGateway);
            p2sVpnGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true);

            var p2sVpnGatewayCreatedOrUpdated = this.P2SVpnGatewayClient.CreateOrUpdate(resourceGroupName, p2sVpnGatewayName, p2sVpnGatewayModel);
            PSP2SVpnGateway gatewayToReturn = this.ToPsP2SVpnGateway(p2sVpnGatewayCreatedOrUpdated);
            gatewayToReturn.ResourceGroupName = resourceGroupName;

            return gatewayToReturn;
        }

        public bool IsP2SVpnGatewayPresent(string resourceGroupName, string name)
        {
            return NetworkBaseCmdlet.IsResourcePresent(() => { GetP2SVpnGateway(resourceGroupName, name); });
        }
    }
}
