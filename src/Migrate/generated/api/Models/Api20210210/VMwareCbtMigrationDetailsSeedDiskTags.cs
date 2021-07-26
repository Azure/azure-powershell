namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The tags for the seed disks.</summary>
    public partial class VMwareCbtMigrationDetailsSeedDiskTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtMigrationDetailsSeedDiskTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtMigrationDetailsSeedDiskTagsInternal
    {

        /// <summary>Creates an new <see cref="VMwareCbtMigrationDetailsSeedDiskTags" /> instance.</summary>
        public VMwareCbtMigrationDetailsSeedDiskTags()
        {

        }
    }
    /// The tags for the seed disks.
    public partial interface IVMwareCbtMigrationDetailsSeedDiskTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The tags for the seed disks.
    internal partial interface IVMwareCbtMigrationDetailsSeedDiskTagsInternal

    {

    }
}