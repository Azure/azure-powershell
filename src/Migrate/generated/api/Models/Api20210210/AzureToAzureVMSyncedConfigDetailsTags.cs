namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The Azure VM tags.</summary>
    public partial class AzureToAzureVMSyncedConfigDetailsTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IAzureToAzureVMSyncedConfigDetailsTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IAzureToAzureVMSyncedConfigDetailsTagsInternal
    {

        /// <summary>Creates an new <see cref="AzureToAzureVMSyncedConfigDetailsTags" /> instance.</summary>
        public AzureToAzureVMSyncedConfigDetailsTags()
        {

        }
    }
    /// The Azure VM tags.
    public partial interface IAzureToAzureVMSyncedConfigDetailsTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The Azure VM tags.
    internal partial interface IAzureToAzureVMSyncedConfigDetailsTagsInternal

    {

    }
}