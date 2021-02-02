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
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Aks.Commands
{
    [Cmdlet("Update", AzureRMConstants.AzureRMPrefix + Constants.NodePool, DefaultParameterSetName = Constants.DefaultParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSNodePool))]
    public class UpdateAzureRmAksNodePool : NewOrUpdateAgentPoolBase
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

        [Parameter(Mandatory = true, ParameterSetName = Constants.ParentObjectParameterSet, HelpMessage = "The cluster object")]
        public PSKubernetesCluster ClusterObject { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = Constants.InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "A PSAgentPool object, normally passed through the pipeline.")]
        [ValidateNotNullOrEmpty]
        public PSNodePool InputObject { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = Constants.IdParameterSet,
            HelpMessage = "Id of an node pool in managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string Id { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Update node pool without prompt")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            AgentPool pool = null;
            ResourceIdentifier resource = null;
            switch(ParameterSetName)
            {
                case Constants.IdParameterSet:
                    resource = new ResourceIdentifier(Id);
                    ResourceGroupName = resource.ResourceGroupName;
                    ClusterName = Utilities.GetParentResourceName(resource.ParentResource, nameof(Id));
                    Name = resource.ResourceName;
                    break;
                case Constants.InputObjectParameterSet:
                    WriteVerbose(Resources.UsingAgentPoolFromPipeline);
                    pool = PSMapper.Instance.Map<AgentPool>(InputObject);
                    resource = new ResourceIdentifier(pool.Id);
                    ResourceGroupName = resource.ResourceGroupName;
                    ClusterName = Utilities.GetParentResourceName(resource.ParentResource, nameof(InputObject));
                    Name = resource.ResourceName;
                    break;
                case Constants.ParentObjectParameterSet:
                    resource = new ResourceIdentifier(ClusterObject.Id);
                    ResourceGroupName = resource.ResourceGroupName;
                    ClusterName = ClusterObject.Name;
                    break;
            }

            var msg = $"{Name} for {ClusterName} in {ResourceGroupName}";
            if(ShouldProcess(msg, Resources.UpdateAgentPool))
            {
                RunCmdLet(() =>
                {
                    {
                        //Put agentPool in the block to avoid referencing it incorrectly.
                        var agentPool = GetAgentPoolObject();
                        if (agentPool == null)
                        {
                            WriteErrorWithTimestamp(Resources.AgentPoolDoesNotExist);
                            return;
                        }

                        if (pool == null)
                        {
                            pool = agentPool;
                        }
                    }

                    if (this.IsParameterBound(c => c.KubernetesVersion))
                    {
                        pool.OrchestratorVersion = KubernetesVersion;
                    }
                    if (this.IsParameterBound(c => c.MinCount))
                    {
                        pool.MinCount = MinCount;
                    }
                    if (this.IsParameterBound(c => c.MaxCount))
                    {
                        pool.MaxCount = MaxCount;
                    }
                    if (this.IsParameterBound(c => c.EnableAutoScaling))
                    {
                        pool.EnableAutoScaling = EnableAutoScaling.ToBool();
                    }

                    var updatedPool = Client.AgentPools.CreateOrUpdate(ResourceGroupName, ClusterName, Name, pool);
                    WriteObject(PSMapper.Instance.Map<PSNodePool>(updatedPool));
                });
            }
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
    }
}
