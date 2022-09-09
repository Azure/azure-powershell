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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Net;
using Microsoft.Azure.Management.Network.Models;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class NetworkManagerBaseCmdlet : NetworkBaseCmdlet
    {
        public INetworkManagersOperations NetworkManagerClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.NetworkManagers;
            }
        }

        public INetworkManagerCommitsOperations NetworkManagerCommitClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.NetworkManagerCommits;
            }
        }

        public bool IsNetworkManagerPresent(string resourceGroupName, string name)
        {
            try
            {
                GetNetworkManager(resourceGroupName, name);
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

        public PSNetworkManagerCommit PostNetworkManagerCommit(string resourceGroupName, string name, List<string> targetLocations, List<string> configurationIds, string commitType)
        {
            NetworkManagerCommit commit = new NetworkManagerCommit();
            commit.CommitType = commitType;
            commit.ConfigurationIds = configurationIds;
            commit.TargetLocations = targetLocations;
            var commitResponse = this.NetworkManagerCommitClient.Post(commit, resourceGroupName, name);
            var psNetworkManagerCommit = NetworkResourceManagerProfile.Mapper.Map<PSNetworkManagerCommit>(commitResponse);
            return psNetworkManagerCommit;
        }


        public PSNetworkManager GetNetworkManager(string resourceGroupName, string name)
        {
            var networkManager = this.NetworkManagerClient.Get(resourceGroupName, name);
            var psNetworkManager = NetworkResourceManagerProfile.Mapper.Map<PSNetworkManager>(networkManager);
            psNetworkManager.Tag = TagsConversionHelper.CreateTagHashtable(networkManager.Tags);
            psNetworkManager.ResourceGroupName = resourceGroupName;
            return psNetworkManager;
        }

        // Temporary - to be removed
        public void NullifyNetworkManagerIfAbsent(Management.Network.Models.NetworkManager networkManager)
        {
            if (networkManager == null)
            {
                return;
            }
        }

        public PSNetworkManager ToPsNetworkManager(Management.Network.Models.NetworkManager networkManager)
        {
            var psNetworkManager = NetworkResourceManagerProfile.Mapper.Map<PSNetworkManager>(networkManager);
            psNetworkManager.Tag = TagsConversionHelper.CreateTagHashtable(networkManager.Tags);

            return psNetworkManager;
        }
    }
}