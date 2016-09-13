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

using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Management.SiteRecoveryVault.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Azure Site Recovery Vault Settings.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Keeping all related objects together.")]
    public class ASRVaultSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVaultSettings" /> class.
        /// </summary>
        public ASRVaultSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVaultSettings" /> class
        /// </summary>
        /// <param name="asrVaultCreds">Vault credentails</param>
        public ASRVaultSettings(ASRVaultCreds asrVaultCreds)
        {
            this.ResourceName = asrVaultCreds.ResourceName;
            this.ResourceGroupName = asrVaultCreds.ResourceGroupName;
            this.ResourceNamespace = asrVaultCreds.ResourceNamespace;
            this.ResouceType = asrVaultCreds.ARMResourceType;
        }

        #region Properties
        /// <summary>
        /// Gets or sets Resource Name.
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets Resource Group Name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Resource Provider Namespace.
        /// </summary>
        public string ResourceNamespace { get; set; }

        /// <summary>
        /// Gets or sets Resource Type.
        /// </summary>
        public string ResouceType { get; set; }
        #endregion Properties
    }


    /// <summary>
    /// Azure Site Recovery Server.
    /// </summary>
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
        public ASRServer(Fabric fabric, RecoveryServicesProvider provider)
        {
            this.ID = provider.Id;
            this.Name = provider.Name;
            this.FriendlyName = provider.Properties.FriendlyName;
            if (provider.Properties.LastHeartbeat != null)
            {
                this.LastHeartbeat = (DateTime)provider.Properties.LastHeartbeat;
            }
            this.ProviderVersion = provider.Properties.ProviderVersion;
            this.ServerVersion = provider.Properties.ServerVersion;
            this.Connected = provider.Properties.ConnectionStatus.ToLower().CompareTo("connected") == 0 ? true : false;
            this.FabricType = provider.Properties.FabricType;
            this.Type = provider.Type;
        }

        #region Properties
        /// <summary>
        /// Gets or sets Name of the Server.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets Name of the Server.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Server ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the Type of Management entity – VMM, V-Center.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the type of Server - VMM.
        /// </summary>
        public string FabricType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether server is connected or not.
        /// </summary>
        public bool Connected { get; set; }

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
    /// Azure Site Recovery Site object.
    /// </summary>
    public class ASRSite
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRSite" /> class.
        /// </summary>
        public ASRSite()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRSite" /> class.
        /// </summary>
        /// <param name="site">Hydra site object.</param>
        public ASRSite(Fabric fabric)
        {
            this.Name = fabric.Name;
            this.FriendlyName = fabric.Properties.FriendlyName;
            this.ID = fabric.Id;
            this.Type = fabric.Properties.CustomDetails.InstanceType;
            this.SiteIdentifier = fabric.Properties.InternalIdentifier;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets display name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets friendly name.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets site type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets site SiteIdentifier.
        /// </summary>
        public string SiteIdentifier { get; set; }

        #endregion
    }

    /// <summary>
    /// Azure Site Recovery Protection Container.
    /// </summary>
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
        public ASRProtectionContainer(ProtectionContainer pc, List<ASRPolicy> availablePolicies)
        {
            this.AvailablePolicies = availablePolicies;
            this.ID = pc.Id;
            this.Name = pc.Name;
            this.FriendlyName = pc.Properties.FriendlyName;
            this.FabricFriendlyName = pc.Properties.FabricFriendlyName;
            this.Role = pc.Properties.Role;
            this.FabricType = pc.Properties.FabricType;
            this.Type = pc.Type;
        }

        #region Properties
        /// <summary>
        /// Gets or sets name of the Protection container.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets name of the Protection container.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Protection container ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the type e.g. VMM, HyperVSite, etc.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Protection container's Fabric Friendly Name.
        /// </summary>
        public string FabricFriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the type of Fabric - VMM.
        /// </summary>
        public string FabricType { get; set; }

        /// <summary>
        /// Gets or sets a role of the protection container.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the list of Policys.
        /// </summary>
        public List<ASRPolicy> AvailablePolicies { get; set; }
        #endregion
    }

    /// <summary>
    /// Policy association details.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class ASRPolicyAssociationDetails
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
    /// Azure Site Recovery Policy.
    /// </summary>
    public class ASRPolicy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRPolicy" /> class.
        /// </summary>
        public ASRPolicy()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRPolicy" /> class with 
        /// required parameters.
        /// </summary>
        /// <param name="policy">Protection container object</param>
        public ASRPolicy(Policy policy)
        {
            this.ID = policy.Id;
            this.Name = policy.Name;
            this.FriendlyName = policy.Properties.FriendlyName;
            this.Type = policy.Type;
            this.ReplicationProvider = policy.Properties.ProviderSpecificDetails.InstanceType;

            if (policy.Properties.ProviderSpecificDetails.InstanceType == Constants.HyperVReplica2012)
            {
                HyperVReplica2012PolicyDetails details =
                    (HyperVReplica2012PolicyDetails)policy.Properties.ProviderSpecificDetails;

                ASRHyperVReplicaPolicyDetails replicationProviderSettings =
                    new ASRHyperVReplicaPolicyDetails();

                replicationProviderSettings.ReplicaDeletionOption =
                    details.ReplicaDeletionOption;
                replicationProviderSettings.ApplicationConsistentSnapshotFrequencyInHours =
                    details.ApplicationConsistentSnapshotFrequencyInHours;
                replicationProviderSettings.Compression =
                    details.Compression;
                replicationProviderSettings.ReplicationFrequencyInSeconds =
                    300;
                replicationProviderSettings.AllowedAuthenticationType =
                    (details.AllowedAuthenticationType == 1) ?
                    Constants.AuthenticationTypeKerberos :
                    Constants.AuthenticationTypeCertificate;
                replicationProviderSettings.RecoveryPoints = details.RecoveryPoints;
                replicationProviderSettings.InitialReplicationMethod =
                    (string.Compare(details.InitialReplicationMethod, "OverNetwork", StringComparison.OrdinalIgnoreCase) == 0) ?
                    Constants.OnlineReplicationMethod :
                    Constants.OfflineReplicationMethod;
                replicationProviderSettings.ReplicationPort = details.ReplicationPort;
                replicationProviderSettings.OnlineReplicationStartTime = details.OnlineReplicationStartTime;

                this.ReplicationProviderSettings = replicationProviderSettings;
            }
            else if (policy.Properties.ProviderSpecificDetails.InstanceType == Constants.HyperVReplica2012R2)
            {
                HyperVReplica2012R2PolicyDetails details =
                    (HyperVReplica2012R2PolicyDetails)policy.Properties.ProviderSpecificDetails;

                ASRHyperVReplicaPolicyDetails replicationProviderSettings =
                    new ASRHyperVReplicaPolicyDetails();

                replicationProviderSettings.ReplicaDeletionOption =
                    details.ReplicaDeletionOption;
                replicationProviderSettings.ApplicationConsistentSnapshotFrequencyInHours =
                    details.ApplicationConsistentSnapshotFrequencyInHours;
                replicationProviderSettings.Compression =
                    details.Compression;
                replicationProviderSettings.ReplicationFrequencyInSeconds =
                    details.ReplicationFrequencyInSeconds;
                replicationProviderSettings.AllowedAuthenticationType =
                    (details.AllowedAuthenticationType == 1) ?
                    Constants.AuthenticationTypeKerberos :
                    Constants.AuthenticationTypeCertificate;
                replicationProviderSettings.RecoveryPoints = details.RecoveryPoints;
                replicationProviderSettings.InitialReplicationMethod =
                    (string.Compare(details.InitialReplicationMethod, "OverNetwork", StringComparison.OrdinalIgnoreCase) == 0) ?
                    Constants.OnlineReplicationMethod :
                    Constants.OfflineReplicationMethod;
                replicationProviderSettings.ReplicationPort = details.ReplicationPort;
                replicationProviderSettings.OnlineReplicationStartTime = details.OnlineReplicationStartTime;

                this.ReplicationProviderSettings = replicationProviderSettings;
            }
            else if (policy.Properties.ProviderSpecificDetails.InstanceType == Constants.HyperVReplicaAzure)
            {
                HyperVReplicaAzurePolicyDetails details =
                    (HyperVReplicaAzurePolicyDetails)policy.Properties.ProviderSpecificDetails;

                ASRHyperVReplicaAzurePolicyDetails replicationProviderSettings =
                    new ASRHyperVReplicaAzurePolicyDetails();

                replicationProviderSettings.ApplicationConsistentSnapshotFrequencyInHours =
                    details.ApplicationConsistentSnapshotFrequencyInHours;
                replicationProviderSettings.ReplicationFrequencyInSeconds = details.ReplicationInterval;
                replicationProviderSettings.RecoveryPoints = details.RecoveryPointHistoryDurationInHours;
                replicationProviderSettings.OnlineReplicationStartTime = details.OnlineReplicationStartTime;
                replicationProviderSettings.Encryption = details.Encryption;
                replicationProviderSettings.ActiveStorageAccountId =
                    details.ActiveStorageAccountId;

                this.ReplicationProviderSettings = replicationProviderSettings;
            }
        }

        #region Properties
        /// <summary>
        /// Gets or sets friendly name of the Policy.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets name of the Policy.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Policy ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets Policy type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Replication Type (HyperVReplica, HyperVReplicaAzure, San)
        /// </summary>
        public string ReplicationProvider { get; set; }

        /// <summary>
        /// Gets or sets HyperVReplicaProviderSettings
        /// </summary>
        // public HyperVReplicaProviderSettings ReplicationProviderSettings { get; set; }
        public ASRPolicyProviderSettingsDetails ReplicationProviderSettings { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Policy provider settings
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
    /// ASR HyperV Replica Azure enable protection input.
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
    /// ASR Customer Storage Account.
    /// </summary>
    public class ASRCustomerStorageAccount
    {
        /// <summary>
        /// Name of the storage account.
        /// </summary>
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Subscription ID to which the Storage Account is associated.
        /// </summary>
        public string SubscriptionId { get; set; }
    }

    /// <summary>
    /// ASR VM Nic Details
    /// </summary>
    public class ASRVMNicDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVMNicDetails" /> class.
        /// </summary>
        public ASRVMNicDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVMNicDetails" /> class.
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

        /// <summary>
        /// Gets or sets the nic Id.
        /// </summary>
        public string NicId { get; set; }

        /// <summary>
        /// Gets or sets VM network name.
        /// </summary>
        public string VMNetworkName { get; set; }

        /// <summary>
        /// Gets or sets VM subnet name.
        /// </summary>
        public string VMSubnetName { get; set; }

        /// <summary>
        /// Gets or sets recovery VM network Id.
        /// </summary>
        public string RecoveryVMNetworkId { get; set; }

        /// <summary>
        /// Gets or sets recovery VM subnet name.
        /// </summary>
        public string RecoveryVMSubnetName { get; set; }

        /// <summary>
        /// Gets or sets replica nic static IP address.
        /// </summary>
        public string ReplicaNicStaticIPAddress { get; set; }

        /// <summary>
        /// Gets or sets ipv4 address type.
        /// </summary>
        public string IpAddressType { get; set; }

        /// <summary>
        /// Gets or sets selection type for failover.
        /// </summary>
        public string SelectionType { get; set; }
    }

    public class ASRVirtualMachine : ASRProtectionEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVirtualMachine" /> class.
        /// </summary>
        public ASRVirtualMachine()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVirtualMachine" /> class when it is not protected
        /// </summary>
        /// <param name="pi">Protectable Item to read values from</param>
        public ASRVirtualMachine(ProtectableItem pi)
            : base(pi)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVirtualMachine" /> class when it is protected
        /// </summary>
        /// <param name="pi">Protectable Item to read values from</param>
        /// <param name="rpi">Replication Protected Item to read values from</param>
        public ASRVirtualMachine(ProtectableItem pi, ReplicationProtectedItem rpi, Policy policy = null)
            : base(pi, rpi, policy)
        {
            if (0 == string.Compare(
                    rpi.Properties.ProviderSpecificDetails.InstanceType,
                    Constants.HyperVReplicaAzure,
                    StringComparison.OrdinalIgnoreCase))
            {
                HyperVReplicaAzureReplicationDetails providerSpecificDetails =
                           (HyperVReplicaAzureReplicationDetails)rpi.Properties.ProviderSpecificDetails;

                RecoveryAzureVMName = providerSpecificDetails.RecoveryAzureVMName;
                RecoveryAzureVMSize = providerSpecificDetails.RecoveryAzureVMSize;
                RecoveryAzureStorageAccount = providerSpecificDetails.RecoveryAzureStorageAccount;
                SelectedRecoveryAzureNetworkId = providerSpecificDetails.SelectedRecoveryAzureNetworkId;
                if (providerSpecificDetails.VMNics != null)
                {
                    NicDetailsList = new List<ASRVMNicDetails>();
                    foreach (VMNicDetails n in providerSpecificDetails.VMNics)
                    {
                        NicDetailsList.Add(new ASRVMNicDetails(n));
                    }
                }
            }

        }

        /// <summary>
        /// Gets or sets Recovery Azure VM Name of the Virtual machine.
        /// </summary>
        public string RecoveryAzureVMName { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure VM Size of the Virtual machine.
        /// </summary>
        public string RecoveryAzureVMSize { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Storage Account of the Virtual machine.
        /// </summary>
        public string RecoveryAzureStorageAccount { get; set; }

        /// <summary>
        /// Gets or sets Selected Recovery Azure Network Id of the Virtual machine.
        /// </summary>
        public string SelectedRecoveryAzureNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Nic Details of the Virtual machine.
        /// </summary>
        public List<ASRVMNicDetails> NicDetailsList { get; set; }

    }

    /// <summary>
    /// Azure Site Recovery Protection Entity.
    /// </summary>
    public class ASRProtectionEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRProtectionEntity" /> class.
        /// </summary>
        public ASRProtectionEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRProtectionEntity" /> class when it is not protected
        /// </summary>
        /// <param name="pi">Protectable Item to read values from</param>
        public ASRProtectionEntity(ProtectableItem pi)
        {
            this.ID = pi.Id;
            this.ProtectionContainerId = Utilities.GetValueFromArmId(pi.Id, ARMResourceTypeConstants.ReplicationProtectionContainers);
            this.Name = pi.Name;
            this.FriendlyName = pi.Properties.FriendlyName;
            this.ProtectionStatus = pi.Properties.ProtectionStatus;
            if (pi.Properties.CustomDetails != null)
            {
                if (0 == string.Compare(
                    pi.Properties.CustomDetails.InstanceType,
                    "HyperVVirtualMachine",
                    StringComparison.OrdinalIgnoreCase))
                {
                    if (pi.Properties.CustomDetails is HyperVVirtualMachineDetails)
                    {
                        HyperVVirtualMachineDetails providerSettings =
                            (HyperVVirtualMachineDetails)pi.Properties.CustomDetails;

                        IList<DiskDetails> diskDetails = providerSettings.DiskDetailsList;
                        this.UpdateDiskDetails(diskDetails);
                        this.OS = providerSettings.OSDetails == null ? null : providerSettings.OSDetails.OsType;
                        this.FabricObjectId = providerSettings.SourceItemId;
                    }

                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRProtectionEntity" /> class when it is protected
        /// </summary>
        /// <param name="pi">Protectable Item to read values from</param>
        /// <param name="rpi">Replication Protected Item to read values from</param>
        public ASRProtectionEntity(ProtectableItem pi, ReplicationProtectedItem rpi, Policy policy = null) : this(pi)
        {
            this.Type = rpi.Type;
            this.ProtectionStateDescription = rpi.Properties.ProtectionStateDescription;

            if (rpi.Properties.AllowedOperations != null)
            {
                this.AllowedOperations = new List<string>();
                foreach (String op in rpi.Properties.AllowedOperations)
                {
                    AllowedOperations.Add(op);
                }
            }
            this.ReplicationProvider = rpi.Properties.ProviderSpecificDetails.InstanceType;
            this.ActiveLocation = rpi.Properties.ActiveLocation;
            this.ReplicationHealth = rpi.Properties.ReplicationHealth;
            this.TestFailoverStateDescription = rpi.Properties.TestFailoverStateDescription;
            this.ProtectionStatus = rpi.Properties.ProtectionState;
            if (policy != null)
            {
                this.Policy = new ASRPolicy(policy);
            }
            this.ReplicationProtectedItemId = rpi.Id;
        }

        private void UpdateDiskDetails(IList<DiskDetails> diskDetails)
        {
            this.Disks = new List<VirtualHardDisk>();
            foreach (var disk in diskDetails)
            {
                VirtualHardDisk hd = new VirtualHardDisk();
                hd.Id = disk.VhdId;
                hd.Name = disk.VhdName;
                this.Disks.Add(hd);
            }
            DiskDetails OSDisk = diskDetails.SingleOrDefault(d => string.Compare(d.VhdType, "OperatingSystem", StringComparison.OrdinalIgnoreCase) == 0);
            if (OSDisk != null)
            {
                this.OSDiskId = OSDisk.VhdId;
                this.OSDiskName = OSDisk.VhdName;
            }
        }

        /// <summary>
        /// Gets or sets Friendly Name of the Protection entity.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets Name of the Protection entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Protection entity ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets type of the Protection entity.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets fabric object ID.
        /// </summary>
        public string FabricObjectId { get; set; }

        /// <summary>
        /// Gets or sets Protection container ID.
        /// </summary>
        public string ProtectionContainerId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is protected or not.
        /// </summary>
        public string ProtectionStatus { get; set; }

        /// <summary>
        /// Gets or sets a value that lists allowed operations.
        /// </summary>
        public IList<string> AllowedOperations { get; set; }

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
        /// Gets or sets Policy.
        /// </summary>
        public ASRPolicy Policy { get; set; }

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

        /// <summary>
        /// Gets or sets Replication protected item id.
        /// </summary>
        public string ReplicationProtectedItemId { get; set; }
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
            this.StateDescription = "";
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
            this.ID = job.Id;
            this.Type = job.Type;
            this.JobType = job.Properties.ScenarioName;
            this.DisplayName = job.Properties.FriendlyName;
            this.ClientRequestId = job.Properties.ActivityId;
            this.State = job.Properties.State;
            this.StateDescription = job.Properties.StateDescription;
            this.Name = job.Name;
            this.TargetObjectId = job.Properties.TargetObjectId;
            this.TargetObjectName = job.Properties.TargetObjectName;
            if (job.Properties.EndTime.HasValue)
                this.EndTime = job.Properties.EndTime.Value.ToLocalTime();
            if (job.Properties.StartTime.HasValue)
                this.StartTime = job.Properties.StartTime.Value.ToLocalTime();
            if (job.Properties.AllowedActions != null && job.Properties.AllowedActions.Count > 0)
            {
                this.AllowedActions = new List<string>();
                foreach (var action in job.Properties.AllowedActions)
                {
                    this.AllowedActions.Add(action);
                }
            }

            if (!string.IsNullOrEmpty(job.Properties.TargetObjectId))
            {
                this.TargetObjectType = job.Properties.TargetInstanceType;
            }

            this.Tasks = new List<ASRTask>();
            foreach (var task in job.Properties.Tasks)
            {
                this.Tasks.Add(new ASRTask(task));
            }

            this.Errors = new List<ASRErrorDetails>();

            foreach (var error in job.Properties.Errors)
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
        /// Gets or sets type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Job display name.
        /// </summary>
        public string JobType { get; set; }

        /// <summary>
        /// Gets or sets Job display name.
        /// </summary>
        public string DisplayName { get; set; }

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
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets End timestamp.
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets TargetObjectId.
        /// </summary>
        public string TargetObjectId { get; set; }

        /// <summary>
        /// Gets or sets TargetObjectType.
        /// </summary>
        public string TargetObjectType { get; set; }

        /// <summary>
        /// Gets or sets End timestamp.
        /// </summary>
        public string TargetObjectName { get; set; }

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
    /// Azure Site Recovery Vault.
    /// </summary>
    public class ASRVault
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVault" /> class.
        /// </summary>
        public ASRVault()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVault" /> class.
        /// </summary>
        /// <param name="vault">vault object</param>
        public ASRVault(Vault vault)
        {
            this.ID = vault.Id;
            this.Name = vault.Name;
            this.Type = vault.Type;
            this.Location = vault.Location;
            this.ResourceGroupName = PSRecoveryServicesClient.GetResourceGroup(vault.Id);
            this.SubscriptionId = PSRecoveryServicesClient.GetSubscriptionId(vault.Id);
            this.Properties = new ASRVaultProperties();
            this.Properties.ProvisioningState = vault.Properties.ProvisioningState;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVault" /> class.
        /// </summary>
        /// <param name="vault">vault object</param>
        public ASRVault(VaultCreateResponse vault)
        {
            this.ID = vault.Id;
            this.Name = vault.Name;
            this.Type = vault.Type;
            this.Location = vault.Location;
            this.ResourceGroupName = PSRecoveryServicesClient.GetResourceGroup(vault.Id);
            this.SubscriptionId = PSRecoveryServicesClient.GetSubscriptionId(vault.Id);
            this.Properties = new ASRVaultProperties();
            this.Properties.ProvisioningState = vault.Properties.ProvisioningState;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets Vault Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Vault ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets Resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Subscription.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets Properties.
        /// </summary>
        public ASRVaultProperties Properties { get; set; }

        #endregion
    }

    /// <summary>
    /// Azure Site Recovery Vault properties.
    /// </summary>
    public class ASRVaultProperties
    {
        #region Properties

        /// <summary>
        /// Gets or sets Provisioning State.
        /// </summary>
        public string ProvisioningState { get; set; }

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
    /// Class to define the output of the vault settings file generation.
    /// </summary>
    public class VaultSettingsFilePath
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VaultSettingsFilePath" /> class
        /// </summary>
        public VaultSettingsFilePath()
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
        public string Response { get; set; }

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
            //this.CreationTimeUtc = error.CreationTimeUtc;
            this.ErrorCode = error.ErrorCode;
            this.ErrorId = error.ErrorId;
            this.ErrorMessage = error.ErrorMessage;
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
        /// Gets or sets the Time of the error creation.
        /// </summary>
        public DateTime CreationTimeUtc { get; set; }
    }

    /// <summary>
    /// Represents Azure site recovery storage classification.
    /// </summary>
    public class ASRStorageClassification
    {
        /// <summary>
        /// Gets or sets Storage classification ARM Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Storage classification ARM name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Storage classification friendly name.
        /// </summary>
        public string FriendlyName { get; set; }
    }

    /// <summary>
    /// Represents Azure site recovery storage classification mapping.
    /// </summary>
    public class ASRStorageClassificationMapping
    {
        /// <summary>
        /// Gets or sets Storage classification ARM Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Storage classification ARM name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets primary classification ARM Id.
        /// </summary>
        public string PrimaryClassificationId { get; set; }

        /// <summary>
        /// Gets or sets recovery classification ARM Id.
        /// </summary>
        public string RecoveryClassificationId { get; set; }
    }

    /// <summary>
    /// Disk details.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
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

    /// <summary>
    /// Partial details of a NIC of a VM.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class VMNic
    {
        /// <summary>
        /// Gets or sets ID of the NIC.
        /// </summary>
        [DataMember]
        public string NicId { get; set; }

        /// <summary>
        /// Gets or sets Name of the VM subnet.
        /// </summary>
        [DataMember]
        public string VMSubnetName { get; set; }

        /// <summary>
        /// Gets or sets Name of the VM network.
        /// </summary>
        [DataMember]
        public string VMNetworkName { get; set; }

        /// <summary>
        /// Gets or sets Id of the recovery VM Network.
        /// </summary>
        [DataMember]
        public string RecoveryVMNetworkId { get; set; }

        /// <summary>
        /// Gets or sets the name of the recovery VM subnet.
        /// </summary>
        [DataMember]
        public string RecoveryVMSubnetName { get; set; }

        /// <summary>
        /// Gets or sets the static IP address of the replica NIC.
        /// </summary>
        [DataMember]
        public string RecoveryNicStaticIPAddress { get; set; }
    }
}