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
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSNetworkInterface : PSTopLevelResource
    {
        public PSResourceId VirtualMachine { get; set; }

        public List<PSNetworkInterfaceIPConfiguration> IpConfigurations { get; set; }

        public PSNetworkInterfaceDnsSettings DnsSettings { get; set; }

        public string MacAddress { get; set; }

        public bool? Primary { get; set; }

        public bool? EnableIPForwarding { get; set; }

        public PSNetworkSecurityGroup NetworkSecurityGroup { get; set; }

        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string VirtualMachineText
        {
            get { return JsonConvert.SerializeObject(VirtualMachine, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string IpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(IpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DnsSettingsText
        {
            get { return JsonConvert.SerializeObject(this.DnsSettings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string NetworkSecurityGroupText
        {
            get { return JsonConvert.SerializeObject(NetworkSecurityGroup, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeIpConfigurations()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
