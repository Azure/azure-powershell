namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan group details.</summary>
    public partial class RecoveryPlanGroup :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroupInternal
    {

        /// <summary>Backing field for <see cref="EndGroupAction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanAction[] _endGroupAction;

        /// <summary>The end group actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanAction[] EndGroupAction { get => this._endGroupAction; set => this._endGroupAction = value; }

        /// <summary>Backing field for <see cref="GroupType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RecoveryPlanGroupType _groupType;

        /// <summary>The group type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RecoveryPlanGroupType GroupType { get => this._groupType; set => this._groupType = value; }

        /// <summary>Backing field for <see cref="ReplicationProtectedItem" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProtectedItem[] _replicationProtectedItem;

        /// <summary>The list of protected items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProtectedItem[] ReplicationProtectedItem { get => this._replicationProtectedItem; set => this._replicationProtectedItem = value; }

        /// <summary>Backing field for <see cref="StartGroupAction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanAction[] _startGroupAction;

        /// <summary>The start group actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanAction[] StartGroupAction { get => this._startGroupAction; set => this._startGroupAction = value; }

        /// <summary>Creates an new <see cref="RecoveryPlanGroup" /> instance.</summary>
        public RecoveryPlanGroup()
        {

        }
    }
    /// Recovery plan group details.
    public partial interface IRecoveryPlanGroup :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The end group actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The end group actions.",
        SerializedName = @"endGroupActions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanAction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanAction[] EndGroupAction { get; set; }
        /// <summary>The group type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The group type.",
        SerializedName = @"groupType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RecoveryPlanGroupType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RecoveryPlanGroupType GroupType { get; set; }
        /// <summary>The list of protected items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of protected items.",
        SerializedName = @"replicationProtectedItems",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProtectedItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProtectedItem[] ReplicationProtectedItem { get; set; }
        /// <summary>The start group actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start group actions.",
        SerializedName = @"startGroupActions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanAction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanAction[] StartGroupAction { get; set; }

    }
    /// Recovery plan group details.
    internal partial interface IRecoveryPlanGroupInternal

    {
        /// <summary>The end group actions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanAction[] EndGroupAction { get; set; }
        /// <summary>The group type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RecoveryPlanGroupType GroupType { get; set; }
        /// <summary>The list of protected items.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProtectedItem[] ReplicationProtectedItem { get; set; }
        /// <summary>The start group actions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanAction[] StartGroupAction { get; set; }

    }
}