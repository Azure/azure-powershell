namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Identifies the service being brought into the virtual network.</summary>
    public partial class EndpointService :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointService,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointServiceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>A unique identifier of the service being referenced by the interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="EndpointService" /> instance.</summary>
        public EndpointService()
        {

        }
    }
    /// Identifies the service being brought into the virtual network.
    public partial interface IEndpointService :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>A unique identifier of the service being referenced by the interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique identifier of the service being referenced by the interface endpoint.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// Identifies the service being brought into the virtual network.
    internal partial interface IEndpointServiceInternal

    {
        /// <summary>A unique identifier of the service being referenced by the interface endpoint.</summary>
        string Id { get; set; }

    }
}