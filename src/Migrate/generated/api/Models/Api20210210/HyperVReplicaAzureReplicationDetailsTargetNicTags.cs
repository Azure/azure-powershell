namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The tags for the target NICs.</summary>
    public partial class HyperVReplicaAzureReplicationDetailsTargetNicTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IHyperVReplicaAzureReplicationDetailsTargetNicTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IHyperVReplicaAzureReplicationDetailsTargetNicTagsInternal
    {

        /// <summary>
        /// Creates an new <see cref="HyperVReplicaAzureReplicationDetailsTargetNicTags" /> instance.
        /// </summary>
        public HyperVReplicaAzureReplicationDetailsTargetNicTags()
        {

        }
    }
    /// The tags for the target NICs.
    public partial interface IHyperVReplicaAzureReplicationDetailsTargetNicTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The tags for the target NICs.
    internal partial interface IHyperVReplicaAzureReplicationDetailsTargetNicTagsInternal

    {

    }
}