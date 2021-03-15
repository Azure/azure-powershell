namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>HyperV replica 2012 replication details.</summary>
    public partial class HyperVReplicaReplicationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaReplicationDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaReplicationDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings __replicationProviderSpecificSettings = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificSettings();

        /// <summary>Backing field for <see cref="InitialReplicationDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetails _initialReplicationDetail;

        /// <summary>Initial replication details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetails InitialReplicationDetail { get => (this._initialReplicationDetail = this._initialReplicationDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InitialReplicationDetails()); set => this._initialReplicationDetail = value; }

        /// <summary>The initial replication progress percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string InitialReplicationDetailInitialReplicationProgressPercentage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetailsInternal)InitialReplicationDetail).InitialReplicationProgressPercentage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetailsInternal)InitialReplicationDetail).InitialReplicationProgressPercentage = value ?? null; }

        /// <summary>Initial replication type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string InitialReplicationDetailInitialReplicationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetailsInternal)InitialReplicationDetail).InitialReplicationType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetailsInternal)InitialReplicationDetail).InitialReplicationType = value ?? null; }

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)__replicationProviderSpecificSettings).InstanceType; }

        /// <summary>Backing field for <see cref="LastReplicatedTime" /> property.</summary>
        private global::System.DateTime? _lastReplicatedTime;

        /// <summary>The Last replication time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastReplicatedTime { get => this._lastReplicatedTime; set => this._lastReplicatedTime = value; }

        /// <summary>Internal Acessors for InitialReplicationDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaReplicationDetailsInternal.InitialReplicationDetail { get => (this._initialReplicationDetail = this._initialReplicationDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InitialReplicationDetails()); set { {_initialReplicationDetail = value;} } }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)__replicationProviderSpecificSettings).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)__replicationProviderSpecificSettings).InstanceType = value; }

        /// <summary>Backing field for <see cref="VMDiskDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails[] _vMDiskDetail;

        /// <summary>VM disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails[] VMDiskDetail { get => this._vMDiskDetail; set => this._vMDiskDetail = value; }

        /// <summary>Backing field for <see cref="VMId" /> property.</summary>
        private string _vMId;

        /// <summary>The virtual machine Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VMId { get => this._vMId; set => this._vMId = value; }

        /// <summary>Backing field for <see cref="VMNic" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails[] _vMNic;

        /// <summary>The PE Network details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails[] VMNic { get => this._vMNic; set => this._vMNic = value; }

        /// <summary>Backing field for <see cref="VMProtectionState" /> property.</summary>
        private string _vMProtectionState;

        /// <summary>The protection state for the vm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VMProtectionState { get => this._vMProtectionState; set => this._vMProtectionState = value; }

        /// <summary>Backing field for <see cref="VMProtectionStateDescription" /> property.</summary>
        private string _vMProtectionStateDescription;

        /// <summary>The protection state description for the vm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VMProtectionStateDescription { get => this._vMProtectionStateDescription; set => this._vMProtectionStateDescription = value; }

        /// <summary>Creates an new <see cref="HyperVReplicaReplicationDetails" /> instance.</summary>
        public HyperVReplicaReplicationDetails()
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
            await eventListener.AssertNotNull(nameof(__replicationProviderSpecificSettings), __replicationProviderSpecificSettings);
            await eventListener.AssertObjectIsValid(nameof(__replicationProviderSpecificSettings), __replicationProviderSpecificSettings);
        }
    }
    /// HyperV replica 2012 replication details.
    public partial interface IHyperVReplicaReplicationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings
    {
        /// <summary>The initial replication progress percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The initial replication progress percentage.",
        SerializedName = @"initialReplicationProgressPercentage",
        PossibleTypes = new [] { typeof(string) })]
        string InitialReplicationDetailInitialReplicationProgressPercentage { get; set; }
        /// <summary>Initial replication type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Initial replication type.",
        SerializedName = @"initialReplicationType",
        PossibleTypes = new [] { typeof(string) })]
        string InitialReplicationDetailInitialReplicationType { get; set; }
        /// <summary>The Last replication time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Last replication time.",
        SerializedName = @"lastReplicatedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastReplicatedTime { get; set; }
        /// <summary>VM disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VM disk details.",
        SerializedName = @"vMDiskDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails[] VMDiskDetail { get; set; }
        /// <summary>The virtual machine Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The virtual machine Id.",
        SerializedName = @"vmId",
        PossibleTypes = new [] { typeof(string) })]
        string VMId { get; set; }
        /// <summary>The PE Network details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The PE Network details.",
        SerializedName = @"vmNics",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails[] VMNic { get; set; }
        /// <summary>The protection state for the vm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protection state for the vm.",
        SerializedName = @"vmProtectionState",
        PossibleTypes = new [] { typeof(string) })]
        string VMProtectionState { get; set; }
        /// <summary>The protection state description for the vm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protection state description for the vm.",
        SerializedName = @"vmProtectionStateDescription",
        PossibleTypes = new [] { typeof(string) })]
        string VMProtectionStateDescription { get; set; }

    }
    /// HyperV replica 2012 replication details.
    internal partial interface IHyperVReplicaReplicationDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal
    {
        /// <summary>Initial replication details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetails InitialReplicationDetail { get; set; }
        /// <summary>The initial replication progress percentage.</summary>
        string InitialReplicationDetailInitialReplicationProgressPercentage { get; set; }
        /// <summary>Initial replication type.</summary>
        string InitialReplicationDetailInitialReplicationType { get; set; }
        /// <summary>The Last replication time.</summary>
        global::System.DateTime? LastReplicatedTime { get; set; }
        /// <summary>VM disk details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails[] VMDiskDetail { get; set; }
        /// <summary>The virtual machine Id.</summary>
        string VMId { get; set; }
        /// <summary>The PE Network details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails[] VMNic { get; set; }
        /// <summary>The protection state for the vm.</summary>
        string VMProtectionState { get; set; }
        /// <summary>The protection state description for the vm.</summary>
        string VMProtectionStateDescription { get; set; }

    }
}