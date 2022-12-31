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

using Microsoft.Azure.Management.ContainerService.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Aks.Models
{
    public class PSContainerServiceAgentPoolProfile
    {
        /// <summary>
        /// Gets or sets unique name of the node pool profile in the context
        /// of the subscription and resource group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets number of agents (VMs) to host docker containers.
        /// Allowed values must be in the range of 1 to 100 (inclusive). The
        /// default value is 1.
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// Gets or sets size of agent VMs. Possible values include:
        /// 'Standard_A1', 'Standard_A10', 'Standard_A11', 'Standard_A1_v2',
        /// 'Standard_A2', 'Standard_A2_v2', 'Standard_A2m_v2', 'Standard_A3',
        /// 'Standard_A4', 'Standard_A4_v2', 'Standard_A4m_v2', 'Standard_A5',
        /// 'Standard_A6', 'Standard_A7', 'Standard_A8', 'Standard_A8_v2',
        /// 'Standard_A8m_v2', 'Standard_A9', 'Standard_B2ms', 'Standard_B2s',
        /// 'Standard_B4ms', 'Standard_B8ms', 'Standard_D1', 'Standard_D11',
        /// 'Standard_D11_v2', 'Standard_D11_v2_Promo', 'Standard_D12',
        /// 'Standard_D12_v2', 'Standard_D12_v2_Promo', 'Standard_D13',
        /// 'Standard_D13_v2', 'Standard_D13_v2_Promo', 'Standard_D14',
        /// 'Standard_D14_v2', 'Standard_D14_v2_Promo', 'Standard_D15_v2',
        /// 'Standard_D16_v3', 'Standard_D16s_v3', 'Standard_D1_v2',
        /// 'Standard_D2', 'Standard_D2_v2', 'Standard_D2_v2_Promo',
        /// 'Standard_D2_v3', 'Standard_D2s_v3', 'Standard_D3',
        /// 'Standard_D32_v3', 'Standard_D32s_v3', 'Standard_D3_v2',
        /// 'Standard_D3_v2_Promo', 'Standard_D4', 'Standard_D4_v2',
        /// 'Standard_D4_v2_Promo', 'Standard_D4_v3', 'Standard_D4s_v3',
        /// 'Standard_D5_v2', 'Standard_D5_v2_Promo', 'Standard_D64_v3',
        /// 'Standard_D64s_v3', 'Standard_D8_v3', 'Standard_D8s_v3',
        /// 'Standard_DS1', 'Standard_DS11', 'Standard_DS11_v2',
        /// 'Standard_DS11_v2_Promo', 'Standard_DS12', 'Standard_DS12_v2',
        /// 'Standard_DS12_v2_Promo', 'Standard_DS13', 'Standard_DS13-2_v2',
        /// 'Standard_DS13-4_v2', 'Standard_DS13_v2', 'Standard_DS13_v2_Promo',
        /// 'Standard_DS14', 'Standard_DS14-4_v2', 'Standard_DS14-8_v2',
        /// 'Standard_DS14_v2', 'Standard_DS14_v2_Promo', 'Standard_DS15_v2',
        /// 'Standard_DS1_v2', 'Standard_DS2', 'Standard_DS2_v2',
        /// 'Standard_DS2_v2_Promo', 'Standard_DS3', 'Standard_DS3_v2',
        /// 'Standard_DS3_v2_Promo', 'Standard_DS4', 'Standard_DS4_v2',
        /// 'Standard_DS4_v2_Promo', 'Standard_DS5_v2',
        /// 'Standard_DS5_v2_Promo', 'Standard_E16_v3', 'Standard_E16s_v3',
        /// 'Standard_E2_v3', 'Standard_E2s_v3', 'Standard_E32-16s_v3',
        /// 'Standard_E32-8s_v3', 'Standard_E32_v3', 'Standard_E32s_v3',
        /// 'Standard_E4_v3', 'Standard_E4s_v3', 'Standard_E64-16s_v3',
        /// 'Standard_E64-32s_v3', 'Standard_E64_v3', 'Standard_E64s_v3',
        /// 'Standard_E8_v3', 'Standard_E8s_v3', 'Standard_F1', 'Standard_F16',
        /// 'Standard_F16s', 'Standard_F16s_v2', 'Standard_F1s', 'Standard_F2',
        /// 'Standard_F2s', 'Standard_F2s_v2', 'Standard_F32s_v2',
        /// 'Standard_F4', 'Standard_F4s', 'Standard_F4s_v2',
        /// 'Standard_F64s_v2', 'Standard_F72s_v2', 'Standard_F8',
        /// 'Standard_F8s', 'Standard_F8s_v2', 'Standard_G1', 'Standard_G2',
        /// 'Standard_G3', 'Standard_G4', 'Standard_G5', 'Standard_GS1',
        /// 'Standard_GS2', 'Standard_GS3', 'Standard_GS4', 'Standard_GS4-4',
        /// 'Standard_GS4-8', 'Standard_GS5', 'Standard_GS5-16',
        /// 'Standard_GS5-8', 'Standard_H16', 'Standard_H16m',
        /// 'Standard_H16mr', 'Standard_H16r', 'Standard_H8', 'Standard_H8m',
        /// 'Standard_L16s', 'Standard_L32s', 'Standard_L4s', 'Standard_L8s',
        /// 'Standard_M128-32ms', 'Standard_M128-64ms', 'Standard_M128ms',
        /// 'Standard_M128s', 'Standard_M64-16ms', 'Standard_M64-32ms',
        /// 'Standard_M64ms', 'Standard_M64s', 'Standard_NC12',
        /// 'Standard_NC12s_v2', 'Standard_NC12s_v3', 'Standard_NC24',
        /// 'Standard_NC24r', 'Standard_NC24rs_v2', 'Standard_NC24rs_v3',
        /// 'Standard_NC24s_v2', 'Standard_NC24s_v3', 'Standard_NC6',
        /// 'Standard_NC6s_v2', 'Standard_NC6s_v3', 'Standard_ND12s',
        /// 'Standard_ND24rs', 'Standard_ND24s', 'Standard_ND6s',
        /// 'Standard_NV12', 'Standard_NV24', 'Standard_NV6'
        /// </summary>
        public string VmSize { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Managed', 'Ephemeral'
        /// </summary>
        public string OsDiskType { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'OS', 'Temporary'
        /// </summary>
        public string KubeletDiskType { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'OCIContainer', 'WasmWasi'
        /// </summary>
        public string WorkloadRuntime { get; set; }

        /// <summary>
        /// Gets or sets OS Disk Size in GB to be used to specify the disk size
        /// for every machine in this master/node pool. If you specify 0, it
        /// will apply the default osDisk size according to the vmSize
        /// specified.
        /// </summary>
        public int? OsDiskSizeGB { get; set; }

        /// <summary>
        /// Gets or sets vNet SubnetID specifies the VNet's subnet identifier.
        /// </summary>
        public string VnetSubnetID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the subnet which pods will join when
        /// launched.
        /// </summary>
        /// <remarks>
        /// If omitted, pod IPs are statically assigned on the node subnet (see
        /// vnetSubnetID for more details). This is of the form:
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}
        /// </remarks>
        public string PodSubnetID { get; set; }

        /// <summary>
        /// Gets or sets maximum number of pods that can run on a node.
        /// </summary>
        public int? MaxPods { get; set; }

        /// <summary>
        /// Gets or sets osType to be used to specify os type. Choose from
        /// Linux and Windows. Default to Linux. Possible values include:
        /// 'Linux', 'Windows'
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Ubuntu', 'CBLMariner',
        /// 'Windows2019', 'Windows2022'
        /// </summary>
        public string OsSKU { get; set; }

        /// <summary>
        /// Gets or sets maximum number of nodes for auto-scaling
        /// </summary>
        public int? MaxCount { get; set; }

        /// <summary>
        /// Gets or sets minimum number of nodes for auto-scaling
        /// </summary>
        public int? MinCount { get; set; }

        /// <summary>
        /// Gets or sets mode for agent pool System or User
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Gets or sets whether to enable auto-scaler
        /// </summary>
        public bool? EnableAutoScaling { get; set; }

        /// <summary>
        /// Gets or sets the scale down mode to use when scaling the Agent
        /// Pool.
        /// </summary>
        /// <remarks>
        /// This also effects the cluster autoscaler behavior. If not
        /// specified, it defaults to Delete. Possible values include:
        /// 'Delete', 'Deallocate'
        /// </remarks>
        public string ScaleDownMode { get; set; }

        /// <summary>
        /// Gets or sets agentPoolType represents types of an node pool.
        /// Possible values include: 'VirtualMachineScaleSets',
        /// 'AvailabilitySet'
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets version of orchestrator specified when creating the
        /// managed cluster.
        /// </summary>
        public string OrchestratorVersion { get; set; }

        /// <summary>
        /// Gets the version of Kubernetes the Agent Pool is running.
        /// </summary>
        /// <remarks>
        /// If orchestratorVersion is a fully specified version
        /// (major.minor.patch), this field will be exactly equal to it. If
        /// orchestratorVersion is (major.minor), this field will contain the
        /// full (major.minor.patch) version being used.
        /// </remarks>
        public string CurrentOrchestratorVersion { get; private set; }

        /// <summary>
        /// Gets the version of node image
        /// </summary>
        public string NodeImageVersion { get; private set; }

        /// <summary>
        /// Gets or sets settings for upgrading the agentpool
        /// </summary>
        public AgentPoolUpgradeSettings UpgradeSettings { get; set; }

        /// <summary>
        /// Gets the current deployment or provisioning state, which only
        /// appears in the response.
        /// </summary>
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets or sets whether the Agent Pool is running or stopped.
        /// </summary>
        /// <remarks>
        /// When an Agent Pool is first created it is initially Running. The
        /// Agent Pool can be stopped by setting this field to Stopped. A
        /// stopped Agent Pool stops all of its VMs and does not accrue billing
        /// charges. An Agent Pool can only be stopped if it is Running and
        /// provisioning state is Succeeded
        /// </remarks>
        public PowerState PowerState { get; set; }

        /// <summary>
        /// Gets or sets (PREVIEW) Availability zones for nodes. Must use
        /// VirtualMachineScaleSets AgentPoolType.
        /// </summary>
        public IList<string> AvailabilityZones { get; set; }

        /// <summary>
        /// Gets or sets enable public IP for nodes
        /// </summary>
        public bool? EnableNodePublicIP { get; set; }

        /// <summary>
        /// Gets or sets the public IP prefix ID which VM nodes should use IPs
        /// from.
        /// </summary>
        /// <remarks>
        /// This is of the form:
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes/{publicIPPrefixName}
        /// </remarks>
        public string NodePublicIPPrefixID { get; set; }

        /// <summary>
        /// Gets or sets scaleSetPriority to be used to specify virtual machine
        /// scale set priority. Default to regular. Possible values include:
        /// 'Low', 'Regular'
        /// </summary>
        public string ScaleSetPriority { get; set; }

        /// <summary>
        /// Gets or sets scaleSetEvictionPolicy to be used to specify eviction
        /// policy for low priority virtual machine scale set. Default to
        /// Delete. Possible values include: 'Delete', 'Deallocate'
        /// </summary>
        public string ScaleSetEvictionPolicy { get; set; }

        /// <summary>
        /// Gets or sets the max price (in US Dollars) you are willing to pay
        /// for spot instances. Possible values are any decimal value greater
        /// than zero or -1 which indicates default price to be up-to
        /// on-demand.
        /// </summary>
        /// <remarks>
        /// Possible values are any decimal value greater than zero or -1 which
        /// indicates the willingness to pay any on-demand price. For more
        /// details on spot pricing, see [spot VMs
        /// pricing](https://docs.microsoft.com/azure/virtual-machines/spot-vms#pricing)
        /// </remarks>
        public double? SpotMaxPrice { get; set; }

        /// <summary>
        /// Gets or sets the tags to be persisted on the agent pool virtual
        /// machine scale set.
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the node labels to be persisted across all nodes in
        /// agent pool.
        /// </summary>
        public IDictionary<string, string> NodeLabels { get; set; }

        /// <summary>
        /// Gets or sets taints added to new nodes during node pool create and
        /// scale. For example, key=value:NoSchedule.
        /// </summary>
        public IList<string> NodeTaints { get; set; }

        /// <summary>
        /// Gets or sets the ID for Proximity Placement Group.
        /// </summary>
        public string ProximityPlacementGroupID { get; set; }

        /// <summary>
        /// Gets or sets the Kubelet configuration on the agent pool nodes.
        /// </summary>
        public KubeletConfig KubeletConfig { get; set; }

        /// <summary>
        /// Gets or sets the OS configuration of Linux agent nodes.
        /// </summary>
        public LinuxOSConfig LinuxOSConfig { get; set; }

        /// <summary>
        /// Gets or sets whether to enable host based OS and data drive
        /// encryption.
        /// </summary>
        /// <remarks>
        /// This is only supported on certain VM sizes and in certain Azure
        /// regions. For more information, see:
        /// https://docs.microsoft.com/azure/aks/enable-host-encryption
        /// </remarks>
        public bool? EnableEncryptionAtHost { get; set; }

        /// <summary>
        /// Gets or sets whether to enable UltraSSD
        /// </summary>
        public bool? EnableUltraSSD { get; set; }

        /// <summary>
        /// Gets or sets whether to use a FIPS-enabled OS.
        /// </summary>
        /// <remarks>
        /// See [Add a FIPS-enabled node
        /// pool](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#add-a-fips-enabled-node-pool-preview)
        /// for more details.
        /// </remarks>
        public bool? EnableFIPS { get; set; }

        /// <summary>
        /// Gets or sets gPUInstanceProfile to be used to specify GPU MIG
        /// instance profile for supported GPU VM SKU. Possible values include:
        /// 'MIG1g', 'MIG2g', 'MIG3g', 'MIG4g', 'MIG7g'
        /// </summary>
        public string GpuInstanceProfile { get; set; }

        /// <summary>
        /// Gets or sets creationData to be used to specify the source Snapshot
        /// ID if the node pool will be created/upgraded using a snapshot.
        /// </summary>
        public CreationData CreationData { get; set; }

        /// <summary>
        /// Gets or sets the fully qualified resource ID of the Dedicated Host
        /// Group to provision virtual machines from, used only in creation
        /// scenario and not allowed to changed once set.
        /// </summary>
        /// <remarks>
        /// This is of the form:
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}.
        /// For more information see [Azure dedicated
        /// hosts](https://docs.microsoft.com/azure/virtual-machines/dedicated-hosts).
        /// </remarks>
        public string HostGroupID { get; set; }

        //The following properties are added back to avoid breaking change, but they'er useless.

        /// <summary>
        /// Gets or sets DNS prefix to be used to create the FQDN for the agent
        /// pool.
        /// </summary>
        public string DnsPrefix { get; set; }

        /// <summary>
        /// Gets FDQN for the agent pool.
        /// </summary>
        public string Fqdn { get; private set; }

        /// <summary>
        /// Gets or sets ports number array used to expose on this agent pool.
        /// The default opened ports are different based on your choice of
        /// orchestrator.
        /// </summary>
        public IList<int?> Ports { get; set; }

        /// <summary>
        /// Gets or sets storage profile specifies what kind of storage used.
        /// Choose from StorageAccount and ManagedDisks. Leave it empty, we
        /// will choose for you based on the orchestrator choice. Possible
        /// values include: 'StorageAccount', 'ManagedDisks'
        /// </summary>
        public string StorageProfile { get; set; }
    }
}
