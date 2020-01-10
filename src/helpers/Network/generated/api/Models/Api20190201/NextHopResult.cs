namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>The information about next hop from the specified VM.</summary>
    public partial class NextHopResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INextHopResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INextHopResultInternal
    {

        /// <summary>Backing field for <see cref="NextHopIPAddress" /> property.</summary>
        private string _nextHopIPAddress;

        /// <summary>Next hop IP Address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextHopIPAddress { get => this._nextHopIPAddress; set => this._nextHopIPAddress = value; }

        /// <summary>Backing field for <see cref="NextHopType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.NextHopType? _nextHopType;

        /// <summary>Next hop type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.NextHopType? NextHopType { get => this._nextHopType; set => this._nextHopType = value; }

        /// <summary>Backing field for <see cref="RouteTableId" /> property.</summary>
        private string _routeTableId;

        /// <summary>
        /// The resource identifier for the route table associated with the route being returned. If the route being returned does
        /// not correspond to any user created routes then this field will be the string 'System Route'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RouteTableId { get => this._routeTableId; set => this._routeTableId = value; }

        /// <summary>Creates an new <see cref="NextHopResult" /> instance.</summary>
        public NextHopResult()
        {

        }
    }
    /// The information about next hop from the specified VM.
    public partial interface INextHopResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Next hop IP Address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Next hop IP Address",
        SerializedName = @"nextHopIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string NextHopIPAddress { get; set; }
        /// <summary>Next hop type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Next hop type.",
        SerializedName = @"nextHopType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.NextHopType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.NextHopType? NextHopType { get; set; }
        /// <summary>
        /// The resource identifier for the route table associated with the route being returned. If the route being returned does
        /// not correspond to any user created routes then this field will be the string 'System Route'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource identifier for the route table associated with the route being returned. If the route being returned does not correspond to any user created routes then this field will be the string 'System Route'.",
        SerializedName = @"routeTableId",
        PossibleTypes = new [] { typeof(string) })]
        string RouteTableId { get; set; }

    }
    /// The information about next hop from the specified VM.
    internal partial interface INextHopResultInternal

    {
        /// <summary>Next hop IP Address</summary>
        string NextHopIPAddress { get; set; }
        /// <summary>Next hop type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.NextHopType? NextHopType { get; set; }
        /// <summary>
        /// The resource identifier for the route table associated with the route being returned. If the route being returned does
        /// not correspond to any user created routes then this field will be the string 'System Route'.
        /// </summary>
        string RouteTableId { get; set; }

    }
}