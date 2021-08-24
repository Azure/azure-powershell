namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The target VM tags.</summary>
    public partial class VMwareCbtEnableMigrationInputTargetVmtags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtEnableMigrationInputTargetVmtags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtEnableMigrationInputTargetVmtagsInternal
    {

        /// <summary>
        /// Creates an new <see cref="VMwareCbtEnableMigrationInputTargetVmtags" /> instance.
        /// </summary>
        public VMwareCbtEnableMigrationInputTargetVmtags()
        {

        }
    }
    /// The target VM tags.
    public partial interface IVMwareCbtEnableMigrationInputTargetVmtags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The target VM tags.
    internal partial interface IVMwareCbtEnableMigrationInputTargetVmtagsInternal

    {

    }
}