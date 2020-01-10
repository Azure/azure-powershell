namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class PatchRouteFilterRuleTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterRuleTags,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPatchRouteFilterRuleTagsInternal
    {

        /// <summary>Creates an new <see cref="PatchRouteFilterRuleTags" /> instance.</summary>
        public PatchRouteFilterRuleTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IPatchRouteFilterRuleTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IPatchRouteFilterRuleTagsInternal

    {

    }
}