// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewaySslProfileBase : NetworkBaseCmdlet
    {
        [Parameter(
               Mandatory = true,
               HelpMessage = "The name of the SSL profile")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "SSL policy")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewaySslPolicy SslPolicy { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Client authentication configuration settings")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayClientAuthConfiguration ClientAuthConfiguration { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "The trusted client CA certificate chains")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayTrustedClientCertificate[] TrustedClientCertificates { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        public PSApplicationGatewaySslProfile NewObject()
        {
            var sslProfile = new PSApplicationGatewaySslProfile();
            sslProfile.Name = this.Name;

            if (this.SslPolicy != null)
            {
                sslProfile.SslPolicy = this.SslPolicy;
            }

            if (this.ClientAuthConfiguration != null)
            {
                sslProfile.ClientAuthConfiguration = this.ClientAuthConfiguration;
            }

            if (this.TrustedClientCertificates != null && this.TrustedClientCertificates.Length > 0)
            {
                sslProfile.TrustedClientCertificates = new List<PSResourceId>();
                foreach (var trustedClientCert in this.TrustedClientCertificates)
                {
                    sslProfile.TrustedClientCertificates.Add(
                        new PSResourceId()
                        {
                            Id = trustedClientCert.Id
                        });
                }
            }

            sslProfile.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                            this.NetworkClient.NetworkManagementClient.SubscriptionId,
                            Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewaySslProfileName,
                            this.Name);

            return sslProfile;
        }
    }
}