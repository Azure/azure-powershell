namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The tags for the target managed disks.</summary>
    public partial class InMageAzureV2EnableProtectionInputTargetManagedDiskTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageAzureV2EnableProtectionInputTargetManagedDiskTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageAzureV2EnableProtectionInputTargetManagedDiskTagsInternal
    {

        /// <summary>
        /// Creates an new <see cref="InMageAzureV2EnableProtectionInputTargetManagedDiskTags" /> instance.
        /// </summary>
        public InMageAzureV2EnableProtectionInputTargetManagedDiskTags()
        {

        }
    }
    /// The tags for the target managed disks.
    public partial interface IInMageAzureV2EnableProtectionInputTargetManagedDiskTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The tags for the target managed disks.
    internal partial interface IInMageAzureV2EnableProtectionInputTargetManagedDiskTagsInternal

    {

    }
}