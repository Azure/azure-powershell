namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan manual action details.</summary>
    public partial class RecoveryPlanManualActionDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanManualActionDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanManualActionDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetails __recoveryPlanActionDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPlanActionDetails();

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The manual action description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>
        /// Gets the type of action details (see RecoveryPlanActionDetailsTypes enum for possible values).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal)__recoveryPlanActionDetails).InstanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal)__recoveryPlanActionDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal)__recoveryPlanActionDetails).InstanceType = value; }

        /// <summary>Creates an new <see cref="RecoveryPlanManualActionDetails" /> instance.</summary>
        public RecoveryPlanManualActionDetails()
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
            await eventListener.AssertNotNull(nameof(__recoveryPlanActionDetails), __recoveryPlanActionDetails);
            await eventListener.AssertObjectIsValid(nameof(__recoveryPlanActionDetails), __recoveryPlanActionDetails);
        }
    }
    /// Recovery plan manual action details.
    public partial interface IRecoveryPlanManualActionDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetails
    {
        /// <summary>The manual action description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The manual action description.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }

    }
    /// Recovery plan manual action details.
    internal partial interface IRecoveryPlanManualActionDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal
    {
        /// <summary>The manual action description.</summary>
        string Description { get; set; }

    }
}