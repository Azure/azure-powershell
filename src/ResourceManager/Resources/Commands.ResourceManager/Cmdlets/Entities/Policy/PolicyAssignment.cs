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

    /// <summary>
    /// The policy assignment object.
    /// </summary>
    public class PolicyAssignment
    {
        /// <summary>
        /// The policy assignment properties.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public PolicyAssignmentProperties Properties { get; set; }

        /// <summary>
        /// The policy assignment name.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Name { get; set; }
    }
}