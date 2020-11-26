namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Dictionary of <string></summary>
    public partial class HyperVSiteTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteTagsInternal
    {

        /// <summary>Creates an new <see cref="HyperVSiteTags" /> instance.</summary>
        public HyperVSiteTags()
        {

        }
    }
    /// Dictionary of <string>
    public partial interface IHyperVSiteTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// Dictionary of <string>
    internal partial interface IHyperVSiteTagsInternal

    {

    }
}