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
    using System.Collections;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.DeploymentManager.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(
        VerbsCommon.New, 
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "DeploymentManagerServiceUnit",
        DefaultParameterSetName = NewServiceUnit.ByTopologyAndServiceNamesParameterSet,
        SupportsShouldProcess = true), 
     OutputType(typeof(PSServiceUnitResource))]
    public class NewServiceUnit : DeploymentManagerBaseCmdlet
    {
        private const string IncrementalDeploymentMode = "Incremental";
        private const string CompleteDeploymentMode = "Complete";

        private const string ByServiceObjectParameterSet = "ByServiceObject";
        private const string ByServiceResourceIdParamSet = "ByServiceResourceId";
        private const string ByTopologyAndServiceNamesParameterSet = "ByTopologyAndServiceNames";
        private const string ByTopologyObjectAndServiceNameParameterSet = "ByTopologyObjectAndServiceName";
        private const string ByTopologyResourceIdAndServiceNameParameterSet = "ByTopologyResourceAndServiceName";

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
            ParameterSetName = NewServiceUnit.ByTopologyAndServiceNamesParameterSet,
            HelpMessage = "The name of the serivce topology this service unit is a part of.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DeploymentManager/serviceTopologies", nameof(ResourceGroupName))]
        public string ServiceTopologyName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true, 
            ParameterSetName = NewServiceUnit.ByTopologyAndServiceNamesParameterSet,
            HelpMessage = "The name of the service this service unit is a part of.")]
        [Parameter(
            Position = 2,
            Mandatory = true, 
            ParameterSetName = NewServiceUnit.ByTopologyObjectAndServiceNameParameterSet,
            HelpMessage = "The name of the service this service unit is a part of.")]
        [Parameter(
            Position = 2,
            Mandatory = true, 
            ParameterSetName = NewServiceUnit.ByTopologyResourceIdAndServiceNameParameterSet,
            HelpMessage = "The name of the service this service unit is a part of.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DeploymentManager/serviceTopologies/services", nameof(ResourceGroupName), nameof(ServiceTopologyName))]
        public string ServiceName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true, 
            HelpMessage = "The name of the service unit.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DeploymentManager/serviceTopologies/services/serviceUnits", nameof(ResourceGroupName), nameof(ServiceTopologyName), nameof(ServiceName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The location of the service unit resource.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.DeploymentManager/serviceTopologies")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "Determines the location where resources under the service unit would be deployed to.")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceGroup { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The deployment mode to use when deploying the resources in the service unit.")]
        [ValidateSet(NewServiceUnit.IncrementalDeploymentMode, NewServiceUnit.CompleteDeploymentMode)]
        [ValidateNotNullOrEmpty]
        public string DeploymentMode { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "The SAS Uri to the parameters file. If ArtifactSourceId was referenced in the ServiceTopology, specify relative path using ParametersArtifactSourceRelativePath.")]
        public string ParametersUri { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "The SAS Uri to the template file. If ArtifactSourceId was referenced in the ServiceTopology, specify relative path using TemplateArtifactSourceRelativePath.")]
        public string TemplateUri { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "The path to the template file relative to the artifact source. Requires ArtifactSource to be referenced in ServiceTopology.")]
        public string TemplateArtifactSourceRelativePath { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "The path to the parameters file relative to the artifact source. Requires ArtifactSource to be referenced in ServiceTopology.")]
        public string ParametersArtifactSourceRelativePath { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true, 
            ParameterSetName = NewServiceUnit.ByTopologyObjectAndServiceNameParameterSet,
            HelpMessage = "The service topology object in which the service unit should be created.")]
        [ValidateNotNullOrEmpty]
        public PSServiceTopologyResource ServiceTopologyObject { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true, 
            ParameterSetName = NewServiceUnit.ByTopologyResourceIdAndServiceNameParameterSet,
            HelpMessage = "The service topology resource identifier in which the service unit should be created.")]
        [ValidateNotNullOrEmpty]
        public string ServiceTopologyResourceId { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true, 
            ParameterSetName = NewServiceUnit.ByServiceObjectParameterSet,
            HelpMessage = "The service object in which the service unit should be created.")]
        [ValidateNotNullOrEmpty]
        public PSServiceResource ServiceObject { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true, 
            ParameterSetName = NewServiceUnit.ByServiceResourceIdParamSet,
            HelpMessage = "The service resource identifier in which the service unit should be created.")]
        [ValidateNotNullOrEmpty]
        public string ServiceResourceId { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.Name, Messages.CreateServiceUnit))
            {
                this.ResolveParameters();
                var psServiceUnitResource = new PSServiceUnitResource()
                {
                    ResourceGroupName = this.ResourceGroupName,
                    ServiceTopologyName = this.ServiceTopologyName,
                    ServiceName = this.ServiceName,
                    Name = this.Name,
                    Location = this.Location,
                    TargetResourceGroup = this.TargetResourceGroup,
                    DeploymentMode = this.DeploymentMode,
                    TemplateUri = this.TemplateUri,
                    ParametersUri = this.ParametersUri,
                    TemplateArtifactSourceRelativePath = this.TemplateArtifactSourceRelativePath,
                    ParametersArtifactSourceRelativePath = this.ParametersArtifactSourceRelativePath,
                    Tags = this.Tag
                };

                if (this.DeploymentManagerClient.ServiceUnitExists(psServiceUnitResource))
                {
                    throw new PSArgumentException(Messages.ServiceUnitAlreadyExists);
                }

                psServiceUnitResource = this.DeploymentManagerClient.PutServiceUnit(psServiceUnitResource);
                this.WriteObject(psServiceUnitResource);
            }
        }

        private void ResolveParameters()
        {
            if (this.ServiceObject != null)
            {
                this.ServiceTopologyName = this.ServiceObject.ServiceTopologyName;
                this.ServiceName = this.ServiceObject.Name;
            }
            else if (!string.IsNullOrWhiteSpace(this.ServiceResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ServiceResourceId);
                this.ServiceName = parsedResourceId.ResourceName;
                string[] tokens = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length < 2)
                {
                    throw new ArgumentException($"Invalid Service resource identifier: {this.ServiceResourceId}");
                }

                this.ServiceTopologyName = tokens[1];
            }
            else if (this.ServiceTopologyObject != null)
            {
                this.ServiceTopologyName = this.ServiceTopologyObject.Name;
            }
            else if (!string.IsNullOrWhiteSpace(this.ServiceTopologyResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ServiceTopologyResourceId);
                this.ServiceTopologyName = parsedResourceId.ResourceName;
            }
        }
    }
}
