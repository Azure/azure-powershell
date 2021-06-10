namespace Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataDog.Runtime.Extensions;

    /// <summary>The definition of a linked resource.</summary>
    public partial class LinkedResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301.ILinkedResource,
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301.ILinkedResourceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The ARM id of the linked resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataDog.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataDog.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="LinkedResource" /> instance.</summary>
        public LinkedResource()
        {

        }
    }
    /// The definition of a linked resource.
    public partial interface ILinkedResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Runtime.IJsonSerializable
    {
        /// <summary>The ARM id of the linked resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataDog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM id of the linked resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// The definition of a linked resource.
    internal partial interface ILinkedResourceInternal

    {
        /// <summary>The ARM id of the linked resource.</summary>
        string Id { get; set; }

    }
}