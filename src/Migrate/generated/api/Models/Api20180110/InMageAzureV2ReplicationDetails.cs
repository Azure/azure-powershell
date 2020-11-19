namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>InMageAzureV2 provider specific settings</summary>
    public partial class InMageAzureV2ReplicationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ReplicationDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ReplicationDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings __replicationProviderSpecificSettings = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificSettings();

        /// <summary>Backing field for <see cref="AgentExpiryDate" /> property.</summary>
        private global::System.DateTime? _agentExpiryDate;

        /// <summary>Agent expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? AgentExpiryDate { get => this._agentExpiryDate; set => this._agentExpiryDate = value; }

        /// <summary>Backing field for <see cref="AgentVersion" /> property.</summary>
        private string _agentVersion;

        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AgentVersion { get => this._agentVersion; set => this._agentVersion = value; }

        /// <summary>Backing field for <see cref="AzureVMDiskDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails[] _azureVMDiskDetail;

        /// <summary>Azure VM Disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails[] AzureVMDiskDetail { get => this._azureVMDiskDetail; set => this._azureVMDiskDetail = value; }

        /// <summary>Backing field for <see cref="CompressedDataRateInMb" /> property.</summary>
        private double? _compressedDataRateInMb;

        /// <summary>The compressed data change rate in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public double? CompressedDataRateInMb { get => this._compressedDataRateInMb; set => this._compressedDataRateInMb = value; }

        /// <summary>Backing field for <see cref="Datastore" /> property.</summary>
        private string[] _datastore;

        /// <summary>
        /// The data stores of the on-premise machine. Value can be list of strings that contain data store names.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] Datastore { get => this._datastore; set => this._datastore = value; }

        /// <summary>Backing field for <see cref="DiscoveryType" /> property.</summary>
        private string _discoveryType;

        /// <summary>
        /// A value indicating the discovery type of the machine. Value can be vCenter or physical.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiscoveryType { get => this._discoveryType; set => this._discoveryType = value; }

        /// <summary>Backing field for <see cref="DiskResized" /> property.</summary>
        private string _diskResized;

        /// <summary>A value indicating whether any disk is resized for this VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskResized { get => this._diskResized; set => this._diskResized = value; }

        /// <summary>Backing field for <see cref="EnableRdpOnTargetOption" /> property.</summary>
        private string _enableRdpOnTargetOption;

        /// <summary>
        /// The selected option to enable RDP\SSH on target vm after failover. String value of {SrsDataContract.EnableRDPOnTargetOption}
        /// enum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EnableRdpOnTargetOption { get => this._enableRdpOnTargetOption; set => this._enableRdpOnTargetOption = value; }

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

        /// <summary>Backing field for <see cref="IsAgentUpdateRequired" /> property.</summary>
        private string _isAgentUpdateRequired;

        /// <summary>A value indicating whether installed agent needs to be updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IsAgentUpdateRequired { get => this._isAgentUpdateRequired; set => this._isAgentUpdateRequired = value; }

        /// <summary>Backing field for <see cref="IsRebootAfterUpdateRequired" /> property.</summary>
        private string _isRebootAfterUpdateRequired;

        /// <summary>A value indicating whether the source server requires a restart after update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IsRebootAfterUpdateRequired { get => this._isRebootAfterUpdateRequired; set => this._isRebootAfterUpdateRequired = value; }

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

        /// <summary>Backing field for <see cref="LicenseType" /> property.</summary>
        private string _licenseType;

        /// <summary>License Type of the VM to be used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string LicenseType { get => this._licenseType; set => this._licenseType = value; }

        /// <summary>Backing field for <see cref="MasterTargetId" /> property.</summary>
        private string _masterTargetId;

        /// <summary>The master target Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MasterTargetId { get => this._masterTargetId; set => this._masterTargetId = value; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)__replicationProviderSpecificSettings).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)__replicationProviderSpecificSettings).InstanceType = value; }

        /// <summary>Backing field for <see cref="MultiVMGroupId" /> property.</summary>
        private string _multiVMGroupId;

        /// <summary>The multi vm group Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MultiVMGroupId { get => this._multiVMGroupId; set => this._multiVMGroupId = value; }

        /// <summary>Backing field for <see cref="MultiVMGroupName" /> property.</summary>
        private string _multiVMGroupName;

        /// <summary>The multi vm group name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MultiVMGroupName { get => this._multiVMGroupName; set => this._multiVMGroupName = value; }

        /// <summary>Backing field for <see cref="MultiVMSyncStatus" /> property.</summary>
        private string _multiVMSyncStatus;

        /// <summary>A value indicating whether multi vm sync is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MultiVMSyncStatus { get => this._multiVMSyncStatus; set => this._multiVMSyncStatus = value; }

        /// <summary>Backing field for <see cref="OSDiskId" /> property.</summary>
        private string _oSDiskId;

        /// <summary>The id of the disk containing the OS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSDiskId { get => this._oSDiskId; set => this._oSDiskId = value; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private string _oSType;

        /// <summary>The type of the OS on the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSType { get => this._oSType; set => this._oSType = value; }

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
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetails[] _protectedDisk;

        /// <summary>The list of protected disks.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetails[] ProtectedDisk { get => this._protectedDisk; set => this._protectedDisk = value; }

        /// <summary>Backing field for <see cref="ProtectionStage" /> property.</summary>
        private string _protectionStage;

        /// <summary>The protection stage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProtectionStage { get => this._protectionStage; set => this._protectionStage = value; }

        /// <summary>Backing field for <see cref="RecoveryAvailabilitySetId" /> property.</summary>
        private string _recoveryAvailabilitySetId;

        /// <summary>The recovery availability set Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryAvailabilitySetId { get => this._recoveryAvailabilitySetId; set => this._recoveryAvailabilitySetId = value; }

        /// <summary>Backing field for <see cref="RecoveryAzureLogStorageAccountId" /> property.</summary>
        private string _recoveryAzureLogStorageAccountId;

        /// <summary>
        /// The ARM id of the log storage account used for replication. This will be set to null if no log storage account was provided
        /// during enable protection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryAzureLogStorageAccountId { get => this._recoveryAzureLogStorageAccountId; set => this._recoveryAzureLogStorageAccountId = value; }

        /// <summary>Backing field for <see cref="RecoveryAzureResourceGroupId" /> property.</summary>
        private string _recoveryAzureResourceGroupId;

        /// <summary>The target resource group Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryAzureResourceGroupId { get => this._recoveryAzureResourceGroupId; set => this._recoveryAzureResourceGroupId = value; }

        /// <summary>Backing field for <see cref="RecoveryAzureStorageAccount" /> property.</summary>
        private string _recoveryAzureStorageAccount;

        /// <summary>The recovery Azure storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryAzureStorageAccount { get => this._recoveryAzureStorageAccount; set => this._recoveryAzureStorageAccount = value; }

        /// <summary>Backing field for <see cref="RecoveryAzureVMName" /> property.</summary>
        private string _recoveryAzureVMName;

        /// <summary>Recovery Azure given name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryAzureVMName { get => this._recoveryAzureVMName; set => this._recoveryAzureVMName = value; }

        /// <summary>Backing field for <see cref="RecoveryAzureVMSize" /> property.</summary>
        private string _recoveryAzureVMSize;

        /// <summary>The Recovery Azure VM size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryAzureVMSize { get => this._recoveryAzureVMSize; set => this._recoveryAzureVMSize = value; }

        /// <summary>Backing field for <see cref="ReplicaId" /> property.</summary>
        private string _replicaId;

        /// <summary>The replica id of the protected item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ReplicaId { get => this._replicaId; set => this._replicaId = value; }

        /// <summary>Backing field for <see cref="ResyncProgressPercentage" /> property.</summary>
        private int? _resyncProgressPercentage;

        /// <summary>The resync progress percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ResyncProgressPercentage { get => this._resyncProgressPercentage; set => this._resyncProgressPercentage = value; }

        /// <summary>Backing field for <see cref="RpoInSecond" /> property.</summary>
        private long? _rpoInSecond;

        /// <summary>The RPO in seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? RpoInSecond { get => this._rpoInSecond; set => this._rpoInSecond = value; }

        /// <summary>Backing field for <see cref="SelectedRecoveryAzureNetworkId" /> property.</summary>
        private string _selectedRecoveryAzureNetworkId;

        /// <summary>The selected recovery azure network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SelectedRecoveryAzureNetworkId { get => this._selectedRecoveryAzureNetworkId; set => this._selectedRecoveryAzureNetworkId = value; }

        /// <summary>Backing field for <see cref="SelectedSourceNicId" /> property.</summary>
        private string _selectedSourceNicId;

        /// <summary>
        /// The selected source nic Id which will be used as the primary nic during failover.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SelectedSourceNicId { get => this._selectedSourceNicId; set => this._selectedSourceNicId = value; }

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

        /// <summary>Backing field for <see cref="TargetVMId" /> property.</summary>
        private string _targetVMId;

        /// <summary>
        /// The ARM Id of the target Azure VM. This value will be null until the VM is failed over. Only after failure it will be
        /// populated with the ARM Id of the Azure VM.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetVMId { get => this._targetVMId; set => this._targetVMId = value; }

        /// <summary>Backing field for <see cref="UncompressedDataRateInMb" /> property.</summary>
        private double? _uncompressedDataRateInMb;

        /// <summary>The uncompressed data change rate in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public double? UncompressedDataRateInMb { get => this._uncompressedDataRateInMb; set => this._uncompressedDataRateInMb = value; }

        /// <summary>Backing field for <see cref="UseManagedDisk" /> property.</summary>
        private string _useManagedDisk;

        /// <summary>A value indicating whether managed disks should be used during failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string UseManagedDisk { get => this._useManagedDisk; set => this._useManagedDisk = value; }

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
        /// The validation errors of the on-premise machine Value can be list of validation errors.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] ValidationError { get => this._validationError; set => this._validationError = value; }

        /// <summary>Backing field for <see cref="VhdName" /> property.</summary>
        private string _vhdName;

        /// <summary>The OS disk VHD name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VhdName { get => this._vhdName; set => this._vhdName = value; }

        /// <summary>Creates an new <see cref="InMageAzureV2ReplicationDetails" /> instance.</summary>
        public InMageAzureV2ReplicationDetails()
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
    /// InMageAzureV2 provider specific settings
    public partial interface IInMageAzureV2ReplicationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings
    {
        /// <summary>Agent expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Agent expiry date.",
        SerializedName = @"agentExpiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? AgentExpiryDate { get; set; }
        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The agent version.",
        SerializedName = @"agentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string AgentVersion { get; set; }
        /// <summary>Azure VM Disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Azure VM Disk details.",
        SerializedName = @"azureVMDiskDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails[] AzureVMDiskDetail { get; set; }
        /// <summary>The compressed data change rate in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The compressed data change rate in MB.",
        SerializedName = @"compressedDataRateInMB",
        PossibleTypes = new [] { typeof(double) })]
        double? CompressedDataRateInMb { get; set; }
        /// <summary>
        /// The data stores of the on-premise machine. Value can be list of strings that contain data store names.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The data stores of the on-premise machine. Value can be list of strings that contain data store names.",
        SerializedName = @"datastores",
        PossibleTypes = new [] { typeof(string) })]
        string[] Datastore { get; set; }
        /// <summary>
        /// A value indicating the discovery type of the machine. Value can be vCenter or physical.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating the discovery type of the machine. Value can be vCenter or physical.",
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
        /// <summary>
        /// The selected option to enable RDP\SSH on target vm after failover. String value of {SrsDataContract.EnableRDPOnTargetOption}
        /// enum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The selected option to enable RDP\SSH on target vm after failover. String value of {SrsDataContract.EnableRDPOnTargetOption} enum.",
        SerializedName = @"enableRdpOnTargetOption",
        PossibleTypes = new [] { typeof(string) })]
        string EnableRdpOnTargetOption { get; set; }
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
        /// <summary>A value indicating whether installed agent needs to be updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether installed agent needs to be updated.",
        SerializedName = @"isAgentUpdateRequired",
        PossibleTypes = new [] { typeof(string) })]
        string IsAgentUpdateRequired { get; set; }
        /// <summary>A value indicating whether the source server requires a restart after update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether the source server requires a restart after update.",
        SerializedName = @"isRebootAfterUpdateRequired",
        PossibleTypes = new [] { typeof(string) })]
        string IsRebootAfterUpdateRequired { get; set; }
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
        /// <summary>License Type of the VM to be used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"License Type of the VM to be used.",
        SerializedName = @"licenseType",
        PossibleTypes = new [] { typeof(string) })]
        string LicenseType { get; set; }
        /// <summary>The master target Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The master target Id.",
        SerializedName = @"masterTargetId",
        PossibleTypes = new [] { typeof(string) })]
        string MasterTargetId { get; set; }
        /// <summary>The multi vm group Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The multi vm group Id.",
        SerializedName = @"multiVmGroupId",
        PossibleTypes = new [] { typeof(string) })]
        string MultiVMGroupId { get; set; }
        /// <summary>The multi vm group name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The multi vm group name.",
        SerializedName = @"multiVmGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string MultiVMGroupName { get; set; }
        /// <summary>A value indicating whether multi vm sync is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether multi vm sync is enabled or disabled.",
        SerializedName = @"multiVmSyncStatus",
        PossibleTypes = new [] { typeof(string) })]
        string MultiVMSyncStatus { get; set; }
        /// <summary>The id of the disk containing the OS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The id of the disk containing the OS.",
        SerializedName = @"osDiskId",
        PossibleTypes = new [] { typeof(string) })]
        string OSDiskId { get; set; }
        /// <summary>The type of the OS on the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the OS on the VM.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSType { get; set; }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetails[] ProtectedDisk { get; set; }
        /// <summary>The protection stage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protection stage.",
        SerializedName = @"protectionStage",
        PossibleTypes = new [] { typeof(string) })]
        string ProtectionStage { get; set; }
        /// <summary>The recovery availability set Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery availability set Id.",
        SerializedName = @"recoveryAvailabilitySetId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryAvailabilitySetId { get; set; }
        /// <summary>
        /// The ARM id of the log storage account used for replication. This will be set to null if no log storage account was provided
        /// during enable protection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM id of the log storage account used for replication. This will be set to null if no log storage account was provided during enable protection.",
        SerializedName = @"recoveryAzureLogStorageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryAzureLogStorageAccountId { get; set; }
        /// <summary>The target resource group Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target resource group Id.",
        SerializedName = @"recoveryAzureResourceGroupId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryAzureResourceGroupId { get; set; }
        /// <summary>The recovery Azure storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery Azure storage account.",
        SerializedName = @"recoveryAzureStorageAccount",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryAzureStorageAccount { get; set; }
        /// <summary>Recovery Azure given name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Recovery Azure given name.",
        SerializedName = @"recoveryAzureVMName",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryAzureVMName { get; set; }
        /// <summary>The Recovery Azure VM size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Recovery Azure VM size.",
        SerializedName = @"recoveryAzureVMSize",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryAzureVMSize { get; set; }
        /// <summary>The replica id of the protected item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The replica id of the protected item.",
        SerializedName = @"replicaId",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicaId { get; set; }
        /// <summary>The resync progress percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resync progress percentage.",
        SerializedName = @"resyncProgressPercentage",
        PossibleTypes = new [] { typeof(int) })]
        int? ResyncProgressPercentage { get; set; }
        /// <summary>The RPO in seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The RPO in seconds.",
        SerializedName = @"rpoInSeconds",
        PossibleTypes = new [] { typeof(long) })]
        long? RpoInSecond { get; set; }
        /// <summary>The selected recovery azure network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The selected recovery azure network Id.",
        SerializedName = @"selectedRecoveryAzureNetworkId",
        PossibleTypes = new [] { typeof(string) })]
        string SelectedRecoveryAzureNetworkId { get; set; }
        /// <summary>
        /// The selected source nic Id which will be used as the primary nic during failover.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The selected source nic Id which will be used as the primary nic during failover.",
        SerializedName = @"selectedSourceNicId",
        PossibleTypes = new [] { typeof(string) })]
        string SelectedSourceNicId { get; set; }
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
        /// <summary>
        /// The ARM Id of the target Azure VM. This value will be null until the VM is failed over. Only after failure it will be
        /// populated with the ARM Id of the Azure VM.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM Id of the target Azure VM. This value will be null until the VM is failed over. Only after failure it will be populated with the ARM Id of the Azure VM.",
        SerializedName = @"targetVmId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetVMId { get; set; }
        /// <summary>The uncompressed data change rate in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The uncompressed data change rate in MB.",
        SerializedName = @"uncompressedDataRateInMB",
        PossibleTypes = new [] { typeof(double) })]
        double? UncompressedDataRateInMb { get; set; }
        /// <summary>A value indicating whether managed disks should be used during failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether managed disks should be used during failover.",
        SerializedName = @"useManagedDisks",
        PossibleTypes = new [] { typeof(string) })]
        string UseManagedDisk { get; set; }
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
        /// The validation errors of the on-premise machine Value can be list of validation errors.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The validation errors of the on-premise machine Value can be list of validation errors.",
        SerializedName = @"validationErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] ValidationError { get; set; }
        /// <summary>The OS disk VHD name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS disk VHD name.",
        SerializedName = @"vhdName",
        PossibleTypes = new [] { typeof(string) })]
        string VhdName { get; set; }

    }
    /// InMageAzureV2 provider specific settings
    internal partial interface IInMageAzureV2ReplicationDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal
    {
        /// <summary>Agent expiry date.</summary>
        global::System.DateTime? AgentExpiryDate { get; set; }
        /// <summary>The agent version.</summary>
        string AgentVersion { get; set; }
        /// <summary>Azure VM Disk details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails[] AzureVMDiskDetail { get; set; }
        /// <summary>The compressed data change rate in MB.</summary>
        double? CompressedDataRateInMb { get; set; }
        /// <summary>
        /// The data stores of the on-premise machine. Value can be list of strings that contain data store names.
        /// </summary>
        string[] Datastore { get; set; }
        /// <summary>
        /// A value indicating the discovery type of the machine. Value can be vCenter or physical.
        /// </summary>
        string DiscoveryType { get; set; }
        /// <summary>A value indicating whether any disk is resized for this VM.</summary>
        string DiskResized { get; set; }
        /// <summary>
        /// The selected option to enable RDP\SSH on target vm after failover. String value of {SrsDataContract.EnableRDPOnTargetOption}
        /// enum.
        /// </summary>
        string EnableRdpOnTargetOption { get; set; }
        /// <summary>The source IP address.</summary>
        string IPAddress { get; set; }
        /// <summary>The infrastructure VM Id.</summary>
        string InfrastructureVMId { get; set; }
        /// <summary>A value indicating whether installed agent needs to be updated.</summary>
        string IsAgentUpdateRequired { get; set; }
        /// <summary>A value indicating whether the source server requires a restart after update.</summary>
        string IsRebootAfterUpdateRequired { get; set; }
        /// <summary>The last heartbeat received from the source server.</summary>
        global::System.DateTime? LastHeartbeat { get; set; }
        /// <summary>The last RPO calculated time.</summary>
        global::System.DateTime? LastRpoCalculatedTime { get; set; }
        /// <summary>The last update time received from on-prem components.</summary>
        global::System.DateTime? LastUpdateReceivedTime { get; set; }
        /// <summary>License Type of the VM to be used.</summary>
        string LicenseType { get; set; }
        /// <summary>The master target Id.</summary>
        string MasterTargetId { get; set; }
        /// <summary>The multi vm group Id.</summary>
        string MultiVMGroupId { get; set; }
        /// <summary>The multi vm group name.</summary>
        string MultiVMGroupName { get; set; }
        /// <summary>A value indicating whether multi vm sync is enabled or disabled.</summary>
        string MultiVMSyncStatus { get; set; }
        /// <summary>The id of the disk containing the OS.</summary>
        string OSDiskId { get; set; }
        /// <summary>The type of the OS on the VM.</summary>
        string OSType { get; set; }
        /// <summary>The OS Version of the protected item.</summary>
        string OSVersion { get; set; }
        /// <summary>The process server Id.</summary>
        string ProcessServerId { get; set; }
        /// <summary>The list of protected disks.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetails[] ProtectedDisk { get; set; }
        /// <summary>The protection stage.</summary>
        string ProtectionStage { get; set; }
        /// <summary>The recovery availability set Id.</summary>
        string RecoveryAvailabilitySetId { get; set; }
        /// <summary>
        /// The ARM id of the log storage account used for replication. This will be set to null if no log storage account was provided
        /// during enable protection.
        /// </summary>
        string RecoveryAzureLogStorageAccountId { get; set; }
        /// <summary>The target resource group Id.</summary>
        string RecoveryAzureResourceGroupId { get; set; }
        /// <summary>The recovery Azure storage account.</summary>
        string RecoveryAzureStorageAccount { get; set; }
        /// <summary>Recovery Azure given name.</summary>
        string RecoveryAzureVMName { get; set; }
        /// <summary>The Recovery Azure VM size.</summary>
        string RecoveryAzureVMSize { get; set; }
        /// <summary>The replica id of the protected item.</summary>
        string ReplicaId { get; set; }
        /// <summary>The resync progress percentage.</summary>
        int? ResyncProgressPercentage { get; set; }
        /// <summary>The RPO in seconds.</summary>
        long? RpoInSecond { get; set; }
        /// <summary>The selected recovery azure network Id.</summary>
        string SelectedRecoveryAzureNetworkId { get; set; }
        /// <summary>
        /// The selected source nic Id which will be used as the primary nic during failover.
        /// </summary>
        string SelectedSourceNicId { get; set; }
        /// <summary>The CPU count of the VM on the primary side.</summary>
        int? SourceVMCpuCount { get; set; }
        /// <summary>The RAM size of the VM on the primary side.</summary>
        int? SourceVMRamSizeInMb { get; set; }
        /// <summary>
        /// The ARM Id of the target Azure VM. This value will be null until the VM is failed over. Only after failure it will be
        /// populated with the ARM Id of the Azure VM.
        /// </summary>
        string TargetVMId { get; set; }
        /// <summary>The uncompressed data change rate in MB.</summary>
        double? UncompressedDataRateInMb { get; set; }
        /// <summary>A value indicating whether managed disks should be used during failover.</summary>
        string UseManagedDisk { get; set; }
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
        /// The validation errors of the on-premise machine Value can be list of validation errors.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] ValidationError { get; set; }
        /// <summary>The OS disk VHD name.</summary>
        string VhdName { get; set; }

    }
}