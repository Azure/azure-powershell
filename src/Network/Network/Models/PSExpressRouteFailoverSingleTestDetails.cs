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

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSExpressRouteFailoverSingleTestDetails : PSChildResource
    {
        public string PeeringLocation { get; set; }

        public string Status { get; set; }

        public string StartTimeUtc { get; set; }

        public string EndTimeUtc { get; set; }

        public List<PSExpressRouteFailoverRedundantRoute> RedundantRoutes { get; set; }

        public List<string> NonRedundantRoutes { get; set; }

        public bool WasSimulationSuccessful { get; set; }

        public List<PSFailoverConnectionDetails> FailoverConnectionDetails { get; set; }

        [JsonIgnore]
        public string RedundantRoutesText => JsonConvert.SerializeObject(RedundantRoutes, Formatting.Indented);

        [JsonIgnore]
        public string NonRedundantRoutesText => JsonConvert.SerializeObject(NonRedundantRoutes, Formatting.Indented);

        [JsonIgnore]
        public string FailoverConnectionDetailsText => JsonConvert.SerializeObject(FailoverConnectionDetails, Formatting.Indented);
    }
}
