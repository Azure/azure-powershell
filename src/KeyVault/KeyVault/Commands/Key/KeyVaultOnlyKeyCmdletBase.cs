using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    public class KeyVaultOnlyKeyCmdletBase: KeyVaultCmdletBase
    {
        #region Parameter Set Names

        internal const string ByVaultNameParameterSet = "ByVaultName";
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

        /// <summary>
        /// Key name.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = ByVaultNameParameterSet,
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

        #endregion Input Parameter Definitions

        internal virtual void NormalizeParameterSets()
        {
            if (InputObject != null)
            {
                Name = InputObject.Name;

                if (InputObject.IsHsm)
                {
                    throw new NotImplementedException("Feature about key on managed HSM is not supported yet");
                }
                else
                {
                    VaultName = InputObject.VaultName;
                }
            }
        }
    }
}
