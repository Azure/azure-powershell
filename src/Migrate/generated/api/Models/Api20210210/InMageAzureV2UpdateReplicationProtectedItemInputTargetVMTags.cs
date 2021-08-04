namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The target VM tags.</summary>
    public partial class InMageAzureV2UpdateReplicationProtectedItemInputTargetVMTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageAzureV2UpdateReplicationProtectedItemInputTargetVMTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageAzureV2UpdateReplicationProtectedItemInputTargetVMTagsInternal
    {

        /// <summary>
        /// Creates an new <see cref="InMageAzureV2UpdateReplicationProtectedItemInputTargetVMTags" /> instance.
        /// </summary>
        public InMageAzureV2UpdateReplicationProtectedItemInputTargetVMTags()
        {

        }
    }
    /// The target VM tags.
    public partial interface IInMageAzureV2UpdateReplicationProtectedItemInputTargetVMTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The target VM tags.
    internal partial interface IInMageAzureV2UpdateReplicationProtectedItemInputTargetVMTagsInternal

    {

    }
}