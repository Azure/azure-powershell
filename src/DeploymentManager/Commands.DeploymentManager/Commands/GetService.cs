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
        VerbsCommon.Get, 
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeploymentManagerService",
        DefaultParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName),
     OutputType(typeof(PSServiceResource))]
    public class GetService : DeploymentManagerBaseCmdlet
    {
        private const string ByServiceTopologyObjectParameterSet = "ByServiceTopologyObject";

        private const string ByServiceTopologyResourceIdParamSet = "ByServiceTopologyResourceId";

        [Parameter(
            Position = 0,
            Mandatory = true, 
            ParameterSetName = DeploymentManagerBaseCmdlet.InteractiveParamSetName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group.")]
        [Parameter(
            Position = 0,
            Mandatory = true, 
            ParameterSetName = GetService.ByServiceTopologyObjectParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group.")]
        [Parameter(
            Position = 0,
            Mandatory = true, 
            ParameterSetName = GetService.ByServiceTopologyResourceIdParamSet,
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
        [Parameter(
            Position = 2,
            Mandatory = true, 
            ParameterSetName = GetService.ByServiceTopologyObjectParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the service.")]
        [Parameter(
            Position = 2,
            Mandatory = true, 
            ParameterSetName = GetService.ByServiceTopologyResourceIdParamSet,
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

        [Parameter(
            Position = 1,
            Mandatory = true, 
            ParameterSetName = GetService.ByServiceTopologyObjectParameterSet,
            HelpMessage = "The service topology object in which the service should be created.")]
        [ValidateNotNullOrEmpty]
        public PSServiceTopologyResource ServiceTopology { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true, 
            ParameterSetName = GetService.ByServiceTopologyResourceIdParamSet,
            HelpMessage = "The service topology resource identifier in which the service should be created.")]
        [ValidateNotNullOrEmpty]
        public string ServiceTopologyResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ResolveParams();
            var psServiceResource = new PSServiceResource()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServiceTopologyName = this.ServiceTopologyName,
                Name = this.Name
            };

            psServiceResource = this.DeploymentManagerClient.GetService(psServiceResource);
            this.WriteObject(psServiceResource);
        }

        private void ResolveParams()
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
                this.Name = parsedResourceId.ResourceName;

                string[] tokens = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length < 2)
                {
                    throw new ArgumentException($"Invalid Service resource identifier: {this.ResourceId}");
                }

                this.ServiceTopologyName = tokens[1];
            }
            else if (this.ServiceTopology != null)
            {
                this.ServiceTopologyName = this.ServiceTopology.Name;
            }
            else if (!string.IsNullOrWhiteSpace(this.ServiceTopologyResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ServiceTopologyResourceId);
                this.ServiceTopologyName = parsedResourceId.ResourceName;
            }
        }
    }
}
