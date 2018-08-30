﻿//
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
    using WindowsAzure.Commands.Common.Attributes;

    public class PSBackendAddressPool : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public List<PSNetworkInterfaceIPConfiguration> BackendIpConfigurations { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSResourceId> LoadBalancingRules { get; set; }

        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string BackendIpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(BackendIpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string LoadBalancingRulesText
        {
            get { return JsonConvert.SerializeObject(LoadBalancingRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeBackendIpConfigurations()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeLoadBalancingRules()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
