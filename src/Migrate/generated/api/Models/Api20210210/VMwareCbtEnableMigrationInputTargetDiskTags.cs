namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The tags for the target disks.</summary>
    public partial class VMwareCbtEnableMigrationInputTargetDiskTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtEnableMigrationInputTargetDiskTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtEnableMigrationInputTargetDiskTagsInternal
    {

        /// <summary>
        /// Creates an new <see cref="VMwareCbtEnableMigrationInputTargetDiskTags" /> instance.
        /// </summary>
        public VMwareCbtEnableMigrationInputTargetDiskTags()
        {

        }
    }
    /// The tags for the target disks.
    public partial interface IVMwareCbtEnableMigrationInputTargetDiskTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The tags for the target disks.
    internal partial interface IVMwareCbtEnableMigrationInputTargetDiskTagsInternal

    {

    }
}