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
using Microsoft.Azure.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet(VerbsCommon.Set, "AzureKeyVaultCertificateAttribute",
        SupportsShouldProcess = true,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(KeyVaultCertificate))]
    public class SetAzureKeyVaultCertificateAttribute : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Certificate name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.CertificateName)]
        public string Name { get; set; }

        /// <summary>
        /// Certificate version.
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Secret version. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment, secret name and secret version.")]
        [Alias("CertificateVersion")]        
        public string Version { get; set; }

        /// <summary>
        /// If present, enable a certificate if value is true. 
        /// Disable a certificate if value is false.
        /// If not present, no change on current certificate enabled/disabled state.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "If present, enable a certificate if value is true. Disable a certificate if value is false. If not specified, the existing value of the certificate's enabled/disabled state remains unchanged.")]
        public bool? Enable { get; set; }

        /// <summary>
        /// Certificate tags
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable representing certificate tags. If not specified, the existing tags of the sertificate remain unchanged. Remove a tag by specifying an empty Hashtable.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false,
           HelpMessage = "Cmdlet does not return object by default. If this switch is specified, return certificate object.")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.SetCertificateAttributes))
            {
                var certificateBundle = DataServiceClient.UpdateCertificate(
                VaultName,
                Name,
                Version ?? string.Empty,
                new CertificateAttributes
                {
                    Enabled = Enable,
                },
                Tag == null ? null : Tag.ConvertToDictionary());

                if (PassThru)
                {
                    var certificate = KeyVaultCertificate.FromCertificateBundle(certificateBundle);
                    this.WriteObject(certificate);
                }
            }
        }
    }
}
