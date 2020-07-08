namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>The tags that will be assigned to the key vault.</summary>
    public partial class VaultPatchParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchParametersTags,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchParametersTagsInternal
    {

        /// <summary>Creates an new <see cref="VaultPatchParametersTags" /> instance.</summary>
        public VaultPatchParametersTags()
        {

        }
    }
    /// The tags that will be assigned to the key vault.
    public partial interface IVaultPatchParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IAssociativeArray<string>
    {

    }
    /// The tags that will be assigned to the key vault.
    internal partial interface IVaultPatchParametersTagsInternal

    {

    }
}