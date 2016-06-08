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

using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSApplicationGatewayHttpListener : PSChildResource
    {
        public PSResourceId FrontendIpConfiguration { get; set; }
        public PSResourceId FrontendPort { get; set; }
        public string Protocol { get; set; }
        public string HostName { get; set; }
        public PSResourceId SslCertificate { get; set; }
        public string RequireServerNameIndication { get; set; }
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string FrontendIpConfigurationText
        {
            get { return JsonConvert.SerializeObject(FrontendIpConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string FrontendPortText
        {
            get { return JsonConvert.SerializeObject(FrontendPort, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SslCertificateText
        {
            get { return JsonConvert.SerializeObject(SslCertificate, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
