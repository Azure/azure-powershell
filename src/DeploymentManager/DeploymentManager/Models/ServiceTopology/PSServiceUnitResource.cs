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

namespace Microsoft.Azure.Commands.DeploymentManager.Models
{
    using System;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.DeploymentManager.Models;

    public class PSServiceUnitResource : PSResource
    {
        public PSServiceUnitResource() : base()
        {
        }

        public PSServiceUnitResource(
            string resourceGroup,
            string serviceTopologyName,
            string serviceName,
            ServiceUnitResource serviceUnitResource) : base(serviceUnitResource)
        {
            this.ResourceGroupName = resourceGroup;
            this.DeploymentMode = serviceUnitResource.DeploymentMode.ToString();
            this.ServiceTopologyName = serviceTopologyName;
            this.ServiceName = serviceName;
            this.TargetResourceGroup = serviceUnitResource.TargetResourceGroup;
            this.TemplateUri = serviceUnitResource.Artifacts.TemplateUri;
            this.ParametersUri = serviceUnitResource.Artifacts.ParametersUri;
            this.ParametersArtifactSourceRelativePath = serviceUnitResource.Artifacts.ParametersArtifactSourceRelativePath;
            this.TemplateArtifactSourceRelativePath = serviceUnitResource.Artifacts.TemplateArtifactSourceRelativePath;
        }

        /// <summary>
        /// Gets or sets the resource group to which the service unit belongs.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the service topology the service unit belongs to.
        /// </summary>
        public string ServiceTopologyName { get; set; }

        /// <summary>
        /// Gets or sets the service the service unit belongs to.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the resource group to which the resources in the topology group should be deployed to.
        /// </summary>
        public string TargetResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets describes the type of ARM deployment to be performed
        /// on the resource. Possible values include: 'Complete', 'Incremental'
        /// </summary>
        public string DeploymentMode { get; set; }

        /// <summary>
        /// Gets or sets the SAS URI of the ARM template.
        /// </summary>
        public string TemplateUri { get; set; }

        /// <summary>
        /// Gets or sets the SAS URI of the ARM parameters file.
        /// </summary>
        public string ParametersUri { get; set; }

        /// <summary>
        /// Gets or sets the relative path of the ARM parameters file from the artifact source for this topology.
        /// </summary>
        public string ParametersArtifactSourceRelativePath { get; set; }

        /// <summary>
        /// Gets or sets the relative path of the ARM template file from the artifact source for this topology.
        /// </summary>
        public string TemplateArtifactSourceRelativePath { get; set; }

        internal ServiceUnitResource ToSdkType()
        {
            return new ServiceUnitResource(
                location: this.Location, 
                targetResourceGroup: this.TargetResourceGroup, 
                deploymentMode: (DeploymentMode)Enum.Parse(typeof(DeploymentMode), this.DeploymentMode, ignoreCase: true),
                id: this.Id, 
                name: this.Name, 
                type: this.Type, 
                tags: TagsConversionHelper.CreateTagDictionary(this.Tags, validate: true))
            {
                Artifacts = new ServiceUnitArtifacts()
                {
                    TemplateUri = this.TemplateUri,
                    ParametersUri = this.ParametersUri,
                    TemplateArtifactSourceRelativePath = this.TemplateArtifactSourceRelativePath,
                    ParametersArtifactSourceRelativePath = this.ParametersArtifactSourceRelativePath
                }
            };
        }
    }
}
