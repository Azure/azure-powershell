namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Hyper-V Replica specific policy Input.</summary>
    public partial class HyperVReplicaPolicyInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaPolicyInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaPolicyInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInput __policyProviderSpecificInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.PolicyProviderSpecificInput();

        /// <summary>Backing field for <see cref="AllowedAuthenticationType" /> property.</summary>
        private int? _allowedAuthenticationType;

        /// <summary>A value indicating the authentication type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? AllowedAuthenticationType { get => this._allowedAuthenticationType; set => this._allowedAuthenticationType = value; }

        /// <summary>
        /// Backing field for <see cref="ApplicationConsistentSnapshotFrequencyInHour" /> property.
        /// </summary>
        private int? _applicationConsistentSnapshotFrequencyInHour;

        /// <summary>A value indicating the application consistent frequency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ApplicationConsistentSnapshotFrequencyInHour { get => this._applicationConsistentSnapshotFrequencyInHour; set => this._applicationConsistentSnapshotFrequencyInHour = value; }

        /// <summary>Backing field for <see cref="Compression" /> property.</summary>
        private string _compression;

        /// <summary>A value indicating whether compression has to be enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Compression { get => this._compression; set => this._compression = value; }

        /// <summary>Backing field for <see cref="InitialReplicationMethod" /> property.</summary>
        private string _initialReplicationMethod;

        /// <summary>A value indicating whether IR is online.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InitialReplicationMethod { get => this._initialReplicationMethod; set => this._initialReplicationMethod = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInputInternal)__policyProviderSpecificInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInputInternal)__policyProviderSpecificInput).InstanceType = value ?? null; }

        /// <summary>Backing field for <see cref="OfflineReplicationExportPath" /> property.</summary>
        private string _offlineReplicationExportPath;

        /// <summary>A value indicating the offline IR export path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OfflineReplicationExportPath { get => this._offlineReplicationExportPath; set => this._offlineReplicationExportPath = value; }

        /// <summary>Backing field for <see cref="OfflineReplicationImportPath" /> property.</summary>
        private string _offlineReplicationImportPath;

        /// <summary>A value indicating the offline IR import path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OfflineReplicationImportPath { get => this._offlineReplicationImportPath; set => this._offlineReplicationImportPath = value; }

        /// <summary>Backing field for <see cref="OnlineReplicationStartTime" /> property.</summary>
        private string _onlineReplicationStartTime;

        /// <summary>A value indicating the online IR start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OnlineReplicationStartTime { get => this._onlineReplicationStartTime; set => this._onlineReplicationStartTime = value; }

        /// <summary>Backing field for <see cref="RecoveryPoint" /> property.</summary>
        private int? _recoveryPoint;

        /// <summary>A value indicating the number of recovery points.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? RecoveryPoint { get => this._recoveryPoint; set => this._recoveryPoint = value; }

        /// <summary>Backing field for <see cref="ReplicaDeletion" /> property.</summary>
        private string _replicaDeletion;

        /// <summary>A value indicating whether the VM has to be auto deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ReplicaDeletion { get => this._replicaDeletion; set => this._replicaDeletion = value; }

        /// <summary>Backing field for <see cref="ReplicationPort" /> property.</summary>
        private int? _replicationPort;

        /// <summary>A value indicating the recovery HTTPS port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ReplicationPort { get => this._replicationPort; set => this._replicationPort = value; }

        /// <summary>Creates an new <see cref="HyperVReplicaPolicyInput" /> instance.</summary>
        public HyperVReplicaPolicyInput()
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
    /// Hyper-V Replica specific policy Input.
    public partial interface IHyperVReplicaPolicyInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInput
    {
        /// <summary>A value indicating the authentication type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating the authentication type.",
        SerializedName = @"allowedAuthenticationType",
        PossibleTypes = new [] { typeof(int) })]
        int? AllowedAuthenticationType { get; set; }
        /// <summary>A value indicating the application consistent frequency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating the application consistent frequency.",
        SerializedName = @"applicationConsistentSnapshotFrequencyInHours",
        PossibleTypes = new [] { typeof(int) })]
        int? ApplicationConsistentSnapshotFrequencyInHour { get; set; }
        /// <summary>A value indicating whether compression has to be enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether compression has to be enabled.",
        SerializedName = @"compression",
        PossibleTypes = new [] { typeof(string) })]
        string Compression { get; set; }
        /// <summary>A value indicating whether IR is online.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether IR is online.",
        SerializedName = @"initialReplicationMethod",
        PossibleTypes = new [] { typeof(string) })]
        string InitialReplicationMethod { get; set; }
        /// <summary>A value indicating the offline IR export path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating the offline IR export path.",
        SerializedName = @"offlineReplicationExportPath",
        PossibleTypes = new [] { typeof(string) })]
        string OfflineReplicationExportPath { get; set; }
        /// <summary>A value indicating the offline IR import path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating the offline IR import path.",
        SerializedName = @"offlineReplicationImportPath",
        PossibleTypes = new [] { typeof(string) })]
        string OfflineReplicationImportPath { get; set; }
        /// <summary>A value indicating the online IR start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating the online IR start time.",
        SerializedName = @"onlineReplicationStartTime",
        PossibleTypes = new [] { typeof(string) })]
        string OnlineReplicationStartTime { get; set; }
        /// <summary>A value indicating the number of recovery points.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating the number of recovery points.",
        SerializedName = @"recoveryPoints",
        PossibleTypes = new [] { typeof(int) })]
        int? RecoveryPoint { get; set; }
        /// <summary>A value indicating whether the VM has to be auto deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether the VM has to be auto deleted.",
        SerializedName = @"replicaDeletion",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicaDeletion { get; set; }
        /// <summary>A value indicating the recovery HTTPS port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating the recovery HTTPS port.",
        SerializedName = @"replicationPort",
        PossibleTypes = new [] { typeof(int) })]
        int? ReplicationPort { get; set; }

    }
    /// Hyper-V Replica specific policy Input.
    internal partial interface IHyperVReplicaPolicyInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInputInternal
    {
        /// <summary>A value indicating the authentication type.</summary>
        int? AllowedAuthenticationType { get; set; }
        /// <summary>A value indicating the application consistent frequency.</summary>
        int? ApplicationConsistentSnapshotFrequencyInHour { get; set; }
        /// <summary>A value indicating whether compression has to be enabled.</summary>
        string Compression { get; set; }
        /// <summary>A value indicating whether IR is online.</summary>
        string InitialReplicationMethod { get; set; }
        /// <summary>A value indicating the offline IR export path.</summary>
        string OfflineReplicationExportPath { get; set; }
        /// <summary>A value indicating the offline IR import path.</summary>
        string OfflineReplicationImportPath { get; set; }
        /// <summary>A value indicating the online IR start time.</summary>
        string OnlineReplicationStartTime { get; set; }
        /// <summary>A value indicating the number of recovery points.</summary>
        int? RecoveryPoint { get; set; }
        /// <summary>A value indicating whether the VM has to be auto deleted.</summary>
        string ReplicaDeletion { get; set; }
        /// <summary>A value indicating the recovery HTTPS port.</summary>
        int? ReplicationPort { get; set; }

    }
}