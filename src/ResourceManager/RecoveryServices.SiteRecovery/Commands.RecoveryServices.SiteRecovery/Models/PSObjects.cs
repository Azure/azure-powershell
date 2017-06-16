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
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Azure Site Recovery Vault Settings.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRVaultSettings
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRVaultSettings" /> class.
        /// </summary>
        public ASRVaultSettings()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRVaultSettings" /> class
        /// </summary>
        /// <param name="asrVaultCreds">Vault credentails</param>
        public ASRVaultSettings(ASRVaultCreds asrVaultCreds)
        {
            ResourceName = asrVaultCreds.ResourceName;
            ResourceGroupName = asrVaultCreds.ResourceGroupName;
            ResourceNamespace = asrVaultCreds.ResourceNamespace;
            ResouceType = asrVaultCreds.ARMResourceType;
        }

        #region Properties

        /// <summary>
        ///     Gets or sets Resource Name.
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        ///     Gets or sets Resource Group Name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        ///     Gets or sets Resource Provider Namespace.
        /// </summary>
        public string ResourceNamespace { get; set; }

        /// <summary>
        ///     Gets or sets Resource Type.
        /// </summary>
        public string ResouceType { get; set; }

        #endregion Properties
    }

    /// <summary>
    ///     Azure Site Recovery Server.
    /// </summary>
    public class ASRRecoveryServicesProvider
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRRecoveryServicesProvider" /> class.
        /// </summary>
        public ASRRecoveryServicesProvider()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRRecoveryServicesProvider" /> class with
        ///     required
        ///     parameters.
        /// </summary>
        /// <param name="server">Server object</param>
        public ASRRecoveryServicesProvider(RecoveryServicesProvider provider)
        {
            ID = provider.Id;
            Name = provider.Name;
            FriendlyName = provider.Properties.FriendlyName;
            if (provider.Properties.LastHeartBeat != null)
            {
                LastHeartbeat = (DateTime) provider.Properties.LastHeartBeat;
            }
            ProviderVersion = provider.Properties.ProviderVersion;
            ServerVersion = provider.Properties.ServerVersion;
            Connected = provider.Properties.ConnectionStatus.ToLower()
                            .CompareTo("connected") ==
                        0 ? true : false;
            FabricType = provider.Properties.FabricType;
            Type = provider.Type;
        }

        #region Properties

        /// <summary>
        ///     Gets or sets Name of the Server.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Name of the Server.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Server ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets the Type of Management entity – VMM, V-Center.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the type of Server - VMM.
        /// </summary>
        public string FabricType { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether server is connected or not.
        /// </summary>
        public bool Connected { get; set; }

        /// <summary>
        ///     Gets or sets Last communicated time.
        /// </summary>
        public DateTime LastHeartbeat { get; set; }

        /// <summary>
        ///     Gets or sets Provider version.
        /// </summary>
        public string ProviderVersion { get; set; }

        /// <summary>
        ///     Gets or sets Server version.
        /// </summary>
        public string ServerVersion { get; set; }

        #endregion
    }

    /// <summary>
    ///     Azure Site Recovery Site object.
    /// </summary>
    public class ASRFabric
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRSite" /> class.
        /// </summary>
        public ASRFabric()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRSite" /> class.
        /// </summary>
        /// <param name="site">Hydra site object.</param>
        public ASRFabric(Fabric fabric)
        {
            Name = fabric.Name;
            FriendlyName = fabric.Properties.FriendlyName;
            ID = fabric.Id;
            Type = fabric.Type;
            SiteIdentifier = fabric.Properties.InternalIdentifier;
            fabricSpecificDetails = fabric.Properties.CustomDetails;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets display name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets friendly name.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets site type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets site SiteIdentifier.
        /// </summary>
        public string SiteIdentifier { get; set; }

        /// <summary>
        ///     Gets or sets site SiteIdentifier.
        /// </summary>
        public FabricSpecificDetails fabricSpecificDetails { get; set; }

        #endregion
    }

    /// <summary>
    ///     Azure Site Recovery Protection Container Mapping.
    /// </summary>
    public class ASRProtectionContainerMapping
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRProtectionContainerMapping" /> class.
        /// </summary>
        public ASRProtectionContainerMapping()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRProtectionContainerMapping" /> class with
        ///     required parameters.
        /// </summary>
        /// <param name="pc">Protection container mapping object</param>
        public ASRProtectionContainerMapping(ProtectionContainerMapping pcm)
        {
            Name = pcm.Name;
            ID = pcm.Id;
            Health = pcm.Properties.Health;
            HealthErrorDetails = pcm.Properties.HealthErrorDetails;
            PolicyFriendlyName = pcm.Properties.PolicyFriendlyName;
            PolicyId = pcm.Properties.PolicyId;
            SourceFabricFriendlyName = pcm.Properties.SourceFabricFriendlyName;
            SourceProtectionContainerFriendlyName =
                pcm.Properties.SourceProtectionContainerFriendlyName;
            State = pcm.Properties.State;
            TargetFabricFriendlyName = pcm.Properties.TargetFabricFriendlyName;
            TargetProtectionContainerFriendlyName =
                pcm.Properties.TargetProtectionContainerFriendlyName;
            TargetProtectionContainerId = pcm.Properties.TargetProtectionContainerId;
        }

        #region Properties

        /// <summary>
        ///     Gets or sets name of the Protection Container Mapping.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Protection container Mapping ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets Health
        /// </summary>
        public string Health { get; set; }

        /// <summary>
        ///     Gets or sets Health Error Details
        /// </summary>
        public IList<HealthError> HealthErrorDetails { get; set; }

        /// <summary>
        ///     Gets or sets Policy Friendly Name
        /// </summary>
        public string PolicyFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Policy Id
        /// </summary>
        public string PolicyId { get; set; }

        /// <summary>
        ///     Gets or sets Source Fabric Friendly Name
        /// </summary>
        public string SourceFabricFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Source Protection Container Friendly Name
        /// </summary>
        public string SourceProtectionContainerFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     Gets or sets Target Fabric Friendly Name
        /// </summary>
        public string TargetFabricFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Target Protection Container Friendly Name
        /// </summary>
        public string TargetProtectionContainerFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Target Protection Container Id
        /// </summary>
        public string TargetProtectionContainerId { get; set; }

        #endregion
    }

    /// <summary>
    ///     Azure Site Recovery Protection Container.
    /// </summary>
    public class ASRProtectionContainer
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRProtectionContainer" /> class.
        /// </summary>
        public ASRProtectionContainer()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRProtectionContainer" /> class with
        ///     required parameters.
        /// </summary>
        /// <param name="pc">Protection container object</param>
        public ASRProtectionContainer(ProtectionContainer pc,
            List<ASRPolicy> availablePolicies,
            List<ASRProtectionContainerMapping> protectionContainerMappings)
        {
            ID = pc.Id;
            Name = pc.Name;
            FriendlyName = pc.Properties.FriendlyName;
            FabricFriendlyName = pc.Properties.FabricFriendlyName;
            Role = pc.Properties.Role;
            FabricType = pc.Properties.FabricType;
            Type = pc.Type;
            AvailablePolicies = availablePolicies;
            ProtectionContainerMappings = protectionContainerMappings;
        }

        #region Properties

        /// <summary>
        ///     Gets or sets name of the Protection container.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets name of the Protection container.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Protection container ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets the type e.g. VMM, HyperVSite, etc.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed.")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets Protection container's Fabric Friendly Name.
        /// </summary>
        public string FabricFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets the type of Fabric - VMM.
        /// </summary>
        public string FabricType { get; set; }

        /// <summary>
        ///     Gets or sets a role of the protection container.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        ///     Gets or sets the list of Policies.
        /// </summary>
        public List<ASRPolicy> AvailablePolicies { get; set; }

        /// <summary>
        ///     Gets or sets the list of Protection Container Mappings.
        /// </summary>
        public List<ASRProtectionContainerMapping> ProtectionContainerMappings { get; set; }

        #endregion
    }

    /// <summary>
    ///     Azure Site Recovery Policy.
    /// </summary>
    public class ASRPolicy
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRPolicy" /> class.
        /// </summary>
        public ASRPolicy()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRPolicy" /> class with
        ///     required parameters.
        /// </summary>
        /// <param name="policy">Protection container object</param>
        public ASRPolicy(Policy policy)
        {
            ID = policy.Id;
            Name = policy.Name;
            FriendlyName = policy.Properties.FriendlyName;
            Type = policy.Type;

            if (policy.Properties.ProviderSpecificDetails is HyperVReplicaBluePolicyDetails)
            {
                var details =
                    (HyperVReplicaBluePolicyDetails) policy.Properties.ProviderSpecificDetails;

                var replicationProviderSettings = new ASRHyperVReplicaPolicyDetails();

                ReplicationProvider = Constants.HyperVReplica2012R2;
                replicationProviderSettings.ReplicaDeletionOption = details.ReplicaDeletionOption;
                replicationProviderSettings.ApplicationConsistentSnapshotFrequencyInHours =
                    (int) details.ApplicationConsistentSnapshotFrequencyInHours;
                replicationProviderSettings.Compression = details.Compression;
                replicationProviderSettings.ReplicationFrequencyInSeconds = 300;
                replicationProviderSettings.AllowedAuthenticationType =
                    details.AllowedAuthenticationType == 1 ? Constants.AuthenticationTypeKerberos
                        : Constants.AuthenticationTypeCertificate;
                replicationProviderSettings.RecoveryPoints = (int) details.RecoveryPoints;
                replicationProviderSettings.InitialReplicationMethod =
                    string.Compare(details.InitialReplicationMethod,
                        "OverNetwork",
                        StringComparison.OrdinalIgnoreCase) ==
                    0 ? Constants.OnlineReplicationMethod : Constants.OfflineReplicationMethod;
                replicationProviderSettings.ReplicationPort = (ushort) details.ReplicationPort;
                replicationProviderSettings.OnlineReplicationStartTime =
                    details.OnlineReplicationStartTime == null ? (TimeSpan?) null
                        : TimeSpan.Parse(details.OnlineReplicationStartTime);

                ReplicationProviderSettings = replicationProviderSettings;
            }
            else if (policy.Properties.ProviderSpecificDetails is HyperVReplicaPolicyDetails)
            {
                var details =
                    (HyperVReplicaPolicyDetails) policy.Properties.ProviderSpecificDetails;

                var replicationProviderSettings = new ASRHyperVReplicaPolicyDetails();

                ReplicationProvider = Constants.HyperVReplica2012;
                replicationProviderSettings.ReplicaDeletionOption = details.ReplicaDeletionOption;
                replicationProviderSettings.ApplicationConsistentSnapshotFrequencyInHours =
                    (int) details.ApplicationConsistentSnapshotFrequencyInHours;
                replicationProviderSettings.Compression = details.Compression;
                replicationProviderSettings.AllowedAuthenticationType =
                    details.AllowedAuthenticationType == 1 ? Constants.AuthenticationTypeKerberos
                        : Constants.AuthenticationTypeCertificate;
                replicationProviderSettings.RecoveryPoints = (int) details.RecoveryPoints;
                replicationProviderSettings.InitialReplicationMethod =
                    string.Compare(details.InitialReplicationMethod,
                        "OverNetwork",
                        StringComparison.OrdinalIgnoreCase) ==
                    0 ? Constants.OnlineReplicationMethod : Constants.OfflineReplicationMethod;
                replicationProviderSettings.ReplicationPort = (ushort) details.ReplicationPort;
                replicationProviderSettings.OnlineReplicationStartTime =
                    details.OnlineReplicationStartTime == null ? (TimeSpan?) null
                        : TimeSpan.Parse(details.OnlineReplicationStartTime);

                ReplicationProviderSettings = replicationProviderSettings;
            }
            else if (policy.Properties.ProviderSpecificDetails is HyperVReplicaAzurePolicyDetails)
            {
                var details =
                    (HyperVReplicaAzurePolicyDetails) policy.Properties.ProviderSpecificDetails;

                var replicationProviderSettings = new ASRHyperVReplicaAzurePolicyDetails();

                ReplicationProvider = Constants.HyperVReplicaAzure;
                replicationProviderSettings.ApplicationConsistentSnapshotFrequencyInHours =
                    (int) details.ApplicationConsistentSnapshotFrequencyInHours;
                replicationProviderSettings.ReplicationFrequencyInSeconds =
                    (int) details.ReplicationInterval;
                replicationProviderSettings.RecoveryPoints =
                    (int) details.RecoveryPointHistoryDurationInHours;
                replicationProviderSettings.OnlineReplicationStartTime =
                    details.OnlineReplicationStartTime == null ? (TimeSpan?) null
                        : TimeSpan.Parse(details.OnlineReplicationStartTime);
                replicationProviderSettings.Encryption = details.Encryption;
                replicationProviderSettings.ActiveStorageAccountId = details.ActiveStorageAccountId;

                ReplicationProviderSettings = replicationProviderSettings;
            }
        }

        #region Properties

        /// <summary>
        ///     Gets or sets friendly name of the Policy.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets name of the Policy.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Policy ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets Policy type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets Replication Type (HyperVReplica, HyperVReplicaAzure, San)
        /// </summary>
        public string ReplicationProvider { get; set; }

        /// <summary>
        ///     Gets or sets HyperVReplicaProviderSettings
        /// </summary>
        // public HyperVReplicaProviderSettings ReplicationProviderSettings { get; set; }
        public ASRPolicyProviderSettingsDetails ReplicationProviderSettings { get; set; }

        #endregion Properties
    }

    /// <summary>
    ///     Policy provider settings
    /// </summary>
    public class ASRPolicyProviderSettingsDetails
    {
    }

    // Summary:
    //     HyperV Replica Policy Details.
    public class ASRHyperVReplicaPolicyDetails : ASRPolicyProviderSettingsDetails
    {
        // Summary:
        //     Optional.
        public string AllowedAuthenticationType { get; set; }

        //
        // Summary:
        //     Optional.
        public int ApplicationConsistentSnapshotFrequencyInHours { get; set; }

        //
        // Summary:
        //     Optional.
        public string Compression { get; set; }

        //
        // Summary:
        //     Optional.
        public string InitialReplicationMethod { get; set; }

        //
        // Summary:
        //     Optional.
        public string OfflineReplicationExportPath { get; set; }

        //
        // Summary:
        //     Optional.
        public string OfflineReplicationImportPath { get; set; }

        //
        // Summary:
        //     Optional.
        public TimeSpan? OnlineReplicationStartTime { get; set; }

        //
        // Summary:
        //     Optional.
        public int RecoveryPoints { get; set; }

        //
        // Summary:
        //     Optional.
        public string ReplicaDeletionOption { get; set; }

        //
        // Summary:
        //     Optional.
        public ushort ReplicationFrequencyInSeconds { get; set; }

        //
        // Summary:
        //     Optional.
        public ushort ReplicationPort { get; set; }
    }

    /// <summary>
    ///     ASR HyperV Replica Azure enable protection input.
    /// </summary>
    public class ASRHyperVReplicaAzurePolicyDetails : ASRPolicyProviderSettingsDetails
    {
        // Summary:
        //     Optional.
        public string ActiveStorageAccountId { get; set; }

        //
        // Summary:
        //     Optional.
        public int ApplicationConsistentSnapshotFrequencyInHours { get; set; }

        //
        // Summary:
        //     Optional.
        public string Encryption { get; set; }

        //
        // Summary:
        //     Optional.
        public TimeSpan? OnlineReplicationStartTime { get; set; }

        //
        // Summary:
        //     Optional.
        public int RecoveryPoints { get; set; }

        //
        // Summary:
        //     Optional.
        public int ReplicationFrequencyInSeconds { get; set; }
    }

    /// <summary>
    ///     ASR VM Nic Details
    /// </summary>
    public class ASRVMNicDetails
    {
        /// <summary>
        ///     Gets or sets the nic Id.
        /// </summary>
        public string NicId { get; set; }

        /// <summary>
        ///     Gets or sets VM network name.
        /// </summary>
        public string VMNetworkName { get; set; }

        /// <summary>
        ///     Gets or sets VM subnet name.
        /// </summary>
        public string VMSubnetName { get; set; }

        /// <summary>
        ///     Gets or sets recovery VM network Id.
        /// </summary>
        public string RecoveryVMNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets recovery VM subnet name.
        /// </summary>
        public string RecoveryVMSubnetName { get; set; }

        /// <summary>
        ///     Gets or sets replica nic static IP address.
        /// </summary>
        public string ReplicaNicStaticIPAddress { get; set; }

        /// <summary>
        ///     Gets or sets ipv4 address type.
        /// </summary>
        public string IpAddressType { get; set; }

        /// <summary>
        ///     Gets or sets selection type for failover.
        /// </summary>
        public string SelectionType { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRVMNicDetails" /> class.
        /// </summary>
        public ASRVMNicDetails()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRVMNicDetails" /> class.
        /// </summary>
        public ASRVMNicDetails(VMNicDetails vMNicDetails)
        {
            NicId = vMNicDetails.NicId;
            VMNetworkName = vMNicDetails.VMNetworkName;
            VMSubnetName = vMNicDetails.VMSubnetName;
            RecoveryVMNetworkId = vMNicDetails.RecoveryVMNetworkId;
            RecoveryVMSubnetName = vMNicDetails.RecoveryVMSubnetName;
            ReplicaNicStaticIPAddress = vMNicDetails.ReplicaNicStaticIPAddress;
            IpAddressType = vMNicDetails.IpAddressType;
            SelectionType = vMNicDetails.SelectionType;
        }
    }

    /// <summary>
    ///     Azure Site Recovery Protectable Item
    /// </summary>
    public class ASRProtectableItem
    {
        /// <summary>
        ///     Gets or sets Friendly Name of the Protection entity.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Name of the Protection entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Protection entity ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets fabric object ID.
        /// </summary>
        public string FabricObjectId { get; set; }

        /// <summary>
        ///     Gets or sets Protection container ID.
        /// </summary>
        public string ProtectionContainerId { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether it is protected or not.
        /// </summary>
        public string ProtectionStatus { get; set; }

        /// <summary>
        ///     Gets or sets a value that lists allowed operations.
        /// </summary>
        public IList<string> ProtectionReadinessErrors { get; set; }

        /// <summary>
        ///     Gets or sets OSDiskVHDId.
        /// </summary>
        public string OSDiskId { get; set; }

        /// <summary>
        ///     Gets or sets OS DiskName.
        /// </summary>
        public string OSDiskName { get; set; }

        /// <summary>
        ///     Gets or sets OS.
        /// </summary>
        public string OS { get; set; }

        /// <summary>
        ///     Gets or sets OS.
        /// </summary>
        public List<VirtualHardDisk> Disks { get; set; }

        /// <summary>
        ///     Gets or sets Replication provider.
        /// </summary>
        public IList<string> SupportedReplicationProviders { get; set; }

        /// <summary>
        ///     Gets or sets Replication protected item id.
        /// </summary>
        public string ReplicationProtectedItemId { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRProtectableItem" /> class.
        /// </summary>
        public ASRProtectableItem()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRProtectableItem" /> class when it is not
        ///     protected
        /// </summary>
        /// <param name="pi">Protectable Item to read values from</param>
        public ASRProtectableItem(ProtectableItem pi)
        {
            ID = pi.Id;
            Name = pi.Name;
            FriendlyName = pi.Properties.FriendlyName;
            ProtectionContainerId = Utilities.GetValueFromArmId(pi.Id,
                ARMResourceTypeConstants.ReplicationProtectionContainers);
            ProtectionStatus = pi.Properties.ProtectionStatus;
            ReplicationProtectedItemId = pi.Properties.ReplicationProtectedItemId;
            SupportedReplicationProviders = pi.Properties.SupportedReplicationProviders;
            if (pi.Properties.CustomDetails != null)
            {
                if (pi.Properties.CustomDetails is HyperVVirtualMachineDetails)
                {
                    if (pi.Properties.CustomDetails is HyperVVirtualMachineDetails)
                    {
                        var providerSettings =
                            (HyperVVirtualMachineDetails) pi.Properties.CustomDetails;

                        var diskDetails = providerSettings.DiskDetails;
                        UpdateDiskDetails(diskDetails);
                        OS = providerSettings.OsDetails == null ? null
                            : providerSettings.OsDetails.OsType;
                        FabricObjectId = providerSettings.SourceItemId;
                    }
                }
            }
        }

        private void UpdateDiskDetails(IList<DiskDetails> diskDetails)
        {
            Disks = new List<VirtualHardDisk>();
            foreach (var disk in diskDetails)
            {
                var hd = new VirtualHardDisk();
                hd.Id = disk.VhdId;
                hd.Name = disk.VhdName;
                Disks.Add(hd);
            }

            var OSDisk = diskDetails.SingleOrDefault(d => string.Compare(d.VhdType,
                                                              "OperatingSystem",
                                                              StringComparison.OrdinalIgnoreCase) ==
                                                          0);
            if (OSDisk != null)
            {
                OSDiskId = OSDisk.VhdId;
                OSDiskName = OSDisk.VhdName;
            }
        }
    }

    /// <summary>
    ///     Azure Site Recovery Replication Protected Item.
    /// </summary>
    public class ASRReplicationProtectedItem
    {
        /// <summary>
        ///     Gets or sets Friendly Name of the Protection entity.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Name of the Protection entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Protection entity ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets type of the Protection entity.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets Current Scenario Details
        /// </summary>
        public CurrentScenarioDetails CurrentScenario { get; set; }

        /// <summary>
        ///     Gets or sets a value that lists allowed operations.
        /// </summary>
        public IList<string> AllowedOperations { get; set; }

        /// <summary>
        ///     Gets or sets a active location of protection entity.
        /// </summary>
        public string ActiveLocation { get; set; }

        /// <summary>
        ///     Gets or sets Replication provider.
        /// </summary>
        public string ReplicationProvider { get; set; }

        /// <summary>
        ///     Gets or sets Failover Recovery Point Id
        /// </summary>
        public string FailoverRecoveryPointId { get; set; }

        /// <summary>
        ///     Gets or sets Last Successful Failover Time
        /// </summary>
        public DateTime? LastSuccessfulFailoverTime { get; set; }

        /// <summary>
        ///     Gets or sets Last Successful TestFailover Time
        /// </summary>
        public DateTime? LastSuccessfulTestFailoverTime { get; set; }

        /// <summary>
        ///     Gets or sets Policy Friendly Name
        /// </summary>
        public string PolicyFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Policy ID
        /// </summary>
        public string PolicyID { get; set; }

        /// <summary>
        ///     Gets or sets Primary Fabric Friendly Name
        /// </summary>
        public string PrimaryFabricFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Primary Protection Container Friendly Name
        /// </summary>
        public string PrimaryProtectionContainerFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Protectable Item Id
        /// </summary>
        public string ProtectableItemId { get; set; }

        /// <summary>
        ///     Gets or sets Protected Item Type
        /// </summary>
        public string ProtectedItemType { get; set; }

        /// <summary>
        ///     Gets or sets Protection State
        /// </summary>
        public string ProtectionState { get; set; }

        /// <summary>
        ///     Gets or sets Protection State Description
        /// </summary>
        public string ProtectionStateDescription { get; set; }

        /// <summary>
        ///     Gets or sets Provider Specific Details
        /// </summary>
        public ReplicationProviderSpecificSettings ProviderSpecificDetails { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Fabric Friendly Name
        /// </summary>
        public string RecoveryFabricFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Fabric Id
        /// </summary>
        public string RecoveryFabricId { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Protection Container Friendly Name
        /// </summary>
        public string RecoveryProtectionContainerFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Services Provider Id
        /// </summary>
        public string RecoveryServicesProviderId { get; set; }

        /// <summary>
        ///     Gets or sets Replication Health
        /// </summary>
        public string ReplicationHealth { get; set; }

        /// <summary>
        ///     Gets or sets Replication Health Errors
        /// </summary>
        public IList<HealthError> ReplicationHealthErrors { get; set; }

        /// <summary>
        ///     Gets or sets Test Failover State
        /// </summary>
        public string TestFailoverState { get; set; }

        /// <summary>
        ///     Gets or sets Test Failover State Description
        /// </summary>
        public string TestFailoverStateDescription { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Azure VM Name of the Virtual machine.
        /// </summary>
        public string RecoveryAzureVMName { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Azure VM Size of the Virtual machine.
        /// </summary>
        public string RecoveryAzureVMSize { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Azure Storage Account of the Virtual machine.
        /// </summary>
        public string RecoveryAzureStorageAccount { get; set; }

        /// <summary>
        ///     Gets or sets Selected Recovery Azure Network Id of the Virtual machine.
        /// </summary>
        public string SelectedRecoveryAzureNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets Nic Details of the Virtual machine.
        /// </summary>
        public List<ASRVMNicDetails> NicDetailsList { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRReplicationProtectedItem" /> class.
        /// </summary>
        public ASRReplicationProtectedItem()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRReplicationProtectedItem" /> class when it is
        ///     protected
        /// </summary>
        /// <param name="pi">Protectable Item to read values from</param>
        /// <param name="rpi">Replication Protected Item to read values from</param>
        public ASRReplicationProtectedItem(ReplicationProtectedItem rpi)
        {
            ID = rpi.Id;
            Name = rpi.Name;
            FriendlyName = rpi.Properties.FriendlyName;
            Type = rpi.Type;
            ActiveLocation = rpi.Properties.ActiveLocation;
            AllowedOperations = rpi.Properties.AllowedOperations;
            CurrentScenario = rpi.Properties.CurrentScenario;
            FailoverRecoveryPointId = rpi.Properties.FailoverRecoveryPointId;
            LastSuccessfulFailoverTime = rpi.Properties.LastSuccessfulFailoverTime;
            LastSuccessfulTestFailoverTime = rpi.Properties.LastSuccessfulTestFailoverTime;
            PolicyFriendlyName = rpi.Properties.PolicyFriendlyName;
            PolicyID = rpi.Properties.PolicyId;
            PrimaryFabricFriendlyName = rpi.Properties.PrimaryFabricFriendlyName;
            PrimaryProtectionContainerFriendlyName =
                rpi.Properties.PrimaryProtectionContainerFriendlyName;
            ProtectableItemId = rpi.Properties.ProtectableItemId;
            ProtectedItemType = rpi.Properties.ProtectedItemType;
            ProtectionState = rpi.Properties.ProtectionState;
            ProtectionStateDescription = rpi.Properties.ProtectionStateDescription;
            RecoveryFabricFriendlyName = rpi.Properties.RecoveryFabricFriendlyName;
            RecoveryFabricId = rpi.Properties.RecoveryFabricId;
            RecoveryProtectionContainerFriendlyName =
                rpi.Properties.RecoveryProtectionContainerFriendlyName;
            RecoveryServicesProviderId = rpi.Properties.RecoveryServicesProviderId;
            ReplicationHealth = rpi.Properties.ReplicationHealth;
            ReplicationHealthErrors = rpi.Properties.ReplicationHealthErrors;
            TestFailoverState = rpi.Properties.TestFailoverState;
            TestFailoverStateDescription = rpi.Properties.TestFailoverStateDescription;

            if (rpi.Properties.ProviderSpecificDetails is HyperVReplicaAzureReplicationDetails)
            {
                var providerSpecificDetails =
                    (HyperVReplicaAzureReplicationDetails) rpi.Properties.ProviderSpecificDetails;

                ReplicationProvider = Constants.HyperVReplicaAzure;
                RecoveryAzureVMName = providerSpecificDetails.RecoveryAzureVMName;
                RecoveryAzureVMSize = providerSpecificDetails.RecoveryAzureVMSize;
                RecoveryAzureStorageAccount = providerSpecificDetails.RecoveryAzureStorageAccount;
                SelectedRecoveryAzureNetworkId = providerSpecificDetails
                    .SelectedRecoveryAzureNetworkId;
                if (providerSpecificDetails.VmNics != null)
                {
                    NicDetailsList = new List<ASRVMNicDetails>();
                    foreach (var n in providerSpecificDetails.VmNics)
                    {
                        NicDetailsList.Add(new ASRVMNicDetails(n));
                    }
                }
            }
            else if (rpi.Properties.ProviderSpecificDetails is HyperVReplicaReplicationDetails)
            {
                ReplicationProvider = Constants.HyperVReplica2012;
            }
            else if (rpi.Properties.ProviderSpecificDetails is HyperVReplicaBlueReplicationDetails)
            {
                ReplicationProvider = Constants.HyperVReplica2012R2;
            }
            else if (rpi.Properties.ProviderSpecificDetails is InMageAzureV2ReplicationDetails)
            {
                ReplicationProvider = Constants.InMageAzureV2;
            }
            else if (rpi.Properties.ProviderSpecificDetails is InMageReplicationDetails)
            {
                ReplicationProvider = Constants.InMage;
            }
            else if (rpi.Properties.ProviderSpecificDetails is A2AReplicationDetails)
            {
                ReplicationProvider = Constants.InMage;
            }
        }
    }

    /// <summary>
    ///     PS Recovery Point Class.
    /// </summary>
    public class ASRRecoveryPoint
    {
        /// <summary>
        ///     Gets or sets Name of the Recovery Point.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Point ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets type of the Recovery Point.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Point Time.
        /// </summary>
        public DateTime? RecoveryPointTime { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Point Type.
        /// </summary>
        public string RecoveryPointType { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRRecoveryPoint" /> class.
        /// </summary>
        public ASRRecoveryPoint()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRRecoveryPoint" /> class.
        /// </summary>
        /// <param name="recoveryPoint">Recovery point object to read values from.</param>
        public ASRRecoveryPoint(RecoveryPoint recoveryPoint)
        {
            ID = recoveryPoint.Id;
            Name = recoveryPoint.Name;
            Type = recoveryPoint.Type;
            RecoveryPointTime = recoveryPoint.Properties.RecoveryPointTime;
            RecoveryPointType = recoveryPoint.Properties.RecoveryPointType;
        }
    }

    /// <summary>
    ///     ASRGroupTaskDetails of the Task.
    /// </summary>
    public class ASRGroupTaskDetails
    {
        /// <summary>
        ///     Gets or sets ASRGroupTaskDetails Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Child Tasks.
        /// </summary>
        private List<ASRTaskBase> ChildTasks { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRGroupTaskDetails" /> class.
        /// </summary>
        public ASRGroupTaskDetails()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRGroupTaskDetails" /> class.
        /// </summary>
        /// <param name="task">Task details to load values from.</param>
        public ASRGroupTaskDetails(GroupTaskDetails groupTaskDetails)
        {
            //this.Type = groupTaskDetails.Type;
            ChildTasks = new List<ASRTaskBase>();
            if (groupTaskDetails.ChildTasks != null)
            {
                ChildTasks = groupTaskDetails.ChildTasks.Select(ct => new ASRTaskBase(ct))
                    .ToList();
            }
        }
    }

    /// <summary>
    ///     ASRTaskBase.
    /// </summary>
    public class ASRTaskBase
    {
        /// <summary>
        ///     Gets or sets the task name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Job ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets the Status.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     Gets or sets the State description, which tells the exact internal state.
        /// </summary>
        public string StateDescription { get; set; }

        /// <summary>
        ///     Gets or sets the start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        ///     Gets or sets the end time.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRTaskBase" /> class.
        /// </summary>
        public ASRTaskBase()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRTaskBase" /> class.
        /// </summary>
        /// <param name="task">Base task details to load values from.</param>
        public ASRTaskBase(Management.RecoveryServices.SiteRecovery.Models.ASRTask taskBase)
        {
            ID = taskBase.Name;
            Name = taskBase.FriendlyName;
            if (taskBase.EndTime != null)
            {
                EndTime = ((DateTime) taskBase.EndTime).ToLocalTime();
            }

            if (taskBase.StartTime != null)
            {
                StartTime = ((DateTime) taskBase.StartTime).ToLocalTime();
            }

            State = taskBase.State;
            StateDescription = taskBase.StateDescription;
        }
    }

    /// <summary>
    ///     Task of the Job.
    /// </summary>
    public class ASRTask
    {
        /// <summary>
        ///     Gets or sets the task name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Job ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets the Status.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     Gets or sets the State description, which tells the exact internal state.
        /// </summary>
        public string StateDescription { get; set; }

        /// <summary>
        ///     Gets or sets the start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        ///     Gets or sets the end time.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        ///     Gets or sets the GroupTaskDetails
        /// </summary>
        public ASRGroupTaskDetails GroupTaskDetails { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRTask" /> class.
        /// </summary>
        public ASRTask()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRTask" /> class.
        /// </summary>
        /// <param name="task">Task details to load values from.</param>
        public ASRTask(Management.RecoveryServices.SiteRecovery.Models.ASRTask task)
        {
            ID = task.Name;
            if (task.EndTime != null)
            {
                EndTime = ((DateTime) task.EndTime).ToLocalTime();
            }
            Name = task.FriendlyName;
            if (task.StartTime != null)
            {
                StartTime = ((DateTime) task.StartTime).ToLocalTime();
            }
            State = task.State;
            StateDescription = task.StateDescription;
            if (task.GroupTaskCustomDetails != null)
            {
                GroupTaskDetails = new ASRGroupTaskDetails(task.GroupTaskCustomDetails);
            }
        }
    }

    /// <summary>
    ///     Azure Site Recovery Job.
    /// </summary>
    public class ASRJob
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRJob" /> class.
        /// </summary>
        public ASRJob()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRJob" /> class with required parameters.
        /// </summary>
        /// <param name="job">ASR Job object</param>
        public ASRJob(Job job)
        {
            ID = job.Id;
            Type = job.Type;
            JobType = job.Properties.ScenarioName;
            DisplayName = job.Properties.FriendlyName;
            ClientRequestId = job.Properties.ActivityId;
            State = job.Properties.State;
            StateDescription = job.Properties.StateDescription;
            Name = job.Name;
            TargetObjectId = job.Properties.TargetObjectId;
            TargetObjectName = job.Properties.TargetObjectName;
            if (job.Properties.EndTime.HasValue)
                EndTime = job.Properties.EndTime.Value.ToLocalTime();
            if (job.Properties.StartTime.HasValue)
                StartTime = job.Properties.StartTime.Value.ToLocalTime();
            if (job.Properties.AllowedActions != null &&
                job.Properties.AllowedActions.Count > 0)
            {
                AllowedActions = new List<string>();
                foreach (var action in job.Properties.AllowedActions)
                {
                    AllowedActions.Add(action);
                }
            }

            if (!string.IsNullOrEmpty(job.Properties.TargetObjectId))
            {
                TargetObjectType = job.Properties.TargetInstanceType;
            }

            Tasks = new List<ASRTask>();
            foreach (var task in job.Properties.Tasks)
            {
                Tasks.Add(new ASRTask(task));
            }

            Errors = new List<ASRErrorDetails>();

            foreach (var error in job.Properties.Errors)
            {
                var errorDetails = new ASRErrorDetails();
                errorDetails.TaskId = error.TaskId;
                errorDetails.ServiceErrorDetails = new ASRServiceError(error.ServiceErrorDetails);
                errorDetails.ProviderErrorDetails =
                    new ASRProviderError(error.ProviderErrorDetails);
                Errors.Add(errorDetails);
            }
        }

        #region Properties

        /// <summary>
        ///     Gets or sets Job display name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Job ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets Job display name.
        /// </summary>
        public string JobType { get; set; }

        /// <summary>
        ///     Gets or sets Job display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        ///     Gets or sets Activity ID.
        /// </summary>
        public string ClientRequestId { get; set; }

        /// <summary>
        ///     Gets or sets State of the Job.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     Gets or sets StateDescription of the Job.
        /// </summary>
        public string StateDescription { get; set; }

        /// <summary>
        ///     Gets or sets Start timestamp.
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        ///     Gets or sets End timestamp.
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        ///     Gets or sets TargetObjectId.
        /// </summary>
        public string TargetObjectId { get; set; }

        /// <summary>
        ///     Gets or sets TargetObjectType.
        /// </summary>
        public string TargetObjectType { get; set; }

        /// <summary>
        ///     Gets or sets End timestamp.
        /// </summary>
        public string TargetObjectName { get; set; }

        /// <summary>
        ///     Gets or sets list of allowed actions.
        /// </summary>
        public List<string> AllowedActions { get; set; }

        /// <summary>
        ///     Gets or sets list of tasks.
        /// </summary>
        public List<ASRTask> Tasks { get; set; }

        /// <summary>
        ///     Gets or sets list of Errors.
        /// </summary>
        public List<ASRErrorDetails> Errors { get; set; }

        #endregion
    }

    /// <summary>
    ///     This class contains the error details per object.
    /// </summary>
    public class ASRErrorDetails
    {
        /// <summary>
        ///     Gets or sets the Service error details.
        /// </summary>
        public ASRServiceError ServiceErrorDetails { get; set; }

        /// <summary>
        ///     Gets or sets the Provider error details.
        /// </summary>
        public ASRProviderError ProviderErrorDetails { get; set; }

        /// <summary>
        ///     Gets or sets the Id of the task.
        /// </summary>
        public string TaskId { get; set; }
    }

    /// <summary>
    ///     This class contains the ASR error details per object.
    /// </summary>
    public class ASRServiceError : Error
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRServiceError" /> class with required
        ///     parameters.
        /// </summary>
        public ASRServiceError()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRServiceError" /> class with required
        ///     parameters.
        /// </summary>
        /// <param name="serviceError">ServiceError object</param>
        public ASRServiceError(ServiceError serviceError) : base(serviceError)
        {
        }
    }

    /// <summary>
    ///     This class contains the provider error details per object.
    /// </summary>
    public class ASRProviderError
    {
        /// <summary>
        ///     Gets or sets the Error code.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        ///     Gets or sets the Error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     Gets or sets the Provider error Id
        /// </summary>
        public string ErrorId { get; set; }

        /// <summary>
        ///     Gets or sets the Time of the error creation.
        /// </summary>
        public DateTime CreationTimeUtc { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRProviderError" /> class with required
        ///     parameters.
        /// </summary>
        public ASRProviderError()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRProviderError" /> class with required
        ///     parameters.
        /// </summary>
        /// <param name="error">ProviderError object</param>
        public ASRProviderError(ProviderError error)
        {
            //this.CreationTimeUtc = error.CreationTimeUtc;
            ErrorCode = (int) error.ErrorCode;
            ErrorId = error.ErrorId;
            ErrorMessage = error.ErrorMessage;
        }
    }

    /// <summary>
    ///     Represents Azure site recovery storage classification.
    /// </summary>
    public class ASRStorageClassification
    {
        /// <summary>
        ///     Gets or sets Storage classification ARM Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets Storage classification ARM name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Storage classification friendly name.
        /// </summary>
        public string FriendlyName { get; set; }
    }

    /// <summary>
    ///     Represents Azure site recovery storage classification mapping.
    /// </summary>
    public class ASRStorageClassificationMapping
    {
        /// <summary>
        ///     Gets or sets Storage classification ARM Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets Storage classification ARM name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets primary classification ARM Id.
        /// </summary>
        public string PrimaryClassificationId { get; set; }

        /// <summary>
        ///     Gets or sets recovery classification ARM Id.
        /// </summary>
        public string RecoveryClassificationId { get; set; }
    }

    /// <summary>
    ///     Disk details.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class VirtualHardDisk
    {
        /// <summary>
        ///     Gets or sets the VHD id.
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }

    /// <summary>
    ///     Partial details of a NIC of a VM.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class VMNic
    {
        /// <summary>
        ///     Gets or sets ID of the NIC.
        /// </summary>
        [DataMember]
        public string NicId { get; set; }

        /// <summary>
        ///     Gets or sets Name of the VM subnet.
        /// </summary>
        [DataMember]
        public string VMSubnetName { get; set; }

        /// <summary>
        ///     Gets or sets Name of the VM network.
        /// </summary>
        [DataMember]
        public string VMNetworkName { get; set; }

        /// <summary>
        ///     Gets or sets Id of the recovery VM Network.
        /// </summary>
        [DataMember]
        public string RecoveryVMNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the recovery VM subnet.
        /// </summary>
        [DataMember]
        public string RecoveryVMSubnetName { get; set; }

        /// <summary>
        ///     Gets or sets the static IP address of the replica NIC.
        /// </summary>
        [DataMember]
        public string RecoveryNicStaticIPAddress { get; set; }
    }
}