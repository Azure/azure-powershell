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
        VerbsLifecycle.Stop, 
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "DeploymentManagerRollout",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName),
     OutputType(typeof(PSRollout))]
    public class StopRollout : DeploymentManagerBaseCmdlet
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
            HelpMessage = "The rollout to be removed.")]
        [ValidateNotNullOrEmpty]
        public PSRollout InputObject { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(Messages.ConfirmStopRollout, this.Name),
                string.Format(Messages.StoppingRollout, this.Name),
                this.Name,
                () =>
                {
                    var canceledRollout = this.Cancel();
                    this.WriteVerbose(string.Format(Messages.StoppedRollout, this.Name));
                    this.WriteObject(canceledRollout);
                });
        }

        private PSRollout Cancel()
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

            var rolloutToCancel = new PSRollout()
            {
                ResourceGroupName = this.ResourceGroupName,
                Name = this.Name
            };

            var canceledRollout = this.DeploymentManagerClient.CancelRollout(rolloutToCancel);
            return canceledRollout;
        }
    }
}
