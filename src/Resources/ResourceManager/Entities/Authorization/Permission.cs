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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Authorization
{
    using Newtonsoft.Json;

    /// <summary>
    /// The permission.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "By design.")]
    public class Permission
    {
        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string[] Actions { get; set; }

        /// <summary>
        /// Gets or sets the not actions.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string[] NotActions { get; set; }
    }
}
