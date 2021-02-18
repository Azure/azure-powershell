namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan planned failover input properties.</summary>
    public partial class RecoveryPlanPlannedFailoverInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanPlannedFailoverInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanPlannedFailoverInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FailoverDirection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections _failoverDirection;

        /// <summary>The failover direction.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections FailoverDirection { get => this._failoverDirection; set => this._failoverDirection = value; }

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput[] _providerSpecificDetail;

        /// <summary>The provider specific properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput[] ProviderSpecificDetail { get => this._providerSpecificDetail; set => this._providerSpecificDetail = value; }

        /// <summary>
        /// Creates an new <see cref="RecoveryPlanPlannedFailoverInputProperties" /> instance.
        /// </summary>
        public RecoveryPlanPlannedFailoverInputProperties()
        {

        }
    }
    /// Recovery plan planned failover input properties.
    public partial interface IRecoveryPlanPlannedFailoverInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The failover direction.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The failover direction.",
        SerializedName = @"failoverDirection",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections FailoverDirection { get; set; }
        /// <summary>The provider specific properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provider specific properties.",
        SerializedName = @"providerSpecificDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput[] ProviderSpecificDetail { get; set; }

    }
    /// Recovery plan planned failover input properties.
    internal partial interface IRecoveryPlanPlannedFailoverInputPropertiesInternal

    {
        /// <summary>The failover direction.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections FailoverDirection { get; set; }
        /// <summary>The provider specific properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput[] ProviderSpecificDetail { get; set; }

    }
}