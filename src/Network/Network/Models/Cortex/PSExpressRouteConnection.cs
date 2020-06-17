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
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSExpressRouteConnection : PSChildResource
    {
        [Ps1Xml(Label = "ExpressRoute Circuit Peering", Target = ViewControl.Table, ScriptBlock = "$_.ExpressRouteCircuitPeering.Id")]
        public PSExpressRouteCircuitPeeringId ExpressRouteCircuitPeering { get; set; }

        [Ps1Xml(Label = "Authorization Key", Target = ViewControl.Table)]
        public string AuthorizationKey { get; set; }

        [Ps1Xml(Label = "Routing Weight", Target = ViewControl.Table)]
        public uint RoutingWeight { get; set; }

        [Ps1Xml(Label = "Internet Security Enabled", Target = ViewControl.Table)]
        public bool EnableInternetSecurity { get; set; }

        public PSRoutingConfiguration RoutingConfiguration { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string ExpressRouteCircuitPeeringText
        {
            get { return JsonConvert.SerializeObject(ExpressRouteCircuitPeering, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RoutingConfigurationText
        {
            get { return JsonConvert.SerializeObject(RoutingConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
