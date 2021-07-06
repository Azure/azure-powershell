// ----------------------------------------------------------------------------------
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
using System.Collections;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabricManagedClusters;
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedNodeType", SupportsShouldProcess = true), OutputType(typeof(PSManagedNodeType))]
    public class NewAzServiceFabricManagedNodeType : ServiceFabricManagedCmdletBase
    {
        #region Params

        #region Common params

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the node type.")]
        [ValidateNotNullOrEmpty()]
        [Alias("NodeTypeName")]
        public string Name { get; set; }

        #endregion

        [Parameter(Mandatory = true, HelpMessage = "The number of nodes in the node type.")]
        public int InstanceCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specify if the node type is primary. On this node type will run system services. Only one node type should be marked as primary. Primary node type cannot be deleted or changed for existing clusters.")]
        public SwitchParameter Primary { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "Disk size for each vm in the node type in GBs. Default 100.")]
        [Alias("DataDiskSize")]
        public int DiskSize { get; set; } = 100;

        [Parameter(Mandatory = false, HelpMessage = "Managed data disk type. IOPS and throughput are given by the disk size, to see more information go to https://docs.microsoft.com/en-us/azure/virtual-machines/disks-types. Default StandardSSD_LRS")]
        [Alias("DataDiskType")]
        public PSDiskType DiskType { get; set; } = PSDiskType.StandardSSD_LRS;

        [Parameter(Mandatory = false, HelpMessage = "Application start port of a range of ports.")]
        public int? ApplicationStartPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Application End port of a range of ports.")]
        public int? ApplicationEndPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Ephemeral start port of a range of ports.")]
        public int? EphemeralStartPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Ephemeral end port of a range of ports.")]
        public int? EphemeralEndPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The size of virtual machines in the pool. All virtual machines in a pool are the same size. Default: Standard_D2_v2.")]
        public string VmSize { get; set; } = "Standard_D2_v2";

        [Parameter(Mandatory = false, HelpMessage = "The publisher of the Azure Virtual Machines Marketplace image. Default: MicrosoftWindowsServer.")]
        public string VmImagePublisher { get; set; } = "MicrosoftWindowsServer";

        [Parameter(Mandatory = false, HelpMessage = "The offer type of the Azure Virtual Machines Marketplace image. Default: WindowsServer.")]
        public string VmImageOffer { get; set; } = "WindowsServer";

        [Parameter(Mandatory = false, HelpMessage = "The SKU of the Azure Virtual Machines Marketplace image. Default: 2019-Datacenter.")]
        public string VmImageSku { get; set; } = "2019-Datacenter";

        [Parameter(Mandatory = false, HelpMessage = "The version of the Azure Virtual Machines Marketplace image. Default: latest.")]
        public string VmImageVersion { get; set; } = "latest";

        [Parameter(Mandatory = false, HelpMessage = "Capacity tags applied to the nodes in the node type as key/value pairs, the cluster resource manager uses these tags to understand how much resource a node has. Updating this will override the current values.")]
        public Hashtable Capacity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Placement tags applied to nodes in the node type as key/value pairs, which can be used to indicate where certain services (workload) should run. Updating this will override the current values.")]
        public Hashtable PlacementProperty { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The list of user assigned identities associated with the virtual machine scale set under the node type. Each entry will be an ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'. Follow steps to create the identity and add the role assignment with Service Fabric Resource Provider beforehand here: https://docs.microsoft.com/en-us/azure/service-fabric/how-to-managed-identity-managed-cluster-virtual-machine-scale-sets")]
        public string[] VmUserAssignedIdentity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates if the node type can only host Stateless workloads.")]
        public SwitchParameter IsStateless { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates if scale set associated with the node type can be composed of multiple placement groups.")]
        public SwitchParameter MultiplePlacementGroup { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.Name, action: string.Format("Create new node type {0} in cluster: {1}", this.Name, this.ClusterName)))
            {
                try
                {
                    NodeType nodeType = SafeGetResource(() => this.SfrpMcClient.NodeTypes.Get(this.ResourceGroupName, this.ClusterName, this.Name));
                    if (nodeType != null)
                    {
                        WriteError(new ErrorRecord(new InvalidOperationException(string.Format("Node type '{0}' already exists.", this.Name)),
                            "ResourceAlreadyExists", ErrorCategory.InvalidOperation, null));
                    }
                    else
                    {
                        NodeType newNodeTypeParams = this.GetNewNodeTypeParameters();
                        var beginRequestResponse = this.SfrpMcClient.NodeTypes.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ClusterName, this.Name, newNodeTypeParams)
                            .GetAwaiter().GetResult();

                        nodeType = this.PollLongRunningOperation(beginRequestResponse);

                        WriteObject(new PSManagedNodeType(nodeType), false);
                    }
                }
                catch (Exception ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }

        private NodeType GetNewNodeTypeParameters()
        {
            var newNodeType = new NodeType(
                isPrimary: this.Primary.IsPresent,
                vmInstanceCount: this.InstanceCount,
                dataDiskSizeGB: this.DiskSize,
                dataDiskType: this.DiskType.ToString(),
                name: this.Name,
                vmSize: this.VmSize,
                vmImagePublisher: this.VmImagePublisher,
                vmImageOffer: this.VmImageOffer,
                vmImageSku: this.VmImageSku,
                vmImageVersion: this.VmImageVersion,
                isStateless: this.IsStateless.IsPresent
            );

            if (this.ApplicationStartPort.HasValue && this.ApplicationEndPort.HasValue)
            {
                newNodeType.ApplicationPorts = new EndpointRangeDescription(this.ApplicationStartPort.Value, this.ApplicationEndPort.Value);
            }

            if (this.EphemeralStartPort.HasValue && this.EphemeralEndPort.HasValue)
            {
                newNodeType.EphemeralPorts = new EndpointRangeDescription(this.EphemeralStartPort.Value, this.EphemeralEndPort.Value);
            }

            if (this.Capacity != null)
            {
                newNodeType.Capacities = this.Capacity.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string);
            }

            if (this.PlacementProperty != null)
            {
                newNodeType.PlacementProperties = this.PlacementProperty.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string);
            }

            if (this.VmUserAssignedIdentity != null && this.VmUserAssignedIdentity.Length > 0)
            {
                newNodeType.VmManagedIdentity = new VmManagedIdentity(userAssignedIdentities: this.VmUserAssignedIdentity);
            }

            if (this.MultiplePlacementGroup.IsPresent)
            {
                newNodeType.MultiplePlacementGroups = this.MultiplePlacementGroup.IsPresent;
            }

            return newNodeType;
        }
    }
}
