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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Locks
{
    using Newtonsoft.Json;

    /// <summary>
    /// The lock properties.
    /// </summary>
    public class LockProperties
    {
        /// <summary>
        /// The lock level.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public LockLevel Level { get; set; }

        /// <summary>
        /// The lock notes.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Notes { get; set; }
    }
}
