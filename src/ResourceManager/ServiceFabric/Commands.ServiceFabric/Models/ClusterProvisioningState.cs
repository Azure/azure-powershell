
namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public enum ClusterProvisioningState
    {
        Default,

        // ClusterResource intermediate states
        WaitingForNodes,
        Deploying,
        BaselineUpgrade,
        UpdatingUserConfiguration,
        UpdatingUserCertificate,
        UpdatingInfrastructure,
        EnforcingClusterVersion,
        UpgradeServiceUnreachable,
        Deleting,
        ScaleUp,
        ScaleDown,
        AutoScale,

        // Cluster terminal state
        Ready,
        Failed
    }
}
