namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>RouteTablePropertiesFormat route Table resource.</summary>
    public partial class Components3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetableProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IComponents3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetableProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IComponents3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetablePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Route" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsPropertiesItemsItem[] _route;

        /// <summary>Routes - Collection of routes contained within a route table.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsPropertiesItemsItem[] Route { get => this._route; set => this._route = value; }

        /// <summary>
        /// Creates an new <see cref="Components3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetableProperties"
        /// /> instance.
        /// </summary>
        public Components3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetableProperties()
        {

        }
    }
    /// RouteTablePropertiesFormat route Table resource.
    public partial interface IComponents3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetableProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>Routes - Collection of routes contained within a route table.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Routes - Collection of routes contained within a route table.",
        SerializedName = @"routes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsPropertiesItemsItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsPropertiesItemsItem[] Route { get; set; }

    }
    /// RouteTablePropertiesFormat route Table resource.
    internal partial interface IComponents3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetablePropertiesInternal

    {
        /// <summary>Routes - Collection of routes contained within a route table.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsPropertiesItemsItem[] Route { get; set; }

    }
}