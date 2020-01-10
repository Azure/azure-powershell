namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Tags object for patch operations.</summary>
    public partial class TagsObject :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITagsObject,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITagsObjectInternal
    {

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITagsObjectTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITagsObjectTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.TagsObjectTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="TagsObject" /> instance.</summary>
        public TagsObject()
        {

        }
    }
    /// Tags object for patch operations.
    public partial interface ITagsObject :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITagsObjectTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITagsObjectTags Tag { get; set; }

    }
    /// Tags object for patch operations.
    internal partial interface ITagsObjectInternal

    {
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITagsObjectTags Tag { get; set; }

    }
}