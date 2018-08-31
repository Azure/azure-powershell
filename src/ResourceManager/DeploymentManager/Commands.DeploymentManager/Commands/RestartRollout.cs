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

    [Cmdlet(VerbsLifecycle.Restart, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeploymentManagerRollout"), OutputType(typeof(PSRollout))]
    public class RestartpRollout : DeploymentManagerBaseCmdlet
    {
        [Parameter(
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.PropertiesParamSetName, 
            HelpMessage = "The resource group.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.PropertiesParamSetName, 
            HelpMessage = "The name of the rollout.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.ResourceParamSetName, 
            ValueFromPipeline = true, 
            HelpMessage = "The resource to be removed.")]
        [ValidateNotNullOrEmpty]
        public PSRollout Rollout { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "Skip steps that succeeded in the previous run of the rollout.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter SkipSucceeded { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                this.SkipSucceeded.IsPresent,
                string.Format(Messages.ConfirmRestartRollout, this.Name),
                string.Format(Messages.RestartingRollout, this.Name),
                this.Name,
                () =>
                {
                    var restartedRollout = this.Restart();
                    this.WriteVerbose(Messages.RestartedRollout);
                    this.WriteObject(restartedRollout);
                });
        }

        private PSRollout Restart()
        {
            PSRollout rolloutToRestart = null;
            if (this.ParameterSetName == DeploymentManagerBaseCmdlet.ResourceParamSetName)
            {
                rolloutToRestart = this.Rollout;
            }
            else if (this.ParameterSetName == DeploymentManagerBaseCmdlet.PropertiesParamSetName)
            {
                rolloutToRestart = new PSRollout()
                {
                    ResourceGroupName = this.ResourceGroupName,
                    Name = this.Name
                };
            }

            var restartedRollout = this.DeploymentManagerClient.RestartRollout(rolloutToRestart, this.SkipSucceeded);
            return restartedRollout;
        }
    }
}
