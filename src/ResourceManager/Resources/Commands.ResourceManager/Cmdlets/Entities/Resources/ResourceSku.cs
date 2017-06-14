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

using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources
{
    /// <summary>
    /// The resource sku object.
    /// </summary>
    public class ResourceSku
    {
        /// <summary>
        /// Gets or sets the <c>sku</c> name.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the <c>sku</c> tier.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Tier { get; set; }

        /// <summary>
        /// Gets or sets the <c>sku</c> size.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the <c>sku</c> family.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets the <c>sku</c> capacity.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public int? Capacity { get; set; }
    }
}

