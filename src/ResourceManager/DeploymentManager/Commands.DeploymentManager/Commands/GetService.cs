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
        VerbsCommon.Get, 
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeploymentManagerService",
        DefaultParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName),
     OutputType(typeof(PSServiceResource))]
    public class GetService : DeploymentManagerBaseCmdlet
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
            HelpMessage = "The name of the service topology.")]
        [ValidateNotNullOrEmpty]
        public string ServiceTopologyName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the service.")]
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
            HelpMessage = "Service object.")]
        [ValidateNotNullOrEmpty]
        public PSServiceResource Service { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.Service != null)
            {
                this.ResourceGroupName = this.Service.ResourceGroupName;
                this.ServiceTopologyName = this.Service.ServiceTopologyName;
                this.Name = this.Service.Name;
            }
            else if (!string.IsNullOrWhiteSpace(this.ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ServiceTopologyName = parsedResourceId.ParentResource;
                this.Name = parsedResourceId.ResourceName;
            }

            var psServiceResource = new PSServiceResource()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServiceTopologyName = this.ServiceTopologyName,
                Name = this.Name
            };

            psServiceResource = this.DeploymentManagerClient.GetService(psServiceResource);
            this.WriteObject(psServiceResource);
        }
    }
}
