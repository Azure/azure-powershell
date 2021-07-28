namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The target VM tags.</summary>
    public partial class VMwareCbtMigrationDetailsTargetVmtags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtMigrationDetailsTargetVmtags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtMigrationDetailsTargetVmtagsInternal
    {

        /// <summary>Creates an new <see cref="VMwareCbtMigrationDetailsTargetVmtags" /> instance.</summary>
        public VMwareCbtMigrationDetailsTargetVmtags()
        {

        }
    }
    /// The target VM tags.
    public partial interface IVMwareCbtMigrationDetailsTargetVmtags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The target VM tags.
    internal partial interface IVMwareCbtMigrationDetailsTargetVmtagsInternal

    {

    }
}