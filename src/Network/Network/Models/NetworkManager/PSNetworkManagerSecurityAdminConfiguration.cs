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
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSNetworkManagerSecurityAdminConfiguration : PSNetworkManagerBaseResource
    {
        public string NetworkManagerName { get; set; }

        public string SecurityType { get; set; }

        public List<string> ApplyOnNetworkIntentPolicyBasedServices { get; set; }

        [JsonIgnore]
        public string ApplyOnNetworkIntentPolicyBasedServicesText
        {
            get { return JsonConvert.SerializeObject(ApplyOnNetworkIntentPolicyBasedServices, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
        public string NetworkGroupAddressSpaceAggregationOption { get; set; }

        public string DeleteExistingNSGs { get; set; }
    }
}
