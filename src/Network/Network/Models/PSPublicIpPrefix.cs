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

    public class PSPublicIpPrefix : PSTopLevelResource
    {
        public PSPublicIpPrefixSku Sku { get; set; }

        public List<PSPublicIpPrefixTag> IpTags { get; set; }

        public string PublicIpAddressVersion { get; set; }

        public List<string> Zones { get; set; }

        public string ProvisioningState { get; set; }

        public ushort PrefixLength { get; set; }

        public string IPPrefix { get; set; }

        public List<PSPublicIpAddress> PublicIpAddresses { get; set; }

        public PSResourceId CustomIpPrefix { get; set; }

        [JsonIgnore]
        public string PublicIpAddressesText
        {
           get { return JsonConvert.SerializeObject(PublicIpAddresses, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
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
