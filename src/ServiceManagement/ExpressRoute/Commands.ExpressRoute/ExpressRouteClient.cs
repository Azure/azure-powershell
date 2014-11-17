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

using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Management.ExpressRoute;
using Microsoft.WindowsAzure.Management.ExpressRoute.Models;

namespace Microsoft.WindowsAzure.Commands.ExpressRoute
{
    public class ExpressRouteClient
    {
        public ExpressRouteManagementClient Client { get; internal set; }

        /// <summary>
        /// Creates new ExpressRouteClient
        /// </summary>
        /// <param name="subscription">Subscription containing websites to manipulate</param>
        public ExpressRouteClient(AzureSubscription subscription)
        {
            Client = AzureSession.ClientFactory.CreateClient<ExpressRouteManagementClient>(subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        public ExpressRouteClient(ExpressRouteManagementClient client)
        {
            Client = client;
        }

        public AzureBgpPeering GetAzureBGPPeering(string serviceKey, BgpPeeringAccessType accessType)
        {
            return Client.BorderGatewayProtocolPeerings.Get(serviceKey, accessType).BgpPeering;
        }

        public AzureBgpPeering NewAzureBGPPeering(string serviceKey, UInt32 peerAsn, string primaryPeerSubnet,
            string secondaryPeerSubnet, UInt32 vlanId, BgpPeeringAccessType accessType, string sharedKey = null)
        {
            return Client.BorderGatewayProtocolPeerings.New(serviceKey, accessType, new BorderGatewayProtocolPeeringNewParameters()
            {
                PeerAutonomousSystemNumber = peerAsn,
                PrimaryPeerSubnet = primaryPeerSubnet,
                SecondaryPeerSubnet = secondaryPeerSubnet,
                SharedKey = sharedKey,
                VirtualLanId = vlanId
            }).BgpPeering;
        }

        public bool RemoveAzureBGPPeering(string serviceKey, BgpPeeringAccessType accessType)
        {
            var result = Client.BorderGatewayProtocolPeerings.Remove(serviceKey, accessType);
            return result.HttpStatusCode.Equals(HttpStatusCode.OK);
        }

        public AzureBgpPeering UpdateAzureBGPPeering(string serviceKey, 
            BgpPeeringAccessType accessType, UInt32 peerAsn, string primaryPeerSubnet,
            string secondaryPeerSubnet, UInt32 vlanId, string sharedKey)
        {
            return
               (Client.BorderGatewayProtocolPeerings.Update(serviceKey, accessType, new BorderGatewayProtocolPeeringUpdateParameters()
                {
                    PeerAutonomousSystemNumber = peerAsn,
                    PrimaryPeerSubnet = primaryPeerSubnet,
                    SecondaryPeerSubnet = secondaryPeerSubnet,
                    SharedKey = sharedKey,
                    VirtualLanId = vlanId,
                })).BgpPeering;
        }
        
        public AzureDedicatedCircuit GetAzureDedicatedCircuit(string serviceKey)
        {
            return (Client.DedicatedCircuits.Get(serviceKey)).DedicatedCircuit;
        }

		public AzureDedicatedCircuit NewAzureDedicatedCircuit(string circuitName, 
            UInt32 bandwidth, string location, string serviceProviderName)
        {
            return (Client.DedicatedCircuits.New(new DedicatedCircuitNewParameters()
            {
                Bandwidth = bandwidth,
                CircuitName = circuitName,
                Location = location,
                ServiceProviderName = serviceProviderName
            })).DedicatedCircuit;
        }

        public IEnumerable<AzureDedicatedCircuit> ListAzureDedicatedCircuit()
        {
            return (Client.DedicatedCircuits.List().DedicatedCircuits);
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
            return (Client.DedicatedCircuitLinks.New(serviceKey, vNetName)).DedicatedCircuitLink;
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
            return (Client.CrossConnections.New(serviceKey)).CrossConnection;
        }

        public AzureCrossConnection SetAzureCrossConnection(string serviceKey,
                                                            CrossConnectionUpdateParameters parameters)
        {
            return (Client.CrossConnections.Update(serviceKey, parameters)).CrossConnection;
        }

        public IEnumerable<AzureCrossConnection> ListAzureCrossConnections()
        {
            return (Client.CrossConnections.List()).CrossConnections;
        } 
    }  
}
