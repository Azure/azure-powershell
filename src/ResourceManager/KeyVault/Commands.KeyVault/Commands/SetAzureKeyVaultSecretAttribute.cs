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

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet(VerbsCommon.Set, "AzureKeyVaultSecretAttribute",
        SupportsShouldProcess = true,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(Secret))]
    public class SetAzureKeyVaultSecretAttribute : KeyVaultCmdletBase
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
        /// Key version.
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Secret version. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment, secret name and secret version.")]
        [Alias("SecretVersion")]
        public string Version { get; set; }

        /// <summary>
        /// If present, enable a secret if value is true. 
        /// Disable a secret if value is false.
        /// If not present, no change on current secret enabled/disabled state.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "If present, enable a secret if value is true. Disable a secret if value is false. If not specified, the existing value of the secret's enabled/disabled state remains unchanged.")]
        public bool? Enable { get; set; }

        /// <summary>
        /// Secret expires time in UTC time
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The expiration time of a secret in UTC time. If not specified, the existing value of the secret's expiration time remains unchanged.")]
        public DateTime? Expires { get; set; }

        /// <summary>
        /// The UTC time before which secret can't be used 
        /// </summary>
        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
            HelpMessage = "The UTC time before which secret can't be used. If not specified, the existing value of the secret's NotBefore attribute remains unchanged.")]
        public DateTime? NotBefore { get; set; }

        /// <summary>
        /// Content type
        /// TODO: check if content type is null, will it replace the server data
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Secret's content type. If not specified, the existing value of the secret's content type remains unchanged. Remove the existing content type value by specifying an empty string.")]
        public string ContentType { get; set; }

        /// <summary>
        /// Secret tags
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable representing secret tags. If not specified, the existing tags of the secret remain unchanged. Remove a tag by specifying an empty Hashtable.")]
        [Alias(Constants.TagsAlias)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false,
           HelpMessage = "Cmdlet does not return object by default. If this switch is specified, return Secret object.")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.SetSecretAttribute))
            {
                var secret = DataServiceClient.UpdateSecret(
                VaultName,
                Name,
                Version ?? string.Empty,
                new SecretAttributes(Enable, Expires, NotBefore, ContentType, Tag));

                if (PassThru)
                {
                    WriteObject(secret);
                }
            }
        }
    }
}
