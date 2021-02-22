namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan HVR Azure failback input.</summary>
    public partial class RecoveryPlanHyperVReplicaAzureFailbackInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanHyperVReplicaAzureFailbackInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanHyperVReplicaAzureFailbackInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput __recoveryPlanProviderSpecificFailoverInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPlanProviderSpecificFailoverInput();

        /// <summary>Backing field for <see cref="DataSyncOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DataSyncStatus _dataSyncOption;

        /// <summary>The data sync option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DataSyncStatus DataSyncOption { get => this._dataSyncOption; set => this._dataSyncOption = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInputInternal)__recoveryPlanProviderSpecificFailoverInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInputInternal)__recoveryPlanProviderSpecificFailoverInput).InstanceType = value ?? null; }

        /// <summary>Backing field for <see cref="RecoveryVMCreationOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AlternateLocationRecoveryOption _recoveryVMCreationOption;

        /// <summary>The ALR option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AlternateLocationRecoveryOption RecoveryVMCreationOption { get => this._recoveryVMCreationOption; set => this._recoveryVMCreationOption = value; }

        /// <summary>
        /// Creates an new <see cref="RecoveryPlanHyperVReplicaAzureFailbackInput" /> instance.
        /// </summary>
        public RecoveryPlanHyperVReplicaAzureFailbackInput()
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
    /// Recovery plan HVR Azure failback input.
    public partial interface IRecoveryPlanHyperVReplicaAzureFailbackInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput
    {
        /// <summary>The data sync option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The data sync option.",
        SerializedName = @"dataSyncOption",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DataSyncStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DataSyncStatus DataSyncOption { get; set; }
        /// <summary>The ALR option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ALR option.",
        SerializedName = @"recoveryVmCreationOption",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AlternateLocationRecoveryOption) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AlternateLocationRecoveryOption RecoveryVMCreationOption { get; set; }

    }
    /// Recovery plan HVR Azure failback input.
    internal partial interface IRecoveryPlanHyperVReplicaAzureFailbackInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInputInternal
    {
        /// <summary>The data sync option.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DataSyncStatus DataSyncOption { get; set; }
        /// <summary>The ALR option.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AlternateLocationRecoveryOption RecoveryVMCreationOption { get; set; }

    }
}