
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

using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class SecurityPartnerProviderBaseCmdlet : NetworkBaseCmdlet
    {
        public ISecurityPartnerProvidersOperations SecurityPartnerProviderClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.SecurityPartnerProviders;
            }
        }

        protected IVirtualHubsOperations VirtualHubClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualHubs;
            }
        }

        public PSSecurityPartnerProvider GetSecurityPartnerProvider(string resourceGroupName, string name)
        {
            var securityPartnerProvider = this.SecurityPartnerProviderClient.Get(resourceGroupName, name);

            var psSecurityPartnerProvider = NetworkResourceManagerProfile.Mapper.Map<PSSecurityPartnerProvider>(securityPartnerProvider);
           
            psSecurityPartnerProvider.ResourceGroupName = resourceGroupName;
            psSecurityPartnerProvider.Tag = TagsConversionHelper.CreateTagHashtable(securityPartnerProvider.Tags);

            return psSecurityPartnerProvider;
        }

        public PSSecurityPartnerProvider ToPsSecurityPartnerProvider(SecurityPartnerProvider securityPartnerProvider)
        {
            var psSecurityPartnerProvider = NetworkResourceManagerProfile.Mapper.Map<PSSecurityPartnerProvider>(securityPartnerProvider);

            psSecurityPartnerProvider.Tag = TagsConversionHelper.CreateTagHashtable(securityPartnerProvider.Tags);

            return psSecurityPartnerProvider;
        }

        public bool IsSecurityPartnerProviderPresent(string resourceGroupName, string name)
        {
            try
            {
                GetSecurityPartnerProvider(resourceGroupName, name);
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
    }
}
