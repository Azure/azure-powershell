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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The policy definition properties.
    /// </summary>
    public class PolicySetDefinitionProperties
    {
        /// <summary>
        /// The description.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Description { get; set; }

        /// <summary>
        /// The display name.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string DisplayName { get; set; }

        /// <summary>
        /// The policy set definition metadata.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public JObject Metadata { get; set; }

        /// <summary>
        /// The policy reference.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public JArray PolicyDefinitions { get; set; }

        /// <summary>
        /// The parameters declaration.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public JObject Parameters { get; set; }
    }
}
