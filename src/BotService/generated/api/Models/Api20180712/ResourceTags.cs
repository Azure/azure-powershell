namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Contains resource tags defined as key/value pairs.</summary>
    public partial class ResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="ResourceTags" /> instance.</summary>
        public ResourceTags()
        {

        }
    }
    /// Contains resource tags defined as key/value pairs.
    public partial interface IResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IAssociativeArray<string>
    {

    }
    /// Contains resource tags defined as key/value pairs.
    internal partial interface IResourceTagsInternal

    {

    }
}