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
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using System.Web.Script.Serialization;

namespace Microsoft.Azure.Commands.SiteRecovery
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
        /// Represents None string value.
        /// </summary>
        public const string None = "None";

        /// <summary>
        /// Represents Existing string value.
        /// </summary>
        public const string Existing = "Existing";

        /// <summary>
        /// Represents New string value.
        /// </summary>
        public const string New = "New";

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
        /// Represents San string constant.
        /// </summary>
        public const string San = "San";

        /// <summary>
        /// Represents HyperVReplica string constant.
        /// </summary>
        public const string AzureContainer = "Microsoft Azure";

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

        /// <summary>
        /// Represents Direction string value.
        /// </summary>
        public const string Direction = "Direction";

        /// <summary>
        /// Represents RPId string value.
        /// </summary>
        public const string RPId = "RPId";

        /// <summary>
        /// Represents ID string value.
        /// </summary>
        public const string ID = "ID";

        /// <summary>
        /// Represents NetworkType string value.
        /// </summary>
        public const string NetworkType = "NetworkType";

        /// <summary>
        /// Represents ProtectionEntityId string value.
        /// </summary>
        public const string ProtectionEntityId = "ProtectionEntityId";

        /// <summary>
        /// Azure fabric Id. In E2A context Recovery Server Id is always this.
        /// </summary>
        public const string AzureFabricId = "21a9403c-6ec1-44f2-b744-b4e50b792387";

        /// <summary>
        /// Authentication Type as Certificate based authentication.
        /// </summary>
        public const string AuthenticationTypeCertificate = "Certificate";

        /// <summary>
        /// Authentication Type as Kerberos.
        /// </summary>
        public const string AuthenticationTypeKerberos = "Kerberos";

        /// <summary>
        /// Acceptable values of Replication Frequency in seconds (as per portal).
        /// </summary>
        public const string Thirty = "30";

        /// <summary>
        /// Acceptable values of Replication Frequency in seconds (as per portal).
        /// </summary>
        public const string ThreeHundred = "300";

        /// <summary>
        /// Acceptable values of Replication Frequency in seconds (as per portal).
        /// </summary>
        public const string NineHundred = "900";

        /// <summary>
        /// Replication type - async.
        /// </summary>
        public const string Sync = "Sync";

        /// <summary>
        /// Replication type - async.
        /// </summary>
        public const string Async = "Async";

        /// <summary>
        /// SourceSiteOperations - Required.
        /// </summary>
        public const string Required = "Required";

        /// <summary>
        /// SourceSiteOperations - NotRequired.
        /// </summary>
        public const string NotRequired = "NotRequired";
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
            this.ResouceGroupName = cloudServiceName;
        }

        #region Properties
        /// <summary>
        /// Gets or sets Resource Name.
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets Cloud Service Name.
        /// </summary>
        public string ResouceGroupName { get; set; }
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
            this.ID = server.Id;
            this.Name = server.Name;
            this.FriendlyName = server.Properties.FriendlyName;
            this.LastHeartbeat = server.Properties.LastHeartbeat;
            this.ProviderVersion = server.Properties.ProviderVersion;
            this.ServerVersion = server.Properties.ServerVersion;
            // this.Connected = server.Properties.Connected;
            this.FabricObjectID = server.Properties.FabricObjectID;
            this.FabricType = server.Properties.FabricType;
            this.Type = server.Type;
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
        /// Gets or sets the type of Fabric - VMM.
        /// </summary>
        public string FabricType { get; set; }

        /// <summary>
        /// Gets or sets the ID of the on premise fabric.
        /// </summary>
        public string FabricObjectID { get; set; }

        ///// <summary>
        ///// Gets or sets a value indicating whether server is connected or not.
        ///// </summary>
        //public bool Connected { get; set; }

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
            if (pc.Properties.AvailableProtectionProfiles != null)
            {
                this.AvailableProtectionProfiles = new List<ASRProtectionProfile>();
                foreach (var profile in pc.Properties.AvailableProtectionProfiles)
                {
                    this.AvailableProtectionProfiles.Add(
                        new ASRProtectionProfile(profile));
                }
            }

            this.ID = pc.Id;
            this.Name = pc.Name;
            this.FriendlyName = pc.Properties.FriendlyName;
            this.Role = pc.Properties.Role;
            // this.ServerId = pc.Properties.ServerId;
            this.FabricObjectId = pc.Properties.FabricObjectId;
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
        /// Gets or sets Protection container's FabricObjectId.
        /// </summary>
        public string FabricObjectId { get; set; }

        /// <summary>
        /// Gets or sets the type of Fabric - VMM.
        /// </summary>
        public string FabricType { get; set; }

        ///// <summary>
        ///// Gets or sets Server ID.
        ///// </summary>
        //public string ServerId { get; set; }

        /// <summary>
        /// Gets or sets a role of the protection container.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the list of protection profiles.
        /// </summary>
        public List<ASRProtectionProfile> AvailableProtectionProfiles { get; set; }
        #endregion
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
        /// <param name="profile">Protection container object</param>
        public ASRProtectionProfile(ProtectionProfile profile)
        {
            this.ID = profile.Id;
            this.Name = profile.Name;
            this.FriendlyName = profile.CustomData.FriendlyName;
            this.Type = profile.Type;
            this.ReplicationProvider = profile.CustomData.ReplicationProvider;

            if (profile.CustomData.ReplicationProvider == Constants.HyperVReplica)
            {
                HyperVReplicaProtectionProfileDetails details =
                    (HyperVReplicaProtectionProfileDetails)profile.CustomData.ReplicationProviderSettings;

                ASRHyperVReplicaProtectionProfileDetails replicationProviderSettings =
                    new ASRHyperVReplicaProtectionProfileDetails();

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
            else if (profile.CustomData.ReplicationProvider == Constants.HyperVReplicaAzure)
            {
                HyperVReplicaAzureProtectionProfileDetails details =
                    (HyperVReplicaAzureProtectionProfileDetails)profile.CustomData.ReplicationProviderSettings;

                ASRHyperVReplicaAzureProtectionProfileDetails replicationProviderSettings =
                    new ASRHyperVReplicaAzureProtectionProfileDetails();

                replicationProviderSettings.ApplicationConsistentSnapshotFrequencyInHours =
                    details.ApplicationConsistentSnapshotFrequencyInHours;
                replicationProviderSettings.ReplicationFrequencyInSeconds = details.ReplicationInterval;
                replicationProviderSettings.RecoveryPoints = details.RecoveryPointHistoryDuration;
                replicationProviderSettings.OnlineReplicationStartTime = details.OnlineReplicationStartTime;
                replicationProviderSettings.Encryption = details.Encryption;
                replicationProviderSettings.ActiveStorageAccount = new CustomerStorageAccount();
                replicationProviderSettings.ActiveStorageAccount.StorageAccountName =
                    details.ActiveStorageAccount.StorageAccountName;
                replicationProviderSettings.ActiveStorageAccount.SubscriptionId =
                    details.ActiveStorageAccount.SubscriptionId;

                this.ReplicationProviderSettings = replicationProviderSettings;
            }
        }

        #region Properties
        /// <summary>
        /// Gets or sets friendly name of the Protection profile.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets name of the Protection profile.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Protection profile ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets Protection profile type.
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
        public ASRProtectionProfileProviderSettingsDetails ReplicationProviderSettings { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Protection profile provider settings
    /// </summary>
    public class ASRProtectionProfileProviderSettingsDetails
    {
    }

    // Summary:
    //     HyperV Replica Protection Profile Details.
    public class ASRHyperVReplicaProtectionProfileDetails : ASRProtectionProfileProviderSettingsDetails
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
    public class ASRHyperVReplicaAzureProtectionProfileDetails : ASRProtectionProfileProviderSettingsDetails
    {
        // Summary:
        //     Optional.
        public CustomerStorageAccount ActiveStorageAccount { get; set; }
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
            this.ID = pe.Id;
            this.ProtectionContainerId = pe.Properties.ProtectionContainerId;
            this.Name = pe.Name;
            this.FriendlyName = pe.Properties.FriendlyName;
            this.Type = pe.Type;
            this.FabricObjectId =
                (0 == string.Compare(this.Type, "VirtualMachine", StringComparison.OrdinalIgnoreCase)) ?
                pe.Properties.FabricObjectId.ToUpper() :
                pe.Properties.FabricObjectId;
            this.ProtectionStatus = pe.Properties.ProtectionStatus;
            this.ProtectionStateDescription = pe.Properties.ProtectionStateDescription;
            // this.CanCommit = pe.CanCommit;
            // this.CanFailover = pe.CanFailover;
            // this.CanReverseReplicate = pe.CanReverseReplicate;
            this.AllowedOperations = pe.Properties.AllowedOperations;
            this.ReplicationProvider = pe.Properties.ReplicationProvider;
            this.ActiveLocation = pe.Properties.ActiveLocation;
            this.ReplicationHealth = pe.Properties.ReplicationHealth;
            this.TestFailoverStateDescription = pe.Properties.TestFailoverStateDescription;

            if (pe.Properties.ReplicationProviderSettings != null)
            {
                if (0 == string.Compare(
                    pe.Properties.ReplicationProvider,
                    Constants.HyperVReplicaAzure,
                    StringComparison.OrdinalIgnoreCase))
                {
                    if (pe.Properties.ReplicationProviderSettings is AzureProtectionEntityProviderSettings)
                    {
                        AzureProtectionEntityProviderSettings providerSettings =
                            (AzureProtectionEntityProviderSettings)pe.Properties.ReplicationProviderSettings;

                        AzureVmDiskDetails diskDetails = providerSettings.VMDiskDetails;
                        this.UpdateDiskDetails(diskDetails);

                        // also take the VM properties
                    }
                    else if (pe.Properties.ReplicationProviderSettings is OnPremProtectionEntityProviderSettings)
                    {
                        OnPremProtectionEntityProviderSettings providerSettings =
                            (OnPremProtectionEntityProviderSettings)pe.Properties.ReplicationProviderSettings;

                        AzureVmDiskDetails diskDetails = providerSettings.VMDiskDetails;
                        this.UpdateDiskDetails(diskDetails);
                    }
                }
                else
                {
                    OnPremProtectionEntityProviderSettings providerSettings =
                        (OnPremProtectionEntityProviderSettings)pe.Properties.ReplicationProviderSettings;

                    AzureVmDiskDetails diskDetails = providerSettings.VMDiskDetails;
                    this.UpdateDiskDetails(diskDetails);
                }
            }

            if (pe.Properties.ProtectionProfile != null &&
                !string.IsNullOrWhiteSpace(pe.Properties.ProtectionProfile.Id))
            {
                this.ProtectionProfile = new ASRProtectionProfile(pe.Properties.ProtectionProfile);
            }
        }

        private void UpdateDiskDetails(AzureVmDiskDetails diskDetails)
        {
            this.Disks = new List<VirtualHardDisk>();
            foreach (var disk in diskDetails.Disks)
            {
                VirtualHardDisk hd = new VirtualHardDisk();
                hd.Id = disk.Id;
                hd.Name = disk.Name;
                this.Disks.Add(hd);
            }

            this.OSDiskId = diskDetails.VHDId;
            this.OSDiskName = diskDetails.OsDisk;
            this.OS = diskDetails.OsType;
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
            string protectedOrNot,
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
            // this.ServerId = serverId;
            this.ProtectionContainerId = protectionContainerId;
            this.Name = name;
            this.Type = type;
            this.FabricObjectId =
                (0 == string.Compare(this.Type, "VirtualMachine", StringComparison.OrdinalIgnoreCase)) ?
                fabricObjectId.ToUpper() :
                fabricObjectId;
            this.ProtectionStatus = protectedOrNot;
            this.ProtectionStateDescription = protectionStateDescription;
            // this.CanCommit = canCommit;
            // this.CanFailover = canFailover;
            // this.CanReverseReplicate = canReverseReplicate;
            // this.AllowedActions =
            this.ReplicationProvider = replicationProvider;
            this.ActiveLocation = activeLocation;
            this.ReplicationHealth = replicationHealth;
            this.TestFailoverStateDescription = testFailoverStateDescription;
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

        ///// <summary>
        ///// Gets or sets Server ID.
        ///// </summary>
        //public string ServerId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is protected or not.
        /// </summary>
        public string ProtectionStatus { get; set; }

        ///// <summary>
        ///// Gets or sets a value indicating whether it can be committed or not.
        ///// </summary>
        //public bool CanCommit { get; set; }

        ///// <summary>
        ///// Gets or sets a value indicating whether it can be failed over or not.
        ///// </summary>
        //public bool CanFailover { get; set; }

        ///// <summary>
        ///// Gets or sets a value indicating whether it can be reverse replicated or not.
        ///// </summary>
        //public bool CanReverseReplicate { get; set; }

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
        /// Gets or sets ProtectionProfile.
        /// </summary>
        public ASRProtectionProfile ProtectionProfile { get; set; }

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
            this.ID = task.Id;
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
            this.ID = job.Id;
            this.Type = job.Type;
            this.JobType = job.Properties.ScenarioName;
            this.DisplayName = job.Properties.DisplayName;
            this.ClientRequestId = job.Properties.ActivityId;
            this.State = job.Properties.State;
            this.StateDescription = job.Properties.StateDescription;
            this.EndTime = job.Properties.EndTime;
            this.StartTime = job.Properties.StartTime;
            this.Name = job.Name;
            this.TargetObjectId = job.Properties.TargetObjectId;
            this.TargetObjectName = job.Properties.TargetObjectName;
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
                this.TargetObjectType = job.Properties.TargetObjectType;
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
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// Gets or sets End timestamp.
        /// </summary>
        public DateTimeOffset? EndTime { get; set; }

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
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
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
            this.ResouceGroupName = PSRecoveryServicesClient.GetResourceGroup(vault.Id);
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
            this.ResouceGroupName = PSRecoveryServicesClient.GetResourceGroup(vault.Id);
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
        /// Gets or sets Resouce group name.
        /// </summary>
        public string ResouceGroupName { get; set; }

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
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
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

    /// <summary>
    /// Partial details of a NIC of a VM.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related classes together.")]
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