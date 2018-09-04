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

    [Cmdlet(
        VerbsCommon.New, 
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeploymentManagerServiceUnit",
        SupportsShouldProcess = true), 
     OutputType(typeof(PSServiceUnitResource))]
    public class NewServiceUnit : DeploymentManagerBaseCmdlet
    {
        private const string IncrementalDeploymentMode = "Incremental";

        private const string CompleteDeploymentMode = "Complete";

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The resource group.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The name of the serivce topology this service unit is a part of.")]
        [ValidateNotNullOrEmpty]
        public string ServiceTopologyName { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The name of the service this service unit is a part of.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The name of the service unit.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The location of the service unit resource.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "Determines the location where resources under the service unit would be deployed to.")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceGroup { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The deployment mode to use when deploying the resources in the service unit.")]
        [ValidateSet(NewServiceUnit.IncrementalDeploymentMode, NewServiceUnit.CompleteDeploymentMode)]
        [ValidateNotNullOrEmpty]
        public string DeploymentMode { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "The SAS Uri to the parameters file. If ArtifactSourceId was referenced in the ServiceTopology, specify relative path using ParametersArtifactSourceRelativePath.")]
        public string ParametersUri { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "The SAS Uri to the template file. If ArtifactSourceId was referenced in the ServiceTopology, specify relative path using TemplateArtifactSourceRelativePath.")]
        public string TemplateUri { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "The path to the template file relative to the artifact source. Requires ArtifactSource to be referenced in ServiceTopology.")]
        public string TemplateArtifactSourceRelativePath { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "The path to the parameters file relative to the artifact source. Requires ArtifactSource to be referenced in ServiceTopology.")]
        public string ParametersArtifactSourceRelativePath { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.Name, Messages.CreateServiceUnit))
            {
                this.ValidateArguments();
                var psServiceUnitResource = new PSServiceUnitResource()
                {
                    ResourceGroupName = this.ResourceGroupName,
                    ServiceTopologyName = this.ServiceTopologyName,
                    ServiceName = this.ServiceName,
                    Name = this.Name,
                    Location = this.Location,
                    TargetResourceGroup = this.TargetResourceGroup,
                    DeploymentMode = this.DeploymentMode,
                    TemplateUri = this.TemplateUri,
                    ParametersUri = this.ParametersUri,
                    TemplateArtifactSourceRelativePath = this.TemplateArtifactSourceRelativePath,
                    ParametersArtifactSourceRelativePath = this.ParametersArtifactSourceRelativePath
                };

                if (this.DeploymentManagerClient.ServiceUnitExists(psServiceUnitResource))
                {
                    throw new PSArgumentException(Messages.ServiceUnitAlreadyExists);
                }

                psServiceUnitResource = this.DeploymentManagerClient.PutServiceUnit(psServiceUnitResource);
                this.WriteObject(psServiceUnitResource);
            }
        }
        
        private void ValidateArguments()
        {
            if (string.IsNullOrWhiteSpace(this.ParametersUri) || string.IsNullOrWhiteSpace(this.TemplateUri))
            {
                if (string.IsNullOrWhiteSpace(this.ParametersArtifactSourceRelativePath) || string.IsNullOrWhiteSpace(this.TemplateArtifactSourceRelativePath))
                {
                    throw new PSArgumentException(Messages.TemplateParametersMissing);
                }
            }
            else if (string.IsNullOrWhiteSpace(this.ParametersArtifactSourceRelativePath) || string.IsNullOrWhiteSpace(this.TemplateArtifactSourceRelativePath))
            {
                if (string.IsNullOrWhiteSpace(this.ParametersUri) || string.IsNullOrWhiteSpace(this.TemplateUri))
                {
                    throw new PSArgumentException(Messages.TemplateParametersMissing);
                }
            }
        }
    }
}
