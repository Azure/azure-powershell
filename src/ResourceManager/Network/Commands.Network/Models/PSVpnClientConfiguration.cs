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
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVpnClientConfiguration
    {
        public PSAddressSpace VpnClientAddressPool { get; set; }

        public List<PSVpnClientRevokedCertificate> VpnClientRevokedCertificates { get; set; }

        public List<PSVpnClientRootCertificate> VpnClientRootCertificates { get; set; }


        [JsonIgnore]
        public string VpnClientAddressPoolText
        {
            get { return JsonConvert.SerializeObject(VpnClientAddressPool, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VpnClientRevokedCertificatesText
        {
            get { return JsonConvert.SerializeObject(VpnClientRevokedCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VpnClientRootCertificatesText
        {
            get { return JsonConvert.SerializeObject(VpnClientRootCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
