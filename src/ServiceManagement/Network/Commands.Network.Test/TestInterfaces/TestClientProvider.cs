using System;
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

using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.TestInterfaces
{
    public class TestClientProvider : IClientProvider
    {
        private readonly ManagementClient managementClient;

        private readonly ComputeManagementClient computeManagementClient;

        private readonly StorageManagementClient storageManagementClient;

        private readonly NetworkManagementClient networkManagementClient;

        public TestClientProvider(ManagementClient mgmtClient, ComputeManagementClient computeClient,
            StorageManagementClient storageClient, NetworkManagementClient networkClient)
        {
            this.managementClient = mgmtClient;
            this.computeManagementClient = computeClient;
            this.storageManagementClient = storageClient;
            this.networkManagementClient = networkClient;
        }

        public ManagementClient CreateClient()
        {
            return managementClient;
        }

        public ComputeManagementClient CreateComputeClient()
        {
            return computeManagementClient;
        }

        public StorageManagementClient CreateStorageClient()
        {
            return storageManagementClient;
        }

        public NetworkManagementClient CreateNetworkClient()
        {
            return networkManagementClient;
        }
    }
}
