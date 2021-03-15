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

        //Hide as PublicIp is going to GA around May
        //[Parameter(Mandatory = false, HelpMessage = "Whether to enable public IP for nodes")]
        //public SwitchParameter EnableNodePublicIp { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "ScaleSetPriority to be used to specify virtual machine scale set priority. Default to regular.")]
        [PSArgumentCompleter("Low", "Regular")]
        public string ScaleSetPriority { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "ScaleSetEvictionPolicy to be used to specify eviction policy for low priority virtual machine scale set. Default to Delete.")]
        [PSArgumentCompleter("Delete", "Deallocate")]
        public string ScaleSetEvictionPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Represents types of an node pool. Possible values include: 'VirtualMachineScaleSets', 'AvailabilitySet'")]
        [PSArgumentCompleter("AvailabilitySet", "VirtualMachineScaleSets")]
        public string VmSetType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Create node pool even if it already exists")]
        public SwitchParameter Force { get; set; }

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
                var pool = Client.AgentPools.CreateOrUpdate(ResourceGroupName, ClusterName, Name, agentPool);
                var psPool = PSMapper.Instance.Map<PSNodePool>(pool);
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
                osDiskSizeGB: OsDiskSize,
                type: VmSetType ?? "AvailabilitySet",
                vnetSubnetID: VnetSubnetID);

            if (this.IsParameterBound(c => c.KubernetesVersion))
            {
                agentPool.OrchestratorVersion = KubernetesVersion;
            }

            if (this.IsParameterBound(c => c.OsType))
            {
                agentPool.OsType = OsType;
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
            //if(EnableNodePublicIp.IsPresent)
            //{
            //    agentPool.EnableNodePublicIP = EnableNodePublicIp.ToBool();
            //}
            if(this.IsParameterBound(c => c.ScaleSetEvictionPolicy))
            {
                agentPool.ScaleSetEvictionPolicy = ScaleSetEvictionPolicy;
            }
            if(this.IsParameterBound(c => c.ScaleSetPriority))
            {
                agentPool.ScaleSetPriority = ScaleSetPriority;
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
