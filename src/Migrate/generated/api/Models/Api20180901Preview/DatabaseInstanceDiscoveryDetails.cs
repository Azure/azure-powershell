namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Discovery properties that can be shared by various publishers.</summary>
    public partial class DatabaseInstanceDiscoveryDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceDiscoveryDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceDiscoveryDetailsInternal
    {

        /// <summary>Backing field for <see cref="EnqueueTime" /> property.</summary>
        private string _enqueueTime;

        /// <summary>Gets or sets the time the message was enqueued.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EnqueueTime { get => this._enqueueTime; set => this._enqueueTime = value; }

        /// <summary>Backing field for <see cref="ExtendedInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceDiscoveryDetailsExtendedInfo _extendedInfo;

        /// <summary>Gets or sets the extended properties of the database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceDiscoveryDetailsExtendedInfo ExtendedInfo { get => (this._extendedInfo = this._extendedInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.DatabaseInstanceDiscoveryDetailsExtendedInfo()); set => this._extendedInfo = value; }

        /// <summary>Backing field for <see cref="HostName" /> property.</summary>
        private string _hostName;

        /// <summary>Gets or sets the host name of the database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string HostName { get => this._hostName; set => this._hostName = value; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string _iPAddress;

        /// <summary>
        /// Gets or sets the IP addresses of the database server. IP addresses could be IP V4 or IP V6.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Backing field for <see cref="InstanceId" /> property.</summary>
        private string _instanceId;

        /// <summary>Gets or sets the database instance Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceId { get => this._instanceId; set => this._instanceId = value; }

        /// <summary>Backing field for <see cref="InstanceName" /> property.</summary>
        private string _instanceName;

        /// <summary>Gets or sets the database instance name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceName { get => this._instanceName; set => this._instanceName = value; }

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>Gets or sets the database instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; set => this._instanceType = value; }

        /// <summary>Backing field for <see cref="InstanceVersion" /> property.</summary>
        private string _instanceVersion;

        /// <summary>Gets or sets the database instance version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceVersion { get => this._instanceVersion; set => this._instanceVersion = value; }

        /// <summary>Backing field for <see cref="LastUpdatedTime" /> property.</summary>
        private global::System.DateTime? _lastUpdatedTime;

        /// <summary>
        /// Gets or sets the time of the last modification of the database instance details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastUpdatedTime { get => this._lastUpdatedTime; set => this._lastUpdatedTime = value; }

        /// <summary>Backing field for <see cref="PortNumber" /> property.</summary>
        private int? _portNumber;

        /// <summary>Gets or sets the port number of the database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? PortNumber { get => this._portNumber; set => this._portNumber = value; }

        /// <summary>Backing field for <see cref="SolutionName" /> property.</summary>
        private string _solutionName;

        /// <summary>Gets or sets the name of the solution that sent the data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SolutionName { get => this._solutionName; set => this._solutionName = value; }

        /// <summary>Creates an new <see cref="DatabaseInstanceDiscoveryDetails" /> instance.</summary>
        public DatabaseInstanceDiscoveryDetails()
        {

        }
    }
    /// Discovery properties that can be shared by various publishers.
    public partial interface IDatabaseInstanceDiscoveryDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the time the message was enqueued.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the time the message was enqueued.",
        SerializedName = @"enqueueTime",
        PossibleTypes = new [] { typeof(string) })]
        string EnqueueTime { get; set; }
        /// <summary>Gets or sets the extended properties of the database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the extended properties of the database server.",
        SerializedName = @"extendedInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceDiscoveryDetailsExtendedInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceDiscoveryDetailsExtendedInfo ExtendedInfo { get; set; }
        /// <summary>Gets or sets the host name of the database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the host name of the database server.",
        SerializedName = @"hostName",
        PossibleTypes = new [] { typeof(string) })]
        string HostName { get; set; }
        /// <summary>
        /// Gets or sets the IP addresses of the database server. IP addresses could be IP V4 or IP V6.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the IP addresses of the database server. IP addresses could be IP V4 or IP V6.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>Gets or sets the database instance Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the database instance Id.",
        SerializedName = @"instanceId",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceId { get; set; }
        /// <summary>Gets or sets the database instance name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the database instance name.",
        SerializedName = @"instanceName",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceName { get; set; }
        /// <summary>Gets or sets the database instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the database instance type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get; set; }
        /// <summary>Gets or sets the database instance version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the database instance version.",
        SerializedName = @"instanceVersion",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceVersion { get; set; }
        /// <summary>
        /// Gets or sets the time of the last modification of the database instance details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the time of the last modification of the database instance details.",
        SerializedName = @"lastUpdatedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastUpdatedTime { get; set; }
        /// <summary>Gets or sets the port number of the database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the port number of the database server.",
        SerializedName = @"portNumber",
        PossibleTypes = new [] { typeof(int) })]
        int? PortNumber { get; set; }
        /// <summary>Gets or sets the name of the solution that sent the data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the name of the solution that sent the data.",
        SerializedName = @"solutionName",
        PossibleTypes = new [] { typeof(string) })]
        string SolutionName { get; set; }

    }
    /// Discovery properties that can be shared by various publishers.
    internal partial interface IDatabaseInstanceDiscoveryDetailsInternal

    {
        /// <summary>Gets or sets the time the message was enqueued.</summary>
        string EnqueueTime { get; set; }
        /// <summary>Gets or sets the extended properties of the database server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceDiscoveryDetailsExtendedInfo ExtendedInfo { get; set; }
        /// <summary>Gets or sets the host name of the database server.</summary>
        string HostName { get; set; }
        /// <summary>
        /// Gets or sets the IP addresses of the database server. IP addresses could be IP V4 or IP V6.
        /// </summary>
        string IPAddress { get; set; }
        /// <summary>Gets or sets the database instance Id.</summary>
        string InstanceId { get; set; }
        /// <summary>Gets or sets the database instance name.</summary>
        string InstanceName { get; set; }
        /// <summary>Gets or sets the database instance type.</summary>
        string InstanceType { get; set; }
        /// <summary>Gets or sets the database instance version.</summary>
        string InstanceVersion { get; set; }
        /// <summary>
        /// Gets or sets the time of the last modification of the database instance details.
        /// </summary>
        global::System.DateTime? LastUpdatedTime { get; set; }
        /// <summary>Gets or sets the port number of the database server.</summary>
        int? PortNumber { get; set; }
        /// <summary>Gets or sets the name of the solution that sent the data.</summary>
        string SolutionName { get; set; }

    }
}