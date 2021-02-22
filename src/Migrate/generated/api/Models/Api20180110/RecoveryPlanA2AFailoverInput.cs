namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan A2A failover input.</summary>
    public partial class RecoveryPlanA2AFailoverInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanA2AFailoverInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanA2AFailoverInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput __recoveryPlanProviderSpecificFailoverInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPlanProviderSpecificFailoverInput();

        /// <summary>Backing field for <see cref="CloudServiceCreationOption" /> property.</summary>
        private string _cloudServiceCreationOption;

        /// <summary>A value indicating whether to use recovery cloud service for TFO or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CloudServiceCreationOption { get => this._cloudServiceCreationOption; set => this._cloudServiceCreationOption = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInputInternal)__recoveryPlanProviderSpecificFailoverInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInputInternal)__recoveryPlanProviderSpecificFailoverInput).InstanceType = value ?? null; }

        /// <summary>Backing field for <see cref="MultiVMSyncPointOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MultiVMSyncPointOption? _multiVMSyncPointOption;

        /// <summary>
        /// A value indicating whether multi VM sync enabled VMs should use multi VM sync points for failover.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MultiVMSyncPointOption? MultiVMSyncPointOption { get => this._multiVMSyncPointOption; set => this._multiVMSyncPointOption = value; }

        /// <summary>Backing field for <see cref="RecoveryPointType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.A2ARpRecoveryPointType _recoveryPointType;

        /// <summary>The recovery point type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.A2ARpRecoveryPointType RecoveryPointType { get => this._recoveryPointType; set => this._recoveryPointType = value; }

        /// <summary>Creates an new <see cref="RecoveryPlanA2AFailoverInput" /> instance.</summary>
        public RecoveryPlanA2AFailoverInput()
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
    /// Recovery plan A2A failover input.
    public partial interface IRecoveryPlanA2AFailoverInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput
    {
        /// <summary>A value indicating whether to use recovery cloud service for TFO or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether to use recovery cloud service for TFO or not.",
        SerializedName = @"cloudServiceCreationOption",
        PossibleTypes = new [] { typeof(string) })]
        string CloudServiceCreationOption { get; set; }
        /// <summary>
        /// A value indicating whether multi VM sync enabled VMs should use multi VM sync points for failover.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether multi VM sync enabled VMs should use multi VM sync points for failover.",
        SerializedName = @"multiVmSyncPointOption",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MultiVMSyncPointOption) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MultiVMSyncPointOption? MultiVMSyncPointOption { get; set; }
        /// <summary>The recovery point type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The recovery point type.",
        SerializedName = @"recoveryPointType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.A2ARpRecoveryPointType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.A2ARpRecoveryPointType RecoveryPointType { get; set; }

    }
    /// Recovery plan A2A failover input.
    internal partial interface IRecoveryPlanA2AFailoverInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInputInternal
    {
        /// <summary>A value indicating whether to use recovery cloud service for TFO or not.</summary>
        string CloudServiceCreationOption { get; set; }
        /// <summary>
        /// A value indicating whether multi VM sync enabled VMs should use multi VM sync points for failover.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MultiVMSyncPointOption? MultiVMSyncPointOption { get; set; }
        /// <summary>The recovery point type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.A2ARpRecoveryPointType RecoveryPointType { get; set; }

    }
}