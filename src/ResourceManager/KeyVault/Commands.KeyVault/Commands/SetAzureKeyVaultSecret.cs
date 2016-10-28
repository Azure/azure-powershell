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

using Microsoft.Azure.Commands.KeyVault.Models;
using System;
using System.Collections;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet(VerbsCommon.Set, "AzureKeyVaultSecret",
        SupportsShouldProcess = true,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(Secret))]
    public class SetAzureKeyVaultSecret : KeyVaultCmdletBase
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
        /// Secret name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.SecretName)]
        public string Name { get; set; }

        /// <summary>
        /// Secret value
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 2,
            HelpMessage = "Secret value")]
        public SecureString SecretValue { get; set; }

        /// <summary>
        /// Set secret in disabled state if present       
        /// </summary>        
        [Parameter(Mandatory = false,
            HelpMessage = "Set secret in disabled state if present. If not specified, the secret is enabled.")]
        public SwitchParameter Disable { get; set; }

        /// <summary>
        /// Secret expires time in UTC time
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The expiration time of a secret in UTC time. If not specified, the secret will not expire.")]
        public DateTime? Expires { get; set; }

        /// <summary>
        /// The UTC time before which secret can't be used 
        /// </summary>
        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
            HelpMessage = "The UTC time before which secret can't be used. If not specified, there is no limitation.")]
        public DateTime? NotBefore { get; set; }

        /// <summary>
        /// Content type
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Secret's content type.")]
        public string ContentType { get; set; }

        /// <summary>
        /// Secret tags
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable representing secret tags.")]
        [Alias(Constants.TagsAlias)]
        public Hashtable Tag { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.SetSecret))
            {
                var secret = DataServiceClient.SetSecret(
                VaultName,
                Name,
                SecretValue,
                new SecretAttributes(!Disable.IsPresent, Expires, NotBefore, ContentType, Tag));
                WriteObject(secret);
            }
        }
    }
}
