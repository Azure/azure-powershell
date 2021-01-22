namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Dictionary of <string></summary>
    public partial class VMwareSiteTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteTagsInternal
    {

        /// <summary>Creates an new <see cref="VMwareSiteTags" /> instance.</summary>
        public VMwareSiteTags()
        {

        }
    }
    /// Dictionary of <string>
    public partial interface IVMwareSiteTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// Dictionary of <string>
    internal partial interface IVMwareSiteTagsInternal

    {

    }
}