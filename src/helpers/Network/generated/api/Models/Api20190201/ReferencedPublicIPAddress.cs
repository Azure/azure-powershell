namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Reference to a public IP address.</summary>
    public partial class ReferencedPublicIPAddress :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddress,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddressInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The PublicIPAddress Reference.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="ReferencedPublicIPAddress" /> instance.</summary>
        public ReferencedPublicIPAddress()
        {

        }
    }
    /// Reference to a public IP address.
    public partial interface IReferencedPublicIPAddress :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The PublicIPAddress Reference.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The PublicIPAddress Reference.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// Reference to a public IP address.
    internal partial interface IReferencedPublicIPAddressInternal

    {
        /// <summary>The PublicIPAddress Reference.</summary>
        string Id { get; set; }

    }
}