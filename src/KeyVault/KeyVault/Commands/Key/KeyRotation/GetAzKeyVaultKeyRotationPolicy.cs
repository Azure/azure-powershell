using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

using System.Management.Automation;
using System;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Key
{
    /// <summary>
    /// Gets the KeyRotationPolicy for the specified key in Key Vault.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKeyRotationPolicy", DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSKeyRotationPolicy))]
    public class GetAzKeyVaultKeyRotationPolicy: KeyVaultOnlyKeyCmdletBase
    {
        internal override void NormalizeParameterSets()
        {
            if (InputObject != null)
            {
                Name = InputObject.Name;

                if (InputObject.IsHsm)
                {
                    throw new NotImplementedException("Getting key rotation policy on managed HSM is not supported yet");
                }
                else
                {
                    VaultName = InputObject.VaultName;
                }
            }
        }

        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();

            WriteObject(this.Track2DataClient.GetKeyRotationPolicy(VaultName, Name));
        }
    }
}
