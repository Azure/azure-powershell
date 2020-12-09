namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Discovery properties that can be published by various ISVs.</summary>
    public partial class DiscoveryDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetailsInternal
    {

        /// <summary>Backing field for <see cref="BiosId" /> property.</summary>
        private string _biosId;

        /// <summary>Gets or sets the BIOS ID of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string BiosId { get => this._biosId; set => this._biosId = value; }

        /// <summary>Backing field for <see cref="EnqueueTime" /> property.</summary>
        private string _enqueueTime;

        /// <summary>Gets or sets the time the message was enqueued.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EnqueueTime { get => this._enqueueTime; set => this._enqueueTime = value; }

        /// <summary>Backing field for <see cref="ExtendedInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetailsExtendedInfo _extendedInfo;

        /// <summary>Gets or sets the ISV specific extended information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetailsExtendedInfo ExtendedInfo { get => (this._extendedInfo = this._extendedInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.DiscoveryDetailsExtendedInfo()); set => this._extendedInfo = value; }

        /// <summary>Backing field for <see cref="FabricType" /> property.</summary>
        private string _fabricType;

        /// <summary>Gets or sets the fabric type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FabricType { get => this._fabricType; set => this._fabricType = value; }

        /// <summary>Backing field for <see cref="Fqdn" /> property.</summary>
        private string _fqdn;

        /// <summary>Gets or sets the FQDN of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Fqdn { get => this._fqdn; set => this._fqdn = value; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string[] _iPAddress;

        /// <summary>
        /// Gets or sets the list of IP addresses of the machine. IP addresses could be IP V4 or IP V6.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Backing field for <see cref="LastUpdatedTime" /> property.</summary>
        private global::System.DateTime? _lastUpdatedTime;

        /// <summary>Gets or sets the time of the last modification of the machine details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastUpdatedTime { get => this._lastUpdatedTime; set => this._lastUpdatedTime = value; }

        /// <summary>Backing field for <see cref="MacAddress" /> property.</summary>
        private string[] _macAddress;

        /// <summary>Gets or sets the list of MAC addresses of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] MacAddress { get => this._macAddress; set => this._macAddress = value; }

        /// <summary>Backing field for <see cref="MachineId" /> property.</summary>
        private string _machineId;

        /// <summary>Gets or sets the unique identifier of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MachineId { get => this._machineId; set => this._machineId = value; }

        /// <summary>Backing field for <see cref="MachineManagerId" /> property.</summary>
        private string _machineManagerId;

        /// <summary>Gets or sets the unique identifier of the virtual machine manager(vCenter/VMM).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MachineManagerId { get => this._machineManagerId; set => this._machineManagerId = value; }

        /// <summary>Backing field for <see cref="MachineName" /> property.</summary>
        private string _machineName;

        /// <summary>Gets or sets the name of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MachineName { get => this._machineName; set => this._machineName = value; }

        /// <summary>Backing field for <see cref="OSName" /> property.</summary>
        private string _oSName;

        /// <summary>Gets or sets the OS name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSName { get => this._oSName; set => this._oSName = value; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private string _oSType;

        /// <summary>Gets or sets the OS type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Backing field for <see cref="OSVersion" /> property.</summary>
        private string _oSVersion;

        /// <summary>Gets or sets the OS version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSVersion { get => this._oSVersion; set => this._oSVersion = value; }

        /// <summary>Backing field for <see cref="SolutionName" /> property.</summary>
        private string _solutionName;

        /// <summary>Gets or sets the name of the solution that sent the data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SolutionName { get => this._solutionName; set => this._solutionName = value; }

        /// <summary>Creates an new <see cref="DiscoveryDetails" /> instance.</summary>
        public DiscoveryDetails()
        {

        }
    }
    /// Discovery properties that can be published by various ISVs.
    public partial interface IDiscoveryDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the BIOS ID of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the BIOS ID of the machine.",
        SerializedName = @"biosId",
        PossibleTypes = new [] { typeof(string) })]
        string BiosId { get; set; }
        /// <summary>Gets or sets the time the message was enqueued.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the time the message was enqueued.",
        SerializedName = @"enqueueTime",
        PossibleTypes = new [] { typeof(string) })]
        string EnqueueTime { get; set; }
        /// <summary>Gets or sets the ISV specific extended information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the ISV specific extended information.",
        SerializedName = @"extendedInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetailsExtendedInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetailsExtendedInfo ExtendedInfo { get; set; }
        /// <summary>Gets or sets the fabric type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the fabric type.",
        SerializedName = @"fabricType",
        PossibleTypes = new [] { typeof(string) })]
        string FabricType { get; set; }
        /// <summary>Gets or sets the FQDN of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the FQDN of the machine.",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string Fqdn { get; set; }
        /// <summary>
        /// Gets or sets the list of IP addresses of the machine. IP addresses could be IP V4 or IP V6.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the list of IP addresses of the machine. IP addresses could be IP V4 or IP V6.",
        SerializedName = @"ipAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] IPAddress { get; set; }
        /// <summary>Gets or sets the time of the last modification of the machine details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the time of the last modification of the machine details.",
        SerializedName = @"lastUpdatedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastUpdatedTime { get; set; }
        /// <summary>Gets or sets the list of MAC addresses of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the list of MAC addresses of the machine.",
        SerializedName = @"macAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] MacAddress { get; set; }
        /// <summary>Gets or sets the unique identifier of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the unique identifier of the machine.",
        SerializedName = @"machineId",
        PossibleTypes = new [] { typeof(string) })]
        string MachineId { get; set; }
        /// <summary>Gets or sets the unique identifier of the virtual machine manager(vCenter/VMM).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the unique identifier of the virtual machine manager(vCenter/VMM).",
        SerializedName = @"machineManagerId",
        PossibleTypes = new [] { typeof(string) })]
        string MachineManagerId { get; set; }
        /// <summary>Gets or sets the name of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the name of the machine.",
        SerializedName = @"machineName",
        PossibleTypes = new [] { typeof(string) })]
        string MachineName { get; set; }
        /// <summary>Gets or sets the OS name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the OS name.",
        SerializedName = @"osName",
        PossibleTypes = new [] { typeof(string) })]
        string OSName { get; set; }
        /// <summary>Gets or sets the OS type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the OS type.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSType { get; set; }
        /// <summary>Gets or sets the OS version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the OS version.",
        SerializedName = @"osVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSVersion { get; set; }
        /// <summary>Gets or sets the name of the solution that sent the data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the name of the solution that sent the data.",
        SerializedName = @"solutionName",
        PossibleTypes = new [] { typeof(string) })]
        string SolutionName { get; set; }

    }
    /// Discovery properties that can be published by various ISVs.
    internal partial interface IDiscoveryDetailsInternal

    {
        /// <summary>Gets or sets the BIOS ID of the machine.</summary>
        string BiosId { get; set; }
        /// <summary>Gets or sets the time the message was enqueued.</summary>
        string EnqueueTime { get; set; }
        /// <summary>Gets or sets the ISV specific extended information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetailsExtendedInfo ExtendedInfo { get; set; }
        /// <summary>Gets or sets the fabric type.</summary>
        string FabricType { get; set; }
        /// <summary>Gets or sets the FQDN of the machine.</summary>
        string Fqdn { get; set; }
        /// <summary>
        /// Gets or sets the list of IP addresses of the machine. IP addresses could be IP V4 or IP V6.
        /// </summary>
        string[] IPAddress { get; set; }
        /// <summary>Gets or sets the time of the last modification of the machine details.</summary>
        global::System.DateTime? LastUpdatedTime { get; set; }
        /// <summary>Gets or sets the list of MAC addresses of the machine.</summary>
        string[] MacAddress { get; set; }
        /// <summary>Gets or sets the unique identifier of the machine.</summary>
        string MachineId { get; set; }
        /// <summary>Gets or sets the unique identifier of the virtual machine manager(vCenter/VMM).</summary>
        string MachineManagerId { get; set; }
        /// <summary>Gets or sets the name of the machine.</summary>
        string MachineName { get; set; }
        /// <summary>Gets or sets the OS name.</summary>
        string OSName { get; set; }
        /// <summary>Gets or sets the OS type.</summary>
        string OSType { get; set; }
        /// <summary>Gets or sets the OS version.</summary>
        string OSVersion { get; set; }
        /// <summary>Gets or sets the name of the solution that sent the data.</summary>
        string SolutionName { get; set; }

    }
}