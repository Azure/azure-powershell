namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class UpdateResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IUpdateResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IUpdateResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="UpdateResourceTags" /> instance.</summary>
        public UpdateResourceTags()
        {

        }
    }
    /// Resource tags
    public partial interface IUpdateResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface IUpdateResourceTagsInternal

    {

    }
}