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

    public class PSNetworkManagerConnectivityConfiguration : PSNetworkManagerBaseResource
    {
        public string NetworkManagerName { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ConnectivityTopology { get; set; }

        public IList<PSNetworkManagerHub> Hubs { get; set; }

        public string DeleteExistingPeering { get; set; }

        public string IsGlobal { get; set; }

        [JsonProperty(Order = 1)]
        public IList<PSNetworkManagerConnectivityGroupItem> AppliesToGroups { get; set; }

        [JsonIgnore]
        public string AppliesToGroupsText
        {
            get { return JsonConvert.SerializeObject(AppliesToGroups, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string HubsText
        {
            get { return JsonConvert.SerializeObject(Hubs, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}

