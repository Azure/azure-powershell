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
    using Newtonsoft.Json;

    /// <summary>
    /// The resource plan object.
    /// </summary>
    public class ResourcePlan
    {
        /// <summary>
        /// Gets or sets the plan name.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the plan's promotion code.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string PromotionCode { get; set; }

        /// <summary>
        /// Gets or sets the plan's product code.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Product { get; set; }

        /// <summary>
        /// Gets or sets the plan's publisher.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Publisher { get; set; }
    }
}
