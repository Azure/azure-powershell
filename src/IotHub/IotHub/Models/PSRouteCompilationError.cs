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

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Compilation error when evaluating route
    /// </summary>
    public partial class PSRouteCompilationError
    {
        /// <summary>
        /// Gets or sets route error message
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets severity of the route error. Possible values include:
        /// 'error', 'warning'
        /// </summary>
        [JsonProperty(PropertyName = "severity")]
        public string Severity { get; set; }

        /// <summary>
        /// Gets or sets location where the route error happened
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public PSRouteErrorRange Location { get; set; }
    }
}


