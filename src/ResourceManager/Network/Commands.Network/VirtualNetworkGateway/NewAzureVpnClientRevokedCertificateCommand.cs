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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmVpnClientRevokedCertificate"), OutputType(typeof(PSVpnClientRevokedCertificate))]
    public class NewAzureVpnClientRevokedCertificateCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the VpnClient certificate to be revoked.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The thumbprint of the VpnClient certificate to be revoked.")]
        [ValidateNotNullOrEmpty]
        public string Thumbprint { get; set; }

        public override void Execute()
        {

            base.Execute();
            var vpnClientRevokedCertificate = new PSVpnClientRevokedCertificate();

            vpnClientRevokedCertificate.Name = this.Name;
            vpnClientRevokedCertificate.Thumbprint = this.Thumbprint;

            WriteObject(vpnClientRevokedCertificate);
        }
    }
}
