﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Management.IotHub.Models;

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{    
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSRoutingProperties
    {
        /// <summary>
        /// Routing endpoints
        /// </summary>
        [JsonProperty(PropertyName = "endpoints")]
        public PSRoutingEndpoints Endpoints { get; set; }

        /// <summary>
        /// The list of routing rules that users can provide.
        /// </summary>
        [JsonProperty(PropertyName = "routes")]
        public List<PSRouteMetadata> Routes { get; set; }

        /// <summary>
        /// The properties of the route that will be used as a fallback route        
        /// </summary>
        [JsonProperty(PropertyName = "fallbackRoute")]
        public PSFallbackRouteMetadata FallbackRoute { get; set; }


    }
}
