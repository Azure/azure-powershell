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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.Storage;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class ServiceFabricNodeTypeCmdletBase : ServiceFabricClusterCmdlet
    {
        protected Lazy<IStorageManagementClient> storageManagementClient;
        protected Lazy<INetworkManagementClient> networkManagementClient;

        public IStorageManagementClient StorageManagementClient
        {
            get { return storageManagementClient.Value; }
        }

        public INetworkManagementClient NetworkManagementClient
        {
            get { return networkManagementClient.Value; }
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
                   HelpMessage = "The node type name")]
        [ValidateNotNullOrEmpty()]
        public virtual string NodeType { get; set; }

        public ServiceFabricNodeTypeCmdletBase()
        {
            storageManagementClient = new Lazy<IStorageManagementClient>(() =>
             AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(
                DefaultContext,
                AzureEnvironment.Endpoint.ResourceManager));

            networkManagementClient = new Lazy<INetworkManagementClient>(() =>
            AzureSession.Instance.ClientFactory.CreateArmClient<NetworkManagementClient>(
               DefaultContext,
               AzureEnvironment.Endpoint.ResourceManager));
        }

        protected bool VmssExists()
        {
            var vmss = SafeGetResource(
                () =>
                ComputeClient.VirtualMachineScaleSets.Get( 
                    this.ResourceGroupName,     
                    this.NodeType),
                false);

            return vmss != null;
        }
    }
}
