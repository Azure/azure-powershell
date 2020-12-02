namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class ResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="ResourceTags" /> instance.</summary>
        public ResourceTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    public partial interface IResourceTagsInternal

    {

    }
}