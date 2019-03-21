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

    [Cmdlet(
        VerbsCommon.New, 
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "DeploymentManagerArtifactSource",
        SupportsShouldProcess = true), 
     OutputType(typeof(PSArtifactSource))]
    public class NewArtifactSource : DeploymentManagerBaseCmdlet
    {
        /// <summary>
        /// The parameter set for SAS-based authentication.
        /// </summary>
        private const string SasUriParamSet = "Sas";

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The resource group.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The name of the artifact source.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The location of the resource.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The SAS Uri to the Azure storage container where the artifacts are stored.", ParameterSetName = NewArtifactSource.SasUriParamSet)]
        [ValidateNotNullOrEmpty]
        public string SasUri { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "The optional directory offset under the storage container for the artifacts.")]
        public string ArtifactRoot { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.Name, Messages.CreateArtifactSource))
            {
                var psArtifactSource = new PSArtifactSource()
                {
                    ResourceGroupName = this.ResourceGroupName,
                    Name = this.Name,
                    Location = this.Location,
                    SourceType = "AzureStorage",
                    ArtifactRoot = this.ArtifactRoot,
                    Authentication = this.GetAuthentication(),
                    Tags = this.Tag
                };

                if (this.DeploymentManagerClient.ArtifactSourceExists(psArtifactSource))
                {
                    throw new PSArgumentException(Messages.ArtifactSourceAlreadyExists);
                }

                psArtifactSource = this.DeploymentManagerClient.PutArtifactSource(psArtifactSource);
                this.WriteObject(psArtifactSource);
            }
        }

        private PSAuthentication GetAuthentication()
        {
            switch (this.ParameterSetName)
            {
                case SasUriParamSet:
                    return new PSSasAuthentication()
                    {
                        SasUri = this.SasUri
                    };

                default:
                    return null;
            }
        }
    }
}
