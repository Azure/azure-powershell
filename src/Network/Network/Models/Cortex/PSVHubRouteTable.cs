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
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;

    public class PSVHubRouteTable : PSChildResource
    {
        public List<PSVHubRoute> Routes { get; set; }

        [Ps1Xml(Label = "Labels", Target = ViewControl.Table)]
        public List<string> Labels { get; set; }

        public List<string> AssociatedConnections { get; set; }

        public List<string> PropagatingConnections { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string RoutesText
        {
            get { return JsonConvert.SerializeObject(Routes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
        
        [JsonIgnore]
        public string AssociatedConnectionsText
        {
            get { return JsonConvert.SerializeObject(AssociatedConnections, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
        
        [JsonIgnore]
        public string PropagatingConnectionsText
        {
            get { return JsonConvert.SerializeObject(PropagatingConnections, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }

    public class PSVHubRoute
    {
        [Ps1Xml(Label = "Name", Target = ViewControl.Table)]
        public string Name { get; set; }

        [Ps1Xml(Label = "Destination Type", Target = ViewControl.Table)]
        public string DestinationType { get; set; }

        [Ps1Xml(Label = "Destinations", Target = ViewControl.Table)]
        public List<string> Destinations { get; set; }

        [Ps1Xml(Label = "Next Hop Type", Target = ViewControl.Table)]
        public string NextHopType { get; set; }

        [Ps1Xml(Label = "Next Hop", Target = ViewControl.Table)]
        public string NextHop { get; set; }
    }
}
