namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>InMage provider specific settings</summary>
    public partial class InMageReplicationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReplicationDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReplicationDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings __replicationProviderSpecificSettings = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificSettings();

        /// <summary>Backing field for <see cref="ActiveSiteType" /> property.</summary>
        private string _activeSiteType;

        /// <summary>
        /// The active location of the VM. If the VM is being protected from Azure, this field will take values from { Azure, OnPrem
        /// }. If the VM is being protected between two data-centers, this field will be OnPrem always.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ActiveSiteType { get => this._activeSiteType; set => this._activeSiteType = value; }

        /// <summary>Backing field for <see cref="AgentDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetails _agentDetail;

        /// <summary>The agent details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetails AgentDetail { get => (this._agentDetail = this._agentDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageAgentDetails()); set => this._agentDetail = value; }

        /// <summary>Agent expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? AgentDetailAgentExpiryDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)AgentDetail).AgentExpiryDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)AgentDetail).AgentExpiryDate = value ?? default(global::System.DateTime); }

        /// <summary>A value indicating whether installed agent needs to be updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string AgentDetailAgentUpdateStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)AgentDetail).AgentUpdateStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)AgentDetail).AgentUpdateStatus = value ?? null; }

        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string AgentDetailAgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)AgentDetail).AgentVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)AgentDetail).AgentVersion = value ?? null; }

        /// <summary>A value indicating whether reboot is required after update is applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string AgentDetailPostUpdateRebootStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)AgentDetail).PostUpdateRebootStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)AgentDetail).PostUpdateRebootStatus = value ?? null; }

        /// <summary>Backing field for <see cref="AzureStorageAccountId" /> property.</summary>
        private string _azureStorageAccountId;

        /// <summary>
        /// A value indicating the underlying Azure storage account. If the VM is not running in Azure, this value shall be set to
        /// null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AzureStorageAccountId { get => this._azureStorageAccountId; set => this._azureStorageAccountId = value; }

        /// <summary>Backing field for <see cref="CompressedDataRateInMb" /> property.</summary>
        private double? _compressedDataRateInMb;

        /// <summary>The compressed data change rate in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public double? CompressedDataRateInMb { get => this._compressedDataRateInMb; set => this._compressedDataRateInMb = value; }

        /// <summary>Backing field for <see cref="ConsistencyPoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReplicationDetailsConsistencyPoints _consistencyPoint;

        /// <summary>The collection of Consistency points.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReplicationDetailsConsistencyPoints ConsistencyPoint { get => (this._consistencyPoint = this._consistencyPoint ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageReplicationDetailsConsistencyPoints()); set => this._consistencyPoint = value; }

        /// <summary>Backing field for <see cref="Datastore" /> property.</summary>
        private string[] _datastore;

        /// <summary>
        /// The data stores of the on-premise machine Value can be list of strings that contain data store names
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] Datastore { get => this._datastore; set => this._datastore = value; }

        /// <summary>Backing field for <see cref="DiscoveryType" /> property.</summary>
        private string _discoveryType;

        /// <summary>A value indicating the discovery type of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiscoveryType { get => this._discoveryType; set => this._discoveryType = value; }

        /// <summary>Backing field for <see cref="DiskResized" /> property.</summary>
        private string _diskResized;

        /// <summary>A value indicating whether any disk is resized for this VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskResized { get => this._diskResized; set => this._diskResized = value; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string _iPAddress;

        /// <summary>The source IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Backing field for <see cref="InfrastructureVMId" /> property.</summary>
        private string _infrastructureVMId;

        /// <summary>The infrastructure VM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InfrastructureVMId { get => this._infrastructureVMId; set => this._infrastructureVMId = value; }

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)__replicationProviderSpecificSettings).InstanceType; }

        /// <summary>Backing field for <see cref="LastHeartbeat" /> property.</summary>
        private global::System.DateTime? _lastHeartbeat;

        /// <summary>The last heartbeat received from the source server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastHeartbeat { get => this._lastHeartbeat; set => this._lastHeartbeat = value; }

        /// <summary>Backing field for <see cref="LastRpoCalculatedTime" /> property.</summary>
        private global::System.DateTime? _lastRpoCalculatedTime;

        /// <summary>The last RPO calculated time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastRpoCalculatedTime { get => this._lastRpoCalculatedTime; set => this._lastRpoCalculatedTime = value; }

        /// <summary>Backing field for <see cref="LastUpdateReceivedTime" /> property.</summary>
        private global::System.DateTime? _lastUpdateReceivedTime;

        /// <summary>The last update time received from on-prem components.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastUpdateReceivedTime { get => this._lastUpdateReceivedTime; set => this._lastUpdateReceivedTime = value; }

        /// <summary>Backing field for <see cref="MasterTargetId" /> property.</summary>
        private string _masterTargetId;

        /// <summary>The master target Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MasterTargetId { get => this._masterTargetId; set => this._masterTargetId = value; }

        /// <summary>Internal Acessors for AgentDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReplicationDetailsInternal.AgentDetail { get => (this._agentDetail = this._agentDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageAgentDetails()); set { {_agentDetail = value;} } }

        /// <summary>Internal Acessors for OSDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDiskDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReplicationDetailsInternal.OSDetail { get => (this._oSDetail = this._oSDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDiskDetails()); set { {_oSDetail = value;} } }

        /// <summary>Internal Acessors for ResyncDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReplicationDetailsInternal.ResyncDetail { get => (this._resyncDetail = this._resyncDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InitialReplicationDetails()); set { {_resyncDetail = value;} } }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)__replicationProviderSpecificSettings).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)__replicationProviderSpecificSettings).InstanceType = value; }

        /// <summary>Backing field for <see cref="MultiVMGroupId" /> property.</summary>
        private string _multiVMGroupId;

        /// <summary>The multi vm group Id, if any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MultiVMGroupId { get => this._multiVMGroupId; set => this._multiVMGroupId = value; }

        /// <summary>Backing field for <see cref="MultiVMGroupName" /> property.</summary>
        private string _multiVMGroupName;

        /// <summary>The multi vm group name, if any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MultiVMGroupName { get => this._multiVMGroupName; set => this._multiVMGroupName = value; }

        /// <summary>Backing field for <see cref="MultiVMSyncStatus" /> property.</summary>
        private string _multiVMSyncStatus;

        /// <summary>A value indicating whether the multi vm sync is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MultiVMSyncStatus { get => this._multiVMSyncStatus; set => this._multiVMSyncStatus = value; }

        /// <summary>Backing field for <see cref="OSDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDiskDetails _oSDetail;

        /// <summary>The OS details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDiskDetails OSDetail { get => (this._oSDetail = this._oSDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDiskDetails()); set => this._oSDetail = value; }

        /// <summary>The type of the OS on the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailOstype { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDiskDetailsInternal)OSDetail).OSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDiskDetailsInternal)OSDetail).OSType = value ?? null; }

        /// <summary>The id of the disk containing the OS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailOsvhdId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDiskDetailsInternal)OSDetail).OSVhdId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDiskDetailsInternal)OSDetail).OSVhdId = value ?? null; }

        /// <summary>The OS disk VHD name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailVhdName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDiskDetailsInternal)OSDetail).VhdName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDiskDetailsInternal)OSDetail).VhdName = value ?? null; }

        /// <summary>Backing field for <see cref="OSVersion" /> property.</summary>
        private string _oSVersion;

        /// <summary>The OS Version of the protected item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSVersion { get => this._oSVersion; set => this._oSVersion = value; }

        /// <summary>Backing field for <see cref="ProcessServerId" /> property.</summary>
        private string _processServerId;

        /// <summary>The process server Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProcessServerId { get => this._processServerId; set => this._processServerId = value; }

        /// <summary>Backing field for <see cref="ProtectedDisk" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageProtectedDiskDetails[] _protectedDisk;

        /// <summary>The list of protected disks.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageProtectedDiskDetails[] ProtectedDisk { get => this._protectedDisk; set => this._protectedDisk = value; }

        /// <summary>Backing field for <see cref="ProtectionStage" /> property.</summary>
        private string _protectionStage;

        /// <summary>The protection stage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProtectionStage { get => this._protectionStage; set => this._protectionStage = value; }

        /// <summary>Backing field for <see cref="RebootAfterUpdateStatus" /> property.</summary>
        private string _rebootAfterUpdateStatus;

        /// <summary>A value indicating whether the source server requires a restart after update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RebootAfterUpdateStatus { get => this._rebootAfterUpdateStatus; set => this._rebootAfterUpdateStatus = value; }

        /// <summary>Backing field for <see cref="ReplicaId" /> property.</summary>
        private string _replicaId;

        /// <summary>The replica id of the protected item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ReplicaId { get => this._replicaId; set => this._replicaId = value; }

        /// <summary>Backing field for <see cref="ResyncDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetails _resyncDetail;

        /// <summary>The resync details of the machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetails ResyncDetail { get => (this._resyncDetail = this._resyncDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InitialReplicationDetails()); set => this._resyncDetail = value; }

        /// <summary>The initial replication progress percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ResyncDetailInitialReplicationProgressPercentage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetailsInternal)ResyncDetail).InitialReplicationProgressPercentage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetailsInternal)ResyncDetail).InitialReplicationProgressPercentage = value ?? null; }

        /// <summary>Initial replication type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ResyncDetailInitialReplicationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetailsInternal)ResyncDetail).InitialReplicationType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetailsInternal)ResyncDetail).InitialReplicationType = value ?? null; }

        /// <summary>Backing field for <see cref="RetentionWindowEnd" /> property.</summary>
        private global::System.DateTime? _retentionWindowEnd;

        /// <summary>The retention window end time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? RetentionWindowEnd { get => this._retentionWindowEnd; set => this._retentionWindowEnd = value; }

        /// <summary>Backing field for <see cref="RetentionWindowStart" /> property.</summary>
        private global::System.DateTime? _retentionWindowStart;

        /// <summary>The retention window start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? RetentionWindowStart { get => this._retentionWindowStart; set => this._retentionWindowStart = value; }

        /// <summary>Backing field for <see cref="RpoInSecond" /> property.</summary>
        private long? _rpoInSecond;

        /// <summary>The RPO in seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? RpoInSecond { get => this._rpoInSecond; set => this._rpoInSecond = value; }

        /// <summary>Backing field for <see cref="SourceVMCpuCount" /> property.</summary>
        private int? _sourceVMCpuCount;

        /// <summary>The CPU count of the VM on the primary side.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? SourceVMCpuCount { get => this._sourceVMCpuCount; set => this._sourceVMCpuCount = value; }

        /// <summary>Backing field for <see cref="SourceVMRamSizeInMb" /> property.</summary>
        private int? _sourceVMRamSizeInMb;

        /// <summary>The RAM size of the VM on the primary side.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? SourceVMRamSizeInMb { get => this._sourceVMRamSizeInMb; set => this._sourceVMRamSizeInMb = value; }

        /// <summary>Backing field for <see cref="UncompressedDataRateInMb" /> property.</summary>
        private double? _uncompressedDataRateInMb;

        /// <summary>The uncompressed data change rate in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public double? UncompressedDataRateInMb { get => this._uncompressedDataRateInMb; set => this._uncompressedDataRateInMb = value; }

        /// <summary>Backing field for <see cref="VCenterInfrastructureId" /> property.</summary>
        private string _vCenterInfrastructureId;

        /// <summary>The vCenter infrastructure Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VCenterInfrastructureId { get => this._vCenterInfrastructureId; set => this._vCenterInfrastructureId = value; }

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

        /// <summary>Backing field for <see cref="ValidationError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] _validationError;

        /// <summary>
        /// The validation errors of the on-premise machine Value can be list of validation errors
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] ValidationError { get => this._validationError; set => this._validationError = value; }

        /// <summary>Creates an new <see cref="InMageReplicationDetails" /> instance.</summary>
        public InMageReplicationDetails()
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
    /// InMage provider specific settings
    public partial interface IInMageReplicationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings
    {
        /// <summary>
        /// The active location of the VM. If the VM is being protected from Azure, this field will take values from { Azure, OnPrem
        /// }. If the VM is being protected between two data-centers, this field will be OnPrem always.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The active location of the VM. If the VM is being protected from Azure, this field will take values from { Azure, OnPrem }. If the VM is being protected between two data-centers, this field will be OnPrem always.",
        SerializedName = @"activeSiteType",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveSiteType { get; set; }
        /// <summary>Agent expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Agent expiry date.",
        SerializedName = @"agentExpiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? AgentDetailAgentExpiryDate { get; set; }
        /// <summary>A value indicating whether installed agent needs to be updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether installed agent needs to be updated.",
        SerializedName = @"agentUpdateStatus",
        PossibleTypes = new [] { typeof(string) })]
        string AgentDetailAgentUpdateStatus { get; set; }
        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The agent version.",
        SerializedName = @"agentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string AgentDetailAgentVersion { get; set; }
        /// <summary>A value indicating whether reboot is required after update is applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether reboot is required after update is applied.",
        SerializedName = @"postUpdateRebootStatus",
        PossibleTypes = new [] { typeof(string) })]
        string AgentDetailPostUpdateRebootStatus { get; set; }
        /// <summary>
        /// A value indicating the underlying Azure storage account. If the VM is not running in Azure, this value shall be set to
        /// null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating the underlying Azure storage account. If the VM is not running in Azure, this value shall be set to null.",
        SerializedName = @"azureStorageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string AzureStorageAccountId { get; set; }
        /// <summary>The compressed data change rate in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The compressed data change rate in MB.",
        SerializedName = @"compressedDataRateInMB",
        PossibleTypes = new [] { typeof(double) })]
        double? CompressedDataRateInMb { get; set; }
        /// <summary>The collection of Consistency points.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The collection of Consistency points.",
        SerializedName = @"consistencyPoints",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReplicationDetailsConsistencyPoints) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReplicationDetailsConsistencyPoints ConsistencyPoint { get; set; }
        /// <summary>
        /// The data stores of the on-premise machine Value can be list of strings that contain data store names
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The data stores of the on-premise machine Value can be list of strings that contain data store names",
        SerializedName = @"datastores",
        PossibleTypes = new [] { typeof(string) })]
        string[] Datastore { get; set; }
        /// <summary>A value indicating the discovery type of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating the discovery type of the machine.",
        SerializedName = @"discoveryType",
        PossibleTypes = new [] { typeof(string) })]
        string DiscoveryType { get; set; }
        /// <summary>A value indicating whether any disk is resized for this VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether any disk is resized for this VM.",
        SerializedName = @"diskResized",
        PossibleTypes = new [] { typeof(string) })]
        string DiskResized { get; set; }
        /// <summary>The source IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source IP address.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>The infrastructure VM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The infrastructure VM Id.",
        SerializedName = @"infrastructureVmId",
        PossibleTypes = new [] { typeof(string) })]
        string InfrastructureVMId { get; set; }
        /// <summary>The last heartbeat received from the source server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The last heartbeat received from the source server.",
        SerializedName = @"lastHeartbeat",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastHeartbeat { get; set; }
        /// <summary>The last RPO calculated time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The last RPO calculated time.",
        SerializedName = @"lastRpoCalculatedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastRpoCalculatedTime { get; set; }
        /// <summary>The last update time received from on-prem components.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The last update time received from on-prem components.",
        SerializedName = @"lastUpdateReceivedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastUpdateReceivedTime { get; set; }
        /// <summary>The master target Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The master target Id.",
        SerializedName = @"masterTargetId",
        PossibleTypes = new [] { typeof(string) })]
        string MasterTargetId { get; set; }
        /// <summary>The multi vm group Id, if any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The multi vm group Id, if any.",
        SerializedName = @"multiVmGroupId",
        PossibleTypes = new [] { typeof(string) })]
        string MultiVMGroupId { get; set; }
        /// <summary>The multi vm group name, if any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The multi vm group name, if any.",
        SerializedName = @"multiVmGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string MultiVMGroupName { get; set; }
        /// <summary>A value indicating whether the multi vm sync is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether the multi vm sync is enabled or disabled.",
        SerializedName = @"multiVmSyncStatus",
        PossibleTypes = new [] { typeof(string) })]
        string MultiVMSyncStatus { get; set; }
        /// <summary>The type of the OS on the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the OS on the VM.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailOstype { get; set; }
        /// <summary>The id of the disk containing the OS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The id of the disk containing the OS.",
        SerializedName = @"osVhdId",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailOsvhdId { get; set; }
        /// <summary>The OS disk VHD name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS disk VHD name.",
        SerializedName = @"vhdName",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailVhdName { get; set; }
        /// <summary>The OS Version of the protected item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS Version of the protected item.",
        SerializedName = @"osVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSVersion { get; set; }
        /// <summary>The process server Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The process server Id.",
        SerializedName = @"processServerId",
        PossibleTypes = new [] { typeof(string) })]
        string ProcessServerId { get; set; }
        /// <summary>The list of protected disks.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of protected disks.",
        SerializedName = @"protectedDisks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageProtectedDiskDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageProtectedDiskDetails[] ProtectedDisk { get; set; }
        /// <summary>The protection stage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protection stage.",
        SerializedName = @"protectionStage",
        PossibleTypes = new [] { typeof(string) })]
        string ProtectionStage { get; set; }
        /// <summary>A value indicating whether the source server requires a restart after update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether the source server requires a restart after update.",
        SerializedName = @"rebootAfterUpdateStatus",
        PossibleTypes = new [] { typeof(string) })]
        string RebootAfterUpdateStatus { get; set; }
        /// <summary>The replica id of the protected item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The replica id of the protected item.",
        SerializedName = @"replicaId",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicaId { get; set; }
        /// <summary>The initial replication progress percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The initial replication progress percentage.",
        SerializedName = @"initialReplicationProgressPercentage",
        PossibleTypes = new [] { typeof(string) })]
        string ResyncDetailInitialReplicationProgressPercentage { get; set; }
        /// <summary>Initial replication type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Initial replication type.",
        SerializedName = @"initialReplicationType",
        PossibleTypes = new [] { typeof(string) })]
        string ResyncDetailInitialReplicationType { get; set; }
        /// <summary>The retention window end time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The retention window end time.",
        SerializedName = @"retentionWindowEnd",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RetentionWindowEnd { get; set; }
        /// <summary>The retention window start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The retention window start time.",
        SerializedName = @"retentionWindowStart",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RetentionWindowStart { get; set; }
        /// <summary>The RPO in seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The RPO in seconds.",
        SerializedName = @"rpoInSeconds",
        PossibleTypes = new [] { typeof(long) })]
        long? RpoInSecond { get; set; }
        /// <summary>The CPU count of the VM on the primary side.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CPU count of the VM on the primary side.",
        SerializedName = @"sourceVmCpuCount",
        PossibleTypes = new [] { typeof(int) })]
        int? SourceVMCpuCount { get; set; }
        /// <summary>The RAM size of the VM on the primary side.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The RAM size of the VM on the primary side.",
        SerializedName = @"sourceVmRamSizeInMB",
        PossibleTypes = new [] { typeof(int) })]
        int? SourceVMRamSizeInMb { get; set; }
        /// <summary>The uncompressed data change rate in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The uncompressed data change rate in MB.",
        SerializedName = @"uncompressedDataRateInMB",
        PossibleTypes = new [] { typeof(double) })]
        double? UncompressedDataRateInMb { get; set; }
        /// <summary>The vCenter infrastructure Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The vCenter infrastructure Id.",
        SerializedName = @"vCenterInfrastructureId",
        PossibleTypes = new [] { typeof(string) })]
        string VCenterInfrastructureId { get; set; }
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
        /// <summary>
        /// The validation errors of the on-premise machine Value can be list of validation errors
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The validation errors of the on-premise machine Value can be list of validation errors",
        SerializedName = @"validationErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] ValidationError { get; set; }

    }
    /// InMage provider specific settings
    internal partial interface IInMageReplicationDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal
    {
        /// <summary>
        /// The active location of the VM. If the VM is being protected from Azure, this field will take values from { Azure, OnPrem
        /// }. If the VM is being protected between two data-centers, this field will be OnPrem always.
        /// </summary>
        string ActiveSiteType { get; set; }
        /// <summary>The agent details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetails AgentDetail { get; set; }
        /// <summary>Agent expiry date.</summary>
        global::System.DateTime? AgentDetailAgentExpiryDate { get; set; }
        /// <summary>A value indicating whether installed agent needs to be updated.</summary>
        string AgentDetailAgentUpdateStatus { get; set; }
        /// <summary>The agent version.</summary>
        string AgentDetailAgentVersion { get; set; }
        /// <summary>A value indicating whether reboot is required after update is applied.</summary>
        string AgentDetailPostUpdateRebootStatus { get; set; }
        /// <summary>
        /// A value indicating the underlying Azure storage account. If the VM is not running in Azure, this value shall be set to
        /// null.
        /// </summary>
        string AzureStorageAccountId { get; set; }
        /// <summary>The compressed data change rate in MB.</summary>
        double? CompressedDataRateInMb { get; set; }
        /// <summary>The collection of Consistency points.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReplicationDetailsConsistencyPoints ConsistencyPoint { get; set; }
        /// <summary>
        /// The data stores of the on-premise machine Value can be list of strings that contain data store names
        /// </summary>
        string[] Datastore { get; set; }
        /// <summary>A value indicating the discovery type of the machine.</summary>
        string DiscoveryType { get; set; }
        /// <summary>A value indicating whether any disk is resized for this VM.</summary>
        string DiskResized { get; set; }
        /// <summary>The source IP address.</summary>
        string IPAddress { get; set; }
        /// <summary>The infrastructure VM Id.</summary>
        string InfrastructureVMId { get; set; }
        /// <summary>The last heartbeat received from the source server.</summary>
        global::System.DateTime? LastHeartbeat { get; set; }
        /// <summary>The last RPO calculated time.</summary>
        global::System.DateTime? LastRpoCalculatedTime { get; set; }
        /// <summary>The last update time received from on-prem components.</summary>
        global::System.DateTime? LastUpdateReceivedTime { get; set; }
        /// <summary>The master target Id.</summary>
        string MasterTargetId { get; set; }
        /// <summary>The multi vm group Id, if any.</summary>
        string MultiVMGroupId { get; set; }
        /// <summary>The multi vm group name, if any.</summary>
        string MultiVMGroupName { get; set; }
        /// <summary>A value indicating whether the multi vm sync is enabled or disabled.</summary>
        string MultiVMSyncStatus { get; set; }
        /// <summary>The OS details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDiskDetails OSDetail { get; set; }
        /// <summary>The type of the OS on the VM.</summary>
        string OSDetailOstype { get; set; }
        /// <summary>The id of the disk containing the OS.</summary>
        string OSDetailOsvhdId { get; set; }
        /// <summary>The OS disk VHD name.</summary>
        string OSDetailVhdName { get; set; }
        /// <summary>The OS Version of the protected item.</summary>
        string OSVersion { get; set; }
        /// <summary>The process server Id.</summary>
        string ProcessServerId { get; set; }
        /// <summary>The list of protected disks.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageProtectedDiskDetails[] ProtectedDisk { get; set; }
        /// <summary>The protection stage.</summary>
        string ProtectionStage { get; set; }
        /// <summary>A value indicating whether the source server requires a restart after update.</summary>
        string RebootAfterUpdateStatus { get; set; }
        /// <summary>The replica id of the protected item.</summary>
        string ReplicaId { get; set; }
        /// <summary>The resync details of the machine</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetails ResyncDetail { get; set; }
        /// <summary>The initial replication progress percentage.</summary>
        string ResyncDetailInitialReplicationProgressPercentage { get; set; }
        /// <summary>Initial replication type.</summary>
        string ResyncDetailInitialReplicationType { get; set; }
        /// <summary>The retention window end time.</summary>
        global::System.DateTime? RetentionWindowEnd { get; set; }
        /// <summary>The retention window start time.</summary>
        global::System.DateTime? RetentionWindowStart { get; set; }
        /// <summary>The RPO in seconds.</summary>
        long? RpoInSecond { get; set; }
        /// <summary>The CPU count of the VM on the primary side.</summary>
        int? SourceVMCpuCount { get; set; }
        /// <summary>The RAM size of the VM on the primary side.</summary>
        int? SourceVMRamSizeInMb { get; set; }
        /// <summary>The uncompressed data change rate in MB.</summary>
        double? UncompressedDataRateInMb { get; set; }
        /// <summary>The vCenter infrastructure Id.</summary>
        string VCenterInfrastructureId { get; set; }
        /// <summary>The virtual machine Id.</summary>
        string VMId { get; set; }
        /// <summary>The PE Network details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails[] VMNic { get; set; }
        /// <summary>The protection state for the vm.</summary>
        string VMProtectionState { get; set; }
        /// <summary>The protection state description for the vm.</summary>
        string VMProtectionStateDescription { get; set; }
        /// <summary>
        /// The validation errors of the on-premise machine Value can be list of validation errors
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] ValidationError { get; set; }

    }
}