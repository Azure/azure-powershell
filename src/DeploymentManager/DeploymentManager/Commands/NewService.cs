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
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(
        VerbsCommon.
        New, ResourceManager.Common.AzureRMConstants.AzurePrefix + "DeploymentManagerService",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName), 
     OutputType(typeof(PSServiceResource))]
    public class NewService : DeploymentManagerBaseCmdlet
    {
        private const string ByServiceTopologyObjectParameterSet = "ByServiceTopologyObject";
        private const string ByServiceTopologyResourceIdParamSet = "ByServiceTopologyResourceId";

        [Parameter(
            Position = 0,
            Mandatory = true, 
            HelpMessage = "The resource group.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName,
            HelpMessage = "The name of the service topology this service belongs to.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DeploymentManager/serviceTopologies", nameof(ResourceGroupName))]
        public string ServiceTopologyName { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The name of the service.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The location of the service resource.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.DeploymentManager/serviceTopologies")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "Determines the location where resources under the service would be deployed to.")]
        [ValidateNotNullOrEmpty]
        public string TargetLocation { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "Determines the subscription to which resources under the service would be deployed to.")]
        [ValidateNotNullOrEmpty]
        public string TargetSubscriptionId { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true, 
            ParameterSetName = NewService.ByServiceTopologyObjectParameterSet,
            HelpMessage = "The service topology object in which the service should be created.")]
        [ValidateNotNullOrEmpty]
        public PSServiceTopologyResource ServiceTopologyObject { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true, 
            ParameterSetName = NewService.ByServiceTopologyResourceIdParamSet,
            HelpMessage = "The service topology resource identifier in which the service should be created.")]
        [ValidateNotNullOrEmpty]
        public string ServiceTopologyId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.Name, Messages.CreateService))
            {
                if (this.ServiceTopologyObject != null)
                {
                    this.ServiceTopologyName = this.ServiceTopologyObject.Name;
                }
                else if (!string.IsNullOrWhiteSpace(this.ServiceTopologyId))
                {
                    var parsedResource = new ResourceIdentifier(this.ServiceTopologyId);
                    this.ServiceTopologyName = parsedResource.ResourceName;
                }

                var serviceResource = new PSServiceResource()
                {
                    ResourceGroupName = this.ResourceGroupName,
                    Name = this.Name,
                    Location = this.Location,
                    TargetSubscriptionId = this.TargetSubscriptionId,
                    TargetLocation = this.TargetLocation,
                    ServiceTopologyName = this.ServiceTopologyName,
                    Tags = this.Tag
                };

                if (this.DeploymentManagerClient.ServiceExists(serviceResource))
                {
                    throw new PSArgumentException(Messages.ServiceAlreadyExists);
                }

                serviceResource = this.DeploymentManagerClient.PutService(serviceResource);
                this.WriteObject(serviceResource);
            }
        }
    }
}
