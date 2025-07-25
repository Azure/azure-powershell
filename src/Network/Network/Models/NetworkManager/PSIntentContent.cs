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

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSIntentContent
    {
        public string SourceResourceId { get; set; }
        public string DestinationResourceId { get; set; }
        public PSIPTraffic IpTraffic { get; set; }

        [JsonIgnore]
        public string IntentContentText
        {
            get
            {
                var contentDetails = new
                {
                    SourceResourceId,
                    DestinationResourceId,
                    IpTraffic
                };
                return JsonConvert.SerializeObject(contentDetails, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            }
        }
    }
}