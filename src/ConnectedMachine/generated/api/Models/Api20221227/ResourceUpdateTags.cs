namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class ResourceUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IResourceUpdateTags,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IResourceUpdateTagsInternal
    {

        /// <summary>Creates an new <see cref="ResourceUpdateTags" /> instance.</summary>
        public ResourceUpdateTags()
        {

        }
    }
    /// Resource tags
    public partial interface IResourceUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface IResourceUpdateTagsInternal

    {

    }
}