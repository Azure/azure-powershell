namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The target VM tags.</summary>
    public partial class HyperVReplicaAzureEnableProtectionInputTargetVmtags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IHyperVReplicaAzureEnableProtectionInputTargetVmtags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IHyperVReplicaAzureEnableProtectionInputTargetVmtagsInternal
    {

        /// <summary>
        /// Creates an new <see cref="HyperVReplicaAzureEnableProtectionInputTargetVmtags" /> instance.
        /// </summary>
        public HyperVReplicaAzureEnableProtectionInputTargetVmtags()
        {

        }
    }
    /// The target VM tags.
    public partial interface IHyperVReplicaAzureEnableProtectionInputTargetVmtags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The target VM tags.
    internal partial interface IHyperVReplicaAzureEnableProtectionInputTargetVmtagsInternal

    {

    }
}