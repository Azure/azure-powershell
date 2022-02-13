namespace Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.Extensions;

    /// <summary>Tags on the azure resource.</summary>
    public partial class AccountUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountUpdateParametersTags,
        Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountUpdateParametersTagsInternal
    {

        /// <summary>Creates an new <see cref="AccountUpdateParametersTags" /> instance.</summary>
        public AccountUpdateParametersTags()
        {

        }
    }
    /// Tags on the azure resource.
    public partial interface IAccountUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.IAssociativeArray<string>
    {

    }
    /// Tags on the azure resource.
    internal partial interface IAccountUpdateParametersTagsInternal

    {

    }
}