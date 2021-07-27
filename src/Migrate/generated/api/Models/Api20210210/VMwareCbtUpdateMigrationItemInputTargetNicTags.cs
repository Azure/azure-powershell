namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The tags for the target NICs.</summary>
    public partial class VMwareCbtUpdateMigrationItemInputTargetNicTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtUpdateMigrationItemInputTargetNicTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtUpdateMigrationItemInputTargetNicTagsInternal
    {

        /// <summary>
        /// Creates an new <see cref="VMwareCbtUpdateMigrationItemInputTargetNicTags" /> instance.
        /// </summary>
        public VMwareCbtUpdateMigrationItemInputTargetNicTags()
        {

        }
    }
    /// The tags for the target NICs.
    public partial interface IVMwareCbtUpdateMigrationItemInputTargetNicTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The tags for the target NICs.
    internal partial interface IVMwareCbtUpdateMigrationItemInputTargetNicTagsInternal

    {

    }
}