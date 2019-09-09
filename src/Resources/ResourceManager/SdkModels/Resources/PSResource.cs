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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkExtensions;
using Microsoft.Azure.Management.ResourceManager.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSResource
    {
        public string ResourceId { get; set; }

        public string Id { get; set; }

        public Identity Identity { get; set; }

        public string Kind { get; set; }

        public string Location { get; set; }

        public string ManagedBy { get; set; }

        public string ResourceName { get; set; }

        public string Name { get; set; }

        public string ExtensionResourceName { get; set; }

        public string ParentResource { get; set; }

        public Plan Plan { get; set; }

        public PSObject Properties { get; set; }

        public string ResourceGroupName { get; set; }

        public string Type { get; set; }

        public string ResourceType { get; set; }

        public string ExtensionResourceType { get; set; }

        public Sku Sku { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public string SubscriptionId { get; set; }

        public DateTime? CreatedTime { get; set; }

        public DateTime? ChangedTime { get; set; }

        public string ETag { get; set; }

        public PSResource(GenericResource resource)
        {
            this.ResourceId = resource.Id;
            this.Id = resource.Id;
            this.Identity = resource.Identity;
            this.Kind = resource.Kind;
            this.Location = resource.Location;
            this.ManagedBy = resource.ManagedBy;
            this.ResourceName = resource.Name;
            this.Name = resource.Name;
            this.Plan = resource.Plan;
            this.Properties = ((JToken)resource.Properties).ToPsObject();
            this.ResourceType = resource.Type;
            this.Sku = resource.Sku;
            this.Tags = resource.Tags;
            this.Type = resource.Type;

            var resourceIdentifier = new ResourceIdentifier(this.Id);
            this.ParentResource = resourceIdentifier.ParentResource;
            this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
        }

        public PSResource(Resource<JToken> resource)
        {
            this.Name = resource.Name;
            this.ResourceName = resource.Name;
            this.ResourceId = resource.Id;
            this.Id = resource.Id;
            this.Type = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetResourceType(resource.Id);
            this.ResourceType = Type;
            this.ExtensionResourceName = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetExtensionResourceName(resource.Id);
            this.ExtensionResourceType = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetExtensionResourceType(resource.Id);
            this.Kind = resource.Kind;
            this.ResourceGroupName = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetResourceGroupName(resource.Id);
            this.Location = resource.Location;
            this.SubscriptionId = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetSubscriptionId(resource.Id);
            this.Tags = TagsHelper.GetTagsDictionary(TagsHelper.GetTagsHashtable(resource.Tags));
            this.Properties = resource.Properties == null ? null : resource.Properties.ToPsObject();
            this.CreatedTime = resource.CreatedTime;
            this.ChangedTime = resource.ChangedTime;
            this.ETag = resource.ETag;
            this.Plan = resource.Plan == null ? null : new Plan
            {
                Name = resource.Plan.Name,
                Publisher = resource.Plan.Publisher,
                Product = resource.Plan.Product,
                PromotionCode = resource.Plan.PromotionCode,
                Version = resource.Plan.Version
            };
            this.Sku = resource.Sku == null ? null : new Sku
            {
                Name = resource.Sku.Name,
                Tier = resource.Sku.Tier,
                Size = resource.Sku.Size,
                Family = resource.Sku.Family,
                Capacity = resource.Sku.Capacity
            };

            if (resource.Identity != null)
            {
                this.Identity = new Identity(resource.Identity.PrincipalId, resource.Identity.TenantId);
                if (Enum.TryParse(resource.Identity.Type, out Management.ResourceManager.Models.ResourceIdentityType type))
                {
                    this.Identity.Type = type;
                }

            }
        }
    }
}
