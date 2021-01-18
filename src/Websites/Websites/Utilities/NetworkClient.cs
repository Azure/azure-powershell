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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
//using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
//using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;
using Microsoft.Azure.Management.WebSites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.WebApps.Utilities
{
    public class NetworkClient
    {
        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public NetworkClient(IAzureContext context)
        {
            this.WrappedNetworkClient = AzureSession.Instance.ClientFactory.CreateArmClient<NetworkManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);

        }
        public NetworkManagementClient WrappedNetworkClient
        {
            get;
            private set;
        }

        public string GetNetworkInterfacePrivateIPAddress(string networkInterfaceId)
        {
            var nicId = new ResourceIdentifier(networkInterfaceId);
            var nic = WrappedNetworkClient.NetworkInterfaces.Get(nicId.ResourceGroupName, nicId.ResourceName);
            return nic.IpConfigurations[0].PrivateIPAddress;
        }

        public string ValidateSubnet(string subnet, string virtualNetworkName, string resourceGroupName, string subscriptionId)
        {
            //Resource Id Format: "subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworks/{2}/subnets/{3}"
            ResourceIdentifier subnetResourceId = null;
            if (subnet.ToLowerInvariant().Contains("/subnets/"))
            {
                try
                {
                    subnetResourceId = new ResourceIdentifier(subnet);
                }
                catch (ArgumentException ae)
                {
                    throw new ArgumentException("Subnet ResourceId is invalid.", ae);
                }
            }
            else
            {
                subnetResourceId = new ResourceIdentifier();
                subnetResourceId.Subscription = subscriptionId;
                subnetResourceId.ResourceGroupName = resourceGroupName;
                subnetResourceId.ResourceType = "Microsoft.Network/virtualNetworks/subnets";
                subnetResourceId.ParentResource = $"virtualNetworks/{virtualNetworkName}";
                subnetResourceId.ResourceName = subnet;
            }
            return subnetResourceId.ToString();
        }

        public string GetVirtualNetworkResourceId(string subnetResourceId)
        {
            ResourceIdentifier subnetId = new ResourceIdentifier(subnetResourceId);
            var virtualNetworkResourceId = new ResourceIdentifier();
            virtualNetworkResourceId.Subscription = subnetId.Subscription;
            virtualNetworkResourceId.ResourceGroupName = subnetId.ResourceGroupName;
            virtualNetworkResourceId.ResourceType = "Microsoft.Network/virtualNetworks";
            virtualNetworkResourceId.ResourceName = subnetId.ParentResource.Substring(subnetId.ParentResource.IndexOf('/')+1);
            return virtualNetworkResourceId.ToString();
        }

        public Subnet GetSubnet(string subnetResourceId)
        {
            var subnetId = new ResourceIdentifier(subnetResourceId);
            var resourceGroupName = subnetId.ResourceGroupName;
            var virtualNetworkName = subnetId.ParentResource.Substring(subnetId.ParentResource.IndexOf('/') + 1);
            var subnetName = subnetId.ResourceName;

            Subnet subnetObj = WrappedNetworkClient.Subnets.Get(resourceGroupName, virtualNetworkName, subnetName);
            return subnetObj;
        }

        public void UpdateSubnet(Subnet subnetObj)
        {
            var subnetId = new ResourceIdentifier(subnetObj.Id);
            var resourceGroupName = subnetId.ResourceGroupName;
            var virtualNetworkName = subnetId.ParentResource.Substring(subnetId.ParentResource.IndexOf('/') + 1);
            var subnetName = subnetId.ResourceName;

            WrappedNetworkClient.Subnets.CreateOrUpdate(resourceGroupName, virtualNetworkName, subnetName, subnetObj);
        }

        public void VerifyEmptySubnet(string subnetResourceId)
        {
            Subnet subnetObj = GetSubnet(subnetResourceId);

            if ((subnetObj.ResourceNavigationLinks != null && subnetObj.ResourceNavigationLinks.Count != 0) || (subnetObj.ServiceAssociationLinks != null && subnetObj.ServiceAssociationLinks.Count != 0))
                throw new Exception($"Subnet '{subnetObj.Name}' is not empty.");
        }

       public void EnsureSubnetPrivateEndpointPolicy(string subnetResourceId, bool privateEndpointNetworkPoliciesEnabled)
        {
            Subnet subnetObj = GetSubnet(subnetResourceId);
            string enabledTargetStatus = privateEndpointNetworkPoliciesEnabled ? "Enabled" : "Disabled";
            if (subnetObj.PrivateEndpointNetworkPolicies != enabledTargetStatus)
            {
                subnetObj.PrivateEndpointNetworkPolicies = enabledTargetStatus;
                UpdateSubnet(subnetObj);
            }
        }

        public void EnsureSubnetServiceEndpoint(string subnetResourceId, string serviceEndpointServiceName, List<string> serviceEndpointLocations)
        {
            Subnet subnetObj = GetSubnet(subnetResourceId);

            if (subnetObj.ServiceEndpoints == null)
            {
                subnetObj.ServiceEndpoints = new List<ServiceEndpointPropertiesFormat>();
                subnetObj.ServiceEndpoints.Add(new ServiceEndpointPropertiesFormat(serviceEndpointServiceName, serviceEndpointLocations));
                UpdateSubnet(subnetObj);
            }
            else
            {
                bool serviceEndpointExists = false;
                foreach (var serviceEndpoint in subnetObj.ServiceEndpoints)
                {
                    if (serviceEndpoint.Service == serviceEndpointServiceName)
                    {
                        serviceEndpointExists = true;
                        break;
                    }
                }
                if (!serviceEndpointExists)
                {
                    subnetObj.ServiceEndpoints.Add(new ServiceEndpointPropertiesFormat(serviceEndpointServiceName, serviceEndpointLocations));
                    UpdateSubnet(subnetObj);
                }
            }
        }

        public void EnsureSubnetDelegation(string subnetResourceId, string delegationServiceName)
        {
            Subnet subnetObj = GetSubnet(subnetResourceId);

            if (subnetObj.Delegations == null)
                subnetObj.Delegations = new List<Delegation>();

            if (subnetObj.Delegations.Count == 0)
            {
                subnetObj.Delegations.Add(new Delegation(name: "delegation", serviceName: delegationServiceName));
                UpdateSubnet(subnetObj);
            }
            else
            {
                var existingDelegationServiceName = subnetObj.Delegations[0].ServiceName;
                if (existingDelegationServiceName != delegationServiceName)
                    throw new Exception($"Subnet '{subnetObj.Name}' is already delegated to {existingDelegationServiceName}.");
            }
        }

        public string GetSubnetResourceGroupName(string subnet, string virtualNetworkName)
        {
            var matchedVNetwork = WrappedNetworkClient.VirtualNetworks.ListAll().FirstOrDefault(item => item.Name == virtualNetworkName);
            if (matchedVNetwork != null)
            {
                var subNets = matchedVNetwork.Subnets.ToList();
                Subnet matchedSubnet = matchedVNetwork.Subnets.FirstOrDefault(sItem => sItem.Name == subnet || sItem.Id == subnet);
                if (matchedSubnet != null)
                {
                    var subnetResourceId = new ResourceIdentifier(matchedSubnet.Id);
                    return subnetResourceId.ResourceGroupName;
                }
            }
            return null;
        }

        public PrivateEndpoint CreatePrivateEndpoint(string resourceGroupName, string privateEndpointNamePrefix, string privateLinkResourceId, string groupId, string subnetId, string location)
        {
            var privateEndpointName = $"{privateEndpointNamePrefix}PrivateEndpoint";
            var serviceConnectionName = $"{privateEndpointNamePrefix}ServiceConnection";
            var groupIds = new List<string>() { groupId };
            var pe = new PrivateEndpoint();
            pe.Subnet = new Subnet(id: subnetId);
            pe.Location = location;
            var plsConnection = new PrivateLinkServiceConnection();
            plsConnection.Name = serviceConnectionName;
            plsConnection.PrivateLinkServiceId = privateLinkResourceId;
            plsConnection.GroupIds = groupIds;
            pe.PrivateLinkServiceConnections = new List<PrivateLinkServiceConnection>() { plsConnection };
            return WrappedNetworkClient.PrivateEndpoints.CreateOrUpdate(resourceGroupName, privateEndpointName, pe);
        }
                               
        private void WriteVerbose(string verboseFormat, params object[] args)
        {
            if (VerboseLogger != null)
            {
                VerboseLogger(string.Format(verboseFormat, args));
            }
        }

        private void WriteWarning(string warningFormat, params object[] args)
        {
            if (WarningLogger != null)
            {
                WarningLogger(string.Format(warningFormat, args));
            }
        }

        private void WriteError(string errorFormat, params object[] args)
        {
            if (ErrorLogger != null)
            {
                ErrorLogger(string.Format(errorFormat, args));
            }
        }
    }
}
