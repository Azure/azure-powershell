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

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSApplicationGatewayHttpListener : PSChildResource
    {
        public PSResourceId FrontendIpConfiguration { get; set; }
        public PSResourceId FrontendPort { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string Protocol { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string HostName { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public List<string> HostNames { get; set; }
        public PSResourceId SslCertificate { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public bool RequireServerNameIndication { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
        public string Type { get; set; }
        public List<PSApplicationGatewayCustomError> CustomErrorConfigurations { get; set; }
        public PSResourceId FirewallPolicy { get; set; }
        public PSResourceId SslProfile { get; set; }

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

        [JsonIgnore]
        public string SslProfileText
        {
            get { return JsonConvert.SerializeObject(SslProfile, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string FirewallPolicyText
        {
            get { return JsonConvert.SerializeObject(FirewallPolicy, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
