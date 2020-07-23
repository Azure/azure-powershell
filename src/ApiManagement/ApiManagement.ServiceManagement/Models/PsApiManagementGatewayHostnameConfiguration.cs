//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models
{
    using System;
    using System.Text.RegularExpressions;

    public class PsApiManagementGatewayHostnameConfiguration : PsApiManagementArmResource
    {
        static readonly Regex GatewayHostnameConfigurationIdRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/gateways/(?<gatewayId>[^/]+)/hostnameConfigurations/(?<hcId>[^/]+)", RegexOptions.IgnoreCase);

        public string Hostname { get; set; }

        public string CertificateResourceId { get; set; }

        public bool? NegotiateClientCertificate { get; set; }

        public string GatewayId { get; set; }

        public string GatewayHostnameConfigurationId { get; set; }

        public PsApiManagementGatewayHostnameConfiguration() { }

        public PsApiManagementGatewayHostnameConfiguration(string armResourceId)
        {
            this.Id = armResourceId;

            var match = GatewayHostnameConfigurationIdRegex.Match(Id);
            if (match.Success)
            {
                var gatewayIdRegexResult = match.Groups["gatewayId"];
                var hcIdRegexResult = match.Groups["hcId"];
                if (gatewayIdRegexResult != null && gatewayIdRegexResult.Success && hcIdRegexResult != null && hcIdRegexResult.Success)
                {
                    this.GatewayId = gatewayIdRegexResult.Value;
                    this.GatewayHostnameConfigurationId = hcIdRegexResult.Value;
                    return;
                }
            }

            throw new ArgumentException($"ResourceId {armResourceId} is not a valid GatewayHostnameConfiguration Id.");
        }

    }
}