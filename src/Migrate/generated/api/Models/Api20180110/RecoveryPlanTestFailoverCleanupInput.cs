namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan test failover cleanup input.</summary>
    public partial class RecoveryPlanTestFailoverCleanupInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverCleanupInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverCleanupInputInternal
    {

        /// <summary>The test failover cleanup comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Comment { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverCleanupInputPropertiesInternal)Property).Comment; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverCleanupInputPropertiesInternal)Property).Comment = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverCleanupInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverCleanupInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPlanTestFailoverCleanupInputProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverCleanupInputProperties _property;

        /// <summary>The recovery plan test failover cleanup input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverCleanupInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPlanTestFailoverCleanupInputProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="RecoveryPlanTestFailoverCleanupInput" /> instance.</summary>
        public RecoveryPlanTestFailoverCleanupInput()
        {

        }
    }
    /// Recovery plan test failover cleanup input.
    public partial interface IRecoveryPlanTestFailoverCleanupInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The test failover cleanup comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The test failover cleanup comments.",
        SerializedName = @"comments",
        PossibleTypes = new [] { typeof(string) })]
        string Comment { get; set; }

    }
    /// Recovery plan test failover cleanup input.
    internal partial interface IRecoveryPlanTestFailoverCleanupInputInternal

    {
        /// <summary>The test failover cleanup comments.</summary>
        string Comment { get; set; }
        /// <summary>The recovery plan test failover cleanup input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverCleanupInputProperties Property { get; set; }

    }
}