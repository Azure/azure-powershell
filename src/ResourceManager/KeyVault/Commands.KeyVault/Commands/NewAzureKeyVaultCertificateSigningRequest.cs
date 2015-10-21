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
using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// The New-AzureKeyVaultCertificateSigningRequest cmdlet creates a certificate signing request.
    /// </summary>
    [Cmdlet(VerbsCommon.New, CmdletNoun.AzureKeyVaultCertificateSigningRequest,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(string))]
    public class NewAzureKeyVaultCertificateSigningRequest : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// VaultName
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the name of the key vault to which this cmdlet creates the certificate.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern(Constants.VaultNameRegExString)]
        public string VaultName { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 1,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the name of the certificate in key vault.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern(Constants.ObjectNameRegExString)]
        [Alias(Constants.CertificateName)]
        public string Name { get; set; }

        /// <summary>
        /// Policy
        /// </summary>
        [Parameter(Position = 2,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the policy to use to create the certificate signing request.")]
        [ValidateNotNullOrEmpty]
        public KeyVaultCertificatePolicy CertificatePolicy { get; set; }

        /// <summary>
        /// Certificate tags
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable representing certificate tags.")]
        public Hashtable Tags { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var csr = this.DataServiceClient.CreateCsr(VaultName, Name, CertificatePolicy == null ? null : CertificatePolicy.ToCertificatePolicy(), Tags == null ? null : Tags.ConvertToDictionary());
            this.WriteObject(csr);
        }
    }
}
