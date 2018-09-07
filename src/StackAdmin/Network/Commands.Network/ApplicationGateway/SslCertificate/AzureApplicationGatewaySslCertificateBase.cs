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
using System.IO;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewaySslCertificateBase : NetworkBaseCmdlet
    {
        [Parameter(
               Mandatory = true,
               HelpMessage = "The name of the ssl certificate")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Path of certificate PFX file")]
        [ValidateNotNullOrEmpty]
        public string CertificateFile { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Certificate password")]
        [ValidateNotNullOrEmpty]
        public SecureString Password { get; set; }

        public PSApplicationGatewaySslCertificate NewObject()
        {
            var sslCertificate = new PSApplicationGatewaySslCertificate();

            sslCertificate.Name = this.Name;
            sslCertificate.Data = Convert.ToBase64String(File.ReadAllBytes(this.CertificateFile));
            sslCertificate.Password = this.Password;
            sslCertificate.Id =
                ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                    this.NetworkClient.NetworkManagementClient.SubscriptionId,
                    Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewaySslCertificateName,
                    this.Name);

            return sslCertificate;
        }
    }
}
