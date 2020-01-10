namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that define the IP flow to be verified.</summary>
    public partial class VerificationIPFlowParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal
    {

        /// <summary>Backing field for <see cref="Direction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction _direction;

        /// <summary>The direction of the packet represented as a 5-tuple.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction Direction { get => this._direction; set => this._direction = value; }

        /// <summary>Backing field for <see cref="LocalIPAddress" /> property.</summary>
        private string _localIPAddress;

        /// <summary>The local IP address. Acceptable values are valid IPv4 addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LocalIPAddress { get => this._localIPAddress; set => this._localIPAddress = value; }

        /// <summary>Backing field for <see cref="LocalPort" /> property.</summary>
        private string _localPort;

        /// <summary>
        /// The local port. Acceptable values are a single integer in the range (0-65535). Support for * for the source port, which
        /// depends on the direction.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LocalPort { get => this._localPort; set => this._localPort = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol _protocol;

        /// <summary>Protocol to be verified on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="RemoteIPAddress" /> property.</summary>
        private string _remoteIPAddress;

        /// <summary>The remote IP address. Acceptable values are valid IPv4 addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RemoteIPAddress { get => this._remoteIPAddress; set => this._remoteIPAddress = value; }

        /// <summary>Backing field for <see cref="RemotePort" /> property.</summary>
        private string _remotePort;

        /// <summary>
        /// The remote port. Acceptable values are a single integer in the range (0-65535). Support for * for the source port, which
        /// depends on the direction.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RemotePort { get => this._remotePort; set => this._remotePort = value; }

        /// <summary>Backing field for <see cref="TargetNicResourceId" /> property.</summary>
        private string _targetNicResourceId;

        /// <summary>
        /// The NIC ID. (If VM has multiple NICs and IP forwarding is enabled on any of them, then this parameter must be specified.
        /// Otherwise optional).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TargetNicResourceId { get => this._targetNicResourceId; set => this._targetNicResourceId = value; }

        /// <summary>Backing field for <see cref="TargetResourceId" /> property.</summary>
        private string _targetResourceId;

        /// <summary>The ID of the target resource to perform next-hop on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TargetResourceId { get => this._targetResourceId; set => this._targetResourceId = value; }

        /// <summary>Creates an new <see cref="VerificationIPFlowParameters" /> instance.</summary>
        public VerificationIPFlowParameters()
        {

        }
    }
    /// Parameters that define the IP flow to be verified.
    public partial interface IVerificationIPFlowParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The direction of the packet represented as a 5-tuple.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The direction of the packet represented as a 5-tuple.",
        SerializedName = @"direction",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction Direction { get; set; }
        /// <summary>The local IP address. Acceptable values are valid IPv4 addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The local IP address. Acceptable values are valid IPv4 addresses.",
        SerializedName = @"localIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string LocalIPAddress { get; set; }
        /// <summary>
        /// The local port. Acceptable values are a single integer in the range (0-65535). Support for * for the source port, which
        /// depends on the direction.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The local port. Acceptable values are a single integer in the range (0-65535). Support for * for the source port, which depends on the direction.",
        SerializedName = @"localPort",
        PossibleTypes = new [] { typeof(string) })]
        string LocalPort { get; set; }
        /// <summary>Protocol to be verified on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Protocol to be verified on.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol Protocol { get; set; }
        /// <summary>The remote IP address. Acceptable values are valid IPv4 addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The remote IP address. Acceptable values are valid IPv4 addresses.",
        SerializedName = @"remoteIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string RemoteIPAddress { get; set; }
        /// <summary>
        /// The remote port. Acceptable values are a single integer in the range (0-65535). Support for * for the source port, which
        /// depends on the direction.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The remote port. Acceptable values are a single integer in the range (0-65535). Support for * for the source port, which depends on the direction.",
        SerializedName = @"remotePort",
        PossibleTypes = new [] { typeof(string) })]
        string RemotePort { get; set; }
        /// <summary>
        /// The NIC ID. (If VM has multiple NICs and IP forwarding is enabled on any of them, then this parameter must be specified.
        /// Otherwise optional).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The NIC ID. (If VM has multiple NICs and IP forwarding is enabled on any of them, then this parameter must be specified. Otherwise optional).",
        SerializedName = @"targetNicResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetNicResourceId { get; set; }
        /// <summary>The ID of the target resource to perform next-hop on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID of the target resource to perform next-hop on.",
        SerializedName = @"targetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetResourceId { get; set; }

    }
    /// Parameters that define the IP flow to be verified.
    internal partial interface IVerificationIPFlowParametersInternal

    {
        /// <summary>The direction of the packet represented as a 5-tuple.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction Direction { get; set; }
        /// <summary>The local IP address. Acceptable values are valid IPv4 addresses.</summary>
        string LocalIPAddress { get; set; }
        /// <summary>
        /// The local port. Acceptable values are a single integer in the range (0-65535). Support for * for the source port, which
        /// depends on the direction.
        /// </summary>
        string LocalPort { get; set; }
        /// <summary>Protocol to be verified on.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol Protocol { get; set; }
        /// <summary>The remote IP address. Acceptable values are valid IPv4 addresses.</summary>
        string RemoteIPAddress { get; set; }
        /// <summary>
        /// The remote port. Acceptable values are a single integer in the range (0-65535). Support for * for the source port, which
        /// depends on the direction.
        /// </summary>
        string RemotePort { get; set; }
        /// <summary>
        /// The NIC ID. (If VM has multiple NICs and IP forwarding is enabled on any of them, then this parameter must be specified.
        /// Otherwise optional).
        /// </summary>
        string TargetNicResourceId { get; set; }
        /// <summary>The ID of the target resource to perform next-hop on.</summary>
        string TargetResourceId { get; set; }

    }
}