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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections.Generic;
using System.Net;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class NetworkWatcherBaseCmdlet : NetworkBaseCmdlet
    {
        public INetworkWatchersOperations NetworkWatcherClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.NetworkWatchers;
            }
        }

        public bool IsNetworkWatcherPresent(string resourceGroupName, string name)
        {
            try
            {
                GetNetworkWatcher(resourceGroupName, name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSNetworkWatcher GetNetworkWatcher(string resourceGroupName, string name, string expandResource = null)
        {
            MNM.NetworkWatcher networkWatcher = this.NetworkWatcherClient.Get(resourceGroupName, name);

            PSNetworkWatcher psNetworkWatcher = ToPsNetworkWatcher(networkWatcher);
            psNetworkWatcher.ResourceGroupName = resourceGroupName;

            return psNetworkWatcher;
        }

        public PSNetworkWatcher ToPsNetworkWatcher(MNM.NetworkWatcher networkWatcher)
        {
            var psNetworkWatcher = NetworkResourceManagerProfile.Mapper.Map<PSNetworkWatcher>(networkWatcher);
            psNetworkWatcher.Tag =
                TagsConversionHelper.CreateTagHashtable(networkWatcher.Tags);

            return psNetworkWatcher;
        }

        public PSNetworkWatcher GetNetworkWatcherByLocation(string location)
        {
            var nwList = this.NetworkClient.NetworkManagementClient.NetworkWatchers.ListAll();
            foreach (var nw in nwList)
            {
                if (nw.Location == location)
                {
                    PSNetworkWatcher psNetworkWatcher = ToPsNetworkWatcher(nw);
                    psNetworkWatcher.ResourceGroupName = this.GetResourceGroupNameFromResourceId(nw.Id);
                    return psNetworkWatcher;
                }
            }

            return null;
        }

        public string GetResourceGroupNameFromResourceId(string resourceId)
        {
            ResourceIdentifier resourceInfo = new ResourceIdentifier(resourceId);
            return resourceInfo.ResourceGroupName;
        }
    }
}