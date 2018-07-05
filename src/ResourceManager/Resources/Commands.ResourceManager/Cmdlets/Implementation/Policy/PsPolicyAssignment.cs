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

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy
{
    using System.Management.Automation;
    using Components;
    using Extensions;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Class that wraps a policy definition PSObject
    /// </summary>
    public class PsPolicyAssignment
    {
        public PsPolicyAssignment(JToken input)
        {
            var resource = input.ToResource();
            this.Name = resource.Name;
            this.PolicyAssignmentId = resource.Id;
            this.Properties = resource.Properties.ToPsObject();
            this.ResourceId = resource.Id;
            this.ResourceName = resource.Name;
            this.ResourceGroupName = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetResourceGroupName(resource.Id);
            this.ResourceType = resource.Type;
            this.Sku = resource.Sku.ToJToken().ToPsObject();
            this.SubscriptionId = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetSubscriptionId(resource.Id);
        }

        public string Name { get; set; }
        public string ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceGroupName { get; set; }
        public string ResourceType { get; set; }
        public string SubscriptionId { get; set; }
        public PSObject Sku { get; set; }
        public PSObject Properties { get; set; }
        public string PolicyAssignmentId { get; set; }
    }
}
