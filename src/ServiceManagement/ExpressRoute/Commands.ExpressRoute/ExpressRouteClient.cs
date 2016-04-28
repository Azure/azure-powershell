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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Common;

namespace Microsoft.WindowsAzure.Commands.ExpressRoute
{
    using Microsoft.WindowsAzure.Management.ExpressRoute;
    using Microsoft.WindowsAzure.Management.ExpressRoute.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Net;
    using Utilities.Common;
    using Microsoft.Azure.Commands.Common.Authentication.Models;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Hyak.Common;


    public class ExpressRouteClient
    {
        public ExpressRouteManagementClient Client { get; internal set; }

        private static ClientType CreateClient<ClientType>(AzureSMProfile profile, AzureSubscription subscription) where ClientType : ServiceClient<ClientType>
        {
            return AzureSession.ClientFactory.CreateClient<ClientType>(profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        /// <summary>
        /// Creates new ExpressRouteClient
        /// </summary>
        /// <param name="subscription">Subscription containing websites to manipulate</param>
        /// <param name="profile">Azure Profile</param>
        public ExpressRouteClient(AzureSMProfile profile, AzureSubscription subscription)
            : this(CreateClient<ExpressRouteManagementClient>(profile, subscription))
        {
        }

        public ExpressRouteClient(ExpressRouteManagementClient client)
        {
            Client = client;
        }

        public string GetAzureDedicatedCircuitPeeringArpInfo(Guid serviceKey, BgpPeeringAccessType accessType, DevicePath devicePath)
        {
            return Client.DedicatedCircuitPeeringArpInfo.Get(serviceKey.ToString(), accessType, devicePath).Data.ToString();
        }

        public string GetAzureDedicatedCircuitPeeringRouteTableInfo(Guid serviceKey, BgpPeeringAccessType accessType, DevicePath devicePath)
        {
            return Client.DedicatedCircuitPeeringRouteTableInfo.Get(serviceKey.ToString(), accessType, devicePath).Data.ToString();
        }

        public string GetAzureDedicatedCircuitPeeringRouteTableSummary(Guid serviceKey, BgpPeeringAccessType accessType, DevicePath devicePath)
        {
            return Client.DedicatedCircuitPeeringRouteTableSummary.Get(serviceKey.ToString(), accessType, devicePath).Data.ToString();
        }

        public AzureDedicatedCircuitStats GetAzureDedicatedCircuitStatsInfo(Guid serviceKey, BgpPeeringAccessType accessType)
        {
            return Client.DedicatedCircuitStats.Get(serviceKey.ToString(), accessType).DedicatedCircuitStats;
        }
        public AzureBgpPeering GetAzureBGPPeering(Guid serviceKey, BgpPeeringAccessType accessType)
        {
            return Client.BorderGatewayProtocolPeerings.Get(serviceKey.ToString(), accessType).BgpPeering;
        }

        public AzureBgpPeering NewAzureBGPPeering(Guid serviceKey, string advertisedPublicPrefixes, UInt32 customerAsn, UInt32 peerAsn, string primaryPeerSubnet,
            string routingRegistryName, string secondaryPeerSubnet, UInt32 vlanId, BgpPeeringAccessType accessType, string sharedKey = null)
        {
            var result = Client.BorderGatewayProtocolPeerings.New(serviceKey.ToString(), accessType, new BorderGatewayProtocolPeeringNewParameters()
           {
               AdvertisedPublicPrefixes = advertisedPublicPrefixes,
               CustomerAutonomousSystemNumber = customerAsn,
               PeerAutonomousSystemNumber = peerAsn,
               PrimaryPeerSubnet = primaryPeerSubnet,
               RoutingRegistryName = routingRegistryName,
               SecondaryPeerSubnet = secondaryPeerSubnet,
               SharedKey = sharedKey,
               VirtualLanId = vlanId
           });

            if (result.HttpStatusCode.Equals(HttpStatusCode.OK))
            {
                return GetAzureBGPPeering(serviceKey, accessType);
            }
            else
            {
                throw new Exception(result.Error.ToString());
            }
        }

        public bool RemoveAzureBGPPeering(Guid serviceKey, BgpPeeringAccessType accessType)
        {
            var result = Client.BorderGatewayProtocolPeerings.Remove(serviceKey.ToString(), accessType);
            return result.HttpStatusCode.Equals(HttpStatusCode.OK);
        }

        public AzureBgpPeering UpdateAzureBGPPeering(Guid serviceKey,
            BgpPeeringAccessType accessType, UInt32 customerAsn, UInt32 peerAsn, string primaryPeerSubnet,
            string routingRegistryName, string secondaryPeerSubnet, UInt32 vlanId, string sharedKey)
        {
            var result = Client.BorderGatewayProtocolPeerings.Update(serviceKey.ToString(), accessType, new BorderGatewayProtocolPeeringUpdateParameters()
                {
                    CustomerAutonomousSystemNumber = customerAsn,
                    PeerAutonomousSystemNumber = peerAsn,
                    PrimaryPeerSubnet = primaryPeerSubnet,
                    RoutingRegistryName = routingRegistryName,
                    SecondaryPeerSubnet = secondaryPeerSubnet,
                    SharedKey = sharedKey,
                    VirtualLanId = vlanId,
                });
            if (result.HttpStatusCode.Equals(HttpStatusCode.OK))
            {
                return GetAzureBGPPeering(serviceKey, accessType);
            }
            else
            {
                throw new Exception(result.Error.ToString());
            }
        }

        public AzureDedicatedCircuit GetAzureDedicatedCircuit(Guid serviceKey)
        {
            return (Client.DedicatedCircuits.Get(serviceKey.ToString())).DedicatedCircuit;
        }

        public AzureDedicatedCircuit NewAzureDedicatedCircuit(string circuitName,
            UInt32 bandwidth, string location, string serviceProviderName, CircuitSku sku, BillingType billingType)
        {
            var result = Client.DedicatedCircuits.New(new DedicatedCircuitNewParameters()
            {
                Bandwidth = bandwidth,
                BillingType = billingType,
                CircuitName = circuitName,
                Location = location,
                ServiceProviderName = serviceProviderName,
                Sku = sku,
            });

            if (result.HttpStatusCode.Equals(HttpStatusCode.OK))
            {
                return GetAzureDedicatedCircuit(new Guid(result.Data));
            }
            else
            {
                throw new Exception(result.Error.ToString());
            }
        }

        public IEnumerable<AzureDedicatedCircuit> ListAzureDedicatedCircuit()
        {
            return (Client.DedicatedCircuits.List().DedicatedCircuits);
        }

        public AzureDedicatedCircuit SetAzureDedicatedCircuitProperties(Guid serviceKey, UInt32? bandwidth, CircuitSku? sku, BillingType? billingType)
        {
            var updateParams = new DedicatedCircuitUpdateParameters() { };

            if (bandwidth.HasValue)
            {
                updateParams.Bandwidth = bandwidth.Value.ToString();
            }

            if (sku.HasValue)
            {
                updateParams.Sku = sku.Value.ToString();
            }

            if (billingType.HasValue)
            {
                updateParams.BillingType = billingType.Value;
            }

            var result = Client.DedicatedCircuits.Update(serviceKey.ToString(), updateParams);

            if (result.HttpStatusCode.Equals(HttpStatusCode.OK))
            {
                return GetAzureDedicatedCircuit(serviceKey);
            }
            else
            {
                throw new Exception(result.Error.ToString());
            }
        }

        public bool RemoveAzureDedicatedCircuit(Guid serviceKey)
        {
            var result = Client.DedicatedCircuits.Remove(serviceKey.ToString());
            return result.HttpStatusCode.Equals(HttpStatusCode.OK);
        }

        public AzureDedicatedCircuitLink GetAzureDedicatedCircuitLink(Guid serviceKey, string vNetName)
        {
            return (Client.DedicatedCircuitLinks.Get(serviceKey.ToString(), vNetName)).DedicatedCircuitLink;
        }

        public AzureDedicatedCircuitLink NewAzureDedicatedCircuitLink(Guid serviceKey, string vNetName)
        {
            var result = Client.DedicatedCircuitLinks.New(serviceKey.ToString(), vNetName);
            if (result.HttpStatusCode.Equals(HttpStatusCode.OK))
            {
                return GetAzureDedicatedCircuitLink(serviceKey, vNetName);
            }
            else
            {
                throw new Exception(result.Error.ToString());
            }
        }

        public IEnumerable<AzureDedicatedCircuitLink> ListAzureDedicatedCircuitLink(Guid serviceKey)
        {
            return (Client.DedicatedCircuitLinks.List(serviceKey.ToString()).DedicatedCircuitLinks);
        }

        public bool RemoveAzureDedicatedCircuitLink(Guid serviceKey, string vNetName)
        {
            var result = Client.DedicatedCircuitLinks.Remove(serviceKey.ToString(), vNetName);
            return result.HttpStatusCode.Equals(HttpStatusCode.OK);
        }

        public IEnumerable<AzureDedicatedCircuitServiceProvider> ListAzureDedicatedCircuitServiceProviders()
        {
            return (Client.DedicatedCircuitServiceProviders.List().DedicatedCircuitServiceProviders);
        }

        public AzureCrossConnection GetAzureCrossConnection(Guid serviceKey)
        {
            return (Client.CrossConnections.Get(serviceKey.ToString())).CrossConnection;
        }

        public AzureCrossConnection NewAzureCrossConnection(Guid serviceKey)
        {
            var result = Client.CrossConnections.New(serviceKey.ToString());

            if (result.HttpStatusCode.Equals(HttpStatusCode.OK))
            {
                return GetAzureCrossConnection(serviceKey);
            }
            else
            {
                throw new Exception(result.Error.ToString());
            }
        }

        public AzureCrossConnection SetAzureCrossConnection(Guid serviceKey,
                                                            CrossConnectionUpdateParameters parameters)
        {
            var result = Client.CrossConnections.Update(serviceKey.ToString(), parameters);

            if (result.HttpStatusCode.Equals(HttpStatusCode.OK))
            {
                return GetAzureCrossConnection(serviceKey);
            }
            else
            {
                throw new Exception(result.Error.ToString());
            }
        }

        public IEnumerable<AzureCrossConnection> ListAzureCrossConnections()
        {
            return (Client.CrossConnections.List()).CrossConnections;
        }

        public AzureDedicatedCircuitLinkAuthorization GetAzureDedicatedCircuitLinkAuthorization(Guid serviceKey, Guid authorizationId)
        {
            return (Client.DedicatedCircuitLinkAuthorizations.Get(serviceKey.ToString(), authorizationId.ToString())).DedicatedCircuitLinkAuthorization;
        }

        public AzureDedicatedCircuitLinkAuthorization NewAzureDedicatedCircuitLinkAuthorization(Guid serviceKey, string description, int limit, string microsoftIds)
        {
            return (Client.DedicatedCircuitLinkAuthorizations.New(serviceKey.ToString(), new DedicatedCircuitLinkAuthorizationNewParameters()
            {
                Description = description,
                Limit = limit,
                MicrosoftIds = microsoftIds
            })).DedicatedCircuitLinkAuthorization;
        }

        public AzureDedicatedCircuitLinkAuthorization SetAzureDedicatedCircuitLinkAuthorization(Guid serviceKey, Guid authorizationId, string description, int limit)
        {
            return (Client.DedicatedCircuitLinkAuthorizations.Update(serviceKey.ToString(), authorizationId.ToString(), new DedicatedCircuitLinkAuthorizationUpdateParameters()
            {
                Description = description,
                Limit = limit
            })).DedicatedCircuitLinkAuthorization;
        }

        public IEnumerable<AzureDedicatedCircuitLinkAuthorization> ListAzureDedicatedCircuitLinkAuthorizations(Guid serviceKey)
        {
            return (Client.DedicatedCircuitLinkAuthorizations.List(serviceKey.ToString()).DedicatedCircuitLinkAuthorizations);
        }

        public bool RemoveAzureDedicatedCircuitLinkAuthorization(Guid serviceKey, Guid authorizationId)
        {
            var result = Client.DedicatedCircuitLinkAuthorizations.Remove(serviceKey.ToString(), authorizationId.ToString());
            return result.HttpStatusCode.Equals(HttpStatusCode.OK);
        }

        public AzureAuthorizedDedicatedCircuit GetAuthorizedAzureDedicatedCircuit(Guid serviceKey)
        {
            return (Client.AuthorizedDedicatedCircuits.Get(serviceKey.ToString())).AuthorizedDedicatedCircuit;
        }

        public IEnumerable<AzureAuthorizedDedicatedCircuit> ListAzureAuthorizedDedicatedCircuits()
        {
            return (Client.AuthorizedDedicatedCircuits.List().AuthorizedDedicatedCircuits);
        }

        public bool NewAzureDedicatedCircuitLinkAuthorizationMicrosoftIds(Guid serviceKey, Guid authorizationId, string microsoftIds)
        {
            var result = Client.DedicatedCircuitLinkAuthorizationMicrosoftIds.New(serviceKey.ToString(), authorizationId.ToString(), new DedicatedCircuitLinkAuthorizationMicrosoftIdNewParameters()
                {
                    MicrosoftIds = microsoftIds
                });
            return result.StatusCode.Equals(HttpStatusCode.OK);
        }

        public bool RemoveAzureDedicatedCircuitLinkAuthorizationMicrosoftIds(Guid serviceKey, Guid authorizationId, string microsoftIds)
        {
            var result = Client.DedicatedCircuitLinkAuthorizationMicrosoftIds.Remove(serviceKey.ToString(), authorizationId.ToString(), new DedicatedCircuitLinkAuthorizationMicrosoftIdRemoveParameters()
            {
                MicrosoftIds = microsoftIds
            });
            return result.StatusCode.Equals(HttpStatusCode.OK);
        }
    }
}
