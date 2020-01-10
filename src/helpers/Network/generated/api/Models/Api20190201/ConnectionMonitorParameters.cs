namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that define the operation to create a connection monitor.</summary>
    public partial class ConnectionMonitorParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal
    {

        /// <summary>Backing field for <see cref="AutoStart" /> property.</summary>
        private bool? _autoStart;

        /// <summary>Determines if the connection monitor will start automatically once created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? AutoStart { get => this._autoStart; set => this._autoStart = value; }

        /// <summary>Backing field for <see cref="Destination" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorDestination _destination;

        /// <summary>Describes the destination of connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorDestination Destination { get => (this._destination = this._destination ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorDestination()); set => this._destination = value; }

        /// <summary>Address of the connection monitor destination (IP or domain name).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorDestinationInternal)Destination).Address; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorDestinationInternal)Destination).Address = value; }

        /// <summary>The destination port used by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? DestinationPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorDestinationInternal)Destination).Port; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorDestinationInternal)Destination).Port = value; }

        /// <summary>The ID of the resource used as the destination by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorDestinationInternal)Destination).ResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorDestinationInternal)Destination).ResourceId = value; }

        /// <summary>Internal Acessors for Destination</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorDestination Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal.Destination { get => (this._destination = this._destination ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorDestination()); set { {_destination = value;} } }

        /// <summary>Internal Acessors for Source</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorSource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal.Source { get => (this._source = this._source ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorSource()); set { {_source = value;} } }

        /// <summary>Backing field for <see cref="MonitoringIntervalInSeconds" /> property.</summary>
        private int? _monitoringIntervalInSeconds;

        /// <summary>Monitoring interval in seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? MonitoringIntervalInSeconds { get => this._monitoringIntervalInSeconds; set => this._monitoringIntervalInSeconds = value; }

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorSource _source;

        /// <summary>Describes the source of connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorSource Source { get => (this._source = this._source ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorSource()); set => this._source = value; }

        /// <summary>The source port used by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? SourcePort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorSourceInternal)Source).Port; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorSourceInternal)Source).Port = value; }

        /// <summary>The ID of the resource used as the source by connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SourceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorSourceInternal)Source).ResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorSourceInternal)Source).ResourceId = value; }

        /// <summary>Creates an new <see cref="ConnectionMonitorParameters" /> instance.</summary>
        public ConnectionMonitorParameters()
        {

        }
    }
    /// Parameters that define the operation to create a connection monitor.
    public partial interface IConnectionMonitorParameters :
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

    }
    /// Parameters that define the operation to create a connection monitor.
    internal partial interface IConnectionMonitorParametersInternal

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
        /// <summary>Monitoring interval in seconds.</summary>
        int? MonitoringIntervalInSeconds { get; set; }
        /// <summary>Describes the source of connection monitor.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorSource Source { get; set; }
        /// <summary>The source port used by connection monitor.</summary>
        int? SourcePort { get; set; }
        /// <summary>The ID of the resource used as the source by connection monitor.</summary>
        string SourceResourceId { get; set; }

    }
}