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
using System.Linq;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmApplicationGatewaySslCertificate"), OutputType(typeof(PSApplicationGateway))]
    public class SetAzureApplicationGatewaySslCertificateCommand : AzureApplicationGatewaySslCertificateBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var oldSslCertificate = this.ApplicationGateway.SslCertificates.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (oldSslCertificate == null)
            {
                throw new ArgumentException("Ssl certificate with the specified name does not exist");
            }

            X509Certificate2 cert = new X509Certificate2(CertificateFile, Password, X509KeyStorageFlags.Exportable);

            var newSslCertificate = base.NewObject();

            this.ApplicationGateway.SslCertificates.Remove(oldSslCertificate);
            this.ApplicationGateway.SslCertificates.Add(newSslCertificate);

            WriteObject(this.ApplicationGateway);
        }
    }
}