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

    public class PSExpressRouteGateway : PSTopLevelResource
    {
        public List<PSExpressRouteConnection> ExpressRouteConnections { get; set; }

        [Ps1Xml(Label = "VirtualHub", Target = ViewControl.Table, ScriptBlock = "$_.VirtualHub.Id")]
        public PSVirtualHubId VirtualHub { get; set; }

        [Ps1Xml(Label = "AutoScaleConfiguration", Target = ViewControl.Table)]
        public PSExpressRouteGatewayAutoscaleConfiguration AutoScaleConfiguration { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string AllowNonVirtualWanTraffic { get; set; }

        [JsonIgnore]
        public string VirtualHubText
        {
            get { return JsonConvert.SerializeObject(VirtualHub, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string AutoScaleConfigurationText
        {
            get { return JsonConvert.SerializeObject(AutoScaleConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ExpressRouteConnectionsText
        {
            get { return JsonConvert.SerializeObject(ExpressRouteConnections, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}