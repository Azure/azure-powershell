namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class VMwareSiteTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteTagsInternal
    {

        /// <summary>Creates an new <see cref="VMwareSiteTags" /> instance.</summary>
        public VMwareSiteTags()
        {

        }
    }
    public partial interface IVMwareSiteTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    internal partial interface IVMwareSiteTagsInternal

    {

    }
}