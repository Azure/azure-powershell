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
    public class PSApplicationGatewayPathRule : PSChildResource
    {
        public List<string> Paths { get; set; }
        public PSResourceId BackendAddressPool { get; set; }
        public PSResourceId BackendHttpSettings { get; set; }

        [JsonIgnore]
        public string PathsText
        {
            get { return JsonConvert.SerializeObject(Paths, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string BackendAddressPoolText
        {
            get { return JsonConvert.SerializeObject(BackendAddressPool, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string BackendHttpSettingsText
        {
            get { return JsonConvert.SerializeObject(BackendHttpSettings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
