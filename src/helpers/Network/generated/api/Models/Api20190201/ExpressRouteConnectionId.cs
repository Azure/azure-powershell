namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>The ID of the ExpressRouteConnection.</summary>
    public partial class ExpressRouteConnectionId :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionId,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionIdInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The ID of the ExpressRouteConnection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnectionIdInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Creates an new <see cref="ExpressRouteConnectionId" /> instance.</summary>
        public ExpressRouteConnectionId()
        {

        }
    }
    /// The ID of the ExpressRouteConnection.
    public partial interface IExpressRouteConnectionId :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The ID of the ExpressRouteConnection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ID of the ExpressRouteConnection.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }

    }
    /// The ID of the ExpressRouteConnection.
    internal partial interface IExpressRouteConnectionIdInternal

    {
        /// <summary>The ID of the ExpressRouteConnection.</summary>
        string Id { get; set; }

    }
}