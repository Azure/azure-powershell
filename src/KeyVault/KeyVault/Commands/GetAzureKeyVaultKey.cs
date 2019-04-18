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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKey",        DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSKeyVaultKeyIdentityItem), typeof(PSKeyVaultKey), typeof(PSDeletedKeyVaultKeyIdentityItem), typeof(PSDeletedKeyVaultKey))]
    public class GetAzureKeyVaultKey : KeyVaultCmdletBase
    {

        #region Parameter Set Names

        private const string ByVaultNameParameterSet = "ByVaultName";
        private const string ByKeyNameParameterSet = "ByKeyName";
        private const string ByKeyVersionsParameterSet = "ByKeyVersions";

        private const string InputObjectByVaultNameParameterSet = "ByInputObjectVaultName";
        private const string InputObjectByKeyNameParameterSet = "ByInputObjectKeyName";
        private const string InputObjectByKeyVersionsParameterSet = "ByInputObjectKeyVersions";

        private const string ResourceIdByVaultNameParameterSet = "ByResourceIdVaultName";
        private const string ResourceIdByKeyNameParameterSet = "ByResourceIdKeyName";
        private const string ResourceIdByKeyVersionsParameterSet = "ByResourceIdKeyVersions";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByKeyNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByKeyVersionsParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
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
        /// KeyVault resource id
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdByVaultNameParameterSet,
            HelpMessage = "KeyVault Resource Id.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdByKeyNameParameterSet,
            HelpMessage = "KeyVault Resource Id.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdByKeyVersionsParameterSet,
            HelpMessage = "KeyVault ResourceId.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Key name.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByVaultNameParameterSet,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByVaultNameParameterSet,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByVaultNameParameterSet,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyNameParameterSet,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByKeyNameParameterSet,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByKeyNameParameterSet,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyVersionsParameterSet,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByKeyVersionsParameterSet,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByKeyVersionsParameterSet,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.KeyName)]
        [SupportsWildcards]
        public string Name { get; set; }

        /// <summary>
        /// Key version.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyNameParameterSet,
            Position = 2,
            HelpMessage = "Key version. Cmdlet constructs the FQDN of a key from vault name, currently selected environment, key name and key version.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByKeyNameParameterSet,
            Position = 2,
            HelpMessage = "Key version. Cmdlet constructs the FQDN of a key from vault name, currently selected environment, key name and key version.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByKeyNameParameterSet,
            Position = 2,
            HelpMessage = "Key version. Cmdlet constructs the FQDN of a key from vault name, currently selected environment, key name and key version.")]
        [Alias("KeyVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyVersionsParameterSet,
            HelpMessage = "Specifies whether to include the versions of the key in the output.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByKeyVersionsParameterSet,
            HelpMessage = "Specifies whether to include the versions of the key in the output.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByKeyVersionsParameterSet,
            HelpMessage = "Specifies whether to include the versions of the key in the output.")]
        public SwitchParameter IncludeVersions { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Specifies whether to show the previously deleted keys in the output.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByVaultNameParameterSet,
            HelpMessage = "Specifies whether to show the previously deleted keys in the output.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByVaultNameParameterSet,
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
            else if (!string.IsNullOrEmpty(ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                VaultName = parsedResourceId.ResourceName;
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
                if (string.IsNullOrEmpty(Name) || WildcardPattern.ContainsWildcardCharacters(Name))
                {
                    GetAndWriteDeletedKeys(VaultName, Name);
                }
                else
                {
                    PSDeletedKeyVaultKey deletedKeyBundle = DataServiceClient.GetDeletedKey(VaultName, Name);
                    WriteObject(deletedKeyBundle);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Name) || WildcardPattern.ContainsWildcardCharacters(Name))
                {
                    GetAndWriteKeys(VaultName, Name);
                }
                else
                {
                    keyBundle = DataServiceClient.GetKey(VaultName, Name, string.Empty);
                    WriteObject(keyBundle);
                }
            }
        }

        private void GetAndWriteKeys(string vaultName, string name) =>
            GetAndWriteObjects(new KeyVaultObjectFilterOptions
                {
                    VaultName = vaultName,
                    NextLink = null
                },
                (options) => KVSubResourceWildcardFilter(name, DataServiceClient.GetKeys(options)));

        private void GetAndWriteDeletedKeys(string vaultName, string name) =>
            GetAndWriteObjects(new KeyVaultObjectFilterOptions
                {
                    VaultName = vaultName,
                    NextLink = null
                },
                (options) => KVSubResourceWildcardFilter(name, DataServiceClient.GetDeletedKeys(options)));

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
