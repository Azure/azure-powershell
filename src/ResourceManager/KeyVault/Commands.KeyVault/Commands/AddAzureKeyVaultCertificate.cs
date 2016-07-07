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

using System.Collections;
using Microsoft.Azure.Commands.KeyVault.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Starts the process for enrolling for a certificate in Azure Key Vault
    /// </summary>
    [Cmdlet(VerbsCommon.Add, CmdletNoun.AzureKeyVaultCertificate,
        SupportsShouldProcess = true,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(KeyVaultCertificateOperation))]
    public class AddAzureKeyVaultCertificate : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// VaultName
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ValidateNotNullOrEmpty]
                public string VaultName { get; set; }

        /// <summary>
        /// Name
        /// </summary>       
        [Parameter(Mandatory = true,
                   Position = 1,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [ValidateNotNullOrEmpty]        
        [Alias(Constants.CertificateName)]
        public string Name { get; set; }

        /// <summary>
        /// CertificatePolicy
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Specifies the certificate policy.")]
        [ValidateNotNull]
        public KeyVaultCertificatePolicy CertificatePolicy { get; set; }

        /// <summary>
        /// Certificate tags
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable representing certificate tags.")]
        [Alias(Constants.TagsAlias)]
        public Hashtable Tag { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(Name, Properties.Resources.AddCertificate)) {
                var certificateOperation = this.DataServiceClient.EnrollCertificate(VaultName, Name, CertificatePolicy == null ? null : CertificatePolicy.ToCertificatePolicy(), Tag == null ? null : Tag.ConvertToDictionary());
                var kvCertificateOperation = KeyVaultCertificateOperation.FromCertificateOperation(certificateOperation);
                this.WriteObject(kvCertificateOperation);
            }
        }
    }
}
