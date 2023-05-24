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
    using System.Management.Automation;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;

    public class PSVirtualHubEffectiveRouteMapRouteList
    {
        [Ps1Xml(Label = "Value", Target = ViewControl.Table)]
        public List<PSVirtualHubEffectiveRouteMapRoute> Value { get; set; }

        [JsonIgnore]
        public string ValueText
        {
            get { return JsonConvert.SerializeObject(Value, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }

    public class PSVirtualHubEffectiveRouteMapRoute
    {
        public string Prefix { get; set; }

        public string BgpCommunities { get; set; }

        public string AsPath { get; set; }
    }
}