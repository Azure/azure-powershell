namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that define the operation to create a connection monitor.</summary>
    public partial class ConnectionMonitor :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitor,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorInternal
    {

        /// <summary>Determines if the connection monitor will start automatically once created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? AutoStart { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).AutoStart; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).AutoStart = value; }

        /// <summary>Address of the connection monitor destination (IP or domain name).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).DestinationAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).DestinationAddress = value; }

        /// <summary>The destination port used by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? DestinationPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).DestinationPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).DestinationPort = value; }

        /// <summary>The ID of the resource used as the destination by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).DestinationResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).DestinationResourceId = value; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Connection monitor location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Destination</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorDestination Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorInternal.Destination { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).Destination; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).Destination = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParameters Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorParameters()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Source</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorSource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorInternal.Source { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).Source; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).Source = value; }

        /// <summary>Monitoring interval in seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? MonitoringIntervalInSeconds { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).MonitoringIntervalInSeconds; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).MonitoringIntervalInSeconds = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParameters _property;

        /// <summary>Properties of the connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParameters Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorParameters()); set => this._property = value; }

        /// <summary>The source port used by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? SourcePort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).SourcePort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).SourcePort = value; }

        /// <summary>The ID of the resource used as the source by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SourceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).SourceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)Property).SourceResourceId = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorTags _tag;

        /// <summary>Connection monitor tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="ConnectionMonitor" /> instance.</summary>
        public ConnectionMonitor()
        {

        }
    }
    /// Parameters that define the operation to create a connection monitor.
    public partial interface IConnectionMonitor :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Determines if the connection monitor will start automatically once created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Determines if the connection monitor will start automatically once created.",
        SerializedName = @"autoStart",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AutoStart { get; set; }
        /// <summary>Address of the connection monitor destination (IP or domain name).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Address of the connection monitor destination (IP or domain name).",
        SerializedName = @"address",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationAddress { get; set; }
        /// <summary>The destination port used by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The destination port used by connection monitor.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int? DestinationPort { get; set; }
        /// <summary>The ID of the resource used as the destination by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the resource used as the destination by connection monitor.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationResourceId { get; set; }
        /// <summary>Connection monitor location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Connection monitor location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>Monitoring interval in seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Monitoring interval in seconds.",
        SerializedName = @"monitoringIntervalInSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? MonitoringIntervalInSeconds { get; set; }
        /// <summary>The source port used by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source port used by connection monitor.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int? SourcePort { get; set; }
        /// <summary>The ID of the resource used as the source by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID of the resource used as the source by connection monitor.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceResourceId { get; set; }
        /// <summary>Connection monitor tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Connection monitor tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorTags Tag { get; set; }

    }
    /// Parameters that define the operation to create a connection monitor.
    internal partial interface IConnectionMonitorInternal

    {
        /// <summary>Determines if the connection monitor will start automatically once created.</summary>
        bool? AutoStart { get; set; }
        /// <summary>Describes the destination of connection monitor.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorDestination Destination { get; set; }
        /// <summary>Address of the connection monitor destination (IP or domain name).</summary>
        string DestinationAddress { get; set; }
        /// <summary>The destination port used by connection monitor.</summary>
        int? DestinationPort { get; set; }
        /// <summary>The ID of the resource used as the destination by connection monitor.</summary>
        string DestinationResourceId { get; set; }
        /// <summary>Connection monitor location.</summary>
        string Location { get; set; }
        /// <summary>Monitoring interval in seconds.</summary>
        int? MonitoringIntervalInSeconds { get; set; }
        /// <summary>Properties of the connection monitor.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParameters Property { get; set; }
        /// <summary>Describes the source of connection monitor.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorSource Source { get; set; }
        /// <summary>The source port used by connection monitor.</summary>
        int? SourcePort { get; set; }
        /// <summary>The ID of the resource used as the source by connection monitor.</summary>
        string SourceResourceId { get; set; }
        /// <summary>Connection monitor tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorTags Tag { get; set; }

    }
}