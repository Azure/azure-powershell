
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

namespace Microsoft.Azure.Commands.Network
{
    public abstract class ExpressRouteCrossConnectionBaseCmdlet : NetworkBaseCmdlet
    {
        public IExpressRouteCrossConnectionsOperations ExpressRouteCrossConnectionClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.ExpressRouteCrossConnections;
            }
        }

        public PSExpressRouteCrossConnection GetExistingExpressRouteCrossConnection(string resourceGroupName, string name)
        {
            PSExpressRouteCrossConnection crossConnection = null;
            try
            {
                crossConnection = GetExpressRouteCrossConnection(resourceGroupName, name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return null;
                }

                throw;
            }

            return crossConnection;
        }

        public PSExpressRouteCrossConnection GetExpressRouteCrossConnection(string resourceGroupName, string name)
        {
            var crossConnection = this.ExpressRouteCrossConnectionClient.Get(resourceGroupName, name);

            var psExpressRouteCrossConnection = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteCrossConnection>(crossConnection);
            psExpressRouteCrossConnection.ResourceGroupName = resourceGroupName;

            psExpressRouteCrossConnection.Tag =
                TagsConversionHelper.CreateTagHashtable(crossConnection.Tags);

            return psExpressRouteCrossConnection;
        }

        public PSExpressRouteCrossConnection ToPsExpressRouteCrossConnection(Management.Network.Models.ExpressRouteCrossConnection crossConnection)
        {
            var psCrossConnection = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteCrossConnection>(crossConnection);

            psCrossConnection.Tag = TagsConversionHelper.CreateTagHashtable(crossConnection.Tags);

            return psCrossConnection;
        }
    }
}