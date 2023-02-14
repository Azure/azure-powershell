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
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using System.Net;

    public abstract class PublicIpPrefixBaseCmdlet : NetworkBaseCmdlet
    {
        public IPublicIPPrefixesOperations PublicIpPrefixClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.PublicIPPrefixes;
            }
        }

        public bool IsPublicIpPrefixPresent(string resourceGroupName, string name)
        {
            try
            {
                GetPublicIpPrefix(resourceGroupName, name);
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

        public PSPublicIpPrefix GetPublicIpPrefix(string resourceGroupName, string name, string expandResource = null)
        {
            var publicIPPrefix = this.PublicIpPrefixClient.Get(resourceGroupName, name, expandResource);

            var psPublicIpPrefix = ToPsPublicIpPrefix(publicIPPrefix);
            psPublicIpPrefix.ResourceGroupName = resourceGroupName;

            return psPublicIpPrefix;
        }

        public PSPublicIpPrefix ToPsPublicIpPrefix(PublicIPPrefix publicIpPrefix)
        {
            var psPublicIpPrefix = NetworkResourceManagerProfile.Mapper.Map<PSPublicIpPrefix>(publicIpPrefix);

            psPublicIpPrefix.Tag = TagsConversionHelper.CreateTagHashtable(publicIpPrefix.Tags);

            if (string.IsNullOrEmpty(psPublicIpPrefix.IPPrefix))
            {
                psPublicIpPrefix.IPPrefix = "Not Assigned";
            }
            return psPublicIpPrefix;
        }
    }
}
