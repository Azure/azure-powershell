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

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Models;
    using Microsoft.WindowsAzure.Management;
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Storage;

    public class ClientProvider : IClientProvider
    {
        private readonly ServiceManagementBaseCmdlet svcMgmtBaseCmdlet;

        public ClientProvider(ServiceManagementBaseCmdlet baseCmdlet)
        {
            this.svcMgmtBaseCmdlet = baseCmdlet;
        }

        ManagementClient IClientProvider.CreateClient()
        {
            return AzureSession.ClientFactory.CreateClient<ManagementClient>(this.svcMgmtBaseCmdlet.Profile.Context,
                AzureEnvironment.Endpoint.ServiceManagement);
        }

        ComputeManagementClient IClientProvider.CreateComputeClient()
        {
            return AzureSession.ClientFactory.CreateClient<ComputeManagementClient>(this.svcMgmtBaseCmdlet.Profile,
                this.svcMgmtBaseCmdlet.Profile.Context.Subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        StorageManagementClient IClientProvider.CreateStorageClient()
        {
            return AzureSession.ClientFactory.CreateClient<StorageManagementClient>(this.svcMgmtBaseCmdlet.Profile,
                this.svcMgmtBaseCmdlet.Profile.Context.Subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        NetworkManagementClient IClientProvider.CreateNetworkClient()
        {
            return AzureSession.ClientFactory.CreateClient<NetworkManagementClient>(this.svcMgmtBaseCmdlet.Profile,
                this.svcMgmtBaseCmdlet.Profile.Context.Subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }
    }
}
