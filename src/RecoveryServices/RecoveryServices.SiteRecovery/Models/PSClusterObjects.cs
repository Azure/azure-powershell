// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Azure Site Recovery Replication Protection Cluster.
    /// </summary>
    public class ASRReplicationProtectionCluster
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRReplicationProtectionCluster" /> class.
        /// </summary>
        public ASRReplicationProtectionCluster()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRReplicationProtectionCluster" /> class with
        ///     required parameters.
        /// </summary>
        /// <param name="cluster">Protection cluster object</param>
        public ASRReplicationProtectionCluster(
            ReplicationProtectionCluster cluster)
        {
            this.ID = cluster.Id;
            this.Name = cluster.Name;
            this.Type = cluster.Type;
            this.ProtectionClusterType = cluster.Properties.ProtectionClusterType;
            this.PrimaryFabricFriendlyName = cluster.Properties.PrimaryFabricFriendlyName;
            this.PrimaryFabricProvider = cluster.Properties.PrimaryFabricProvider;
            this.RecoveryFabricFriendlyName = cluster.Properties.RecoveryFabricFriendlyName;
            this.RecoveryFabricId = cluster.Properties.RecoveryFabricId;
            this.PrimaryProtectionContainerFriendlyName = cluster.Properties.PrimaryProtectionContainerFriendlyName;
            this.RecoveryProtectionContainerFriendlyName = cluster.Properties.RecoveryProtectionContainerFriendlyName;
            this.ProtectionState = cluster.Properties.ProtectionState;
            this.ProtectionStateDescription = cluster.Properties.ProtectionStateDescription;
            this.ActiveLocation = cluster.Properties.ActiveLocation;
            this.TestFailoverState = cluster.Properties.TestFailoverState;
            this.TestFailoverStateDescription = cluster.Properties.TestFailoverStateDescription;
            this.AllowedOperations = cluster.Properties.AllowedOperations;
            this.ReplicationHealth = cluster.Properties.ReplicationHealth;
            if (cluster.Properties.HealthErrors != null)
            {
                this.HealthErrors = cluster.Properties.HealthErrors.ToList().
                        ConvertAll(healthError => new ASRHealthError(healthError));
            }
            this.LastSuccessfulFailoverTime = cluster.Properties.LastSuccessfulFailoverTime;
            this.LastSuccessfulTestFailoverTime = cluster.Properties.LastSuccessfulTestFailoverTime;
            this.PolicyId = cluster.Properties.PolicyId;
            this.PolicyFriendlyName = cluster.Properties.PolicyFriendlyName;
            this.CurrentScenario = cluster.Properties.CurrentScenario;
            this.RecoveryContainerId = cluster.Properties.RecoveryContainerId;
            this.AgentClusterId = cluster.Properties.AgentClusterId;
            this.ClusterFqdn = cluster.Properties.ClusterFqdn;
            this.ClusterNodeFqdns = cluster.Properties.ClusterNodeFqdns;
            this.ClusterProtectedItemIds = cluster.Properties.ClusterProtectedItemIds;
            this.ProvisioningState = cluster.Properties.ProvisioningState;
            this.AreAllClusterNodesRegistered = cluster.Properties.AreAllClusterNodesRegistered;
            this.ClusterRegisteredNodes = cluster.Properties.ClusterRegisteredNodes;

            if(cluster.Properties.ProviderSpecificDetails is A2AReplicationProtectionClusterDetails)
            {
                this.ReplicationProvider = Constants.A2A;
                var details = (A2AReplicationProtectionClusterDetails)cluster.Properties.ProviderSpecificDetails;
                this.ProviderSpecificDetails = new ASRA2AReplicationProtectionClusterDetails
                {
                    MultiVMGroupId = details.MultiVMGroupId,
                    MultiVMGroupName = details.MultiVMGroupName,
                    MultiVMGroupCreateOption = details.MultiVMGroupCreateOption,
                    PrimaryFabricLocation = details.PrimaryFabricLocation,
                    RecoveryFabricLocation = details.RecoveryFabricLocation,
                    FailoverRecoveryPointId = details.FailoverRecoveryPointId,
                    ClusterManagementId = details.ClusterManagementId,
                    RpoInSeconds = details.RpoInSeconds,
                    LastRpoCalculatedTime = details.LastRpoCalculatedTime,
                    InitialPrimaryZone = details.InitialPrimaryZone,
                    InitialPrimaryFabricLocation = details.InitialPrimaryFabricLocation,
                    InitialRecoveryZone = details.InitialRecoveryZone,
                    InitialRecoveryFabricLocation = details.InitialRecoveryFabricLocation,
                    InitialPrimaryExtendedLocation = details.InitialPrimaryExtendedLocation,
                    InitialRecoveryExtendedLocation = details.InitialRecoveryExtendedLocation,
                    PrimaryAvailabilityZone = details.PrimaryAvailabilityZone,
                    RecoveryAvailabilityZone = details.RecoveryAvailabilityZone,
                    PrimaryExtendedLocation = details.PrimaryExtendedLocation,
                    RecoveryExtendedLocation = details.RecoveryExtendedLocation,
                    LifecycleId = details.LifecycleId
                };
            }

            if (cluster.Properties.SharedDiskProperties != null)
            {
                var details = cluster.Properties.SharedDiskProperties;
                this.SharedDiskProperties = new ASRSharedDiskReplicationItemProperties
                {
                    ProtectionState = details.ProtectionState,
                    TestFailoverState = details.TestFailoverState,
                    ActiveLocation = details.ActiveLocation,
                    AllowedOperations = details.AllowedOperations,
                    ReplicationHealth = details.ReplicationHealth,
                    CurrentScenario = details.CurrentScenario
                };

                if (details.HealthErrors != null)
                {
                    this.SharedDiskProperties.HealthErrors = details.HealthErrors.ToList().
                            ConvertAll(healthError => new ASRHealthError(healthError));
                }

                var providerDetails = (A2ASharedDiskReplicationDetails)details.SharedDiskProviderSpecificDetails;
                if (details.SharedDiskProviderSpecificDetails is A2ASharedDiskReplicationDetails)
                {
                    List<ASRAzureToAzureProtectedDiskDetails> protectedManagedDisks = null;
                    List<AsrA2AUnprotectedDiskDetails> unprotectedDisks = null;
                    if (providerDetails.ProtectedManagedDisks != null && providerDetails.ProtectedManagedDisks.Any())
                    {
                        protectedManagedDisks = providerDetails.ProtectedManagedDisks.ToList()
                            .ConvertAll(disk => new ASRAzureToAzureProtectedDiskDetails(disk));
                    }
                    if (providerDetails.UnprotectedDisks != null && providerDetails.UnprotectedDisks.Count > 0)
                    {
                        unprotectedDisks = new List<AsrA2AUnprotectedDiskDetails>();
                        foreach (var unprotectedDisk in providerDetails.UnprotectedDisks)
                        {
                            unprotectedDisks.Add(
                                new AsrA2AUnprotectedDiskDetails
                                {
                                    DiskLunId = unprotectedDisk.DiskLunId ?? -1
                                });
                        }
                    }

                    List<ASRA2ASharedDiskIRErrorDetails> sharedDiskIrErrors = null;
                    if (providerDetails.SharedDiskIrErrors != null)
                    {
                        sharedDiskIrErrors = providerDetails.SharedDiskIrErrors.ToList().
                            ConvertAll(healthError => new ASRA2ASharedDiskIRErrorDetails(healthError));
                    }

                    this.SharedDiskProperties.SharedDiskProviderSpecificDetails = new ASRA2ASharedDiskReplicationDetails
                    {
                        ManagementId = providerDetails.ManagementId,
                        UnprotectedDisks = unprotectedDisks,
                        ProtectedManagedDisks = protectedManagedDisks,
                        PrimaryFabricLocation = providerDetails.PrimaryFabricLocation,
                        RecoveryFabricLocation = providerDetails.RecoveryFabricLocation,
                        FailoverRecoveryPointId = providerDetails.FailoverRecoveryPointId,
                        MonitoringPercentageCompletion = providerDetails.MonitoringPercentageCompletion,
                        MonitoringJobType = providerDetails.MonitoringJobType,
                        RpoInSeconds = providerDetails.RpoInSeconds,
                        LastRpoCalculatedTime = providerDetails.LastRpoCalculatedTime,
                        SharedDiskIrErrors = sharedDiskIrErrors
                    };
                }
            }
        }

        #region Properties

        /// <summary>
        /// Gets or sets the protection cluster Id.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the protection cluster.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Type of the object.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the type of protection cluster type.
        /// </summary>
        public string ProtectionClusterType { get; set; }

        /// <summary>
        /// Gets or sets the friendly name of the primary fabric.
        /// </summary>
        public string PrimaryFabricFriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the fabric provider of the primary fabric.
        /// </summary>
        public string PrimaryFabricProvider { get; set; }

        /// <summary>
        /// Gets or sets the friendly name of recovery fabric.
        /// </summary>
        public string RecoveryFabricFriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the Arm Id of recovery fabric.
        /// </summary>
        public string RecoveryFabricId { get; set; }

        /// <summary>
        /// Gets or sets the name of primary protection container friendly name.
        /// </summary>
        public string PrimaryProtectionContainerFriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the name of recovery container friendly name.
        /// </summary>
        public string RecoveryProtectionContainerFriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the protection status.
        /// </summary>
        public string ProtectionState { get; set; }

        /// <summary>
        /// Gets or sets the protection state description.
        /// </summary>
        public string ProtectionStateDescription { get; set; }

        /// <summary>
        /// Gets or sets the Current active location of the Protection cluster.
        /// </summary>
        public string ActiveLocation { get; set; }

        /// <summary>
        /// Gets or sets the Test failover state.
        /// </summary>
        public string TestFailoverState { get; set; }

        /// <summary>
        /// Gets or sets the Test failover state description.
        /// </summary>
        public string TestFailoverStateDescription { get; set; }

        /// <summary>
        /// Gets or sets the allowed operations on the Replication protection cluster.
        /// </summary>
        public IList<string> AllowedOperations { get; set; }

        /// <summary>
        /// Gets or sets the consolidated protection health for the VM taking any
        /// issues with SRS as well as all the replication units associated with the
        /// VM&#39;s replication group into account. This is a string representation of the
        /// ProtectionHealth enumeration.
        /// </summary>
        public string ReplicationHealth { get; set; }

        /// <summary>
        ///     Gets or sets Replication provider.
        /// </summary>
        public string ReplicationProvider { get; set; }

        /// <summary>
        /// Gets or sets list of health errors.
        /// </summary>
        public IList<ASRHealthError> HealthErrors { get; set; }

        /// <summary>
        /// Gets or sets the last successful failover time.
        /// </summary>
        public System.DateTime? LastSuccessfulFailoverTime { get; set; }

        /// <summary>
        /// Gets or sets the last successful test failover time.
        /// </summary>
        public System.DateTime? LastSuccessfulTestFailoverTime { get; set; }

        /// <summary>
        /// Gets or sets the name of Policy governing this PE.
        /// </summary>
        public string PolicyFriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the current scenario.
        /// </summary>
        public CurrentScenarioDetails CurrentScenario { get; set; }

        /// <summary>
        /// Gets or sets the recovery container Id.
        /// </summary>
        public string RecoveryContainerId { get; set; }

        /// <summary>
        /// Gets or sets the Agent cluster Id.
        /// </summary>
        public string AgentClusterId { get; set; }

        /// <summary>
        /// Gets or sets the cluster FQDN.
        /// </summary>
        public string ClusterFqdn { get; set; }

        /// <summary>
        /// Gets or sets the List of cluster Node FQDNs.
        /// </summary>
        public IList<string> ClusterNodeFqdns { get; set; }

        /// <summary>
        /// Gets or sets the List of Protected Item Id&#39;s.
        /// </summary>
        public IList<string> ClusterProtectedItemIds { get; set; }

        /// <summary>
        /// Gets the provisioning state of the cluster.
        /// </summary>
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether all nodes of the cluster are
        /// registered or not.
        /// </summary>
        public bool? AreAllClusterNodesRegistered { get; set; }

        /// <summary>
        /// Gets or sets the registered node details.
        /// </summary>
        public IList<RegisteredClusterNodes> ClusterRegisteredNodes { get; set; }

        /// <summary>
        /// Gets or sets the Replication cluster provider custom settings.
        /// </summary>
        public ASRReplicationClusterProviderSpecificSettings ProviderSpecificDetails { get; set; }

        /// <summary>
        /// Gets or sets the shared disk properties.
        /// </summary>
        public ASRSharedDiskReplicationItemProperties SharedDiskProperties { get; set; }

        /// <summary>
        /// Gets or sets the Policy Id.
        /// </summary>
        public string PolicyId { get; set; }

        #endregion
    }

    /// <summary>
    ///     ReplicationCluster provider settings
    /// </summary>
    public class ASRReplicationClusterProviderSpecificSettings
    {

    }

    /// <summary>
    ///     A2A ReplicationCluster provider settings
    /// </summary>
    public class ASRA2AReplicationProtectionClusterDetails : ASRReplicationClusterProviderSpecificSettings
    {
        /// <summary>
        /// Gets or sets the multi vm group Id.
        /// </summary>
        public string MultiVMGroupId { get; set; }

        /// <summary>
        /// Gets or sets the multi vm group name.
        /// </summary>
        public string MultiVMGroupName { get; set; }

        /// <summary>
        /// Gets or sets whether Multi VM group is auto created or specified by user. Possible values include: &#39;AutoCreated&#39;, &#39;UserSpecified&#39;
        /// </summary>
        public string MultiVMGroupCreateOption { get; set; }

        /// <summary>
        /// Gets or sets primary fabric location.
        /// </summary>
        public string PrimaryFabricLocation { get; set; }

        /// <summary>
        /// Gets or sets the recovery fabric location.
        /// </summary>
        public string RecoveryFabricLocation { get; set; }

        /// <summary>
        /// Gets or sets the recovery point Id to which the cluster was failed over.
        /// </summary>
        public string FailoverRecoveryPointId { get; set; }

        /// <summary>
        /// Gets or sets the cluster management Id.
        /// </summary>
        public string ClusterManagementId { get; set; }

        /// <summary>
        /// Gets or sets the last RPO value in seconds.
        /// </summary>
        public long? RpoInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the time (in UTC) when the last RPO value was calculated by
        /// Protection Service.
        /// </summary>
        public System.DateTime? LastRpoCalculatedTime { get; set; }

        /// <summary>
        /// Gets or sets the initial primary availability zone.
        /// </summary>
        public string InitialPrimaryZone { get; set; }

        /// <summary>
        /// Gets or sets the initial primary fabric location.
        /// </summary>
        public string InitialPrimaryFabricLocation { get; set; }

        /// <summary>
        /// Gets or sets the initial recovery availability zone.
        /// </summary>
        public string InitialRecoveryZone { get; set; }

        /// <summary>
        /// Gets or sets the initial recovery fabric location.
        /// </summary>
        public string InitialRecoveryFabricLocation { get; set; }

        /// <summary>
        /// Gets or sets the initial primary extended location.
        /// </summary>
        public ExtendedLocation InitialPrimaryExtendedLocation { get; set; }

        /// <summary>
        /// Gets or sets the initial recovery extended location.
        /// </summary>
        public ExtendedLocation InitialRecoveryExtendedLocation { get; set; }

        /// <summary>
        /// Gets or sets the primary availability zone.
        /// </summary>
        public string PrimaryAvailabilityZone { get; set; }

        /// <summary>
        /// Gets or sets the recovery availability zone.
        /// </summary>
        public string RecoveryAvailabilityZone { get; set; }

        /// <summary>
        /// Gets or sets the primary Extended Location.
        /// </summary>
        public ExtendedLocation PrimaryExtendedLocation { get; set; }

        /// <summary>
        /// Gets or sets the recovery Extended Location.
        /// </summary>
        public ExtendedLocation RecoveryExtendedLocation { get; set; }

        /// <summary>
        /// Gets or sets an id that survives actions like switch protection which
        /// change the backing PE/CPE objects internally.The lifecycle id gets carried
        /// forward to have a link/continuity in being able to have an Id that denotes
        /// the &#34;same&#34; protected cluster even though other internal Ids/ARM Id might be
        /// changing.
        /// </summary>
        public string LifecycleId { get; set; }
    }

    /// <summary>
    ///     ReplicationCluster provider settings
    /// </summary>
    public class ASRSharedDiskReplicationItemProperties
    {
        /// <summary>
        /// Gets or sets the protection state of shared disk.
        /// </summary>
        public string ProtectionState { get; set; }

        /// <summary>
        /// Gets or sets the tfo state of shared disk.
        /// </summary>
        public string TestFailoverState { get; set; }

        /// <summary>
        /// Gets or sets the Current active location of the PE.
        /// </summary>
        public string ActiveLocation { get; set; }

        /// <summary>
        /// Gets or sets the allowed operations on the Replication protected item.
        /// </summary>
        public IList<string> AllowedOperations { get; set; }

        /// <summary>
        /// Gets or sets the consolidated protection health for the VM taking any
        /// issues with SRS as well as all the replication units associated with the
        /// VM&#39;s replication group into account. This is a string representation of the
        /// ProtectionHealth enumeration.
        /// </summary>
        public string ReplicationHealth { get; set; }

        /// <summary>
        /// Gets or sets list of health errors.
        /// </summary>
        public IList<ASRHealthError> HealthErrors { get; set; }

        /// <summary>
        /// Gets or sets the current scenario.
        /// </summary>
        public CurrentScenarioDetails CurrentScenario { get; set; }

        /// <summary>
        /// Gets or sets the Replication provider custom settings.
        /// </summary>
        public ASRSharedDiskReplicationProviderSpecificSettings SharedDiskProviderSpecificDetails { get; set; }
    }

    /// <summary>
    ///     Shared disk provider settings
    /// </summary>
    public class ASRSharedDiskReplicationProviderSpecificSettings
    {

    }

    /// <summary>
    ///     A2A Shared disk provider settings
    /// </summary>
    public class ASRA2ASharedDiskReplicationDetails : ASRSharedDiskReplicationProviderSpecificSettings
    {
        /// <summary>
        /// Gets or sets the management Id.
        /// </summary>
        public string ManagementId { get; set; }

        /// <summary>
        /// Gets or sets the list of unprotected disks.
        /// </summary>
        public IList<AsrA2AUnprotectedDiskDetails> UnprotectedDisks { get; set; }

        /// <summary>
        /// Gets or sets the list of protected managed disks.
        /// </summary>
        public IList<ASRAzureToAzureProtectedDiskDetails> ProtectedManagedDisks { get; set; }

        /// <summary>
        /// Gets or sets primary fabric location.
        /// </summary>
        public string PrimaryFabricLocation { get; set; }

        /// <summary>
        /// Gets or sets the recovery fabric location.
        /// </summary>
        public string RecoveryFabricLocation { get; set; }

        /// <summary>
        /// Gets or sets the recovery point id to which the Virtual node was failed
        /// over.
        /// </summary>
        public string FailoverRecoveryPointId { get; set; }

        /// <summary>
        /// Gets or sets the percentage of the monitoring job. The type of the
        /// monitoring job is defined by MonitoringJobType property.
        /// </summary>
        public int? MonitoringPercentageCompletion { get; set; }

        /// <summary>
        /// Gets or sets the type of the monitoring job. The progress is contained in
        /// MonitoringPercentageCompletion property.
        /// </summary>
        public string MonitoringJobType { get; set; }

        /// <summary>
        /// Gets or sets the last RPO value in seconds.
        /// </summary>
        public long? RpoInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the time (in UTC) when the last RPO value was calculated by
        /// Protection Service.
        /// </summary>
        public System.DateTime? LastRpoCalculatedTime { get; set; }

        /// <summary>
        /// Gets or sets the IR Errors.
        /// </summary>
        public IList<ASRA2ASharedDiskIRErrorDetails> SharedDiskIrErrors { get; set; }
    }

    /// <summary>
    ///     A2A Shared disk IR error details
    /// </summary>
    public class ASRA2ASharedDiskIRErrorDetails
    {
        /// <summary>
        ///     Initializes a new instance of the shared disk IR error class.
        /// </summary>
        /// <param name="healthError">Shared disk IR error object.</param>
        public ASRA2ASharedDiskIRErrorDetails(A2ASharedDiskIRErrorDetails healthError)
        {
            this.ErrorCode = healthError.ErrorCode;
            this.ErrorCodeEnum = healthError.ErrorCodeEnum;
            this.ErrorMessage = healthError.ErrorMessage;
            this.PossibleCauses = healthError.PossibleCauses;
            this.RecommendedAction = healthError.RecommendedAction;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets the error code enum.
        /// </summary>
        public string ErrorCodeEnum { get; set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets the possible causes.
        /// </summary>
        public string PossibleCauses { get; set; }

        /// <summary>
        /// Gets the recommended action.
        /// </summary>
        public string RecommendedAction { get; set; }
    }

    /// <summary>
    ///     PS Cluster Recovery Point Class.
    /// </summary>
    public class ASRClusterRecoveryPoint
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRClusterRecoveryPoint" /> class.
        /// </summary>
        public ASRClusterRecoveryPoint()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRClusterRecoveryPoint" /> class.
        /// </summary>
        /// <param name="recoveryPoint">Recovery point object to read values from.</param>
        public ASRClusterRecoveryPoint(
            ClusterRecoveryPoint recoveryPoint)
        {
            this.ID = recoveryPoint.Id;
            this.Name = recoveryPoint.Name;
            this.Type = recoveryPoint.Type;
            this.RecoveryPointTime = recoveryPoint.Properties.RecoveryPointTime;
            this.RecoveryPointType = recoveryPoint.Properties.RecoveryPointType;

            var providerSpecificDetails = recoveryPoint.Properties.ProviderSpecificDetails;
            if (providerSpecificDetails is A2AClusterRecoveryPointDetails)
            {
                var details = providerSpecificDetails as A2AClusterRecoveryPointDetails;
                this.RecoveryPointSyncType = details.RecoveryPointSyncType;
                this.Nodes = details.Nodes;
            }
        }

        /// <summary>
        ///     Gets or sets Recovery Point ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets Name of the Recovery Point.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Point Time.
        /// </summary>
        public DateTime? RecoveryPointTime { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Point Type.
        /// </summary>
        public string RecoveryPointType { get; set; }

        /// <summary>
        ///     Gets or sets type of the Recovery Point.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the recovery point is multi VM
        /// consistent. Possible values include: &#39;MultiVmSyncRecoveryPoint&#39;, &#39;PerVmRecoveryPoint&#39;
        /// </summary>
        public string RecoveryPointSyncType { get; set; }

        /// <summary>
        /// Gets or sets the list of nodes representing the cluster.
        /// </summary>
        public IList<string> Nodes { get; set; }
    }

    /// <summary>
    /// Azure VM protected item details required for AzureToAzure protection.
    /// </summary>
    public class ASRAzureToAzureReplicationProtectedItemConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRAzureToAzureReplicationProtectedItemConfig" /> class.
        /// </summary>
        public ASRAzureToAzureReplicationProtectedItemConfig()
        {
        }

        /// <summary>
        /// Gets or sets the list of vm managed disk details.
        /// </summary>
        public ASRAzuretoAzureDiskReplicationConfig[] AzureToAzureDiskReplicationConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the recovery resource group Id.
        /// </summary>
        public string RecoveryResourceGroupId { get; set; }

        /// <summary>
        /// Gets or sets the recovery availability set.
        /// </summary>
        public string RecoveryAvailabilitySetId { get; set; }

        /// <summary>
        /// Gets or sets the boot diagnostic storage account.
        /// </summary>
        public string RecoveryBootDiagStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the recovery availability zone.
        /// </summary>
        public string RecoveryAvailabilityZone { get; set; }

        /// <summary>
        /// Gets or sets the recovery proximity placement group Id.
        /// </summary>
        public string RecoveryProximityPlacementGroupId { get; set; }

        /// <summary>
        /// Gets or sets the virtual machine scale set id.
        /// </summary>
        public string RecoveryVirtualMachineScaleSetId { get; set; }

        /// <summary>
        /// Gets or sets the recovery capacity reservation group Id.
        /// </summary>
        public string RecoveryCapacityReservationGroupId { get; set; }

        /// <summary>
        /// Gets or sets the Replication Protected item name.
        /// </summary>
        public string ReplicationProtectedItemName { get; set; }

        /// <summary>
        /// Gets or sets DiskEncryptionVaultId.
        /// </summary>
        public string DiskEncryptionVaultId { get; set; }

        /// <summary>
        /// Gets or sets DiskEncryptionSecretUrl.
        /// </summary>
        public string DiskEncryptionSecretUrl { get; set; }

        /// <summary>
        /// Gets or sets KeyEncryptionKeyUrl.
        /// </summary>
        public string KeyEncryptionKeyUrl { get; set; }

        /// <summary>
        /// Gets or sets KeyEncryptionVaultId.
        /// </summary>
        public string KeyEncryptionVaultId { get; set; }
    }
}
