namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Hyper-V Replica Azure specific input for creating a protection profile.</summary>
    public partial class HyperVReplicaAzurePolicyInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzurePolicyInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzurePolicyInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInput __policyProviderSpecificInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.PolicyProviderSpecificInput();

        /// <summary>
        /// Backing field for <see cref="ApplicationConsistentSnapshotFrequencyInHour" /> property.
        /// </summary>
        private int? _applicationConsistentSnapshotFrequencyInHour;

        /// <summary>
        /// The interval (in hours) at which Hyper-V Replica should create an application consistent snapshot within the VM.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ApplicationConsistentSnapshotFrequencyInHour { get => this._applicationConsistentSnapshotFrequencyInHour; set => this._applicationConsistentSnapshotFrequencyInHour = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInputInternal)__policyProviderSpecificInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInputInternal)__policyProviderSpecificInput).InstanceType = value ?? null; }

        /// <summary>Backing field for <see cref="OnlineReplicationStartTime" /> property.</summary>
        private string _onlineReplicationStartTime;

        /// <summary>
        /// The scheduled start time for the initial replication. If this parameter is Null, the initial replication starts immediately.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OnlineReplicationStartTime { get => this._onlineReplicationStartTime; set => this._onlineReplicationStartTime = value; }

        /// <summary>Backing field for <see cref="RecoveryPointHistoryDuration" /> property.</summary>
        private int? _recoveryPointHistoryDuration;

        /// <summary>
        /// The duration (in hours) to which point the recovery history needs to be maintained.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? RecoveryPointHistoryDuration { get => this._recoveryPointHistoryDuration; set => this._recoveryPointHistoryDuration = value; }

        /// <summary>Backing field for <see cref="ReplicationInterval" /> property.</summary>
        private int? _replicationInterval;

        /// <summary>The replication interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ReplicationInterval { get => this._replicationInterval; set => this._replicationInterval = value; }

        /// <summary>Backing field for <see cref="StorageAccount" /> property.</summary>
        private string[] _storageAccount;

        /// <summary>
        /// The list of storage accounts to which the VMs in the primary cloud can replicate to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] StorageAccount { get => this._storageAccount; set => this._storageAccount = value; }

        /// <summary>Creates an new <see cref="HyperVReplicaAzurePolicyInput" /> instance.</summary>
        public HyperVReplicaAzurePolicyInput()
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
            await eventListener.AssertNotNull(nameof(__policyProviderSpecificInput), __policyProviderSpecificInput);
            await eventListener.AssertObjectIsValid(nameof(__policyProviderSpecificInput), __policyProviderSpecificInput);
        }
    }
    /// Hyper-V Replica Azure specific input for creating a protection profile.
    public partial interface IHyperVReplicaAzurePolicyInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInput
    {
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
        SerializedName = @"recoveryPointHistoryDuration",
        PossibleTypes = new [] { typeof(int) })]
        int? RecoveryPointHistoryDuration { get; set; }
        /// <summary>The replication interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The replication interval.",
        SerializedName = @"replicationInterval",
        PossibleTypes = new [] { typeof(int) })]
        int? ReplicationInterval { get; set; }
        /// <summary>
        /// The list of storage accounts to which the VMs in the primary cloud can replicate to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of storage accounts to which the VMs in the primary cloud can replicate to.",
        SerializedName = @"storageAccounts",
        PossibleTypes = new [] { typeof(string) })]
        string[] StorageAccount { get; set; }

    }
    /// Hyper-V Replica Azure specific input for creating a protection profile.
    internal partial interface IHyperVReplicaAzurePolicyInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInputInternal
    {
        /// <summary>
        /// The interval (in hours) at which Hyper-V Replica should create an application consistent snapshot within the VM.
        /// </summary>
        int? ApplicationConsistentSnapshotFrequencyInHour { get; set; }
        /// <summary>
        /// The scheduled start time for the initial replication. If this parameter is Null, the initial replication starts immediately.
        /// </summary>
        string OnlineReplicationStartTime { get; set; }
        /// <summary>
        /// The duration (in hours) to which point the recovery history needs to be maintained.
        /// </summary>
        int? RecoveryPointHistoryDuration { get; set; }
        /// <summary>The replication interval.</summary>
        int? ReplicationInterval { get; set; }
        /// <summary>
        /// The list of storage accounts to which the VMs in the primary cloud can replicate to.
        /// </summary>
        string[] StorageAccount { get; set; }

    }
}