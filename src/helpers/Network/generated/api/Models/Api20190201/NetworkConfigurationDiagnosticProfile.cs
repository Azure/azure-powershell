namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters to compare with network configuration.</summary>
    public partial class NetworkConfigurationDiagnosticProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfileInternal
    {

        /// <summary>Backing field for <see cref="Destination" /> property.</summary>
        private string _destination;

        /// <summary>Traffic destination. Accepted values are: '*', IP Address/CIDR, Service Tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Destination { get => this._destination; set => this._destination = value; }

        /// <summary>Backing field for <see cref="DestinationPort" /> property.</summary>
        private string _destinationPort;

        /// <summary>
        /// Traffic destination port. Accepted values are '*', port (for example, 3389) and port range (for example, 80-100).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string DestinationPort { get => this._destinationPort; set => this._destinationPort = value; }

        /// <summary>Backing field for <see cref="Direction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction _direction;

        /// <summary>The direction of the traffic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction Direction { get => this._direction; set => this._direction = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private string _protocol;

        /// <summary>Protocol to be verified on. Accepted values are '*', TCP, UDP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private string _source;

        /// <summary>Traffic source. Accepted values are '*', IP Address/CIDR, Service Tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Source { get => this._source; set => this._source = value; }

        /// <summary>Creates an new <see cref="NetworkConfigurationDiagnosticProfile" /> instance.</summary>
        public NetworkConfigurationDiagnosticProfile()
        {

        }
    }
    /// Parameters to compare with network configuration.
    public partial interface INetworkConfigurationDiagnosticProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Traffic destination. Accepted values are: '*', IP Address/CIDR, Service Tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Traffic destination. Accepted values are: '*', IP Address/CIDR, Service Tag.",
        SerializedName = @"destination",
        PossibleTypes = new [] { typeof(string) })]
        string Destination { get; set; }
        /// <summary>
        /// Traffic destination port. Accepted values are '*', port (for example, 3389) and port range (for example, 80-100).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Traffic destination port. Accepted values are '*', port (for example, 3389) and port range (for example, 80-100).",
        SerializedName = @"destinationPort",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationPort { get; set; }
        /// <summary>The direction of the traffic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The direction of the traffic.",
        SerializedName = @"direction",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction Direction { get; set; }
        /// <summary>Protocol to be verified on. Accepted values are '*', TCP, UDP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Protocol to be verified on. Accepted values are '*', TCP, UDP.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(string) })]
        string Protocol { get; set; }
        /// <summary>Traffic source. Accepted values are '*', IP Address/CIDR, Service Tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Traffic source. Accepted values are '*', IP Address/CIDR, Service Tag.",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(string) })]
        string Source { get; set; }

    }
    /// Parameters to compare with network configuration.
    internal partial interface INetworkConfigurationDiagnosticProfileInternal

    {
        /// <summary>Traffic destination. Accepted values are: '*', IP Address/CIDR, Service Tag.</summary>
        string Destination { get; set; }
        /// <summary>
        /// Traffic destination port. Accepted values are '*', port (for example, 3389) and port range (for example, 80-100).
        /// </summary>
        string DestinationPort { get; set; }
        /// <summary>The direction of the traffic.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction Direction { get; set; }
        /// <summary>Protocol to be verified on. Accepted values are '*', TCP, UDP.</summary>
        string Protocol { get; set; }
        /// <summary>Traffic source. Accepted values are '*', IP Address/CIDR, Service Tag.</summary>
        string Source { get; set; }

    }
}