namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>A2A protected disk details.</summary>
    public partial class A2AProtectedDiskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal
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

        /// <summary>Backing field for <see cref="DiskUri" /> property.</summary>
        private string _diskUri;

        /// <summary>The disk uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskUri { get => this._diskUri; set => this._diskUri = value; }

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

        /// <summary>Backing field for <see cref="PrimaryDiskAzureStorageAccountId" /> property.</summary>
        private string _primaryDiskAzureStorageAccountId;

        /// <summary>The primary disk storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryDiskAzureStorageAccountId { get => this._primaryDiskAzureStorageAccountId; set => this._primaryDiskAzureStorageAccountId = value; }

        /// <summary>Backing field for <see cref="PrimaryStagingAzureStorageAccountId" /> property.</summary>
        private string _primaryStagingAzureStorageAccountId;

        /// <summary>The primary staging storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryStagingAzureStorageAccountId { get => this._primaryStagingAzureStorageAccountId; set => this._primaryStagingAzureStorageAccountId = value; }

        /// <summary>Backing field for <see cref="RecoveryAzureStorageAccountId" /> property.</summary>
        private string _recoveryAzureStorageAccountId;

        /// <summary>The recovery disk storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryAzureStorageAccountId { get => this._recoveryAzureStorageAccountId; set => this._recoveryAzureStorageAccountId = value; }

        /// <summary>Backing field for <see cref="RecoveryDiskUri" /> property.</summary>
        private string _recoveryDiskUri;

        /// <summary>Recovery disk uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryDiskUri { get => this._recoveryDiskUri; set => this._recoveryDiskUri = value; }

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

        /// <summary>Creates an new <see cref="A2AProtectedDiskDetails" /> instance.</summary>
        public A2AProtectedDiskDetails()
        {

        }
    }
    /// A2A protected disk details.
    public partial interface IA2AProtectedDiskDetails :
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
        /// <summary>The disk uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The disk uri.",
        SerializedName = @"diskUri",
        PossibleTypes = new [] { typeof(string) })]
        string DiskUri { get; set; }
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
        /// <summary>The primary disk storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary disk storage account.",
        SerializedName = @"primaryDiskAzureStorageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryDiskAzureStorageAccountId { get; set; }
        /// <summary>The primary staging storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary staging storage account.",
        SerializedName = @"primaryStagingAzureStorageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryStagingAzureStorageAccountId { get; set; }
        /// <summary>The recovery disk storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery disk storage account.",
        SerializedName = @"recoveryAzureStorageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryAzureStorageAccountId { get; set; }
        /// <summary>Recovery disk uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Recovery disk uri.",
        SerializedName = @"recoveryDiskUri",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryDiskUri { get; set; }
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
    /// A2A protected disk details.
    internal partial interface IA2AProtectedDiskDetailsInternal

    {
        /// <summary>The data pending at source virtual machine in MB.</summary>
        double? DataPendingAtSourceAgentInMb { get; set; }
        /// <summary>The data pending for replication in MB at staging account.</summary>
        double? DataPendingInStagingStorageAccountInMb { get; set; }
        /// <summary>The KeyVault resource id for secret (BEK).</summary>
        string DekKeyVaultArmId { get; set; }
        /// <summary>The disk capacity in bytes.</summary>
        long? DiskCapacityInByte { get; set; }
        /// <summary>The disk name.</summary>
        string DiskName { get; set; }
        /// <summary>The type of disk.</summary>
        string DiskType { get; set; }
        /// <summary>The disk uri.</summary>
        string DiskUri { get; set; }
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
        /// <summary>The primary disk storage account.</summary>
        string PrimaryDiskAzureStorageAccountId { get; set; }
        /// <summary>The primary staging storage account.</summary>
        string PrimaryStagingAzureStorageAccountId { get; set; }
        /// <summary>The recovery disk storage account.</summary>
        string RecoveryAzureStorageAccountId { get; set; }
        /// <summary>Recovery disk uri.</summary>
        string RecoveryDiskUri { get; set; }
        /// <summary>A value indicating whether resync is required for this disk.</summary>
        bool? ResyncRequired { get; set; }
        /// <summary>The secret URL / identifier (BEK).</summary>
        string SecretIdentifier { get; set; }

    }
}