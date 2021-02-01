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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;
using Track2Sdk = Azure.Security.KeyVault.Keys;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Create a new key in key vault. This cmdlet supports the following types of
    /// key creation.
    /// 1. Create a new HSM or software key with default key attributes
    /// 2. Create a new HSM or software key with given key attributes
    /// 3. Create a HSM or software key by importing key material with default key
    /// attributes
    /// 4 .Create a HSM or software key by importing key material with given key
    /// attributes
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKey", SupportsShouldProcess = true, DefaultParameterSetName = InteractiveCreateParameterSet)]
    [OutputType(typeof(PSKeyVaultKey))]
    public class AddAzureKeyVaultKey : KeyVaultCmdletBase
    {

        #region Parameter Set Names

        private const string InteractiveCreateParameterSet = "InteractiveCreate";
        private const string InputObjectCreateParameterSet = "InputObjectCreate";
        private const string ResourceIdCreateParameterSet = "ResourceIdCreate";
        private const string InteractiveImportParameterSet = "InteractiveImport";
        private const string InputObjectImportParameterSet = "InputObjectImport";
        private const string ResourceIdImportParameterSet = "ResourceIdImport";
        private const string HsmInteractiveCreateParameterSet = "HsmInteractiveCreate";
        private const string HsmInputObjectCreateParameterSet = "HsmInputObjectCreate";
        private const string HsmResourceIdCreateParameterSet = "HsmResourceIdCreate";
        private const string HsmInteractiveImportParameterSet = "HsmInteractiveImport";
        private const string HsmInputObjectImportParameterSet = "HsmInputObjectImport";
        private const string HsmResourceIdImportParameterSet = "HsmResourceIdImport";

        private const string HsmDestination = "HSM";
        private const string SoftwareDestination = "Software";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = InteractiveCreateParameterSet,
            Position = 0,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InteractiveImportParameterSet,
            Position = 0,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        // HsmName must not be positional
        // otherwise the parameter set is no difference with vault parameter set
        // when user does not specify parameter name
        // e.g. Add-AzKeyVaultKey 'vaultOrHsmName?' 'keyName'
        [Parameter(Mandatory = true,
            ParameterSetName = HsmInteractiveCreateParameterSet,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmInteractiveImportParameterSet,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectCreateParameterSet,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "Vault object.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectImportParameterSet,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "Vault object.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVault InputObject { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = HsmInputObjectCreateParameterSet,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "HSM object.")]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmInputObjectImportParameterSet,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "HSM object.")]
        [ValidateNotNullOrEmpty]
        public PSManagedHsm HsmObject { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdCreateParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource ID of the vault.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdImportParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = HsmResourceIdCreateParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource ID of the HSM.")]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmResourceIdImportParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string HsmResourceId { get; set; }

        /// <summary>
        /// key name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.KeyName)]
        public string Name { get; set; }

        /// <summary>
        /// Path to the local file containing to-be-imported key material.
        /// The supported suffix are:
        /// 1. byok
        /// 2. pfx
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = InteractiveImportParameterSet,
            HelpMessage = "Path to the local file containing the key material to be imported.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectImportParameterSet)]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdImportParameterSet)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmInteractiveImportParameterSet)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmInputObjectImportParameterSet)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmResourceIdImportParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyFilePath { get; set; }

        /// <summary>
        /// Password of the imported file.
        /// Required for pfx file
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = InteractiveImportParameterSet,
            HelpMessage = "Password of the local file containing the key material to be imported.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectImportParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdImportParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = HsmInteractiveImportParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = HsmInputObjectImportParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = HsmResourceIdImportParameterSet)]
        [ValidateNotNullOrEmpty]
        public SecureString KeyFilePassword { get; set; }

        /// <summary>
        /// Destination of the key
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = InteractiveCreateParameterSet,
            HelpMessage = "Specifies whether to add the key as a software-protected key or an HSM-protected key in the Key Vault service. Valid values are: HSM and Software. ")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectCreateParameterSet,
            HelpMessage = "Specifies whether to add the key as a software-protected key or an HSM-protected key in the Key Vault service. Valid values are: HSM and Software. ")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdCreateParameterSet,
            HelpMessage = "Specifies whether to add the key as a software-protected key or an HSM-protected key in the Key Vault service. Valid values are: HSM and Software. ")]
        [Parameter(Mandatory = false,
            ParameterSetName = InteractiveImportParameterSet,
            HelpMessage = "Specifies whether to add the key as a software-protected key or an HSM-protected key in the Key Vault service. Valid values are: HSM and Software. ")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectImportParameterSet,
            HelpMessage = "Specifies whether to add the key as a software-protected key or an HSM-protected key in the Key Vault service. Valid values are: HSM and Software. ")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdImportParameterSet,
            HelpMessage = "Specifies whether to add the key as a software-protected key or an HSM-protected key in the Key Vault service. Valid values are: HSM and Software. ")]
        [ValidateSet(HsmDestination, SoftwareDestination)]
        public string Destination { get; set; }

        /// <summary>
        /// Set key in disabled state if present
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Indicates that the key you are adding is set to an initial state of disabled. Any attempt to use the key will fail. Use this parameter if you are preloading keys that you intend to enable later.")]
        public SwitchParameter Disable { get; set; }

        /// <summary>
        /// Key operations
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The operations that can be performed with the key. If not present, all operations can be performed.")]
        public string[] KeyOps { get; set; }

        /// <summary>
        /// Key expires time in UTC time
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Specifies the expiration time of the key in UTC. If not specified, key will not expire.")]
        public DateTime? Expires { get; set; }

        /// <summary>
        /// The UTC time before which key can't be used
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The UTC time before which the key can't be used. If not specified, there is no limitation.")]
        public DateTime? NotBefore { get; set; }

        /// <summary>
        /// Key tags
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "A hashtable representing key tags.")]
        [Alias(Constants.TagsAlias)]
        public Hashtable Tag { get; set; }


        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectCreateParameterSet,
            HelpMessage = "RSA key size, in bits. If not specified, the service will provide a safe default.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InteractiveCreateParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdCreateParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = HsmInputObjectCreateParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = HsmInteractiveCreateParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = HsmResourceIdCreateParameterSet)]
        public int? Size { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = HsmInteractiveCreateParameterSet,
            HelpMessage = "Specifies the key type of this key. When importing BYOK keys, it defaults to 'RSA'.")]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmInputObjectCreateParameterSet)]
        [Parameter(Mandatory = true,
            ParameterSetName = HsmResourceIdCreateParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = InteractiveImportParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectImportParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdImportParameterSet)]
        [PSArgumentCompleter("RSA", "EC", "oct")]
        public string KeyType { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = HsmInteractiveCreateParameterSet,
            HelpMessage = "Specifies the curve name of elliptic curve cryptography, this value is valid when KeyType is EC.")]
        [Parameter(Mandatory = false,
            ParameterSetName = HsmInputObjectCreateParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = HsmResourceIdCreateParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = InteractiveImportParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectImportParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdImportParameterSet)]
        [PSArgumentCompleter("P-256", "P-256K", "P-384", "P-521")]
        public string CurveName { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            NormalizeKeySourceParameters();
            ValidateKeyExchangeKey();
            if (ShouldProcess(Name, Properties.Resources.AddKey))
            {
                PSKeyVaultKey keyBundle;
                if (string.IsNullOrEmpty(HsmName))
                {
                    keyBundle = CreateKeyVaultKey();
                }
                else
                {
                    keyBundle = CreateHsmKey();
                }
                this.WriteObject(keyBundle);
            }
        }

        /// <summary>
        /// Normalize different ways to specify a vault or HSM.
        /// Calling this method will set <see cref="HsmName" /> or <see cref="VaultName" />.
        /// </summary>
        private void NormalizeKeySourceParameters()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
            }
            else if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                VaultName = resourceIdentifier.ResourceName;
            }
            if (HsmObject != null)
            {
                HsmName = HsmObject.VaultName;
            }
            else if (HsmResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                HsmName = resourceIdentifier.ResourceName;
            }
        }

        private void ValidateKeyExchangeKey()
        {
            if (KeyOps != null && KeyOps.Contains(Constants.KeyOpsImport))
            {
                // "import" is exclusive, it cannot be combined with any other value(s).
                if (KeyOps.Length > 1) { throw new ArgumentException(Resources.KeyOpsImportIsExclusive); }
                // When KeyOps is 'import', KeyType MUST be RSA-HSM
                if (Destination != HsmDestination) { throw new ArgumentException(Resources.KEKMustBeHSM); }
            }
        }

        private PSKeyVaultKey CreateKeyVaultKey()
        {
            if (string.IsNullOrEmpty(KeyFilePath))
            {
                return this.DataServiceClient.CreateKey(
                        VaultName,
                        Name,
                        CreateKeyAttributes(),
                        Size,
                        null);
            }
            else
            {
                bool? importToHsm = null;
                return this.DataServiceClient.ImportKey(
                    VaultName, Name,
                    CreateKeyAttributes(),
                    CreateWebKeyFromFile(),
                    string.IsNullOrEmpty(Destination) ? importToHsm : HsmDestination.Equals(Destination, StringComparison.OrdinalIgnoreCase));
            }
        }

        private PSKeyVaultKey CreateHsmKey()
        {
            if (string.IsNullOrEmpty(KeyFilePath))
            {
                return this.Track2DataClient.CreateManagedHsmKey(
                        HsmName,
                        Name,
                        CreateKeyAttributes(),
                        Size,
                        CurveName);
            }
            else
            {
                return this.Track2DataClient.ImportManagedHsmKey(
                    HsmName, Name,
                    CreateTrack2WebKeyFromFile());
            }
        }

        internal PSKeyVaultKeyAttributes CreateKeyAttributes()
        {
            if (!string.IsNullOrEmpty(VaultName) && !string.IsNullOrEmpty(Destination))
            {
                KeyType = (HsmDestination.Equals(Destination, StringComparison.OrdinalIgnoreCase)) ? JsonWebKeyType.RsaHsm : JsonWebKeyType.Rsa;
            }

            return new Models.PSKeyVaultKeyAttributes(
                !Disable.IsPresent,
                Expires,
                NotBefore,
                KeyType,
                KeyOps,
                Tag);
        }

        internal JsonWebKey CreateWebKeyFromFile()
        {
            ValidateEcParameters();

            FileInfo keyFile = new FileInfo(this.GetUnresolvedProviderPathFromPSPath(this.KeyFilePath));
            if (!keyFile.Exists)
            {
                throw new FileNotFoundException(string.Format(Resources.KeyFileNotFound, this.KeyFilePath));
            }

            var converterChain = WebKeyConverterFactory.CreateConverterChain();
            var converterExtraInfo = new WebKeyConverterExtraInfo()
            {
                KeyType = KeyType,
                CurveName = CurveName
            };

            return converterChain.ConvertKeyFromFile(keyFile, KeyFilePassword, converterExtraInfo);
        }

        private void ValidateEcParameters()
        {
            if (JwkHelper.IsEC(KeyType) && string.IsNullOrEmpty(CurveName))
            {
                throw new AzPSArgumentException(Resources.EcButNoCurveName, nameof(CurveName));
            }

            if (!string.IsNullOrEmpty(CurveName) && !JwkHelper.IsEC(KeyType))
            {
                throw new AzPSArgumentException(Resources.CurveNameButNotEc, nameof(KeyType));
            }
        }

        internal Track2Sdk.JsonWebKey CreateTrack2WebKeyFromFile()
        {
            FileInfo keyFile = new FileInfo(this.GetUnresolvedProviderPathFromPSPath(this.KeyFilePath));
            if (!keyFile.Exists)
            {
                throw new FileNotFoundException(string.Format(Resources.KeyFileNotFound, this.KeyFilePath));
            }

            var converterChain = WebKeyConverterFactory.CreateConverterChain();
            return converterChain.ConvertToTrack2SdkKeyFromFile(keyFile, KeyFilePassword);
        }
    }
}