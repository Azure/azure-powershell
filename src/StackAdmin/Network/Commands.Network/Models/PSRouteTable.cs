//
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

    public class PSRouteTable : PSTopLevelResource
    {
        public List<PSRoute> Routes { get; set; }

        public List<PSSubnet> Subnets { get; set; }

        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string RoutesText
        {
            get { return JsonConvert.SerializeObject(Routes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SubnetsText
        {
            get { return JsonConvert.SerializeObject(Subnets, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeSubnets()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeRoutes()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
