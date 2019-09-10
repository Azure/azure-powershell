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

namespace Microsoft.Azure.Commands.DeploymentManager.Commands
{
    using System.Collections;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.DeploymentManager.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DeploymentManager.Models;

    [Cmdlet(
        VerbsCommon.New, 
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "DeploymentManagerServiceTopology",
        SupportsShouldProcess = true), 
     OutputType(typeof(PSServiceTopologyResource))]
    public class NewServiceTopology : DeploymentManagerBaseCmdlet
    {
        [Parameter(
            Mandatory = true, 
            HelpMessage = "The resource group.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The name of the topology.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The location of the topology.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.DeploymentManager/serviceTopologies")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "The identifier of the artifact source, where the artifacts that make up the topology are stored.")]
        public string ArtifactSourceId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.Name, Messages.CreateServiceTopology))
            {
                var topologyResource = new PSServiceTopologyResource()
                {
                    ResourceGroupName = this.ResourceGroupName,
                    Name = this.Name,
                    Location = this.Location,
                    ArtifactSourceId = this.ArtifactSourceId,
                    Tags = this.Tag
                };

                if (this.DeploymentManagerClient.ServiceTopologyExists(topologyResource))
                {
                    throw new PSArgumentException(Messages.ServiceTopologyAlreadyExists);
                }

                topologyResource = this.DeploymentManagerClient.PutServiceTopology(topologyResource);

                this.WriteObject(topologyResource);
            }
        }
    }
}
