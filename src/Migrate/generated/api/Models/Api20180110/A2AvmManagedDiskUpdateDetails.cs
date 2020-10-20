namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Azure VM managed disk update input details.</summary>
    public partial class A2AvmManagedDiskUpdateDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmManagedDiskUpdateDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmManagedDiskUpdateDetailsInternal
    {

        /// <summary>Backing field for <see cref="DiskId" /> property.</summary>
        private string _diskId;

        /// <summary>The disk Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskId { get => this._diskId; set => this._diskId = value; }

        /// <summary>Backing field for <see cref="RecoveryReplicaDiskAccountType" /> property.</summary>
        private string _recoveryReplicaDiskAccountType;

        /// <summary>The replica disk type before failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryReplicaDiskAccountType { get => this._recoveryReplicaDiskAccountType; set => this._recoveryReplicaDiskAccountType = value; }

        /// <summary>Backing field for <see cref="RecoveryTargetDiskAccountType" /> property.</summary>
        private string _recoveryTargetDiskAccountType;

        /// <summary>The target disk type before failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryTargetDiskAccountType { get => this._recoveryTargetDiskAccountType; set => this._recoveryTargetDiskAccountType = value; }

        /// <summary>Creates an new <see cref="A2AvmManagedDiskUpdateDetails" /> instance.</summary>
        public A2AvmManagedDiskUpdateDetails()
        {

        }
    }
    /// Azure VM managed disk update input details.
    public partial interface IA2AvmManagedDiskUpdateDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The disk Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The disk Id.",
        SerializedName = @"diskId",
        PossibleTypes = new [] { typeof(string) })]
        string DiskId { get; set; }
        /// <summary>The replica disk type before failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The replica disk type before failover.",
        SerializedName = @"recoveryReplicaDiskAccountType",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryReplicaDiskAccountType { get; set; }
        /// <summary>The target disk type before failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target disk type before failover.",
        SerializedName = @"recoveryTargetDiskAccountType",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryTargetDiskAccountType { get; set; }

    }
    /// Azure VM managed disk update input details.
    internal partial interface IA2AvmManagedDiskUpdateDetailsInternal

    {
        /// <summary>The disk Id.</summary>
        string DiskId { get; set; }
        /// <summary>The replica disk type before failover.</summary>
        string RecoveryReplicaDiskAccountType { get; set; }
        /// <summary>The target disk type before failover.</summary>
        string RecoveryTargetDiskAccountType { get; set; }

    }
}