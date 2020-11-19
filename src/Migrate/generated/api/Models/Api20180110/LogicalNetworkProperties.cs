namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Logical Network Properties.</summary>
    public partial class LogicalNetworkProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>The Friendly Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="LogicalNetworkDefinitionsStatus" /> property.</summary>
        private string _logicalNetworkDefinitionsStatus;

        /// <summary>A value indicating whether logical network definitions are isolated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string LogicalNetworkDefinitionsStatus { get => this._logicalNetworkDefinitionsStatus; set => this._logicalNetworkDefinitionsStatus = value; }

        /// <summary>Backing field for <see cref="LogicalNetworkUsage" /> property.</summary>
        private string _logicalNetworkUsage;

        /// <summary>
        /// A value indicating whether logical network is used as private test network by test failover.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string LogicalNetworkUsage { get => this._logicalNetworkUsage; set => this._logicalNetworkUsage = value; }

        /// <summary>Backing field for <see cref="NetworkVirtualizationStatus" /> property.</summary>
        private string _networkVirtualizationStatus;

        /// <summary>
        /// A value indicating whether Network Virtualization is enabled for the logical network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NetworkVirtualizationStatus { get => this._networkVirtualizationStatus; set => this._networkVirtualizationStatus = value; }

        /// <summary>Creates an new <see cref="LogicalNetworkProperties" /> instance.</summary>
        public LogicalNetworkProperties()
        {

        }
    }
    /// Logical Network Properties.
    public partial interface ILogicalNetworkProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The Friendly Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Friendly Name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>A value indicating whether logical network definitions are isolated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether logical network definitions are isolated.",
        SerializedName = @"logicalNetworkDefinitionsStatus",
        PossibleTypes = new [] { typeof(string) })]
        string LogicalNetworkDefinitionsStatus { get; set; }
        /// <summary>
        /// A value indicating whether logical network is used as private test network by test failover.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether logical network is used as private test network by test failover.",
        SerializedName = @"logicalNetworkUsage",
        PossibleTypes = new [] { typeof(string) })]
        string LogicalNetworkUsage { get; set; }
        /// <summary>
        /// A value indicating whether Network Virtualization is enabled for the logical network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether Network Virtualization is enabled for the logical network.",
        SerializedName = @"networkVirtualizationStatus",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkVirtualizationStatus { get; set; }

    }
    /// Logical Network Properties.
    internal partial interface ILogicalNetworkPropertiesInternal

    {
        /// <summary>The Friendly Name.</summary>
        string FriendlyName { get; set; }
        /// <summary>A value indicating whether logical network definitions are isolated.</summary>
        string LogicalNetworkDefinitionsStatus { get; set; }
        /// <summary>
        /// A value indicating whether logical network is used as private test network by test failover.
        /// </summary>
        string LogicalNetworkUsage { get; set; }
        /// <summary>
        /// A value indicating whether Network Virtualization is enabled for the logical network.
        /// </summary>
        string NetworkVirtualizationStatus { get; set; }

    }
}