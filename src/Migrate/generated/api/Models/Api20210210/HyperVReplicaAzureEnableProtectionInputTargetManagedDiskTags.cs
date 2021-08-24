namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The tags for the target managed disks.</summary>
    public partial class HyperVReplicaAzureEnableProtectionInputTargetManagedDiskTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IHyperVReplicaAzureEnableProtectionInputTargetManagedDiskTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IHyperVReplicaAzureEnableProtectionInputTargetManagedDiskTagsInternal
    {

        /// <summary>
        /// Creates an new <see cref="HyperVReplicaAzureEnableProtectionInputTargetManagedDiskTags" /> instance.
        /// </summary>
        public HyperVReplicaAzureEnableProtectionInputTargetManagedDiskTags()
        {

        }
    }
    /// The tags for the target managed disks.
    public partial interface IHyperVReplicaAzureEnableProtectionInputTargetManagedDiskTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The tags for the target managed disks.
    internal partial interface IHyperVReplicaAzureEnableProtectionInputTargetManagedDiskTagsInternal

    {

    }
}