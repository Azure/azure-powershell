namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Virtual Hub identifier.</summary>
    public partial class VirtualHubId :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubId,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubIdInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>
        /// The resource URI for the Virtual Hub where the ExpressRoute gateway is or will be deployed. The Virtual Hub resource and
        /// the ExpressRoute gateway resource reside in the same subscription.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="VirtualHubId" /> instance.</summary>
        public VirtualHubId()
        {

        }
    }
    /// Virtual Hub identifier.
    public partial interface IVirtualHubId :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The resource URI for the Virtual Hub where the ExpressRoute gateway is or will be deployed. The Virtual Hub resource and
        /// the ExpressRoute gateway resource reside in the same subscription.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource URI for the Virtual Hub where the ExpressRoute gateway is or will be deployed. The Virtual Hub resource and the ExpressRoute gateway resource reside in the same subscription.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// Virtual Hub identifier.
    internal partial interface IVirtualHubIdInternal

    {
        /// <summary>
        /// The resource URI for the Virtual Hub where the ExpressRoute gateway is or will be deployed. The Virtual Hub resource and
        /// the ExpressRoute gateway resource reside in the same subscription.
        /// </summary>
        string Id { get; set; }

    }
}