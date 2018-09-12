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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmApplicationGatewayAuthenticationCertificate", SupportsShouldProcess = true), 
        OutputType(typeof(PSApplicationGateway))]
    public class RemoveAzureApplicationGatewayAuthenticationCertificateCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the authentication certificate")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Microsoft.Azure.Commands.Network.Properties.Resources.RemoveResourceMessage))
            {
                base.ExecuteCmdlet();

                var authCertificate = this.ApplicationGateway.AuthenticationCertificates.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

                if (authCertificate != null)
                {
                    this.ApplicationGateway.AuthenticationCertificates.Remove(authCertificate);
                }

                WriteObject(this.ApplicationGateway);
            }
        }
    }
}
