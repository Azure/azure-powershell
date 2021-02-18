namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Tags of the original vault.</summary>
    public partial class DeletedVaultPropertiesTags :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesTags,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesTagsInternal
    {

        /// <summary>Creates an new <see cref="DeletedVaultPropertiesTags" /> instance.</summary>
        public DeletedVaultPropertiesTags()
        {

        }
    }
    /// Tags of the original vault.
    public partial interface IDeletedVaultPropertiesTags :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IAssociativeArray<string>
    {

    }
    /// Tags of the original vault.
    internal partial interface IDeletedVaultPropertiesTagsInternal

    {

    }
}