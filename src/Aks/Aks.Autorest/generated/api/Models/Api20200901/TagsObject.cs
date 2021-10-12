namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Tags object for patch operations.</summary>
    public partial class TagsObject :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ITagsObject,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ITagsObjectInternal
    {

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ITagsObjectTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ITagsObjectTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.TagsObjectTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="TagsObject" /> instance.</summary>
        public TagsObject()
        {

        }
    }
    /// Tags object for patch operations.
    public partial interface ITagsObject :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ITagsObjectTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ITagsObjectTags Tag { get; set; }

    }
    /// Tags object for patch operations.
    internal partial interface ITagsObjectInternal

    {
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ITagsObjectTags Tag { get; set; }

    }
}