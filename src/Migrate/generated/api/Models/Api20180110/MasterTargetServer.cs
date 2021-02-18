namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Details of a Master Target Server.</summary>
    public partial class MasterTargetServer :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal
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

        /// <summary>Agent version details.</summary>
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

        /// <summary>Backing field for <see cref="DataStore" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDataStore[] _dataStore;

        /// <summary>The list of data stores in the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDataStore[] DataStore { get => this._dataStore; set => this._dataStore = value; }

        /// <summary>Backing field for <see cref="DiskCount" /> property.</summary>
        private int? _diskCount;

        /// <summary>Disk count of the master target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? DiskCount { get => this._diskCount; set => this._diskCount = value; }

        /// <summary>Backing field for <see cref="HealthError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] _healthError;

        /// <summary>Health errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get => this._healthError; set => this._healthError = value; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string _iPAddress;

        /// <summary>The IP address of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The server Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="LastHeartbeat" /> property.</summary>
        private global::System.DateTime? _lastHeartbeat;

        /// <summary>The last heartbeat received from the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastHeartbeat { get => this._lastHeartbeat; set => this._lastHeartbeat = value; }

        /// <summary>Version expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? MarAgentVersionDetailExpiryDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetailsInternal)MarsAgentVersionDetail).ExpiryDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetailsInternal)MarsAgentVersionDetail).ExpiryDate = value ?? default(global::System.DateTime); }

        /// <summary>A value indicating whether security update required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus? MarAgentVersionDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetailsInternal)MarsAgentVersionDetail).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetailsInternal)MarsAgentVersionDetail).Status = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus)""); }

        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string MarAgentVersionDetailVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetailsInternal)MarsAgentVersionDetail).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetailsInternal)MarsAgentVersionDetail).Version = value ?? null; }

        /// <summary>Backing field for <see cref="MarsAgentExpiryDate" /> property.</summary>
        private global::System.DateTime? _marsAgentExpiryDate;

        /// <summary>MARS agent expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? MarsAgentExpiryDate { get => this._marsAgentExpiryDate; set => this._marsAgentExpiryDate = value; }

        /// <summary>Backing field for <see cref="MarsAgentVersion" /> property.</summary>
        private string _marsAgentVersion;

        /// <summary>MARS agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MarsAgentVersion { get => this._marsAgentVersion; set => this._marsAgentVersion = value; }

        /// <summary>Backing field for <see cref="MarsAgentVersionDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails _marsAgentVersionDetail;

        /// <summary>Mars agent version details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails MarsAgentVersionDetail { get => (this._marsAgentVersionDetail = this._marsAgentVersionDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetails()); set => this._marsAgentVersionDetail = value; }

        /// <summary>Internal Acessors for AgentVersionDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal.AgentVersionDetail { get => (this._agentVersionDetail = this._agentVersionDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetails()); set { {_agentVersionDetail = value;} } }

        /// <summary>Internal Acessors for MarsAgentVersionDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal.MarsAgentVersionDetail { get => (this._marsAgentVersionDetail = this._marsAgentVersionDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetails()); set { {_marsAgentVersionDetail = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The server name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private string _oSType;

        /// <summary>The OS type of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Backing field for <see cref="OSVersion" /> property.</summary>
        private string _oSVersion;

        /// <summary>OS Version of the master target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSVersion { get => this._oSVersion; set => this._oSVersion = value; }

        /// <summary>Backing field for <see cref="RetentionVolume" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRetentionVolume[] _retentionVolume;

        /// <summary>The retention volumes of Master target Server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRetentionVolume[] RetentionVolume { get => this._retentionVolume; set => this._retentionVolume = value; }

        /// <summary>Backing field for <see cref="ValidationError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] _validationError;

        /// <summary>Validation errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] ValidationError { get => this._validationError; set => this._validationError = value; }

        /// <summary>Backing field for <see cref="VersionStatus" /> property.</summary>
        private string _versionStatus;

        /// <summary>Version status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VersionStatus { get => this._versionStatus; set => this._versionStatus = value; }

        /// <summary>Creates an new <see cref="MasterTargetServer" /> instance.</summary>
        public MasterTargetServer()
        {

        }
    }
    /// Details of a Master Target Server.
    public partial interface IMasterTargetServer :
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
        /// <summary>The list of data stores in the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of data stores in the fabric.",
        SerializedName = @"dataStores",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDataStore) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDataStore[] DataStore { get; set; }
        /// <summary>Disk count of the master target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Disk count of the master target.",
        SerializedName = @"diskCount",
        PossibleTypes = new [] { typeof(int) })]
        int? DiskCount { get; set; }
        /// <summary>Health errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Health errors.",
        SerializedName = @"healthErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get; set; }
        /// <summary>The IP address of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP address of the server.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>The server Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The server Id.",
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
        /// <summary>Version expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version expiry date.",
        SerializedName = @"expiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? MarAgentVersionDetailExpiryDate { get; set; }
        /// <summary>A value indicating whether security update required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether security update required.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus? MarAgentVersionDetailStatus { get; set; }
        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The agent version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string MarAgentVersionDetailVersion { get; set; }
        /// <summary>MARS agent expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"MARS agent expiry date.",
        SerializedName = @"marsAgentExpiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? MarsAgentExpiryDate { get; set; }
        /// <summary>MARS agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"MARS agent version.",
        SerializedName = @"marsAgentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string MarsAgentVersion { get; set; }
        /// <summary>The server name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The server name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The OS type of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS type of the server.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSType { get; set; }
        /// <summary>OS Version of the master target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"OS Version of the master target.",
        SerializedName = @"osVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSVersion { get; set; }
        /// <summary>The retention volumes of Master target Server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The retention volumes of Master target Server.",
        SerializedName = @"retentionVolumes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRetentionVolume) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRetentionVolume[] RetentionVolume { get; set; }
        /// <summary>Validation errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Validation errors.",
        SerializedName = @"validationErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] ValidationError { get; set; }
        /// <summary>Version status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version status",
        SerializedName = @"versionStatus",
        PossibleTypes = new [] { typeof(string) })]
        string VersionStatus { get; set; }

    }
    /// Details of a Master Target Server.
    internal partial interface IMasterTargetServerInternal

    {
        /// <summary>Agent expiry date.</summary>
        global::System.DateTime? AgentExpiryDate { get; set; }
        /// <summary>The version of the scout component on the server.</summary>
        string AgentVersion { get; set; }
        /// <summary>Agent version details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails AgentVersionDetail { get; set; }
        /// <summary>Version expiry date.</summary>
        global::System.DateTime? AgentVersionDetailExpiryDate { get; set; }
        /// <summary>A value indicating whether security update required.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus? AgentVersionDetailStatus { get; set; }
        /// <summary>The agent version.</summary>
        string AgentVersionDetailVersion { get; set; }
        /// <summary>The list of data stores in the fabric.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDataStore[] DataStore { get; set; }
        /// <summary>Disk count of the master target.</summary>
        int? DiskCount { get; set; }
        /// <summary>Health errors.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get; set; }
        /// <summary>The IP address of the server.</summary>
        string IPAddress { get; set; }
        /// <summary>The server Id.</summary>
        string Id { get; set; }
        /// <summary>The last heartbeat received from the server.</summary>
        global::System.DateTime? LastHeartbeat { get; set; }
        /// <summary>Version expiry date.</summary>
        global::System.DateTime? MarAgentVersionDetailExpiryDate { get; set; }
        /// <summary>A value indicating whether security update required.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus? MarAgentVersionDetailStatus { get; set; }
        /// <summary>The agent version.</summary>
        string MarAgentVersionDetailVersion { get; set; }
        /// <summary>MARS agent expiry date.</summary>
        global::System.DateTime? MarsAgentExpiryDate { get; set; }
        /// <summary>MARS agent version.</summary>
        string MarsAgentVersion { get; set; }
        /// <summary>Mars agent version details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails MarsAgentVersionDetail { get; set; }
        /// <summary>The server name.</summary>
        string Name { get; set; }
        /// <summary>The OS type of the server.</summary>
        string OSType { get; set; }
        /// <summary>OS Version of the master target.</summary>
        string OSVersion { get; set; }
        /// <summary>The retention volumes of Master target Server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRetentionVolume[] RetentionVolume { get; set; }
        /// <summary>Validation errors.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] ValidationError { get; set; }
        /// <summary>Version status</summary>
        string VersionStatus { get; set; }

    }
}