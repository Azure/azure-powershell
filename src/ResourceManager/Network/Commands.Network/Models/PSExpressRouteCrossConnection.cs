﻿// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using Microsoft.Azure.Management.Network.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSExpressRouteCrossConnection : PSTopLevelResource
    {
        public string PrimaryAzurePort { get; set; }
        public string SecondaryAzurePort { get; set; }
        public int? STag { get; set; }
        public string PeeringLocation { get; set; }
        public int? BandwidthInMbps { get; set; }
        public string ServiceProviderProvisioningState { get; set; }
        public string ServiceProviderNotes { get; set; }
        public string ProvisioningState { get; set; }
        public PSExpressRouteCircuitReference ExpressRouteCircuit { get; set; }
        public List<PSExpressRouteCrossConnectionPeering> Peerings { get; set; }

        [JsonIgnore]
        public string ExpressRouteCircuitText
        {
            get { return JsonConvert.SerializeObject(ExpressRouteCircuit, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PeeringsText
        {
            get { return JsonConvert.SerializeObject(Peerings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
