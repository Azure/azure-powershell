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
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using System.Net;

    public abstract class CustomIpPrefixBaseCmdlet : NetworkBaseCmdlet
    {
        public ICustomIPPrefixesOperations CustomIpPrefixClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.CustomIPPrefixes;
            }
        }

        public PSCustomIpPrefix GetCustomIpPrefix(string resourceGroupName, string name, string expandResource = null)
        {
            var sdkModel = this.CustomIpPrefixClient.Get(resourceGroupName, name, expandResource);

            var psModel = ToPsCustomIpPrefix(sdkModel);
            psModel.ResourceGroupName = resourceGroupName;

            return psModel;
        }

        public PSCustomIpPrefix ToPsCustomIpPrefix(CustomIpPrefix customIpPrefix)
        {
            var psModel = NetworkResourceManagerProfile.Mapper.Map<PSCustomIpPrefix>(customIpPrefix);

            psModel.Tag = TagsConversionHelper.CreateTagHashtable(customIpPrefix.Tags);

            return psModel;
        }
    }
}
