namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>VirtualHub route table</summary>
    public partial class VirtualHubRouteTable :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRouteTable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRouteTableInternal
    {

        /// <summary>Backing field for <see cref="Route" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRoute[] _route;

        /// <summary>List of all routes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRoute[] Route { get => this._route; set => this._route = value; }

        /// <summary>Creates an new <see cref="VirtualHubRouteTable" /> instance.</summary>
        public VirtualHubRouteTable()
        {

        }
    }
    /// VirtualHub route table
    public partial interface IVirtualHubRouteTable :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of all routes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of all routes.",
        SerializedName = @"routes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRoute) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRoute[] Route { get; set; }

    }
    /// VirtualHub route table
    internal partial interface IVirtualHubRouteTableInternal

    {
        /// <summary>List of all routes.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRoute[] Route { get; set; }

    }
}