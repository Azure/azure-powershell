namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The tags for the target NICs.</summary>
    public partial class HyperVReplicaAzureEnableProtectionInputTargetNicTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IHyperVReplicaAzureEnableProtectionInputTargetNicTags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IHyperVReplicaAzureEnableProtectionInputTargetNicTagsInternal
    {

        /// <summary>
        /// Creates an new <see cref="HyperVReplicaAzureEnableProtectionInputTargetNicTags" /> instance.
        /// </summary>
        public HyperVReplicaAzureEnableProtectionInputTargetNicTags()
        {

        }
    }
    /// The tags for the target NICs.
    public partial interface IHyperVReplicaAzureEnableProtectionInputTargetNicTags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The tags for the target NICs.
    internal partial interface IHyperVReplicaAzureEnableProtectionInputTargetNicTagsInternal

    {

    }
}