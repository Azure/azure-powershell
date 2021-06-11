namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class ResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="ResourceTags" /> instance.</summary>
        public ResourceTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IResourceTagsInternal

    {

    }
}