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

    [Cmdlet(
        VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "DeploymentManagerArtifactSource",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DeploymentManagerBaseCmdlet.InputObjectParamSetName),
     OutputType(typeof(PSArtifactSource))]
    public class SetArtifactSource : DeploymentManagerBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "The artifact source object.",
            ValueFromPipeline = true,
            ParameterSetName = DeploymentManagerBaseCmdlet.InputObjectParamSetName)]
        [ValidateNotNullOrEmpty]
        public PSArtifactSource InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.InputObject.Name, Messages.UpdateArtifactSource))
            {
                var artifactSource = this.DeploymentManagerClient.PutArtifactSource(this.InputObject);
                this.WriteObject(artifactSource);
            }
        }
    }
}
