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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    /// Constant definition
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class Constants
    {
        /// <summary>
        /// ASR vault type
        /// </summary>
        public const string ASRVaultType = "HyperVRecoveryManagerVault";

        /// <summary>
        /// Vault Credential version.
        /// </summary>
        public const string VaultCredentialVersion = "1.0";

        /// <summary>
        /// The version of Extended resource info.
        /// </summary>
        public const string VaultSecurityInfoVersion = "1.0";

        /// <summary>
        /// extended information version.
        /// </summary>
        public const string VaultExtendedInfoContractVersion = "V2014_09";

        /// <summary>
        /// A valid value for the string field Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.Type
        /// </summary>
        public const string RdfeOperationStatusTypeCreate = "Create";

        /// <summary>
        /// A valid value for the string field Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.Type
        /// </summary>
        public const string RdfeOperationStatusTypeDelete = "Delete";

        /// <summary>
        /// A valid value for the string field Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.Result
        /// </summary>
        public const string RdfeOperationStatusResultSucceeded = "Succeeded";

        /// <summary>
        /// A valid value for the string field Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.Failed
        /// </summary>
        public const string RdfeOperationStatusResultFailed = "Failed";

        /// <summary>
        /// A valid value for the string field Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.InProgress
        /// </summary>
        public const string RdfeOperationStatusResultInProgress = "InProgress";

        /// <summary>
        /// Cloud service name prefix
        /// </summary>
        public const string CloudServiceNameExtensionPrefix = "CS-";

        /// <summary>
        /// Cloud service name suffix
        /// </summary>
        public const string CloudServiceNameExtensionSuffix = "-RecoveryServices";

        /// <summary>
        /// Schema Version of RP
        /// </summary>
        public const string RpSchemaVersion = "1.1";

        /// <summary>
        /// Resource Provider Namespace.
        /// </summary>
        public const string ResourceNamespace = "WAHyperVRecoveryManager";

        /// <summary>
        /// Represents direction primary to secondary.
        /// </summary>
        public const string PrimaryToRecovery = "PrimaryToRecovery";

        /// <summary>
        /// Represents direction secondary to primary.
        /// </summary>
        public const string RecoveryToPrimary = "RecoveryToPrimary";

        /// <summary>
        /// Represents Optimize value ForDowntime.
        /// </summary>
        public const string ForDowntime = "ForDowntime";

        /// <summary>
        /// Represents Optimize value for Synchronization.
        /// </summary>
        public const string ForSynchronization = "ForSynchronization";

        /// <summary>
        /// Represents primary location.
        /// </summary>
        public const string PrimaryLocation = "Primary";

        /// <summary>
        /// Represents Recovery location.
        /// </summary>
        public const string RecoveryLocation = "Recovery";

        /// <summary>
        /// Represents HyperVReplica string constant.
        /// </summary>
        public const string HyperVReplica = "HyperVReplica";

        /// <summary>
        /// Represents HyperVReplica string constant.
        /// </summary>
        public const string HyperVReplicaAzure = "HyperVReplicaAzure";

        /// <summary>
        /// Represents OnlineReplicationMethod string constant.
        /// </summary>
        public const string OnlineReplicationMethod = "Online";

        /// <summary>
        /// Represents OfflineReplicationMethod string constant.
        /// </summary>
        public const string OfflineReplicationMethod = "Offline";

        /// <summary>
        /// Represents OS Windows.
        /// </summary>
        public const string OSWindows = "Windows";

        /// <summary>
        /// Represents OS Linux.
        /// </summary>
        public const string OSLinux = "Linux";

        /// <summary>
        /// Represents Enable protection.
        /// </summary>
        public const string EnableProtection = "Enable";

        /// <summary>
        /// Represents Disable protection.
        /// </summary>
        public const string DisableProtection = "Disable";
    }

    /// <summary>
    /// Azure Site Recovery Vault Settings.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRVaultSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVaultSettings" /> class.
        /// </summary>
        public ASRVaultSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVaultSettings" /> class with vault
        /// and Cloud Service names.
        /// </summary>
        /// <param name="resourceName">vault Name</param>
        /// <param name="cloudServiceName">Cloud Service Name</param>
        public ASRVaultSettings(string resourceName, string cloudServiceName)
        {
            this.ResourceName = resourceName;
            this.CloudServiceName = cloudServiceName;
        }

        #region Properties
        /// <summary>
        /// Gets or sets Resource Name.
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets Cloud Service Name.
        /// </summary>
        public string CloudServiceName { get; set; }
        #endregion Properties
    }

    /// <summary>
    /// Azure Site Recovery Server.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRServer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRServer" /> class.
        /// </summary>
        public ASRServer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRServer" /> class with required 
        /// parameters.
        /// </summary>
        /// <param name="server">Server object</param>
        public ASRServer(Server server)
        {
            this.ID = server.ID;
            this.Name = server.Name;
            this.LastHeartbeat = server.LastHeartbeat;
            this.ProviderVersion = server.ProviderVersion;
            this.ServerVersion = server.ServerVersion;
        }

        #region Properties
        /// <summary>
        /// Gets or sets Name of the Server.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Server ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets Last communicated time.
        /// </summary>
        public DateTime LastHeartbeat { get; set; }

        /// <summary>
        /// Gets or sets Provider version.
        /// </summary>
        public string ProviderVersion { get; set; }

        /// <summary>
        /// Gets or sets Server version.
        /// </summary>
        public string ServerVersion { get; set; }
        #endregion
    }

    /// <summary>
    /// Azure Site Recovery Protection Container.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRProtectionContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRProtectionContainer" /> class.
        /// </summary>
        public ASRProtectionContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRProtectionContainer" /> class with 
        /// required parameters.
        /// </summary>
        /// <param name="pc">Protection container object</param>
        public ASRProtectionContainer(ProtectionContainer pc)
        {
            if (pc.AvailableProtectionProfiles != null)
            {
                this.AvailableProtectionProfiles = new List<ASRProtectionProfile>();
                foreach (var profile in pc.AvailableProtectionProfiles)
                {
                    var asrProtectionProfile = new ASRProtectionProfile();

                    asrProtectionProfile.AssociationDetail = new List<ASRProtectionProfileAssociationDetails>();
                    foreach (var profileAssosicationDetail in profile.AssociationDetail)
                    {
                        var asrProfileDetail = new ASRProtectionProfileAssociationDetails();
                        asrProfileDetail.AssociationStatus = profileAssosicationDetail.AssociationStatus;
                        asrProfileDetail.PrimaryProtectionContainerId =
                            profileAssosicationDetail.PrimaryProtectionContainerId;
                        asrProfileDetail.RecoveryProtectionContainerId =
                            profileAssosicationDetail.RecoveryProtectionContainerId;
                        asrProtectionProfile.AssociationDetail.Add(asrProfileDetail);
                    }

                    if (profile.ReplicationProvider == Constants.HyperVReplicaAzure)
                    {
                        var details = DataContractUtils<HyperVReplicaAzureProtectionProfileDetails>.Deserialize(
                            profile.ReplicationProviderSetting);

                        asrProtectionProfile.AllowReplicaDeletion = false;
                        asrProtectionProfile.ReplicationPort = 0;

                        asrProtectionProfile.ApplicationConsistentSnapshotFrequencyInHours = 
                            details.AppConsistencyFreq;
                        asrProtectionProfile.RecoveryAzureStorageAccount = 
                            details.ActiveStorageAccount.StorageAccountName;
                        asrProtectionProfile.RecoveryAzureSubscription = 
                            details.ActiveStorageAccount.SubscriptionId;
                        asrProtectionProfile.ReplicationFrequencySecond = details.ReplicationInterval;
                        asrProtectionProfile.ReplicationMethod = details.OnlineIrStartTime.HasValue ?
                            Constants.OnlineReplicationMethod : 
                            Constants.OfflineReplicationMethod;
                        asrProtectionProfile.ReplicationStartTime = details.OnlineIrStartTime;
                        asrProtectionProfile.CompressionEnabled = details.IsEncryptionEnabled;
                        asrProtectionProfile.RecoveryPoints 
                            = details.RecoveryPointHistoryDuration;
                    }
                    else if (profile.ReplicationProvider == Constants.HyperVReplica)
                    {
                        var details = DataContractUtils<HyperVReplicaProtectionProfileDetails>.Deserialize(
                            profile.ReplicationProviderSetting);

                        asrProtectionProfile.AllowReplicaDeletion = 
                            details.VmAutoDeleteOption == "OnRecoveryCloud";
                        asrProtectionProfile.ApplicationConsistentSnapshotFrequencyInHours = 
                            details.AppConsistencyFreq;

                        asrProtectionProfile.CompressionEnabled = details.IsCompressionEnabled;

                        asrProtectionProfile.RecoveryAzureStorageAccount = null;
                        asrProtectionProfile.RecoveryAzureSubscription = null;
                        asrProtectionProfile.ReplicationFrequencySecond = 0;

                        asrProtectionProfile.RecoveryPoints = details.NosOfRps;
                        asrProtectionProfile.ReplicationMethod = details.IsOnlineIr ? 
                            Constants.OnlineReplicationMethod : 
                            Constants.OfflineReplicationMethod;
                        asrProtectionProfile.ReplicationPort = details.RecoveryHttpsPort;
                        asrProtectionProfile.ReplicationStartTime = details.OnlineIrStartTime;
                    }

                    asrProtectionProfile.ID = profile.ID;
                    asrProtectionProfile.Name = profile.Name;
                    asrProtectionProfile.ReplicationType = profile.ReplicationProvider;
                    asrProtectionProfile.CanDissociate = profile.CanDissociate;

                    this.AvailableProtectionProfiles.Add(asrProtectionProfile);
                }
            }

            this.ID = pc.ID;
            this.Name = pc.Name;
            this.Role = pc.Role;
            this.ServerId = pc.ServerId;
            this.FabricObjectId = pc.FabricObjectId;
            this.FabricType = pc.FabricType;
            this.Type = pc.Type;
        }

        #region Properties
        /// <summary>
        /// Gets or sets name of the Protection container.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Protection container ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets Protection container's FabricObjectId.
        /// </summary>
        public string FabricObjectId { get; set; }

        /// <summary>
        /// Gets or sets the type of Fabric - VMM.
        /// </summary>
        [DataMember]
        public string FabricType { get; set; }

        /// <summary>
        /// Gets or sets the type e.g. VMM, HyperVSite etc.
        /// </summary>
        [DataMember]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Server ID.
        /// </summary>
        public string ServerId { get; set; }

        /// <summary>
        /// Gets or sets a role of the protection container.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the list of protection profiles.
        /// </summary>
        [DataMember]
        public List<ASRProtectionProfile> AvailableProtectionProfiles { get; set; }
        #endregion
    }

    /// <summary>
    /// Azure Site Recovery Virtual Machine.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRVirtualMachine : ASRProtectionEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVirtualMachine" /> class.
        /// </summary>
        public ASRVirtualMachine()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVirtualMachine" /> class.
        /// </summary>
        /// <param name="vm">Virtual Machine</param>
        public ASRVirtualMachine(VirtualMachine vm)
            : base(
                vm.ID,
                vm.ServerId,
                vm.ProtectionContainerId,
                vm.Name,
                vm.Type,
                vm.FabricObjectId,
                vm.Protected,
                vm.CanCommit,
                vm.CanFailover,
                vm.CanReverseReplicate,
                vm.ActiveLocation,
                vm.ProtectionStateDescription,
                vm.TestFailoverStateDescription,
                vm.ReplicationHealth,
                vm.ReplicationProvider)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVirtualMachine" /> class with required 
        /// parameters.
        /// </summary>
        /// <param name="id">Virtual Machine ID</param>
        /// <param name="serverId">Server ID</param>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="name">Name of the Virtual Machine</param>
        /// <param name="type">Virtual Machine type</param>
        /// <param name="fabricObjectId">Fabric object ID</param>
        /// <param name="protectedOrNot">Can protected or not</param>
        /// <param name="canCommit">Can commit or not</param>
        /// <param name="canFailover">Can failover or not</param>
        /// <param name="canReverseReplicate">Can reverse replicate or not</param>
        /// <param name="activeLocation">Active location</param>
        /// <param name="protectionStateDescription">Protection state</param>
        /// <param name="testFailoverStateDescription">Test fail over state</param>
        /// <param name="replicationHealth">Replication health</param>
        /// <param name="replicationProvider">Replication provider</param>
        public ASRVirtualMachine(
            string id,
            string serverId,
            string protectionContainerId,
            string name,
            string type,
            string fabricObjectId,
            bool protectedOrNot,
            bool canCommit,
            bool canFailover,
            bool canReverseReplicate,
            string activeLocation,
            string protectionStateDescription,
            string testFailoverStateDescription,
            string replicationHealth,
            string replicationProvider)
            : base(
                id,
                serverId,
                protectionContainerId,
                name,
                type,
                fabricObjectId,
                protectedOrNot,
                canCommit,
                canFailover,
                canReverseReplicate,
                activeLocation,
                protectionStateDescription,
                testFailoverStateDescription,
                replicationHealth,
                replicationProvider)
        {
        }
    }

    /// <summary>
    /// Azure Site Recovery Virtual Machine Group.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRVirtualMachineGroup : ASRProtectionEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVirtualMachineGroup" /> class.
        /// </summary>
        public ASRVirtualMachineGroup()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVirtualMachineGroup" /> class with 
        /// required parameters.
        /// </summary>
        /// <param name="id">Virtual Machine group ID</param>
        /// <param name="serverId">Server ID</param>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="name">Name of the Virtual Machine</param>
        /// <param name="type">Virtual Machine type</param>
        /// <param name="fabricObjectId">Fabric object ID</param>
        /// <param name="protectedOrNot">Can protected or not</param>
        /// <param name="canCommit">Can commit or not</param>
        /// <param name="canFailover">Can failover or not</param>
        /// <param name="canReverseReplicate">Can reverse replicate or not</param>
        /// <param name="activeLocation">Active location</param>
        /// <param name="protectionState">Protection state</param>
        /// <param name="testFailoverState">Test fail over state</param>
        /// <param name="replicationHealth">Replication health</param>
        /// <param name="replicationProvider">Replication provider</param>
        /// <param name="virtualMachineList">List of Virtual Machines</param>
        public ASRVirtualMachineGroup(
            string id,
            string serverId,
            string protectionContainerId,
            string name,
            string type,
            string fabricObjectId,
            bool protectedOrNot,
            bool canCommit,
            bool canFailover,
            bool canReverseReplicate,
            string activeLocation,
            string protectionState,
            string testFailoverState,
            string replicationHealth,
            string replicationProvider,
            IList<VirtualMachine> virtualMachineList)
            : base(
                id,
                serverId,
                protectionContainerId,
                name,
                type,
                fabricObjectId,
                protectedOrNot,
                canCommit,
                canFailover,
                canReverseReplicate,
                activeLocation,
                protectionState,
                testFailoverState,
                replicationHealth,
                replicationProvider)
        {
            this.VirtualMachineList = new List<ASRVirtualMachine>();
            foreach (var vm in virtualMachineList)
            {
                this.VirtualMachineList.Add(
                    new ASRVirtualMachine(
                    vm.ID,
                    vm.ServerId,
                    vm.ProtectionContainerId,
                    vm.Name,
                    vm.Type,
                    vm.FabricObjectId,
                    vm.Protected,
                    vm.CanCommit,
                    vm.CanFailover,
                    vm.CanReverseReplicate,
                    vm.ActiveLocation,
                    vm.ProtectionStateDescription,
                    vm.TestFailoverStateDescription,
                    vm.ReplicationHealth,
                    vm.ReplicationProvider));
            }
        }

        /// <summary>
        /// Gets or sets Virtual Machine list.
        /// </summary>
        public List<ASRVirtualMachine> VirtualMachineList { get; set; }
    }

    /// <summary>
    /// Azure Site Recovery Protection Entity.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRProtectionEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRProtectionEntity" /> class.
        /// </summary>
        public ASRProtectionEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRProtectionEntity" /> class.
        /// </summary>
        /// <param name="pe">Protection entity object to read values from.</param>
        public ASRProtectionEntity(ProtectionEntity pe)
        {
            this.ID = pe.ID;
            this.ServerId = pe.ServerId;
            this.ProtectionContainerId = pe.ProtectionContainerId;
            this.Name = pe.Name;
            this.Type = pe.Type;
            this.FabricObjectId =
                (0 == string.Compare(this.Type, "VirtualMachine", StringComparison.OrdinalIgnoreCase)) ?
                pe.FabricObjectId.ToUpper() :
                pe.FabricObjectId;
            this.Protected = pe.Protected;
            this.ProtectionStateDescription = pe.ProtectionStateDescription;
            this.CanCommit = pe.CanCommit;
            this.CanFailover = pe.CanFailover;
            this.CanReverseReplicate = pe.CanReverseReplicate;
            this.ReplicationProvider = pe.ReplicationProvider;
            this.ActiveLocation = pe.ActiveLocation;
            this.ReplicationHealth = pe.ReplicationHealth;
            this.TestFailoverStateDescription = pe.TestFailoverStateDescription;
            this.ProtectionProfileId = pe.ProtectionProfileId;

            if (!string.IsNullOrWhiteSpace(pe.ReplicationProviderSettings))
            {
                var diskDetails = DataContractUtils<AzureVmDiskDetails>.Deserialize(
                    pe.ReplicationProviderSettings);
                this.OS = diskDetails.OsType;
                this.OSDiskName = diskDetails.OsDisk;

                if (diskDetails.Disks != null)
                {
                    this.Disks = new List<VirtualHardDisk>();
                    foreach (var disk in diskDetails.Disks)
                    {
                        var vhd = new VirtualHardDisk();
                        vhd.Id = disk.Id;
                        vhd.Name = disk.Name;
                        this.Disks.Add(vhd);

                        if (this.OSDiskName == disk.Name)
                        {
                            this.OSDiskId = disk.Id;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRProtectionEntity" /> class with 
        /// required parameters.
        /// </summary>
        /// <param name="protectionEntityId">Protection Entity ID</param>
        /// <param name="serverId">Server ID</param>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="name">Name of the Virtual Machine</param>
        /// <param name="type">Virtual Machine type</param>
        /// <param name="fabricObjectId">Fabric object ID</param>
        /// <param name="protectedOrNot">Can protected or not</param>
        /// <param name="canCommit">Can commit or not</param>
        /// <param name="canFailover">Can failover or not</param>
        /// <param name="canReverseReplicate">Can reverse replicate or not</param>
        /// <param name="activeLocation">Active location</param>
        /// <param name="protectionStateDescription">Protection state</param>
        /// <param name="testFailoverStateDescription">Test fail over state</param>
        /// <param name="replicationHealth">Replication health</param>
        /// <param name="replicationProvider">Replication provider</param>
        public ASRProtectionEntity(
            string protectionEntityId,
            string serverId,
            string protectionContainerId,
            string name,
            string type,
            string fabricObjectId,
            bool protectedOrNot,
            bool canCommit,
            bool canFailover,
            bool canReverseReplicate,
            string activeLocation,
            string protectionStateDescription,
            string testFailoverStateDescription,
            string replicationHealth,
            string replicationProvider)
        {
            this.ID = protectionEntityId;
            this.ServerId = serverId;
            this.ProtectionContainerId = protectionContainerId;
            this.Name = name;
            this.Type = type;
            this.FabricObjectId =
                (0 == string.Compare(this.Type, "VirtualMachine", StringComparison.OrdinalIgnoreCase)) ?
                fabricObjectId.ToUpper() :
                fabricObjectId;
            this.Protected = protectedOrNot;
            this.ProtectionStateDescription = protectionStateDescription;
            this.CanCommit = canCommit;
            this.CanFailover = canFailover;
            this.CanReverseReplicate = canReverseReplicate;
            this.ReplicationProvider = replicationProvider;
            this.ActiveLocation = activeLocation;
            this.ReplicationHealth = replicationHealth;
            this.TestFailoverStateDescription = testFailoverStateDescription;
        }

        /// <summary>
        /// Gets or sets Name of the Protection entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Protection entity ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets fabric object ID.
        /// </summary>
        public string FabricObjectId { get; set; }

        /// <summary>
        /// Gets or sets Protection container ID.
        /// </summary>
        public string ProtectionContainerId { get; set; }

        /// <summary>
        /// Gets or sets Server ID.
        /// </summary>
        public string ServerId { get; set; }

        /// <summary>
        /// Gets or sets type of the Protection entity.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is protected or not.
        /// </summary>
        public bool Protected { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it can be committed or not.
        /// </summary>
        public bool CanCommit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it can be failed over or not.
        /// </summary>
        public bool CanFailover { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it can be reverse replicated or not.
        /// </summary>
        public bool CanReverseReplicate { get; set; }

        /// <summary>
        /// Gets or sets a active location of protection entity.
        /// </summary>
        public string ActiveLocation { get; set; }

        /// <summary>
        /// Gets or sets protection state.
        /// </summary>
        public string ProtectionStateDescription { get; set; }

        /// <summary>
        /// Gets or sets Replication health.
        /// </summary>
        public string ReplicationHealth { get; set; }

        /// <summary>
        /// Gets or sets test failover state.
        /// </summary>
        public string TestFailoverStateDescription { get; set; }

        /// <summary>
        /// Gets or sets ProtectionProfileId.
        /// </summary>
        public string ProtectionProfileId { get; set; }

        /// <summary>
        /// Gets or sets OSDiskVHDId.
        /// </summary>
        public string OSDiskId { get; set; }

        /// <summary>
        /// Gets or sets OS DiskName.
        /// </summary>
        public string OSDiskName { get; set; }

        /// <summary>
        /// Gets or sets OS.
        /// </summary>
        public string OS { get; set; }

        /// <summary>
        /// Gets or sets OS.
        /// </summary>
        public List<VirtualHardDisk> Disks { get; set; }

        /// <summary>
        /// Gets or sets Replication provider.
        /// </summary>
        public string ReplicationProvider { get; set; }
    }

    /// <summary>
    /// Task of the Job.
    /// </summary>
    public class ASRTask
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRTask" /> class.
        /// </summary>
        public ASRTask()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRTask" /> class.
        /// </summary>
        /// <param name="task">Task details to load values from.</param>
        public ASRTask(AsrTask task)
        {
            this.ID = task.ID;
            this.EndTime = task.EndTime;
            this.Name = task.Name;
            this.StartTime = task.StartTime;
            this.State = task.State;
            this.StateDescription = task.StateDescription;
        }

        /// <summary>
        /// Gets or sets the task name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Job ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the State description, which tells the exact internal state.
        /// </summary>
        public string StateDescription { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        public DateTime EndTime { get; set; }
    }
    
    /// <summary>
    /// Azure Site Recovery Job.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRJob
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRJob" /> class.
        /// </summary>
        public ASRJob()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRJob" /> class with required parameters.
        /// </summary>
        /// <param name="job">ASR Job object</param>
        public ASRJob(Job job)
        {
            this.ID = job.ID;
            this.ClientRequestId = job.ActivityId;
            this.State = job.State;
            this.StateDescription = job.StateDescription;
            this.EndTime = job.EndTimestamp;
            this.StartTime = job.StartTimestamp;
            this.AllowedActions = job.AllowedActions as List<string>;
            this.Name = job.Name;
            this.Tasks = new List<ASRTask>();
            foreach (var task in job.Tasks)
            {
                this.Tasks.Add(new ASRTask(task));
            }

            this.Errors = new List<ASRErrorDetails>();

            foreach (var error in job.Errors)
            {
                ASRErrorDetails errorDetails = new ASRErrorDetails();
                errorDetails.TaskId = error.TaskId;
                errorDetails.ServiceErrorDetails = new ASRServiceError(error.ServiceErrorDetails);
                errorDetails.ProviderErrorDetails = new ASRProviderError(error.ProviderErrorDetails);
                this.Errors.Add(errorDetails);
            }
        }

        #region Properties
        /// <summary>
        /// Gets or sets Job display name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Job ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets Activity ID.
        /// </summary>
        public string ClientRequestId { get; set; }

        /// <summary>
        /// Gets or sets State of the Job.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets StateDescription of the Job.
        /// </summary>
        public string StateDescription { get; set; }

        /// <summary>
        /// Gets or sets Start timestamp.
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets End timestamp.
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// Gets or sets list of allowed actions.
        /// </summary>
        public List<string> AllowedActions { get; set; }

        /// <summary>
        /// Gets or sets list of tasks.
        /// </summary>
        public List<ASRTask> Tasks { get; set; }

        /// <summary>
        /// Gets or sets list of Errors.
        /// </summary>
        public List<ASRErrorDetails> Errors { get; set; }
        #endregion
    }

    /// <summary>
    /// This class contains the error details per object.
    /// </summary>
    public class ASRErrorDetails
    {
        /// <summary>
        /// Gets or sets the Service error details.
        /// </summary>
        public ASRServiceError ServiceErrorDetails { get; set; }

        /// <summary>
        /// Gets or sets the Provider error details.
        /// </summary>
        public ASRProviderError ProviderErrorDetails { get; set; }

        /// <summary>
        /// Gets or sets the Id of the task.
        /// </summary>
        public string TaskId { get; set; }
    }

    /// <summary>
    /// This class contains the ASR error details per object.
    /// </summary>
    public class ASRServiceError : Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRServiceError" /> class with required parameters.
        /// </summary>
        public ASRServiceError()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRServiceError" /> class with required parameters.
        /// </summary>
        /// <param name="serviceError">ServiceError object</param>
        public ASRServiceError(ServiceError serviceError)
            : base(serviceError)
        {
        }
    }

    /// <summary>
    /// Class to define the output of the vault credential generation.
    /// </summary>
    public class VaultCredentialOutput
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VaultCredentialOutput" /> class
        /// </summary>
        public VaultCredentialOutput()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the path of generated credential file.
        /// </summary>
        public string FilePath { get; set; }

        #endregion
    }

    /// <summary>
    /// Class to define the output object for the vault operations.
    /// </summary>
    public class VaultOperationOutput
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VaultOperationOutput" /> class
        /// </summary>
        public VaultOperationOutput()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the operation tracking id of the operation performed.
        /// </summary>
        public string OperationTrackingId { get; set; }

        #endregion
    }

    /// <summary>
    /// This class contains the provider error details per object.
    /// </summary>
    public class ASRProviderError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRProviderError" /> class with required parameters.
        /// </summary>
        public ASRProviderError()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRProviderError" /> class with required parameters.
        /// </summary>
        /// <param name="error">ProviderError object</param>
        public ASRProviderError(ProviderError error)
        {
            this.AffectedObjects = error.AffectedObjects;
            this.CreationTimeUtc = error.CreationTimeUtc;
            this.ErrorCode = error.ErrorCode;
            this.ErrorId = error.ErrorId;
            this.ErrorLevel = error.ErrorLevel;
            this.ErrorMessage = error.ErrorMessage;
            this.WorkflowId = error.WorkflowId;
        }

        /// <summary>
        /// Gets or sets the Error code.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the Error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the Provider error Id
        /// </summary>
        public string ErrorId { get; set; }

        /// <summary>
        /// Gets or sets Workflow Id.
        /// </summary>
        public string WorkflowId { get; set; }

        /// <summary>
        /// Gets or sets the AffectedObjects.
        /// </summary>
        public IDictionary<string, string> AffectedObjects { get; set; }

        /// <summary>
        /// Gets or sets the Time of the error creation.
        /// </summary>
        public DateTime CreationTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the Error level.
        /// </summary>
        public string ErrorLevel { get; set; }
    }

    /// <summary>
    /// Protection profile association details.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related public classes together.")]
    public class ASRProtectionProfileAssociationDetails
    {
        /// <summary>
        /// Gets or sets the PrimaryProtectionContainerId.
        /// </summary>
        [DataMember(Order = 1)]
        public string PrimaryProtectionContainerId { get; set; }

        /// <summary>
        /// Gets or sets the RecoveryProtectionContainerId.
        /// </summary>
        [DataMember(Order = 2)]
        public string RecoveryProtectionContainerId { get; set; }       
        
        /// <summary>
        /// Gets or sets the association status. This is a string representation of the 
        /// enumeration type <see cref="CloudPairingStatus"/>.
        /// </summary>
        [DataMember(Order = 3)]
        public string AssociationStatus { get; set; }
    }

    /// <summary>
    /// Azure Site Recovery Protection Profile.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRProtectionProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRProtectionProfile" /> class.
        /// </summary>
        public ASRProtectionProfile()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRProtectionProfile" /> class with 
        /// required parameters.
        /// </summary>
        /// <param name="protectionProfile">Protection container object</param>
        public ASRProtectionProfile(ProtectionProfile protectionProfile)
        {
            this.ID = protectionProfile.ID;
            this.Name = protectionProfile.Name;
            this.ReplicationType = protectionProfile.ReplicationProvider;
        }

        #region Properties
        /// <summary>
        /// Gets or sets name of the Protection profile.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Protection profile ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets Replication Type (HyperVReplica, HyperVReplicaAzure)
        /// </summary>
        public string ReplicationType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether profile can be dissociated or not.
        /// </summary>
        public bool CanDissociate { get; set; }

        /// <summary>
        /// Gets or sets Replication Method.
        /// </summary>
        public string ReplicationMethod { get; set; }

        /////// <summary>
        /////// Gets or sets Recovery Protection Container.
        /////// </summary>
        ////public ProtectionContainer RecoveryProtectionContainer { get; set; }

        /// <summary>
        /// Gets or sets Association Details.
        /// </summary>
        public List<ASRProtectionProfileAssociationDetails> AssociationDetail { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Subscription.
        /// </summary>
        public string RecoveryAzureSubscription { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Storage Account.
        /// </summary>
        public string RecoveryAzureStorageAccount { get; set; }

        /// <summary>
        /// Gets or sets Replication Frequency in seconds.
        /// </summary>
        public int ReplicationFrequencySecond { get; set; }

        /// <summary>
        /// Gets or sets Recovery Points.
        /// </summary>
        public int RecoveryPoints { get; set; }

        /// <summary>
        /// Gets or sets Application Consistent Snapshot Frequency in hours.
        /// </summary>
        public int ApplicationConsistentSnapshotFrequencyInHours { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Compression is Enabled.
        /// </summary>
        public bool CompressionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the replication port.
        /// </summary>
        public int ReplicationPort { get; set; }

        /// <summary>
        /// Gets or sets Replication Start Time.
        /// </summary>
        public TimeSpan? ReplicationStartTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Replica Deletion should be enabled.
        /// </summary>
        public bool AllowReplicaDeletion { get; set; }

        #endregion
    }

    /// <summary>
    /// Disk details.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related classes together.")]
    public class VirtualHardDisk
    {
        /// <summary>
        /// Gets or sets the VHD id.
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}