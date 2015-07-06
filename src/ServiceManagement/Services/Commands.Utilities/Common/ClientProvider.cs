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

using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.Azure.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public class ClientProvider : IClientProvider
    {
        private readonly AzureProfile profile;

        public ClientProvider(AzureProfile azureProfile)
        {
            this.profile = azureProfile;
        }

        ManagementClient IClientProvider.CreateClient()
        {
            return AzureSession.ClientFactory.CreateClient<ManagementClient>(this.profile.Context,
                AzureEnvironment.Endpoint.ServiceManagement);
        }

        ComputeManagementClient IClientProvider.CreateComputeClient()
        {
            return AzureSession.ClientFactory.CreateClient<ComputeManagementClient>(this.profile,
                this.profile.Context.Subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        StorageManagementClient IClientProvider.CreateStorageClient()
        {
            return AzureSession.ClientFactory.CreateClient<StorageManagementClient>(this.profile,
                this.profile.Context.Subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        NetworkManagementClient IClientProvider.CreateNetworkClient()
        {
            return AzureSession.ClientFactory.CreateClient<NetworkManagementClient>(this.profile,
                this.profile.Context.Subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }
    }
}
