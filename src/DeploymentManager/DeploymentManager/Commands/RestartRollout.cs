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
        VerbsLifecycle.Restart, 
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "DeploymentManagerRollout",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName),
     OutputType(typeof(PSRollout))]
    public class RestartpRollout : DeploymentManagerBaseCmdlet
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
            HelpMessage = "The name of the rollout.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DeploymentManager/rollouts", nameof(ResourceGroupName))]
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
            HelpMessage = "The resource to be removed.")]
        [ValidateNotNullOrEmpty]
        public PSRollout InputObject { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "Skip steps that succeeded in the previous run of the rollout.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter SkipSucceeded { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ConfirmAction(
                this.SkipSucceeded.IsPresent,
                string.Format(Messages.ConfirmRestartRollout, this.Name),
                string.Format(Messages.RestartingRollout, this.Name),
                this.Name,
                () =>
                {
                    var restartedRollout = this.Restart();
                    this.WriteVerbose(string.Format(Messages.RestartedRollout, this.Name));
                    this.WriteObject(restartedRollout);
                });
        }

        private PSRollout Restart()
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

            var rolloutToRestart = new PSRollout()
            {
                ResourceGroupName = this.ResourceGroupName,
                Name = this.Name
            };

            var restartedRollout = this.DeploymentManagerClient.RestartRollout(rolloutToRestart, this.SkipSucceeded);
            return restartedRollout;
        }
    }
}
