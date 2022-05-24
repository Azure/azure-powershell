using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Key
{
    /// <summary>
    /// Updates the KeyRotationPolicy for the specified key in Key Vault.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKeyRotationPolicy", SupportsShouldProcess = true, DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSKeyRotationPolicy))]
    public class SetAzKeyVaultKeyRotationPolicy: KeyVaultOnlyKeyCmdletBase
    {
        #region Parameter Set Names

        internal const string ByKeyRotationPolicyInputObjectParameterSet = "ByKeyRotationPolicyInputObject";

        #endregion

        #region Input Parameter Definitions

        [Parameter(Mandatory = true,
                 Position = 0,
                 ParameterSetName = ByKeyRotationPolicyInputObjectParameterSet,
                 ValueFromPipeline = true,
                 HelpMessage = "PSKeyRotationPolicy object.")]
        public PSKeyRotationPolicy KeyRotationPolicy { get; set; }

        [Parameter(ParameterSetName = ByVaultNameParameterSet, 
            HelpMessage = "The time span when the key rotation policy will expire. It should be at least 28 days.")]
        [Parameter(ParameterSetName = ByKeyInputObjectParameterSet)]
        public TimeSpan ExpiresIn { get; set; }


        [Parameter(ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "PSKeyRotationLifetimeAction object.")]
        [Parameter(ParameterSetName = ByKeyInputObjectParameterSet)]
        public PSKeyRotationLifetimeAction[] KeyRotationLifetimeAction { get; set; }

        #endregion

        internal override void NormalizeParameterSets()
        {
            if (null != InputObject)
            {
                Name = InputObject.Name;

                if (InputObject.IsHsm)
                {
                    throw new NotImplementedException("Updating key rotation policy on managed HSM is not supported yet");
                }
                else
                {
                    VaultName = InputObject.VaultName;
                }
            }

            if (!this.ParameterSetName.Equals(ByKeyRotationPolicyInputObjectParameterSet))
            {

                // Only update specified parameter, others keep same
                KeyRotationPolicy = Track2DataClient.GetKeyRotationPolicy(VaultName, Name) ?? 
                    new PSKeyRotationPolicy() 
                    { 
                        VaultName = VaultName,
                        KeyName = Name,
                        ExpiresIn = null,
                        LifetimeActions = null
                    };

                if (MyInvocation.BoundParameters.ContainsKey("ExpiresIn"))
                {
                    KeyRotationPolicy.ExpiresIn = ExpiresIn;
                }

                if (MyInvocation.BoundParameters.ContainsKey("KeyRotationLifetimeAction"))
                {
                    KeyRotationPolicy.LifetimeActions = KeyRotationLifetimeAction;
                }
            }
        }

        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();

            ConfirmAction(KeyRotationPolicy.KeyName, Properties.Resources.SetKeyRotationPolicy, () => 
            {
                WriteObject(this.Track2DataClient.SetKeyRotationPolicy(KeyRotationPolicy));
            });
        }
    }
}
