using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Key
{
    public class KeyVaultKeyCmdletBase : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        internal const string ByVaultNameParameterSet = "ByVaultName";
        internal const string ByHsmNameParameterSet = "ByHsmName";
        internal const string ByKeyInputObjectParameterSet = "ByKeyInputObject";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Vault name.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByHsmNameParameterSet,
            HelpMessage = "HSM name.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName { get; set; }

        /// <summary>
        /// Key name.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Key name.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = ByHsmNameParameterSet,
            HelpMessage = "Key name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.KeyName)]
        public string Name { get; set; }

        /// <summary>
        /// Key object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByKeyInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Key object")]
        [ValidateNotNullOrEmpty]
        [Alias("Key")]
        public PSKeyVaultKeyIdentityItem InputObject { get; set; }

        /// <summary>
        /// Key version.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Key version.")]
        [Alias("KeyVersion")]
        public string Version { get; set; }

        #endregion Input Parameter Definitions

        internal void NormalizeParameterSets()
        {
            if (InputObject != null) { 
                Name = InputObject.Name;
                Version = Version ?? InputObject.Version;

                if (InputObject.IsHsm)
                {
                    HsmName = InputObject.VaultName;
                }
                else
                {
                    VaultName = InputObject.VaultName;
                }
            }
        }
    }
}
