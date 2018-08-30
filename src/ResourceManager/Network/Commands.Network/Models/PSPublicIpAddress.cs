﻿// ----------------------------------------------------------------------------------
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
    using WindowsAzure.Commands.Common.Attributes;

    public class PSPublicIpAddress : PSTopLevelResource
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string PublicIpAllocationMethod { get; set; }

        public PSPublicIpAddressSku Sku { get; set; }

        public PSIPConfiguration IpConfiguration { get; set; }

        public PSPublicIpAddressDnsSettings DnsSettings { get; set; }

        public List<PSPublicIpTag> IpTags {get; set;}

        [Ps1Xml(Target = ViewControl.Table)]
        public string IpAddress { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string PublicIpAddressVersion { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public int? IdleTimeoutInMinutes { get; set; }

        public List<string> Zones { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string IpConfigurationText
        {
            get { return JsonConvert.SerializeObject(IpConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DnsSettingsText
        {
            get { return JsonConvert.SerializeObject(DnsSettings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string IpTagsText
        {
            get { return JsonConvert.SerializeObject(IpTags, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SkuText
        {
            get { return JsonConvert.SerializeObject(Sku, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
