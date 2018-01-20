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

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSSecureGateway : PSTopLevelResource
    {
        public PSSecureGatewaySku Sku { get; set; }

        public PSResourceId VirtualHub { get; set; }

        public PSResourceId VirtualNetwork { get; set; }

        public List<PSSecureGatewayApplicationRuleCollection> ApplicationRuleCollections { get; set; }

        public List<PSSecureGatewayNetworkRuleCollection> NetworkRuleCollections { get; set; }
        
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string SkuText
        {
            get { return JsonConvert.SerializeObject(Sku, Formatting.Indented); }
        }

        [JsonIgnore]
        public string VirtualHubText
        {
            get { return JsonConvert.SerializeObject(VirtualHub, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VirtualNetworkText
        {
            get { return JsonConvert.SerializeObject(VirtualNetwork, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ApplicationRuleCollectionsText
        {
            get { return JsonConvert.SerializeObject(ApplicationRuleCollections, Formatting.Indented); }
        }

        [JsonIgnore]
        public string NetworkRuleCollectionsText
        {
            get { return JsonConvert.SerializeObject(NetworkRuleCollections, Formatting.Indented); }
        }
    }
}
