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

namespace Microsoft.Azure.Commands.Network.Models
{
    using Microsoft.Azure.Management.Internal.Resources.Utilities;
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PSConnectionMonitorResult : PSChildResource
    {
        public string ProvisioningState { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        [JsonProperty(Order = 1)]
        public PSConnectionMonitorSource Source { get; set; }

        [JsonProperty(Order = 1)]
        public PSConnectionMonitorDestination Destination { get; set; }

        public bool? AutoStart { get; set; }

        public int? MonitoringIntervalInSeconds { get; set; }

        public DateTime? StartTime { get; set; }

        public string MonitoringStatus { get; set; }

        public Dictionary<string, string> Tags { get; set; }

        [JsonIgnore]
        public string SourceText
        {
            get { return JsonConvert.SerializeObject(this.Source, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DestinationText
        {
            get { return JsonConvert.SerializeObject(this.Destination, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string TagsText
        {
            get { return JsonConvert.SerializeObject(this.Tags, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
