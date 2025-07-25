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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKey", DefaultParameterSetName = ByVaultNameParameterSet)]
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

        private const string HsmByVaultNameParameterSet = "HsmByVaultName";
        private const string HsmByKeyNameParameterSet = "HsmByKeyName";
        private const string HsmByKeyVersionsParameterSet = "HsmByKeyVersions";

        private const string HsmInputObjectByVaultNameParameterSet = "HsmByInputObjectVaultName";
        private const string HsmInputObjectByKeyNameParameterSet = "HsmByInputObjectKeyName";
        private const string HsmInputObjectByKeyVersionsParameterSet = "HsmByInputObjectKeyVersions";

        private const string HsmResourceIdByVaultNameParameterSet = "HsmByResourceIdVaultName";
        private const string HsmResourceIdByKeyNameParameterSet = "HsmByResourceIdKeyName";
        private const string HsmResourceIdByKeyVersionsParameterSet = "HsmByResourceIdKeyVersions";

        private readonly string[] _supportedTypesForDownload = new string[] { Constants.RSA, Constants.RSAHSM };

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
            ParameterSetName = ByVaultNameParameterSet)]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByKeyVersionsParameterSet)]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = HsmByKeyNameParameterSet,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmByVaultNameParameterSet)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmByKeyVersionsParameterSet)]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName { get; set; }

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
            ParameterSetName = InputObjectByKeyNameParameterSet)]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = InputObjectByKeyVersionsParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSKeyVault InputObject { get; set; }

        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = HsmInputObjectByVaultNameParameterSet,
            HelpMessage = "HSM object.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = HsmInputObjectByKeyNameParameterSet)]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = HsmInputObjectByKeyVersionsParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagedHsm HsmObject { get; set; }

        /// <summary>
        /// KeyVault resource id
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdByVaultNameParameterSet,
            HelpMessage = "KeyVault Resource Id.")]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdByKeyNameParameterSet)]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdByKeyVersionsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = HsmResourceIdByVaultNameParameterSet,
            HelpMessage = "HSM Resource Id.")]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = HsmResourceIdByKeyNameParameterSet)]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = HsmResourceIdByKeyVersionsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string HsmResourceId { get; set; }

        /// <summary>
        /// Key name.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByVaultNameParameterSet,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByVaultNameParameterSet,
            Position = 1)]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByVaultNameParameterSet,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyNameParameterSet,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByKeyNameParameterSet,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByKeyNameParameterSet,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyVersionsParameterSet,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByKeyVersionsParameterSet,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByKeyVersionsParameterSet,
            Position = 1)]
        [Parameter(Mandatory = false,
            ParameterSetName = HsmByVaultNameParameterSet,
            Position = 1)]
        [Parameter(Mandatory = false,
            ParameterSetName = HsmInputObjectByVaultNameParameterSet,
            Position = 1)]
        [Parameter(Mandatory = false,
            ParameterSetName = HsmResourceIdByVaultNameParameterSet,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmByKeyNameParameterSet,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmInputObjectByKeyNameParameterSet,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmResourceIdByKeyNameParameterSet,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmByKeyVersionsParameterSet,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmInputObjectByKeyVersionsParameterSet,
            Position = 1)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmResourceIdByKeyVersionsParameterSet,
            Position = 1)]
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
            Position = 2)]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByKeyNameParameterSet,
            Position = 2)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmByKeyNameParameterSet,
            Position = 2)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmInputObjectByKeyNameParameterSet,
            Position = 2)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmResourceIdByKeyNameParameterSet,
            Position = 2)]
        [Alias("KeyVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyVersionsParameterSet,
            HelpMessage = "Specifies whether to include the versions of the key in the output.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByKeyVersionsParameterSet)]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByKeyVersionsParameterSet)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmByKeyVersionsParameterSet)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmInputObjectByKeyVersionsParameterSet)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmResourceIdByKeyVersionsParameterSet)]
        public SwitchParameter IncludeVersions { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Specifies whether to show the previously deleted keys in the output.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByVaultNameParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByVaultNameParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = HsmByVaultNameParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = HsmInputObjectByVaultNameParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = HsmResourceIdByVaultNameParameterSet)]
        public SwitchParameter InRemovedState { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies the output file for which this cmdlet saves the key. The public key is saved in PEM format by default.")]
        [ValidateNotNullOrEmpty]
        public string OutFile { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();
            if (string.IsNullOrEmpty(HsmName))
            {
                GetKeyVaultKey();
            }
            else
            {
                GetHsmKey();
            }
        }

        private void GetHsmKey()
        {
            PSKeyVaultKey keyBundle = null;
            if (!string.IsNullOrEmpty(Version))
            {
                keyBundle = this.Track2DataClient.GetManagedHsmKey(HsmName, Name, Version);
                WriteObject(keyBundle);
            }
            else if (IncludeVersions.IsPresent)
            {
                WriteObject(this.Track2DataClient.GetManagedHsmKeyAllVersions(HsmName, Name), true);
            }
            else if (InRemovedState.IsPresent)
            {
                if (string.IsNullOrEmpty(Name) || WildcardPattern.ContainsWildcardCharacters(Name))
                {
                    WriteObject(KVSubResourceWildcardFilter(
                        Name, this.Track2DataClient.GetManagedHsmDeletedKeys(HsmName)),
                        true);
                }
                else
                {
                    PSDeletedKeyVaultKey deletedKeyBundle = this.Track2DataClient.GetManagedHsmDeletedKey(HsmName, Name);
                    WriteObject(deletedKeyBundle);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Name) || WildcardPattern.ContainsWildcardCharacters(Name))
                {
                    WriteObject(KVSubResourceWildcardFilter(
                        Name, this.Track2DataClient.GetManagedHsmKeys(HsmName)),
                        true);
                }
                else
                {
                    keyBundle = this.Track2DataClient.GetManagedHsmKey(HsmName, Name, string.Empty);
                    WriteObject(keyBundle);
                }
            }

            if (!string.IsNullOrEmpty(OutFile) && keyBundle != null)
            {
                DownloadKey(keyBundle.Key, OutFile);
            }
        }

        private void GetKeyVaultKey()
        {
            PSKeyVaultKey keyBundle = null;
            if (!string.IsNullOrEmpty(Version))
            {
                keyBundle = Track2DataClient.GetKey(VaultName, Name, Version);
                WriteObject(keyBundle);
            }
            else if (IncludeVersions)
            {
                keyBundle = Track2DataClient.GetKey(VaultName, Name, string.Empty);
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
                    PSDeletedKeyVaultKey deletedKeyBundle = Track2DataClient.GetDeletedKey(VaultName, Name);
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
                    keyBundle = Track2DataClient.GetKey(VaultName, Name, string.Empty);
                    WriteObject(keyBundle);
                }
            }

            if (!string.IsNullOrEmpty(OutFile) && keyBundle != null)
            {
                DownloadKey(keyBundle.Key, OutFile);
            }
        }

        private void NormalizeParameterSets()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
            }
            else if (!string.IsNullOrEmpty(ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                VaultName = parsedResourceId.ResourceName;
            }

            if (HsmObject != null)
            {
                HsmName = HsmObject.VaultName;
            }
            else if (!string.IsNullOrEmpty(HsmResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(HsmResourceId);
                HsmName = parsedResourceId.ResourceName;
            }
        }

        private void GetAndWriteKeys(string vaultName, string name) =>
            GetAndWriteObjects(new KeyVaultObjectFilterOptions
            {
                VaultName = vaultName,
                NextLink = null
            },
                (options) => KVSubResourceWildcardFilter(name, Track2DataClient.GetKeys(options)));

        private void GetAndWriteDeletedKeys(string vaultName, string name) =>
            GetAndWriteObjects(new KeyVaultObjectFilterOptions
            {
                VaultName = vaultName,
                NextLink = null
            },
                (options) => KVSubResourceWildcardFilter(name, Track2DataClient.GetDeletedKeys(options)));

        private void GetAndWriteKeyVersions(string vaultName, string name, string currentKeyVersion) =>
            GetAndWriteObjects(new KeyVaultObjectFilterOptions
            {
                VaultName = vaultName,
                NextLink = null,
                Name = name
            },
                (options) => Track2DataClient.GetKeyVersions(options).Where(k => k.Version != currentKeyVersion));

        private void DownloadKey(JsonWebKey jwk, string path)
        {
            if (CanDownloadKey(jwk, out string reason))
            {
                var pem = JwkHelper.ExportPublicKeyToPem(jwk);
                AzureSession.Instance.DataStore.WriteFile(path, pem);
                WriteDebug(string.Format(Resources.PublicKeySavedAt, path));
            }
            else
            {
                WriteWarning(reason);
            }
        }

        private bool CanDownloadKey(JsonWebKey jwk, out string reason)
        {
            reason = string.Format(Resources.DownloadNotSupported, jwk.Kty);
            return _supportedTypesForDownload.Contains(jwk.Kty);
        }
    }
}
