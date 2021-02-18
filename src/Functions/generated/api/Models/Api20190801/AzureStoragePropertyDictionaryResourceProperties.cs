namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Azure storage accounts.</summary>
    public partial class AzureStoragePropertyDictionaryResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureStoragePropertyDictionaryResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureStoragePropertyDictionaryResourcePropertiesInternal
    {

        /// <summary>
        /// Creates an new <see cref="AzureStoragePropertyDictionaryResourceProperties" /> instance.
        /// </summary>
        public AzureStoragePropertyDictionaryResourceProperties()
        {

        }
    }
    /// Azure storage accounts.
    public partial interface IAzureStoragePropertyDictionaryResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureStorageInfoValue>
    {

    }
    /// Azure storage accounts.
    internal partial interface IAzureStoragePropertyDictionaryResourcePropertiesInternal

    {

    }
}