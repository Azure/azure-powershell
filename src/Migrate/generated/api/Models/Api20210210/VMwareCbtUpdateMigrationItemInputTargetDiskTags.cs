namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The tags for the target disks.</summary>
    public partial class VMwareCbtUpdateMigrationItemInputTargetDiskTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtUpdateMigrationItemInputTargetDiskTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtUpdateMigrationItemInputTargetDiskTagsInternal
    {

        /// <summary>
        /// Creates an new <see cref="VMwareCbtUpdateMigrationItemInputTargetDiskTags" /> instance.
        /// </summary>
        public VMwareCbtUpdateMigrationItemInputTargetDiskTags()
        {

        }
    }
    /// The tags for the target disks.
    public partial interface IVMwareCbtUpdateMigrationItemInputTargetDiskTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The tags for the target disks.
    internal partial interface IVMwareCbtUpdateMigrationItemInputTargetDiskTagsInternal

    {

    }
}