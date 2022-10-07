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

    public class PSCustomIpPrefix : PSTopLevelResource
    {
        public string Cidr { get; set; }

        public string Geo { get; set; }

        public string Asn { get; set; }

        public string CommissionedState { get; set; }

        public List<PSResourceId> PublicIpPrefixes { get; set; }

        public List<string> Zones { get; set; }

        public string ProvisioningState { get; set; }

        public string SignedMessage { get; set; }

        public string AuthorizationMessage { get; set; }

        public PSResourceId CustomIpPrefixParent { get; set; }

        public List<PSResourceId> ChildCustomIpPrefixes { get; set; }

        public bool? NoInternetAdvertise { get; set; }

        public bool? ExpressRouteAdvertise { get; set; }

        public string PrefixType { get; set; }

        [JsonIgnore]
        public string PublicIpPrefixesText
        {
            get { return JsonConvert.SerializeObject(PublicIpPrefixes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string CustomIpPrefixParentText
        {
            get { return JsonConvert.SerializeObject(new PSResourceId() { Id = CustomIpPrefixParent.Id }, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ChildCustomIpPrefixesText
        {
            get { return JsonConvert.SerializeObject(ChildCustomIpPrefixes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
