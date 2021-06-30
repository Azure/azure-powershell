namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class PatchResourceRequestInputTags :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPatchResourceRequestInputTags,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPatchResourceRequestInputTagsInternal
    {

        /// <summary>Creates an new <see cref="PatchResourceRequestInputTags" /> instance.</summary>
        public PatchResourceRequestInputTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IPatchResourceRequestInputTags :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IPatchResourceRequestInputTagsInternal

    {

    }
}