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
using Microsoft.Azure.Management.Network.Models;
using System.Net;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class PrivateLinkServiceBaseCmdlet : NetworkBaseCmdlet
    {
        public IPrivateLinkServicesOperations PrivateLinkServiceClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.PrivateLinkServices;
            }
        }

        public bool IsPrivateLinkServicePresent(string resourceGroupName, string name)
        {
            try
            {
                GetPrivateLinkService(resourceGroupName, name);
            }
            catch (ErrorException exception)
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

        public PSPrivateLinkService GetPrivateLinkService(string resourceGroupName, string name, string expandResource = null)
        {
            var privateLinkService = this.PrivateLinkServiceClient.Get(resourceGroupName, name, expandResource);

            var psPrivateLinkService = ToPsPrivateLinkService(privateLinkService);
            psPrivateLinkService.ResourceGroupName = resourceGroupName;
            psPrivateLinkService.Tag = TagsConversionHelper.CreateTagHashtable(privateLinkService.Tags);

            return psPrivateLinkService;
        }

        public PSPrivateLinkService ToPsPrivateLinkService(Microsoft.Azure.Management.Network.Models.PrivateLinkService privateLinkService)
        {
            var psPrivateLinkService = NetworkResourceManagerProfile.Mapper.Map<PSPrivateLinkService>(privateLinkService);
            psPrivateLinkService.Tag = TagsConversionHelper.CreateTagHashtable(privateLinkService.Tags);
            return psPrivateLinkService;
        }
    }
}
