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

using System.Management.Automation;
using Microsoft.Azure.Commands.Aks.Commands;
using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Aks
{
    [Cmdlet("Remove", AzureRMConstants.AzureRMPrefix + Constants.NodePool, DefaultParameterSetName = Constants.GroupNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureRmAksNodePool : KubeCmdletBase
    {
        [Parameter(Mandatory = true,
            ParameterSetName = Constants.InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "A PSAgentPool object, normally passed through the pipeline.")]
        [ValidateNotNullOrEmpty]
        public PSNodePool InputObject { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = Constants.IdParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Id of an node pool in managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string Id { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.GroupNameParameterSet,
            HelpMessage = "Resource group name")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = Constants.GroupNameParameterSet,
            HelpMessage = "Name of your managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ParameterSetName = Constants.GroupNameParameterSet,
            HelpMessage = "Name of your node pool.")]
        [Parameter(Mandatory = true, ParameterSetName = Constants.ParentObjectParameterSet, HelpMessage = "Name of your node pool.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = Constants.ParentObjectParameterSet, HelpMessage = "The cluster object.")]
        [ValidateNotNull]
        public PSKubernetesCluster ClusterObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Remove node pool without prompt")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ResourceIdentifier resource;
            switch(ParameterSetName)
            {
                case Constants.IdParameterSet:
                    resource = new ResourceIdentifier(Id);
                    ResourceGroupName = resource.ResourceGroupName;
                    ClusterName = Utilities.GetParentResourceName(resource.ParentResource, nameof(Id));
                    Name = resource.ResourceName;
                    break;
                case Constants.InputObjectParameterSet:
                    resource = new ResourceIdentifier(InputObject.Id);
                    ResourceGroupName = resource.ResourceGroupName;
                    ClusterName = Utilities.GetParentResourceName(resource.ParentResource, nameof(InputObject));
                    Name = resource.ResourceName;
                    break;
            }

            var msg = $"{Name} for {ClusterName} in {ResourceGroupName}";

            ConfirmAction(Force.IsPresent,
                Resources.DoYouWantToDeleteTheAgentPool,
                Resources.RemovingTheAgentPool,
                msg,
                () =>
                {
                    RunCmdLet(() =>
                   {
                       Client.AgentPools.Delete(ResourceGroupName, ClusterName, Name);
                       if(PassThru)
                       {
                           WriteObject(true);
                       }
                   });
                });
        }
    }
}
