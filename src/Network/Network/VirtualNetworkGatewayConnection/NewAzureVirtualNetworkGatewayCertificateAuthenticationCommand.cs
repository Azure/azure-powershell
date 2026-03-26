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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayCertificateAuthentication"), OutputType(typeof(PSCertificateAuthentication))]
    public class NewAzureVirtualNetworkGatewayCertificateAuthenticationCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Keyvault secret ID for outbound authentication certificate.")]
        public string OutboundAuthCertificate { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Inbound authentication certificate subject name.")]
        public string InboundAuthCertificateSubjectName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Inbound authentication certificate public keys.")]
        public string[] InboundAuthCertificateChain { get; set; }

        public override void Execute()
        {
            base.Execute();

            var certificateAuth = new PSCertificateAuthentication()
            {
                OutboundAuthCertificate = this.OutboundAuthCertificate,
                InboundAuthCertificateSubjectName = this.InboundAuthCertificateSubjectName,
                InboundAuthCertificateChain = this.InboundAuthCertificateChain?.ToList()
            };

            WriteObject(certificateAuth);
        }
    }
}
