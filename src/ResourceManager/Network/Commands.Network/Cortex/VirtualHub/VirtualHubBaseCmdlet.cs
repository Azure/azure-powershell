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
            //// The following code will throw if resource is not found
            var virtualHub = this.VirtualHubClient.Get(resourceGroupName, name);
            var psVirtualHub = ToPsVirtualHub(virtualHub);
            psVirtualHub.ResourceGroupName = resourceGroupName;

            return psVirtualHub;
        }

        public PSVirtualHub CreateOrUpdateVirtualHub(string resourceGroupName, string virtualHubName, PSVirtualHub virtualHub, Hashtable tags)
        {
            var virtualHubModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualHub>(virtualHub);
            virtualHubModel.Location = virtualHub.Location;
            virtualHubModel.Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true);

            var virtualHubCreatedOrUpdated = this.VirtualHubClient.CreateOrUpdate(resourceGroupName, virtualHubName, virtualHubModel);
            PSVirtualHub hubToReturn = this.ToPsVirtualHub(virtualHubCreatedOrUpdated);
            hubToReturn.ResourceGroupName = resourceGroupName;

            return hubToReturn;
        }

        public List<PSVirtualHub> ListVirtualHubs(string resourceGroupName)
        {
            var virtualHubs = string.IsNullOrWhiteSpace(resourceGroupName) ?
                this.VirtualHubClient.List() :                                       //// List by SubId
                this.VirtualHubClient.ListByResourceGroup(resourceGroupName);        //// List by RG Name

            List<PSVirtualHub> hubsToReturn = new List<PSVirtualHub>();
            if (virtualHubs != null)
            {
                foreach (MNM.VirtualHub virtualHub in virtualHubs)
                {
                    PSVirtualHub virtualHubToReturn = ToPsVirtualHub(virtualHub);
                    virtualHubToReturn.ResourceGroupName = resourceGroupName;
                    hubsToReturn.Add(virtualHubToReturn);
                }
            }

            return hubsToReturn;
        }

        public bool IsVirtualHubPresent(string resourceGroupName, string name)
        {
            try
            {
                GetVirtualHub(resourceGroupName, name);
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
