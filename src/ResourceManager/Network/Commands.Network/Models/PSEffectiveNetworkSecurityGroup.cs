﻿//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSEffectiveNetworkSecurityGroup
    {
        public PSResourceId NetworkSecurityGroup { get; set; }

        public PSEffectiveNetworkSecurityGroupAssociation Association { get; set; }

        public List<PSEffectiveSecurityRule> EffectiveSecurityRules { get; set; }

        public Dictionary<string, List<string>> TagMap { get; set; }

        [JsonIgnore]
        public string NetworkSecurityGroupText
        {
            get { return JsonConvert.SerializeObject(NetworkSecurityGroup, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string AssociationText
        {
            get { return JsonConvert.SerializeObject(Association, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string EffectiveSecurityRulesText
        {
            get { return JsonConvert.SerializeObject(EffectiveSecurityRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string TagMapText
        {
            get { return JsonConvert.SerializeObject(TagMap, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
