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

    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeploymentManagerServiceTopology", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveServiceTopology : DeploymentManagerBaseCmdlet
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
            HelpMessage = "The name of the service topology.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.ResourceParamSetName, ValueFromPipeline = true, 
            HelpMessage = "The resource to be removed.")]
        [ValidateNotNullOrEmpty]
        public PSServiceTopologyResource ServiceTopology { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                this.Force.IsPresent,
                string.Format(Messages.ConfirmRemoveTopology, this.Name),
                string.Format(Messages.RemovingTopology, this.Name),
                this.Name,
                () =>
                {
                    var result = this.Delete();
                    if (result)
                    {
                        this.WriteVerbose(string.Format(Messages.RemovedTopology, this.Name));
                    }

                    if (this.PassThru)
                    {
                        this.WriteObject(result);
                    }
                });
        }

        private bool Delete()
        {
            PSServiceTopologyResource topologyToDelete = null;
            if (this.ParameterSetName == DeploymentManagerBaseCmdlet.ResourceParamSetName)
            {
                topologyToDelete = this.ServiceTopology;
            }
            else if (this.ParameterSetName == DeploymentManagerBaseCmdlet.PropertiesParamSetName)
            {
                topologyToDelete = new PSServiceTopologyResource()
                {
                    ResourceGroupName = this.ResourceGroupName,
                    Name = this.Name
                };
            }

            return this.DeploymentManagerClient.DeleteServiceTopology(topologyToDelete);
        }
    }
}
