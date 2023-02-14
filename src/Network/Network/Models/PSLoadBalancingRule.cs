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

using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSLoadBalancingRule : PSChildResource
    {
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string Protocol { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string LoadDistribution { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public int FrontendPort { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public int BackendPort { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public int? IdleTimeoutInMinutes { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public bool? EnableFloatingIP { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public bool? EnableTcpReset { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public bool? DisableOutboundSNAT { get; set; }
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
        [JsonProperty(Order = 1)]
        public PSResourceId FrontendIPConfiguration { get; set; }
        [JsonProperty(Order = 1)]
        public PSResourceId BackendAddressPool { get; set; }
        [JsonProperty(Order = 1)]
        public List<PSResourceId> BackendAddressPools { get; set; }
        [JsonProperty(Order = 1)]
        public PSResourceId Probe { get; set; }

        [JsonIgnore]
        public string FrontendIPConfigurationText
        {
            get { return JsonConvert.SerializeObject(FrontendIPConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string BackendAddressPoolText
        {
            get { return JsonConvert.SerializeObject(BackendAddressPool, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string BackendAddressPoolsText
        {
            get { return JsonConvert.SerializeObject(BackendAddressPools, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ProbeText
        {
            get { return JsonConvert.SerializeObject(Probe, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeFrontendPort()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeBackendPort()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
