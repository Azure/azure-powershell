namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class ResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="ResourceTags" /> instance.</summary>
        public ResourceTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IResourceTagsInternal

    {

    }
}