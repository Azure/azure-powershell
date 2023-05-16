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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The policy exemption object.
    /// </summary>
    public class PsPolicyExemption
    {
        public PsPolicyExemption(JToken input)
        {
            var resource = input.ToResourceWithSystemData();
            Name = resource.Name;
            Properties = new PsPolicyExemptionProperties(resource.Properties);
            ResourceId = resource.Id;
            ResourceName = resource.Name;
            ResourceGroupName = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetResourceGroupName(resource.Id);
            ResourceType = resource.Type;
            SubscriptionId = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetSubscriptionId(resource.Id);
            SystemData = resource.SystemData.ToPsObject();
        }

        /// <summary>
        /// Gets or sets the policy exemption properties.
        /// </summary>
        public PsPolicyExemptionProperties Properties { get; set; }

        /// <summary>
        /// Gets or sets the resource system data.
        /// </summary>
        public PSObject SystemData { get; set; }

        /// <summary>
        /// The policy exemption name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The resource Id of the policy exemption
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// The resource name of the policy exemption
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// The corresponding resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The exemption resource type
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// The corresponding subscription Id
        /// </summary>
        public string SubscriptionId { get; set; }
    }
}