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
    using System.Management.Automation;

    using Microsoft.Azure.Commands.DeploymentManager.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(
        VerbsCommon.Remove, 
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "DeploymentManagerArtifactSource", 
        SupportsShouldProcess = true,
        DefaultParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName), 
     OutputType(typeof(bool))]
    public class RemoveArtifactSource : DeploymentManagerBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName, 
            HelpMessage = "The resource group.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName, 
            HelpMessage = "The name of the artifact source.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.ResourceIdParamSetName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource identifier.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.InputObjectParamSetName, 
            ValueFromPipeline = true, 
            HelpMessage = "The artifact source to be removed.")]
        [ValidateNotNullOrEmpty]
        public PSArtifactSource InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            this.WriteVerbose(string.Format(Messages.RemovingArtifactSource, this.Name));
            var result = this.Delete();
            if (result)
            {
                this.WriteVerbose(string.Format(Messages.RemovedArtifactSource, this.Name));
            }

            if (this.PassThru)
            {
                this.WriteObject(result);
            }
        }

        private bool Delete()
        {
            if (this.InputObject != null)
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else if (!string.IsNullOrWhiteSpace(this.ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.Name = parsedResourceId.ResourceName;
            }

            var artifactSourceToDelete = new PSArtifactSource()
            {
                ResourceGroupName = this.ResourceGroupName,
                Name = this.Name
            };
            return this.DeploymentManagerClient.DeleteArtifactSource(artifactSourceToDelete);
        }
    }
}
