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
using System.Linq;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Private endpoint which the connection belongs to.
    /// </summary>
    public class PSPrivateEndpointProperty
    {
        /// <summary>
        /// Initializes a new instance of the PrivateEndpointProperty class.
        /// </summary>
        /// <param name="id">Resource id of the private endpoint.</param>
        public PSPrivateEndpointProperty(string id = default(string))
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets resource id of the private endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
