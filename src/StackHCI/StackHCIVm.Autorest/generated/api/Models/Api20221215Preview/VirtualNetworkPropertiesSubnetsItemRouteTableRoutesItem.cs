namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>RoutePropertiesFormat - Properties of the route.</summary>
    public partial class VirtualNetworkPropertiesSubnetsItemRouteTableRoutesItem :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsItemRouteTableRoutesItem,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsItemRouteTableRoutesItemInternal
    {

        /// <summary>Backing field for <see cref="AddressPrefix" /> property.</summary>
        private string _addressPrefix;

        /// <summary>AddressPrefix - The destination CIDR to which the route applies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string AddressPrefix { get => this._addressPrefix; set => this._addressPrefix = value; }

        /// <summary>Backing field for <see cref="NextHopIPAddress" /> property.</summary>
        private string _nextHopIPAddress;

        /// <summary>
        /// NextHopIPAddress - The IP address packets should be forwarded to. Next hop values are only allowed in routes where the
        /// next hop type is VirtualAppliance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string NextHopIPAddress { get => this._nextHopIPAddress; set => this._nextHopIPAddress = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualNetworkPropertiesSubnetsItemRouteTableRoutesItem" /> instance.
        /// </summary>
        public VirtualNetworkPropertiesSubnetsItemRouteTableRoutesItem()
        {

        }
    }
    /// RoutePropertiesFormat - Properties of the route.
    public partial interface IVirtualNetworkPropertiesSubnetsItemRouteTableRoutesItem :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>AddressPrefix - The destination CIDR to which the route applies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AddressPrefix - The destination CIDR to which the route applies.",
        SerializedName = @"addressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string AddressPrefix { get; set; }
        /// <summary>
        /// NextHopIPAddress - The IP address packets should be forwarded to. Next hop values are only allowed in routes where the
        /// next hop type is VirtualAppliance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"NextHopIPAddress - The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance.",
        SerializedName = @"nextHopIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string NextHopIPAddress { get; set; }

    }
    /// RoutePropertiesFormat - Properties of the route.
    internal partial interface IVirtualNetworkPropertiesSubnetsItemRouteTableRoutesItemInternal

    {
        /// <summary>AddressPrefix - The destination CIDR to which the route applies.</summary>
        string AddressPrefix { get; set; }
        /// <summary>
        /// NextHopIPAddress - The IP address packets should be forwarded to. Next hop values are only allowed in routes where the
        /// next hop type is VirtualAppliance.
        /// </summary>
        string NextHopIPAddress { get; set; }

    }
}