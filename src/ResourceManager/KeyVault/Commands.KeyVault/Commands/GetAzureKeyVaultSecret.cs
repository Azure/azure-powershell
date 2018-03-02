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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet(VerbsCommon.Get, "AzureKeyVaultSecret",        
        DefaultParameterSetName = ByVaultNameParameterSet,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(List<PSKeyVaultSecretIdentityItem>), typeof(PSKeyVaultSecret), typeof(List<PSDeletedKeyVaultSecretIdentityItem>), typeof(PSDeletedKeyVaultSecret))]
    public class GetAzureKeyVaultSecret : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByVaultNameParameterSet = "ByVaultName";
        private const string BySecretNameParameterSet = "BySecretName";
        private const string BySecretVersionsParameterSet = "BySecretVersions";

        private const string InputObjectByVaultNameParameterSet = "ByInputObjectVaultName";
        private const string InputObjectBySecretNameParameterSet = "ByInputObjectSecretName";
        private const string InputObjectBySecretVersionsParameterSet = "ByInputObjectSecretVersions";

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
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// KeyVault object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = InputObjectByVaultNameParameterSet,
            HelpMessage = "KeyVault Object.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = InputObjectBySecretNameParameterSet,
            HelpMessage = "KeyVault Object.")]
        [Parameter(Mandatory = true,
           Position = 0,
           ValueFromPipeline = true,
           ParameterSetName = InputObjectBySecretVersionsParameterSet,
           HelpMessage = "KeyVault Object.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVault InputObject { get; set; }

        /// <summary>
        /// Secret name
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [Parameter(Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = InputObjectByVaultNameParameterSet,
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = BySecretNameParameterSet,
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = InputObjectBySecretNameParameterSet,
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = BySecretVersionsParameterSet,
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = InputObjectBySecretVersionsParameterSet,
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.SecretName)]
        public string Name { get; set; }

        /// <summary>
        /// Secret version
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = BySecretNameParameterSet,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Secret version. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment, secret name and secret version.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectBySecretNameParameterSet,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Secret version. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment, secret name and secret version.")]
        [Alias("SecretVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = BySecretVersionsParameterSet,
            HelpMessage = "Specifies whether to include the versions of the secret in the output.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectBySecretVersionsParameterSet,
            HelpMessage = "Specifies whether to include the versions of the secret in the output.")]
        public SwitchParameter IncludeVersions { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Specifies whether to show the previously deleted secrets in the output.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByVaultNameParameterSet,
            HelpMessage = "Specifies whether to show the previously deleted secrets in the output.")]
        public SwitchParameter InRemovedState { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            PSKeyVaultSecret secret;

            if (InputObject != null)
            {
                VaultName = InputObject.VaultName.ToString();
            }

            if (!string.IsNullOrEmpty(Version))
            {
                secret = DataServiceClient.GetSecret(VaultName, Name, Version);
                WriteObject(secret);
            }
            else if (IncludeVersions)
            {
                secret = DataServiceClient.GetSecret(VaultName, Name, string.Empty);
                if (secret != null)
                {
                    WriteObject(new PSKeyVaultSecretIdentityItem(secret));
                    GetAndWriteSecretVersions(VaultName, Name, secret.Version);
                }
            }
            else if (InRemovedState)
            {
                if (Name == null)
                {
                    GetAndWriteDeletedSecrets(VaultName);
                }
                else
                {
                    PSDeletedKeyVaultSecret deletedSecret = DataServiceClient.GetDeletedSecret(VaultName, Name);
                    WriteObject(deletedSecret);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Name))
                {
                    GetAndWriteSecrets(VaultName);
                }
                else
                {
                    secret = DataServiceClient.GetSecret(VaultName, Name, string.Empty);
                    WriteObject(secret);
                }
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
