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

    public class ExpressRouteGatewayBaseCmdlet : NetworkBaseCmdlet
    {
        public IExpressRouteGatewaysOperations ExpressRouteGatewayClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.ExpressRouteGateways;
            }
        }

        public PSExpressRouteGateway ToPsExpressRouteGateway(Management.Network.Models.ExpressRouteGateway expressRouteGateway)
        {
            var pSExpressRouteGateway = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteGateway>(expressRouteGateway);
            pSExpressRouteGateway.Tag = TagsConversionHelper.CreateTagHashtable(expressRouteGateway.Tags);

            return pSExpressRouteGateway;
        }

        public PSExpressRouteGateway GetExpressRouteGateway(string resourceGroupName, string name)
        {
            var expressRouteGateway = this.ExpressRouteGatewayClient.Get(resourceGroupName, name);
            if (expressRouteGateway == null)
            {
                return null;
            }

            var psExpressRouteGateway = this.ToPsExpressRouteGateway(expressRouteGateway);
            psExpressRouteGateway.ResourceGroupName = resourceGroupName;

            return psExpressRouteGateway;
        }

        public List<PSExpressRouteGateway> ListExpressRouteGateways(string resourceGroupName)
        {
            var expressRouteGateways = ShouldListBySubscription(resourceGroupName, null) ?
                this.ExpressRouteGatewayClient.ListBySubscription() :                                              //// List by sub id
                this.ExpressRouteGatewayClient.ListByResourceGroup(resourceGroupName);               //// List by RG name

            List<PSExpressRouteGateway> gatewaysToReturn = new List<PSExpressRouteGateway>();
            if (expressRouteGateways != null)
            {
                foreach (MNM.ExpressRouteGateway gateway in expressRouteGateways.Value)
                {
                    PSExpressRouteGateway gatewayToReturn = ToPsExpressRouteGateway(gateway);
                    gatewayToReturn.ResourceGroupName = resourceGroupName;
                    gatewaysToReturn.Add(gatewayToReturn);
                }
            }

            return gatewaysToReturn;
        }

        public PSExpressRouteGateway CreateOrUpdateExpressRouteGateway(string resourceGroupName, string expressRouteGatewayName, PSExpressRouteGateway expressRouteGateway, Hashtable tags)
        {
            var expressRouteGatewayModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ExpressRouteGateway>(expressRouteGateway);
            expressRouteGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true);

            this.ExpressRouteGatewayClient.CreateOrUpdate(resourceGroupName, expressRouteGatewayName, expressRouteGatewayModel);
            PSExpressRouteGateway gatewayToReturn = this.GetExpressRouteGateway(resourceGroupName, expressRouteGatewayName);

            return gatewayToReturn;
        }

        public bool IsExpressRouteGatewayPresent(string resourceGroupName, string name)
        {
            try
            {
                var expressRouteGateway = GetExpressRouteGateway(resourceGroupName, name);
                if (expressRouteGateway == null)
                {
                    return false;
                }
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
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
