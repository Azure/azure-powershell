namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class ComponentsResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="ComponentsResourceTags" /> instance.</summary>
        public ComponentsResourceTags()
        {

        }
    }
    /// Resource tags
    public partial interface IComponentsResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface IComponentsResourceTagsInternal

    {

    }
}