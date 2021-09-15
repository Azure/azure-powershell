namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>A reference to an Azure resource.</summary>
    public partial class ResourceReference :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReferenceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The fully qualified Azure resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="ResourceReference" /> instance.</summary>
        public ResourceReference()
        {

        }
    }
    /// A reference to an Azure resource.
    public partial interface IResourceReference :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>The fully qualified Azure resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The fully qualified Azure resource id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// A reference to an Azure resource.
    internal partial interface IResourceReferenceInternal

    {
        /// <summary>The fully qualified Azure resource id.</summary>
        string Id { get; set; }

    }
}