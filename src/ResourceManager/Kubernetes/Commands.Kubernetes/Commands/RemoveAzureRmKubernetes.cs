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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Kubernetes.Generated;
using Microsoft.Azure.Commands.Kubernetes.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Kubernetes
{
    [Cmdlet(VerbsCommon.Remove, KubeNounStr, SupportsShouldProcess = true)]
    public class Remove : KubeCmdletBase
    {
        private const string IdParameterSet = "IdParameterSet";
        private const string GroupNameParameterSet = "GroupNameParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(Mandatory =true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline =true,
            HelpMessage ="A PSKubernetesCluster object, normally passed through the pipeline.")]
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
        public string Id { get; set; }

        /// <summary>
        /// Cluster name
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = GroupNameParameterSet,
            HelpMessage = "Name of your managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = GroupNameParameterSet,
            HelpMessage = "Resource group name")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Remove cluster even if it is the defualt")]
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

            ConfirmAction(Force.IsPresent,
                "Do you want to delete the managed Kubernetes resource '{0}'?",
                "Remove managed Kubernetes resource '{0}'.",
                "AzureRmKubernetes",
                () =>
                    RunCmdLet(() => { Client.ManagedClusters.Delete(ResourceGroupName, Name); }));
        }
    }
}