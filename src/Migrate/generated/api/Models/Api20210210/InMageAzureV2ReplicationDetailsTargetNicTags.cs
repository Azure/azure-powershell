namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The tags for the target NICs.</summary>
    public partial class InMageAzureV2ReplicationDetailsTargetNicTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageAzureV2ReplicationDetailsTargetNicTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageAzureV2ReplicationDetailsTargetNicTagsInternal
    {

        /// <summary>
        /// Creates an new <see cref="InMageAzureV2ReplicationDetailsTargetNicTags" /> instance.
        /// </summary>
        public InMageAzureV2ReplicationDetailsTargetNicTags()
        {

        }
    }
    /// The tags for the target NICs.
    public partial interface IInMageAzureV2ReplicationDetailsTargetNicTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The tags for the target NICs.
    internal partial interface IInMageAzureV2ReplicationDetailsTargetNicTagsInternal

    {

    }
}