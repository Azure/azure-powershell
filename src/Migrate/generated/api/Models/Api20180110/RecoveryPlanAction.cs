namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan action details.</summary>
    public partial class RecoveryPlanAction :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanAction,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionInternal
    {

        /// <summary>Backing field for <see cref="ActionName" /> property.</summary>
        private string _actionName;

        /// <summary>The action name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ActionName { get => this._actionName; set => this._actionName = value; }

        /// <summary>Backing field for <see cref="CustomDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetails _customDetail;

        /// <summary>The custom details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetails CustomDetail { get => (this._customDetail = this._customDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPlanActionDetails()); set => this._customDetail = value; }

        /// <summary>
        /// Gets the type of action details (see RecoveryPlanActionDetailsTypes enum for possible values).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CustomDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal)CustomDetail).InstanceType; }

        /// <summary>Backing field for <see cref="FailoverDirection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections[] _failoverDirection;

        /// <summary>The list of failover directions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections[] FailoverDirection { get => this._failoverDirection; set => this._failoverDirection = value; }

        /// <summary>Backing field for <see cref="FailoverType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ReplicationProtectedItemOperation[] _failoverType;

        /// <summary>The list of failover types.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ReplicationProtectedItemOperation[] FailoverType { get => this._failoverType; set => this._failoverType = value; }

        /// <summary>Internal Acessors for CustomDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionInternal.CustomDetail { get => (this._customDetail = this._customDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPlanActionDetails()); set { {_customDetail = value;} } }

        /// <summary>Internal Acessors for CustomDetailInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionInternal.CustomDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal)CustomDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal)CustomDetail).InstanceType = value; }

        /// <summary>Creates an new <see cref="RecoveryPlanAction" /> instance.</summary>
        public RecoveryPlanAction()
        {

        }
    }
    /// Recovery plan action details.
    public partial interface IRecoveryPlanAction :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The action name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The action name.",
        SerializedName = @"actionName",
        PossibleTypes = new [] { typeof(string) })]
        string ActionName { get; set; }
        /// <summary>
        /// Gets the type of action details (see RecoveryPlanActionDetailsTypes enum for possible values).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the type of action details (see RecoveryPlanActionDetailsTypes enum for possible values).",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string CustomDetailInstanceType { get;  }
        /// <summary>The list of failover directions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The list of failover directions.",
        SerializedName = @"failoverDirections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections[] FailoverDirection { get; set; }
        /// <summary>The list of failover types.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The list of failover types.",
        SerializedName = @"failoverTypes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ReplicationProtectedItemOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ReplicationProtectedItemOperation[] FailoverType { get; set; }

    }
    /// Recovery plan action details.
    internal partial interface IRecoveryPlanActionInternal

    {
        /// <summary>The action name.</summary>
        string ActionName { get; set; }
        /// <summary>The custom details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetails CustomDetail { get; set; }
        /// <summary>
        /// Gets the type of action details (see RecoveryPlanActionDetailsTypes enum for possible values).
        /// </summary>
        string CustomDetailInstanceType { get; set; }
        /// <summary>The list of failover directions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections[] FailoverDirection { get; set; }
        /// <summary>The list of failover types.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ReplicationProtectedItemOperation[] FailoverType { get; set; }

    }
}