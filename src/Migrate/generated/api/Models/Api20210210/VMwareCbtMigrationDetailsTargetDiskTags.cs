namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The tags for the target disks.</summary>
    public partial class VMwareCbtMigrationDetailsTargetDiskTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtMigrationDetailsTargetDiskTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtMigrationDetailsTargetDiskTagsInternal
    {

        /// <summary>Creates an new <see cref="VMwareCbtMigrationDetailsTargetDiskTags" /> instance.</summary>
        public VMwareCbtMigrationDetailsTargetDiskTags()
        {

        }
    }
    /// The tags for the target disks.
    public partial interface IVMwareCbtMigrationDetailsTargetDiskTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The tags for the target disks.
    internal partial interface IVMwareCbtMigrationDetailsTargetDiskTagsInternal

    {

    }
}