namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that define the source and destination endpoint.</summary>
    public partial class NextHopParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INextHopParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INextHopParametersInternal
    {

        /// <summary>Backing field for <see cref="DestinationIPAddress" /> property.</summary>
        private string _destinationIPAddress;

        /// <summary>The destination IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string DestinationIPAddress { get => this._destinationIPAddress; set => this._destinationIPAddress = value; }

        /// <summary>Backing field for <see cref="SourceIPAddress" /> property.</summary>
        private string _sourceIPAddress;

        /// <summary>The source IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SourceIPAddress { get => this._sourceIPAddress; set => this._sourceIPAddress = value; }

        /// <summary>Backing field for <see cref="TargetNicResourceId" /> property.</summary>
        private string _targetNicResourceId;

        /// <summary>
        /// The NIC ID. (If VM has multiple NICs and IP forwarding is enabled on any of the nics, then this parameter must be specified.
        /// Otherwise optional).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TargetNicResourceId { get => this._targetNicResourceId; set => this._targetNicResourceId = value; }

        /// <summary>Backing field for <see cref="TargetResourceId" /> property.</summary>
        private string _targetResourceId;

        /// <summary>
        /// The resource identifier of the target resource against which the action is to be performed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TargetResourceId { get => this._targetResourceId; set => this._targetResourceId = value; }

        /// <summary>Creates an new <see cref="NextHopParameters" /> instance.</summary>
        public NextHopParameters()
        {

        }
    }
    /// Parameters that define the source and destination endpoint.
    public partial interface INextHopParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The destination IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The destination IP address.",
        SerializedName = @"destinationIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationIPAddress { get; set; }
        /// <summary>The source IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The source IP address.",
        SerializedName = @"sourceIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string SourceIPAddress { get; set; }
        /// <summary>
        /// The NIC ID. (If VM has multiple NICs and IP forwarding is enabled on any of the nics, then this parameter must be specified.
        /// Otherwise optional).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The NIC ID. (If VM has multiple NICs and IP forwarding is enabled on any of the nics, then this parameter must be specified. Otherwise optional).",
        SerializedName = @"targetNicResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetNicResourceId { get; set; }
        /// <summary>
        /// The resource identifier of the target resource against which the action is to be performed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The resource identifier of the target resource against which the action is to be performed.",
        SerializedName = @"targetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetResourceId { get; set; }

    }
    /// Parameters that define the source and destination endpoint.
    internal partial interface INextHopParametersInternal

    {
        /// <summary>The destination IP address.</summary>
        string DestinationIPAddress { get; set; }
        /// <summary>The source IP address.</summary>
        string SourceIPAddress { get; set; }
        /// <summary>
        /// The NIC ID. (If VM has multiple NICs and IP forwarding is enabled on any of the nics, then this parameter must be specified.
        /// Otherwise optional).
        /// </summary>
        string TargetNicResourceId { get; set; }
        /// <summary>
        /// The resource identifier of the target resource against which the action is to be performed.
        /// </summary>
        string TargetResourceId { get; set; }

    }
}