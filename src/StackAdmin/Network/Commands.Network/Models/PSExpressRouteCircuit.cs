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

    public class PSExpressRouteCircuit : PSTopLevelResource
    {
        public bool? AllowClassicOperations { get; set; }

        public string CircuitProvisioningState { get; set; }

        public string ServiceProviderProvisioningState { get; set; }

        public List<PSPeering> Peerings { get; set; }

        public List<PSExpressRouteCircuitAuthorization> Authorizations { get; set; }

        public string ServiceKey { get; set; }

        public string ServiceProviderNotes { get; set; }

        public PSServiceProviderProperties ServiceProviderProperties { get; set; }

        public PSExpressRouteCircuitSku Sku { get; set; }

        public string ProvisioningState { get; set; }

        public string GatewayManagerEtag { get; set; } 

        [JsonIgnore]
        public string SkuText
        {
            get { return JsonConvert.SerializeObject(Sku, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ServiceProviderPropertiesText
        {
            get { return JsonConvert.SerializeObject(ServiceProviderProperties, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PeeringsText
        {
            get { return JsonConvert.SerializeObject(Peerings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string AuthorizationsText
        {
            get { return JsonConvert.SerializeObject(Authorizations, Formatting.Indented); }
        }
    }
}
