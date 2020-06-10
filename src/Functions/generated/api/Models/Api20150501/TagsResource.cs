namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// A container holding only the Tags for a resource, allowing the user to update the tags on a WebTest instance.
    /// </summary>
    public partial class TagsResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResourceInternal
    {

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResourceTags _tag;

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResourceTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.TagsResourceTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="TagsResource" /> instance.</summary>
        public TagsResource()
        {

        }
    }
    /// A container holding only the Tags for a resource, allowing the user to update the tags on a WebTest instance.
    public partial interface ITagsResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResourceTags Tag { get; set; }

    }
    /// A container holding only the Tags for a resource, allowing the user to update the tags on a WebTest instance.
    internal partial interface ITagsResourceInternal

    {
        /// <summary>Resource tags</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResourceTags Tag { get; set; }

    }
}