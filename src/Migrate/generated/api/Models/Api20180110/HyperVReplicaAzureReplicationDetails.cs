namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Hyper V Replica Azure provider specific settings.</summary>
    public partial class HyperVReplicaAzureReplicationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings __replicationProviderSpecificSettings = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificSettings();

        /// <summary>Backing field for <see cref="AzureVMDiskDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails[] _azureVMDiskDetail;

        /// <summary>Azure VM Disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails[] AzureVMDiskDetail { get => this._azureVMDiskDetail; set => this._azureVMDiskDetail = value; }

        /// <summary>Backing field for <see cref="EnableRdpOnTargetOption" /> property.</summary>
        private string _enableRdpOnTargetOption;

        /// <summary>
        /// The selected option to enable RDP\SSH on target vm after failover. String value of {SrsDataContract.EnableRDPOnTargetOption}
        /// enum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EnableRdpOnTargetOption { get => this._enableRdpOnTargetOption; set => this._enableRdpOnTargetOption = value; }

        /// <summary>Backing field for <see cref="Encryption" /> property.</summary>
        private string _encryption;

        /// <summary>The encryption info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Encryption { get => this._encryption; set => this._encryption = value; }

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

        /// <summary>Backing field for <see cref="LastRpoCalculatedTime" /> property.</summary>
        private global::System.DateTime? _lastRpoCalculatedTime;

        /// <summary>The last RPO calculated time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastRpoCalculatedTime { get => this._lastRpoCalculatedTime; set => this._lastRpoCalculatedTime = value; }

        /// <summary>Backing field for <see cref="LicenseType" /> property.</summary>
        private string _licenseType;

        /// <summary>License Type of the VM to be used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string LicenseType { get => this._licenseType; set => this._licenseType = value; }

        /// <summary>Internal Acessors for InitialReplicationDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal.InitialReplicationDetail { get => (this._initialReplicationDetail = this._initialReplicationDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InitialReplicationDetails()); set { {_initialReplicationDetail = value;} } }

        /// <summary>Internal Acessors for OSDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal.OSDetail { get => (this._oSDetail = this._oSDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDetails()); set { {_oSDetail = value;} } }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)__replicationProviderSpecificSettings).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)__replicationProviderSpecificSettings).InstanceType = value; }

        /// <summary>Backing field for <see cref="OSDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails _oSDetail;

        /// <summary>The operating system info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails OSDetail { get => (this._oSDetail = this._oSDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDetails()); set => this._oSDetail = value; }

        /// <summary>The OSEdition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailOsedition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSEdition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSEdition = value ?? null; }

        /// <summary>The OS Major Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailOsmajorVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSMajorVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSMajorVersion = value ?? null; }

        /// <summary>The OS Minor Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailOsminorVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSMinorVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSMinorVersion = value ?? null; }

        /// <summary>VM Disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailOstype { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSType = value ?? null; }

        /// <summary>The OS Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailOsversion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSVersion = value ?? null; }

        /// <summary>Product type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailProductType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).ProductType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).ProductType = value ?? null; }

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

        /// <summary>Backing field for <see cref="RpoInSecond" /> property.</summary>
        private long? _rpoInSecond;

        /// <summary>Last RPO value.</summary>
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

        /// <summary>Backing field for <see cref="UseManagedDisk" /> property.</summary>
        private string _useManagedDisk;

        /// <summary>A value indicating whether managed disks should be used during failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string UseManagedDisk { get => this._useManagedDisk; set => this._useManagedDisk = value; }

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

        /// <summary>Creates an new <see cref="HyperVReplicaAzureReplicationDetails" /> instance.</summary>
        public HyperVReplicaAzureReplicationDetails()
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
    /// Hyper V Replica Azure provider specific settings.
    public partial interface IHyperVReplicaAzureReplicationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings
    {
        /// <summary>Azure VM Disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Azure VM Disk details.",
        SerializedName = @"azureVmDiskDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails[] AzureVMDiskDetail { get; set; }
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
        /// <summary>The encryption info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The encryption info.",
        SerializedName = @"encryption",
        PossibleTypes = new [] { typeof(string) })]
        string Encryption { get; set; }
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
        /// <summary>The last RPO calculated time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The last RPO calculated time.",
        SerializedName = @"lastRpoCalculatedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastRpoCalculatedTime { get; set; }
        /// <summary>License Type of the VM to be used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"License Type of the VM to be used.",
        SerializedName = @"licenseType",
        PossibleTypes = new [] { typeof(string) })]
        string LicenseType { get; set; }
        /// <summary>The OSEdition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OSEdition.",
        SerializedName = @"osEdition",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailOsedition { get; set; }
        /// <summary>The OS Major Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS Major Version.",
        SerializedName = @"oSMajorVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailOsmajorVersion { get; set; }
        /// <summary>The OS Minor Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS Minor Version.",
        SerializedName = @"oSMinorVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailOsminorVersion { get; set; }
        /// <summary>VM Disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VM Disk details.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailOstype { get; set; }
        /// <summary>The OS Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS Version.",
        SerializedName = @"oSVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailOsversion { get; set; }
        /// <summary>Product type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Product type.",
        SerializedName = @"productType",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailProductType { get; set; }
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
        SerializedName = @"recoveryAzureVmName",
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
        /// <summary>Last RPO value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Last RPO value.",
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
        /// <summary>A value indicating whether managed disks should be used during failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether managed disks should be used during failover.",
        SerializedName = @"useManagedDisks",
        PossibleTypes = new [] { typeof(string) })]
        string UseManagedDisk { get; set; }
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
    /// Hyper V Replica Azure provider specific settings.
    internal partial interface IHyperVReplicaAzureReplicationDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal
    {
        /// <summary>Azure VM Disk details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails[] AzureVMDiskDetail { get; set; }
        /// <summary>
        /// The selected option to enable RDP\SSH on target vm after failover. String value of {SrsDataContract.EnableRDPOnTargetOption}
        /// enum.
        /// </summary>
        string EnableRdpOnTargetOption { get; set; }
        /// <summary>The encryption info.</summary>
        string Encryption { get; set; }
        /// <summary>Initial replication details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetails InitialReplicationDetail { get; set; }
        /// <summary>The initial replication progress percentage.</summary>
        string InitialReplicationDetailInitialReplicationProgressPercentage { get; set; }
        /// <summary>Initial replication type.</summary>
        string InitialReplicationDetailInitialReplicationType { get; set; }
        /// <summary>The Last replication time.</summary>
        global::System.DateTime? LastReplicatedTime { get; set; }
        /// <summary>The last RPO calculated time.</summary>
        global::System.DateTime? LastRpoCalculatedTime { get; set; }
        /// <summary>License Type of the VM to be used.</summary>
        string LicenseType { get; set; }
        /// <summary>The operating system info.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails OSDetail { get; set; }
        /// <summary>The OSEdition.</summary>
        string OSDetailOsedition { get; set; }
        /// <summary>The OS Major Version.</summary>
        string OSDetailOsmajorVersion { get; set; }
        /// <summary>The OS Minor Version.</summary>
        string OSDetailOsminorVersion { get; set; }
        /// <summary>VM Disk details.</summary>
        string OSDetailOstype { get; set; }
        /// <summary>The OS Version.</summary>
        string OSDetailOsversion { get; set; }
        /// <summary>Product type.</summary>
        string OSDetailProductType { get; set; }
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
        /// <summary>Last RPO value.</summary>
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
        /// <summary>A value indicating whether managed disks should be used during failover.</summary>
        string UseManagedDisk { get; set; }
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