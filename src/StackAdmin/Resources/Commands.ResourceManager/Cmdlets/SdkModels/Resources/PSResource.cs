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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkExtensions;
using Microsoft.Azure.Management.ResourceManager.Models;
using System.Collections;
using System.Collections.Generic;

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

        public string Name { get; set; }

        public string ParentResource { get; set; }

        public Plan Plan { get; set; }

        public object Properties { get; set; }

        public string ResourceGroupName { get; set; }

        public string ResourceType { get; set; }

        public Sku Sku { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public string Type { get; set; }

        public PSResource(GenericResource resource)
        {
            this.ResourceId = resource.Id;
            this.Id = resource.Id;
            this.Identity = resource.Identity;
            this.Kind = resource.Kind;
            this.Location = resource.Location;
            this.ManagedBy = resource.ManagedBy;
            this.Name = resource.Name;
            this.Plan = resource.Plan;
            this.Properties = resource.Properties;
            this.ResourceType = resource.Type;
            this.Sku = resource.Sku;
            this.Tags = resource.Tags;
            this.Type = resource.Type;

            var resourceIdentifier = new ResourceIdentifier(this.Id);
            this.ParentResource = resourceIdentifier.ParentResource;
            this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
        }
    }
}
