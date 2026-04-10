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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    /// <summary>
    /// Options for creating a deny assignment.
    /// </summary>
    public class CreateDenyAssignmentOptions
    {
        [JsonProperty("denyAssignmentName")]
        public string DenyAssignmentName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("actions")]
        public List<string> Actions { get; set; } = new List<string>();

        [JsonProperty("notActions")]
        public List<string> NotActions { get; set; } = new List<string>();

        [JsonProperty("dataActions")]
        public List<string> DataActions { get; set; } = new List<string>();

        [JsonProperty("notDataActions")]
        public List<string> NotDataActions { get; set; } = new List<string>();

        [JsonProperty("principalIds")]
        public List<string> PrincipalIds { get; set; } = new List<string>();

        [JsonProperty("excludePrincipalIds")]
        public List<string> ExcludePrincipalIds { get; set; } = new List<string>();

        [JsonProperty("excludePrincipalTypes")]
        public List<string> ExcludePrincipalTypes { get; set; }

        /// <summary>
        /// Legacy single-value property for backward compatibility with input files.
        /// When set, applies to all exclude principals unless ExcludePrincipalTypes is also provided.
        /// </summary>
        [JsonProperty("excludePrincipalType")]
        public string ExcludePrincipalType { get; set; }

        [JsonProperty("doNotApplyToChildScopes")]
        public bool DoNotApplyToChildScopes { get; set; }
    }
}
