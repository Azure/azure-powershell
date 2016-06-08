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

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    public class PSApplicationGatewayUrlPathMap : PSChildResource
    {
        public PSResourceId DefaultBackendAddressPool { get; set; }
        public PSResourceId DefaultBackendHttpSettings { get; set; }
        public List<PSApplicationGatewayPathRule> PathRules { get; set; }
        public string ProvisioningState { get; set; }
        [JsonIgnore]
        public string DefaultBackendAddressPoolText
        {
            get { return JsonConvert.SerializeObject(DefaultBackendAddressPool, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DefaultBackendHttpSettingsText
        {
            get { return JsonConvert.SerializeObject(DefaultBackendHttpSettings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PathRulesText
        {
            get { return JsonConvert.SerializeObject(PathRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
