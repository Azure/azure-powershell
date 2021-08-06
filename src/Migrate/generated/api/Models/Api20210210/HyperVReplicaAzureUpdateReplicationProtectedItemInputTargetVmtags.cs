namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The target VM tags.</summary>
    public partial class HyperVReplicaAzureUpdateReplicationProtectedItemInputTargetVmtags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IHyperVReplicaAzureUpdateReplicationProtectedItemInputTargetVmtags,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IHyperVReplicaAzureUpdateReplicationProtectedItemInputTargetVmtagsInternal
    {

        /// <summary>
        /// Creates an new <see cref="HyperVReplicaAzureUpdateReplicationProtectedItemInputTargetVmtags" /> instance.
        /// </summary>
        public HyperVReplicaAzureUpdateReplicationProtectedItemInputTargetVmtags()
        {

        }
    }
    /// The target VM tags.
    public partial interface IHyperVReplicaAzureUpdateReplicationProtectedItemInputTargetVmtags :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The target VM tags.
    internal partial interface IHyperVReplicaAzureUpdateReplicationProtectedItemInputTargetVmtagsInternal

    {

    }
}