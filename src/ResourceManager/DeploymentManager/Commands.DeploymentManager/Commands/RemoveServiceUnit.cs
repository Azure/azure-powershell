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
    using System;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.DeploymentManager.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(
        VerbsCommon.Remove, 
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeploymentManagerServiceUnit", 
        SupportsShouldProcess = true,
        DefaultParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName), 
     OutputType(typeof(bool))]
    public class RemoveServiceUnit : DeploymentManagerBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName, 
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName, 
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the service topology the service unit belongs to.")]
        [ValidateNotNullOrEmpty]
        public string ServiceTopologyName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName, 
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the service the service unit belongs to.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName, 
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the service unit to delete.")]
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
            HelpMessage = "The resource to be removed.")]
        [ValidateNotNullOrEmpty]
        public PSServiceUnitResource ServiceUnit { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(Messages.ConfirmRemoveTopologyUnit, this.Name),
                string.Format(Messages.RemovingTopologyUnit, this.Name),
                this.Name,
                () =>
                {
                    var result = this.Delete();
                    if (this.PassThru)
                    {
                        this.WriteObject(result);
                    }
                });
        }

        private bool Delete()
        {
            if (this.ServiceUnit != null)
            {
                this.ResourceGroupName = this.ServiceUnit.ResourceGroupName;
                this.ServiceTopologyName = this.ServiceUnit.ServiceTopologyName;
                this.ServiceName = this.ServiceUnit.ServiceName;
                this.Name = this.ServiceUnit.Name;
            }
            else if (!string.IsNullOrWhiteSpace(this.ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.Name = parsedResourceId.ResourceName;

                string[] tokens = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length < 4)
                {
                    throw new ArgumentException($"Invalid Service Unit resource identifier: {this.ResourceId}");
                }

                this.ServiceTopologyName = tokens[1];
                this.ServiceName = tokens[3]; 
            }

            var serviceUnitToDelete = new PSServiceUnitResource()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServiceTopologyName = this.ServiceTopologyName,
                ServiceName = this.ServiceName,
                Name = this.Name
            };

            return this.DeploymentManagerClient.DeleteServiceUnit(serviceUnitToDelete);
        }
    }
}
