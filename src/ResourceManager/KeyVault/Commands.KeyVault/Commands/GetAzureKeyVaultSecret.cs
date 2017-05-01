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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet(VerbsCommon.Get, "AzureKeyVaultSecret",        
        DefaultParameterSetName = ByVaultNameParameterSet,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(List<SecretIdentityItem>), typeof(Secret), typeof(List<DeletedSecretIdentityItem>), typeof(DeletedSecret))]
    public class GetAzureKeyVaultSecret : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByVaultNameParameterSet = "ByVaultName";
        private const string BySecretNameParameterSet = "BySecretName";
        private const string BySecretVersionsParameterSet = "BySecretVersions";
        private const string ByDeletedSecretParameterSet = "ByDeletedSecrets";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = BySecretNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = BySecretVersionsParameterSet,
           HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = ByDeletedSecretParameterSet,
           HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Secret name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = BySecretNameParameterSet,
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = BySecretVersionsParameterSet,
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [Parameter(Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByDeletedSecretParameterSet,
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.SecretName)]
        public string Name { get; set; }

        /// <summary>
        /// Secret version
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = BySecretNameParameterSet,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Secret version. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment, secret name and secret version.")]
        [Alias("SecretVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = BySecretVersionsParameterSet,
            HelpMessage = "Specifies whether to include the versions of the secret in the output.")]
        public SwitchParameter IncludeVersions { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ByDeletedSecretParameterSet,
            HelpMessage = "Specifies whether to show the previously deleted secrets in the output.")]
        public SwitchParameter InRemovedState { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            Secret secret;
            switch (ParameterSetName)
            {
                case BySecretNameParameterSet:
                    secret = DataServiceClient.GetSecret(VaultName, Name, Version ?? string.Empty);
                    WriteObject(secret);
                    break;
                case BySecretVersionsParameterSet:
                    secret = DataServiceClient.GetSecret(VaultName, Name, string.Empty);
                    if (secret != null)
                    {
                        WriteObject(new SecretIdentityItem(secret));
                        GetAndWriteSecretVersions(VaultName, Name, secret.Version);
                    }
                    break;
                case ByVaultNameParameterSet:
                    GetAndWriteSecrets(VaultName);
                    break;
                case ByDeletedSecretParameterSet:
                    if (Name == null)
                    {
                        GetAndWriteDeletedSecrets(VaultName);
                        break;
                    }
                    DeletedSecret deletedSecret = DataServiceClient.GetDeletedSecret(VaultName, Name);
                    WriteObject(deletedSecret);
                    break;

                default:
                    throw new ArgumentException(KeyVaultProperties.Resources.BadParameterSetName);
            }
        }

        private void GetAndWriteDeletedSecrets(string vaultName) =>
            GetAndWriteObjects(new KeyVaultObjectFilterOptions
                {
                    VaultName = vaultName,
                    NextLink = null
                },
                (options) => DataServiceClient.GetDeletedSecrets(options));

        private void GetAndWriteSecrets(string vaultName) =>
            GetAndWriteObjects(new KeyVaultObjectFilterOptions
                {
                    VaultName = vaultName,
                    NextLink = null
                }, 
                (options) => DataServiceClient.GetSecrets(options));

        private void GetAndWriteSecretVersions(string vaultName, string name, string currentSecretVersion) =>
            GetAndWriteObjects(new KeyVaultObjectFilterOptions
                {
                    VaultName = vaultName,
                    Name = name,
                    NextLink = null
                }, 
                (options) => DataServiceClient.GetSecretVersions(options).Where(s => s.Version != currentSecretVersion));
    }
}
