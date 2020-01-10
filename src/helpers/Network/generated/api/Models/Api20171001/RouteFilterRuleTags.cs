namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class RouteFilterRuleTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRuleTags,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRuleTagsInternal
    {

        /// <summary>Creates an new <see cref="RouteFilterRuleTags" /> instance.</summary>
        public RouteFilterRuleTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IRouteFilterRuleTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IRouteFilterRuleTagsInternal

    {

    }
}