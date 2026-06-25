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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Models;

using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.EkmConnection
{
    /// <summary>
    /// Creates the External Key Manager (EKM) connection on a Managed HSM. (Preview)
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultEkmConnection",
        SupportsShouldProcess = true, DefaultParameterSetName = ByHsmNameParameterSet)]
    [OutputType(typeof(PSKeyVaultEkmConnection))]
    public class NewAzKeyVaultEkmConnection : KeyVaultEkmConnectionCmdletBase
    {
        [Parameter(Mandatory = true,
            HelpMessage = "EKM proxy host (FQDN or FQDN:port). If the port is omitted, 443 is assumed.")]
        [ValidateNotNullOrEmpty]
        public new string Host { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Path(s) to one or more server CA certificate(s) in PEM or DER format.")]
        [ValidateNotNullOrEmpty]
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

            string normalizedHost = EkmConnectionHelper.NormalizeHost(Host);
            EkmConnectionHelper.ValidatePathPrefix(PathPrefix);
            var certificates = EkmConnectionHelper.LoadCertificatesAsDer(ServerCaCertificate);
            if (certificates.Count == 0)
            {
                throw new AzPSArgumentException(
                    "Please specify at least one -ServerCaCertificate for EKM connection creation.",
                    nameof(ServerCaCertificate));
            }

            if (ShouldProcess(HsmName, "Create External Key Manager (EKM) connection"))
            {
                var connection = Track2DataClient.CreateManagedHsmEkmConnection(
                    HsmName, normalizedHost, PathPrefix, certificates, ServerSubjectCommonName);
                WriteObject(connection);
            }
        }
    }
}
