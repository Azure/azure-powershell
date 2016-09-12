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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Collections;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// The resource definition object.
    /// </summary>
    public class Resource<TProperties>
    {
        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public TProperties Properties { get; set; }

        /// <summary>
        /// Gets or sets the id for the resource.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the resource definition.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Type { get; set; }

        /// <summary>  
        /// Gets or sets the resource <c>sku</c>.  
        /// </summary>  
        [JsonProperty(Required = Required.Default)]
        public ResourceSku Sku { get; set; }


        /// <summary>
        /// Gets or sets the kind of the resource definition.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the resource location.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the <c>etag</c>.
        /// </summary>
        [JsonProperty(Required = Required.Default, PropertyName = "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Gets or sets the resource plan.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public ResourcePlan Plan { get; set; }

        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public DateTime? CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the changed time.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public DateTime? ChangedTime { get; set; }

        /// <summary>
        /// Gets or sets the zones.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string[] Zones { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public InsensitiveDictionary<string> Tags { get; set; }
    }
}
