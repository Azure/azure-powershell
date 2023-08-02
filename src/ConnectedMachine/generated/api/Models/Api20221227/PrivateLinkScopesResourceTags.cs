namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class PrivateLinkScopesResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IPrivateLinkScopesResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IPrivateLinkScopesResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="PrivateLinkScopesResourceTags" /> instance.</summary>
        public PrivateLinkScopesResourceTags()
        {

        }
    }
    /// Resource tags
    public partial interface IPrivateLinkScopesResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface IPrivateLinkScopesResourceTagsInternal

    {

    }
}