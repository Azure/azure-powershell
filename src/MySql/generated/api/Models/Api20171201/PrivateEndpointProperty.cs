namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    public partial class PrivateEndpointProperty :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPrivateEndpointProperty,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPrivateEndpointPropertyInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource id of the private endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="PrivateEndpointProperty" /> instance.</summary>
        public PrivateEndpointProperty()
        {

        }
    }
    public partial interface IPrivateEndpointProperty :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>Resource id of the private endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource id of the private endpoint.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    internal partial interface IPrivateEndpointPropertyInternal

    {
        /// <summary>Resource id of the private endpoint.</summary>
        string Id { get; set; }

    }
}