// ----------------------------------------------------------------------------------
// 
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using SRSDataModel = Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models
{
    //
    // Summary:
    //     Replication protected item.
    public class ReplicationProtectedItem_2016_08_10
    {
        public ReplicationProtectedItem_2016_08_10(SRSDataModel.ReplicationProtectedItem replicationProtectedItem)
        {
            this.Id = replicationProtectedItem.Id;
            this.Name = replicationProtectedItem.Name;
            this.Type = replicationProtectedItem.Type;
            this.Location = replicationProtectedItem.Location;
            this.Properties = new ReplicationProtectedItemProperties_2016_08_10(replicationProtectedItem.Properties);
        }
        public ReplicationProtectedItemProperties_2016_08_10 Properties { get; set; }

        //
        // Summary
        //    Get or set the entity id.
        public string Id { get; }

        //
        // Summary
        //    Get or set the entity Name.
        public string Name { get; set; }

        //
        // Summary
        //    Get or set the entity type.
        public string Type { get; set; }

        //
        // Summary
        //    Get or set the entity location.
        public string Location { get; set; }
    }

    //
    // Summary:
    //     Replication protected item custom data details.
    public class ReplicationProtectedItemProperties_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the ReplicationProtectedItemProperties class.
        public ReplicationProtectedItemProperties_2016_08_10(SRSDataModel.ReplicationProtectedItemProperties rpiProperties)
        {
            this.FailoverRecoveryPointId = rpiProperties.FailoverRecoveryPointId;
            this.CurrentScenario = new CurrentScenarioDetails_2016_08_10(rpiProperties.CurrentScenario);
            this.LastSuccessfulTestFailoverTime = rpiProperties.LastSuccessfulTestFailoverTime;
            this.LastSuccessfulFailoverTime = rpiProperties.LastSuccessfulFailoverTime;
            this.PolicyFriendlyName = rpiProperties.PolicyFriendlyName;
            this.PolicyId = rpiProperties.PolicyId;
            this.FailoverHealthErrors = new List<ASRHealthError_2016_08_10>();
            if (rpiProperties.HealthErrors != null)
            {
                foreach (var healthError in rpiProperties.HealthErrors)
                {
                    this.FailoverHealthErrors.Add(new ASRHealthError_2016_08_10(healthError));
                }
            }
            this.ReplicationHealthErrors = new List<ASRHealthError_2016_08_10>();

            if (rpiProperties.HealthErrors != null)
            {
                foreach (var healthError in rpiProperties.HealthErrors)
                {
                    this.ReplicationHealthErrors.Add(new ASRHealthError_2016_08_10(healthError));
                }
            }

            this.FailoverHealth = rpiProperties.FailoverHealth;
            this.ReplicationHealth = rpiProperties.ReplicationHealth;
            this.AllowedOperations = rpiProperties.AllowedOperations;
            this.TestFailoverStateDescription = rpiProperties.TestFailoverStateDescription;
            this.TestFailoverState = rpiProperties.TestFailoverState;
            this.ActiveLocation = rpiProperties.ActiveLocation;
            this.ProtectionStateDescription = rpiProperties.ProtectionStateDescription;
            this.PrimaryProtectionContainerFriendlyName = rpiProperties.PrimaryProtectionContainerFriendlyName;
            this.RecoveryProtectionContainerFriendlyName = rpiProperties.RecoveryProtectionContainerFriendlyName;
            this.RecoveryFabricId = rpiProperties.RecoveryFabricId;
            this.RecoveryFabricFriendlyName = rpiProperties.RecoveryFabricFriendlyName;
            this.RecoveryServicesProviderId = rpiProperties.RecoveryServicesProviderId;
            this.ProtectableItemId = rpiProperties.ProtectableItemId;
            this.ProtectedItemType = rpiProperties.ProtectedItemType;
            this.FriendlyName = rpiProperties.FriendlyName;
            if (rpiProperties.ProviderSpecificDetails is SRSDataModel.HyperVReplicaAzureReplicationDetails)
            {
                this.ProviderSpecificDetails = new HyperVReplicaAzureReplicationDetails_2016_08_10(
                    rpiProperties.ProviderSpecificDetails as SRSDataModel.HyperVReplicaAzureReplicationDetails);
            }
            else if (rpiProperties.ProviderSpecificDetails is SRSDataModel.HyperVReplicaReplicationDetails)
            {
                this.ProviderSpecificDetails = new HyperVReplicaReplicationDetails_2016_08_10(
                    rpiProperties.ProviderSpecificDetails as SRSDataModel.HyperVReplicaReplicationDetails);
            }
            else if (rpiProperties.ProviderSpecificDetails is SRSDataModel.HyperVReplicaBlueReplicationDetails)
            {
                this.ProviderSpecificDetails = new HyperVReplicaBlueReplicationDetails_2016_08_10(
                    rpiProperties.ProviderSpecificDetails as SRSDataModel.HyperVReplicaBlueReplicationDetails);
            }
            else if (rpiProperties.ProviderSpecificDetails is SRSDataModel.InMageAzureV2ReplicationDetails)
            {
                this.ProviderSpecificDetails = new InMageAzureV2ReplicationDetails_2016_08_10(
                    rpiProperties.ProviderSpecificDetails as SRSDataModel.InMageAzureV2ReplicationDetails);
            }
            else if (rpiProperties.ProviderSpecificDetails is SRSDataModel.InMageReplicationDetails)
            {
                this.ProviderSpecificDetails = new InMageReplicationDetails_2016_08_10(
                    rpiProperties.ProviderSpecificDetails as SRSDataModel.InMageReplicationDetails);
            }
            else if (rpiProperties.ProviderSpecificDetails is SRSDataModel.A2AReplicationDetails)
            {
                this.ProviderSpecificDetails = new A2AReplicationDetails_2016_08_10(
                    rpiProperties.ProviderSpecificDetails as SRSDataModel.A2AReplicationDetails);
            }
            this.FailoverRecoveryPointId = rpiProperties.RecoveryContainerId;
        }

        //
        // Summary:
        //     Gets or sets the recovery point ARM Id to which the Vm was failed over.
        public string FailoverRecoveryPointId { get; set; }

        //
        // Summary:
        //     Gets or sets the current scenario.
        public CurrentScenarioDetails_2016_08_10 CurrentScenario { get; set; }

        //
        // Summary:
        //     Gets or sets the Last successful test failover time.
        public DateTime? LastSuccessfulTestFailoverTime { get; set; }
        //
        // Summary:
        //     Gets or sets the Last successful failover time.
        public DateTime? LastSuccessfulFailoverTime { get; set; }

        //
        // Summary:
        //     Gets or sets the name of Policy governing this PE.
        public string PolicyFriendlyName { get; set; }

        //
        // Summary:
        //     Gets or sets the ID of Policy governing this PE.
        public string PolicyId { get; set; }

        //
        // Summary:
        //     Gets or sets list of failover health errors.
        public IList<ASRHealthError_2016_08_10> FailoverHealthErrors { get; set; }

        //
        // Summary:
        //     Gets or sets list of replication health errors.
        public IList<ASRHealthError_2016_08_10> ReplicationHealthErrors { get; set; }

        //
        // Summary:
        //     Gets or sets the consolidated failover health for the VM.
        public string FailoverHealth { get; set; }

        //
        // Summary:
        //     Gets or sets the consolidated protection health for the VM taking any issues
        //     with SRS as well as all the replication units associated with the VM's replication
        //     group into account. This is a string representation of the ProtectionHealth enumeration.
        public string ReplicationHealth { get; set; }

        //
        // Summary:
        //     Gets or sets the allowed operations on the Replication protected item.
        public IList<string> AllowedOperations { get; set; }

        //
        // Summary:
        //     Gets or sets the Test failover state description.
        public string TestFailoverStateDescription { get; set; }

        //
        // Summary:
        //     Gets or sets the Test failover state.
        public string TestFailoverState { get; set; }

        //
        // Summary:
        //     Gets or sets the Current active location of the PE.
        public string ActiveLocation { get; set; }

        //
        // Summary:
        //     Gets or sets the protection state description.
        public string ProtectionStateDescription { get; set; }

        //
        // Summary:
        //     Gets or sets the protection status.
        public string ProtectionState { get; set; }

        //
        // Summary:
        //     Gets or sets the name of recovery container friendly name.
        public string RecoveryProtectionContainerFriendlyName { get; set; }

        //
        // Summary:
        //     Gets or sets the name of primary protection container friendly name.
        public string PrimaryProtectionContainerFriendlyName { get; set; }

        //
        // Summary:
        //     Gets or sets the Arm Id of recovery fabric.
        public string RecoveryFabricId { get; set; }

        //
        // Summary:
        //     Gets or sets the friendly name of recovery fabric.
        public string RecoveryFabricFriendlyName { get; set; }

        //
        // Summary:
        //     Gets or sets the friendly name of the primary fabric.
        public string PrimaryFabricFriendlyName { get; set; }

        //
        // Summary:
        //     Gets or sets the recovery provider ARM Id.
        public string RecoveryServicesProviderId { get; set; }

        //
        // Summary:
        //     Gets or sets the protected item ARM Id.
        public string ProtectableItemId { get; set; }

        //
        // Summary:
        //     Gets or sets the type of protected item type.
        public string ProtectedItemType { get; set; }

        //
        // Summary:
        //     Gets or sets the name.
        public string FriendlyName { get; set; }

        //
        // Summary:
        //     Gets or sets the Replication provider custom settings.
        public ReplicationProviderSpecificSettings_2016_08_10 ProviderSpecificDetails { get; set; }

        //
        // Summary:
        //     Gets or sets the recovery container Id.
        public string RecoveryContainerId { get; set; }
    }

    //
    // Summary:
    //     Current scenario details of the protected entity.
    public class CurrentScenarioDetails_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the CurrentScenarioDetails class.
        public CurrentScenarioDetails_2016_08_10(SRSDataModel.CurrentScenarioDetails currentScenario)
        {
            this.ScenarioName = currentScenario.ScenarioName;
            this.JobId = currentScenario.JobId;
            this.StartTime = currentScenario.StartTime;
        }

        //
        // Summary:
        //     Gets or sets scenario name.
        public string ScenarioName { get; set; }

        //
        // Summary:
        //     Gets or sets ARM Id of the job being executed.
        public string JobId { get; set; }

        //
        // Summary:
        //     Gets or sets start time of the workflow.
        public DateTime? StartTime { get; set; }
    }

    public class ReplicationProviderSpecificSettings_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the ReplicationProviderSpecificSettings class.
        public ReplicationProviderSpecificSettings_2016_08_10()
        {

        }
    }

    //
    // Summary:
    //     A2A provider specific settings.
    public class A2AReplicationDetails_2016_08_10 : ReplicationProviderSpecificSettings_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the A2AReplicationDetails class.
        public A2AReplicationDetails_2016_08_10() { }

        //
        // Summary:
        //     Initializes a new instance of the A2AReplicationDetails class.
        public A2AReplicationDetails_2016_08_10(SRSDataModel.ReplicationProviderSpecificSettings rpSpecificDetails)
        {
            SRSDataModel.A2AReplicationDetails a2aReplicationDetails = rpSpecificDetails as SRSDataModel.A2AReplicationDetails;
            this.TestFailoverRecoveryFabricObjectId = a2aReplicationDetails.TestFailoverRecoveryFabricObjectId;
            this.LifecycleId = a2aReplicationDetails.LifecycleId;
            this.VmProtectionStateDescription = a2aReplicationDetails.VmProtectionStateDescription;
            this.VmProtectionState = a2aReplicationDetails.VmProtectionState;
            this.RecoveryFabricObjectId = a2aReplicationDetails.RecoveryFabricObjectId;
            this.IsReplicationAgentUpdateRequired = a2aReplicationDetails.IsReplicationAgentUpdateRequired;
            this.AgentVersion = a2aReplicationDetails.AgentVersion;
            this.LastHeartbeat = a2aReplicationDetails.LastHeartbeat;
            this.MonitoringJobType = a2aReplicationDetails.MonitoringJobType;
            this.MonitoringPercentageCompletion = a2aReplicationDetails.MonitoringPercentageCompletion;
            if (a2aReplicationDetails.VmNics != null)
            {
                this.VmNics =
                       a2aReplicationDetails.VmNics?.ToList()
                       .ConvertAll(nic => new ASRVMNicDetails_2016_08_10(nic));
            }
            this.SelectedRecoveryAzureNetworkId = a2aReplicationDetails.SelectedRecoveryAzureNetworkId;
            this.RecoveryAvailabilitySet = a2aReplicationDetails.RecoveryAvailabilitySet;
            this.RecoveryCloudService = a2aReplicationDetails.RecoveryCloudService;
            this.RecoveryAzureResourceGroupId = a2aReplicationDetails.RecoveryAzureResourceGroupId;
            this.RecoveryAzureVMName = a2aReplicationDetails.RecoveryAzureVMName;
            this.RecoveryAzureVMSize = a2aReplicationDetails.RecoveryAzureVMSize;
            this.OsType = a2aReplicationDetails.OsType;
            this.RecoveryFabricLocation = a2aReplicationDetails.RecoveryFabricLocation;
            this.PrimaryFabricLocation = a2aReplicationDetails.PrimaryFabricLocation;

            if (a2aReplicationDetails.ProtectedDisks != null)
            {
                this.ProtectedDisks =
                    a2aReplicationDetails.ProtectedDisks.ToList()
                    .ConvertAll(disk => new ASRAzureToAzureProtectedDiskDetails_2016_08_10(disk));
            }

            if (a2aReplicationDetails.ProtectedManagedDisks != null)
            {
                this.ProtectedManagedDisks =
                    a2aReplicationDetails.ProtectedManagedDisks.ToList()
                    .ConvertAll(disk => new ASRAzureToAzureProtectedDiskDetails_2016_08_10(disk));
            }

            if (a2aReplicationDetails.VmSyncedConfigDetails != null)
            {
                this.VmSyncedConfigDetails =
                    new ASRAzureToAzureVmSyncedConfigDetails_2016_08_10(a2aReplicationDetails.VmSyncedConfigDetails);
            }
            this.ManagementId = a2aReplicationDetails.ManagementId;
            this.MultiVmGroupName = a2aReplicationDetails.MultiVmGroupName;
            this.MultiVmGroupId = a2aReplicationDetails.MultiVmGroupId;
            this.FabricObjectId = a2aReplicationDetails.FabricObjectId;
            this.RpoInSeconds = a2aReplicationDetails.RpoInSeconds;
            this.LastRpoCalculatedTime = a2aReplicationDetails.LastRpoCalculatedTime;
        }

        //
        // Summary:
        //     Gets or sets the test failover fabric object Id.
        public string TestFailoverRecoveryFabricObjectId { get; set; }
        //
        // Summary:
        //     Gets or sets an id associated with the PE that survives actions like switch protection
        //     which change the backing PE/CPE objects internally.The lifecycle id gets carried
        //     forward to have a link/continuity in being able to have an Id that denotes the
        //     "same" protected item even though other internal Ids/ARM Id might be changing.
        public string LifecycleId { get; set; }

        //
        // Summary:
        //     Gets or sets the protection state description for the vm.
        public string VmProtectionStateDescription { get; set; }

        //
        // Summary:
        //     Gets or sets the protection state for the vm.
        public string VmProtectionState { get; set; }

        //
        // Summary:
        //     Gets or sets the recovery fabric object Id.
        public string RecoveryFabricObjectId { get; set; }

        //
        // Summary:
        //     Gets or sets a value indicating whether replication agent update is required.
        public bool? IsReplicationAgentUpdateRequired { get; set; }

        //
        // Summary:
        //     Gets or sets the agent version.
        public string AgentVersion { get; set; }

        //
        // Summary:
        //     Gets or sets the last heartbeat received from the source server.
        public DateTime? LastHeartbeat { get; set; }

        //
        // Summary:
        //     Gets or sets the type of the monitoring job. The progress is contained in MonitoringPercentageCompletion
        //     property.
        public string MonitoringJobType { get; set; }

        //
        // Summary:
        //     Gets or sets the percentage of the monitoring job. The type of the monitoring
        //     job is defined by MonitoringJobType property.
        public int? MonitoringPercentageCompletion { get; set; }

        //
        // Summary:
        //     Gets or sets the synced configuration details.
        public ASRAzureToAzureVmSyncedConfigDetails_2016_08_10 VmSyncedConfigDetails { get; set; }
        //
        // Summary:
        //     Gets or sets the virtual machine nic details.
        public IList<ASRVMNicDetails_2016_08_10> VmNics { get; set; }
        //
        // Summary:
        //     Gets or sets the recovery virtual network.
        public string SelectedRecoveryAzureNetworkId { get; set; }

        //
        // Summary:
        //     Gets or sets the recovery availability set.
        public string RecoveryAvailabilitySet { get; set; }

        //
        // Summary:
        //     Gets or sets the recovery cloud service.
        public string RecoveryCloudService { get; set; }

        //
        // Summary:
        //     Gets or sets the recovery resource group.
        public string RecoveryAzureResourceGroupId { get; set; }
        //
        // Summary:
        //     Gets or sets the name of recovery virtual machine.
        public string RecoveryAzureVMName { get; set; }
        //
        // Summary:
        //     Gets or sets the size of recovery virtual machine.
        public string RecoveryAzureVMSize { get; set; }

        //
        // Summary:
        //     Gets or sets the type of operating system.
        public string OsType { get; set; }
        //
        // Summary:
        //     Gets or sets the recovery fabric location.
        public string RecoveryFabricLocation { get; set; }
        //
        // Summary:
        //     Gets or sets primary fabric location.
        public string PrimaryFabricLocation { get; set; }
        //
        // Summary:
        //     Gets or sets the list of protected managed disks.
        public IList<ASRAzureToAzureProtectedDiskDetails_2016_08_10> ProtectedManagedDisks { get; set; }
        //
        // Summary:
        //     Gets or sets the list of protected disks.
        public IList<ASRAzureToAzureProtectedDiskDetails_2016_08_10> ProtectedDisks { get; set; }
        //
        // Summary:
        //     Gets or sets the management Id.
        public string ManagementId { get; set; }
        //
        // Summary:
        //     Gets or sets the multi vm group name.
        public string MultiVmGroupName { get; set; }
        //
        // Summary:
        //     Gets or sets the multi vm group Id.
        public string MultiVmGroupId { get; set; }
        //
        // Summary:
        //     Gets or sets the fabric specific object Id of the virtual machine.
        public string FabricObjectId { get; set; }

        //
        // Summary:
        //     Gets or sets the last RPO value in seconds.
        public long? RpoInSeconds { get; set; }
        //
        // Summary:
        //     Gets or sets the time (in UTC) when the last RPO value was calculated by Protection
        //     Service.
        public DateTime? LastRpoCalculatedTime { get; set; }
    }

    //
    // Summary:
    //     InMageAzureV2 provider specific settings
    public class InMageAzureV2ReplicationDetails_2016_08_10 : ReplicationProviderSpecificSettings_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the InMageAzureV2ReplicationDetails class.
        public InMageAzureV2ReplicationDetails_2016_08_10(SRSDataModel.ReplicationProviderSpecificSettings rpSpecificDetails)
        {
            var inMageAzureV2ReplicationDetails = rpSpecificDetails as SRSDataModel.InMageAzureV2ReplicationDetails;
            this.VhdName = inMageAzureV2ReplicationDetails.VhdName;
            this.OsDiskId = inMageAzureV2ReplicationDetails.OsDiskId;
            if (inMageAzureV2ReplicationDetails.AzureVMDiskDetails != null)
            {
                this.AzureVMDiskDetails = new List<ASRHyperVReplicaAzureVmDiskDetails_2016_08_10>();
                foreach (var diskDetails in inMageAzureV2ReplicationDetails.AzureVMDiskDetails)
                {
                    this.AzureVMDiskDetails.Add(new ASRHyperVReplicaAzureVmDiskDetails_2016_08_10(diskDetails));
                }
            }
            this.RecoveryAzureVMName = inMageAzureV2ReplicationDetails.RecoveryAzureVMName;
            this.RecoveryAzureVMSize = inMageAzureV2ReplicationDetails.RecoveryAzureVMSize;
            this.RecoveryAzureStorageAccount = inMageAzureV2ReplicationDetails.RecoveryAzureStorageAccount;
            this.RecoveryAzureLogStorageAccountId = inMageAzureV2ReplicationDetails.RecoveryAzureLogStorageAccountId;
            if (inMageAzureV2ReplicationDetails.VmNics != null)
            {
                this.VmNics =
                       inMageAzureV2ReplicationDetails.VmNics?.ToList()
                       .ConvertAll(nic => new ASRVMNicDetails_2016_08_10(nic));
            }
            this.SelectedRecoveryAzureNetworkId = inMageAzureV2ReplicationDetails.SelectedRecoveryAzureNetworkId;
            this.DiscoveryType = inMageAzureV2ReplicationDetails.DiscoveryType;
            this.EnableRDPOnTargetOption = inMageAzureV2ReplicationDetails.EnableRdpOnTargetOption;
            this.Datastores = inMageAzureV2ReplicationDetails.Datastores;
            this.TargetVmId = inMageAzureV2ReplicationDetails.TargetVmId;
            this.RecoveryAzureResourceGroupId = inMageAzureV2ReplicationDetails.RecoveryAzureResourceGroupId;
            this.RecoveryAvailabilitySetId = inMageAzureV2ReplicationDetails.RecoveryAvailabilitySetId;
            this.UseManagedDisks = inMageAzureV2ReplicationDetails.UseManagedDisks;
            this.LicenseType = inMageAzureV2ReplicationDetails.LicenseType;
            if (inMageAzureV2ReplicationDetails.ValidationErrors != null)
            {
                this.ValidationErrors = new List<ASRHealthError_2016_08_10>();
                foreach (var healthError in inMageAzureV2ReplicationDetails.ValidationErrors)
                {
                    this.ValidationErrors.Add(new ASRHealthError_2016_08_10(healthError));
                }
            }

            this.LastRpoCalculatedTime = inMageAzureV2ReplicationDetails.LastRpoCalculatedTime;
            this.LastUpdateReceivedTime = inMageAzureV2ReplicationDetails.LastUpdateReceivedTime;
            this.OsType = inMageAzureV2ReplicationDetails.OsType;
            this.SourceVmRAMSizeInMB = inMageAzureV2ReplicationDetails.SourceVmRamSizeInMB;
            this.SourceVmCPUCount = inMageAzureV2ReplicationDetails.SourceVmCpuCount;
            this.MasterTargetId = inMageAzureV2ReplicationDetails.MasterTargetId;
            this.InfrastructureVmId = inMageAzureV2ReplicationDetails.InfrastructureVmId;
            this.VCenterInfrastructureId = inMageAzureV2ReplicationDetails.VCenterInfrastructureId;
            this.ProtectionStage = inMageAzureV2ReplicationDetails.ProtectionStage;
            this.VmId = inMageAzureV2ReplicationDetails.VmId;
            this.VmProtectionState = inMageAzureV2ReplicationDetails.VmProtectionState;
            this.VmProtectionStateDescription = inMageAzureV2ReplicationDetails.VmProtectionStateDescription;
            this.ResyncProgressPercentage = inMageAzureV2ReplicationDetails.ResyncProgressPercentage;
            this.RpoInSeconds = inMageAzureV2ReplicationDetails.RpoInSeconds;
            this.CompressedDataRateInMB = inMageAzureV2ReplicationDetails.CompressedDataRateInMB;

            this.UncompressedDataRateInMB = inMageAzureV2ReplicationDetails.UncompressedDataRateInMB;
            this.IpAddress = inMageAzureV2ReplicationDetails.IpAddress;
            this.AgentVersion = inMageAzureV2ReplicationDetails.AgentVersion;
            this.IsAgentUpdateRequired = inMageAzureV2ReplicationDetails.IsAgentUpdateRequired;
            this.IsRebootAfterUpdateRequired = inMageAzureV2ReplicationDetails.IsRebootAfterUpdateRequired;
            this.LastHeartbeat = inMageAzureV2ReplicationDetails.LastHeartbeat;
            this.ProcessServerId = inMageAzureV2ReplicationDetails.ProcessServerId;
            this.MultiVmGroupId = inMageAzureV2ReplicationDetails.MultiVmGroupId;
            this.MultiVmGroupName = inMageAzureV2ReplicationDetails.MultiVmGroupName;
            this.MultiVmSyncStatus = inMageAzureV2ReplicationDetails.MultiVmSyncStatus;
            if (inMageAzureV2ReplicationDetails.ProtectedDisks != null)
            {
                this.ProtectedDisks = new List<InMageAzureV2ProtectedDiskDetails_2016_08_10>();
                foreach (var diskDetails in inMageAzureV2ReplicationDetails.ProtectedDisks)
                {
                    this.ProtectedDisks.Add(new InMageAzureV2ProtectedDiskDetails_2016_08_10(diskDetails));
                }
            }
            this.DiskResized = inMageAzureV2ReplicationDetails.DiskResized;
            this.ReplicaId = inMageAzureV2ReplicationDetails.ReplicaId;
            this.OsVersion = inMageAzureV2ReplicationDetails.OsVersion;
        }

        //
        // Summary:
        //     Gets or sets the OS disk VHD name.
        public string VhdName { get; set; }
        //
        // Summary:
        //     Gets or sets the id of the disk containing the OS.
        public string OsDiskId { get; set; }
        //
        // Summary:
        //     Gets or sets azure VM Disk details.
        public IList<ASRHyperVReplicaAzureVmDiskDetails_2016_08_10> AzureVMDiskDetails { get; set; }
        //
        // Summary:
        //     Gets or sets recovery Azure given name.
        public string RecoveryAzureVMName { get; set; }
        //
        // Summary:
        //     Gets or sets the Recovery Azure VM size.
        public string RecoveryAzureVMSize { get; set; }
        //
        // Summary:
        //     Gets or sets the recovery Azure storage account.
        public string RecoveryAzureStorageAccount { get; set; }
        //
        // Summary:
        //     Gets or sets the ARM id of the log storage account used for replication. This
        //     will be set to null if no log storage account was provided during enable protection.
        public string RecoveryAzureLogStorageAccountId { get; set; }
        //
        // Summary:
        //     Gets or sets the PE Network details.
        public IList<ASRVMNicDetails_2016_08_10> VmNics { get; set; }
        //
        // Summary:
        //     Gets or sets the selected recovery azure network Id.
        public string SelectedRecoveryAzureNetworkId { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating the discovery type of the machine. Value can
        //     be vCenter or physical.
        public string DiscoveryType { get; set; }
        //
        // Summary:
        //     Gets or sets the selected option to enable RDP\SSH on target vm after failover.
        //     String value of {SrsDataContract.EnableRDPOnTargetOption} enum.
        public string EnableRDPOnTargetOption { get; set; }
        //
        // Summary:
        //     Gets or sets the datastores of the on-premise machine. Value can be list of strings
        //     that contain datastore names.
        public IList<string> Datastores { get; set; }
        //
        // Summary:
        //     Gets or sets the ARM Id of the target Azure VM. This value will be null until
        //     the VM is failed over. Only after failure it will be populated with the ARM Id
        //     of the Azure VM.
        public string TargetVmId { get; set; }
        //
        // Summary:
        //     Gets or sets the target resource group Id.
        public string RecoveryAzureResourceGroupId { get; set; }
        //
        // Summary:
        //     Gets or sets the recovery availability set Id.
        public string RecoveryAvailabilitySetId { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether managed disks should be used during failover.
        public string UseManagedDisks { get; set; }
        //
        // Summary:
        //     Gets or sets license Type of the VM to be used.
        public string LicenseType { get; set; }
        //
        // Summary:
        //     Gets or sets the validation errors of the on-premise machine Value can be list
        //     of validation errors.
        public IList<ASRHealthError_2016_08_10> ValidationErrors { get; set; }
        //
        // Summary:
        //     Gets or sets the last RPO calculated time.
        public DateTime? LastRpoCalculatedTime { get; set; }
        //
        // Summary:
        //     Gets or sets the last update time received from on-prem components.
        public DateTime? LastUpdateReceivedTime { get; set; }
        //
        // Summary:
        //     Gets or sets the type of the OS on the VM.
        public string OsType { get; set; }
        //
        // Summary:
        //     Gets or sets the RAM size of the VM on the primary side.
        public int? SourceVmRAMSizeInMB { get; set; }
        //
        // Summary:
        //     Gets or sets the CPU count of the VM on the primary side.
        public int? SourceVmCPUCount { get; set; }
        //
        // Summary:
        //     Gets or sets the master target Id.
        public string MasterTargetId { get; set; }
        //
        // Summary:
        //     Gets or sets the infrastructure VM Id.
        public string InfrastructureVmId { get; set; }
        //
        // Summary:
        //     Gets or sets the vCenter infrastructure Id.
        public string VCenterInfrastructureId { get; set; }
        //
        // Summary:
        //     Gets or sets the protection stage.
        public string ProtectionStage { get; set; }
        //
        // Summary:
        //     Gets or sets the virtual machine Id.
        public string VmId { get; set; }
        //
        // Summary:
        //     Gets or sets the protection state for the vm.
        public string VmProtectionState { get; set; }
        //
        // Summary:
        //     Gets or sets the protection state description for the vm.
        public string VmProtectionStateDescription { get; set; }
        //
        // Summary:
        //     Gets or sets the resync progress percentage.
        public int? ResyncProgressPercentage { get; set; }
        //
        // Summary:
        //     Gets or sets the RPO in seconds.
        public long? RpoInSeconds { get; set; }
        //
        // Summary:
        //     Gets or sets the compressed data change rate in MB.
        public double? CompressedDataRateInMB { get; set; }
        //
        // Summary:
        //     Gets or sets the uncompressed data change rate in MB.
        public double? UncompressedDataRateInMB { get; set; }
        //
        // Summary:
        //     Gets or sets the source IP address.
        public string IpAddress { get; set; }
        //
        // Summary:
        //     Gets or sets the agent version.
        public string AgentVersion { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether installed agent needs to be updated.
        public string IsAgentUpdateRequired { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether the source server requires a restart
        //     after update.
        public string IsRebootAfterUpdateRequired { get; set; }
        //
        // Summary:
        //     Gets or sets the last heartbeat received from the source server.
        public DateTime? LastHeartbeat { get; set; }
        //
        // Summary:
        //     Gets or sets the process server Id.
        public string ProcessServerId { get; set; }
        //
        // Summary:
        //     Gets or sets the multi vm group Id.
        public string MultiVmGroupId { get; set; }
        //
        // Summary:
        //     Gets or sets the multi vm group name.
        public string MultiVmGroupName { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether multi vm sync is enabled or disabled.
        public string MultiVmSyncStatus { get; set; }
        //
        // Summary:
        //     Gets or sets the list of protected disks.
        public IList<InMageAzureV2ProtectedDiskDetails_2016_08_10> ProtectedDisks { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether any disk is resized for this VM.
        public string DiskResized { get; set; }
        //
        // Summary:
        //     Gets or sets the replica id of the protected item.
        public string ReplicaId { get; set; }
        //
        // Summary:
        //     Gets or sets the OS Version of the protected item.
        public string OsVersion { get; set; }
    }

    public class HyperVReplicaAzureReplicationDetails_2016_08_10 : ReplicationProviderSpecificSettings_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the HyperVReplicaAzureReplicationDetails class.
        public HyperVReplicaAzureReplicationDetails_2016_08_10(SRSDataModel.HyperVReplicaAzureReplicationDetails hyperVReplicaAzureReplicationDetails)
        {
            this.RecoveryAvailabilitySetId = hyperVReplicaAzureReplicationDetails.RecoveryAvailabilitySetId;
            this.RecoveryAzureResourceGroupId = hyperVReplicaAzureReplicationDetails.RecoveryAzureResourceGroupId;
            this.EnableRDPOnTargetOption = hyperVReplicaAzureReplicationDetails.EnableRdpOnTargetOption;
            this.SourceVmCPUCount = hyperVReplicaAzureReplicationDetails.SourceVmCpuCount;
            this.SourceVmRAMSizeInMB = hyperVReplicaAzureReplicationDetails.SourceVmRamSizeInMB;
            this.OSDetails = new ASRHyperVReplicaAzureOsDetails_2016_08_10(hyperVReplicaAzureReplicationDetails.OSDetails);
            this.Encryption = hyperVReplicaAzureReplicationDetails.Encryption;
            this.SelectedRecoveryAzureNetworkId = hyperVReplicaAzureReplicationDetails.SelectedRecoveryAzureNetworkId;
            if (hyperVReplicaAzureReplicationDetails.VmNics != null)
            {
                this.VmNics =
                       hyperVReplicaAzureReplicationDetails.VmNics?.ToList()
                       .ConvertAll(nic => new ASRVMNicDetails_2016_08_10(nic));
            }
            this.InitialReplicationDetails = new InitialReplicationDetails_2016_08_10(hyperVReplicaAzureReplicationDetails.InitialReplicationDetails);
            this.VmProtectionStateDescription = hyperVReplicaAzureReplicationDetails.VmProtectionStateDescription;
            this.VmProtectionState = hyperVReplicaAzureReplicationDetails.VmProtectionState;
            this.VmId = hyperVReplicaAzureReplicationDetails.VmId;
            this.LastReplicatedTime = hyperVReplicaAzureReplicationDetails.LastReplicatedTime;
            this.RecoveryAzureLogStorageAccountId = hyperVReplicaAzureReplicationDetails.RecoveryAzureLogStorageAccountId;
            this.RecoveryAzureResourceGroupId = hyperVReplicaAzureReplicationDetails.RecoveryAzureStorageAccount;
            this.RecoveryAzureVMSize = hyperVReplicaAzureReplicationDetails.RecoveryAzureVMSize;
            this.RecoveryAzureVMName = hyperVReplicaAzureReplicationDetails.RecoveryAzureVmName;
            if (hyperVReplicaAzureReplicationDetails.AzureVmDiskDetails != null)
            {
                this.AzureVMDiskDetails = new List<ASRHyperVReplicaAzureVmDiskDetails_2016_08_10>();
                foreach (var diskDetails in hyperVReplicaAzureReplicationDetails.AzureVmDiskDetails)
                {
                    this.AzureVMDiskDetails.Add(new ASRHyperVReplicaAzureVmDiskDetails_2016_08_10(diskDetails));
                }
            }
            this.UseManagedDisks = hyperVReplicaAzureReplicationDetails.UseManagedDisks;
            this.LicenseType = hyperVReplicaAzureReplicationDetails.LicenseType;
        }

        //
        // Summary:
        //     Gets or sets the recovery availability set Id.
        public string RecoveryAvailabilitySetId { get; set; }
        //
        // Summary:
        //     Gets or sets the target resource group Id.
        public string RecoveryAzureResourceGroupId { get; set; }
        //
        // Summary:
        //     Gets or sets the selected option to enable RDP\SSH on target vm after failover.
        //     String value of {SrsDataContract.EnableRDPOnTargetOption} enum.
        public string EnableRDPOnTargetOption { get; set; }
        //
        // Summary:
        //     Gets or sets the CPU count of the VM on the primary side.
        public int? SourceVmCPUCount { get; set; }
        //
        // Summary:
        //     Gets or sets the RAM size of the VM on the primary side.
        public int? SourceVmRAMSizeInMB { get; set; }
        //
        // Summary:
        //     Gets or sets the operating system info.
        public ASRHyperVReplicaAzureOsDetails_2016_08_10 OSDetails { get; set; }
        //
        // Summary:
        //     Gets or sets the encryption info.
        public string Encryption { get; set; }
        //
        // Summary:
        //     Gets or sets the selected recovery azure network Id.
        public string SelectedRecoveryAzureNetworkId { get; set; }
        //
        // Summary:
        //     Gets or sets the PE Network details.
        public IList<ASRVMNicDetails_2016_08_10> VmNics { get; set; }
        //
        // Summary:
        //     Gets or sets initial replication details.
        public InitialReplicationDetails_2016_08_10 InitialReplicationDetails { get; set; }
        //
        // Summary:
        //     Gets or sets the protection state description for the vm.
        public string VmProtectionStateDescription { get; set; }
        //
        // Summary:
        //     Gets or sets the protection state for the vm.
        public string VmProtectionState { get; set; }
        //
        // Summary:
        //     Gets or sets the virtual machine Id.
        public string VmId { get; set; }
        //
        // Summary:
        //     Gets or sets the Last replication time.
        public DateTime? LastReplicatedTime { get; set; }
        //
        // Summary:
        //     Gets or sets the ARM id of the log storage account used for replication. This
        //     will be set to null if no log storage account was provided during enable protection.
        public string RecoveryAzureLogStorageAccountId { get; set; }
        //
        // Summary:
        //     Gets or sets the recovery Azure storage account.
        public string RecoveryAzureStorageAccount { get; set; }
        //
        // Summary:
        //     Gets or sets the Recovery Azure VM size.
        public string RecoveryAzureVMSize { get; set; }
        //
        // Summary:
        //     Gets or sets recovery Azure given name.
        public string RecoveryAzureVMName { get; set; }
        //
        // Summary:
        //     Gets or sets azure VM Disk details.
        public IList<ASRHyperVReplicaAzureVmDiskDetails_2016_08_10> AzureVMDiskDetails { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether managed disks should be used during failover.
        public string UseManagedDisks { get; set; }
        //
        // Summary:
        //     Gets or sets license Type of the VM to be used.
        public string LicenseType { get; set; }
    }

    //
    // Summary:
    //     Initial replication details.
    public class InitialReplicationDetails_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the InitialReplicationDetails class.
        public InitialReplicationDetails_2016_08_10(SRSDataModel.InitialReplicationDetails initialReplicationDetails)
        {
            this.InitialReplicationProgressPercentage = initialReplicationDetails.InitialReplicationProgressPercentage;
            this.InitialReplicationType = initialReplicationDetails.InitialReplicationType;
        }

        //
        // Summary:
        //     Gets or sets initial replication type.
        public string InitialReplicationType { get; set; }

        //
        // Summary:
        //     Gets or sets the initial replication progress percentage.
        public string InitialReplicationProgressPercentage { get; set; }
    }

    //
    // Summary:
    //     HyperV replica 2012 replication details.
    public class HyperVReplicaReplicationDetails_2016_08_10 : ReplicationProviderSpecificSettings_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the HyperVReplicaReplicationDetails class.
        public HyperVReplicaReplicationDetails_2016_08_10(SRSDataModel.HyperVReplicaReplicationDetails hyperVReplicaReplicationDetails)
        {
            this.LastReplicatedTime = hyperVReplicaReplicationDetails.LastReplicatedTime;
            if (hyperVReplicaReplicationDetails.VmNics != null)
            {
                this.VmNics =
                       hyperVReplicaReplicationDetails.VmNics?.ToList()
                       .ConvertAll(nic => new ASRVMNicDetails_2016_08_10(nic));
            }
            this.VmId = hyperVReplicaReplicationDetails.VmId;
            this.VmProtectionState = hyperVReplicaReplicationDetails.VmProtectionState;
            this.VmProtectionStateDescription = hyperVReplicaReplicationDetails.VmProtectionStateDescription;
            this.InitialReplicationDetails = new InitialReplicationDetails_2016_08_10(hyperVReplicaReplicationDetails.InitialReplicationDetails);

            if (hyperVReplicaReplicationDetails.VMDiskDetails != null)
            {
                this.VMDiskDetails = hyperVReplicaReplicationDetails.VMDiskDetails.ToList().ConvertAll(
                    (VMDiskDetails) => new ASRHyperVReplicaDiskDetails_2016_08_10(VMDiskDetails));
            }
        }

        //
        // Summary:
        //     Gets or sets the Last replication time.
        public DateTime? LastReplicatedTime { get; set; }
        //
        // Summary:
        //     Gets or sets the PE Network details.
        public IList<ASRVMNicDetails_2016_08_10> VmNics { get; set; }
        //
        // Summary:
        //     Gets or sets the virtual machine Id.
        public string VmId { get; set; }
        //
        // Summary:
        //     Gets or sets the protection state for the vm.
        public string VmProtectionState { get; set; }
        //
        // Summary:
        //     Gets or sets the protection state description for the vm.
        public string VmProtectionStateDescription { get; set; }
        //
        // Summary:
        //     Gets or sets initial replication details.
        public InitialReplicationDetails_2016_08_10 InitialReplicationDetails { get; set; }
        //
        // Summary:
        //     Gets or sets VM disk details.
        public IList<ASRHyperVReplicaDiskDetails_2016_08_10> VMDiskDetails { get; set; }
    }


    //
    // Summary:
    //     HyperV replica 2012 R2 (Blue) replication details.
    public class HyperVReplicaBlueReplicationDetails_2016_08_10 : ReplicationProviderSpecificSettings_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the HyperVReplicaBlueReplicationDetails class.
        public HyperVReplicaBlueReplicationDetails_2016_08_10(SRSDataModel.HyperVReplicaBlueReplicationDetails hyperVReplicaBlueReplicationDetails)
        {
            this.LastReplicatedTime = hyperVReplicaBlueReplicationDetails.LastReplicatedTime;
            if (hyperVReplicaBlueReplicationDetails.VmNics != null)
            {
                this.VmNics =
                       hyperVReplicaBlueReplicationDetails.VmNics?.ToList()
                       .ConvertAll(nic => new ASRVMNicDetails_2016_08_10(nic));
            }
            this.VmId = hyperVReplicaBlueReplicationDetails.VmId;
            this.VmProtectionState = hyperVReplicaBlueReplicationDetails.VmProtectionState;
            this.VmProtectionStateDescription = hyperVReplicaBlueReplicationDetails.VmProtectionStateDescription;
            this.InitialReplicationDetails = new InitialReplicationDetails_2016_08_10(hyperVReplicaBlueReplicationDetails.InitialReplicationDetails);

            if (hyperVReplicaBlueReplicationDetails.VMDiskDetails != null)
            {
                this.VMDiskDetails = hyperVReplicaBlueReplicationDetails.VMDiskDetails.ToList().ConvertAll(
                    (VMDiskDetails) => new ASRHyperVReplicaDiskDetails_2016_08_10(VMDiskDetails));
            }
        }

        //
        // Summary:
        //     Gets or sets the Last replication time.
        public DateTime? LastReplicatedTime { get; set; }
        //
        // Summary:
        //     Gets or sets the PE Network details.
        public IList<ASRVMNicDetails_2016_08_10> VmNics { get; set; }
        //
        // Summary:
        //     Gets or sets the virtual machine Id.
        public string VmId { get; set; }
        //
        // Summary:
        //     Gets or sets the protection state for the vm.
        public string VmProtectionState { get; set; }
        //
        // Summary:
        //     Gets or sets the protection state description for the vm.
        public string VmProtectionStateDescription { get; set; }
        //
        // Summary:
        //     Gets or sets initial replication details.
        public InitialReplicationDetails_2016_08_10 InitialReplicationDetails { get; set; }
        //
        // Summary:
        //     Gets or sets VM disk details.
        public IList<ASRHyperVReplicaDiskDetails_2016_08_10> VMDiskDetails { get; set; }
    }


    //
    // Summary:
    //     InMage provider specific settings
    public class InMageReplicationDetails_2016_08_10 : ReplicationProviderSpecificSettings_2016_08_10
    {

        //
        // Summary:
        //     Initializes a new instance of the InMageReplicationDetails class.
        public InMageReplicationDetails_2016_08_10(SRSDataModel.InMageReplicationDetails inMageREplicationDetails)
        {
            this.DiskResized = inMageREplicationDetails.DiskResized;
            this.RebootAfterUpdateStatus = inMageREplicationDetails.RebootAfterUpdateStatus;
            this.MultiVmGroupId = inMageREplicationDetails.MultiVmGroupId;
            this.MultiVmGroupName = inMageREplicationDetails.MultiVmGroupName;
            this.MultiVmSyncStatus = inMageREplicationDetails.MultiVmSyncStatus;
            this.AgentDetails = new InMageAgentDetails_2016_08_10(inMageREplicationDetails.AgentDetails);
            this.VCenterInfrastructureId = inMageREplicationDetails.VCenterInfrastructureId;
            this.InfrastructureVmId = inMageREplicationDetails.InfrastructureVmId;
            if (inMageREplicationDetails.VmNics != null)
            {
                this.VmNics =
                       inMageREplicationDetails.VmNics?.ToList()
                       .ConvertAll(nic => new ASRVMNicDetails_2016_08_10(nic));
            }
            this.DiscoveryType = inMageREplicationDetails.DiscoveryType;
            this.AzureStorageAccountId = inMageREplicationDetails.AzureStorageAccountId;
            this.Datastores = inMageREplicationDetails.Datastores;
            if (inMageREplicationDetails.ValidationErrors != null)
            {
                this.ValidationErrors = inMageREplicationDetails.ValidationErrors.ToList().ConvertAll(
                    (healthError) => new ASRHealthError_2016_08_10(healthError));
            }
            this.LastRpoCalculatedTime = inMageREplicationDetails.LastRpoCalculatedTime;
            this.LastUpdateReceivedTime = inMageREplicationDetails.LastUpdateReceivedTime;
            this.ConsistencyPoints = inMageREplicationDetails.ConsistencyPoints;
            this.MasterTargetId = inMageREplicationDetails.MasterTargetId;
            this.ProcessServerId = inMageREplicationDetails.ProcessServerId;
            this.LastHeartbeat = inMageREplicationDetails.LastHeartbeat;
            this.ActiveSiteType = inMageREplicationDetails.ActiveSiteType;
            this.SourceVmCPUCount = inMageREplicationDetails.SourceVmCpuCount;
            this.SourceVmRAMSizeInMB = inMageREplicationDetails.SourceVmRamSizeInMB;
            this.OsDetails = new OSDiskDetails_2016_08_10(inMageREplicationDetails.OsDetails);
            this.ProtectionStage = inMageREplicationDetails.ProtectionStage;
            this.VmId = inMageREplicationDetails.VmId;
            this.VmProtectionState = inMageREplicationDetails.VmProtectionState;
            this.ReplicaId = inMageREplicationDetails.ReplicaId;
            this.VmProtectionStateDescription = inMageREplicationDetails.VmProtectionStateDescription;
            this.RetentionWindowStart = inMageREplicationDetails.RetentionWindowStart;
            this.RetentionWindowEnd = inMageREplicationDetails.RetentionWindowEnd;
            this.CompressedDataRateInMB = inMageREplicationDetails.CompressedDataRateInMB;
            this.UncompressedDataRateInMB = inMageREplicationDetails.UncompressedDataRateInMB;
            this.RpoInSeconds = inMageREplicationDetails.RpoInSeconds;
            if (inMageREplicationDetails.ProtectedDisks != null)
            {
                this.ProtectedDisks = inMageREplicationDetails.ProtectedDisks.ToList().ConvertAll((protectedDisk) => new InMageProtectedDiskDetails_2016_08_10(protectedDisk));
            }

            this.IpAddress = inMageREplicationDetails.IpAddress;
            this.ResyncDetails = new InitialReplicationDetails_2016_08_10(inMageREplicationDetails.ResyncDetails);

            this.OsVersion = inMageREplicationDetails.OsVersion;
        }

        //
        // Summary:
        //     Gets or sets a value indicating whether any disk is resized for this VM.

        public string DiskResized { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether the source server requires a restart
        //     after update.
        public string RebootAfterUpdateStatus { get; set; }
        //
        // Summary:
        //     Gets or sets the multi vm group Id, if any.
        public string MultiVmGroupId { get; set; }
        //
        // Summary:
        //     Gets or sets the multi vm group name, if any.
        public string MultiVmGroupName { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether the multi vm sync is enabled or disabled.
        public string MultiVmSyncStatus { get; set; }
        //
        // Summary:
        //     Gets or sets the agent details.
        public InMageAgentDetails_2016_08_10 AgentDetails { get; set; }
        //
        // Summary:
        //     Gets or sets the vCenter infrastructure Id.
        public string VCenterInfrastructureId { get; set; }
        //
        // Summary:
        //     Gets or sets the infrastructure VM Id.
        public string InfrastructureVmId { get; set; }
        //
        // Summary:
        //     Gets or sets the PE Network details.
        public IList<ASRVMNicDetails_2016_08_10> VmNics { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating the discovery type of the machine.
        public string DiscoveryType { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating the underlying Azure storage account. If the
        //     VM is not running in Azure, this value shall be set to null.
        public string AzureStorageAccountId { get; set; }
        //
        // Summary:
        //     Gets or sets the datastores of the on-premise machine Value can be list of strings
        //     that contain datastore names
        public IList<string> Datastores { get; set; }
        //
        // Summary:
        //     Gets or sets the validation errors of the on-premise machine Value can be list
        //     of validation errors
        public IList<ASRHealthError_2016_08_10> ValidationErrors { get; set; }
        //
        // Summary:
        //     Gets or sets the last RPO calculated time.
        public DateTime? LastRpoCalculatedTime { get; set; }
        //
        // Summary:
        //     Gets or sets the last update time received from on-prem components.
        public DateTime? LastUpdateReceivedTime { get; set; }
        //
        // Summary:
        //     Gets or sets the collection of Consistency points.
        public IDictionary<string, DateTime?> ConsistencyPoints { get; set; }
        //
        // Summary:
        //     Gets or sets the master target Id.
        public string MasterTargetId { get; set; }
        //
        // Summary:
        //     Gets or sets the process server Id.
        public string ProcessServerId { get; set; }
        //
        // Summary:
        //     Gets or sets the last heartbeat received from the source server.
        public DateTime? LastHeartbeat { get; set; }
        //
        // Summary:
        //     Gets or sets the active location of the VM. If the VM is being protected from
        //     Azure, this field will take values from { Azure, OnPrem }. If the VM is being
        //     protected between two data-centers, this field will be OnPrem always.
        public string ActiveSiteType { get; set; }
        //
        // Summary:
        //     Gets or sets the CPU count of the VM on the primary side.
        public int? SourceVmCPUCount { get; set; }
        //
        // Summary:
        //     Gets or sets the RAM size of the VM on the primary side.
        public int? SourceVmRAMSizeInMB { get; set; }
        //
        // Summary:
        //     Gets or sets the OS details.
        public OSDiskDetails_2016_08_10 OsDetails { get; set; }
        //
        // Summary:
        //     Gets or sets the protection stage.
        public string ProtectionStage { get; set; }
        //
        // Summary:
        //     Gets or sets the virtual machine Id.
        public string VmId { get; set; }
        //
        // Summary:
        //     Gets or sets the protection state for the vm.
        public string VmProtectionState { get; set; }
        //
        // Summary:
        //     Gets or sets the replica id of the protected item.
        public string ReplicaId { get; set; }
        //
        // Summary:
        //     Gets or sets the protection state description for the vm.
        public string VmProtectionStateDescription { get; set; }
        //
        // Summary:
        //     Gets or sets the retention window start time.
        public DateTime? RetentionWindowStart { get; set; }
        //
        // Summary:
        //     Gets or sets the retention window end time.
        public DateTime? RetentionWindowEnd { get; set; }
        //
        // Summary:
        //     Gets or sets the compressed data change rate in MB.
        public double? CompressedDataRateInMB { get; set; }
        //
        // Summary:
        //     Gets or sets the uncompressed data change rate in MB.
        public double? UncompressedDataRateInMB { get; set; }
        //
        // Summary:
        //     Gets or sets the RPO in seconds.
        public long? RpoInSeconds { get; set; }
        //
        // Summary:
        //     Gets or sets the list of protected disks.
        public IList<InMageProtectedDiskDetails_2016_08_10> ProtectedDisks { get; set; }
        //
        // Summary:
        //     Gets or sets the source IP address.
        public string IpAddress { get; set; }
        //
        // Summary:
        //     Gets or sets the resync details of the machine
        public InitialReplicationDetails_2016_08_10 ResyncDetails { get; set; }
        //
        // Summary:
        //     Gets or sets the OS Version of the protected item.
        public string OsVersion { get; set; }
    }

    //
    // Summary:
    //     InMage protected disk details.
    public class InMageProtectedDiskDetails_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the InMageProtectedDiskDetails class.
        public InMageProtectedDiskDetails_2016_08_10(SRSDataModel.InMageProtectedDiskDetails inMageProtectedDiskDetails)
        {
            this.TargetDataInMB = inMageProtectedDiskDetails.TargetDataInMB;
            this.PsDataInMB = inMageProtectedDiskDetails.PsDataInMB;
            this.SourceDataInMB = inMageProtectedDiskDetails.SourceDataInMB;
            this.FileSystemCapacityInBytes = inMageProtectedDiskDetails.FileSystemCapacityInBytes;
            this.DiskCapacityInBytes = inMageProtectedDiskDetails.DiskCapacityInBytes;
            this.ResyncDurationInSeconds = inMageProtectedDiskDetails.ResyncDurationInSeconds;
            this.ResyncProgressPercentage = inMageProtectedDiskDetails.ResyncProgressPercentage;
            this.ResyncRequired = inMageProtectedDiskDetails.ResyncRequired;
            this.RpoInSeconds = inMageProtectedDiskDetails.RpoInSeconds;
            this.HealthErrorCode = inMageProtectedDiskDetails.HealthErrorCode;
            this.ProtectionStage = inMageProtectedDiskDetails.ProtectionStage;
            this.DiskName = inMageProtectedDiskDetails.DiskName;
            this.DiskId = inMageProtectedDiskDetails.DiskId;
            this.DiskResized = inMageProtectedDiskDetails.DiskResized;
            this.LastRpoCalculatedTime = inMageProtectedDiskDetails.LastRpoCalculatedTime;
        }

        //
        // Summary:
        //     Gets or sets the target data transit in MB.

        public double? TargetDataInMB { get; set; }
        //
        // Summary:
        //     Gets or sets the PS data transit in MB.

        public double? PsDataInMB { get; set; }
        //
        // Summary:
        //     Gets or sets the source data transit in MB.

        public double? SourceDataInMB { get; set; }
        //
        // Summary:
        //     Gets or sets the file system capacity in bytes.

        public long? FileSystemCapacityInBytes { get; set; }
        //
        // Summary:
        //     Gets or sets the disk capacity in bytes.

        public long? DiskCapacityInBytes { get; set; }
        //
        // Summary:
        //     Gets or sets the resync duration in seconds.

        public long? ResyncDurationInSeconds { get; set; }
        //
        // Summary:
        //     Gets or sets the resync progress percentage.

        public int? ResyncProgressPercentage { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether resync is required for this disk.

        public string ResyncRequired { get; set; }
        //
        // Summary:
        //     Gets or sets the RPO in seconds.

        public long? RpoInSeconds { get; set; }
        //
        // Summary:
        //     Gets or sets the health error code for the disk.

        public string HealthErrorCode { get; set; }
        //
        // Summary:
        //     Gets or sets the protection stage.

        public string ProtectionStage { get; set; }
        //
        // Summary:
        //     Gets or sets the disk name.

        public string DiskName { get; set; }
        //
        // Summary:
        //     Gets or sets the disk id.

        public string DiskId { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether disk is resized.

        public string DiskResized { get; set; }
        //
        // Summary:
        //     Gets or sets the last RPO calculated time.

        public DateTime? LastRpoCalculatedTime { get; set; }
    }
    //
    // Summary:
    //     The details of the InMage agent.
    public class InMageAgentDetails_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the InMageAgentDetails class.
        public InMageAgentDetails_2016_08_10(SRSDataModel.InMageAgentDetails agentDetails)
        {
            this.AgentUpdateStatus = agentDetails.AgentUpdateStatus;
            this.AgentVersion = agentDetails.AgentVersion;
            this.PostUpdateRebootStatus = agentDetails.PostUpdateRebootStatus;
        }

        //
        // Summary:
        //     Gets or sets the agent version.
        public string AgentVersion { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether installed agent needs to be updated.
        public string AgentUpdateStatus { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether reboot is required after update is applied.
        public string PostUpdateRebootStatus { get; set; }
    }

    //
    // Summary:
    //     Details of the OS Disk.
    public class OSDiskDetails_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the OSDiskDetails class.
        public OSDiskDetails_2016_08_10(SRSDataModel.OSDiskDetails osDiskDetails)
        {
            this.OsType = osDiskDetails.OsType;
            this.OsVhdId = osDiskDetails.OsVhdId;
            this.VhdName = osDiskDetails.VhdName;
        }
        //
        // Summary:
        //     Gets or sets the id of the disk containing the OS.
        public string OsVhdId { get; set; }
        //
        // Summary:
        //     Gets or sets the type of the OS on the VM.
        public string OsType { get; set; }
        //
        // Summary:
        //     Gets or sets the OS disk VHD name.
        public string VhdName { get; set; }
    }
    //
    // Summary:
    //     InMageAzureV2 protected disk details.
    public class InMageAzureV2ProtectedDiskDetails_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the InMageAzureV2ProtectedDiskDetails class.
        public InMageAzureV2ProtectedDiskDetails_2016_08_10(SRSDataModel.InMageAzureV2ProtectedDiskDetails inMageAzureV2ProtectedDiskDetails)
        {
            this.TargetDataInMegaBytes = inMageAzureV2ProtectedDiskDetails.TargetDataInMegaBytes;
            this.PsDataInMegaBytes = inMageAzureV2ProtectedDiskDetails.PsDataInMegaBytes;
            this.SourceDataInMegaBytes = inMageAzureV2ProtectedDiskDetails.SourceDataInMegaBytes;
            this.FileSystemCapacityInBytes = inMageAzureV2ProtectedDiskDetails.FileSystemCapacityInBytes;
            this.DiskCapacityInBytes = inMageAzureV2ProtectedDiskDetails.DiskCapacityInBytes;
            this.ResyncDurationInSeconds = inMageAzureV2ProtectedDiskDetails.ResyncDurationInSeconds;
            this.ResyncProgressPercentage = inMageAzureV2ProtectedDiskDetails.ResyncProgressPercentage;
            this.ResyncRequired = inMageAzureV2ProtectedDiskDetails.ResyncRequired;
            this.RpoInSeconds = inMageAzureV2ProtectedDiskDetails.RpoInSeconds;
            this.HealthErrorCode = inMageAzureV2ProtectedDiskDetails.HealthErrorCode;
            this.ProtectionStage = inMageAzureV2ProtectedDiskDetails.ProtectionStage;
            this.DiskName = inMageAzureV2ProtectedDiskDetails.DiskName;
            this.DiskId = inMageAzureV2ProtectedDiskDetails.DiskId;
            this.DiskResized = inMageAzureV2ProtectedDiskDetails.DiskResized;
            this.LastRpoCalculatedTime = inMageAzureV2ProtectedDiskDetails.LastRpoCalculatedTime;
        }
        //
        // Summary:
        //     Gets or sets the target data transit in MB.
        public double? TargetDataInMegaBytes { get; set; }
        //
        // Summary:
        //     Gets or sets the PS data transit in MB.
        public double? PsDataInMegaBytes { get; set; }
        //
        // Summary:
        //     Gets or sets the source data transit in MB.
        public double? SourceDataInMegaBytes { get; set; }
        //
        // Summary:
        //     Gets or sets the disk file system capacity in bytes.
        public long? FileSystemCapacityInBytes { get; set; }
        //
        // Summary:
        //     Gets or sets the disk capacity in bytes.
        public long? DiskCapacityInBytes { get; set; }
        //
        // Summary:
        //     Gets or sets the resync duration in seconds.
        public long? ResyncDurationInSeconds { get; set; }
        //
        // Summary:
        //     Gets or sets the resync progress percentage.
        public int? ResyncProgressPercentage { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether resync is required for this disk.
        public string ResyncRequired { get; set; }
        //
        // Summary:
        //     Gets or sets the RPO in seconds.
        public long? RpoInSeconds { get; set; }
        //
        // Summary:
        //     Gets or sets the health error code for the disk.
        public string HealthErrorCode { get; set; }
        //
        // Summary:
        //     Gets or sets the protection stage.
        public string ProtectionStage { get; set; }
        //
        // Summary:
        //     Gets or sets the disk name.
        public string DiskName { get; set; }
        //
        // Summary:
        //     Gets or sets the disk id.
        public string DiskId { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether disk is resized.
        public string DiskResized { get; set; }
        //
        // Summary:
        //     Gets or sets the last RPO calculated time.
        public DateTime? LastRpoCalculatedTime { get; set; }
    }
}
