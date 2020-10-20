namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Hyper-V Replica Azure specific protection profile details.</summary>
    public partial class HyperVReplicaAzurePolicyDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzurePolicyDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzurePolicyDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetails __policyProviderSpecificDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.PolicyProviderSpecificDetails();

        /// <summary>Backing field for <see cref="ActiveStorageAccountId" /> property.</summary>
        private string _activeStorageAccountId;

        /// <summary>The active storage account Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ActiveStorageAccountId { get => this._activeStorageAccountId; set => this._activeStorageAccountId = value; }

        /// <summary>
        /// Backing field for <see cref="ApplicationConsistentSnapshotFrequencyInHour" /> property.
        /// </summary>
        private int? _applicationConsistentSnapshotFrequencyInHour;

        /// <summary>
        /// The interval (in hours) at which Hyper-V Replica should create an application consistent snapshot within the VM.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ApplicationConsistentSnapshotFrequencyInHour { get => this._applicationConsistentSnapshotFrequencyInHour; set => this._applicationConsistentSnapshotFrequencyInHour = value; }

        /// <summary>Backing field for <see cref="Encryption" /> property.</summary>
        private string _encryption;

        /// <summary>
        /// A value indicating whether encryption is enabled for virtual machines in this cloud.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Encryption { get => this._encryption; set => this._encryption = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetailsInternal)__policyProviderSpecificDetails).InstanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetailsInternal)__policyProviderSpecificDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetailsInternal)__policyProviderSpecificDetails).InstanceType = value; }

        /// <summary>Backing field for <see cref="OnlineReplicationStartTime" /> property.</summary>
        private string _onlineReplicationStartTime;

        /// <summary>
        /// The scheduled start time for the initial replication. If this parameter is Null, the initial replication starts immediately.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OnlineReplicationStartTime { get => this._onlineReplicationStartTime; set => this._onlineReplicationStartTime = value; }

        /// <summary>Backing field for <see cref="RecoveryPointHistoryDurationInHour" /> property.</summary>
        private int? _recoveryPointHistoryDurationInHour;

        /// <summary>
        /// The duration (in hours) to which point the recovery history needs to be maintained.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? RecoveryPointHistoryDurationInHour { get => this._recoveryPointHistoryDurationInHour; set => this._recoveryPointHistoryDurationInHour = value; }

        /// <summary>Backing field for <see cref="ReplicationInterval" /> property.</summary>
        private int? _replicationInterval;

        /// <summary>The replication interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ReplicationInterval { get => this._replicationInterval; set => this._replicationInterval = value; }

        /// <summary>Creates an new <see cref="HyperVReplicaAzurePolicyDetails" /> instance.</summary>
        public HyperVReplicaAzurePolicyDetails()
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
            await eventListener.AssertNotNull(nameof(__policyProviderSpecificDetails), __policyProviderSpecificDetails);
            await eventListener.AssertObjectIsValid(nameof(__policyProviderSpecificDetails), __policyProviderSpecificDetails);
        }
    }
    /// Hyper-V Replica Azure specific protection profile details.
    public partial interface IHyperVReplicaAzurePolicyDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetails
    {
        /// <summary>The active storage account Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The active storage account Id.",
        SerializedName = @"activeStorageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveStorageAccountId { get; set; }
        /// <summary>
        /// The interval (in hours) at which Hyper-V Replica should create an application consistent snapshot within the VM.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The interval (in hours) at which Hyper-V Replica should create an application consistent snapshot within the VM.",
        SerializedName = @"applicationConsistentSnapshotFrequencyInHours",
        PossibleTypes = new [] { typeof(int) })]
        int? ApplicationConsistentSnapshotFrequencyInHour { get; set; }
        /// <summary>
        /// A value indicating whether encryption is enabled for virtual machines in this cloud.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether encryption is enabled for virtual machines in this cloud.",
        SerializedName = @"encryption",
        PossibleTypes = new [] { typeof(string) })]
        string Encryption { get; set; }
        /// <summary>
        /// The scheduled start time for the initial replication. If this parameter is Null, the initial replication starts immediately.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The scheduled start time for the initial replication. If this parameter is Null, the initial replication starts immediately.",
        SerializedName = @"onlineReplicationStartTime",
        PossibleTypes = new [] { typeof(string) })]
        string OnlineReplicationStartTime { get; set; }
        /// <summary>
        /// The duration (in hours) to which point the recovery history needs to be maintained.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The duration (in hours) to which point the recovery history needs to be maintained.",
        SerializedName = @"recoveryPointHistoryDurationInHours",
        PossibleTypes = new [] { typeof(int) })]
        int? RecoveryPointHistoryDurationInHour { get; set; }
        /// <summary>The replication interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The replication interval.",
        SerializedName = @"replicationInterval",
        PossibleTypes = new [] { typeof(int) })]
        int? ReplicationInterval { get; set; }

    }
    /// Hyper-V Replica Azure specific protection profile details.
    internal partial interface IHyperVReplicaAzurePolicyDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetailsInternal
    {
        /// <summary>The active storage account Id.</summary>
        string ActiveStorageAccountId { get; set; }
        /// <summary>
        /// The interval (in hours) at which Hyper-V Replica should create an application consistent snapshot within the VM.
        /// </summary>
        int? ApplicationConsistentSnapshotFrequencyInHour { get; set; }
        /// <summary>
        /// A value indicating whether encryption is enabled for virtual machines in this cloud.
        /// </summary>
        string Encryption { get; set; }
        /// <summary>
        /// The scheduled start time for the initial replication. If this parameter is Null, the initial replication starts immediately.
        /// </summary>
        string OnlineReplicationStartTime { get; set; }
        /// <summary>
        /// The duration (in hours) to which point the recovery history needs to be maintained.
        /// </summary>
        int? RecoveryPointHistoryDurationInHour { get; set; }
        /// <summary>The replication interval.</summary>
        int? ReplicationInterval { get; set; }

    }
}