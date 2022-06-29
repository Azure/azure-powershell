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
using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Aks
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AksCluster", SupportsShouldProcess = true, DefaultParameterSetName = GroupNameParameterSet)]
    [OutputType(typeof(bool))]
    public class RemoveAzureRmAks : KubeCmdletBase
    {
        private const string IdParameterSet = "IdParameterSet";
        private const string GroupNameParameterSet = "GroupNameParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "A PSKubernetesCluster object, normally passed through the pipeline.")]
        [ValidateNotNullOrEmpty]
        public PSKubernetesCluster InputObject { get; set; }

        /// <summary>
        /// Cluster name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = IdParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Id of a managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string Id { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = GroupNameParameterSet,
            HelpMessage = "Resource group name")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Cluster name
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = GroupNameParameterSet,
            HelpMessage = "Name of your managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Remove managed Kubernetes cluster without prompt")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (ParameterSetName)
            {
                case IdParameterSet:
                    {
                        var resource = new ResourceIdentifier(Id);
                        ResourceGroupName = resource.ResourceGroupName;
                        Name = resource.ResourceName;
                        break;
                    }
                case InputObjectParameterSet:
                    {
                        var resource = new ResourceIdentifier(InputObject.Id);
                        ResourceGroupName = resource.ResourceGroupName;
                        Name = resource.ResourceName;
                        break;
                    }
            }

            var msg = $"{Name} in {ResourceGroupName}";

            ConfirmAction(Force.IsPresent,
                Resources.DoYouWantToDeleteTheManagedKubernetesCluster,
                Resources.RemovingTheManagedKubernetesCluster,
                msg,
                () =>
                {
                    RunCmdLet(() =>
                    {
                        Client.ManagedClusters.Delete(ResourceGroupName, Name);
                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    });
                });
        }
    }
}
