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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    public class PSApplicationGatewayBackendHttpSettings : PSChildResource
    {
        public int Port { get; set; }
        public string Protocol { get; set; }
        public string CookieBasedAffinity { get; set; }
        public uint RequestTimeout { get; set; }
        public PSResourceId Probe { get; set; }
        public List<PSResourceId> AuthenticationCertificates { get; set; }
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string ProbeText
        {
            get { return JsonConvert.SerializeObject(Probe, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string AuthenticationCertificatesText
        {
            get { return JsonConvert.SerializeObject(AuthenticationCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
