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
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.PrivateLinkService.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Internal.Common;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Common.Exceptions;

namespace Microsoft.Azure.Commands.Network.PrivateLinkService.PrivateLinkServiceProvider
{
    internal class GenericProvider : IPrivateLinkProvider
    {
        #region Constructor
        public GenericProvider(NetworkBaseCmdlet baseCmdlet, string subscription, string privateLinkResourceType)
        {
            this.BaseCmdlet = baseCmdlet;
            this._subscription = subscription;
            this._configuration = ProviderConfiguration.GetProviderConfiguration(privateLinkResourceType);
        }
        #endregion

        #region Interface Implementation

        public static bool SupportsPrivateLinkFeature(string privateLinkResourceType)
        {
            ProviderConfiguration configuration = ProviderConfiguration.GetProviderConfiguration(privateLinkResourceType);
            return (configuration != null);
        }

        public NetworkBaseCmdlet BaseCmdlet { get; set; }
        private string _subscription;
        private ProviderConfiguration _configuration;

        private IAzureRestClient _client;
        private IAzureRestClient ServiceClient
        {
            get
            {
                if (_client == null)
                {
                    var context = BaseCmdlet.DefaultProfile.DefaultContext;
                    var clientFactory = AzureSession.Instance.ClientFactory;
                    _client = clientFactory.CreateArmClient<AzureRestClient>(context, AzureEnvironment.Endpoint.ResourceManager);
                }
                return _client;

            }
        }

        public PSPrivateEndpointConnection GetPrivateEndpointConnection(string resourceGroupName, string serviceName, string name)
        {
            string url = BuildPrivateEndpointConnectionURL(resourceGroupName, serviceName, name);
            PrivateEndpointConnection connnection = ServiceClient.Operations.GetResource<PrivateEndpointConnection>(url, _configuration.ApiVersion);
            return ToPsPrivateEndpointConnection(connnection);
        }

        public List<PSPrivateEndpointConnection> ListPrivateEndpointConnections(string resourceGroupName, string serviceName)
        {
            var psPECs = new List<PSPrivateEndpointConnection>();
            if(_configuration.HasConnectionsURI)
            {
                string url = BuildPrivateEndpointConnectionsURL(resourceGroupName, serviceName);
                IPage<PrivateEndpointConnection> list = ServiceClient.Operations.GetResourcePage<Page<PrivateEndpointConnection>, PrivateEndpointConnection>(url, _configuration.ApiVersion);
                foreach (var pec in list)
                {
                    var psPec = ToPsPrivateEndpointConnection(pec);
                    psPECs.Add(psPec);
                }
                while (list.NextPageLink != null)
                {
                    list = ServiceClient.Operations.GetResourcePage<Page<PrivateEndpointConnection>, PrivateEndpointConnection>(list.NextPageLink, null);
                    foreach (var pec in list)
                    {
                        var psPec = ToPsPrivateEndpointConnection(pec);
                        psPECs.Add(psPec);
                    }
                }
            } 
            else
            {
                string url = BuildPrivateEndpointConnectionsOwnerURL(resourceGroupName, serviceName);
                TrackedResource resource = ServiceClient.Operations.GetResource<TrackedResource>(url, _configuration.ApiVersion);
                if(resource?.PrivateEndpointConnections != null)
                {
                    foreach (var pec in resource.PrivateEndpointConnections)
                    {
                        var psPec = ToPsPrivateEndpointConnection(pec);
                        psPECs.Add(psPec);
                    }
                }
            }

            return psPECs;
        }

        public PSPrivateEndpointConnection UpdatePrivateEndpointConnectionStatus(string resourceGroupName, string serviceName, string name, string status, string description = null)
        {
            string url = BuildPrivateEndpointConnectionURL(resourceGroupName, serviceName, name);
            PrivateEndpointConnection privateEndpointConnection = ServiceClient.Operations.GetResource<PrivateEndpointConnection>(url, _configuration.ApiVersion);

            privateEndpointConnection.PrivateLinkServiceConnectionState.Status = status;

            if (!string.IsNullOrEmpty(description))
            {
                privateEndpointConnection.PrivateLinkServiceConnectionState.Description = description;
            }

            ServiceClient.Operations.PutResource<PrivateEndpointConnection>(url, _configuration.ApiVersion, privateEndpointConnection);

            return GetPrivateEndpointConnection(resourceGroupName, serviceName, name);
        }

        public void DeletePrivateEndpointConnection(string resourceGroupName, string serviceName, string name)
        {
            string url = BuildPrivateEndpointConnectionURL(resourceGroupName, serviceName, name);
            ServiceClient.Operations.DeleteResource(url, _configuration.ApiVersion);
        }

        public PSPrivateLinkResource GetPrivateLinkResource(string resourceGroupName, string serviceName, string name)
        {
            if (_configuration.SupportGetPrivateLinkResource)
            {
                string url = BuildPrivateLinkResourceURL(resourceGroupName, serviceName, name);
                PrivateLinkResource resource = ServiceClient.Operations.GetResource<PrivateLinkResource>(url, _configuration.ApiVersion);
                return ToPsPrivateLinkResource(resource);
            }

            return ListPrivateLinkResource(resourceGroupName, serviceName).Single(plr => plr.Name.Equals(name));
        }

        public List<PSPrivateLinkResource> ListPrivateLinkResource(string resourceGroupName, string serviceName)
        {
            var psPLRs = new List<PSPrivateLinkResource>();
            string url = BuildPrivateLinkResourcesURL(resourceGroupName, serviceName);
            IPage<PrivateLinkResource> list = ServiceClient.Operations.GetResourcePage<Page<PrivateLinkResource>, PrivateLinkResource>(url, _configuration.ApiVersion);
            foreach (var plr in list)
            {
                var psPlr = ToPsPrivateLinkResource(plr);
                psPLRs.Add(psPlr);
            }
            while (list.NextPageLink != null)
            {
                list = ServiceClient.Operations.GetResourcePage<Page<PrivateLinkResource>, PrivateLinkResource>(list.NextPageLink, null);
                foreach (var plr in list)
                {
                    var psPlr = ToPsPrivateLinkResource(plr);
                    psPLRs.Add(psPlr);
                }
            }
            return psPLRs;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// /subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_privateLinkResourceType}/{serviceName}/privateLinkResources
        /// </summary>
        private string BuildPrivateLinkResourcesURL(string resourceGroupName, string serviceName)
        {
            return $"/subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_configuration.Type}/{serviceName}/privateLinkResources";
        }

        /// <summary>
        /// /subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_privateLinkResourceType}/{serviceName}/privateLinkResources/{name}
        /// </summary>
        private string BuildPrivateLinkResourceURL(string resourceGroupName, string serviceName, string name)
        {
            return $"/subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_configuration.Type}/{serviceName}/privateLinkResources/{name}";
        }

        /// <summary>
        /// /subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_privateLinkResourceType}/{serviceName}/privateEndpointConnections
        /// </summary>
        private string BuildPrivateEndpointConnectionsURL(string resourceGroupName, string serviceName)
        {
            return $"/subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_configuration.Type}/{serviceName}/privateEndpointConnections";
        }

        private string BuildPrivateEndpointConnectionsOwnerURL(string resourceGroupName, string serviceName)
        {
            return $"/subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_configuration.Type}/{serviceName}";
        }


        /// <summary>
        /// /subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_privateLinkResourceType}/{serviceName}/privateEndpointConnections/{name}
        /// </summary>
        private string BuildPrivateEndpointConnectionURL(string resourceGroupName, string serviceName, string name)
        {
            return $"/subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_configuration.Type}/{serviceName}/privateEndpointConnections/{name}";
        }

        private PSPrivateEndpointConnection ToPsPrivateEndpointConnection(PrivateEndpointConnection privateEndpointConnection)
        {
            PSPrivateEndpointConnection psPEC = new PSPrivateEndpointConnection
            {
                Name = privateEndpointConnection.Name,
                Id = privateEndpointConnection.Id,
                ProvisioningState = privateEndpointConnection.ProvisioningState,
                GroupId = privateEndpointConnection.GroupId,
            };
            psPEC.PrivateEndpoint = new PSPrivateEndpoint
            {
                Id = privateEndpointConnection.PrivateEndpoint.Id
            };
            psPEC.PrivateLinkServiceConnectionState = new PSPrivateLinkServiceConnectionState
            {
                Status = privateEndpointConnection.PrivateLinkServiceConnectionState.Status,
                Description = privateEndpointConnection.PrivateLinkServiceConnectionState.Description,
                ActionRequired = privateEndpointConnection.PrivateLinkServiceConnectionState.ActionsRequired
            };
            return psPEC;
        }

        private PSPrivateLinkResource ToPsPrivateLinkResource(PrivateLinkResource privateLinkResource)
        {
            PSPrivateLinkResource psPLR = new PSPrivateLinkResource
            {
                Name = privateLinkResource.Name,
                Id = privateLinkResource.Id,
                Type = privateLinkResource.Type,
                GroupId = privateLinkResource.Properties.GroupId
            };
            if(privateLinkResource.Properties.RequiredMembers != null)
            {
                psPLR.RequiredMembers = new List<string>(privateLinkResource.Properties.RequiredMembers);
            }
            if(privateLinkResource.Properties.RequiredZoneNames != null)
            {
                psPLR.RequiredZoneNames = new List<string>(privateLinkResource.Properties.RequiredZoneNames);
            }
            return psPLR;
        }
        #endregion
    }
}
