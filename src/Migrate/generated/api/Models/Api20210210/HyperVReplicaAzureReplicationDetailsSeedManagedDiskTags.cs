namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The tags for the seed managed disks.</summary>
    public partial class HyperVReplicaAzureReplicationDetailsSeedManagedDiskTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IHyperVReplicaAzureReplicationDetailsSeedManagedDiskTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IHyperVReplicaAzureReplicationDetailsSeedManagedDiskTagsInternal
    {

        /// <summary>
        /// Creates an new <see cref="HyperVReplicaAzureReplicationDetailsSeedManagedDiskTags" /> instance.
        /// </summary>
        public HyperVReplicaAzureReplicationDetailsSeedManagedDiskTags()
        {

        }
    }
    /// The tags for the seed managed disks.
    public partial interface IHyperVReplicaAzureReplicationDetailsSeedManagedDiskTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The tags for the seed managed disks.
    internal partial interface IHyperVReplicaAzureReplicationDetailsSeedManagedDiskTagsInternal

    {

    }
}