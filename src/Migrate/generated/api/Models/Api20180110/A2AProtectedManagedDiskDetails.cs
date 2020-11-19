namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>A2A protected managed disk details.</summary>
    public partial class A2AProtectedManagedDiskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedManagedDiskDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedManagedDiskDetailsInternal
    {

        /// <summary>Backing field for <see cref="DataPendingAtSourceAgentInMb" /> property.</summary>
        private double? _dataPendingAtSourceAgentInMb;

        /// <summary>The data pending at source virtual machine in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public double? DataPendingAtSourceAgentInMb { get => this._dataPendingAtSourceAgentInMb; set => this._dataPendingAtSourceAgentInMb = value; }

        /// <summary>
        /// Backing field for <see cref="DataPendingInStagingStorageAccountInMb" /> property.
        /// </summary>
        private double? _dataPendingInStagingStorageAccountInMb;

        /// <summary>The data pending for replication in MB at staging account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public double? DataPendingInStagingStorageAccountInMb { get => this._dataPendingInStagingStorageAccountInMb; set => this._dataPendingInStagingStorageAccountInMb = value; }

        /// <summary>Backing field for <see cref="DekKeyVaultArmId" /> property.</summary>
        private string _dekKeyVaultArmId;

        /// <summary>The KeyVault resource id for secret (BEK).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DekKeyVaultArmId { get => this._dekKeyVaultArmId; set => this._dekKeyVaultArmId = value; }

        /// <summary>Backing field for <see cref="DiskCapacityInByte" /> property.</summary>
        private long? _diskCapacityInByte;

        /// <summary>The disk capacity in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? DiskCapacityInByte { get => this._diskCapacityInByte; set => this._diskCapacityInByte = value; }

        /// <summary>Backing field for <see cref="DiskId" /> property.</summary>
        private string _diskId;

        /// <summary>The managed disk Arm id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskId { get => this._diskId; set => this._diskId = value; }

        /// <summary>Backing field for <see cref="DiskName" /> property.</summary>
        private string _diskName;

        /// <summary>The disk name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskName { get => this._diskName; set => this._diskName = value; }

        /// <summary>Backing field for <see cref="DiskType" /> property.</summary>
        private string _diskType;

        /// <summary>The type of disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskType { get => this._diskType; set => this._diskType = value; }

        /// <summary>Backing field for <see cref="IsDiskEncrypted" /> property.</summary>
        private bool? _isDiskEncrypted;

        /// <summary>A value indicating whether vm has encrypted os disk or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? IsDiskEncrypted { get => this._isDiskEncrypted; set => this._isDiskEncrypted = value; }

        /// <summary>Backing field for <see cref="IsDiskKeyEncrypted" /> property.</summary>
        private bool? _isDiskKeyEncrypted;

        /// <summary>A value indicating whether disk key got encrypted or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? IsDiskKeyEncrypted { get => this._isDiskKeyEncrypted; set => this._isDiskKeyEncrypted = value; }

        /// <summary>Backing field for <see cref="KekKeyVaultArmId" /> property.</summary>
        private string _kekKeyVaultArmId;

        /// <summary>The KeyVault resource id for key (KEK).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string KekKeyVaultArmId { get => this._kekKeyVaultArmId; set => this._kekKeyVaultArmId = value; }

        /// <summary>Backing field for <see cref="KeyIdentifier" /> property.</summary>
        private string _keyIdentifier;

        /// <summary>The key URL / identifier (KEK).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string KeyIdentifier { get => this._keyIdentifier; set => this._keyIdentifier = value; }

        /// <summary>Backing field for <see cref="MonitoringJobType" /> property.</summary>
        private string _monitoringJobType;

        /// <summary>
        /// The type of the monitoring job. The progress is contained in MonitoringPercentageCompletion property.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MonitoringJobType { get => this._monitoringJobType; set => this._monitoringJobType = value; }

        /// <summary>Backing field for <see cref="MonitoringPercentageCompletion" /> property.</summary>
        private int? _monitoringPercentageCompletion;

        /// <summary>
        /// The percentage of the monitoring job. The type of the monitoring job is defined by MonitoringJobType property.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? MonitoringPercentageCompletion { get => this._monitoringPercentageCompletion; set => this._monitoringPercentageCompletion = value; }

        /// <summary>Backing field for <see cref="PrimaryStagingAzureStorageAccountId" /> property.</summary>
        private string _primaryStagingAzureStorageAccountId;

        /// <summary>The primary staging storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryStagingAzureStorageAccountId { get => this._primaryStagingAzureStorageAccountId; set => this._primaryStagingAzureStorageAccountId = value; }

        /// <summary>Backing field for <see cref="RecoveryReplicaDiskAccountType" /> property.</summary>
        private string _recoveryReplicaDiskAccountType;

        /// <summary>
        /// The replica disk type. Its an optional value and will be same as source disk type if not user provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryReplicaDiskAccountType { get => this._recoveryReplicaDiskAccountType; set => this._recoveryReplicaDiskAccountType = value; }

        /// <summary>Backing field for <see cref="RecoveryReplicaDiskId" /> property.</summary>
        private string _recoveryReplicaDiskId;

        /// <summary>Recovery replica disk Arm Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryReplicaDiskId { get => this._recoveryReplicaDiskId; set => this._recoveryReplicaDiskId = value; }

        /// <summary>Backing field for <see cref="RecoveryResourceGroupId" /> property.</summary>
        private string _recoveryResourceGroupId;

        /// <summary>The recovery disk resource group Arm Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryResourceGroupId { get => this._recoveryResourceGroupId; set => this._recoveryResourceGroupId = value; }

        /// <summary>Backing field for <see cref="RecoveryTargetDiskAccountType" /> property.</summary>
        private string _recoveryTargetDiskAccountType;

        /// <summary>
        /// The target disk type after failover. Its an optional value and will be same as source disk type if not user provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryTargetDiskAccountType { get => this._recoveryTargetDiskAccountType; set => this._recoveryTargetDiskAccountType = value; }

        /// <summary>Backing field for <see cref="RecoveryTargetDiskId" /> property.</summary>
        private string _recoveryTargetDiskId;

        /// <summary>Recovery target disk Arm Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryTargetDiskId { get => this._recoveryTargetDiskId; set => this._recoveryTargetDiskId = value; }

        /// <summary>Backing field for <see cref="ResyncRequired" /> property.</summary>
        private bool? _resyncRequired;

        /// <summary>A value indicating whether resync is required for this disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? ResyncRequired { get => this._resyncRequired; set => this._resyncRequired = value; }

        /// <summary>Backing field for <see cref="SecretIdentifier" /> property.</summary>
        private string _secretIdentifier;

        /// <summary>The secret URL / identifier (BEK).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SecretIdentifier { get => this._secretIdentifier; set => this._secretIdentifier = value; }

        /// <summary>Creates an new <see cref="A2AProtectedManagedDiskDetails" /> instance.</summary>
        public A2AProtectedManagedDiskDetails()
        {

        }
    }
    /// A2A protected managed disk details.
    public partial interface IA2AProtectedManagedDiskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The data pending at source virtual machine in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The data pending at source virtual machine in MB.",
        SerializedName = @"dataPendingAtSourceAgentInMB",
        PossibleTypes = new [] { typeof(double) })]
        double? DataPendingAtSourceAgentInMb { get; set; }
        /// <summary>The data pending for replication in MB at staging account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The data pending for replication in MB at staging account.",
        SerializedName = @"dataPendingInStagingStorageAccountInMB",
        PossibleTypes = new [] { typeof(double) })]
        double? DataPendingInStagingStorageAccountInMb { get; set; }
        /// <summary>The KeyVault resource id for secret (BEK).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The KeyVault resource id for secret (BEK).",
        SerializedName = @"dekKeyVaultArmId",
        PossibleTypes = new [] { typeof(string) })]
        string DekKeyVaultArmId { get; set; }
        /// <summary>The disk capacity in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The disk capacity in bytes.",
        SerializedName = @"diskCapacityInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? DiskCapacityInByte { get; set; }
        /// <summary>The managed disk Arm id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The managed disk Arm id.",
        SerializedName = @"diskId",
        PossibleTypes = new [] { typeof(string) })]
        string DiskId { get; set; }
        /// <summary>The disk name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The disk name.",
        SerializedName = @"diskName",
        PossibleTypes = new [] { typeof(string) })]
        string DiskName { get; set; }
        /// <summary>The type of disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of disk.",
        SerializedName = @"diskType",
        PossibleTypes = new [] { typeof(string) })]
        string DiskType { get; set; }
        /// <summary>A value indicating whether vm has encrypted os disk or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether vm has encrypted os disk or not.",
        SerializedName = @"isDiskEncrypted",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDiskEncrypted { get; set; }
        /// <summary>A value indicating whether disk key got encrypted or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether disk key got encrypted or not.",
        SerializedName = @"isDiskKeyEncrypted",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDiskKeyEncrypted { get; set; }
        /// <summary>The KeyVault resource id for key (KEK).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The KeyVault resource id for key (KEK).",
        SerializedName = @"kekKeyVaultArmId",
        PossibleTypes = new [] { typeof(string) })]
        string KekKeyVaultArmId { get; set; }
        /// <summary>The key URL / identifier (KEK).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key URL / identifier (KEK).",
        SerializedName = @"keyIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string KeyIdentifier { get; set; }
        /// <summary>
        /// The type of the monitoring job. The progress is contained in MonitoringPercentageCompletion property.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the monitoring job. The progress is contained in MonitoringPercentageCompletion property.",
        SerializedName = @"monitoringJobType",
        PossibleTypes = new [] { typeof(string) })]
        string MonitoringJobType { get; set; }
        /// <summary>
        /// The percentage of the monitoring job. The type of the monitoring job is defined by MonitoringJobType property.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The percentage of the monitoring job. The type of the monitoring job is defined by MonitoringJobType property.",
        SerializedName = @"monitoringPercentageCompletion",
        PossibleTypes = new [] { typeof(int) })]
        int? MonitoringPercentageCompletion { get; set; }
        /// <summary>The primary staging storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary staging storage account.",
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
        /// <summary>Recovery replica disk Arm Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Recovery replica disk Arm Id.",
        SerializedName = @"recoveryReplicaDiskId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryReplicaDiskId { get; set; }
        /// <summary>The recovery disk resource group Arm Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery disk resource group Arm Id.",
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
        /// <summary>Recovery target disk Arm Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Recovery target disk Arm Id.",
        SerializedName = @"recoveryTargetDiskId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryTargetDiskId { get; set; }
        /// <summary>A value indicating whether resync is required for this disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether resync is required for this disk.",
        SerializedName = @"resyncRequired",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ResyncRequired { get; set; }
        /// <summary>The secret URL / identifier (BEK).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The secret URL / identifier (BEK).",
        SerializedName = @"secretIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string SecretIdentifier { get; set; }

    }
    /// A2A protected managed disk details.
    internal partial interface IA2AProtectedManagedDiskDetailsInternal

    {
        /// <summary>The data pending at source virtual machine in MB.</summary>
        double? DataPendingAtSourceAgentInMb { get; set; }
        /// <summary>The data pending for replication in MB at staging account.</summary>
        double? DataPendingInStagingStorageAccountInMb { get; set; }
        /// <summary>The KeyVault resource id for secret (BEK).</summary>
        string DekKeyVaultArmId { get; set; }
        /// <summary>The disk capacity in bytes.</summary>
        long? DiskCapacityInByte { get; set; }
        /// <summary>The managed disk Arm id.</summary>
        string DiskId { get; set; }
        /// <summary>The disk name.</summary>
        string DiskName { get; set; }
        /// <summary>The type of disk.</summary>
        string DiskType { get; set; }
        /// <summary>A value indicating whether vm has encrypted os disk or not.</summary>
        bool? IsDiskEncrypted { get; set; }
        /// <summary>A value indicating whether disk key got encrypted or not.</summary>
        bool? IsDiskKeyEncrypted { get; set; }
        /// <summary>The KeyVault resource id for key (KEK).</summary>
        string KekKeyVaultArmId { get; set; }
        /// <summary>The key URL / identifier (KEK).</summary>
        string KeyIdentifier { get; set; }
        /// <summary>
        /// The type of the monitoring job. The progress is contained in MonitoringPercentageCompletion property.
        /// </summary>
        string MonitoringJobType { get; set; }
        /// <summary>
        /// The percentage of the monitoring job. The type of the monitoring job is defined by MonitoringJobType property.
        /// </summary>
        int? MonitoringPercentageCompletion { get; set; }
        /// <summary>The primary staging storage account.</summary>
        string PrimaryStagingAzureStorageAccountId { get; set; }
        /// <summary>
        /// The replica disk type. Its an optional value and will be same as source disk type if not user provided.
        /// </summary>
        string RecoveryReplicaDiskAccountType { get; set; }
        /// <summary>Recovery replica disk Arm Id.</summary>
        string RecoveryReplicaDiskId { get; set; }
        /// <summary>The recovery disk resource group Arm Id.</summary>
        string RecoveryResourceGroupId { get; set; }
        /// <summary>
        /// The target disk type after failover. Its an optional value and will be same as source disk type if not user provided.
        /// </summary>
        string RecoveryTargetDiskAccountType { get; set; }
        /// <summary>Recovery target disk Arm Id.</summary>
        string RecoveryTargetDiskId { get; set; }
        /// <summary>A value indicating whether resync is required for this disk.</summary>
        bool? ResyncRequired { get; set; }
        /// <summary>The secret URL / identifier (BEK).</summary>
        string SecretIdentifier { get; set; }

    }
}