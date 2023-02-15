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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
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

        public string TagsTable
        {
            get { return ResourcesExtensions.ConstructTagsTable(TagsConversionHelper.CreateTagHashtable(Tags)); }
        }

        public string SubscriptionId { get; set; }

        public DateTime? CreatedTime { get; set; }

        public DateTime? ChangedTime { get; set; }

        public string ETag { get; set; }

        private PSResource(string id, string name, string kind, string location, string type, Identity identity, PSObject properties, Plan plan, Sku sku, IDictionary<string, string> tags)
        {
            this.ResourceId = id;
            this.Id = id;
            this.ResourceName = name;
            this.Name = name;
            this.Kind = kind;
            this.Location = location;
            this.ResourceType = type;
            this.Type = type;
            this.Identity = identity;
            this.Properties = properties;
            this.Plan = plan;
            this.Sku = sku;
            this.Tags = tags;
        }

        public PSResource(GenericResource resource): this(
            resource.Id,
            resource.Name,
            resource.Kind,
            resource.Location,
            resource.Type,
            resource.Identity,
            ((JToken)resource.Properties).ToPsObject(),
            resource.Plan,
            resource.Sku,
            resource.Tags
        )
        {
            ResourceIdentifier resourceId = new ResourceIdentifier(resource.Id);
            this.SubscriptionId = resourceId.Subscription;
            this.ResourceGroupName = resourceId.ResourceGroupName;
            this.ParentResource = resourceId.ParentResource;
            this.ManagedBy = resource.ManagedBy;
        }

        public PSResource(GenericResourceExpanded resource) : this(
            (GenericResource)resource
        )
        {
            this.CreatedTime = resource.CreatedTime;
            this.ChangedTime = resource.ChangedTime;
        }

        public PSResource(Resource<JToken> resource): this(
            resource.Id,
            resource.Name,
            resource.Kind,
            resource.Location,
            string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetResourceType(resource.Id),
            resource.Identity == null ? null : new Identity(resource.Identity.PrincipalId, resource.Identity.TenantId),
            resource.Properties?.ToPsObject(),
            resource.Plan == null ? null : new Plan
            {
                Name = resource.Plan.Name,
                Publisher = resource.Plan.Publisher,
                Product = resource.Plan.Product,
                PromotionCode = resource.Plan.PromotionCode,
                Version = resource.Plan.Version
            },
            resource.Sku == null ? null : new Sku
            {
                Name = resource.Sku.Name,
                Tier = resource.Sku.Tier,
                Size = resource.Sku.Size,
                Family = resource.Sku.Family,
                Capacity = resource.Sku.Capacity
            },
            TagsHelper.GetTagsDictionary(TagsHelper.GetTagsHashtable(resource.Tags))
        )
        {
            if ( resource.Properties["creationTime"] == null) { this.CreatedTime = null;} else {this.CreatedTime = Convert.ToDateTime(resource.Properties["creationTime"]);}
            if ( resource.Properties["lastModifiedTime"] == null) { this.ChangedTime = null;} else {this.ChangedTime = Convert.ToDateTime(resource.Properties["lastModifiedTime"]);}
            this.SubscriptionId = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetSubscriptionId(resource.Id);
            this.ResourceGroupName = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetResourceGroupName(resource.Id);
            this.ExtensionResourceName = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetExtensionResourceName(resource.Id);
            this.ExtensionResourceType = string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetExtensionResourceType(resource.Id);
            this.ETag = resource.ETag;
            if (resource.Identity != null)
            {
                if (Enum.TryParse(resource.Identity.Type, out Management.ResourceManager.Models.ResourceIdentityType type))
                {
                    this.Identity.Type = type;
                }
            }
        }
    }
}
