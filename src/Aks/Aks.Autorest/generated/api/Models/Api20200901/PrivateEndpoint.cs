namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Private endpoint which a connection belongs to.</summary>
    public partial class PrivateEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpoint,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The resource Id for private endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="PrivateEndpoint" /> instance.</summary>
        public PrivateEndpoint()
        {

        }
    }
    /// Private endpoint which a connection belongs to.
    public partial interface IPrivateEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>The resource Id for private endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource Id for private endpoint",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// Private endpoint which a connection belongs to.
    internal partial interface IPrivateEndpointInternal

    {
        /// <summary>The resource Id for private endpoint</summary>
        string Id { get; set; }

    }
}