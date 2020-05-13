namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class ResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="ResourceTags" /> instance.</summary>
        public ResourceTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IResourceTagsInternal

    {

    }
}