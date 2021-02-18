namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>The tags that will be assigned to the key vault.</summary>
    public partial class VaultCreateOrUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersTags,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersTagsInternal
    {

        /// <summary>Creates an new <see cref="VaultCreateOrUpdateParametersTags" /> instance.</summary>
        public VaultCreateOrUpdateParametersTags()
        {

        }
    }
    /// The tags that will be assigned to the key vault.
    public partial interface IVaultCreateOrUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IAssociativeArray<string>
    {

    }
    /// The tags that will be assigned to the key vault.
    internal partial interface IVaultCreateOrUpdateParametersTagsInternal

    {

    }
}