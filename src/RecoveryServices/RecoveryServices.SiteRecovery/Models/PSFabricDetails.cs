﻿// ----------------------------------------------------------------------------------
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
        public ASRHyperVReplicaDiskDetails(DiskDetails diskDetails) {
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

    }

    /// <summary>
    ///     InMageAzureV2 Specific Replication Protected Item Details.
    /// </summary>
    public class ASRInMageAzureV2SpecificRPIDetails : ASRProviderSpecificRPIDetails
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
        ///     Recovery Azure Log Storage Account Id.
        /// </summary>
        public string RecoveryAzureLogStorageAccountId { get; set; }

        /// <summary>
        ///     VHD Name.
        /// </summary>
        public string VHDName { get; set; }
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
            this.TestFailoverRecoveryFabricObjectId = details.TestFailoverRecoveryFabricObjectId;
            this.MonitoringJobType = details.MonitoringJobType;
            this.MonitoringPercentageCompletion = details.MonitoringPercentageCompletion;
            this.AgentVersion = details.AgentVersion;
            this.LastRpoCalculatedTime = details.LastRpoCalculatedTime;
            this.RpoInSeconds = details.RpoInSeconds;
            this.IsReplicationAgentUpdateRequired = details.IsReplicationAgentUpdateRequired;

            if (details.LastHeartbeat != null)
            {
                this.LastHeartbeat = details.LastHeartbeat.Value.ToLocalTime();
            }

            if (details.ProtectedDisks != null)
            {
                this.A2ADiskDetails =
                    details.ProtectedDisks.ToList()
                    .ConvertAll(disk => new ASRAzureToAzureProtectedDiskDetails(disk));
            }

            if (details.ProtectedManagedDisks != null)
            {
                this.A2ADiskDetails =
                    details.ProtectedManagedDisks.ToList()
                    .ConvertAll(disk => new ASRAzureToAzureProtectedDiskDetails(disk));
            }

            if (details.VmSyncedConfigDetails != null)
            {
                this.VmSyncedConfigDetails =
                    new ASRAzureToAzureVmSyncedConfigDetails(details.VmSyncedConfigDetails);
            }

        }

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

        // check do we need to expoxed these 2 (TODO)
        // public string RecoveryFabricObjectId;  //how it is different from parent RecoveryFabricId
        // public string LifecycleId;
        // public string managementId;
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