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

namespace Microsoft.Azure.Commands.Network.PrivateLinkService.PrivateLinkServiceProvider
{
    internal class GenericProvider : IPrivateLinkProvider
    {

        private static IDictionary<string, string> _apiVersions = new Dictionary<string, string>{
            {"microsoft.sql/servers", "2018-06-01-preview"}
        };

        #region Constructor
        public GenericProvider(NetworkBaseCmdlet baseCmdlet, string subscription, string privateLinkResourceType)
        {
            this.BaseCmdlet = baseCmdlet;
            this._subscription = subscription;
            this._privateLinkResourceType = privateLinkResourceType;
            this._apiVersion = _apiVersions[privateLinkResourceType?.ToLower()];
        }
        #endregion

        #region Interface Implementation

        public static bool SupportsPrivateLinkResourceType(string privateLinkResourceType)
        {
            return _apiVersions.ContainsKey(privateLinkResourceType?.ToLower());
        }

        public NetworkBaseCmdlet BaseCmdlet { get; set; }
        private string _subscription;
        private string _privateLinkResourceType;
        private string _apiVersion;

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
            PrivateEndpointConnection connnection = ServiceClient.Operations.GetResouce<PrivateEndpointConnection>(url, _apiVersion);
            return ToPsPrivateEndpointConnection(connnection);
        }

        public List<PSPrivateEndpointConnection> ListPrivateEndpointConnections(string resourceGroupName, string serviceName)
        {
            var psPECs = new List<PSPrivateEndpointConnection>();
            string url = BuildPrivateEndpointConnectionsURL(resourceGroupName, serviceName);
            IPage<PrivateEndpointConnection> list = ServiceClient.Operations.GetResoucePage<Page<PrivateEndpointConnection>, PrivateEndpointConnection>(url, _apiVersion);
            foreach (var pec in list)
            {
                var psPec = ToPsPrivateEndpointConnection(pec);
                psPECs.Add(psPec);
            }
            while (list.NextPageLink != null)
            {
                list = ServiceClient.Operations.GetResoucePage<Page<PrivateEndpointConnection>, PrivateEndpointConnection>(list.NextPageLink, null);
                foreach (var pec in list)
                {
                    var psPec = ToPsPrivateEndpointConnection(pec);
                    psPECs.Add(psPec);
                }
            }
            return psPECs;
        }

        public PSPrivateEndpointConnection UpdatePrivateEndpointConnectionStatus(string resourceGroupName, string serviceName, string name, string status, string description = null)
        {
            string url = BuildPrivateEndpointConnectionURL(resourceGroupName, serviceName, name);
            PrivateEndpointConnection privateEndpointConnection = ServiceClient.Operations.GetResouce<PrivateEndpointConnection>(url, _apiVersion);

            privateEndpointConnection.PrivateLinkServiceConnectionState.Status = status;

            if (!string.IsNullOrEmpty(description))
            {
                privateEndpointConnection.PrivateLinkServiceConnectionState.Description = description;
            }

            ServiceClient.Operations.PutResouce<PrivateEndpointConnection>(url, _apiVersion, privateEndpointConnection);

            return GetPrivateEndpointConnection(resourceGroupName, serviceName, name);
        }

        public void DeletePrivateEndpointConnection(string resourceGroupName, string serviceName, string name)
        {
            string url = BuildPrivateEndpointConnectionURL(resourceGroupName, serviceName, name);
            ServiceClient.Operations.DeleteResouce(url, _apiVersion);
        }

        public PSPrivateLinkResource GetPrivateLinkResource(string resourceGroupName, string serviceName, string name)
        {
            string url = BuildPrivateLinkResourceURL(resourceGroupName, serviceName, name);
            PrivateLinkResource resource = ServiceClient.Operations.GetResouce<PrivateLinkResource>(url, _apiVersion);
            return ToPsPrivateLinkResource(resource);
        }

        public List<PSPrivateLinkResource> ListPrivateLinkResource(string resourceGroupName, string serviceName)
        {
            var psPLRs = new List<PSPrivateLinkResource>();
            string url = BuildPrivateLinkResourcesURL(resourceGroupName, serviceName);
            IPage<PrivateLinkResource> list = ServiceClient.Operations.GetResoucePage<Page<PrivateLinkResource>, PrivateLinkResource>(url, _apiVersion);
            foreach (var plr in list)
            {
                var psPlr = ToPsPrivateLinkResource(plr);
                psPLRs.Add(psPlr);
            }
            while (list.NextPageLink != null)
            {
                list = ServiceClient.Operations.GetResoucePage<Page<PrivateLinkResource>, PrivateLinkResource>(list.NextPageLink, null);
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
            return $"/subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_privateLinkResourceType}/{serviceName}/privateLinkResources";
        }

        /// <summary>
        /// /subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_privateLinkResourceType}/{serviceName}/privateLinkResources/{name}
        /// </summary>
        private string BuildPrivateLinkResourceURL(string resourceGroupName, string serviceName, string name)
        {
            return $"/subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_privateLinkResourceType}/{serviceName}/privateLinkResources/{name}";
        }

        /// <summary>
        /// /subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_privateLinkResourceType}/{serviceName}/privateEndpointConnections
        /// </summary>
        private string BuildPrivateEndpointConnectionsURL(string resourceGroupName, string serviceName)
        {
            return $"/subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_privateLinkResourceType}/{serviceName}/privateEndpointConnections";
        }

        /// <summary>
        /// /subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_privateLinkResourceType}/{serviceName}/privateEndpointConnections/{name}
        /// </summary>
        private string BuildPrivateEndpointConnectionURL(string resourceGroupName, string serviceName, string name)
        {
            return $"/subscriptions/{_subscription}/resourceGroups/{resourceGroupName}/providers/{_privateLinkResourceType}/{serviceName}/privateEndpointConnections/{name}";
        }

        private PSPrivateEndpointConnection ToPsPrivateEndpointConnection(PrivateEndpointConnection privateEndpointConnection)
        {
            PSPrivateEndpointConnection psPEC = new PSPrivateEndpointConnection
            {
                Name = privateEndpointConnection.Name,
                Id = privateEndpointConnection.Id,
                ProvisioningState = privateEndpointConnection.ProvisioningState,
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
            psPLR.RequiredMembers = new List<string>(privateLinkResource.Properties.RequiredMembers);
            return psPLR;
        }
        #endregion
    }
}
