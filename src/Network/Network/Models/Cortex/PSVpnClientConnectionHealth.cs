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
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;

    public class PSVpnClientConnectionHealth
    {
        [Ps1Xml(Label = "VpnClient connections count", Target = ViewControl.Table)]
        public int VpnClientConnectionsCount { get; set; }

        public List<string> AllocatedIpAddresses { get; set; }

        [Ps1Xml(Label = "Total ingress bytes transferred", Target = ViewControl.Table)]
        public ulong TotalIngressBytesTransferred { get; set; }

        [Ps1Xml(Label = "Total egress bytes transferred", Target = ViewControl.Table)]
        public ulong TotalEgressBytesTransferred { get; set; }

        [JsonIgnore]
        public string AllocatedIpAddressesText
        {
            get { return JsonConvert.SerializeObject(AllocatedIpAddresses, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}