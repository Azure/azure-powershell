//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//


namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSNetworkManagerSecurityUserRule : PSNetworkManagerBaseResource
    {
        public string Protocol { get; set; }

        public string Direction { get; set; }

        public IList<PSNetworkManagerAddressPrefixItem> Sources { get; set; }

        public IList<PSNetworkManagerAddressPrefixItem> Destinations { get; set; }

        public IList<string> SourcePortRanges { get; set; }

        public IList<string> DestinationPortRanges { get; set; }

        public string NetworkManagerName { get; set; }

        public string SecurityUserConfigurationName { get; set; }

        public string RuleCollectionName { get; set; }

        [JsonIgnore]
        public string SourcesText
        {
            get { return JsonConvert.SerializeObject(Sources, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DestinationsText
        {
            get { return JsonConvert.SerializeObject(Destinations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SourcePortRangesText
        {
            get { return JsonConvert.SerializeObject(SourcePortRanges, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DestinationPortRangesText
        {
            get { return JsonConvert.SerializeObject(DestinationPortRanges, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
