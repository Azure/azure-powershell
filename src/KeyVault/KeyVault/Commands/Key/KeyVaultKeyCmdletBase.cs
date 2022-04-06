using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Key
{
    public class KeyVaultKeyCmdletBase : KeyVaultOnlyKeyCmdletBase
    {
        #region Parameter Set Names

        internal const string ByHsmNameParameterSet = "ByHsmName";

        #endregion

        #region Input Parameter Definitions

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
        public new string Name { get; set; }

        #endregion Input Parameter Definitions

        internal override void NormalizeParameterSets()
        {
            if (InputObject != null) { 
                Name = InputObject.Name;

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
