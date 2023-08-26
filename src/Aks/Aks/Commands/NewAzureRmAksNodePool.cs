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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Aks
{
    [Cmdlet("New", AzureRMConstants.AzureRMPrefix + Constants.NodePool, SupportsShouldProcess = true)]
    [OutputType(typeof(PSNodePool))]
    public class NewAzureRmAksNodePool : NewOrUpdateAgentPoolBase
    {
        [Parameter(Mandatory = true, ParameterSetName = Constants.DefaultParameterSet, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = Constants.DefaultParameterSet, HelpMessage = "The name of the managed cluster resource.")]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = Constants.DefaultParameterSet, HelpMessage = "The name of the node pool.")]
        [Parameter(Mandatory = true, ParameterSetName = Constants.ParentObjectParameterSet, HelpMessage = "The name of the node pool.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = Constants.ParentObjectParameterSet, ValueFromPipeline = true, HelpMessage = "Specify cluster object in which to create node pool.")]
        public PSKubernetesCluster ClusterObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The default number of nodes for the node pools.")]
        public int Count { get; set; } = 3;

        [Parameter(Mandatory = false, HelpMessage = "The default number of nodes for the node pools.")]
        public int OsDiskSize { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The size of the Virtual Machine. Default value is Standard_D2_v2.")]
        public string VmSize { get; set; } = "Standard_D2_v2";

        [Parameter(Mandatory = false, HelpMessage = "VNet SubnetID specifies the VNet's subnet identifier.")]
        public string VnetSubnetID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Maximum number of pods that can run on node.")]
        public int MaxPodCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.")]
        [PSArgumentCompleter("Linux", "Windows")]
        public string OsType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "OsSKU to be used to specify OS SKU. The default is Ubuntu if OSType is Linux. The default is Windows2019 when Kubernetes <= 1.24 or Windows2022 when Kubernetes >= 1.25 if OSType is Windows.")]
        [PSArgumentCompleter("Ubuntu", "CBLMariner", "AzureLinux", "Windows2019", "Windows2022")]
        public string OsSKU { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to enable public IP for nodes.")]
        public SwitchParameter EnableNodePublicIp { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The resource Id of public IP prefix for node pool.")]
        public string NodePublicIPPrefixID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "ScaleSetPriority to be used to specify virtual machine scale set priority. Default to regular.")]

        [PSArgumentCompleter("Low", "Regular", "Spot")]
        public string ScaleSetPriority { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "ScaleSetEvictionPolicy to be used to specify eviction policy for low priority virtual machine scale set. Default to Delete.")]
        [PSArgumentCompleter("Delete", "Deallocate")]
        public string ScaleSetEvictionPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Represents types of an node pool. Possible values include: 'VirtualMachineScaleSets', 'AvailabilitySet'")]
        [PSArgumentCompleter("AvailabilitySet", "VirtualMachineScaleSets")]
        public string VmSetType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Availability zones for nodes. Must use VirtualMachineScaleSets AgentPoolType.")]
        public string[] AvailabilityZone { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Create node pool even if it already exists")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to enable host based OS and data drive")]
        public SwitchParameter EnableEncryptionAtHost { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "whether to enable UltraSSD")]
        public SwitchParameter EnableUltraSSD { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The OS configuration of Linux agent nodes.")]
        public LinuxOSConfig LinuxOSConfig { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The Kubelet configuration on the agent pool nodes.")]
        public KubeletConfig KubeletConfig { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The maximum number or percentage of nodes that ar surged during upgrade.")]
        public string MaxSurge { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The ID for Proximity Placement Group.")]
        public string PPG { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The max price (in US Dollars) you are willing to pay for spot instances. Possible values are any decimal value greater than zero or -1 which indicates default price to be up-to on-demand.")]
        public double? SpotMaxPrice { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to use a FIPS-enabled OS")]
        public SwitchParameter EnableFIPS { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The GpuInstanceProfile to be used to specify GPU MIG instance profile for supported GPU VM SKU.")]
        [PSArgumentCompleter("MIG1g", "MIG2g", "MIG3g", "MIG4g", "MIG7g")]
        public string GpuInstanceProfile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The fully qualified resource ID of the Dedicated Host Group to provision virtual machines from, used only in creation scenario and not allowed to changed once set.")]
        public string HostGroupID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The ID of the subnet which pods will join when launched.")]
        public string PodSubnetID { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            PreValidate();

            Action action = () =>
            {
                if (ParameterSetName == Constants.ParentObjectParameterSet)
                {
                    var clusterId = new ResourceIdentifier(ClusterObject.Id);
                    ResourceGroupName = clusterId.ResourceGroupName;
                    ClusterName = ClusterObject.Name;
                }
                var agentPool = GetAgentPool();
                var pool = this.CreateOrUpdate(ResourceGroupName, ClusterName, Name, agentPool);
                var psPool = AdapterHelper<AgentPool, PSNodePool>.Adapt(pool);
                WriteObject(psPool);
            };

            var msg = $"{Name} for {ClusterName} in {ResourceGroupName}";

            if (GetAgentPoolObject() != null)
                throw new AzPSArgumentException(
                    Resources.AgentPoolAlreadyExistsError,
                    nameof(Name),
                    desensitizedMessage: Resources.AgentPoolAlreadyExistsError);

            if (ShouldProcess(msg, Resources.CreatingClusterAgentPool))
            {
                RunCmdLet(action);
            }
        }

        private AgentPool GetAgentPool()
        {
            var agentPool = new AgentPool(
                name: Name,
                count: Count,
                vmSize: VmSize,
                osDiskSizeGb: OsDiskSize,
                type: VmSetType ?? "AvailabilitySet",
                vnetSubnetId: VnetSubnetID);

            if (this.IsParameterBound(c => c.KubernetesVersion))
            {
                agentPool.OrchestratorVersion = KubernetesVersion;
            }

            if (this.IsParameterBound(c => c.OsType))
            {
                agentPool.OSType = OsType;
            }
            if (this.IsParameterBound(c => c.OsSKU))
            {
                agentPool.OSSku = OsSKU;
                if (OsSKU.ToLower().Equals("cblmariner") || OsSKU.ToLower().Equals("mariner"))
                {
                    WriteWarning("The OsSKU 'AzureLinux' should be used going forward instead of 'CBLMariner' or 'Mariner'. The OsSKU 'CBLMariner' and 'Mariner' will eventually be deprecated.");
                }
            }
            if (this.IsParameterBound(c => c.MaxPodCount))
            {
                agentPool.MaxPods = MaxPodCount;
            }
            if (this.IsParameterBound(c => c.MinCount))
            {
                agentPool.MinCount = MinCount;
            }
            if (this.IsParameterBound(c => c.MaxCount))
            {
                agentPool.MaxCount = MaxCount;
            }
            if (EnableAutoScaling.IsPresent)
            {
                agentPool.EnableAutoScaling = EnableAutoScaling.ToBool();
            }
            if (this.IsParameterBound(c => c.Mode))
            {
                agentPool.Mode = Mode;
            }
            if (EnableNodePublicIp.IsPresent)
            {
                agentPool.EnableNodePublicIP = EnableNodePublicIp.ToBool();
            }
            if (this.IsParameterBound(c => c.NodePublicIPPrefixID))
            {
                agentPool.NodePublicIPPrefixId = NodePublicIPPrefixID;
            }
            if (this.IsParameterBound(c => c.ScaleSetEvictionPolicy))
            {
                agentPool.ScaleSetEvictionPolicy = ScaleSetEvictionPolicy;
            }
            if(this.IsParameterBound(c => c.ScaleSetPriority))
            {
                agentPool.ScaleSetPriority = ScaleSetPriority;
            }
            if (this.IsParameterBound(c => c.AvailabilityZone))
            {
                agentPool.AvailabilityZones = AvailabilityZone;
            }
            if (this.IsParameterBound(c => c.NodeLabel))
            {
                agentPool.NodeLabels = new Dictionary<string, string>();
                foreach (var key in NodeLabel.Keys)
                {
                    agentPool.NodeLabels.Add(key.ToString(), NodeLabel[key].ToString());
                }
            }
            if (this.IsParameterBound(c => c.Tag))
            {
                agentPool.Tags = new Dictionary<string, string>();
                foreach (var key in Tag.Keys)
                {
                    agentPool.Tags.Add(key.ToString(), Tag[key].ToString());
                }
            }
            if (this.IsParameterBound(c => c.NodeTaint))
            {
                agentPool.NodeTaints = NodeTaint;
            }
            if (EnableEncryptionAtHost.IsPresent)
            {
                agentPool.EnableEncryptionAtHost = EnableEncryptionAtHost.ToBool();
            }
            if (EnableUltraSSD.IsPresent)
            {
                agentPool.EnableUltraSsd = EnableUltraSSD.ToBool(); 
            }
            if (this.IsParameterBound(c => c.LinuxOSConfig))
            {
                agentPool.LinuxOSConfig = LinuxOSConfig;
            }
            if (this.IsParameterBound(c => c.KubeletConfig))
            {
                agentPool.KubeletConfig = KubeletConfig;
            }
            if (this.IsParameterBound(c => c.MaxSurge))
            {
                agentPool.UpgradeSettings = new AgentPoolUpgradeSettings(MaxSurge);
            }
            if (this.IsParameterBound(c => c.PPG))
            {
                agentPool.ProximityPlacementGroupId = PPG;
            }
            if (this.IsParameterBound(c => c.SpotMaxPrice))
            {
                agentPool.SpotMaxPrice = SpotMaxPrice;
            }
            if (EnableFIPS.IsPresent)
            {
                agentPool.EnableFips = EnableFIPS.ToBool();
            }
            if (this.IsParameterBound(c => c.GpuInstanceProfile))
            {
                agentPool.GpuInstanceProfile = GpuInstanceProfile;
            }
            if (this.IsParameterBound(c => c.HostGroupID))
            {
                agentPool.HostGroupId = HostGroupID;
            }
            if (this.IsParameterBound(c => c.PodSubnetID)) {
                agentPool.PodSubnetId = PodSubnetID;
            }

            return agentPool;
        }

        protected AgentPool GetAgentPoolObject()
        {
            AgentPool pool = null;
            try
            {
                pool = Client.AgentPools.Get(ResourceGroupName, ClusterName, Name);
                WriteVerbose(string.Format(Resources.AgentPoolExists, pool != null));
            }
            catch (Exception)
            {
                WriteVerbose(Resources.AgentPoolDoesNotExist);
            }
            return pool;
        }

        private void PreValidate()
        {
            if (string.Equals(this.OsType, "Windows"))
            {
                if (VmSetType != "VirtualMachineScaleSets")
                {
                    throw new AzPSArgumentException(
                        Resources.VmSetTypeIsIncorrectForWindowsPool,
                        nameof(VmSetType),
                        desensitizedMessage: Resources.VmSetTypeIsIncorrectForWindowsPool);
                }

                if (Name?.Length > 6)
                {
                    throw new AzPSArgumentException(
                        Resources.WindowsNodePoolNameLengthLimitation,
                        nameof(Name),
                        desensitizedMessage: Resources.WindowsNodePoolNameLengthLimitation);
                }
            }

            if ((this.IsParameterBound(c => c.MinCount) || this.IsParameterBound(c => c.MaxCount) || this.EnableAutoScaling.IsPresent) &&
                !(this.IsParameterBound(c => c.MinCount) && this.IsParameterBound(c => c.MaxCount) && this.EnableAutoScaling.IsPresent))
                throw new AzPSArgumentException(
                    Resources.NodePoolAutoScalingParametersMustAppearTogether,
                    nameof(EnableAutoScaling),
                    desensitizedMessage: Resources.NodePoolAutoScalingParametersMustAppearTogether);
        }
    }
}
