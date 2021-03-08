namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>ARM resource tags</summary>
    public partial class OrganizationResourceUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceUpdateTags,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceUpdateTagsInternal
    {

        /// <summary>Creates an new <see cref="OrganizationResourceUpdateTags" /> instance.</summary>
        public OrganizationResourceUpdateTags()
        {

        }
    }
    /// ARM resource tags
    public partial interface IOrganizationResourceUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IAssociativeArray<string>
    {

    }
    /// ARM resource tags
    internal partial interface IOrganizationResourceUpdateTagsInternal

    {

    }
}