namespace Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Extensions;

    /// <summary>
    /// The list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across
    /// resource groups).
    /// </summary>
    public partial class ResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="ResourceTags" /> instance.</summary>
        public ResourceTags()
        {

        }
    }
    /// The list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across
    /// resource groups).
    public partial interface IResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.IAssociativeArray<string>
    {

    }
    /// The list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across
    /// resource groups).
    internal partial interface IResourceTagsInternal

    {

    }
}