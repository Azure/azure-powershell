namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan InMage failover input.</summary>
    public partial class RecoveryPlanInMageFailoverInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanInMageFailoverInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanInMageFailoverInputInternal,
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

        /// <summary>Backing field for <see cref="RecoveryPointType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RpInMageRecoveryPointType _recoveryPointType;

        /// <summary>The recovery point type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RpInMageRecoveryPointType RecoveryPointType { get => this._recoveryPointType; set => this._recoveryPointType = value; }

        /// <summary>Creates an new <see cref="RecoveryPlanInMageFailoverInput" /> instance.</summary>
        public RecoveryPlanInMageFailoverInput()
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
    /// Recovery plan InMage failover input.
    public partial interface IRecoveryPlanInMageFailoverInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput
    {
        /// <summary>The recovery point type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The recovery point type.",
        SerializedName = @"recoveryPointType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RpInMageRecoveryPointType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RpInMageRecoveryPointType RecoveryPointType { get; set; }

    }
    /// Recovery plan InMage failover input.
    internal partial interface IRecoveryPlanInMageFailoverInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInputInternal
    {
        /// <summary>The recovery point type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RpInMageRecoveryPointType RecoveryPointType { get; set; }

    }
}