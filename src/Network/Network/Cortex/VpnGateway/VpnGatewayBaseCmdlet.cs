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

    public class VpnGatewayBaseCmdlet : NetworkBaseCmdlet
    {
        public IVpnGatewaysOperations VpnGatewayClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VpnGateways;
            }
        }

        public PSVpnGateway ToPsVpnGateway(Management.Network.Models.VpnGateway vpnGateway)
        {
            var pSVpnGateway = NetworkResourceManagerProfile.Mapper.Map<PSVpnGateway>(vpnGateway);
            pSVpnGateway.Tag = TagsConversionHelper.CreateTagHashtable(vpnGateway.Tags);

            return pSVpnGateway;
        }

        public PSVpnGateway GetVpnGateway(string resourceGroupName, string name)
        {
            var vpnGateway = this.VpnGatewayClient.Get(resourceGroupName, name);
            var psVpnGateway = this.ToPsVpnGateway(vpnGateway);
            psVpnGateway.ResourceGroupName = resourceGroupName;

            return psVpnGateway;
        }

        public List<PSVpnGateway> ListVpnGateways(string resourceGroupName)
        {
            var vpnGateways = ShouldListBySubscription(resourceGroupName, null) ?
                this.VpnGatewayClient.List() :                                              //// List by sub id
                this.VpnGatewayClient.ListByResourceGroup(resourceGroupName);               //// List by RG name

            List<PSVpnGateway> gatewaysToReturn = new List<PSVpnGateway>();
            if (vpnGateways != null)
            {
                foreach (MNM.VpnGateway gateway in vpnGateways)
                {
                    PSVpnGateway gatewayToReturn = ToPsVpnGateway(gateway);
                    gatewayToReturn.ResourceGroupName = resourceGroupName;
                    gatewaysToReturn.Add(gatewayToReturn);
                }
            }

            return gatewaysToReturn;
        }

        public PSVpnGateway CreateOrUpdateVpnGateway(string resourceGroupName, string vpnGatewayName, PSVpnGateway vpnGateway, Hashtable tags)
        {
            var vpnGatewayModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VpnGateway>(vpnGateway);
            vpnGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true);

            var vpnGatewayCreatedOrUpdated = this.VpnGatewayClient.CreateOrUpdate(resourceGroupName, vpnGatewayName, vpnGatewayModel);
            PSVpnGateway gatewayToReturn = this.ToPsVpnGateway(vpnGatewayCreatedOrUpdated);
            gatewayToReturn.ResourceGroupName = resourceGroupName;

            return gatewayToReturn;
        }

        public bool IsVpnGatewayPresent(string resourceGroupName, string name)
        {
            try
            {
                GetVpnGateway(resourceGroupName, name);
            }
            catch (Microsoft.Azure.Management.Network.Models.ErrorException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }
            }

            return true;
        }
    }
}
