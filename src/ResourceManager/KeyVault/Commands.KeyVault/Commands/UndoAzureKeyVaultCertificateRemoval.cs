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
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet( VerbsCommon.Undo, "AzureKeyVaultCertificateRemoval",
    SupportsShouldProcess = true,
    ConfirmImpact = ConfirmImpact.Low,
    HelpUri = Constants.KeyVaultHelpUri )]
    [OutputType( typeof( CertificateBundle ) )]
    public class UndoAzureKeyVaultCertificateRemoval : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter( Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment." )]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Secret name
        /// </summary>
        [Parameter( Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.CertificateName )]
        public string Name { get; set; }

        #endregion

        public override void ExecuteCmdlet( )
        {
            if ( ShouldProcess( Name, Properties.Resources.RecoverCertificate ) )
            {
                CertificateBundle certificate = DataServiceClient.RecoverCertificate(VaultName, Name);

                WriteObject( certificate );
            }
        }
    }
}
