namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class PatchRouteFilterTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPatchRouteFilterTags,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPatchRouteFilterTagsInternal
    {

        /// <summary>Creates an new <see cref="PatchRouteFilterTags" /> instance.</summary>
        public PatchRouteFilterTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IPatchRouteFilterTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IPatchRouteFilterTagsInternal

    {

    }
}