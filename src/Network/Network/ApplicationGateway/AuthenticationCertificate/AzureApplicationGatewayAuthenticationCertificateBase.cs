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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayAuthenticationCertificateBase : NetworkBaseCmdlet
    {
        [Parameter(
               Mandatory = true,
               HelpMessage = "The name of the authentication certificate")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Path of certificate CER file")]
        [ValidateNotNullOrEmpty]
        public string CertificateFile { get; set; }

        public PSApplicationGatewayAuthenticationCertificate NewObject()
        {
            X509Certificate2 cert = new X509Certificate2(CertificateFile);

            var authCertificate = new PSApplicationGatewayAuthenticationCertificate();

            authCertificate.Name = this.Name;
            authCertificate.Data = Convert.ToBase64String(cert.Export(X509ContentType.Cert));
            authCertificate.Id =
                ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                    this.NetworkClient.NetworkManagementClient.SubscriptionId,
                    Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayAuthenticationCertificateName,
                    this.Name);

            return authCertificate;
        }
    }
}
