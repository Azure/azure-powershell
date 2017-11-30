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
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSRouteMetadata
    {
        /// <summary>
        /// The name of the route. name can only include alphanumeric
        /// characters, periods, underscores, hyphens with maximum length of
        /// 64 characters and must be unique.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The condition which is evaluated in order to apply the routing rule.
        /// </summary>
        [JsonProperty(PropertyName = "condition")]
        public string Condition { get; set; }

        /// <summary>
        /// The list of endpoints to which the messages that satisfy the
        /// condition are routed to.
        /// </summary>
        [JsonProperty(PropertyName = "endpointNames")]
        public IList<string> EndpointNames { get; set; }

        /// <summary>
        /// Used to specify whether a route is enabled or not.
        /// </summary>
        [JsonProperty(PropertyName = "isEnabled")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// The source to which the routing rule is to be applied to. e.g.
        /// DeviceMessages
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

    }
}
