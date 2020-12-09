namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Azure VM managed disk input details.</summary>
    public partial class A2AvmManagedDiskInputDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmManagedDiskInputDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmManagedDiskInputDetailsInternal
    {

        /// <summary>Backing field for <see cref="DiskId" /> property.</summary>
        private string _diskId;

        /// <summary>The disk Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskId { get => this._diskId; set => this._diskId = value; }

        /// <summary>Backing field for <see cref="PrimaryStagingAzureStorageAccountId" /> property.</summary>
        private string _primaryStagingAzureStorageAccountId;

        /// <summary>The primary staging storage account Arm Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryStagingAzureStorageAccountId { get => this._primaryStagingAzureStorageAccountId; set => this._primaryStagingAzureStorageAccountId = value; }

        /// <summary>Backing field for <see cref="RecoveryReplicaDiskAccountType" /> property.</summary>
        private string _recoveryReplicaDiskAccountType;

        /// <summary>
        /// The replica disk type. Its an optional value and will be same as source disk type if not user provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryReplicaDiskAccountType { get => this._recoveryReplicaDiskAccountType; set => this._recoveryReplicaDiskAccountType = value; }

        /// <summary>Backing field for <see cref="RecoveryResourceGroupId" /> property.</summary>
        private string _recoveryResourceGroupId;

        /// <summary>The target resource group Arm Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryResourceGroupId { get => this._recoveryResourceGroupId; set => this._recoveryResourceGroupId = value; }

        /// <summary>Backing field for <see cref="RecoveryTargetDiskAccountType" /> property.</summary>
        private string _recoveryTargetDiskAccountType;

        /// <summary>
        /// The target disk type after failover. Its an optional value and will be same as source disk type if not user provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryTargetDiskAccountType { get => this._recoveryTargetDiskAccountType; set => this._recoveryTargetDiskAccountType = value; }

        /// <summary>Creates an new <see cref="A2AvmManagedDiskInputDetails" /> instance.</summary>
        public A2AvmManagedDiskInputDetails()
        {

        }
    }
    /// Azure VM managed disk input details.
    public partial interface IA2AvmManagedDiskInputDetails :
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
        /// <summary>The primary staging storage account Arm Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary staging storage account Arm Id.",
        SerializedName = @"primaryStagingAzureStorageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryStagingAzureStorageAccountId { get; set; }
        /// <summary>
        /// The replica disk type. Its an optional value and will be same as source disk type if not user provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The replica disk type. Its an optional value and will be same as source disk type if not user provided.",
        SerializedName = @"recoveryReplicaDiskAccountType",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryReplicaDiskAccountType { get; set; }
        /// <summary>The target resource group Arm Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target resource group Arm Id.",
        SerializedName = @"recoveryResourceGroupId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryResourceGroupId { get; set; }
        /// <summary>
        /// The target disk type after failover. Its an optional value and will be same as source disk type if not user provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target disk type after failover. Its an optional value and will be same as source disk type if not user provided.",
        SerializedName = @"recoveryTargetDiskAccountType",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryTargetDiskAccountType { get; set; }

    }
    /// Azure VM managed disk input details.
    internal partial interface IA2AvmManagedDiskInputDetailsInternal

    {
        /// <summary>The disk Id.</summary>
        string DiskId { get; set; }
        /// <summary>The primary staging storage account Arm Id.</summary>
        string PrimaryStagingAzureStorageAccountId { get; set; }
        /// <summary>
        /// The replica disk type. Its an optional value and will be same as source disk type if not user provided.
        /// </summary>
        string RecoveryReplicaDiskAccountType { get; set; }
        /// <summary>The target resource group Arm Id.</summary>
        string RecoveryResourceGroupId { get; set; }
        /// <summary>
        /// The target disk type after failover. Its an optional value and will be same as source disk type if not user provided.
        /// </summary>
        string RecoveryTargetDiskAccountType { get; set; }

    }
}