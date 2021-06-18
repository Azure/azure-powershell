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
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Fabric Specific Details for VMWare.
    /// </summary>
    public class ASRVMWareSpecificDetails : ASRFabricSpecificDetails
    {
        /// <summary>
        ///     Gets or sets the agent Version.
        /// </summary>
        public string AgentVersion { get; set; }

        /// <summary>
        ///     Gets or sets the CS service status.
        /// </summary>
        public string CsServiceStatus { get; set; }

        /// <summary>
        ///     Gets or sets the host name.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        ///     Gets or sets the IP address.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        ///     Gets or sets the last heartbeat received from CS server.
        /// </summary>
        public DateTime? LastHeartbeat { get; set; }

        /// <summary>
        ///     Gets or sets List of Master Target Servers.
        /// </summary>
        public List<ASRMasterTargetServer> MasterTargetServers { get; set; }

        /// <summary>
        ///     Gets or sets List of Process Servers.
        /// </summary>
        public List<ASRProcessServer> ProcessServers { get; set; }

        /// <summary>
        ///     Gets or sets the number of protected servers.
        /// </summary>
        public string ProtectedServers { get; set; }

        /// <summary>
        ///     Gets or sets List of RunAsAccounts.
        /// </summary>
        public List<ASRRunAsAccount> RunAsAccounts { get; set; }

        /// <summary>
        ///     Gets or sets the version status.
        /// </summary>
        public string VersionStatus { get; set; }
    }

    /// <summary>
    ///     Fabric Specific Details for Azure.
    /// </summary>
    public class ASRAzureFabricSpecificDetails : ASRFabricSpecificDetails
    {
        /// <summary>
        ///     Gets or sets the fabric location.
        /// </summary>
        public string Location { get; set; }
    }

    /// <summary>
    ///     Fabric specific details for InMageRcm.
    /// </summary>
    public class ASRInMageRcmFabricSpecificDetails : ASRFabricSpecificDetails
    {
        /// <summary>
        ///     Gets or sets the ARM Id of the VMware site.
        /// </summary>
        public string VmwareSiteId { get; set; }

        /// <summary>
        ///     Gets or sets the ARM Id of the physical site.
        /// </summary>
        public string PhysicalSiteId { get; set; }

        /// <summary>
        ///     Gets or sets the service endpoint.
        /// </summary>
        public string ServiceEndpoint { get; set; }

        /// <summary>
        ///     Gets or sets the service resource Id.
        /// </summary>
        public string ServiceResourceId { get; set; }

        /// <summary>
        ///     Gets or sets the service container Id.
        /// </summary>
        public string ServiceContainerId { get; set; }

        /// <summary>
        ///     Gets or sets the data plane Uri.
        /// </summary>
        public string DataPlaneUri { get; set; }

        /// <summary>
        ///     Gets or sets the control plane Uri.
        /// </summary>
        public string ControlPlaneUri { get; set; }

        /// <summary>
        ///     Gets or sets the list of process servers.
        /// </summary>
        public List<ASRProcessServerDetails> ProcessServers { get; set; }

        /// <summary>
        ///     Gets or sets the list of RCM proxies.
        /// </summary>
        public List<ASRRcmProxyDetails> RcmProxies { get; set; }

        /// <summary>
        ///     Gets or sets the list of push installers.
        /// </summary>
        public List<ASRPushInstallerDetails> PushInstallers { get; set; }

        /// <summary>
        ///     Gets or sets the list of replication agents.
        /// </summary>
        public List<ASRReplicationAgentDetails> ReplicationAgents { get; set; }

        /// <summary>
        ///     Gets or sets the list of reprotect agents.
        /// </summary>
        public List<ASRReprotectAgentDetails> ReprotectAgents { get; set; }

        /// <summary>
        ///     Gets or sets the list of Mars agents.
        /// </summary>
        public List<ASRMarsAgentDetails> MarsAgents { get; set; }

        /// <summary>
        ///     Gets or sets the list of DRAs.
        /// </summary>
        public List<ASRDraDetails> Dras { get; set; }

        /// <summary>
        ///     Gets or sets the list of agent details.
        /// </summary>
        public List<ASRAgentDetails> AgentDetails { get; set; }
    }

    /// <summary>
    ///     Details of the Process Server.
    /// </summary>
    public class ASRProcessServer
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRProcessServer" /> class.
        /// </summary>
        public ASRProcessServer(ProcessServer processServer)
        {
            this.FriendlyName = processServer.FriendlyName;
            this.Id = processServer.Id;
            this.AgentVersion = processServer.AgentVersion;
            this.IpAddress = processServer.IpAddress;
            this.LastHeartbeat = processServer.LastHeartbeat;
            this.OsType = processServer.OsType;
            this.VersionStatus = processServer.VersionStatus;
            this.AvailableMemoryInBytes = processServer.AvailableMemoryInBytes;
            this.AvailableSpaceInBytes = processServer.AvailableSpaceInBytes;
            this.CpuLoad = processServer.CpuLoad;
            this.CpuLoadStatus = processServer.CpuLoadStatus;
            this.HostId = processServer.HostId;
            this.MemoryUsageStatus = processServer.MemoryUsageStatus;
            this.PsServiceStatus = processServer.PsServiceStatus;
            this.ReplicationPairCount = processServer.ReplicationPairCount;
            this.ServerCount = processServer.MachineCount;
            this.SpaceUsageStatus = processServer.SpaceUsageStatus;
            this.SystemLoad = processServer.SystemLoad;
            this.SystemLoadStatus = processServer.SystemLoadStatus;
            this.TotalMemoryInBytes = processServer.TotalMemoryInBytes;
            this.TotalSpaceInBytes = processServer.TotalSpaceInBytes;
            this.Health = processServer.Health;
            this.PSStatsRefreshTime = processServer.PsStatsRefreshTime;
            this.ThroughputUploadPendingDataInBytes = processServer.ThroughputUploadPendingDataInBytes;
            this.ThroughputInMBps = processServer.ThroughputInMBps;
            this.ThroughputInBytes = processServer.ThroughputInBytes;
            this.ThroughputStatus = processServer.ThroughputStatus;
            this.MarsCommunicationStatus = processServer.MarsCommunicationStatus;
            this.MarsRegistrationStatus = processServer.MarsRegistrationStatus;
            this.Updates =
                this.TranslateMobilityServiceUpdate(processServer.MobilityServiceUpdates);
        }

        /// <summary>
        ///     Gets or sets the version of the scout component on the server.
        /// </summary>
        public string AgentVersion { get; set; }

        /// <summary>
        ///     Gets or sets the available memory.
        /// </summary>
        public long? AvailableMemoryInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the available space.
        /// </summary>
        public long? AvailableSpaceInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the percentage of the CPU load.
        /// </summary>
        public string CpuLoad { get; set; }

        /// <summary>
        ///     Gets or sets the CPU load status.
        /// </summary>
        public string CpuLoadStatus { get; set; }

        /// <summary>
        ///     Gets or sets the Process Server's friendly name.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets the agent generated Id.
        /// </summary>
        public string HostId { get; set; }

        /// <summary>
        ///     Gets or sets the Process Server Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the IP address of the server.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        ///     Gets or sets the last heartbeat received from the server.
        /// </summary>
        public DateTime? LastHeartbeat { get; set; }

        /// <summary>
        ///     Gets or sets the memory usage status.
        /// </summary>
        public string MemoryUsageStatus { get; set; }

        /// <summary>
        ///     Gets or sets the OS type of the server.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        ///     Gets or sets the PS service status.
        /// </summary>
        public string PsServiceStatus { get; set; }

        /// <summary>
        ///     Gets or sets the number of replication pairs configured in this PS.
        /// </summary>
        public string ReplicationPairCount { get; set; }

        /// <summary>
        ///     Gets or sets the servers configured with this PS.
        /// </summary>
        public string ServerCount { get; set; }

        /// <summary>
        ///     Gets or sets the space usage status.
        /// </summary>
        public string SpaceUsageStatus { get; set; }

        /// <summary>
        ///     Gets or sets the percentage of the system load.
        /// </summary>
        public string SystemLoad { get; set; }

        /// <summary>
        ///     Gets or sets the system load status.
        /// </summary>
        public string SystemLoadStatus { get; set; }

        /// <summary>
        ///     Gets or sets the total memory.
        /// </summary>
        public long? TotalMemoryInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the total space.
        /// </summary>
        public long? TotalSpaceInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the list of the mobility service updates available on the
        ///     Process Server.
        /// </summary>
        public IList<ASRMobilityServiceUpdate> Updates { get; set; }

        /// <summary>
        ///     Gets or sets version status
        /// </summary>
        public string VersionStatus { get; set; }

        /// <summary>
        ///     Gets or sets the health of Process Server.
        /// </summary>
        public string Health { get; set; }

        /// <summary>
        ///     Gets or sets the process server stats refresh time.
        /// </summary>
        public DateTime? PSStatsRefreshTime { get; set; }

        /// <summary>
        ///     Gets or sets the uploading pending data in bytes.
        /// </summary>
        public long? ThroughputUploadPendingDataInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the throughput in MBps.
        /// </summary>
        public long? ThroughputInMBps { get; set; }

        /// <summary>
        ///     Gets or sets the throughput in bytes.
        /// </summary>
        public long? ThroughputInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the throughput status.
        /// </summary>
        public string ThroughputStatus { get; set; }

        /// <summary>
        ///     Gets or sets the MARS communication status.
        /// </summary>
        public string MarsCommunicationStatus { get; set; }

        /// <summary>
        ///     Gets or sets the MARS registration status.
        /// </summary>
        public string MarsRegistrationStatus { get; set; }

        /// <summary>
        ///     Translate Mobility updates into Powershell object.
        /// </summary>
        /// <param name="mobilityUpdates">List of Mobility service update object.</param>
        /// <returns>List of Powershell mobility service objects.</returns>
        private IList<ASRMobilityServiceUpdate> TranslateMobilityServiceUpdate(
            IList<MobilityServiceUpdate> mobilityUpdates)
        {
            IList<ASRMobilityServiceUpdate> updates = new List<ASRMobilityServiceUpdate>();
            foreach (var update in mobilityUpdates)
            {
                updates.Add(new ASRMobilityServiceUpdate(update));
            }

            return updates;
        }
    }

    /// <summary>
    ///     The Mobility Service update details.
    /// </summary>
    public class ASRMobilityServiceUpdate
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRMobilityServiceUpdate" /> class.
        /// </summary>
        /// <param name="mobilityServiceUpdateDetails">Mobility service update object.</param>
        public ASRMobilityServiceUpdate(MobilityServiceUpdate mobilityServiceUpdateDetails)
        {
            this.RebootStatus = mobilityServiceUpdateDetails.RebootStatus;
            this.OsType = mobilityServiceUpdateDetails.OsType;
            this.Version = mobilityServiceUpdateDetails.Version;
        }

        /// <summary>
        ///     Gets or sets the OS type.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        ///     Gets or sets the reboot status of the update - whether it is required or not.
        /// </summary>
        public string RebootStatus { get; set; }

        /// <summary>
        ///     Gets or sets the version of the latest update.
        /// </summary>
        public string Version { get; set; }
    }

    /// <summary>
    ///     The retention details of the MT.
    /// </summary>
    public class ASRRetentionVolume
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRRetentionVolume" /> class.
        /// </summary>
        /// <param name="retention">Retention object.</param>
        public ASRRetentionVolume(RetentionVolume retention)
        {
            this.CapacityInBytes = retention.CapacityInBytes;
            this.FreeSpaceInBytes = retention.FreeSpaceInBytes;
            this.ThresholdPercentage = retention.ThresholdPercentage;
            this.VolumeName = retention.VolumeName;
        }

        /// <summary>
        ///     Gets or sets the volume capacity.
        /// </summary>
        public long? CapacityInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the free space available in this volume.
        /// </summary>
        public long? FreeSpaceInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the threshold percentage.
        /// </summary>
        public int? ThresholdPercentage { get; set; }

        /// <summary>
        ///     Gets or sets the volume name.
        /// </summary>
        public string VolumeName { get; set; }
    }

    /// <summary>
    ///     The Datastore details of the MT.
    /// </summary>
    public class ASRDataStore
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRDataStore" /> class.
        /// </summary>
        /// <param name="datastore">Datastore object.</param>
        public ASRDataStore(DataStore datastore)
        {
            this.SymbolicName = datastore.SymbolicName;
            this.Uuid = datastore.Uuid;
            this.Capacity = datastore.Capacity;
            this.FreeSpace = datastore.FreeSpace;
        }

        /// <summary>
        ///     Gets or sets the capacity of data store in GBs.
        /// </summary>
        public string Capacity { get; set; }

        /// <summary>
        ///     Gets or sets the free space of data store in GBs.
        /// </summary>
        public string FreeSpace { get; set; }

        /// <summary>
        ///     Gets or sets the symbolic name of data store.
        /// </summary>
        public string SymbolicName { get; set; }

        /// <summary>
        ///     Gets or sets the uuid of data store.
        /// </summary>
        public string Uuid { get; set; }
    }

    /// <summary>
    ///     Details of a Master Target Server.
    /// </summary>
    public class ASRMasterTargetServer
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRMasterTargetServer" /> class.
        /// </summary>
        public ASRMasterTargetServer(MasterTargetServer masterTargetDetails)
        {
            this.AgentVersion = masterTargetDetails.AgentVersion;
            this.Id = masterTargetDetails.Id;
            this.IpAddress = masterTargetDetails.IpAddress;
            this.LastHeartbeat = masterTargetDetails.LastHeartbeat;
            this.Name = masterTargetDetails.Name;
            this.OsType = masterTargetDetails.OsType;
            this.VersionStatus = masterTargetDetails.VersionStatus;
            this.RetentionVolumes =
                this.TranslateRetentionVolume(masterTargetDetails.RetentionVolumes);
            this.DataStores = this.TranslateDatastores(masterTargetDetails.DataStores);
        }

        /// <summary>
        ///     Gets or sets the version of the scout component on the server.
        /// </summary>
        public string AgentVersion { get; set; }

        /// <summary>
        ///     Gets or sets the list of data stores in the fabric.
        /// </summary>
        public IList<ASRDataStore> DataStores { get; set; }

        /// <summary>
        ///     Gets or sets the server Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the IP address of the server.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        ///     Gets or sets the last heartbeat received from the server.
        /// </summary>
        public DateTime? LastHeartbeat { get; set; }

        /// <summary>
        ///     Gets or sets the server name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the OS type of the server.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        ///     Gets or sets the retention volumes of Master target Server.
        /// </summary>
        public IList<ASRRetentionVolume> RetentionVolumes { get; set; }

        /// <summary>
        ///     Gets or sets version status
        /// </summary>
        public string VersionStatus { get; set; }

        /// <summary>
        ///     Translate retention object to Powershell object.
        /// </summary>
        /// <param name="volumes">Rest API Retention volume object.</param>
        /// <returns></returns>
        private IList<ASRRetentionVolume> TranslateRetentionVolume(IList<RetentionVolume> volumes)
        {
            IList<ASRRetentionVolume> retentionVolumes = new List<ASRRetentionVolume>();
            foreach (var volume in volumes)
            {
                retentionVolumes.Add(new ASRRetentionVolume(volume));
            }

            return retentionVolumes;
        }

        /// <summary>
        ///     Translate Datastore object to Powershell object.
        /// </summary>
        /// <param name="datastores">Rest API Datastore object.</param>
        /// <returns></returns>
        private IList<ASRDataStore> TranslateDatastores(IList<DataStore> datastores)
        {
            IList<ASRDataStore> asrDatastores = new List<ASRDataStore>();
            foreach (var datastore in datastores)
            {
                asrDatastores.Add(new ASRDataStore(datastore));
            }

            return asrDatastores;
        }
    }

    /// <summary>
    ///     Process server details.
    /// </summary>
    public class ASRProcessServerDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRProcessServerDetails" /> class.
        /// </summary>
        public ASRProcessServerDetails(ProcessServerDetails psDetails)
        {
            this.Id = psDetails.Id;
            this.Name = psDetails.Name;
            this.Version = psDetails.Version;
            this.FabricObjectId = psDetails.FabricObjectId;
            this.BiosId = psDetails.BiosId;
            this.Fqdn = psDetails.Fqdn;
            this.LastHeartbeatUtc = psDetails.LastHeartbeatUtc;
            this.TotalMemoryInBytes = psDetails.TotalMemoryInBytes;
            this.AvailableMemoryInBytes = psDetails.AvailableMemoryInBytes;
            this.UsedMemoryInBytes = psDetails.UsedMemoryInBytes;
            this.MemoryUsagePercentage = psDetails.MemoryUsagePercentage;
            this.TotalSpaceInBytes = psDetails.TotalSpaceInBytes;
            this.AvailableSpaceInBytes = psDetails.AvailableSpaceInBytes;
            this.UsedSpaceInBytes = psDetails.UsedSpaceInBytes;
            this.FreeSpacePercentage = psDetails.FreeSpacePercentage;
            this.ThroughputUploadPendingDataInBytes = psDetails.ThroughputUploadPendingDataInBytes;
            this.ThroughputInBytes = psDetails.ThroughputInBytes;
            this.ProcessorUsagePercentage = psDetails.ProcessorUsagePercentage;
            this.ProcessorUsageStatus = psDetails.ProcessorUsageStatus;
            this.MemoryUsageStatus = psDetails.MemoryUsageStatus;
            this.DiskUsageStatus = psDetails.DiskUsageStatus;
            this.SystemLoadStatus = psDetails.SystemLoadStatus;
            this.SystemLoad = psDetails.SystemLoad;
            this.ThroughputStatus = psDetails.ThroughputStatus;
            this.Health = psDetails.Health;
            this.HistoricHealth = psDetails.HistoricHealth;
            this.HealthErrors = psDetails.HealthErrors;
        }

        /// <summary>
        ///     Gets or sets the process server Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the process server name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the fabric object Id.
        /// </summary>
        public string FabricObjectId { get; set; }

        /// <summary>
        ///     Gets or sets the process server bios Id.
        /// </summary>
        public string BiosId { get; set; }

        /// <summary>
        ///     Gets or sets the process server fqdn.
        /// </summary>
        public string Fqdn { get; set; }

        /// <summary>
        ///     Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///     Gets or sets the last heartbeat received from the process server.
        /// </summary>
        public DateTime? LastHeartbeatUtc { get; set; }

        /// <summary>
        ///     Gets or sets the total memory.
        /// </summary>
        public long? TotalMemoryInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the available memory.
        /// </summary>
        public long? AvailableMemoryInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the used memory.
        /// </summary>
        public long? UsedMemoryInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the memory usage percentage.
        /// </summary>
        public double? MemoryUsagePercentage { get; set; }

        /// <summary>
        ///     Gets or sets the total disk space.
        /// </summary>
        public long? TotalSpaceInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the available disk space.
        /// </summary>
        public long? AvailableSpaceInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the used disk space.
        /// </summary>
        public long? UsedSpaceInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the free disk space percentage.
        /// </summary>
        public double? FreeSpacePercentage { get; set; }

        /// <summary>
        ///     Gets or sets the uploading pending data in bytes.
        /// </summary>
        public long? ThroughputUploadPendingDataInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the throughput in bytes.
        /// </summary>
        public long? ThroughputInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the processor usage percentage.
        /// </summary>
        public double? ProcessorUsagePercentage { get; set; }

        /// <summary>
        ///     Gets or sets the processor usage status.
        ///     Possible values include: 'Normal', 'Warning', 'Error', 'Unknown'
        /// </summary>
        public string ProcessorUsageStatus { get; set; }

        /// <summary>
        ///     Gets or sets the memory usage status.
        ///     Possible values include: 'Normal', 'Warning', 'Error', 'Unknown'
        /// </summary>
        public string MemoryUsageStatus { get; set; }

        /// <summary>
        ///     Gets or sets the disk usage status.
        ///     Possible values include: 'Normal', 'Warning', 'Error', 'Unknown'
        /// </summary>
        public string DiskUsageStatus { get; set; }

        /// <summary>
        ///     Gets or sets the system load status.
        ///     Possible values include: 'Normal', 'Warning', 'Error', 'Unknown'
        /// </summary>
        public string SystemLoadStatus { get; set; }

        /// <summary>
        ///     Gets or sets the system load.
        /// </summary>
        public long? SystemLoad { get; set; }

        /// <summary>
        ///     Gets or sets the throughput status.
        ///     Possible values include: 'Normal', 'Warning', 'Error', 'Unknown'
        /// </summary>
        public string ThroughputStatus { get; set; }

        /// <summary>
        ///     Gets or sets the health of the process server.
        ///     Possible values include: 'None', 'Normal', 'Warning', 'Critical'.
        /// </summary>
        public string Health { get; set; }

        /// <summary>
        ///     Gets or sets the health errors.
        /// </summary>
        public IList<HealthError> HealthErrors { get; set; }

        /// <summary>
        ///     Gets or sets the historic health of the process server based on the health in last 24 hours.
        ///     Possible values include: 'None', 'Normal', 'Warning', 'Critical'.
        /// </summary>
        public string HistoricHealth { get; set; }
    }

    /// <summary>
    ///     Rcm proxy details.
    /// </summary>
    public class ASRRcmProxyDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRRcmProxyDetails" /> class.
        /// </summary>
        public ASRRcmProxyDetails(RcmProxyDetails rcmProxyDetails)
        {
            this.Id = rcmProxyDetails.Id;
            this.Name = rcmProxyDetails.Name;
            this.FabricObjectId = rcmProxyDetails.FabricObjectId;
            this.BiosId = rcmProxyDetails.BiosId;
            this.Fqdn = rcmProxyDetails.Fqdn;
            this.Version = rcmProxyDetails.Version;
            this.LastHeartbeatUtc = rcmProxyDetails.LastHeartbeatUtc;
            this.Health = rcmProxyDetails.Health;
            this.HealthErrors = rcmProxyDetails.HealthErrors;
        }

        /// <summary>
        ///     Gets or sets the RCM proxy Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the RCM proxy name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the fabric object Id.
        /// </summary>
        public string FabricObjectId { get; set; }

        /// <summary>
        ///     Gets or sets the RCM proxy bios Id.
        /// </summary>
        public string BiosId { get; set; }

        /// <summary>
        ///     Gets or sets the RCM proxy fqdn.
        /// </summary>
        public string Fqdn { get; set; }

        /// <summary>
        ///     Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///     Gets or sets the last heartbeat received from the RCM proxy.
        /// </summary>
        public DateTime? LastHeartbeatUtc { get; set; }

        /// <summary>
        ///     Gets or sets the health of the RCM proxy.
        /// </summary>
        public string Health { get; set; }

        /// <summary>
        ///     Gets or sets the health errors.
        /// </summary>
        public IList<HealthError> HealthErrors { get; set; }
    }

    /// <summary>
    ///     Push installer details.
    /// </summary>
    public class ASRPushInstallerDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRPushInstallerDetails" /> class.
        /// </summary>
        public ASRPushInstallerDetails(PushInstallerDetails piDetails)
        {
            this.Id = piDetails.Id;
            this.Name = piDetails.Name;
            this.FabricObjectId = piDetails.FabricObjectId;
            this.Version = piDetails.Version;
            this.BiosId = piDetails.BiosId;
            this.Fqdn = piDetails.Fqdn;
            this.LastHeartbeatUtc = piDetails.LastHeartbeatUtc;
            this.Health = piDetails.Health;
            this.HealthErrors = piDetails.HealthErrors;
        }

        /// <summary>
        ///     Gets or sets the push installer Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the push installer name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the fabric object Id.
        /// </summary>
        public string FabricObjectId { get; set; }

        /// <summary>
        ///     Gets or sets the push installer bios Id.
        /// </summary>
        public string BiosId { get; set; }

        /// <summary>
        ///     Gets or sets the push installer fqdn.
        /// </summary>
        public string Fqdn { get; set; }

        /// <summary>
        ///     Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///     Gets or sets the last heartbeat received from the push installer.
        /// </summary>
        public DateTime? LastHeartbeatUtc { get; set; }

        /// <summary>
        ///     Gets or sets the health of the push installer.
        /// </summary>
        public string Health { get; set; }

        /// <summary>
        ///     Gets or sets the health errors.
        /// </summary>
        public IList<HealthError> HealthErrors { get; set; }
    }

    /// <summary>
    ///     Replication agent details.
    /// </summary>
    public class ASRReplicationAgentDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRReplicationAgentDetails" /> class.
        /// </summary>
        public ASRReplicationAgentDetails(ReplicationAgentDetails replicationAgentDetails)
        {
            this.Id = replicationAgentDetails.Id;
            this.Name = replicationAgentDetails.Name;
            this.FabricObjectId = replicationAgentDetails.FabricObjectId;
            this.BiosId = replicationAgentDetails.BiosId;
            this.Fqdn = replicationAgentDetails.Fqdn;
            this.Version = replicationAgentDetails.Version;
            this.LastHeartbeatUtc = replicationAgentDetails.LastHeartbeatUtc;
            this.Health = replicationAgentDetails.Health;
            this.HealthErrors = replicationAgentDetails.HealthErrors;
        }

        /// <summary>
        ///     Gets or sets the replication agent Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the replication agent name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the fabric object Id.
        /// </summary>
        public string FabricObjectId { get; set; }

        /// <summary>
        ///     Gets or sets the replication agent bios Id.
        /// </summary>
        public string BiosId { get; set; }

        /// <summary>
        ///     Gets or sets the replication agent fqdn.
        /// </summary>
        public string Fqdn { get; set; }

        /// <summary>
        ///     Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///     Gets or sets the last heartbeat received from the replication agent.
        /// </summary>
        public DateTime? LastHeartbeatUtc { get; set; }

        /// <summary>
        ///     Gets or sets the health of the replication agent.
        /// </summary>
        public string Health { get; set; }

        /// <summary>
        ///     Gets or sets the health errors.
        /// </summary>
        public IList<HealthError> HealthErrors { get; set; }
    }

    /// <summary>
    ///     Reprotect agent details.
    /// </summary>
    public class ASRReprotectAgentDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRReprotectAgentDetails" /> class.
        /// </summary>
        public ASRReprotectAgentDetails(ReprotectAgentDetails reprotectAgentDetails)
        {
            this.Id = reprotectAgentDetails.Id;
            this.Name = reprotectAgentDetails.Name;
            this.FabricObjectId = reprotectAgentDetails.FabricObjectId;
            this.BiosId = reprotectAgentDetails.BiosId;
            this.Fqdn = reprotectAgentDetails.Fqdn;
            this.Version = reprotectAgentDetails.Version;
            this.LastHeartbeatUtc = reprotectAgentDetails.LastHeartbeatUtc;
            this.Health = reprotectAgentDetails.Health;
            this.HealthErrors = reprotectAgentDetails.HealthErrors;
        }

        /// <summary>
        ///     Gets or sets the reprotect agent Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the reprotect agent name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the fabric object Id.
        /// </summary>
        public string FabricObjectId { get; set; }

        /// <summary>
        ///     Gets or sets the reprotect agent bios Id.
        /// </summary>
        public string BiosId { get; set; }

        /// <summary>
        ///     Gets or sets the reprotect agent fqdn.
        /// </summary>
        public string Fqdn { get; set; }

        /// <summary>
        ///     Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///     Gets or sets the last heartbeat received from the reprotect agent.
        /// </summary>
        public DateTime? LastHeartbeatUtc { get; set; }

        /// <summary>
        ///     Gets or sets the health of the reprotect agent.
        /// </summary>
        public string Health { get; set; }

        /// <summary>
        ///     Gets or sets the health errors.
        /// </summary>
        public IList<HealthError> HealthErrors { get; set; }
    }

    /// <summary>
    ///     Mars agent details.
    /// </summary>
    public class ASRMarsAgentDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRMarsAgentDetails" /> class.
        /// </summary>
        public ASRMarsAgentDetails(MarsAgentDetails marsAgentDetails)
        {
            this.Id = marsAgentDetails.Id;
            this.Name = marsAgentDetails.Name;
            this.FabricObjectId = marsAgentDetails.FabricObjectId;
            this.BiosId = marsAgentDetails.BiosId;
            this.Fqdn = marsAgentDetails.Fqdn;
            this.Version = marsAgentDetails.Version;
            this.LastHeartbeatUtc = marsAgentDetails.LastHeartbeatUtc;
            this.Health = marsAgentDetails.Health;
            this.HealthErrors = marsAgentDetails.HealthErrors;
        }

        /// <summary>
        ///     Gets or sets the Mars agent Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the Mars agent name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the fabric object Id.
        /// </summary>
        public string FabricObjectId { get; set; }

        /// <summary>
        ///     Gets or sets the Mars agent bios Id.
        /// </summary>
        public string BiosId { get; set; }

        /// <summary>
        ///     Gets or sets the Mars agent fqdn.
        /// </summary>
        public string Fqdn { get; set; }

        /// <summary>
        ///     Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///     Gets or sets the last heartbeat received from the Mars agent.
        /// </summary>
        public DateTime? LastHeartbeatUtc { get; set; }

        /// <summary>
        ///     Gets or sets the health of the Mars agent.
        /// </summary>
        public string Health { get; set; }

        /// <summary>
        ///     Gets or sets the health errors.
        /// </summary>
        public IList<HealthError> HealthErrors { get; set; }
    }

    /// <summary>
    ///     Dra details.
    /// </summary>
    public class ASRDraDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRDraDetails" /> class.
        /// </summary>
        public ASRDraDetails(DraDetails draDetails)
        {
            this.Id = draDetails.Id;
            this.Name = draDetails.Name;
            this.BiosId = draDetails.BiosId;
            this.Version = draDetails.Version;
            this.LastHeartbeatUtc = draDetails.LastHeartbeatUtc;
            this.Health = draDetails.Health;
            this.HealthErrors = draDetails.HealthErrors;
        }

        /// <summary>
        ///     Gets or sets the DRA Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the DRA name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the DRA bios Id.
        /// </summary>
        public string BiosId { get; set; }

        /// <summary>
        ///     Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///     Gets or sets the last heartbeat received from the DRA.
        /// </summary>
        public DateTime? LastHeartbeatUtc { get; set; }

        /// <summary>
        ///     Gets or sets the health of the DRA.
        /// </summary>
        public string Health { get; set; }

        /// <summary>
        ///     Gets or sets the health errors.
        /// </summary>
        public IList<HealthError> HealthErrors { get; set; }
    }

    /// <summary>
    ///     Agent details.
    /// </summary>
    public class ASRAgentDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRAgentDetails" /> class.
        /// </summary>
        public ASRAgentDetails(AgentDetails agentDetails)
        {
            this.AgentId = agentDetails.AgentId;
            this.MachineId = agentDetails.MachineId;
            this.BiosId = agentDetails.BiosId;
            this.Fqdn = agentDetails.Fqdn;
            if (agentDetails.Disks != null && agentDetails.Disks.Any())
            {
                this.Disks = agentDetails.Disks
                    .ToList()
                    .ConvertAll(disk => new ASRAgentDiskDetails(disk));
            }
        }

        /// <summary>
        ///     Gets or sets the Id of the agent running on the server.
        /// </summary>
        public string AgentId { get; set; }

        /// <summary>
        ///     Gets or sets the Id of the machine to which the agent is registered.
        /// </summary>
        public string MachineId { get; set; }

        /// <summary>
        ///     Gets or sets the machine BIOS Id.
        /// </summary>
        public string BiosId { get; set; }

        /// <summary>
        ///     Gets or sets the machine FQDN.
        /// </summary>
        public string Fqdn { get; set; }

        /// <summary>
        ///     Gets or sets the disks.
        /// </summary>
        public List<ASRAgentDiskDetails> Disks { get; set; }
    }

    /// <summary>
    ///     Agent disk details.
    /// </summary>
    public class ASRAgentDiskDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRAgentDiskDetails" /> class.
        /// </summary>
        public ASRAgentDiskDetails(AgentDiskDetails details)
        {
            this.DiskId = details.DiskId;
            this.DiskName = details.DiskName;
            this.IsOSDisk = details.IsOSDisk;
            this.CapacityInBytes = details.CapacityInBytes;
            this.LunId = details.LunId;
        }

        /// <summary>
        ///     Gets or sets the disk Id.
        /// </summary>
        public string DiskId { get; set; }

        /// <summary>
        ///     Gets or sets the disk name.
        /// </summary>
        public string DiskName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the disk is the OS disk.
        /// </summary>
        public string IsOSDisk { get; set; }

        /// <summary>
        ///     Gets or sets the disk capacity in bytes.
        /// </summary>
        public long? CapacityInBytes { get; set; }

        /// <summary>
        ///     Gets or sets the lun of disk.
        /// </summary>
        public int? LunId { get; set; }
    }

    /// <summary>
    ///     Fabric Specific Virtual Machine Details for VMWare.
    /// </summary>
    public class ASRVMWareSpecificVMDetails : ASRFabricSpecificVMDetails
    {
        /// <summary>
        ///     Gets or sets the ID generated by the InMage agent after it gets installed on guest.
        /// </summary>
        public string AgentGeneratedId { get; set; }

        /// <summary>
        ///     Gets or sets the value indicating if InMage scout agent is installed on guest.
        /// </summary>
        public string AgentInstalled { get; set; }

        /// <summary>
        ///     Gets or sets the agent version installed on VM.
        /// </summary>
        public string AgentVersion { get; set; }

        /// <summary>
        ///     Gets or sets the discovery type of the machine.
        /// </summary>
        public string DiscoveryType { get; set; }

        /// <summary>
        ///     Gets or sets the IP address of the VM.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        ///     Gets or sets the value indicating whether VM is powered on.
        /// </summary>
        public string PoweredOn { get; set; }
    }


    /// <summary>
    ///     HyperV replica 2012 replication details.
    public class HyperVReplicaSpecificRPIDetails
    {

        /// <summary>
        ///    Gets or sets the Last replication time.
        /// </summary>
        public DateTime? LastReplicatedTime { get; set; }

        /// <summary>
        ///    Gets or sets the PE Network details.
        /// </summary>
        public IList<VMNicDetails> VmNics { get; set; }

        /// <summary>
        ///    Gets or sets the virtual machine Id.
        /// </summary>
        public string VmId { get; set; }

        /// <summary>
        ///     Gets or sets the protection state for the vm.
        /// </summary>
        public string VmProtectionState { get; set; }

        /// <summary>
        ///     Gets or sets the protection state description for the vm.
        /// </summary>
        public string VmProtectionStateDescription { get; set; }

        /// <summary>
        ///Gets or sets VM disk details.
        /// </summary>
        public IList<ASRHyperVReplicaDiskDetails> VMDiskDetails { get; set; }
    }

    /// <summary>
    /// Onprem disk details data.
    /// </summary>
    public class ASRHyperVReplicaDiskDetails
    {
        public ASRHyperVReplicaDiskDetails(DiskDetails diskDetails)
        {
            this.MaxSizeMB = diskDetails.MaxSizeMB;
            this.VhdId = diskDetails.VhdId;
            this.VhdName = diskDetails.VhdName;
            this.VhdType = diskDetails.VhdType;
        }
        /// <summary>
        ///    Gets or sets the hard disk max size in MB.
        /// </summary>
        public long? MaxSizeMB { get; set; }

        /// <summary>
        ///     Gets or sets the type of the volume.
        /// </summary>
        public string VhdType { get; set; }

        /// <summary>
        ///     Gets or sets the VHD Id.
        /// </summary>
        public string VhdId { get; set; }

        /// <summary>
        ///     Gets or sets the VHD name.
        /// </summary>
        public string VhdName { get; set; }
    }

    public class ASRHyperVReplicaAzureVmDiskDetails
    {
        public ASRHyperVReplicaAzureVmDiskDetails(AzureVmDiskDetails hyperVReplicaAzureVmDiskDetails)
        {
            this.VhdType = hyperVReplicaAzureVmDiskDetails.VhdType;
            this.VhdId = hyperVReplicaAzureVmDiskDetails.VhdId;
            this.VhdName = hyperVReplicaAzureVmDiskDetails.VhdName;
            this.MaxSizeMB = hyperVReplicaAzureVmDiskDetails.MaxSizeMB;
            this.TargetDiskLocation = hyperVReplicaAzureVmDiskDetails.TargetDiskLocation;
            this.TargetDiskName = hyperVReplicaAzureVmDiskDetails.TargetDiskName;
            this.LunId = hyperVReplicaAzureVmDiskDetails.LunId;
            this.DiskId = hyperVReplicaAzureVmDiskDetails.DiskId;
            this.DiskEncryptionSetId = hyperVReplicaAzureVmDiskDetails.DiskEncryptionSetId;
        }

        /// <summary>
        ///    Gets or sets VHD type.
        /// </summary>
        public string VhdType { get; set; }

        /// <summary>
        ///    Gets or sets the VHD id.
        /// </summary>
        public string VhdId { get; set; }

        /// <summary>
        /// Gets or sets the disk id.
        /// </summary>
        public string DiskId { get; set; }

        /// <summary>
        ///    Gets or sets VHD name.
        /// </summary>
        public string VhdName { get; set; }

        /// <summary>
        ///    Gets or sets max side in MB.
        /// </summary>
        public string MaxSizeMB { get; set; }

        /// <summary>
        ///    Gets or sets blob uri of the Azure disk.
        /// </summary>
        public string TargetDiskLocation { get; set; }

        /// <summary>
        ///     Gets or sets the target Azure disk name.
        /// </summary>
        public string TargetDiskName { get; set; }

        /// <summary>
        ///     Gets or sets ordinal\LunId of the disk for the Azure VM.
        /// </summary>
        public string LunId { get; set; }

        /// <summary>
        /// Gets or sets the DiskEncryptionSet ARM ID.
        /// </summary>
        public string DiskEncryptionSetId { get; set; }



    }

    /// <summary>
    ///     Disk Details.
    /// </summary>
    public class ASRHyperVReplicaAzureOsDetails
    {
        public ASRHyperVReplicaAzureOsDetails(OSDetails hyperVOsSetails)
        {
            this.OsType = hyperVOsSetails.OsType;
            this.ProductType = hyperVOsSetails.ProductType;
            this.OsEdition = hyperVOsSetails.OsEdition;
            this.OSVersion = hyperVOsSetails.OSVersion;
            this.OSMinorVersion = hyperVOsSetails.OSMinorVersion;
            this.OSMajorVersion = hyperVOsSetails.OSMajorVersion;
        }
        /// <summary>
        ///     Gets or sets VM Disk details.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        ///  Gets or sets product type.
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        ///     Gets or sets the OSEdition.
        /// </summary>
        public string OsEdition { get; set; }

        /// <summary>
        ///     Gets or sets the OS Version.
        /// </summary>
        public string OSVersion { get; set; }

        /// <summary>
        ///    Gets or sets the OS Major Version.
        /// </summary>
        public string OSMajorVersion { get; set; }

        /// <summary>
        ///    Gets or sets the OS Minor Version.
        /// </summary>
        public string OSMinorVersion { get; set; }
    }

    /// <summary>
    ///     InMageAzureV2 Specific Replication Protected Item Details.
    /// </summary>
    public class ASRHyperVReplicaAzureSpecificRPIDetails : ASRProviderSpecificRPIDetails
    {
        /// <summary>
        /// Initializes a new instance of the<see cref="ASRAzureToAzureSpecificRPIDetails" /> class.
        /// </summary>
        public ASRHyperVReplicaAzureSpecificRPIDetails(HyperVReplicaAzureReplicationDetails details)
        {
            this.RecoveryAvailabilitySetId = details.RecoveryAvailabilitySetId;
            this.RecoveryAvailabilityZone = details.TargetAvailabilityZone;
            this.RecoveryProximityPlacementGroupId = details.TargetProximityPlacementGroupId;
            this.EnableRDPOnTargetOption = details.EnableRdpOnTargetOption;
            this.SourceVmCPUCount = details.SourceVmCpuCount;
            this.SourceVmRAMSizeInMB = details.SourceVmRamSizeInMB;
            if (details.OSDetails != null)
            {
                this.OsDetails = new ASRHyperVReplicaAzureOsDetails(details.OSDetails);
            }
            this.Encryption = details.Encryption;
            this.SelectedRecoveryAzureNetworkId = details.SelectedRecoveryAzureNetworkId;
            this.VmProtectionState = details.VmProtectionState;
            this.VmProtectionStateDescription = details.VmProtectionStateDescription;
            this.VmId = details.VmId;
            this.LastReplicatedTime = details.LastReplicatedTime;
            this.RecoveryAzureLogStorageAccountId = details.RecoveryAzureLogStorageAccountId;
            this.RecoveryAzureStorageAccount = details.RecoveryAzureStorageAccount;
            this.RecoveryAzureVMSize = details.RecoveryAzureVMSize;
            this.RecoveryAzureVMName = details.RecoveryAzureVmName;
            this.UseManagedDisks = details.UseManagedDisks;
            if (details.AzureVmDiskDetails != null)
            {
                this.AzureVMDiskDetails =
                    details.AzureVmDiskDetails.ToList()
                    .ConvertAll(disk => new ASRHyperVReplicaAzureVmDiskDetails(disk));
            }
            this.LicenseType = details.LicenseType;
            this.SqlServerLicenseType = details.SqlServerLicenseType;
            this.RecoveryVmTag = details.TargetVmTags;
            this.RecoveryNicTag = details.TargetNicTags;
            this.DiskTag = details.TargetManagedDiskTags;
        }

        /// <summary>
        ///     Gets or sets the recovery availability set Id.
        /// <summary>
        public string RecoveryAvailabilitySetId { get; set; }

        /// <summary>
        ///     Gets or sets the selected option to enable RDP\SSH on target vm after failover.
        ///     String value of {SrsDataContract.EnableRDPOnTargetOption} enum.
        /// <summary>
        public string EnableRDPOnTargetOption { get; set; }

        /// <summary>
        ///     Gets or sets the CPU count of the VM on the primary side.
        /// <summary>
        public int? SourceVmCPUCount { get; set; }

        /// <summary>
        ///     Gets or sets the RAM size of the VM on the primary side.
        /// <summary>
        public int? SourceVmRAMSizeInMB { get; set; }

        /// <summary>
        ///     Gets or sets the operating system info.
        /// <summary>
        public ASRHyperVReplicaAzureOsDetails OsDetails { get; set; }

        /// <summary>
        ///     Gets or sets the encryption info.
        /// <summary>
        public string Encryption { get; set; }

        /// <summary>
        ///     Gets or sets the selected recovery azure network Id.
        /// <summary>
        public string SelectedRecoveryAzureNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets the protection state description for the vm.
        /// <summary>
        public string VmProtectionStateDescription { get; set; }

        /// <summary>
        ///     Gets or sets the protection state for the vm.
        /// <summary>
        public string VmProtectionState { get; set; }

        /// <summary>
        ///     Gets or sets the virtual machine Id.
        /// <summary>
        public string VmId { get; set; }

        /// <summary>
        ///     Gets or sets the Last replication time.
        /// </summary>
        public DateTime? LastReplicatedTime { get; set; }

        /// <summary>
        ///     Gets or sets the ARM id of the log storage account used for replication. This
        ///     will be set to null if no log storage account was provided during enable protection.
        /// </summary>
        public string RecoveryAzureLogStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the recovery Azure storage account.
        /// </summary>
        public string RecoveryAzureStorageAccount { get; set; }

        /// <summary>
        ///     Gets or sets the Recovery Azure VM size.
        /// </summary>
        public string RecoveryAzureVMSize { get; set; }

        /// <summary>
        ///     Gets or sets recovery Azure given name.
        /// </summary>
        public string RecoveryAzureVMName { get; set; }

        /// <summary>
        ///     Gets or sets azure VM Disk details.
        /// </summary>
        public IList<ASRHyperVReplicaAzureVmDiskDetails> AzureVMDiskDetails { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether managed disks should be used during failover.
        /// </summary>
        public string UseManagedDisks { get; set; }

        /// <summary>
        ///     Gets or sets license Type of the VM to be used.
        /// </summary>
        public string LicenseType { get; set; }

        /// <summary>
        ///     Gets or sets the resource ID of the availability zone to failover this virtual machine to.
        /// </summary>
        public string RecoveryAvailabilityZone { get; set; }

        /// <summary>
        ///     Gets or sets the proximity placement group Id for replication protected item after failover.
        /// </summary>
        public string RecoveryProximityPlacementGroupId { get; set; }

        /// <summary>
        /// Gets or sets the SQL Server license type of the machine in the event of a failover.
        /// </summary>
        public string SqlServerLicenseType { get; set; }

        /// <summary>
        /// Gets or sets target VM tags.
        /// </summary>
        public IDictionary<string, string> RecoveryVmTag { get; set; }

        /// <summary>
        /// Gets or sets the tags for the disks.
        /// </summary>
        public IDictionary<string, string> DiskTag { get; set; }

        /// <summary>
        /// Gets or sets the tags for the target NICs.
        /// </summary>S
        public IDictionary<string, string> RecoveryNicTag { get; set; }
    }

    /// <summary>
    ///     InMageAzureV2 Specific Replication Protected Item Details.
    /// </summary>
    public class ASRInMageAzureV2SpecificRPIDetails : ASRProviderSpecificRPIDetails
    {
        /// <summary>
        /// Initializes a new instance of the<see cref="ASRInMageAzureV2SpecificRPIDetails" /> class.
        /// </summary>
        public ASRInMageAzureV2SpecificRPIDetails(InMageAzureV2ReplicationDetails details)
        {
            this.RecoveryAvailabilitySetId = details.RecoveryAvailabilitySetId;
            this.AgentVersion = details.AgentVersion;
            this.DiscoveryType = details.DiscoveryType;
            this.IpAddress = details.IpAddress;
            this.MasterTargetId = details.MasterTargetId;
            this.MultiVmGroupId = details.MultiVmGroupId;
            this.MultiVmGroupName = details.MultiVmGroupName;
            this.OSDiskId = details.OsDiskId;
            this.OSType = details.OsType;
            this.ProcessServerId = details.ProcessServerId;
            this.ProcessServerName = details.ProcessServerName;
            this.ProtectionStage = details.ProtectionStage;
            this.RecoveryAzureLogStorageAccountId = details.RecoveryAzureLogStorageAccountId;
            this.VHDName = details.VhdName;
            this.DiskResized = details.DiskResized;
            this.EnableRdpOnTargetOption = details.EnableRdpOnTargetOption;
            this.InfrastructureVmId = details.InfrastructureVmId;
            this.IsAgentUpdateRequired = details.IsAgentUpdateRequired;
            this.IsRebootAfterUpdateRequired = details.IsRebootAfterUpdateRequired;
            this.LicenseType = details.LicenseType;
            this.MultiVmSyncStatus = details.MultiVmSyncStatus;
            this.OsVersion = details.OsVersion;
            this.RecoveryAzureResourceGroupId = details.RecoveryAzureResourceGroupId;
            this.RecoveryAzureStorageAccount = details.RecoveryAzureStorageAccount;
            this.RecoveryAzureVMName = details.RecoveryAzureVMName;
            this.RecoveryAzureVMSize = details.RecoveryAzureVMSize;
            this.ReplicaId = details.ReplicaId;
            this.ResyncProgressPercentage = details.ResyncProgressPercentage;
            this.RpoInSeconds = details.RpoInSeconds;
            this.SelectedRecoveryAzureNetworkId = details.SelectedRecoveryAzureNetworkId;
            this.SelectedSourceNicId = details.SelectedSourceNicId;
            this.SourceVmCpuCount = details.SourceVmCpuCount;
            this.SourceVmRamSizeInMB = details.SourceVmRamSizeInMB;
            this.TargetVmId = details.TargetVmId;
            this.UncompressedDataRateInMB = details.UncompressedDataRateInMB;
            this.UseManagedDisks = details.UseManagedDisks;
            this.VCenterInfrastructureId = details.VCenterInfrastructureId;
            this.VmId = details.VmId;
            this.VmProtectionState = details.VmProtectionState;
            this.VmProtectionStateDescription = details.VmProtectionStateDescription;
            this.RecoveryAvailabilityZone = details.TargetAvailabilityZone;
            this.RecoveryProximityPlacementGroupId = details.TargetProximityPlacementGroupId;
            this.SqlServerLicenseType = details.SqlServerLicenseType;
            this.RecoveryVmTag = details.TargetVmTags;
            this.RecoveryNicTag = details.TargetNicTags;
            this.DiskTag = details.TargetManagedDiskTags;
            if (details.ProtectedDisks != null)
            {
                this.ProtectedDiskDetails = new List<AsrVirtualHardDisk>();
                foreach (var pd in details.ProtectedDisks)
                {
                    this.ProtectedDiskDetails.Add(
                        new AsrVirtualHardDisk
                        {
                            Id = pd.DiskId,
                            Name = pd.DiskName
                        });
                }
            }
        }

        /// <summary>
        ///     Gets or sets the recovery availability set Id.
        /// <summary>
        public string RecoveryAvailabilitySetId { get; set; }

        /// <summary>
        ///     Gets or sets the agent version.
        /// </summary>
        public string AgentVersion { get; set; }

        /// <summary>
        ///     Gets or sets the value indicating the discovery type of the machine.
        /// </summary>
        public string DiscoveryType { get; set; }

        /// <summary>
        ///     Gets or sets Source IP address.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        ///     Gets or sets Last heartbeat received from the source server.
        /// </summary>
        public DateTime? LastHeartbeat { get; set; }

        /// <summary>
        ///     Master Target Id.
        /// </summary>
        public string MasterTargetId { get; set; }

        /// <summary>
        ///     Multi VM Group Id.
        /// </summary>
        public string MultiVmGroupId { get; set; }

        /// <summary>
        ///     Multi VM Group Name.
        /// </summary>
        public string MultiVmGroupName { get; set; }

        /// <summary>
        ///     OS Disk Id.
        /// </summary>
        public string OSDiskId { get; set; }

        /// <summary>
        ///     OS Type.
        /// </summary>
        public string OSType { get; set; }

        /// <summary>
        ///     Process Server Id.
        /// </summary>
        public string ProcessServerId { get; set; }

        /// <summary>
        ///     Process Server Name.
        /// </summary>
        public string ProcessServerName { get; set; }

        /// <summary>
        ///     Gets or sets Protected Disk Details of the Virtual machine.
        /// </summary>
        public List<AsrVirtualHardDisk> ProtectedDiskDetails { get; set; }

        /// <summary>
        ///     Gets or sets Protection stage.
        /// </summary>
        public string ProtectionStage { get; set; }

        /// <summary>
        ///     Recovery Azure Log Storage Account Id.
        /// </summary>
        public string RecoveryAzureLogStorageAccountId { get; set; }

        /// <summary>
        ///     VHD Name.
        /// </summary>
        public string VHDName { get; set; }

        //
        // Summary:
        //     Gets or sets agent expiry date.
        public DateTime? AgentExpiryDate { get; set; }

        //
        // Summary:
        //     Gets or sets azure VM Disk details.
        public IList<AzureVmDiskDetails> AzureVMDiskDetails { get; set; }

        //
        // Summary:
        //     Gets or sets the compressed data change rate in MB.
        public double? CompressedDataRateInMB { get; set; }
        //
        // Summary:
        //     Gets or sets the datastores of the on-premise machine. Value can be list of strings
        //     that contain datastore names.
        public IList<string> Datastores { get; set; }

        //
        // Summary:
        //     Gets or sets a value indicating whether any disk is resized for this VM.
        public string DiskResized { get; set; }

        //
        // Summary:
        //     Gets or sets the selected option to enable RDP\SSH on target vm after failover.
        //     String value of {SrsDataContract.EnableRDPOnTargetOption} enum.
        public string EnableRdpOnTargetOption { get; set; }

        //
        // Summary:
        //     Gets or sets the infrastructure VM Id.
        public string InfrastructureVmId { get; set; }

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
        //     Gets or sets the last RPO calculated time.
        public DateTime? LastRpoCalculatedTime { get; set; }
        //
        // Summary:
        //     Gets or sets the last update time received from on-prem components.
        public DateTime? LastUpdateReceivedTime { get; set; }

        //
        // Summary:
        //     Gets or sets license Type of the VM to be used.
        public string LicenseType { get; set; }

        //
        // Summary:
        //     Gets or sets a value indicating whether multi vm sync is enabled or disabled.
        public string MultiVmSyncStatus { get; set; }

        //
        // Summary:
        //     Gets or sets the OS Version of the protected item.
        public string OsVersion { get; set; }

        //
        // Summary:
        //     Gets or sets the list of protected disks.
        public IList<InMageAzureV2ProtectedDiskDetails> ProtectedDisks { get; set; }

        //
        // Summary:
        //     Gets or sets the target resource group Id.
        public string RecoveryAzureResourceGroupId { get; set; }
        //
        // Summary:
        //     Gets or sets the recovery Azure storage account.
        public string RecoveryAzureStorageAccount { get; set; }
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
        //     Gets or sets the replica id of the protected item.
        public string ReplicaId { get; set; }
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
        //     Gets or sets the selected recovery azure network Id.
        public string SelectedRecoveryAzureNetworkId { get; set; }
        //
        // Summary:
        //     Gets or sets the selected source nic Id which will be used as the primary nic
        //     during failover.
        public string SelectedSourceNicId { get; set; }
        //
        // Summary:
        //     Gets or sets the CPU count of the VM on the primary side.
        public int? SourceVmCpuCount { get; set; }
        //
        // Summary:
        //     Gets or sets the RAM size of the VM on the primary side.
        public int? SourceVmRamSizeInMB { get; set; }
        //
        // Summary:
        //     Gets or sets the ARM Id of the target Azure VM. This value will be null until
        //     the VM is failed over. Only after failure it will be populated with the ARM Id
        //     of the Azure VM.
        public string TargetVmId { get; set; }
        //
        // Summary:
        //     Gets or sets the uncompressed data change rate in MB.
        public double? UncompressedDataRateInMB { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether managed disks should be used during failover.
        public string UseManagedDisks { get; set; }
        //
        // Summary:
        //     Gets or sets the validation errors of the on-premise machine Value can be list
        //     of validation errors.
        public IList<HealthError> ValidationErrors { get; set; }
        //
        // Summary:
        //     Gets or sets the vCenter infrastructure Id.
        public string VCenterInfrastructureId { get; set; }
        //
        // Summary:
        //     Gets or sets the virtual machine Id.
        public string VmId { get; set; }
        //
        // Summary:
        //     Gets or sets the PE Network details.
        public IList<VMNicDetails> VmNics { get; set; }
        //
        // Summary:
        //     Gets or sets the protection state for the vm.
        public string VmProtectionState { get; set; }
        //
        // Summary:
        //     Gets or sets the protection state description for the vm.
        public string VmProtectionStateDescription { get; set; }

        /// <summary>
        ///     Gets or sets the resource ID of the availability zone to failover this virtual machine to.
        /// </summary>
        public string RecoveryAvailabilityZone { get; set; }

        /// <summary>
        ///     Gets or sets the proximity placement group Id for replication protected item after failover.
        /// </summary>
        public string RecoveryProximityPlacementGroupId { get; set; }

        /// <summary>
        /// Gets or sets the SQL Server license type of the machine in the event of a failover.
        /// </summary>
        public string SqlServerLicenseType { get; set; }

        /// <summary>
        /// Gets or sets target VM tags.
        /// </summary>
        public IDictionary<string, string> RecoveryVmTag { get; set; }

        /// <summary>
        /// Gets or sets the tags for the disks.
        /// </summary>
        public IDictionary<string, string> DiskTag { get; set; }

        /// <summary>
        /// Gets or sets the tags for the target NICs.
        /// </summary>
        public IDictionary<string, string> RecoveryNicTag { get; set; }
    }

    /// <summary>
    ///     InMage Specific Replication Protected Item Details.
    /// </summary>
    public class ASRInMageSpecificRPIDetails : ASRProviderSpecificRPIDetails
    {
        /// <summary>
        ///     Gets or sets the agent version.
        /// </summary>
        public string AgentVersion { get; set; }

        /// <summary>
        ///     Gets or sets the value indicating the discovery type of the machine.
        /// </summary>
        public string DiscoveryType { get; set; }

        /// <summary>
        ///     Gets or sets Source IP address.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        ///     Gets or sets Last heartbeat received from the source server.
        /// </summary>
        public DateTime? LastHeartbeat { get; set; }

        /// <summary>
        ///     Master Target Id.
        /// </summary>
        public string MasterTargetId { get; set; }

        /// <summary>
        ///     Multi VM Group Id.
        /// </summary>
        public string MultiVmGroupId { get; set; }

        /// <summary>
        ///     Multi VM Group Name.
        /// </summary>
        public string MultiVmGroupName { get; set; }

        /// <summary>
        ///     OS Disk Id.
        /// </summary>
        public string OSDiskId { get; set; }

        /// <summary>
        ///     OS Type.
        /// </summary>
        public string OSType { get; set; }

        /// <summary>
        ///     Process Server Id.
        /// </summary>
        public string ProcessServerId { get; set; }

        /// <summary>
        ///     Gets or sets Protected Disk Details of the Virtual machine.
        /// </summary>
        public List<AsrVirtualHardDisk> ProtectedDiskDetails { get; set; }

        /// <summary>
        ///     Gets or sets Protection stage.
        /// </summary>
        public string ProtectionStage { get; set; }

        /// <summary>
        ///     VHD Name.
        /// </summary>
        public string VHDName { get; set; }

        //
        // Summary:
        //     Gets or sets the virtual machine Id.
        public string VmId { get; set; }
    }

    /// <summary>
    ///     AzureToAzure Specific Replication Protected Item Details.
    /// </summary>
    public class ASRAzureToAzureSpecificRPIDetails : ASRProviderSpecificRPIDetails
    {
        /// <summary>
        /// Initializes a new instance of the<see cref="ASRAzureToAzureSpecificRPIDetails" /> class.
        /// </summary>
        public ASRAzureToAzureSpecificRPIDetails(A2AReplicationDetails details)
        {
            this.FabricObjectId = details.FabricObjectId;
            this.MultiVmGroupId = details.MultiVmGroupId;
            this.MultiVmGroupName = details.MultiVmGroupName;
            this.OSType = details.OsType;
            this.PrimaryFabricLocation = details.PrimaryFabricLocation;
            this.RecoveryFabricObjectId = details.RecoveryFabricObjectId;
            this.RecoveryAzureResourceGroupId = details.RecoveryAzureResourceGroupId;
            this.RecoveryAzureCloudService = details.RecoveryCloudService;
            this.RecoveryFabricLocation = details.RecoveryFabricLocation;
            this.RecoveryAvailabilitySet = details.RecoveryAvailabilitySet;
            this.RecoveryProximityPlacementGroupId = details.RecoveryProximityPlacementGroupId;
            this.RecoveryVirtualMachineScaleSetId = details.RecoveryVirtualMachineScaleSetId;
            this.TestFailoverRecoveryFabricObjectId = details.TestFailoverRecoveryFabricObjectId;
            this.MonitoringJobType = details.MonitoringJobType;
            this.MonitoringPercentageCompletion = details.MonitoringPercentageCompletion;
            this.AgentVersion = details.AgentVersion;
            this.LastRpoCalculatedTime = details.LastRpoCalculatedTime;
            this.RpoInSeconds = details.RpoInSeconds;
            this.IsReplicationAgentUpdateRequired = details.IsReplicationAgentUpdateRequired;
            this.VmEncryptionType = details.VmEncryptionType;
            this.InitialPrimaryFabricLocation = details.InitialPrimaryFabricLocation;
            this.InitialRecoveryFabricLocation = details.InitialRecoveryFabricLocation;
            this.InitialPrimaryZone = details.InitialPrimaryZone;
            this.InitialRecoveryZone = details.InitialRecoveryZone;
            this.LifecycleId = details.LifecycleId;

            if (details.LastHeartbeat != null)
            {
                this.LastHeartbeat = details.LastHeartbeat.Value.ToLocalTime();
            }

            if (details.ProtectedDisks != null && details.ProtectedDisks.Any())
            {
                this.A2ADiskDetails =
                    details.ProtectedDisks.ToList()
                    .ConvertAll(disk => new ASRAzureToAzureProtectedDiskDetails(disk));
            }

            if (details.ProtectedManagedDisks != null && details.ProtectedManagedDisks.Any())
            {
                if (this.A2ADiskDetails == null)
                {
                    this.A2ADiskDetails = new List<ASRAzureToAzureProtectedDiskDetails>();
                }
                this.A2ADiskDetails.AddRange(details.ProtectedManagedDisks.ToList().ConvertAll(disk => new ASRAzureToAzureProtectedDiskDetails(disk)));
            }

            if (details.UnprotectedDisks != null && details.UnprotectedDisks.Count > 0)
            {
                this.A2AUnprotectedDiskDetails = new List<AsrA2AUnprotectedDiskDetails>();
                foreach (var unprotectedDisk in details.UnprotectedDisks)
                {
                    this.A2AUnprotectedDiskDetails.Add(
                        new AsrA2AUnprotectedDiskDetails
                        {
                            DiskLunId = unprotectedDisk.DiskLunId ?? -1
                        });
                }
            }

            if (details.VmSyncedConfigDetails != null)
            {
                this.VmSyncedConfigDetails =
                    new ASRAzureToAzureVmSyncedConfigDetails(details.VmSyncedConfigDetails);
            }

        }

        /// <summary>
        /// Gets or sets A2A unprotected disk details.
        /// </summary>
        public List<AsrA2AUnprotectedDiskDetails> A2AUnprotectedDiskDetails { get; set; }

        /// <summary>
        /// Fabric object ARM Id.
        /// </summary>
        public string FabricObjectId { get; set; }

        /// <summary>
        /// Multi vm group Id.
        /// </summary>
        public string MultiVmGroupId { get; set; }

        /// <summary>
        /// Multi vm group name.
        /// </summary>
        public string MultiVmGroupName { get; set; }
        /// </summary>

        /// <summary>
        /// Operating system type.
        /// </summary>
        public string OSType { get; set; }

        /// <summary>
        /// Primary fabric location.
        /// </summary>
        public string PrimaryFabricLocation { get; set; }

        /// <summary>
        /// Recovery azure resource group id.
        /// </summary>
        public string RecoveryAzureResourceGroupId { get; set; }

        /// <summary>
        /// Recovery azure cloud service.
        /// </summary>
        public string RecoveryAzureCloudService { get; set; }

        /// <summary>
        /// Recovery fabric location.
        /// </summary>
        public string RecoveryFabricLocation { get; set; }

        /// <summary>
        /// Recovery availability set.
        /// </summary>
        public string RecoveryAvailabilitySet { get; set; }

        /// <summary>
        /// Recovery proximity placement group Id.
        /// </summary>
        public string RecoveryProximityPlacementGroupId { get; set; }

        /// <summary>
        /// Recovery virtual machine scale set Id.
        /// </summary>
        public string RecoveryVirtualMachineScaleSetId { get; set; }

        /// <summary>
        /// Synced configuration details of the virtual machine.
        /// </summary>
        public ASRAzureToAzureVmSyncedConfigDetails VmSyncedConfigDetails { get; set; }

        /// <summary>
        /// Gets or sets the type of the monitoring job. The progress is contained in
        /// MonitoringPercentageCompletion property.
        /// </summary>
        public string MonitoringJobType { get; set; }

        /// <summary>
        /// Gets or sets the percentage of the monitoring job. The type of the monitoring job
        /// is defined by MonitoringJobType property.
        /// </summary>
        public int? MonitoringPercentageCompletion { get; set; }

        /// <summary>
        /// Gets or sets the last heartbeat received from the source server.
        /// </summary>
        public DateTime? LastHeartbeat { get; set; }

        /// <summary>
        /// Gets or sets A2A specific protected disk details.
        /// </summary>
        public List<ASRAzureToAzureProtectedDiskDetails> A2ADiskDetails { get; set; }

        /// <summary>
        /// Gets or sets the recovery fabric object Id.
        /// </summary>
        public string RecoveryFabricObjectId { get; set; }

        /// <summary>
        /// Gets or sets the test failover fabric object Id.
        /// </summary>
        public string TestFailoverRecoveryFabricObjectId { get; set; }

        /// <summary>
        //     Gets or sets the agent version.
        /// </summary>
        public string AgentVersion;

        /// <summary>
        //  Gets or sets the time (in UTC) when the last RPO value was calculated by Protection service.
        /// </summary>
        public DateTime? LastRpoCalculatedTime;

        /// <summary>
        //     Gets or sets the last RPO value in seconds.
        /// </summary>
        public long? RpoInSeconds;

        /// <summary>
        //     Gets or sets a value indicating whether replication agent update is required.
        /// </summary>
        public bool? IsReplicationAgentUpdateRequired;

        /// <summary>
        /// Gets or sets the VM encryption type.
        /// </summary>
        public string VmEncryptionType { get; set; }

        /// <summary>
        /// Gets or sets the initial primary fabric location.
        /// </summary>
        public string InitialPrimaryFabricLocation { get; set; }

        /// <summary>
        /// Gets or sets the initial recovery fabric location.
        /// </summary>
        public string InitialRecoveryFabricLocation { get; set; }

        /// <summary>
        /// Gets or sets the initial primary zone.
        /// </summary>
        public string InitialPrimaryZone { get; set; }

        /// <summary>
        /// Gets or sets the initial recovery zone.
        /// </summary>
        public string InitialRecoveryZone { get; set; }

        /// <summary>
        /// Gets or sets the only constant ID throught out the enable disable cycle.
        /// (with multiple switch protections in the middle) - Recovery Plans refer this ID.
        /// </summary>
        public string LifecycleId { get; set; }

        // check do we need to expoxed these 2 (TODO)
        // public string RecoveryFabricObjectId;  //how it is different from parent RecoveryFabricId
        // public string managementId;
    }

    /// <summary>
    ///     InMageRcm specific replication protected item details.
    /// </summary>
    public class ASRInMageRcmSpecificRPIDetails : ASRProviderSpecificRPIDetails
    {
        /// <summary>
        /// Initializes a new instance of the<see cref="ASRInMageRcmSpecificRPIDetails" /> class.
        /// </summary>
        public ASRInMageRcmSpecificRPIDetails(InMageRcmReplicationDetails details)
        {
            this.InternalIdentifier = details.InternalIdentifier;
            this.FabricDiscoveryMachineId = details.FabricDiscoveryMachineId;
            this.MultiVmGroupName = details.MultiVmGroupName;
            this.DiscoveryType = details.DiscoveryType;
            this.ProcessServerId = details.ProcessServerId;
            this.ProcessServerName = details.ProcessServerName;
            this.ProcessorCoreCount = details.ProcessorCoreCount;
            this.AllocatedMemoryInMB = details.AllocatedMemoryInMB;
            this.RunAsAccountId = details.RunAsAccountId;
            this.OsType = details.OsType;
            this.FirmwareType = details.FirmwareType;
            this.PrimaryNicIpAddress = details.PrimaryNicIpAddress;
            this.TargetGeneration = details.TargetGeneration;
            this.LicenseType = details.LicenseType;
            this.TargetVmName = details.TargetVmName;
            this.TargetVmSize = details.TargetVmSize;
            this.TargetResourceGroupId = details.TargetResourceGroupId;
            this.TargetLocation = details.TargetLocation;
            this.TargetAvailabilitySetId = details.TargetAvailabilitySetId;
            this.TargetAvailabilityZone = details.TargetAvailabilityZone;
            this.TargetProximityPlacementGroupId = details.TargetProximityPlacementGroupId;
            this.TargetBootDiagnosticsStorageAccountId = details.TargetBootDiagnosticsStorageAccountId;
            this.TargetNetworkId = details.TargetNetworkId;
            this.TestNetworkId = details.TestNetworkId;
            this.FailoverRecoveryPointId = details.FailoverRecoveryPointId;
            this.LastRecoveryPointReceived = details.LastRecoveryPointReceived;
            this.LastRpoInSeconds = details.LastRpoInSeconds;
            this.LastRpoCalculatedTime = details.LastRpoCalculatedTime;
            this.LastRecoveryPointId = details.LastRecoveryPointId;
            this.InitialReplicationProgressPercentage = details.InitialReplicationProgressPercentage;
            this.InitialReplicationProcessedBytes = details.InitialReplicationProcessedBytes;
            this.InitialReplicationTransferredBytes = details.InitialReplicationTransferredBytes;
            this.ResyncProgressPercentage = details.ResyncProgressPercentage;
            this.ResyncProcessedBytes = details.ResyncProcessedBytes;
            this.ResyncTransferredBytes = details.ResyncTransferredBytes;
            this.InitialReplicationProgressHealth = details.InitialReplicationProgressHealth;
            this.ResyncProgressHealth = details.ResyncProgressHealth;
            this.ResyncState = details.ResyncState;
            this.AgentUpgradeState = details.AgentUpgradeState;
            this.LastAgentUpgradeType = details.LastAgentUpgradeType;
            this.AgentUpgradeJobId = details.AgentUpgradeJobId;
            this.AgentUpgradeAttemptToVersion = details.AgentUpgradeAttemptToVersion;
            this.ResyncRequired = details.ResyncRequired;
            this.IsLastUpgradeSuccessful = details.IsLastUpgradeSuccessful;
            this.MobilityAgentDetails =
                details.MobilityAgentDetails != null ?
                    new ASRInMageRcmMobilityAgentDetails(details.MobilityAgentDetails) :
                    null;

            if (details.ProtectedDisks != null && details.ProtectedDisks.Any())
            {
                this.ProtectedDisks = details.ProtectedDisks.ToList()
                   .ConvertAll(disk => new ASRInMageRcmProtectedDiskDetails(disk));
            }

            if (details.VmNics != null && details.VmNics.Any())
            {
                this.VmNics = details.VmNics.ToList()
                    .ConvertAll(nic => new ASRInMageRcmNicDetails(nic));
            }

            if (details.LastAgentUpgradeErrorDetails != null && details.LastAgentUpgradeErrorDetails.Any())
            {
                this.LastAgentUpgradeErrorDetails = details.LastAgentUpgradeErrorDetails.ToList()
                   .ConvertAll(e => new ASRInMageRcmLastAgentUpgradeErrorDetails(e));
            }

            if (details.AgentUpgradeBlockingErrorDetails != null && details.AgentUpgradeBlockingErrorDetails.Any())
            {
                this.AgentUpgradeBlockingErrorDetails = details.AgentUpgradeBlockingErrorDetails.ToList()
                   .ConvertAll(e => new ASRInMageRcmAgentUpgradeBlockingErrorDetails(e));
            }
        }

        /// <summary>
        ///     Gets or sets the virtual machine Id.
        /// </summary>
        public string InternalIdentifier { get; set; }

        /// <summary>
        ///     Gets or sets the ARM Id of the discovered VM.
        /// </summary>
        public string FabricDiscoveryMachineId { get; set; }

        /// <summary>
        ///     Gets or sets the multi VM group name.
        /// </summary>
        public string MultiVmGroupName { get; set; }

        /// <summary>
        ///     Gets or sets the type of the discovered VM.
        /// </summary>
        public string DiscoveryType { get; set; }

        /// <summary>
        ///     Gets or sets the process server Id.
        /// </summary>
        public string ProcessServerId { get; set; }

        /// <summary>
        ///     Gets or sets the process server name.
        /// </summary>
        public string ProcessServerName { get; set; }

        /// <summary>
        ///     Gets or sets the processor core count.
        /// </summary>
        public int? ProcessorCoreCount { get; set; }

        /// <summary>
        ///     Gets or sets the allocated memory in MB.
        /// </summary>
        public double? AllocatedMemoryInMB { get; set; }

        /// <summary>
        ///     Gets or sets the run-as account Id.
        /// </summary>
        public string RunAsAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the OS on the VM.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        ///     Gets or sets the firmware type.
        /// </summary>
        public string FirmwareType { get; set; }

        /// <summary>
        ///     Gets or sets the IP address of the primary network interface.
        /// </summary>
        public string PrimaryNicIpAddress { get; set; }

        /// <summary>
        ///     Gets or sets the target generation.
        /// </summary>
        public string TargetGeneration { get; set; }

        /// <summary>
        ///     Gets or sets License Type of the VM to be used.
        /// </summary>
        public string LicenseType { get; set; }

        /// <summary>
        ///     Gets or sets target VM name.
        /// </summary>
        public string TargetVmName { get; set; }

        /// <summary>
        ///     Gets or sets the target VM size.
        /// </summary>
        public string TargetVmSize { get; set; }

        /// <summary>
        ///     Gets or sets the target resource group Id.
        /// </summary>
        public string TargetResourceGroupId { get; set; }

        /// <summary>
        ///     Gets or sets the target location.
        /// </summary>
        public string TargetLocation { get; set; }

        /// <summary>
        ///     Gets or sets the target availability set Id.
        /// </summary>
        public string TargetAvailabilitySetId { get; set; }

        /// <summary>
        ///     Gets or sets the target availability zone.
        /// </summary>
        public string TargetAvailabilityZone { get; set; }

        /// <summary>
        ///     Gets or sets the target proximity placement group Id.
        /// </summary>
        public string TargetProximityPlacementGroupId { get; set; }

        /// <summary>
        ///     Gets or sets the target boot diagnostics storage account ARM Id.
        /// </summary>
        public string TargetBootDiagnosticsStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the target network Id.
        /// </summary>
        public string TargetNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets the test network Id.
        /// </summary>
        public string TestNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets the recovery point Id to which the VM was failed over.
        /// </summary>
        public string FailoverRecoveryPointId { get; set; }

        /// <summary>
        ///     Gets or sets the last recovery point received time.
        /// </summary>
        public DateTime? LastRecoveryPointReceived { get; set; }

        /// <summary>
        ///     Gets or sets the last recovery point objective value.
        /// </summary>
        public long? LastRpoInSeconds { get; set; }

        /// <summary>
        ///     Gets or sets the last recovery point objective calculated time.
        /// </summary>
        public DateTime? LastRpoCalculatedTime { get; set; }

        /// <summary>
        ///     Gets or sets the last recovery point Id.
        /// </summary>
        public string LastRecoveryPointId { get; set; }

        /// <summary>
        ///     Gets or sets the initial replication progress percentage.
        /// </summary>
        public int? InitialReplicationProgressPercentage { get; set; }

        /// <summary>
        ///     Gets or sets the initial replication processed bytes. This includes sum of total bytes
        ///     transferred and matched bytes on all selected disks in source VM.
        /// </summary>
        public long? InitialReplicationProcessedBytes { get; set; }

        /// <summary>
        ///     Gets or sets the initial replication transferred bytes from source VM to azure for
        ///     all selected disks on source VM.
        /// </summary>
        public long? InitialReplicationTransferredBytes { get; set; }

        /// <summary>
        ///     Gets or sets the initial replication progress health.
        /// </summary>
        public string InitialReplicationProgressHealth { get; set; }

        /// <summary>
        ///     Gets or sets the resync progress percentage.
        /// </summary>
        public int? ResyncProgressPercentage { get; set; }

        /// <summary>
        ///     Gets or sets the resync progress health.
        /// </summary>
        public string ResyncProgressHealth { get; set; }

        /// <summary>
        ///     Gets or sets the resync state.
        /// </summary>
        public string ResyncState { get; set; }

        /// <summary>
        ///     Gets or sets the agent auto upgrade state.
        /// </summary>
        public string AgentUpgradeState { get; set; }

        /// <summary>
        ///     Gets or sets the last agent upgrade type.
        /// </summary>
        public string LastAgentUpgradeType { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether resync is required.
        /// </summary>
        public string ResyncRequired { get; set; }


        /// <summary>
        ///     Gets or sets the resync processed bytes. This includes sum of total bytes transferred
        ///     and matched bytes on all selected disks in source VM.
        /// </summary>
        public long? ResyncProcessedBytes { get; set; }

        /// <summary>
        ///     Gets or sets the resync transferred bytes from source VM to azure for all
        ///     selected disks on source VM.
        /// </summary>
        public long? ResyncTransferredBytes { get; set; }

        /// <summary>
        ///     Gets or sets the agent upgrade job Id.
        /// </summary>
        public string AgentUpgradeJobId { get; set; }

        /// <summary>
        ///     Gets or sets the agent version to which last agent upgrade was attempted.
        /// </summary>
        public string AgentUpgradeAttemptToVersion { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether last agent upgrade was successful or not.
        /// </summary>
        public string IsLastUpgradeSuccessful { get; set; }

        /// <summary>
        ///     Gets or sets the list of protected disks.
        /// </summary>
        public List<ASRInMageRcmProtectedDiskDetails> ProtectedDisks { get; set; }

        /// <summary>
        ///     Gets or sets the mobility agent information.
        /// </summary>
        public ASRInMageRcmMobilityAgentDetails MobilityAgentDetails { get; set; }

        /// <summary>
        ///     Gets or sets the last agent upgrade error information.
        /// </summary>
        public List<ASRInMageRcmLastAgentUpgradeErrorDetails> LastAgentUpgradeErrorDetails { get; set; }

        /// <summary>
        ///     Gets or sets the network details.
        /// </summary>
        public List<ASRInMageRcmNicDetails> VmNics { get; set; }

        /// <summary>
        ///     Gets or sets the agent upgrade blocking error information.
        /// </summary>
        public List<ASRInMageRcmAgentUpgradeBlockingErrorDetails> AgentUpgradeBlockingErrorDetails { get; set; }
    }

    /// <summary>
    ///     InMageRcmFailback specific replication protected item details.
    /// </summary>
    public class ASRInMageRcmFailbackSpecificRPIDetails : ASRProviderSpecificRPIDetails
    {
        /// <summary>
        /// Initializes a new instance of the<see cref="ASRInMageRcmFailbackSpecificRPIDetails " /> class.
        /// </summary>
        public ASRInMageRcmFailbackSpecificRPIDetails(InMageRcmFailbackReplicationDetails details)
        {
            this.InternalIdentifier = details.InternalIdentifier;
            this.AzureVirtualMachineId = details.AzureVirtualMachineId;
            this.MultiVmGroupName = details.MultiVmGroupName;
            this.ReprotectAgentId = details.ReprotectAgentId;
            this.ReprotectAgentName = details.ReprotectAgentName;
            this.OsType = details.OsType;
            this.LogStorageAccountId = details.LogStorageAccountId;
            this.TargetvCenterId = details.TargetvCenterId;
            this.TargetVmName = details.TargetVmName;
            this.TargetDataStoreName = details.TargetDataStoreName;
            this.InitialReplicationProgressPercentage = details.InitialReplicationProgressPercentage;
            this.InitialReplicationProcessedBytes = details.InitialReplicationProcessedBytes;
            this.InitialReplicationTransferredBytes = details.InitialReplicationTransferredBytes;
            this.ResyncProgressPercentage = details.ResyncProgressPercentage;
            this.ResyncProcessedBytes = details.ResyncProcessedBytes;
            this.ResyncTransferredBytes = details.ResyncTransferredBytes;
            this.ResyncState = details.ResyncState;
            this.ResyncRequired = details.ResyncRequired;
            this.InitialReplicationProgressHealth = details.InitialReplicationProgressHealth;
            this.ResyncProgressHealth = details.ResyncProgressHealth;
            this.MobilityAgentDetails =
                details.MobilityAgentDetails != null ?
                    new ASRInMageRcmFailbackMobilityAgentDetails(details.MobilityAgentDetails) :
                    null;

            if (details.ProtectedDisks != null && details.ProtectedDisks.Any())
            {
                this.ProtectedDisks = details.ProtectedDisks.ToList()
                   .ConvertAll(disk => new ASRInMageRcmFailbackProtectedDiskDetails(disk));
            }

            if (details.VmNics != null && details.VmNics.Any())
            {
                this.VmNics = details.VmNics.ToList()
                    .ConvertAll(nic => new ASRInMageRcmFailbackNicDetails(nic));
            }
        }

        /// <summary>
        ///     Gets or sets the virtual machine internal identifier.
        /// </summary>
        public string InternalIdentifier { get; set; }

        /// <summary>
        ///     Gets or sets the ARM Id of the azure VM.
        /// </summary>
        public string AzureVirtualMachineId { get; set; }

        /// <summary>
        ///     Gets or sets the multi VM group name.
        /// </summary>
        public string MultiVmGroupName { get; set; }

        /// <summary>
        ///     Gets or sets the reprotect agent Id.
        /// </summary>
        public string ReprotectAgentId { get; set; }

        /// <summary>
        ///     Gets or sets the reprotect agent name.
        /// </summary>
        public string ReprotectAgentName { get; set; }

        /// <summary>
        ///     Gets or sets the type of the OS on the VM.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        ///     Gets or sets the log storage account ARM Id.
        /// </summary>
        public string LogStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the target vCenter Id.
        /// </summary>
        public string TargetvCenterId { get; set; }

        /// <summary>
        ///     Gets or sets the target datastore name.
        /// </summary>
        public string TargetDataStoreName { get; set; }

        /// <summary>
        ///     Gets or sets the target VM name.
        /// </summary>
        public string TargetVmName { get; set; }

        /// <summary>
        ///     Gets or sets the last sync time.
        /// </summary>
        public DateTime? LastSyncTime { get; set; }

        /// <summary>
        ///     Gets or sets the initial replication progress percentage.
        /// </summary>
        public int? InitialReplicationProgressPercentage { get; set; }

        /// <summary>
        ///     Gets or sets the initial replication processed bytes. This includes sum of total bytes
        ///     transferred and matched bytes on all selected disks in source VM.
        /// </summary>
        public long? InitialReplicationProcessedBytes { get; set; }

        /// <summary>
        ///     Gets or sets the initial replication transferred bytes from source VM to target for
        ///     all selected disks on source VM.
        /// </summary>
        public long? InitialReplicationTransferredBytes { get; set; }

        /// <summary>
        ///     Gets or sets the initial replication progress health.
        /// </summary>
        public string InitialReplicationProgressHealth { get; set; }

        /// <summary>
        ///     Gets or sets the resync progress percentage.
        /// </summary>
        public int? ResyncProgressPercentage { get; set; }

        /// <summary>
        ///     Gets or sets the resync processed bytes. This includes sum of total bytes transferred
        ///     and matched bytes on all selected disks in source VM.
        /// </summary>
        public long? ResyncProcessedBytes { get; set; }

        /// <summary>
        ///     Gets or sets the resync transferred bytes from source VM to target for all
        ///     selected disks on source VM.
        /// </summary>
        public long? ResyncTransferredBytes { get; set; }

        /// <summary>
        ///     Gets or sets the resync progress health.
        /// </summary>
        public string ResyncProgressHealth { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether resync is required.
        /// </summary>
        public string ResyncRequired { get; set; }

        /// <summary>
        ///     Gets or sets the resync state.
        /// </summary>
        public string ResyncState { get; set; }

        /// <summary>
        ///     Gets or sets the list of protected disks.
        /// </summary>
        public List<ASRInMageRcmFailbackProtectedDiskDetails> ProtectedDisks { get; set; }

        /// <summary>
        ///     Gets or sets the mobility agent information.
        /// </summary>
        public ASRInMageRcmFailbackMobilityAgentDetails MobilityAgentDetails { get; set; }

        /// <summary>
        ///     Gets or sets the network details.
        /// </summary>
        public List<ASRInMageRcmFailbackNicDetails> VmNics { get; set; }
    }

    //
    // Summary:
    //     A2A unprotected disk details.
    public class AsrA2AUnprotectedDiskDetails
    {
        //
        // Summary:
        //     Gets or sets the source lun Id for the data disk.
        public int? DiskLunId { get; set; }
    }

    /// <summary>
    ///     types of process server failover.
    /// </summary>
    public enum ProcessServerFailoverType
    {
        /// <summary>
        ///     The system level process failover type
        /// </summary>
        SystemLevel,

        /// <summary>
        ///     The server level process failover type
        /// </summary>
        ServerLevel
    }
}
