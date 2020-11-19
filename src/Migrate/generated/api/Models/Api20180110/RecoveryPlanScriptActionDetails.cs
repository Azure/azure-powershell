namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan script action details.</summary>
    public partial class RecoveryPlanScriptActionDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanScriptActionDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanScriptActionDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetails __recoveryPlanActionDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPlanActionDetails();

        /// <summary>Backing field for <see cref="FabricLocation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RecoveryPlanActionLocation _fabricLocation;

        /// <summary>The fabric location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RecoveryPlanActionLocation FabricLocation { get => this._fabricLocation; set => this._fabricLocation = value; }

        /// <summary>
        /// Gets the type of action details (see RecoveryPlanActionDetailsTypes enum for possible values).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal)__recoveryPlanActionDetails).InstanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal)__recoveryPlanActionDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal)__recoveryPlanActionDetails).InstanceType = value; }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        /// <summary>The script path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Path { get => this._path; set => this._path = value; }

        /// <summary>Backing field for <see cref="Timeout" /> property.</summary>
        private string _timeout;

        /// <summary>The script timeout.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Timeout { get => this._timeout; set => this._timeout = value; }

        /// <summary>Creates an new <see cref="RecoveryPlanScriptActionDetails" /> instance.</summary>
        public RecoveryPlanScriptActionDetails()
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
    /// Recovery plan script action details.
    public partial interface IRecoveryPlanScriptActionDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetails
    {
        /// <summary>The fabric location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The fabric location.",
        SerializedName = @"fabricLocation",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RecoveryPlanActionLocation) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RecoveryPlanActionLocation FabricLocation { get; set; }
        /// <summary>The script path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The script path.",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get; set; }
        /// <summary>The script timeout.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The script timeout.",
        SerializedName = @"timeout",
        PossibleTypes = new [] { typeof(string) })]
        string Timeout { get; set; }

    }
    /// Recovery plan script action details.
    internal partial interface IRecoveryPlanScriptActionDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal
    {
        /// <summary>The fabric location.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RecoveryPlanActionLocation FabricLocation { get; set; }
        /// <summary>The script path.</summary>
        string Path { get; set; }
        /// <summary>The script timeout.</summary>
        string Timeout { get; set; }

    }
}