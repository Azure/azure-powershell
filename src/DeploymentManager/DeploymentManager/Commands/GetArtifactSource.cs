﻿// ----------------------------------------------------------------------------------
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
        VerbsCommon.Get, 
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "DeploymentManagerArtifactSource",
        DefaultParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName), 
        OutputType(typeof(PSArtifactSource))]
    public class GetArtifactSource : DeploymentManagerBaseCmdlet
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
            Mandatory = false, 
            ParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName,
            HelpMessage = "The name of the artifact source.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DeploymentManager/artifactSources", nameof(ResourceGroupName))]
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
            HelpMessage = "Artifact Source object.")]
        [ValidateNotNullOrEmpty]
        public PSArtifactSource InputObject { get; set; }

        public override void ExecuteCmdlet()
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

            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                var psArtifactSource = new PSArtifactSource()
                {
                    ResourceGroupName = this.ResourceGroupName,
                    Name = this.Name,
                };

                psArtifactSource = this.DeploymentManagerClient.GetArtifactSource(psArtifactSource);
                this.WriteObject(psArtifactSource);
            }
            else
            {
                var psArtifactSources = this.DeploymentManagerClient.ListArtifactSources(this.ResourceGroupName);
                this.WriteObject(psArtifactSources, enumerateCollection: true);
            }
        }
    }
}
