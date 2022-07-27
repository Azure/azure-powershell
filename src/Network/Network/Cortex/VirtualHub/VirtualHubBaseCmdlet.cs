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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net;
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class VirtualHubBaseCmdlet : NetworkBaseCmdlet
    {
        private HubVnetConnectionBaseCmdlet hubVnetConnectionBaseCmdlet;

        public HubVnetConnectionBaseCmdlet HubVnetConnectionCmdlet
        {
            get
            {
                if (hubVnetConnectionBaseCmdlet == null)
                {
                    hubVnetConnectionBaseCmdlet = new HubVnetConnectionBaseCmdlet();
                }
                return hubVnetConnectionBaseCmdlet;
            }
        }

        public IVirtualHubsOperations VirtualHubClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualHubs;
            }
        }

        public PSVirtualHub ToPsVirtualHub(Management.Network.Models.VirtualHub virtualHub)
        {
            var psVirtualHub = NetworkResourceManagerProfile.Mapper.Map<PSVirtualHub>(virtualHub);
            
            psVirtualHub.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);

            return psVirtualHub;
        }

        public PSVirtualHub GetVirtualHub(string resourceGroupName, string name)
        {
            try
            {
                //// The following code will throw if resource is not found
                MNM.VirtualHub virtualHub = this.VirtualHubClient.Get(resourceGroupName, name);
                PSVirtualHub psVirtualHub = ToPsVirtualHub(virtualHub);
                psVirtualHub.ResourceGroupName = resourceGroupName;
                psVirtualHub.VirtualNetworkConnections = this.HubVnetConnectionCmdlet.ListHubVnetConnections(resourceGroupName, name);

                return psVirtualHub;
            }
            catch (Exception ex)
            {
                if (ex is Microsoft.Azure.Management.Network.Models.ErrorException || ex is Rest.Azure.CloudException)
                {
                    return null;
                }
                throw;
            }
        }

        public bool IsVirtualHubPresent(string resourceGroupName, string name)
        {
            PSVirtualHub psVirtualHub = GetVirtualHub(resourceGroupName, name);

            return psVirtualHub == null ? false : true;
        }

        public PSVirtualHub CreateOrUpdateVirtualHub(string resourceGroupName, string virtualHubName, PSVirtualHub virtualHub, Hashtable tags, Dictionary<string, List<string>> customHeaders = null)
        {
            var psHubVnetConnections = virtualHub.VirtualNetworkConnections;
            virtualHub.VirtualNetworkConnections = null;
            var virtualHubModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualHub>(virtualHub);
            virtualHubModel.Location = virtualHub.Location;
            virtualHubModel.Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true);
            MNM.VirtualHub virtualHubCreatedOrUpdated;

            if (customHeaders == null)
            {
                virtualHubCreatedOrUpdated = this.VirtualHubClient.CreateOrUpdate(resourceGroupName, virtualHubName, virtualHubModel);
            }
            else
            {
                // Execute the create call and pass the custom headers. 
                using (var _result = this.VirtualHubClient.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, virtualHubName, virtualHubModel, customHeaders).GetAwaiter().GetResult())
                {
                    virtualHubCreatedOrUpdated = _result.Body;
                }
            }

            PSVirtualHub hubToReturn = this.ToPsVirtualHub(virtualHubCreatedOrUpdated);
            hubToReturn.ResourceGroupName = resourceGroupName;

            if (psHubVnetConnections == null)
            {
                return hubToReturn;
            }

            // Crud operation on the vnet connections
            hubToReturn.VirtualNetworkConnections = new List<PSHubVirtualNetworkConnection>();

            foreach (var psConnection in psHubVnetConnections)
            {
                var hubVnetConnnection = NetworkResourceManagerProfile.Mapper.Map<MNM.HubVirtualNetworkConnection>(psConnection);
                // get auth headers for cross-tenant hubvnet conn
                List<string> resourceIds = new List<string>();
                resourceIds.Add(psConnection.RemoteVirtualNetwork.Id);

                var auxHeaderDictionary = GetAuxilaryAuthHeaderFromResourceIds(resourceIds);
                Dictionary<string, List<string>> auxAuthHeader = null;
                if (auxHeaderDictionary != null && auxHeaderDictionary.Count > 0)
                {
                    auxAuthHeader = new Dictionary<string, List<string>>(auxHeaderDictionary);
                }

                var psConnectionReturn = this.HubVnetConnectionCmdlet.CreateOrUpdateHubVirtualNetworkConnection(resourceGroupName, virtualHubName, psConnection.Name, hubVnetConnnection, customHeaders);
                hubToReturn.VirtualNetworkConnections.Add(psConnectionReturn);
            }

            return hubToReturn;
        }

        public List<PSVirtualHub> ListVirtualHubs(string resourceGroupName)
        {
            var virtualHubs = ShouldListBySubscription(resourceGroupName, null) ?
                this.VirtualHubClient.List() :                                       //// List by SubId
                this.VirtualHubClient.ListByResourceGroup(resourceGroupName);        //// List by RG Name

            List<PSVirtualHub> hubsToReturn = new List<PSVirtualHub>();
            if (virtualHubs != null)
            {
                foreach (MNM.VirtualHub virtualHub in virtualHubs)
                {
                    PSVirtualHub virtualHubToReturn = ToPsVirtualHub(virtualHub);
                    virtualHubToReturn.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(virtualHub.Id);
                    virtualHubToReturn.VirtualNetworkConnections = this.HubVnetConnectionCmdlet.ListHubVnetConnections(resourceGroupName, virtualHub.Name);

                    hubsToReturn.Add(virtualHubToReturn);
                }
            }

            return hubsToReturn;
        }
    }
}
