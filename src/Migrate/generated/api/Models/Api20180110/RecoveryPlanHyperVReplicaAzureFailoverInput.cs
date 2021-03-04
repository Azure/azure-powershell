namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan HVR Azure failover input.</summary>
    public partial class RecoveryPlanHyperVReplicaAzureFailoverInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanHyperVReplicaAzureFailoverInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanHyperVReplicaAzureFailoverInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput __recoveryPlanProviderSpecificFailoverInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPlanProviderSpecificFailoverInput();

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInputInternal)__recoveryPlanProviderSpecificFailoverInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInputInternal)__recoveryPlanProviderSpecificFailoverInput).InstanceType = value ?? null; }

        /// <summary>Backing field for <see cref="PrimaryKekCertificatePfx" /> property.</summary>
        private string _primaryKekCertificatePfx;

        /// <summary>The primary KEK certificate PFX.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryKekCertificatePfx { get => this._primaryKekCertificatePfx; set => this._primaryKekCertificatePfx = value; }

        /// <summary>Backing field for <see cref="RecoveryPointType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HyperVReplicaAzureRpRecoveryPointType? _recoveryPointType;

        /// <summary>The recovery point type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HyperVReplicaAzureRpRecoveryPointType? RecoveryPointType { get => this._recoveryPointType; set => this._recoveryPointType = value; }

        /// <summary>Backing field for <see cref="SecondaryKekCertificatePfx" /> property.</summary>
        private string _secondaryKekCertificatePfx;

        /// <summary>The secondary KEK certificate PFX.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SecondaryKekCertificatePfx { get => this._secondaryKekCertificatePfx; set => this._secondaryKekCertificatePfx = value; }

        /// <summary>Backing field for <see cref="VaultLocation" /> property.</summary>
        private string _vaultLocation;

        /// <summary>The vault location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VaultLocation { get => this._vaultLocation; set => this._vaultLocation = value; }

        /// <summary>
        /// Creates an new <see cref="RecoveryPlanHyperVReplicaAzureFailoverInput" /> instance.
        /// </summary>
        public RecoveryPlanHyperVReplicaAzureFailoverInput()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__recoveryPlanProviderSpecificFailoverInput), __recoveryPlanProviderSpecificFailoverInput);
            await eventListener.AssertObjectIsValid(nameof(__recoveryPlanProviderSpecificFailoverInput), __recoveryPlanProviderSpecificFailoverInput);
        }
    }
    /// Recovery plan HVR Azure failover input.
    public partial interface IRecoveryPlanHyperVReplicaAzureFailoverInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput
    {
        /// <summary>The primary KEK certificate PFX.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary KEK certificate PFX.",
        SerializedName = @"primaryKekCertificatePfx",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryKekCertificatePfx { get; set; }
        /// <summary>The recovery point type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery point type.",
        SerializedName = @"recoveryPointType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HyperVReplicaAzureRpRecoveryPointType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HyperVReplicaAzureRpRecoveryPointType? RecoveryPointType { get; set; }
        /// <summary>The secondary KEK certificate PFX.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The secondary KEK certificate PFX.",
        SerializedName = @"secondaryKekCertificatePfx",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryKekCertificatePfx { get; set; }
        /// <summary>The vault location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The vault location.",
        SerializedName = @"vaultLocation",
        PossibleTypes = new [] { typeof(string) })]
        string VaultLocation { get; set; }

    }
    /// Recovery plan HVR Azure failover input.
    internal partial interface IRecoveryPlanHyperVReplicaAzureFailoverInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInputInternal
    {
        /// <summary>The primary KEK certificate PFX.</summary>
        string PrimaryKekCertificatePfx { get; set; }
        /// <summary>The recovery point type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HyperVReplicaAzureRpRecoveryPointType? RecoveryPointType { get; set; }
        /// <summary>The secondary KEK certificate PFX.</summary>
        string SecondaryKekCertificatePfx { get; set; }
        /// <summary>The vault location.</summary>
        string VaultLocation { get; set; }

    }
}