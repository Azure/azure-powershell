
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
using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class IpGroupBaseCmdlet : NetworkBaseCmdlet
    {
        public IIpGroupsOperations IpGroupsClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.IpGroups;
            }
        }

        public bool IsIpGroupsPresent(string resourceGroupName, string name)
        {
            try
            {
                GetIpGroup(resourceGroupName, name);
            }
            catch (Exception ex)
            {
                if (ex is Microsoft.Azure.Management.Network.Models.ErrorException || ex is Rest.Azure.CloudException)
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSIpGroup GetIpGroup(string resourceGroupName, string name)
        {
            var ipGroups = this.IpGroupsClient.Get(resourceGroupName, name);

            var psIpGroup = NetworkResourceManagerProfile.Mapper.Map<PSIpGroup>(ipGroups);
            psIpGroup.ResourceGroupName = resourceGroupName;
            psIpGroup.Tag = TagsConversionHelper.CreateTagHashtable(ipGroups.Tags);

            return psIpGroup;
        }

        public PSIpGroup ToPSIpGroup(IpGroup ipGroups)
        {
            var psIpGroup = NetworkResourceManagerProfile.Mapper.Map<PSIpGroup>(ipGroups);

            psIpGroup.Tag = TagsConversionHelper.CreateTagHashtable(ipGroups.Tags);

            return psIpGroup;
        }
    }
}
