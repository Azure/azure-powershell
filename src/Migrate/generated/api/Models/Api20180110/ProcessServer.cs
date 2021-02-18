namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Details of the Process Server.</summary>
    public partial class ProcessServer :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal
    {

        /// <summary>Backing field for <see cref="AgentExpiryDate" /> property.</summary>
        private global::System.DateTime? _agentExpiryDate;

        /// <summary>Agent expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? AgentExpiryDate { get => this._agentExpiryDate; set => this._agentExpiryDate = value; }

        /// <summary>Backing field for <see cref="AgentVersion" /> property.</summary>
        private string _agentVersion;

        /// <summary>The version of the scout component on the server.</summary>
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

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>The Process Server's friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="HealthError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] _healthError;

        /// <summary>Health errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get => this._healthError; set => this._healthError = value; }

        /// <summary>Backing field for <see cref="HostId" /> property.</summary>
        private string _hostId;

        /// <summary>The agent generated Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string HostId { get => this._hostId; set => this._hostId = value; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string _iPAddress;

        /// <summary>The IP address of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The Process Server Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="LastHeartbeat" /> property.</summary>
        private global::System.DateTime? _lastHeartbeat;

        /// <summary>The last heartbeat received from the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastHeartbeat { get => this._lastHeartbeat; set => this._lastHeartbeat = value; }

        /// <summary>Backing field for <see cref="MachineCount" /> property.</summary>
        private string _machineCount;

        /// <summary>The servers configured with this PS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MachineCount { get => this._machineCount; set => this._machineCount = value; }

        /// <summary>Backing field for <see cref="MemoryUsageStatus" /> property.</summary>
        private string _memoryUsageStatus;

        /// <summary>The memory usage status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MemoryUsageStatus { get => this._memoryUsageStatus; set => this._memoryUsageStatus = value; }

        /// <summary>Internal Acessors for AgentVersionDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal.AgentVersionDetail { get => (this._agentVersionDetail = this._agentVersionDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetails()); set { {_agentVersionDetail = value;} } }

        /// <summary>Backing field for <see cref="MobilityServiceUpdate" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMobilityServiceUpdate[] _mobilityServiceUpdate;

        /// <summary>The list of the mobility service updates available on the Process Server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMobilityServiceUpdate[] MobilityServiceUpdate { get => this._mobilityServiceUpdate; set => this._mobilityServiceUpdate = value; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private string _oSType;

        /// <summary>The OS type of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Backing field for <see cref="OSVersion" /> property.</summary>
        private string _oSVersion;

        /// <summary>
        /// OS Version of the process server. Note: This will get populated if user has CS version greater than 9.12.0.0.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSVersion { get => this._oSVersion; set => this._oSVersion = value; }

        /// <summary>Backing field for <see cref="PsServiceStatus" /> property.</summary>
        private string _psServiceStatus;

        /// <summary>The PS service status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PsServiceStatus { get => this._psServiceStatus; set => this._psServiceStatus = value; }

        /// <summary>Backing field for <see cref="ReplicationPairCount" /> property.</summary>
        private string _replicationPairCount;

        /// <summary>The number of replication pairs configured in this PS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ReplicationPairCount { get => this._replicationPairCount; set => this._replicationPairCount = value; }

        /// <summary>Backing field for <see cref="SpaceUsageStatus" /> property.</summary>
        private string _spaceUsageStatus;

        /// <summary>The space usage status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SpaceUsageStatus { get => this._spaceUsageStatus; set => this._spaceUsageStatus = value; }

        /// <summary>Backing field for <see cref="SslCertExpiryDate" /> property.</summary>
        private global::System.DateTime? _sslCertExpiryDate;

        /// <summary>The PS SSL cert expiry date.</summary>
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

        /// <summary>Creates an new <see cref="ProcessServer" /> instance.</summary>
        public ProcessServer()
        {

        }
    }
    /// Details of the Process Server.
    public partial interface IProcessServer :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Agent expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Agent expiry date.",
        SerializedName = @"agentExpiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? AgentExpiryDate { get; set; }
        /// <summary>The version of the scout component on the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version of the scout component on the server.",
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
        /// <summary>The Process Server's friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Process Server's friendly name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>Health errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Health errors.",
        SerializedName = @"healthErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get; set; }
        /// <summary>The agent generated Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The agent generated Id.",
        SerializedName = @"hostId",
        PossibleTypes = new [] { typeof(string) })]
        string HostId { get; set; }
        /// <summary>The IP address of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP address of the server.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>The Process Server Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Process Server Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>The last heartbeat received from the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The last heartbeat received from the server.",
        SerializedName = @"lastHeartbeat",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastHeartbeat { get; set; }
        /// <summary>The servers configured with this PS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The servers configured with this PS.",
        SerializedName = @"machineCount",
        PossibleTypes = new [] { typeof(string) })]
        string MachineCount { get; set; }
        /// <summary>The memory usage status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The memory usage status.",
        SerializedName = @"memoryUsageStatus",
        PossibleTypes = new [] { typeof(string) })]
        string MemoryUsageStatus { get; set; }
        /// <summary>The list of the mobility service updates available on the Process Server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of the mobility service updates available on the Process Server.",
        SerializedName = @"mobilityServiceUpdates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMobilityServiceUpdate) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMobilityServiceUpdate[] MobilityServiceUpdate { get; set; }
        /// <summary>The OS type of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS type of the server.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSType { get; set; }
        /// <summary>
        /// OS Version of the process server. Note: This will get populated if user has CS version greater than 9.12.0.0.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"OS Version of the process server. Note: This will get populated if user has CS version greater than 9.12.0.0.",
        SerializedName = @"osVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSVersion { get; set; }
        /// <summary>The PS service status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The PS service status.",
        SerializedName = @"psServiceStatus",
        PossibleTypes = new [] { typeof(string) })]
        string PsServiceStatus { get; set; }
        /// <summary>The number of replication pairs configured in this PS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of replication pairs configured in this PS.",
        SerializedName = @"replicationPairCount",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicationPairCount { get; set; }
        /// <summary>The space usage status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The space usage status.",
        SerializedName = @"spaceUsageStatus",
        PossibleTypes = new [] { typeof(string) })]
        string SpaceUsageStatus { get; set; }
        /// <summary>The PS SSL cert expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The PS SSL cert expiry date.",
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

    }
    /// Details of the Process Server.
    internal partial interface IProcessServerInternal

    {
        /// <summary>Agent expiry date.</summary>
        global::System.DateTime? AgentExpiryDate { get; set; }
        /// <summary>The version of the scout component on the server.</summary>
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
        /// <summary>The Process Server's friendly name.</summary>
        string FriendlyName { get; set; }
        /// <summary>Health errors.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get; set; }
        /// <summary>The agent generated Id.</summary>
        string HostId { get; set; }
        /// <summary>The IP address of the server.</summary>
        string IPAddress { get; set; }
        /// <summary>The Process Server Id.</summary>
        string Id { get; set; }
        /// <summary>The last heartbeat received from the server.</summary>
        global::System.DateTime? LastHeartbeat { get; set; }
        /// <summary>The servers configured with this PS.</summary>
        string MachineCount { get; set; }
        /// <summary>The memory usage status.</summary>
        string MemoryUsageStatus { get; set; }
        /// <summary>The list of the mobility service updates available on the Process Server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMobilityServiceUpdate[] MobilityServiceUpdate { get; set; }
        /// <summary>The OS type of the server.</summary>
        string OSType { get; set; }
        /// <summary>
        /// OS Version of the process server. Note: This will get populated if user has CS version greater than 9.12.0.0.
        /// </summary>
        string OSVersion { get; set; }
        /// <summary>The PS service status.</summary>
        string PsServiceStatus { get; set; }
        /// <summary>The number of replication pairs configured in this PS.</summary>
        string ReplicationPairCount { get; set; }
        /// <summary>The space usage status.</summary>
        string SpaceUsageStatus { get; set; }
        /// <summary>The PS SSL cert expiry date.</summary>
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

    }
}