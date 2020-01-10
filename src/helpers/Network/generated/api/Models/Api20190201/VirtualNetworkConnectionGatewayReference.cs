namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>A reference to VirtualNetworkGateway or LocalNetworkGateway resource.</summary>
    public partial class VirtualNetworkConnectionGatewayReference :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkConnectionGatewayReference,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkConnectionGatewayReferenceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The ID of VirtualNetworkGateway or LocalNetworkGateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualNetworkConnectionGatewayReference" /> instance.
        /// </summary>
        public VirtualNetworkConnectionGatewayReference()
        {

        }
    }
    /// A reference to VirtualNetworkGateway or LocalNetworkGateway resource.
    public partial interface IVirtualNetworkConnectionGatewayReference :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The ID of VirtualNetworkGateway or LocalNetworkGateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID of VirtualNetworkGateway or LocalNetworkGateway resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// A reference to VirtualNetworkGateway or LocalNetworkGateway resource.
    internal partial interface IVirtualNetworkConnectionGatewayReferenceInternal

    {
        /// <summary>The ID of VirtualNetworkGateway or LocalNetworkGateway resource.</summary>
        string Id { get; set; }

    }
}