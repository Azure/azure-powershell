namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Organization resource tags</summary>
    public partial class OrganizationResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="OrganizationResourceTags" /> instance.</summary>
        public OrganizationResourceTags()
        {

        }
    }
    /// Organization resource tags
    public partial interface IOrganizationResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IAssociativeArray<string>
    {

    }
    /// Organization resource tags
    internal partial interface IOrganizationResourceTagsInternal

    {

    }
}