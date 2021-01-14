namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Store the fabric details specific to the VMware fabric.</summary>
    public partial class VMwareDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails __fabricSpecificDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificDetails();

        /// <summary>Backing field for <see cref="AgentCount" /> property.</summary>
        private string _agentCount;

        /// <summary>The number of source and target servers configured to talk to this CS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AgentCount { get => this._agentCount; set => this._agentCount = value; }

        /// <summary>Backing field for <see cref="AgentExpiryDate" /> property.</summary>
        private global::System.DateTime? _agentExpiryDate;

        /// <summary>Agent expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? AgentExpiryDate { get => this._agentExpiryDate; set => this._agentExpiryDate = value; }

        /// <summary>Backing field for <see cref="AgentVersion" /> property.</summary>
        private string _agentVersion;

        /// <summary>The agent Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AgentVersion { get => this._agentVersion; set => this._agentVersion = value; }

        /// <summary>Backing field for <see cref="AgentVersionDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails _agentVersionDetail;

        /// <summary>The agent version details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails AgentVersionDetail { get => (this._agentVersionDetail = this._agentVersionDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetails()); set => this._agentVersionDetail = value; }

        /// <summary>Version expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? AgentVersionDetailExpiryDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetailsInternal)AgentVersionDetail).ExpiryDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetailsInternal)AgentVersionDetail).ExpiryDate = value ?? default(global::System.DateTime); }

        /// <summary>A value indicating whether security update required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus? AgentVersionDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetailsInternal)AgentVersionDetail).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetailsInternal)AgentVersionDetail).Status = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus)""); }

        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string AgentVersionDetailVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetailsInternal)AgentVersionDetail).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetailsInternal)AgentVersionDetail).Version = value ?? null; }

        /// <summary>Backing field for <see cref="AvailableMemoryInByte" /> property.</summary>
        private long? _availableMemoryInByte;

        /// <summary>The available memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? AvailableMemoryInByte { get => this._availableMemoryInByte; set => this._availableMemoryInByte = value; }

        /// <summary>Backing field for <see cref="AvailableSpaceInByte" /> property.</summary>
        private long? _availableSpaceInByte;

        /// <summary>The available space.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? AvailableSpaceInByte { get => this._availableSpaceInByte; set => this._availableSpaceInByte = value; }

        /// <summary>Backing field for <see cref="CpuLoad" /> property.</summary>
        private string _cpuLoad;

        /// <summary>The percentage of the CPU load.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CpuLoad { get => this._cpuLoad; set => this._cpuLoad = value; }

        /// <summary>Backing field for <see cref="CpuLoadStatus" /> property.</summary>
        private string _cpuLoadStatus;

        /// <summary>The CPU load status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CpuLoadStatus { get => this._cpuLoadStatus; set => this._cpuLoadStatus = value; }

        /// <summary>Backing field for <see cref="CsServiceStatus" /> property.</summary>
        private string _csServiceStatus;

        /// <summary>The CS service status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CsServiceStatus { get => this._csServiceStatus; set => this._csServiceStatus = value; }

        /// <summary>Backing field for <see cref="DatabaseServerLoad" /> property.</summary>
        private string _databaseServerLoad;

        /// <summary>The database server load.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DatabaseServerLoad { get => this._databaseServerLoad; set => this._databaseServerLoad = value; }

        /// <summary>Backing field for <see cref="DatabaseServerLoadStatus" /> property.</summary>
        private string _databaseServerLoadStatus;

        /// <summary>The database server load status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DatabaseServerLoadStatus { get => this._databaseServerLoadStatus; set => this._databaseServerLoadStatus = value; }

        /// <summary>Backing field for <see cref="HostName" /> property.</summary>
        private string _hostName;

        /// <summary>The host name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string HostName { get => this._hostName; set => this._hostName = value; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string _iPAddress;

        /// <summary>The IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)__fabricSpecificDetails).InstanceType; }

        /// <summary>Backing field for <see cref="LastHeartbeat" /> property.</summary>
        private global::System.DateTime? _lastHeartbeat;

        /// <summary>The last heartbeat received from CS server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastHeartbeat { get => this._lastHeartbeat; set => this._lastHeartbeat = value; }

        /// <summary>Backing field for <see cref="MasterTargetServer" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer[] _masterTargetServer;

        /// <summary>The list of Master Target servers associated with the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer[] MasterTargetServer { get => this._masterTargetServer; set => this._masterTargetServer = value; }

        /// <summary>Backing field for <see cref="MemoryUsageStatus" /> property.</summary>
        private string _memoryUsageStatus;

        /// <summary>The memory usage status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MemoryUsageStatus { get => this._memoryUsageStatus; set => this._memoryUsageStatus = value; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)__fabricSpecificDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)__fabricSpecificDetails).InstanceType = value; }

        /// <summary>Internal Acessors for AgentVersionDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal.AgentVersionDetail { get => (this._agentVersionDetail = this._agentVersionDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetails()); set { {_agentVersionDetail = value;} } }

        /// <summary>Backing field for <see cref="ProcessServer" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer[] _processServer;

        /// <summary>The list of Process Servers associated with the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer[] ProcessServer { get => this._processServer; set => this._processServer = value; }

        /// <summary>Backing field for <see cref="ProcessServerCount" /> property.</summary>
        private string _processServerCount;

        /// <summary>The number of process servers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProcessServerCount { get => this._processServerCount; set => this._processServerCount = value; }

        /// <summary>Backing field for <see cref="ProtectedServer" /> property.</summary>
        private string _protectedServer;

        /// <summary>The number of protected servers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProtectedServer { get => this._protectedServer; set => this._protectedServer = value; }

        /// <summary>Backing field for <see cref="PsTemplateVersion" /> property.</summary>
        private string _psTemplateVersion;

        /// <summary>PS template version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PsTemplateVersion { get => this._psTemplateVersion; set => this._psTemplateVersion = value; }

        /// <summary>Backing field for <see cref="ReplicationPairCount" /> property.</summary>
        private string _replicationPairCount;

        /// <summary>The number of replication pairs configured in this CS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ReplicationPairCount { get => this._replicationPairCount; set => this._replicationPairCount = value; }

        /// <summary>Backing field for <see cref="RunAsAccount" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRunAsAccount[] _runAsAccount;

        /// <summary>The list of run as accounts created on the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRunAsAccount[] RunAsAccount { get => this._runAsAccount; set => this._runAsAccount = value; }

        /// <summary>Backing field for <see cref="SpaceUsageStatus" /> property.</summary>
        private string _spaceUsageStatus;

        /// <summary>The space usage status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SpaceUsageStatus { get => this._spaceUsageStatus; set => this._spaceUsageStatus = value; }

        /// <summary>Backing field for <see cref="SslCertExpiryDate" /> property.</summary>
        private global::System.DateTime? _sslCertExpiryDate;

        /// <summary>CS SSL cert expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? SslCertExpiryDate { get => this._sslCertExpiryDate; set => this._sslCertExpiryDate = value; }

        /// <summary>Backing field for <see cref="SslCertExpiryRemainingDay" /> property.</summary>
        private int? _sslCertExpiryRemainingDay;

        /// <summary>CS SSL cert expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? SslCertExpiryRemainingDay { get => this._sslCertExpiryRemainingDay; set => this._sslCertExpiryRemainingDay = value; }

        /// <summary>Backing field for <see cref="SystemLoad" /> property.</summary>
        private string _systemLoad;

        /// <summary>The percentage of the system load.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SystemLoad { get => this._systemLoad; set => this._systemLoad = value; }

        /// <summary>Backing field for <see cref="SystemLoadStatus" /> property.</summary>
        private string _systemLoadStatus;

        /// <summary>The system load status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SystemLoadStatus { get => this._systemLoadStatus; set => this._systemLoadStatus = value; }

        /// <summary>Backing field for <see cref="TotalMemoryInByte" /> property.</summary>
        private long? _totalMemoryInByte;

        /// <summary>The total memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? TotalMemoryInByte { get => this._totalMemoryInByte; set => this._totalMemoryInByte = value; }

        /// <summary>Backing field for <see cref="TotalSpaceInByte" /> property.</summary>
        private long? _totalSpaceInByte;

        /// <summary>The total space.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? TotalSpaceInByte { get => this._totalSpaceInByte; set => this._totalSpaceInByte = value; }

        /// <summary>Backing field for <see cref="VersionStatus" /> property.</summary>
        private string _versionStatus;

        /// <summary>Version status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VersionStatus { get => this._versionStatus; set => this._versionStatus = value; }

        /// <summary>Backing field for <see cref="WebLoad" /> property.</summary>
        private string _webLoad;

        /// <summary>The web load.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string WebLoad { get => this._webLoad; set => this._webLoad = value; }

        /// <summary>Backing field for <see cref="WebLoadStatus" /> property.</summary>
        private string _webLoadStatus;

        /// <summary>The web load status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string WebLoadStatus { get => this._webLoadStatus; set => this._webLoadStatus = value; }

        /// <summary>Creates an new <see cref="VMwareDetails" /> instance.</summary>
        public VMwareDetails()
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
            await eventListener.AssertNotNull(nameof(__fabricSpecificDetails), __fabricSpecificDetails);
            await eventListener.AssertObjectIsValid(nameof(__fabricSpecificDetails), __fabricSpecificDetails);
        }
    }
    /// Store the fabric details specific to the VMware fabric.
    public partial interface IVMwareDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails
    {
        /// <summary>The number of source and target servers configured to talk to this CS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of source and target servers configured to talk to this CS.",
        SerializedName = @"agentCount",
        PossibleTypes = new [] { typeof(string) })]
        string AgentCount { get; set; }
        /// <summary>Agent expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Agent expiry date.",
        SerializedName = @"agentExpiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? AgentExpiryDate { get; set; }
        /// <summary>The agent Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The agent Version.",
        SerializedName = @"agentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string AgentVersion { get; set; }
        /// <summary>Version expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version expiry date.",
        SerializedName = @"expiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? AgentVersionDetailExpiryDate { get; set; }
        /// <summary>A value indicating whether security update required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether security update required.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus? AgentVersionDetailStatus { get; set; }
        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The agent version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string AgentVersionDetailVersion { get; set; }
        /// <summary>The available memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The available memory.",
        SerializedName = @"availableMemoryInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? AvailableMemoryInByte { get; set; }
        /// <summary>The available space.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The available space.",
        SerializedName = @"availableSpaceInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? AvailableSpaceInByte { get; set; }
        /// <summary>The percentage of the CPU load.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The percentage of the CPU load.",
        SerializedName = @"cpuLoad",
        PossibleTypes = new [] { typeof(string) })]
        string CpuLoad { get; set; }
        /// <summary>The CPU load status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CPU load status.",
        SerializedName = @"cpuLoadStatus",
        PossibleTypes = new [] { typeof(string) })]
        string CpuLoadStatus { get; set; }
        /// <summary>The CS service status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CS service status.",
        SerializedName = @"csServiceStatus",
        PossibleTypes = new [] { typeof(string) })]
        string CsServiceStatus { get; set; }
        /// <summary>The database server load.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The database server load.",
        SerializedName = @"databaseServerLoad",
        PossibleTypes = new [] { typeof(string) })]
        string DatabaseServerLoad { get; set; }
        /// <summary>The database server load status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The database server load status.",
        SerializedName = @"databaseServerLoadStatus",
        PossibleTypes = new [] { typeof(string) })]
        string DatabaseServerLoadStatus { get; set; }
        /// <summary>The host name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The host name.",
        SerializedName = @"hostName",
        PossibleTypes = new [] { typeof(string) })]
        string HostName { get; set; }
        /// <summary>The IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP address.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>The last heartbeat received from CS server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The last heartbeat received from CS server.",
        SerializedName = @"lastHeartbeat",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastHeartbeat { get; set; }
        /// <summary>The list of Master Target servers associated with the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of Master Target servers associated with the fabric.",
        SerializedName = @"masterTargetServers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer[] MasterTargetServer { get; set; }
        /// <summary>The memory usage status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The memory usage status.",
        SerializedName = @"memoryUsageStatus",
        PossibleTypes = new [] { typeof(string) })]
        string MemoryUsageStatus { get; set; }
        /// <summary>The list of Process Servers associated with the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of Process Servers associated with the fabric.",
        SerializedName = @"processServers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer[] ProcessServer { get; set; }
        /// <summary>The number of process servers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of process servers.",
        SerializedName = @"processServerCount",
        PossibleTypes = new [] { typeof(string) })]
        string ProcessServerCount { get; set; }
        /// <summary>The number of protected servers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of protected servers.",
        SerializedName = @"protectedServers",
        PossibleTypes = new [] { typeof(string) })]
        string ProtectedServer { get; set; }
        /// <summary>PS template version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"PS template version.",
        SerializedName = @"psTemplateVersion",
        PossibleTypes = new [] { typeof(string) })]
        string PsTemplateVersion { get; set; }
        /// <summary>The number of replication pairs configured in this CS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of replication pairs configured in this CS.",
        SerializedName = @"replicationPairCount",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicationPairCount { get; set; }
        /// <summary>The list of run as accounts created on the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of run as accounts created on the server.",
        SerializedName = @"runAsAccounts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRunAsAccount) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRunAsAccount[] RunAsAccount { get; set; }
        /// <summary>The space usage status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The space usage status.",
        SerializedName = @"spaceUsageStatus",
        PossibleTypes = new [] { typeof(string) })]
        string SpaceUsageStatus { get; set; }
        /// <summary>CS SSL cert expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"CS SSL cert expiry date.",
        SerializedName = @"sslCertExpiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SslCertExpiryDate { get; set; }
        /// <summary>CS SSL cert expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"CS SSL cert expiry date.",
        SerializedName = @"sslCertExpiryRemainingDays",
        PossibleTypes = new [] { typeof(int) })]
        int? SslCertExpiryRemainingDay { get; set; }
        /// <summary>The percentage of the system load.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The percentage of the system load.",
        SerializedName = @"systemLoad",
        PossibleTypes = new [] { typeof(string) })]
        string SystemLoad { get; set; }
        /// <summary>The system load status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The system load status.",
        SerializedName = @"systemLoadStatus",
        PossibleTypes = new [] { typeof(string) })]
        string SystemLoadStatus { get; set; }
        /// <summary>The total memory.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The total memory.",
        SerializedName = @"totalMemoryInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? TotalMemoryInByte { get; set; }
        /// <summary>The total space.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The total space.",
        SerializedName = @"totalSpaceInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? TotalSpaceInByte { get; set; }
        /// <summary>Version status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version status",
        SerializedName = @"versionStatus",
        PossibleTypes = new [] { typeof(string) })]
        string VersionStatus { get; set; }
        /// <summary>The web load.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The web load.",
        SerializedName = @"webLoad",
        PossibleTypes = new [] { typeof(string) })]
        string WebLoad { get; set; }
        /// <summary>The web load status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The web load status.",
        SerializedName = @"webLoadStatus",
        PossibleTypes = new [] { typeof(string) })]
        string WebLoadStatus { get; set; }

    }
    /// Store the fabric details specific to the VMware fabric.
    internal partial interface IVMwareDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal
    {
        /// <summary>The number of source and target servers configured to talk to this CS.</summary>
        string AgentCount { get; set; }
        /// <summary>Agent expiry date.</summary>
        global::System.DateTime? AgentExpiryDate { get; set; }
        /// <summary>The agent Version.</summary>
        string AgentVersion { get; set; }
        /// <summary>The agent version details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails AgentVersionDetail { get; set; }
        /// <summary>Version expiry date.</summary>
        global::System.DateTime? AgentVersionDetailExpiryDate { get; set; }
        /// <summary>A value indicating whether security update required.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus? AgentVersionDetailStatus { get; set; }
        /// <summary>The agent version.</summary>
        string AgentVersionDetailVersion { get; set; }
        /// <summary>The available memory.</summary>
        long? AvailableMemoryInByte { get; set; }
        /// <summary>The available space.</summary>
        long? AvailableSpaceInByte { get; set; }
        /// <summary>The percentage of the CPU load.</summary>
        string CpuLoad { get; set; }
        /// <summary>The CPU load status.</summary>
        string CpuLoadStatus { get; set; }
        /// <summary>The CS service status.</summary>
        string CsServiceStatus { get; set; }
        /// <summary>The database server load.</summary>
        string DatabaseServerLoad { get; set; }
        /// <summary>The database server load status.</summary>
        string DatabaseServerLoadStatus { get; set; }
        /// <summary>The host name.</summary>
        string HostName { get; set; }
        /// <summary>The IP address.</summary>
        string IPAddress { get; set; }
        /// <summary>The last heartbeat received from CS server.</summary>
        global::System.DateTime? LastHeartbeat { get; set; }
        /// <summary>The list of Master Target servers associated with the fabric.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer[] MasterTargetServer { get; set; }
        /// <summary>The memory usage status.</summary>
        string MemoryUsageStatus { get; set; }
        /// <summary>The list of Process Servers associated with the fabric.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer[] ProcessServer { get; set; }
        /// <summary>The number of process servers.</summary>
        string ProcessServerCount { get; set; }
        /// <summary>The number of protected servers.</summary>
        string ProtectedServer { get; set; }
        /// <summary>PS template version.</summary>
        string PsTemplateVersion { get; set; }
        /// <summary>The number of replication pairs configured in this CS.</summary>
        string ReplicationPairCount { get; set; }
        /// <summary>The list of run as accounts created on the server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRunAsAccount[] RunAsAccount { get; set; }
        /// <summary>The space usage status.</summary>
        string SpaceUsageStatus { get; set; }
        /// <summary>CS SSL cert expiry date.</summary>
        global::System.DateTime? SslCertExpiryDate { get; set; }
        /// <summary>CS SSL cert expiry date.</summary>
        int? SslCertExpiryRemainingDay { get; set; }
        /// <summary>The percentage of the system load.</summary>
        string SystemLoad { get; set; }
        /// <summary>The system load status.</summary>
        string SystemLoadStatus { get; set; }
        /// <summary>The total memory.</summary>
        long? TotalMemoryInByte { get; set; }
        /// <summary>The total space.</summary>
        long? TotalSpaceInByte { get; set; }
        /// <summary>Version status</summary>
        string VersionStatus { get; set; }
        /// <summary>The web load.</summary>
        string WebLoad { get; set; }
        /// <summary>The web load status.</summary>
        string WebLoadStatus { get; set; }

    }
}