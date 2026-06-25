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

using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.EkmConnection
{
    /// <summary>
    /// Updates the External Key Manager (EKM) connection on a Managed HSM. (Preview)
    /// </summary>
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultEkmConnection",
        SupportsShouldProcess = true, DefaultParameterSetName = ByHsmNameParameterSet)]
    [OutputType(typeof(PSKeyVaultEkmConnection))]
    public class UpdateAzKeyVaultEkmConnection : KeyVaultEkmConnectionCmdletBase
    {
        [Parameter(Mandatory = false,
            HelpMessage = "EKM proxy host (FQDN or FQDN:port). If the port is omitted, 443 is assumed.")]
        public new string Host { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Path(s) to one or more server CA certificate(s) in PEM or DER format.")]
        public string[] ServerCaCertificate { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Optional path prefix appended to EKM proxy requests. Must start with \"/\".")]
        public string PathPrefix { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Optional expected Common Name (CN) for the EKM proxy server certificate.")]
        public string ServerSubjectCommonName { get; set; }

        public override void ExecuteCmdlet()
        {
            NormalizeHsmIdentifier();

            string normalizedHost = this.IsParameterBound(c => c.Host)
                ? EkmConnectionHelper.NormalizeHost(Host)
                : null;
            if (this.IsParameterBound(c => c.PathPrefix))
            {
                EkmConnectionHelper.ValidatePathPrefix(PathPrefix);
            }

            var certificates = this.IsParameterBound(c => c.ServerCaCertificate)
                ? EkmConnectionHelper.LoadCertificatesAsDer(ServerCaCertificate)
                : null;

            if (ShouldProcess(HsmName, "Update External Key Manager (EKM) connection"))
            {
                var connection = Track2DataClient.UpdateManagedHsmEkmConnection(
                    HsmName,
                    normalizedHost,
                    this.IsParameterBound(c => c.PathPrefix) ? PathPrefix : null,
                    certificates,
                    this.IsParameterBound(c => c.ServerSubjectCommonName) ? ServerSubjectCommonName : null);
                WriteObject(connection);
            }
        }
    }
}
