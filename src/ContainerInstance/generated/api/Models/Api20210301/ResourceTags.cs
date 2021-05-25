namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The resource tags.</summary>
    public partial class ResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="ResourceTags" /> instance.</summary>
        public ResourceTags()
        {

        }
    }
    /// The resource tags.
    public partial interface IResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IAssociativeArray<string>
    {

    }
    /// The resource tags.
    internal partial interface IResourceTagsInternal

    {

    }
}