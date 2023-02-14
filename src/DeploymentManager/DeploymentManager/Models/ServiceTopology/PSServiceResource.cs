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
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.DeploymentManager.Models;

    public class PSServiceResource : PSResource
    {
        public PSServiceResource() : base()
        {
        }

        public PSServiceResource(
            string resourceGroup,
            string serviceTopologyName,
            ServiceResource serviceResource) : base(serviceResource)
        {
            this.ResourceGroupName = resourceGroup;
            this.ServiceTopologyName = serviceTopologyName;
            this.TargetSubscriptionId = serviceResource.TargetSubscriptionId;
            this.TargetLocation = serviceResource.TargetLocation;
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
        /// Gets or sets the subscription to which the resources in the topology group should be deployed to.
        /// </summary>
        public string TargetSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the location where the resources in the topology group should be deployed to.
        /// </summary>
        public string TargetLocation { get; set; }

        internal ServiceResource ToSdkType()
        {
            return new ServiceResource(
                location: this.Location, 
                targetLocation: this.TargetLocation, 
                targetSubscriptionId: this.TargetSubscriptionId, 
                id: this.Id, 
                name: this.Name, 
                type: this.Type, 
                tags: TagsConversionHelper.CreateTagDictionary(this.Tags, validate: true));
        }
    }
}
