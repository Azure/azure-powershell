using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections;
using Microsoft.Azure.Commands.KeyVault.Properties;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{    /// <summary>
     /// Create a new key in managed hsm. This cmdlet supports the following types of key creation.
     /// 1. Create a key with default key attributes
     /// 2. Create a key with given key attributes
     /// 3. Create a key by importing key material with default key attributes
     /// 4 .Create a key by importing key material with given key attributes
     /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzurePrefix + "ManagedHsmKey", SupportsShouldProcess = true, DefaultParameterSetName = InteractiveCreateParameterSet)]
    [OutputType(typeof(PSManagedHsm))]
    public class AddAzureManagedHsmKey : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string InteractiveCreateParameterSet = "InteractiveCreate";
        private const string InputObjectCreateParameterSet = "InputObjectCreate";
        private const string ResourceIdCreateParameterSet = "ResourceIdCreate";
        private const string InteractiveImportParameterSet = "InteractiveImport";
        private const string InputObjectImportParameterSet = "InputObjectImport";
        private const string ResourceIdImportParameterSet = "ResourceIdImport";

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
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

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
        public PSManagedHsm InputObject { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdCreateParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault Resource Id.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdImportParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault Resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

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
            ParameterSetName = InputObjectImportParameterSet,
            HelpMessage = "Path to the local file containing the key material to be imported.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdImportParameterSet,
            HelpMessage = "Path to the local file containing the key material to be imported.")]
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
            ParameterSetName = InputObjectImportParameterSet,
            HelpMessage = "Password of the local file containing the key material to be imported.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdImportParameterSet,
            HelpMessage = "Password of the local file containing the key material to be imported.")]
        [ValidateNotNullOrEmpty]
        public SecureString KeyFilePassword { get; set; }

        /// <summary>
        /// key type
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Specifies the key type of this key.")]
        [ValidateSet("RSA", "RsaHsm", "EC", "EcHsm", "OCT")]
        public string KeyType { get; set; }

        /// <summary>
        /// curve name
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Specifies the curve name of elliptic curve cryptography, this value is valid when KeyType is EC.")]
        [ValidateSet("P-256", "P-256K", "P-384", "P-521")]
        public string CurveName { get; set; }

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
            ParameterSetName = InteractiveCreateParameterSet,
            HelpMessage = "RSA key size, in bits. If not specified, the service will provide a safe default.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdCreateParameterSet,
            HelpMessage = "RSA key size, in bits. If not specified, the service will provide a safe default.")]
        public int? Size { get; set; }
        #endregion

        public override void ExecuteCmdlet()
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

            ValidateKeyExchangeKey();

            if (ShouldProcess(Name, Properties.Resources.AddKey))
            {
                PSKeyVaultKey keyBundle;
                if (InputObject != null)
                {
                    VaultName = InputObject.VaultName.ToString();
                }
                
                if (string.IsNullOrEmpty(KeyFilePath))
                {
                    keyBundle = this.Track2DataClient.CreateManagedHsmKey(
                            VaultName,
                            Name,
                            CreateKeyAttributes(),
                            Size,
                            CurveName);
                }
                else
                {
                    throw new NotImplementedException();
                }

                this.WriteObject(keyBundle);
            }
        }
        private void ValidateKeyExchangeKey()
        {
            if (KeyOps != null && KeyOps.Contains(Constants.KeyOpsImport))
            {
                // "import" is exclusive, it cannot be combined with any other value(s).
                if (KeyOps.Length > 1) { throw new ArgumentException(Resources.KeyOpsImportIsExclusive); }
            }
        }

        internal PSKeyVaultKeyAttributes CreateKeyAttributes()
        {
              return new Models.PSKeyVaultKeyAttributes(
                !Disable.IsPresent,
                Expires,
                NotBefore,
                KeyType,
                KeyOps,
                Tag);
        }
    }
}
