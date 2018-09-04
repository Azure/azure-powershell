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

    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeploymentManagerService"), OutputType(typeof(PSServiceResource))]
    public class NewService : DeploymentManagerBaseCmdlet
    {
        [Parameter(
            Mandatory = true, 
            HelpMessage = "The resource group.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The name of the service.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The name of the service topology this service belongs to.")]
        [ValidateNotNullOrEmpty]
        public string ServiceTopologyName { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The location of the service resource.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter]
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

        public override void ExecuteCmdlet()
        {
            var serviceResource = new PSServiceResource()
            {
                ResourceGroupName = this.ResourceGroupName,
                Name = this.Name,
                Location = this.Location,
                TargetSubscriptionId = this.TargetSubscriptionId,
                TargetLocation = this.TargetLocation,
                ServiceTopologyName = this.ServiceTopologyName,
            };
            serviceResource = this.DeploymentManagerClient.PutService(serviceResource);
            this.WriteObject(serviceResource);
        }
    }
}
