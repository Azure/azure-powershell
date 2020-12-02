namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Migration item recovery point properties.</summary>
    public partial class MigrationRecoveryPointProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationRecoveryPointProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationRecoveryPointPropertiesInternal
    {

        /// <summary>Internal Acessors for RecoveryPointTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationRecoveryPointPropertiesInternal.RecoveryPointTime { get => this._recoveryPointTime; set { {_recoveryPointTime = value;} } }

        /// <summary>Internal Acessors for RecoveryPointType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationRecoveryPointType? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationRecoveryPointPropertiesInternal.RecoveryPointType { get => this._recoveryPointType; set { {_recoveryPointType = value;} } }

        /// <summary>Backing field for <see cref="RecoveryPointTime" /> property.</summary>
        private global::System.DateTime? _recoveryPointTime;

        /// <summary>The recovery point time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? RecoveryPointTime { get => this._recoveryPointTime; }

        /// <summary>Backing field for <see cref="RecoveryPointType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationRecoveryPointType? _recoveryPointType;

        /// <summary>The recovery point type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationRecoveryPointType? RecoveryPointType { get => this._recoveryPointType; }

        /// <summary>Creates an new <see cref="MigrationRecoveryPointProperties" /> instance.</summary>
        public MigrationRecoveryPointProperties()
        {

        }
    }
    /// Migration item recovery point properties.
    public partial interface IMigrationRecoveryPointProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The recovery point time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The recovery point time.",
        SerializedName = @"recoveryPointTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RecoveryPointTime { get;  }
        /// <summary>The recovery point type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The recovery point type.",
        SerializedName = @"recoveryPointType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationRecoveryPointType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationRecoveryPointType? RecoveryPointType { get;  }

    }
    /// Migration item recovery point properties.
    internal partial interface IMigrationRecoveryPointPropertiesInternal

    {
        /// <summary>The recovery point time.</summary>
        global::System.DateTime? RecoveryPointTime { get; set; }
        /// <summary>The recovery point type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationRecoveryPointType? RecoveryPointType { get; set; }

    }
}