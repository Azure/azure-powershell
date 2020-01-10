namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>List of virtual network gateway routes</summary>
    public partial class GatewayRouteListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRouteListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRouteListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRoute[] _value;

        /// <summary>List of gateway routes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRoute[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="GatewayRouteListResult" /> instance.</summary>
        public GatewayRouteListResult()
        {

        }
    }
    /// List of virtual network gateway routes
    public partial interface IGatewayRouteListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of gateway routes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of gateway routes",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRoute) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRoute[] Value { get; set; }

    }
    /// List of virtual network gateway routes
    internal partial interface IGatewayRouteListResultInternal

    {
        /// <summary>List of gateway routes</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRoute[] Value { get; set; }

    }
}