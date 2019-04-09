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
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "DeploymentManagerServiceUnit", 
        SupportsShouldProcess = true,
        DefaultParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName), 
     OutputType(typeof(bool))]
    public class RemoveServiceUnit : DeploymentManagerBaseCmdlet
    {
        private const string ByServiceObjectParameterSet = "ByServiceObject";
        private const string ByServiceResourceIdParamSet = "ByServiceResourceId";
        private const string ByTopologyObjectAndServiceNameParameterSet = "ByTopologyObjectAndServiceName";
        private const string ByTopologyResourceIdAndServiceNameParameterSet = "ByTopologyResourceAndServiceName";

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
            HelpMessage = "The name of the service topology the service unit is part of.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DeploymentManager/serviceTopologies", nameof(ResourceGroupName))]
        public string ServiceTopologyName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName,
            HelpMessage = "The name of the service the service unit is part of.")]
        [Parameter(
            Position = 2,
            Mandatory = true, 
            ParameterSetName = RemoveServiceUnit.ByTopologyObjectAndServiceNameParameterSet,
            HelpMessage = "The name of the service the service unit is part of.")]
        [Parameter(
            Position = 2,
            Mandatory = true, 
            ParameterSetName = RemoveServiceUnit.ByTopologyResourceIdAndServiceNameParameterSet,
            HelpMessage = "The name of the service the service unit is part of.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DeploymentManager/serviceTopologies/services", nameof(ResourceGroupName), nameof(ServiceTopologyName))]
        public string ServiceName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName,
            HelpMessage = "The name of the service unit.")]
        [Parameter(
            Position = 2,
            Mandatory = true, 
            ParameterSetName = RemoveServiceUnit.ByServiceObjectParameterSet,
            HelpMessage = "The name of the service unit.")]
        [Parameter(
            Position = 2,
            Mandatory = true, 
            ParameterSetName = RemoveServiceUnit.ByServiceResourceIdParamSet,
            HelpMessage = "The name of the service unit.")]
        [Parameter(
            Position = 3,
            Mandatory = true, 
            ParameterSetName = RemoveServiceUnit.ByTopologyObjectAndServiceNameParameterSet,
            HelpMessage = "The name of the service unit.")]
        [Parameter(
            Position = 3,
            Mandatory = true, 
            ParameterSetName = RemoveServiceUnit.ByTopologyResourceIdAndServiceNameParameterSet,
            HelpMessage = "The name of the service unit.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DeploymentManager/serviceTopologies/services/serviceUnits", nameof(ResourceGroupName), nameof(ServiceTopologyName), nameof(ServiceName))]
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
            HelpMessage = "Service unit resource object.")]
        [ValidateNotNullOrEmpty]
        public PSServiceUnitResource InputObject { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true, 
            ParameterSetName = RemoveServiceUnit.ByTopologyObjectAndServiceNameParameterSet,
            HelpMessage = "The service topology object in which the service unit should be created.")]
        [ValidateNotNullOrEmpty]
        public PSServiceTopologyResource ServiceTopologyObject { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true, 
            ParameterSetName = RemoveServiceUnit.ByTopologyResourceIdAndServiceNameParameterSet,
            HelpMessage = "The service topology resource identifier in which the service unit should be created.")]
        [ValidateNotNullOrEmpty]
        public string ServiceTopologyResourceId { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true, 
            ParameterSetName = RemoveServiceUnit.ByServiceObjectParameterSet,
            HelpMessage = "The service object in which the service unit should be created.")]
        [ValidateNotNullOrEmpty]
        public PSServiceResource ServiceObject { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true, 
            ParameterSetName = RemoveServiceUnit.ByServiceResourceIdParamSet,
            HelpMessage = "The service resource identifier in which the service unit should be created.")]
        [ValidateNotNullOrEmpty]
        public string ServiceResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ResolveParameters();
            this.WriteVerbose(string.Format(Messages.RemovingServiceUnit, this.Name));

            var result = this.Delete();
            if (result)
            {
                this.WriteVerbose(string.Format(Messages.RemovedServiceUnit, this.Name));
            }

            if (this.PassThru)
            {
                this.WriteObject(true);
            }
        }

        private bool Delete()
        {
            var serviceUnitToDelete = new PSServiceUnitResource()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServiceTopologyName = this.ServiceTopologyName,
                ServiceName = this.ServiceName,
                Name = this.Name
            };

            return this.DeploymentManagerClient.DeleteServiceUnit(serviceUnitToDelete);
        }

        private void ResolveParameters()
        {
            if (this.InputObject != null)
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.ServiceTopologyName = this.InputObject.ServiceTopologyName;
                this.ServiceName = this.InputObject.ServiceName;
                this.Name = this.InputObject.Name;
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
            else if (this.ServiceObject != null)
            {
                this.ResourceGroupName = this.ServiceObject.ResourceGroupName;
                this.ServiceTopologyName = this.ServiceObject.ServiceTopologyName;
                this.ServiceName = this.ServiceObject.Name;
            }
            else if (!string.IsNullOrWhiteSpace(this.ServiceResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ServiceResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ServiceName = parsedResourceId.ResourceName;
                string[] tokens = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length < 2)
                {
                    throw new ArgumentException($"Invalid Service resource identifier: {this.ResourceId}");
                }

                this.ServiceTopologyName = tokens[1];
            }
            else if (this.ServiceTopologyObject != null)
            {
                this.ResourceGroupName = this.ServiceTopologyObject.ResourceGroupName;
                this.ServiceTopologyName = this.ServiceTopologyObject.Name;
            }
            else if (!string.IsNullOrWhiteSpace(this.ServiceTopologyResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ServiceTopologyResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ServiceTopologyName = parsedResourceId.ResourceName;
            }
        }
    }
}
