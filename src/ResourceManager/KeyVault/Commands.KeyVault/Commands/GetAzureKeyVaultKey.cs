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
    [Cmdlet(VerbsCommon.Get, "AzureKeyVaultKey",        
        DefaultParameterSetName = ByVaultNameParameterSet,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(List<PSKeyVaultKeyIdentityItem>), typeof(PSKeyVaultKey), typeof(List<PSDeletedKeyVaultKeyIdentityItem>), typeof(PSDeletedKeyVaultKey))]
    public class GetAzureKeyVaultKey : KeyVaultCmdletBase
    {

        #region Parameter Set Names

        private const string ByVaultNameParameterSet = "ByVaultName";
        private const string ByKeyNameParameterSet = "ByKeyName";
        private const string ByKeyVersionsParameterSet = "ByKeyVersions";

        private const string InputObjectByVaultNameParameterSet = "ByInputObjectVaultName";
        private const string InputObjectByKeyNameParameterSet = "ByInputObjectKeyName";
        private const string InputObjectByKeyVersionsParameterSet = "ByKInputObjecteyVersions";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByKeyNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByKeyVersionsParameterSet,
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
            HelpMessage = "KeyVault object.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = InputObjectByKeyNameParameterSet,
            HelpMessage = "KeyVault object.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = InputObjectByKeyVersionsParameterSet,
            HelpMessage = "KeyVault object.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVault InputObject { get; set; }

        /// <summary>
        /// Key name.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByVaultNameParameterSet,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByVaultNameParameterSet,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyNameParameterSet,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByKeyNameParameterSet,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyVersionsParameterSet,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByKeyVersionsParameterSet,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.KeyName)]
        public string Name { get; set; }

        /// <summary>
        /// Key version.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyNameParameterSet,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key version. Cmdlet constructs the FQDN of a key from vault name, currently selected environment, key name and key version.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByKeyNameParameterSet,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key version. Cmdlet constructs the FQDN of a key from vault name, currently selected environment, key name and key version.")]
        [Alias("KeyVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyVersionsParameterSet,
            HelpMessage = "Specifies whether to include the versions of the key in the output.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByKeyVersionsParameterSet,
            HelpMessage = "Specifies whether to include the versions of the key in the output.")]
        public SwitchParameter IncludeVersions { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Specifies whether to show the previously deleted keys in the output.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByVaultNameParameterSet,
            HelpMessage = "Specifies whether to show the previously deleted keys in the output.")]
        public SwitchParameter InRemovedState { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            PSKeyVaultKey keyBundle;

            if (InputObject != null)
            {
                VaultName = InputObject.VaultName.ToString();
            }

            if (!string.IsNullOrEmpty(Version))
            {
                keyBundle = DataServiceClient.GetKey(VaultName, Name, Version);
                WriteObject(keyBundle);
            }
            else if (IncludeVersions)
            {
                keyBundle = DataServiceClient.GetKey(VaultName, Name, string.Empty);
                if (keyBundle != null)
                {
                    WriteObject(new PSKeyVaultKeyIdentityItem(keyBundle));
                    GetAndWriteKeyVersions(VaultName, Name, keyBundle.Version);
                }
            }
            else if (InRemovedState)
            {
                if (Name == null)
                {
                    GetAndWriteDeletedKeys(VaultName);
                }
                else
                {
                    PSDeletedKeyVaultKey deletedKeyBundle = DataServiceClient.GetDeletedKey(VaultName, Name);
                    WriteObject(deletedKeyBundle);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Name))
                {
                    GetAndWriteKeys(VaultName);
                }
                else
                {
                    keyBundle = DataServiceClient.GetKey(VaultName, Name, string.Empty);
                    WriteObject(keyBundle);
                }
            }
        }

        private void GetAndWriteKeys(string vaultName) =>
            GetAndWriteObjects(new KeyVaultObjectFilterOptions
                {
                    VaultName = vaultName,
                    NextLink = null
                },
                (options) => DataServiceClient.GetKeys(options));

        private void GetAndWriteDeletedKeys(string vaultName) =>
            GetAndWriteObjects(new KeyVaultObjectFilterOptions
                {
                    VaultName = vaultName,
                    NextLink = null
                },
                (options) => DataServiceClient.GetDeletedKeys(options));

        private void GetAndWriteKeyVersions(string vaultName, string name, string currentKeyVersion) =>
            GetAndWriteObjects(new KeyVaultObjectFilterOptions
                {
                    VaultName = vaultName,
                    NextLink = null,
                    Name = name
                }, 
                (options) => DataServiceClient.GetKeyVersions(options).Where(k => k.Version != currentKeyVersion));
    }
}
