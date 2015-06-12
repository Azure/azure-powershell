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
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSApplicationGateway : PSTopLevelResource
     {
         public int InstanceCount { get; set; }
         public string Size { get; set; }
         public string Fqdn { get; private set; }
         public List<PSApplicationGatewayIpConfiguration> GatewayIpConfigurations { get; set; }

         public List<PSApplicationGatewaySslCertificate> SslCertificates { get; set; }

         public List<PSApplicationGatewayFrontendIpConfiguration> FrontendIpConfigurations { get; set; }

         public List<PSApplicationGatewayFrontendPort> FrontendPorts { get; set; }

         public List<PSApplicationGatewayBackendAddressPool> BackendAddressPools { get; set; }

         public List<PSApplicationGatewayBackendHttpSettings> BackendHttpSettingsCollection { get; set; }

         public List<PSApplicationGatewayHttpListener> HttpListeners { get; set; }

         public List<PSApplicationGatewayRequestRoutingRule> RequestRoutingRules { get; set; }

         public string OperationalState { get; private set; }

         public string ProvisioningState { get; set; }

         [JsonIgnore]
         public string GatewayIpConfigurationsText
         {
             get { return JsonConvert.SerializeObject(GatewayIpConfigurations, Formatting.Indented); }
         }

         [JsonIgnore]
         public string SslCertificatesText
         {
             get { return JsonConvert.SerializeObject(SslCertificates, Formatting.Indented); }
         }

         [JsonIgnore]
         public string FrontendIpConfigurationsText
         {
             get { return JsonConvert.SerializeObject(FrontendIpConfigurations, Formatting.Indented); }
         }

         [JsonIgnore]
         public string FrontendPortsText
         {
             get { return JsonConvert.SerializeObject(FrontendPorts, Formatting.Indented); }
         }

         [JsonIgnore]
         public string BackendAddressPoolsText
         {
             get { return JsonConvert.SerializeObject(BackendAddressPools, Formatting.Indented); }
         }

         [JsonIgnore]
         public string BackendHttpSettingsListText
         {
             get { return JsonConvert.SerializeObject(BackendHttpSettingsCollection, Formatting.Indented); }
         }

         [JsonIgnore]
         public string HttpListenersText
         {
             get { return JsonConvert.SerializeObject(HttpListeners, Formatting.Indented); }
         }

         [JsonIgnore]
         public string RequestRoutingRulesText
         {
             get { return JsonConvert.SerializeObject(RequestRoutingRules, Formatting.Indented); }
         }
     }
}
