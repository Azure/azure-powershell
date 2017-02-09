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

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class ServiceFabricVmssCmdletBase : ServiceFabricClusterCmdlet
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

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The node type name")]
        [ValidateNotNullOrEmpty()]
        public string NodeTypeName { get; set; }

        protected bool CheckExistence()
        {
            var vmss = SafeGetResource(() =>
            ComputeClient.VirtualMachineScaleSets.Get(
                this.ResourceGroupName,
                this.NodeTypeName));

            return vmss != null;
        }

        protected PsCluster RemoveNodeTypeToSFRP()
        {
            var cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.ClusterName);
            cluster.NodeTypes.Remove(
                cluster.NodeTypes.SingleOrDefault(
                    c => string.Equals(
                        c.Name,
                        this.NodeTypeName,
                        StringComparison.InvariantCultureIgnoreCase)));

            return SendPatchRequest(new Management.ServiceFabric.Models.ClusterUpdateParameters()
            {
                NodeTypes = cluster.NodeTypes
            });
        }

        public ServiceFabricVmssCmdletBase()
        {
            storageManagementClient = new Lazy<IStorageManagementClient>(() =>
             AzureSession.ClientFactory.CreateArmClient<StorageManagementClient>(
                AzureRmProfileProvider.Instance.Profile.Context,
                AzureEnvironment.Endpoint.ResourceManager));

            networkManagementClient = new Lazy<INetworkManagementClient>(() =>
            AzureSession.ClientFactory.CreateArmClient<NetworkManagementClient>(
               AzureRmProfileProvider.Instance.Profile.Context,
               AzureEnvironment.Endpoint.ResourceManager));
        }
    }
}
