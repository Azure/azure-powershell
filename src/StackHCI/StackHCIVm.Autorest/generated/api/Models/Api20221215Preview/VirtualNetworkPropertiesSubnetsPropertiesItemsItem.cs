namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>Route is associated with a subnet.</summary>
    public partial class VirtualNetworkPropertiesSubnetsPropertiesItemsItem :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsPropertiesItemsItem,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsPropertiesItemsItemInternal
    {

        /// <summary>AddressPrefix - The destination CIDR to which the route applies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string AddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsItemRouteTableRoutesItemInternal)Property).AddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsItemRouteTableRoutesItemInternal)Property).AddressPrefix = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsItemRouteTableRoutesItem Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsPropertiesItemsItemInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualNetworkPropertiesSubnetsItemRouteTableRoutesItem()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name - name of the subnet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>
        /// NextHopIPAddress - The IP address packets should be forwarded to. Next hop values are only allowed in routes where the
        /// next hop type is VirtualAppliance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string NextHopIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsItemRouteTableRoutesItemInternal)Property).NextHopIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsItemRouteTableRoutesItemInternal)Property).NextHopIPAddress = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsItemRouteTableRoutesItem _property;

        /// <summary>RoutePropertiesFormat - Properties of the route.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsItemRouteTableRoutesItem Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualNetworkPropertiesSubnetsItemRouteTableRoutesItem()); set => this._property = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualNetworkPropertiesSubnetsPropertiesItemsItem" /> instance.
        /// </summary>
        public VirtualNetworkPropertiesSubnetsPropertiesItemsItem()
        {

        }
    }
    /// Route is associated with a subnet.
    public partial interface IVirtualNetworkPropertiesSubnetsPropertiesItemsItem :
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
        /// <summary>Name - name of the subnet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name - name of the subnet",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
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
    /// Route is associated with a subnet.
    internal partial interface IVirtualNetworkPropertiesSubnetsPropertiesItemsItemInternal

    {
        /// <summary>AddressPrefix - The destination CIDR to which the route applies.</summary>
        string AddressPrefix { get; set; }
        /// <summary>Name - name of the subnet</summary>
        string Name { get; set; }
        /// <summary>
        /// NextHopIPAddress - The IP address packets should be forwarded to. Next hop values are only allowed in routes where the
        /// next hop type is VirtualAppliance.
        /// </summary>
        string NextHopIPAddress { get; set; }
        /// <summary>RoutePropertiesFormat - Properties of the route.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsItemRouteTableRoutesItem Property { get; set; }

    }
}