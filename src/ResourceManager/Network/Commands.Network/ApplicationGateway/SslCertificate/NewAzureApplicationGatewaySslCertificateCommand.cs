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

using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureApplicationGatewaySslCertificate"), OutputType(typeof(PSApplicationGatewaySslCertificate))]
    public class NewAzureApplicationGatewaySslCertificateCommand : NetworkBaseCmdlet
    {
        [Parameter(
               Mandatory = true,
               HelpMessage = "The name of the ssl certificate")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Certificate data")]
        [ValidateNotNullOrEmpty]
        public string Data { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Certificate password")]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Certificate public data")]
        [ValidateNotNullOrEmpty]
        public string PublicCertData { get; set; }
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var sslCertificate = new PSApplicationGatewaySslCertificate();
            sslCertificate.Name = this.Name;
            sslCertificate.Data = this.Data;
            sslCertificate.Password = this.Password;
            sslCertificate.PublicCertData = this.PublicCertData;
            
            sslCertificate.Id =
                ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                    this.NetworkClient.NetworkResourceProviderClient.Credentials.SubscriptionId,
                    Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewaySslCertificateName,
                    this.Name);

            WriteObject(sslCertificate);
        }
    }
}
