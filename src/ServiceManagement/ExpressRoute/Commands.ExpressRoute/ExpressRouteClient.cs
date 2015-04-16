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
using Microsoft.Azure.Common.Authentication.Models;
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
    using Microsoft.Azure.Common.Authentication.Models;
    using Microsoft.Azure.Common.Authentication;
    using Hyak.Common;
    
   
    public class ExpressRouteClient
    {
        public ExpressRouteManagementClient Client { get; internal set; }

        private static ClientType CreateClient<ClientType>(AzureProfile profile, AzureSubscription subscription) where ClientType : ServiceClient<ClientType>
        {
            return AzureSession.ClientFactory.CreateClient<ClientType>(profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        /// <summary>
        /// Creates new ExpressRouteClient
        /// </summary>
        /// <param name="subscription">Subscription containing websites to manipulate</param>
        public ExpressRouteClient(AzureProfile profile, AzureSubscription subscription)
            : this(CreateClient<ExpressRouteManagementClient>(profile, subscription))
        {   
        }

        public ExpressRouteClient(ExpressRouteManagementClient client)
        {
            Client = client;
        }

        public AzureBgpPeering GetAzureBGPPeering(string serviceKey, BgpPeeringAccessType accessType)
        {
            return Client.BorderGatewayProtocolPeerings.Get(serviceKey, accessType).BgpPeering;
        }

        public AzureBgpPeering NewAzureBGPPeering(string serviceKey, string advertisedPublicPrefixes, UInt32 customerAsn,
            UInt32 peerAsn, string primaryPeerSubnet, string routingRegistryName, string secondaryPeerSubnet,
            UInt32 vlanId, BgpPeeringAccessType accessType, string sharedKey = null)
        {
             var result = Client.BorderGatewayProtocolPeerings.New(serviceKey, accessType, new BorderGatewayProtocolPeeringNewParameters()
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

        public bool RemoveAzureBGPPeering(string serviceKey, BgpPeeringAccessType accessType)
        {
            var result = Client.BorderGatewayProtocolPeerings.Remove(serviceKey, accessType);
            return result.HttpStatusCode.Equals(HttpStatusCode.OK);
        }

        public AzureBgpPeering UpdateAzureBGPPeering(string serviceKey,
            BgpPeeringAccessType accessType, UInt32 customerAsn, UInt32 peerAsn, string primaryPeerSubnet,
            string routingRegistryName, string secondaryPeerSubnet, UInt32 vlanId, string sharedKey)
        
            
        
        {
            var result = Client.BorderGatewayProtocolPeerings.Update(serviceKey, accessType, new BorderGatewayProtocolPeeringUpdateParameters()
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
        
        public AzureDedicatedCircuit GetAzureDedicatedCircuit(string serviceKey)
        {
            return (Client.DedicatedCircuits.Get(serviceKey)).DedicatedCircuit;
        }

        public AzureDedicatedCircuit NewAzureDedicatedCircuit(string circuitName, 
            UInt32 bandwidth, string location, string serviceProviderName)
        {
            var result = Client.DedicatedCircuits.New(new DedicatedCircuitNewParameters()
            {
                Bandwidth = bandwidth,
                CircuitName = circuitName,
                Location = location,
                ServiceProviderName = serviceProviderName
            });

            if (result.HttpStatusCode.Equals(HttpStatusCode.OK))
            {
                return GetAzureDedicatedCircuit(result.Data);
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

        public AzureDedicatedCircuit SetAzureDedicatedCircuitBandwidth(string serviceKey, UInt32 bandwidth)
        {
            var result = Client.DedicatedCircuits.Update(serviceKey, (new DedicatedCircuitUpdateParameters()
            {
                Bandwidth = bandwidth.ToString()
            }));

            if (result.HttpStatusCode.Equals(HttpStatusCode.OK))
            {
                return GetAzureDedicatedCircuit(serviceKey);
            }
            else
            {
                throw new Exception(result.Error.ToString());
            }
        }

        public bool RemoveAzureDedicatedCircuit(string serviceKey)
        {
            var result = Client.DedicatedCircuits.Remove(serviceKey);
            return result.HttpStatusCode.Equals(HttpStatusCode.OK);
        }

        public AzureDedicatedCircuitLink GetAzureDedicatedCircuitLink(string serviceKey, string vNetName)
        {
            return (Client.DedicatedCircuitLinks.Get(serviceKey, vNetName)).DedicatedCircuitLink;
        }

        public AzureDedicatedCircuitLink NewAzureDedicatedCircuitLink(string serviceKey, string vNetName)
        {
            var result = Client.DedicatedCircuitLinks.New(serviceKey, vNetName);
            if (result.HttpStatusCode.Equals(HttpStatusCode.OK))
            {
                return GetAzureDedicatedCircuitLink(serviceKey, vNetName);
            }
            else
            {
                throw new Exception(result.Error.ToString());
            }
        }

        public IEnumerable<AzureDedicatedCircuitLink> ListAzureDedicatedCircuitLink(string serviceKey)
        {
            return (Client.DedicatedCircuitLinks.List(serviceKey).DedicatedCircuitLinks);
        }

        public bool RemoveAzureDedicatedCircuitLink(string serviceKey, string vNetName)
        {
            var result = Client.DedicatedCircuitLinks.Remove(serviceKey, vNetName);
            return result.HttpStatusCode.Equals(HttpStatusCode.OK);
        }

        public IEnumerable<AzureDedicatedCircuitServiceProvider> ListAzureDedicatedCircuitServiceProviders()
        {
            return (Client.DedicatedCircuitServiceProviders.List().DedicatedCircuitServiceProviders);
        }

        public AzureCrossConnection GetAzureCrossConnection(string serviceKey)
        {
            return (Client.CrossConnections.Get(serviceKey)).CrossConnection;
        }

        public AzureCrossConnection NewAzureCrossConnection(string serviceKey)
        {
            var result = Client.CrossConnections.New(serviceKey);

            if (result.HttpStatusCode.Equals(HttpStatusCode.OK))
            {
                return GetAzureCrossConnection(serviceKey);
            }
            else
            {
                throw new Exception(result.Error.ToString());
            }
        }

        public AzureCrossConnection SetAzureCrossConnection(string serviceKey,
                                                            CrossConnectionUpdateParameters parameters)
        {
            var result = Client.CrossConnections.Update(serviceKey, parameters);

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

        public AzureDedicatedCircuitLinkAuthorization GetAzureDedicatedCircuitLinkAuthorization(string serviceKey, string authorizationId)
        {
            return (Client.DedicatedCircuitLinkAuthorizations.Get(serviceKey, authorizationId)).DedicatedCircuitLinkAuthorization;
        }

        public AzureDedicatedCircuitLinkAuthorization NewAzureDedicatedCircuitLinkAuthorization(string serviceKey, string description, int limit, string microsoftIds)
        {
            return (Client.DedicatedCircuitLinkAuthorizations.New(serviceKey, new DedicatedCircuitLinkAuthorizationNewParameters()
            {
                Description = description,
                Limit = limit,
                MicrosoftIds = microsoftIds
            })).DedicatedCircuitLinkAuthorization;
        }

        public AzureDedicatedCircuitLinkAuthorization SetAzureDedicatedCircuitLinkAuthorization(string serviceKey, string authorizationId, string description, int limit)
        {
            return (Client.DedicatedCircuitLinkAuthorizations.Update(serviceKey, authorizationId, new DedicatedCircuitLinkAuthorizationUpdateParameters()
            {
                Description = description,
                Limit = limit
            })).DedicatedCircuitLinkAuthorization;
        }

        public IEnumerable<AzureDedicatedCircuitLinkAuthorization> ListAzureDedicatedCircuitLinkAuthorizations(string serviceKey)
        {
            return (Client.DedicatedCircuitLinkAuthorizations.List(serviceKey).DedicatedCircuitLinkAuthorizations);
        }

        public bool RemoveAzureDedicatedCircuitLinkAuthorization(string serviceKey, string authorizationId)
        {
            var result = Client.DedicatedCircuitLinkAuthorizations.Remove(serviceKey, authorizationId);
            return result.HttpStatusCode.Equals(HttpStatusCode.OK);
        }

        public AzureAuthorizedDedicatedCircuit GetAuthorizedAzureDedicatedCircuit(string serviceKey)
        {
            return (Client.AuthorizedDedicatedCircuits.Get(serviceKey)).AuthorizedDedicatedCircuit;
        }

        public IEnumerable<AzureAuthorizedDedicatedCircuit> ListAzureAuthorizedDedicatedCircuits()
        {
            return (Client.AuthorizedDedicatedCircuits.List().AuthorizedDedicatedCircuits);
        }

        public bool NewAzureDedicatedCircuitLinkAuthorizationMicrosoftIds(string serviceKey, string authorizationId, string microsoftIds)
        {
            var result = Client.DedicatedCircuitLinkAuthorizationMicrosoftIds.New(serviceKey, authorizationId, new DedicatedCircuitLinkAuthorizationMicrosoftIdNewParameters()
                {
                    MicrosoftIds = microsoftIds
                });
            return result.StatusCode.Equals(HttpStatusCode.OK);
        }

        public bool RemoveAzureDedicatedCircuitLinkAuthorizationMicrosoftIds(string serviceKey, string authorizationId, string microsoftIds)
        {
            var result = Client.DedicatedCircuitLinkAuthorizationMicrosoftIds.Remove(serviceKey, authorizationId, new DedicatedCircuitLinkAuthorizationMicrosoftIdRemoveParameters()
            {
                MicrosoftIds = microsoftIds
            });
            return result.StatusCode.Equals(HttpStatusCode.OK);
        }

    }  
}
