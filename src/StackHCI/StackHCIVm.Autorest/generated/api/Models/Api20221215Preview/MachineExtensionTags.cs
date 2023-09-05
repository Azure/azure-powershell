namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>The Resource tags.</summary>
    public partial class MachineExtensionTags :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionTags,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionTagsInternal
    {

        /// <summary>Creates an new <see cref="MachineExtensionTags" /> instance.</summary>
        public MachineExtensionTags()
        {

        }
    }
    /// The Resource tags.
    public partial interface IMachineExtensionTags :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IAssociativeArray<string>
    {

    }
    /// The Resource tags.
    internal partial interface IMachineExtensionTagsInternal

    {

    }
}