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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Net;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class VerifierWorkspaceBaseCmdlet : NetworkBaseCmdlet
    {
        public IVerifierWorkspacesOperations VerifierWorkspaceClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VerifierWorkspaces;
            }
        }

        public bool IsVerifierWorkspacePresent(string resourceGroupName, string networkManagerName, string workspaceName)
        {
            try
            {
                GetVerifierWorkspace(resourceGroupName, networkManagerName, workspaceName);
            }
            catch (Microsoft.Azure.Management.Network.Models.CommonErrorResponseException exception)
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


        public PSVerifierWorkspace GetVerifierWorkspace(string resourceGroupName, string networkManagerName, string workspaceName)
        {
            var verifierWorkspace = this.VerifierWorkspaceClient.Get(resourceGroupName, networkManagerName, workspaceName);
            var psVerifierWorkspace = ToPsVerifierWorkspace(verifierWorkspace);
            psVerifierWorkspace.Tags = verifierWorkspace.Tags;
            psVerifierWorkspace.ResourceGroupName = resourceGroupName;
            psVerifierWorkspace.NetworkManagerName = networkManagerName;
            return psVerifierWorkspace;
        }

        public PSVerifierWorkspace ToPsVerifierWorkspace(Management.Network.Models.VerifierWorkspace verifierWorkspace)
        {
            var psVerifierWorkspace = NetworkResourceManagerProfile.Mapper.Map<PSVerifierWorkspace>(verifierWorkspace);
            return psVerifierWorkspace;
        }
    }
}