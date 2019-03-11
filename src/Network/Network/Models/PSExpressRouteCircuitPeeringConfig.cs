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
    public partial class PSExpressRouteCircuitPeeringConfig
    {
        public IList<string> AdvertisedPublicPrefixes { get; set; }
        public IList<string> AdvertisedCommunities { get; set; }
        public string AdvertisedPublicPrefixesState { get; set; }
        public int? LegacyMode { get; set; }
        public int? CustomerASN { get; set; }
        public string RoutingRegistryName { get; set; }

        [JsonIgnore]
        public string AdvertisedPublicPrefixesText
        {
            get { return JsonConvert.SerializeObject(AdvertisedPublicPrefixes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string AdvertisedCommunitiesText
        {
            get { return JsonConvert.SerializeObject(AdvertisedCommunities, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
