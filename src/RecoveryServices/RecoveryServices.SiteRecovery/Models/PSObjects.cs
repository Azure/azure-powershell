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
using System.Text;
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
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
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
        public ASRVaultSettings(
            ASRVaultCreds asrVaultCreds)
        {
            this.ResourceName = asrVaultCreds.ResourceName;
            this.ResourceGroupName = asrVaultCreds.ResourceGroupName;
            this.ResourceNamespace = asrVaultCreds.ResourceNamespace;
            this.ResouceType = asrVaultCreds.ARMResourceType;
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
        public ASRRecoveryServicesProvider(
            RecoveryServicesProvider provider)
        {
            this.ID = provider.Id;
            this.Name = provider.Name;
            this.FriendlyName = provider.Properties.FriendlyName;
            if (provider.Properties.LastHeartBeat != null)
            {
                this.LastHeartbeat = (DateTime)provider.Properties.LastHeartBeat;
            }
            this.ProviderVersion = provider.Properties.ProviderVersion;
            this.ServerVersion = provider.Properties.ServerVersion;
            this.Connected = provider.Properties.ConnectionStatus.ToLower()
                                 .CompareTo("connected") ==
                             0 ? true : false;
            this.FabricType = provider.Properties.FabricType;
            this.Type = provider.Type;
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
        public ASRFabric(
            Fabric fabric)
        {
            this.Name = fabric.Name;
            this.FriendlyName = fabric.Properties.FriendlyName;
            this.ID = fabric.Id;
            this.Type = fabric.Type;
            this.SiteIdentifier = fabric.Properties.InternalIdentifier;

            // Populate Fabric Specific Details for VMWare.
            if (fabric.Properties.CustomDetails is VMwareDetails)
            {
                this.FabricType = Constants.VMware;
                var vmwareFabricSpecificDetails =
                    fabric.Properties.CustomDetails as VMwareDetails;
                var inMageFabricSpecificDetails = new ASRVMWareSpecificDetails
                {
                    HostName = vmwareFabricSpecificDetails.HostName,
                    IpAddress = vmwareFabricSpecificDetails.IpAddress,
                    AgentVersion = vmwareFabricSpecificDetails.AgentVersion,
                    ProtectedServers = vmwareFabricSpecificDetails.ProtectedServers,
                    LastHeartbeat = vmwareFabricSpecificDetails.LastHeartbeat,
                    CsServiceStatus = vmwareFabricSpecificDetails.CsServiceStatus,
                    VersionStatus = vmwareFabricSpecificDetails.VersionStatus,
                    ProcessServers = new List<ASRProcessServer>(),
                    MasterTargetServers = new List<ASRMasterTargetServer>(),
                    RunAsAccounts = new List<ASRRunAsAccount>()
                };

                foreach (var p in vmwareFabricSpecificDetails.ProcessServers)
                {
                    inMageFabricSpecificDetails.ProcessServers.Add(new ASRProcessServer(p));
                }

                foreach (var m in vmwareFabricSpecificDetails.MasterTargetServers)
                {
                    inMageFabricSpecificDetails.MasterTargetServers.Add(
                        new ASRMasterTargetServer(m));
                }

                foreach (var r in vmwareFabricSpecificDetails.RunAsAccounts)
                {
                    inMageFabricSpecificDetails.RunAsAccounts.Add(new ASRRunAsAccount(r));
                }

                this.FabricSpecificDetails = inMageFabricSpecificDetails;
            }
            else if (fabric.Properties.CustomDetails is HyperVSiteDetails)
            {
                this.FabricType = Constants.HyperVSite;
            }
            else if (fabric.Properties.CustomDetails is AzureFabricSpecificDetails)
            {
                this.FabricType = Constants.Azure;
                var azureFabricSpecificDetails = fabric.Properties.CustomDetails as AzureFabricSpecificDetails;
                this.FabricSpecificDetails = new ASRAzureFabricSpecificDetails
                {
                    Location = azureFabricSpecificDetails != null ? azureFabricSpecificDetails.Location : null
                };
            }
            else if (fabric.Properties.CustomDetails is VmmDetails)
            {
                this.FabricType = Constants.VMM;
            }
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
        ///     Gets or sets fabric type.
        /// </summary>
        public string FabricType { get; set; }

        /// <summary>
        ///     Gets or sets site SiteIdentifier.
        /// </summary>
        public string SiteIdentifier { get; set; }

        /// <summary>
        ///     Gets or sets site SiteIdentifier.
        /// </summary>
        public ASRFabricSpecificDetails FabricSpecificDetails { get; set; }

        #endregion
    }

    /// <summary>
    ///     Fabric Specific Details.
    /// </summary>
    public class ASRFabricSpecificDetails
    {
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
        public ASRProtectionContainerMapping(
            ProtectionContainerMapping pcm)
        {
            this.Name = pcm.Name;
            this.ID = pcm.Id;
            this.Health = pcm.Properties.Health;
            if (pcm.Properties.HealthErrorDetails != null)
            {
                this.HealthErrorDetails = pcm.Properties.HealthErrorDetails.ToList().
                        ConvertAll(healthError => new ASRHealthError_2016_08_10(healthError));
            }
            this.PolicyFriendlyName = pcm.Properties.PolicyFriendlyName;
            this.PolicyId = pcm.Properties.PolicyId;
            this.SourceFabricFriendlyName = pcm.Properties.SourceFabricFriendlyName;
            this.SourceProtectionContainerFriendlyName =
                pcm.Properties.SourceProtectionContainerFriendlyName;
            this.State = pcm.Properties.State;
            this.TargetFabricFriendlyName = pcm.Properties.TargetFabricFriendlyName;
            this.TargetProtectionContainerFriendlyName =
                pcm.Properties.TargetProtectionContainerFriendlyName;
            this.TargetProtectionContainerId = pcm.Properties.TargetProtectionContainerId;
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
        public IList<ASRHealthError_2016_08_10> HealthErrorDetails { get; set; }

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
        public ASRProtectionContainer(
            ProtectionContainer pc,
            List<ASRPolicy> availablePolicies,
            List<ASRProtectionContainerMapping> protectionContainerMappings)
        {
            this.ID = pc.Id;
            this.Name = pc.Name;
            this.FriendlyName = pc.Properties.FriendlyName;
            this.FabricFriendlyName = pc.Properties.FabricFriendlyName;
            this.Role = pc.Properties.Role;
            this.FabricType = pc.Properties.FabricType;
            this.Type = pc.Type;
            this.AvailablePolicies = availablePolicies;
            this.ProtectionContainerMappings = protectionContainerMappings;
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
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
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
        public ASRPolicy(
            Policy policy)
        {
            this.ID = policy.Id;
            this.Name = policy.Name;
            this.FriendlyName = policy.Properties.FriendlyName;
            this.Type = policy.Type;

            if (policy.Properties.ProviderSpecificDetails is HyperVReplicaBluePolicyDetails)
            {
                var details =
                    (HyperVReplicaBluePolicyDetails)policy.Properties.ProviderSpecificDetails;

                var replicationProviderSettings = new ASRHyperVReplicaPolicyDetails();

                this.ReplicationProvider = Constants.HyperVReplica2012R2;
                replicationProviderSettings.ReplicaDeletionOption = details.ReplicaDeletionOption;
                replicationProviderSettings.ApplicationConsistentSnapshotFrequencyInHours =
                    (int)details.ApplicationConsistentSnapshotFrequencyInHours;
                replicationProviderSettings.Compression = details.Compression;
                replicationProviderSettings.ReplicationFrequencyInSeconds = 300;
                replicationProviderSettings.AllowedAuthenticationType =
                    details.AllowedAuthenticationType == 1 ? Constants.AuthenticationTypeKerberos
                        : Constants.AuthenticationTypeCertificate;
                replicationProviderSettings.RecoveryPoints = (int)details.RecoveryPoints;
                replicationProviderSettings.InitialReplicationMethod = string.Compare(
                                                                           details
                                                                               .InitialReplicationMethod,
                                                                           "OverNetwork",
                                                                           StringComparison
                                                                               .OrdinalIgnoreCase) ==
                                                                       0 ? Constants
                    .OnlineReplicationMethod : Constants.OfflineReplicationMethod;
                replicationProviderSettings.ReplicationPort = (ushort)details.ReplicationPort;
                replicationProviderSettings.OnlineReplicationStartTime =
                    details.OnlineReplicationStartTime == null ? (TimeSpan?)null
                        : TimeSpan.Parse(details.OnlineReplicationStartTime);

                this.ReplicationProviderSettings = replicationProviderSettings;
            }
            else if (policy.Properties.ProviderSpecificDetails is HyperVReplicaPolicyDetails)
            {
                var details = (HyperVReplicaPolicyDetails)policy.Properties.ProviderSpecificDetails;

                var replicationProviderSettings = new ASRHyperVReplicaPolicyDetails();

                this.ReplicationProvider = Constants.HyperVReplica2012;
                replicationProviderSettings.ReplicaDeletionOption = details.ReplicaDeletionOption;
                replicationProviderSettings.ApplicationConsistentSnapshotFrequencyInHours =
                    (int)details.ApplicationConsistentSnapshotFrequencyInHours;
                replicationProviderSettings.Compression = details.Compression;
                replicationProviderSettings.AllowedAuthenticationType =
                    details.AllowedAuthenticationType == 1 ? Constants.AuthenticationTypeKerberos
                        : Constants.AuthenticationTypeCertificate;
                replicationProviderSettings.RecoveryPoints = (int)details.RecoveryPoints;
                replicationProviderSettings.InitialReplicationMethod = string.Compare(
                                                                           details
                                                                               .InitialReplicationMethod,
                                                                           "OverNetwork",
                                                                           StringComparison
                                                                               .OrdinalIgnoreCase) ==
                                                                       0 ? Constants
                    .OnlineReplicationMethod : Constants.OfflineReplicationMethod;
                replicationProviderSettings.ReplicationPort = (ushort)details.ReplicationPort;
                replicationProviderSettings.OnlineReplicationStartTime =
                    details.OnlineReplicationStartTime == null ? (TimeSpan?)null
                        : TimeSpan.Parse(details.OnlineReplicationStartTime);

                this.ReplicationProviderSettings = replicationProviderSettings;
            }
            else if (policy.Properties.ProviderSpecificDetails is HyperVReplicaAzurePolicyDetails)
            {
                var details =
                    (HyperVReplicaAzurePolicyDetails)policy.Properties.ProviderSpecificDetails;

                var replicationProviderSettings = new ASRHyperVReplicaAzurePolicyDetails();

                this.ReplicationProvider = Constants.HyperVReplicaAzure;
                replicationProviderSettings.ApplicationConsistentSnapshotFrequencyInHours =
                    (int)details.ApplicationConsistentSnapshotFrequencyInHours;
                replicationProviderSettings.ReplicationFrequencyInSeconds =
                    (int)details.ReplicationInterval;
                replicationProviderSettings.RecoveryPoints =
                    (int)details.RecoveryPointHistoryDurationInHours;
                replicationProviderSettings.OnlineReplicationStartTime =
                    details.OnlineReplicationStartTime == null ? (TimeSpan?)null
                        : TimeSpan.Parse(details.OnlineReplicationStartTime);
                replicationProviderSettings.Encryption = details.Encryption;
                replicationProviderSettings.ActiveStorageAccountId = details.ActiveStorageAccountId;

                this.ReplicationProviderSettings = replicationProviderSettings;
            }
            else if (policy.Properties.ProviderSpecificDetails is InMageAzureV2PolicyDetails)
            {
                var details =
                    (InMageAzureV2PolicyDetails)policy.Properties.ProviderSpecificDetails;

                var replicationProviderSettings =
                    new ASRInMageAzureV2PolicyDetails
                    {
                        AppConsistentFrequencyInMinutes =
                            (int)details.AppConsistentFrequencyInMinutes,
                        RecoveryPointHistory = (int)details.RecoveryPointHistory,
                        RecoveryPointThresholdInMinutes =
                            (int)details.RecoveryPointThresholdInMinutes,
                        CrashConsistentFrequencyInMinutes =
                            (int)details.CrashConsistentFrequencyInMinutes,
                        MultiVmSyncStatus = details.MultiVmSyncStatus
                    };

                this.ReplicationProviderSettings = replicationProviderSettings;
                this.ReplicationProvider = Constants.InMageAzureV2;
            }
            else if (policy.Properties.ProviderSpecificDetails is InMagePolicyDetails)
            {
                var details =
                    (InMagePolicyDetails)policy.Properties.ProviderSpecificDetails;

                var replicationProviderSettings = new ASRInMagePolicyDetails
                {
                    AppConsistentFrequencyInMinutes = (int)details.AppConsistentFrequencyInMinutes,
                    RecoveryPointHistory = (int)details.RecoveryPointHistory,
                    RecoveryPointThresholdInMinutes = (int)details.RecoveryPointThresholdInMinutes,
                    MultiVmSyncStatus = details.MultiVmSyncStatus
                };

                this.ReplicationProviderSettings = replicationProviderSettings;
                this.ReplicationProvider = Constants.InMage;
            }
            else if (policy.Properties.ProviderSpecificDetails is A2APolicyDetails)
            {
                var details =
                    (A2APolicyDetails)policy.Properties.ProviderSpecificDetails;

                var replicationProviderSettings =
                    new ASRAzureToAzurePolicyDetails
                    {
                        AppConsistentFrequencyInMinutes =
                            (int)details.AppConsistentFrequencyInMinutes,
                        CrashConsistentFrequencyInMinutes =
                            (int)details.CrashConsistentFrequencyInMinutes,
                        MultiVmSyncStatus = details.MultiVmSyncStatus,
                        RecoveryPointHistory = (int)details.RecoveryPointHistory,
                        RecoveryPointThresholdInMinutes =
                            (int)details.RecoveryPointThresholdInMinutes
                    };

                this.ReplicationProviderSettings = replicationProviderSettings;
                this.ReplicationProvider = Constants.A2A;
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
    ///     InMageAzureV2 Specific Policy Details.
    /// </summary>
    public class ASRInMageAzureV2PolicyDetails : ASRPolicyProviderSettingsDetails
    {
        // Gets or sets the app consistent snapshot frequency in minutes.
        public int AppConsistentFrequencyInMinutes { get; set; }

        // Gets or sets the crash consistent snapshot frequency in minutes.
        public int CrashConsistentFrequencyInMinutes { get; set; }

        // Gets or sets a value indicating whether multi-VM sync has to be enabled.
        public string MultiVmSyncStatus { get; set; }

        // Gets or sets the duration in minutes until which the recovery points need to be stored.
        public int RecoveryPointHistory { get; set; }

        // Gets or sets the recovery point threshold in minutes. 
        public int RecoveryPointThresholdInMinutes { get; set; }
    }

    /// <summary>
    ///     InMage Specific Policy Details.
    /// </summary>
    public class ASRInMagePolicyDetails : ASRPolicyProviderSettingsDetails
    {
        // Gets or sets the app consistent snapshot frequency in minutes.
        public int AppConsistentFrequencyInMinutes { get; set; }

        // Gets or sets a value indicating whether multi-VM sync has to be enabled.
        public string MultiVmSyncStatus { get; set; }

        // Gets or sets the duration in minutes until which the recovery points need to be stored.
        public int RecoveryPointHistory { get; set; }

        // Gets or sets the recovery point threshold in minutes. 
        public int RecoveryPointThresholdInMinutes { get; set; }
    }

    /// <summary>
    /// ASR AzureToAzure policy details.
    /// </summary>
    public class ASRAzureToAzurePolicyDetails : ASRPolicyProviderSettingsDetails
    {
        /// <summary>
        /// Gets or sets the app consistent snapshot frequency in minutes.
        /// </summary>
        public int AppConsistentFrequencyInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the crash consistent snapshot frequency in minutes.
        /// </summary>
        public int CrashConsistentFrequencyInMinutes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether multi-VM sync has to be enabled.
        /// </summary>
        public string MultiVmSyncStatus { get; set; }

        /// <summary>
        /// Gets or sets the duration in minutes until which the recovery points need to be stored.
        /// </summary>
        public int RecoveryPointHistory { get; set; }

        /// <summary>
        /// Gets or sets the recovery point threshold in minutes.
        /// </summary>
        public int RecoveryPointThresholdInMinutes { get; set; }
    }

    /// <summary>
    ///     ASR VM Nic Details
    /// </summary>
    public class ASRVMNicDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRVMNicDetails" /> class.
        /// </summary>
        public ASRVMNicDetails()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRVMNicDetails" /> class.
        /// </summary>
        public ASRVMNicDetails(
            VMNicDetails vMNicDetails)
        {
            this.NicId = vMNicDetails.NicId;
            this.ReplicaNicId = vMNicDetails.ReplicaNicId;
            this.SourceNicArmId = vMNicDetails.SourceNicArmId;
            this.VMNetworkName = vMNicDetails.VMNetworkName;
            this.VMSubnetName = vMNicDetails.VMSubnetName;
            this.RecoveryVMNetworkId = vMNicDetails.RecoveryVMNetworkId;
            this.RecoveryVMSubnetName = vMNicDetails.RecoveryVMSubnetName;
            this.ReplicaNicStaticIPAddress = vMNicDetails.ReplicaNicStaticIPAddress;
            this.IpAddressType = vMNicDetails.IpAddressType;
            this.SelectionType = vMNicDetails.SelectionType;
            this.PrimaryNicStaticIPAddress = vMNicDetails.PrimaryNicStaticIPAddress;
            this.RecoveryNicIpAddressType = vMNicDetails.RecoveryNicIpAddressType;
        }

        //
        // Summary:
        //     Gets or sets primary nic static IP address.
        public string PrimaryNicStaticIPAddress { get; set; }

        //
        // Summary:
        //     Gets or sets IP allocation type for recovery VM.
        public string RecoveryNicIpAddressType { get; set; }

        //
        // Summary:
        //     Gets or sets the replica nic Id.
        public string ReplicaNicId { get; set; }

        //
        // Summary:
        //     Gets or sets the source nic ARM Id.
        public string SourceNicArmId { get; set; }

        /// <summary>
        ///     Gets or sets ipv4 address type.
        /// </summary>
        public string IpAddressType { get; set; }

        /// <summary>
        ///     Gets or sets the nic Id.
        /// </summary>
        public string NicId { get; set; }

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
        ///     Gets or sets selection type for failover.
        /// </summary>
        public string SelectionType { get; set; }

        /// <summary>
        ///     Gets or sets VM network name.
        /// </summary>
        public string VMNetworkName { get; set; }

        /// <summary>
        ///     Gets or sets VM subnet name.
        /// </summary>
        public string VMSubnetName { get; set; }
    }

    /// <summary>
    ///     Azure Site Recovery Protectable Item
    /// </summary>
    public class ASRProtectableItem
    {
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
        public ASRProtectableItem(
            ProtectableItem pi)
        {
            this.ID = pi.Id;
            this.Name = pi.Name;
            this.FriendlyName = pi.Properties.FriendlyName;
            this.ProtectionContainerId = Utilities.GetValueFromArmId(
                pi.Id,
                ARMResourceTypeConstants.ReplicationProtectionContainers);
            this.ProtectionStatus = pi.Properties.ProtectionStatus;
            this.ReplicationProtectedItemId = pi.Properties.ReplicationProtectedItemId;
            this.SupportedReplicationProviders = pi.Properties.SupportedReplicationProviders;
            if (pi.Properties.CustomDetails != null)
            {
                if (pi.Properties.CustomDetails is HyperVVirtualMachineDetails)
                {
                    var providerSettings =
                        (HyperVVirtualMachineDetails)pi.Properties.CustomDetails;

                    var diskDetails = providerSettings.DiskDetails;
                    this.UpdateDiskDetails(diskDetails);
                    this.OS = providerSettings.OsDetails == null
                        ? null
                        : providerSettings.OsDetails.OsType;
                    this.FabricObjectId = providerSettings.SourceItemId;
                }
                else if (pi.Properties.CustomDetails is VMwareVirtualMachineDetails)
                {
                    var providerSettings =
                        (VMwareVirtualMachineDetails)pi.Properties.CustomDetails;

                    // Set the VMWare specific properties.
                    this.FabricSpecificVMDetails = new ASRVMWareSpecificVMDetails
                    {
                        IpAddress = providerSettings.IpAddress,
                        AgentVersion = providerSettings.AgentVersion,
                        AgentInstalled = providerSettings.AgentInstalled,
                        AgentGeneratedId = providerSettings.AgentGeneratedId,
                        PoweredOn = providerSettings.PoweredOn,
                        DiscoveryType = providerSettings.DiscoveryType
                    };

                    // Update Disk Details for VMWare.
                    var diskDetails = providerSettings.DiskDetails;
                    this.UpdateDiskDetails(diskDetails);
                    this.OS = providerSettings.OsType;
                }
            }
        }

        /// <summary>
        ///     Gets or sets OS.
        /// </summary>
        public List<AsrVirtualHardDisk> Disks { get; set; }

        /// <summary>
        ///     Gets or sets fabric object ID.
        /// </summary>
        public string FabricObjectId { get; set; }

        /// <summary>
        ///     Gets or sets Fabric Specific Virtual Machine Details.
        /// </summary>
        public ASRFabricSpecificVMDetails FabricSpecificVMDetails { get; set; }

        /// <summary>
        ///     Gets or sets Friendly Name of the Protection entity.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Protection entity ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets Name of the Protection entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets OS.
        /// </summary>
        public string OS { get; set; }

        /// <summary>
        ///     Gets or sets OSDiskVHDId.
        /// </summary>
        public string OSDiskId { get; set; }

        /// <summary>
        ///     Gets or sets OS DiskName.
        /// </summary>
        public string OSDiskName { get; set; }

        /// <summary>
        ///     Gets or sets Protection container ID.
        /// </summary>
        public string ProtectionContainerId { get; set; }

        /// <summary>
        ///     Gets or sets a value that lists allowed operations.
        /// </summary>
        public IList<string> ProtectionReadinessErrors { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether it is protected or not.
        /// </summary>
        public string ProtectionStatus { get; set; }

        /// <summary>
        ///     Gets or sets Replication protected item id.
        /// </summary>
        public string ReplicationProtectedItemId { get; set; }

        /// <summary>
        ///     Gets or sets Replication provider.
        /// </summary>
        public IList<string> SupportedReplicationProviders { get; set; }

        private void UpdateDiskDetails(
            IList<DiskDetails> diskDetails)
        {
            this.Disks = new List<AsrVirtualHardDisk>();
            foreach (var disk in diskDetails)
            {
                var hd = new AsrVirtualHardDisk();
                hd.Id = disk.VhdId;
                hd.Name = disk.VhdName;
                this.Disks.Add(hd);
            }

            var OSDisk = diskDetails.SingleOrDefault(
                d => string.Compare(
                        d.VhdType,
                        Constants.OperatingSystem,
                        StringComparison.OrdinalIgnoreCase) ==
                    0);
            if (OSDisk != null)
            {
                this.OSDiskId = OSDisk.VhdId;
                this.OSDiskName = OSDisk.VhdName;
            }
        }

        // Update Disk Details for VMWare.
        private void UpdateDiskDetails(IList<InMageDiskDetails> diskDetails)
        {
            // Update all the Disks.
            this.Disks = new List<AsrVirtualHardDisk>();
            foreach (var disk in diskDetails)
            {
                var hd = new AsrVirtualHardDisk();
                hd.Id = disk.DiskId;
                hd.Name = disk.DiskName;

                // Update all the Volumes in this Disk.
                hd.Volumes = new List<AsrVolume>();
                foreach (var vol in disk.VolumeList)
                {
                    var volume = new AsrVolume();
                    volume.Label = vol.Label;
                    volume.Name = vol.Name;
                    hd.Volumes.Add(volume);
                }
                this.Disks.Add(hd);
            }

            // Update the OS Disk.
            var OSDisk =
                diskDetails.SingleOrDefault(
                    d => string.Compare(
                            d.DiskType,
                            Constants.OperatingSystem,
                            StringComparison.OrdinalIgnoreCase) ==
                        0);
            if (OSDisk != null)
            {
                this.OSDiskId = OSDisk.DiskId;
                this.OSDiskName = OSDisk.DiskName;
            }
        }
    }

    /// <summary>
    ///     Fabric Specific Virtual Machine Details.
    /// </summary>
    public class ASRFabricSpecificVMDetails
    {
    }

    /// Azure Site Recovery Replication Protected Item.
    /// </summary>
    public class ASRReplicationProtectedItem
    {
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
        public ASRReplicationProtectedItem(
            ReplicationProtectedItem rpi)
        {
            this.ID = rpi.Id;
            this.Name = rpi.Name;
            this.FriendlyName = rpi.Properties.FriendlyName;
            this.Type = rpi.Type;
            this.ActiveLocation = rpi.Properties.ActiveLocation;
            this.AllowedOperations = rpi.Properties.AllowedOperations;
            this.CurrentScenario = rpi.Properties.CurrentScenario;
            this.FailoverRecoveryPointId = rpi.Properties.FailoverRecoveryPointId;
            this.LastSuccessfulFailoverTime = rpi.Properties.LastSuccessfulFailoverTime;
            this.LastSuccessfulTestFailoverTime = rpi.Properties.LastSuccessfulTestFailoverTime;
            this.PolicyFriendlyName = rpi.Properties.PolicyFriendlyName;
            this.PolicyID = rpi.Properties.PolicyId;
            this.PrimaryFabricFriendlyName = rpi.Properties.PrimaryFabricFriendlyName;
            this.PrimaryProtectionContainerFriendlyName =
                rpi.Properties.PrimaryProtectionContainerFriendlyName;
            this.ProtectableItemId = rpi.Properties.ProtectableItemId;
            this.ProtectedItemType = rpi.Properties.ProtectedItemType;
            this.ProtectionState = rpi.Properties.ProtectionState;
            this.ProtectionStateDescription = rpi.Properties.ProtectionStateDescription;
            this.RecoveryFabricFriendlyName = rpi.Properties.RecoveryFabricFriendlyName;
            this.RecoveryFabricId = rpi.Properties.RecoveryFabricId;
            this.RecoveryProtectionContainerFriendlyName =
                rpi.Properties.RecoveryProtectionContainerFriendlyName;
            this.RecoveryServicesProviderId = rpi.Properties.RecoveryServicesProviderId;
            this.ReplicationHealth = rpi.Properties.ReplicationHealth;
            if (rpi.Properties.HealthErrors != null)
            {
                this.ReplicationHealthErrors = rpi.Properties.HealthErrors.ToList().ConvertAll(
                    healthError => new ASRHealthError_2016_08_10(healthError));
            }
            this.TestFailoverState = rpi.Properties.TestFailoverState;
            this.TestFailoverStateDescription = rpi.Properties.TestFailoverStateDescription;

            if (rpi.Properties.ProviderSpecificDetails is HyperVReplicaAzureReplicationDetails)
            {
                var providerSpecificDetails =
                    (HyperVReplicaAzureReplicationDetails)rpi.Properties.ProviderSpecificDetails;

                this.ReplicationProvider = Constants.HyperVReplicaAzure;
                this.RecoveryAzureVMName = providerSpecificDetails.RecoveryAzureVmName;
                this.RecoveryAzureVMSize = providerSpecificDetails.RecoveryAzureVMSize;
                this.RecoveryAzureStorageAccount =
                    providerSpecificDetails.RecoveryAzureStorageAccount;
                this.SelectedRecoveryAzureNetworkId =
                    providerSpecificDetails.SelectedRecoveryAzureNetworkId;

                this.RecoveryResourceGroupId =
                    providerSpecificDetails.RecoveryAzureResourceGroupId;

                if (providerSpecificDetails.VmNics != null)
                {
                    this.NicDetailsList = new List<ASRVMNicDetails>();
                    foreach (var n in providerSpecificDetails.VmNics)
                    {
                        this.NicDetailsList.Add(new ASRVMNicDetails(n));
                    }
                }

                this.ProviderSpecificDetails = new ASRHyperVReplicaAzureSpecificRPIDetails(providerSpecificDetails);

            }
            else if (rpi.Properties.ProviderSpecificDetails is HyperVReplicaReplicationDetails)
            {
                this.ReplicationProvider = Constants.HyperVReplica2012;
            }
            else if (rpi.Properties.ProviderSpecificDetails is HyperVReplicaBlueReplicationDetails)
            {
                this.ReplicationProvider = Constants.HyperVReplica2012R2;
            }
            else if (rpi.Properties.ProviderSpecificDetails is InMageAzureV2ReplicationDetails)
            {
                this.ReplicationProvider = Constants.InMageAzureV2;
                var providerSpecificDetails =
                    (InMageAzureV2ReplicationDetails)rpi.Properties.ProviderSpecificDetails;

                // Set the common properties specific to InMageAzureV2.
                this.RecoveryAzureVMName = providerSpecificDetails.RecoveryAzureVMName;
                this.RecoveryAzureVMSize = providerSpecificDetails.RecoveryAzureVMSize;
                this.RecoveryResourceGroupId =
                    providerSpecificDetails.RecoveryAzureResourceGroupId;
                this.RecoveryAzureStorageAccount =
                    providerSpecificDetails.RecoveryAzureStorageAccount;
                this.SelectedRecoveryAzureNetworkId =
                    providerSpecificDetails.SelectedRecoveryAzureNetworkId;

                if (providerSpecificDetails.VmNics != null)
                {
                    this.NicDetailsList = new List<ASRVMNicDetails>();
                    foreach (var n in providerSpecificDetails.VmNics)
                    {
                        this.NicDetailsList.Add(new ASRVMNicDetails(n));
                    }
                }

                // Set the InMageAzureV2 specific properties.
                var inMageAzureV2RPIDetails =
                    new ASRInMageAzureV2SpecificRPIDetails(providerSpecificDetails);

                if (providerSpecificDetails.ProtectedDisks != null)
                {
                    inMageAzureV2RPIDetails.ProtectedDiskDetails = new List<AsrVirtualHardDisk>();
                    foreach (var pd in providerSpecificDetails.ProtectedDisks)
                    {
                        inMageAzureV2RPIDetails.ProtectedDiskDetails.Add(
                            new AsrVirtualHardDisk
                            {
                                Id = pd.DiskId,
                                Name = pd.DiskName
                            });
                    }
                }

                this.ProviderSpecificDetails = inMageAzureV2RPIDetails;
            }
            else if (rpi.Properties.ProviderSpecificDetails is InMageReplicationDetails)
            {
                this.ReplicationProvider = Constants.InMage;
                var providerSpecificDetails =
                    (InMageReplicationDetails)rpi.Properties.ProviderSpecificDetails;
                // Set the common properties specific to InMage.
                if (providerSpecificDetails.VmNics != null)
                {
                    this.NicDetailsList = new List<ASRVMNicDetails>();
                    foreach (var n in providerSpecificDetails.VmNics)
                    {
                        this.NicDetailsList.Add(new ASRVMNicDetails(n));
                    }
                }

                // Set the InMage specific properties.
                var inMageRPIDetails = new ASRInMageSpecificRPIDetails
                {
                    IpAddress = providerSpecificDetails.IpAddress,
                    ProcessServerId = providerSpecificDetails.ProcessServerId,
                    MasterTargetId = providerSpecificDetails.MasterTargetId,
                    OSType = providerSpecificDetails.OsDetails != null
                        ? providerSpecificDetails.OsDetails.OsType
                        : null,
                    OSDiskId = providerSpecificDetails.OsDetails != null
                        ? providerSpecificDetails.OsDetails.OsVhdId
                        : null,
                    VHDName = providerSpecificDetails.OsDetails != null
                        ? providerSpecificDetails.OsDetails.VhdName
                        : null,
                    MultiVmGroupId = providerSpecificDetails.MultiVmGroupId,
                    MultiVmGroupName = providerSpecificDetails.MultiVmGroupName,
                    AgentVersion = providerSpecificDetails.AgentDetails.AgentVersion,
                    DiscoveryType = providerSpecificDetails.DiscoveryType,
                    LastHeartbeat = providerSpecificDetails.LastHeartbeat,
                    ProtectionStage = providerSpecificDetails.ProtectionStage
                };

                if (providerSpecificDetails.ProtectedDisks != null)
                {
                    inMageRPIDetails.ProtectedDiskDetails = new List<AsrVirtualHardDisk>();
                    foreach (var d in providerSpecificDetails.ProtectedDisks)
                    {
                        inMageRPIDetails.ProtectedDiskDetails.Add(
                            new AsrVirtualHardDisk
                            {
                                Id = d.DiskId,
                                Name = d.DiskName
                            });
                    }
                }

                this.ProviderSpecificDetails = inMageRPIDetails;
            }
            else if (rpi.Properties.ProviderSpecificDetails is A2AReplicationDetails)
            {
                // populate A2A specific  properties.
                this.ReplicationProvider = Constants.A2A;
                var a2aProviderSpecificDetails = (A2AReplicationDetails)rpi.Properties.ProviderSpecificDetails;

                this.RecoveryAzureVMName = a2aProviderSpecificDetails.RecoveryAzureVMName;
                this.RecoveryAzureVMSize = a2aProviderSpecificDetails.RecoveryAzureVMSize;
                this.SelectedRecoveryAzureNetworkId = a2aProviderSpecificDetails.SelectedRecoveryAzureNetworkId;
                this.ProtectionState = a2aProviderSpecificDetails.VmProtectionState;
                this.ProtectionStateDescription = a2aProviderSpecificDetails.VmProtectionStateDescription;
                this.ProviderSpecificDetails = new ASRAzureToAzureSpecificRPIDetails(a2aProviderSpecificDetails);
                if (a2aProviderSpecificDetails.VmNics != null)
                {
                    this.NicDetailsList =
                           a2aProviderSpecificDetails.VmNics?.ToList()
                           .ConvertAll(nic => new ASRVMNicDetails(nic));
                }
            }
        }

        /// <summary>
        ///     Gets or sets a active location of protection entity.
        /// </summary>
        public string ActiveLocation { get; set; }

        /// <summary>
        ///     Gets or sets a value that lists allowed operations.
        /// </summary>
        public IList<string> AllowedOperations { get; set; }

        /// <summary>
        ///     Gets or sets Current Scenario Details
        /// </summary>
        public CurrentScenarioDetails CurrentScenario { get; set; }

        /// <summary>
        ///     Gets or sets Failover Recovery Point Id
        /// </summary>
        public string FailoverRecoveryPointId { get; set; }

        /// <summary>
        ///     Gets or sets Friendly Name of the Protection entity.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Protection entity ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets Last Successful Failover Time
        /// </summary>
        public DateTime? LastSuccessfulFailoverTime { get; set; }

        /// <summary>
        ///     Gets or sets Last Successful TestFailover Time
        /// </summary>
        public DateTime? LastSuccessfulTestFailoverTime { get; set; }

        /// <summary>
        ///     Gets or sets Name of the Protection entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Nic Details of the Virtual machine.
        /// </summary>
        public List<ASRVMNicDetails> NicDetailsList { get; set; }

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
        public ASRProviderSpecificRPIDetails ProviderSpecificDetails { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Azure Storage Account of the Virtual machine.
        /// </summary>
        public string RecoveryAzureStorageAccount { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Azure VM Name of the Virtual machine.
        /// </summary>
        public string RecoveryAzureVMName { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Azure VM Size of the Virtual machine.
        /// </summary>
        public string RecoveryAzureVMSize { get; set; }

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
        ///     Gets or sets Recovery Azure Storage Account of the Virtual machine.
        /// </summary>
        public string RecoveryResourceGroupId { get; set; }

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
        public IList<ASRHealthError_2016_08_10> ReplicationHealthErrors { get; set; }

        /// <summary>
        ///     Gets or sets Replication provider.
        /// </summary>
        public string ReplicationProvider { get; set; }

        /// <summary>
        ///     Gets or sets Selected Recovery Azure Network Id of the Virtual machine.
        /// </summary>
        public string SelectedRecoveryAzureNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets Test Failover State
        /// </summary>
        public string TestFailoverState { get; set; }

        /// <summary>
        ///     Gets or sets Test Failover State Description
        /// </summary>
        public string TestFailoverStateDescription { get; set; }

        /// <summary>
        ///     Gets or sets type of the Protection entity.
        /// </summary>
        public string Type { get; set; }
    }

    /// <summary>
    ///     Provider Specific Replication Protected Item Details.
    /// </summary>
    public class ASRProviderSpecificRPIDetails
    {
    }

    /// <summary>
    ///     PS Recovery Point Class.
    /// </summary>
    public class ASRRecoveryPoint
    {
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
        public ASRRecoveryPoint(
            RecoveryPoint recoveryPoint)
        {
            this.ID = recoveryPoint.Id;
            this.Name = recoveryPoint.Name;
            this.Type = recoveryPoint.Type;
            this.RecoveryPointTime = recoveryPoint.Properties.RecoveryPointTime;
            this.RecoveryPointType = recoveryPoint.Properties.RecoveryPointType;
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
    }

    /// <summary>
    ///     ASRGroupTaskDetails of the Task.
    /// </summary>
    public class ASRGroupTaskDetails
    {
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
        public ASRGroupTaskDetails(
            GroupTaskDetails groupTaskDetails)
        {
            //this.Type = groupTaskDetails.Type;
            this.ChildTasks = new List<ASRTaskBase>();
            if (groupTaskDetails.ChildTasks != null)
            {
                this.ChildTasks = groupTaskDetails.ChildTasks.Select(ct => new ASRTaskBase(ct))
                    .ToList();
            }
        }

        /// <summary>
        ///     Gets or sets ASRGroupTaskDetails Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Child Tasks.
        /// </summary>
        private List<ASRTaskBase> ChildTasks { get; }
    }

    /// <summary>
    ///     ASRTaskBase.
    /// </summary>
    public class ASRTaskBase
    {
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
        public ASRTaskBase(
            Management.RecoveryServices.SiteRecovery.Models.ASRTask taskBase)
        {
            this.ID = taskBase.Name;
            this.Name = taskBase.FriendlyName;
            if (taskBase.EndTime != null)
            {
                this.EndTime = ((DateTime)taskBase.EndTime).ToLocalTime();
            }

            if (taskBase.StartTime != null)
            {
                this.StartTime = ((DateTime)taskBase.StartTime).ToLocalTime();
            }

            this.State = taskBase.State;
            this.StateDescription = taskBase.StateDescription;
        }

        /// <summary>
        ///     Gets or sets the end time.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        ///     Gets or sets Job ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets the task name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        ///     Gets or sets the Status.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     Gets or sets the State description, which tells the exact internal state.
        /// </summary>
        public string StateDescription { get; set; }
    }

    /// <summary>
    ///     Task of the Job.
    /// </summary>
    public class ASRTask
    {
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
        public ASRTask(
            Management.RecoveryServices.SiteRecovery.Models.ASRTask task)
        {
            this.ID = task.Name;
            if (task.EndTime != null)
            {
                this.EndTime = ((DateTime)task.EndTime).ToLocalTime();
            }
            this.Name = task.FriendlyName;
            if (task.StartTime != null)
            {
                this.StartTime = ((DateTime)task.StartTime).ToLocalTime();
            }
            this.State = task.State;
            this.StateDescription = task.StateDescription;
            if (task.GroupTaskCustomDetails != null)
            {
                this.GroupTaskDetails = new ASRGroupTaskDetails(task.GroupTaskCustomDetails);
            }
        }

        /// <summary>
        ///     Gets or sets the end time.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        ///     Gets or sets the GroupTaskDetails
        /// </summary>
        public ASRGroupTaskDetails GroupTaskDetails { get; set; }

        /// <summary>
        ///     Gets or sets Job ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets the task name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        ///     Gets or sets the Status.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     Gets or sets the State description, which tells the exact internal state.
        /// </summary>
        public string StateDescription { get; set; }
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
        public ASRJob(
            Job job)
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
            if ((job.Properties.AllowedActions != null) &&
                (job.Properties.AllowedActions.Count > 0))
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
                var errorDetails = new ASRErrorDetails();
                errorDetails.TaskId = error.TaskId;
                errorDetails.ServiceErrorDetails = new ASRServiceError(error.ServiceErrorDetails);
                errorDetails.ProviderErrorDetails =
                    new ASRProviderError(error.ProviderErrorDetails);
                this.Errors.Add(errorDetails);
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
        ///     Gets or sets the Provider error details.
        /// </summary>
        public ASRProviderError ProviderErrorDetails { get; set; }

        /// <summary>
        ///     Gets or sets the Service error details.
        /// </summary>
        public ASRServiceError ServiceErrorDetails { get; set; }

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
        public ASRServiceError(
            ServiceError serviceError) : base(serviceError)
        {
        }
    }

    /// <summary>
    ///     This class contains the provider error details per object.
    /// </summary>
    public class ASRProviderError
    {
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
        public ASRProviderError(
            ProviderError error)
        {
            //this.CreationTimeUtc = error.CreationTimeUtc;
            this.ErrorCode = (int)error.ErrorCode;
            this.ErrorId = error.ErrorId;
            this.ErrorMessage = error.ErrorMessage;
        }

        /// <summary>
        ///     Gets or sets the Time of the error creation.
        /// </summary>
        public DateTime CreationTimeUtc { get; set; }

        /// <summary>
        ///     Gets or sets the Error code.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        ///     Gets or sets the Provider error Id
        /// </summary>
        public string ErrorId { get; set; }

        /// <summary>
        ///     Gets or sets the Error message
        /// </summary>
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    ///     Represents Azure site recovery storage classification.
    /// </summary>
    public class ASRStorageClassification
    {
        /// <summary>
        ///     Gets or sets Storage classification friendly name.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Storage classification ARM Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets Storage classification ARM name.
        /// </summary>
        public string Name { get; set; }
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
    public class AsrVirtualHardDisk
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

        /// <summary>
        ///     Gets or sets the List of Volumes.
        /// </summary>
        [DataMember]
        public List<AsrVolume> Volumes { get; set; }
    }

    /// <summary>
    ///     Volume details in the Disk.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class AsrVolume
    {
        /// <summary>
        ///     Gets or sets the Volume Label.
        /// </summary>
        [DataMember]
        public string Label { get; set; }

        /// <summary>
        ///     Gets or sets the Volume Name.
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
        ///     Gets or sets the static IP address of the replica NIC.
        /// </summary>
        [DataMember]
        public string RecoveryNicStaticIPAddress { get; set; }

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
        ///     Gets or sets Name of the VM network.
        /// </summary>
        [DataMember]
        public string VMNetworkName { get; set; }

        /// <summary>
        ///     Gets or sets Name of the VM subnet.
        /// </summary>
        [DataMember]
        public string VMSubnetName { get; set; }
    }

    /// <summary>
    ///     CS Accounts Details.
    /// </summary>
    public class ASRRunAsAccount
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRRunAsAccount" /> class.
        /// </summary>
        /// <param name="runAsAccountDetails">Run as account object.</param>
        public ASRRunAsAccount(RunAsAccount runAsAccountDetails)
        {
            this.AccountId = runAsAccountDetails.AccountId;
            this.AccountName = runAsAccountDetails.AccountName;
        }

        /// <summary>
        ///     Gets or sets the CS RunAs account Id.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        ///     Gets or sets the CS RunAs account name.
        /// </summary>
        public string AccountName { get; set; }
    }

    /// <summary>
    /// Azure VM disk details required for AzureToAzure protection.
    /// </summary>
    public class ASRAzuretoAzureDiskReplicationConfig
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRAzuretoAzureDiskReplicationConfig" /> class.
        /// </summary>
        public ASRAzuretoAzureDiskReplicationConfig()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRRunAsAccount" /> class.
        /// </summary>
        /// <param name="runAsAccountDetails">Run as account object.</param>
        /// 
        /// <summary>
        /// Gets or sets the disk uri.
        /// </summary>
        public string VhdUri { get; set; }

        /// <summary>
        /// Gets or sets the primary staging storage account ARM Id.
        /// </summary>
        public string LogStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the recovery disk storage account ARM Id. 
        /// </summary>
        public string RecoveryAzureStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets isManagedDisk. 
        /// </summary>
        public bool IsManagedDisk { get; set; }

        /// <summary>
        /// Gets or sets DiskId. 
        /// </summary>
        public string DiskId;

        /// <summary>
        /// Gets or sets RecoveryReplicaDiskAccountType. 
        /// </summary>
        public string RecoveryReplicaDiskAccountType;

        /// <summary>
        /// Gets or sets RecoveryResourceGroupId. 
        /// </summary>
        public string RecoveryResourceGroupId;

        /// <summary>
        /// Gets or sets RecoveryTargetDiskAccountType. 
        /// </summary>
        public string RecoveryTargetDiskAccountType;
    }

    /// <summary>
    /// AzureToAzure replication provider specific protected disk details.
    /// </summary>
    public class ASRAzureToAzureProtectedDiskDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRAzureToAzureProtectedDiskDetails" />
        /// class.
        /// </summary>
        public ASRAzureToAzureProtectedDiskDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRAzureToAzureProtectedDiskDetails" />
        /// class.
        /// </summary>
        public ASRAzureToAzureProtectedDiskDetails(A2AProtectedDiskDetails disk)
        {
            this.DiskUri = disk.DiskUri;
            this.PrimaryDiskAzureStorageAccountId = disk.PrimaryDiskAzureStorageAccountId;
            this.PrimaryStagingAzureStorageAccountId = disk.PrimaryStagingAzureStorageAccountId;
            this.RecoveryAzureStorageAccountId = disk.RecoveryAzureStorageAccountId;
            this.RecoveryDiskUri = disk.RecoveryDiskUri;
            this.ResyncRequired = disk.ResyncRequired;
            this.MonitoringPercentageCompletion = disk.MonitoringPercentageCompletion;
            this.MonitoringJobType = disk.MonitoringJobType;
            this.DataPendingInStagingStorageAccountInMB = disk.DataPendingInStagingStorageAccountInMB;
            this.DataPendingAtSourceAgentInMB = disk.DataPendingAtSourceAgentInMB;
            this.DiskCapacityInBytes = disk.DiskCapacityInBytes;
            this.DiskName = disk.DiskName;
            this.DiskType = disk.DiskType;
            this.Managed = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRAzureToAzureProtectedDiskDetails" />
        /// class.
        /// </summary>
        public ASRAzureToAzureProtectedDiskDetails(A2AProtectedManagedDiskDetails disk)
        {
            this.PrimaryStagingAzureStorageAccountId = disk.PrimaryStagingAzureStorageAccountId;
            this.ResyncRequired = disk.ResyncRequired;
            this.MonitoringPercentageCompletion = disk.MonitoringPercentageCompletion;
            this.MonitoringJobType = disk.MonitoringJobType;
            this.DataPendingInStagingStorageAccountInMB = disk.DataPendingInStagingStorageAccountInMB;
            this.DataPendingAtSourceAgentInMB = disk.DataPendingAtSourceAgentInMB;
            this.DiskCapacityInBytes = disk.DiskCapacityInBytes;
            this.DiskName = disk.DiskName;
            this.DiskType = disk.DiskType;
            this.RecoveryReplicaDiskAccountType = disk.RecoveryReplicaDiskAccountType;
            this.RecoveryReplicaDiskId = disk.RecoveryReplicaDiskId;
            this.RecoveryResourceGroupId = disk.RecoveryResourceGroupId;
            this.RecoveryTargetDiskAccountType = disk.RecoveryTargetDiskAccountType;
            this.RecoveryTargetDiskId = disk.RecoveryTargetDiskId;
            this.Managed = true;
        }

        /// <summary>
        /// Gets or sets is azure vm managed disk.
        /// </summary>
        public bool Managed { get; set; }

        /// <summary>
        /// Gets or sets is recovery azure vm managed disk type.
        /// </summary>
        public string RecoveryReplicaDiskAccountType { get; set; }

        /// <summary>
        /// Gets or sets the recovery replica disk id.
        /// </summary>
        public string RecoveryReplicaDiskId { get; set; }

        /// <summary>
        /// Gets or sets the recovery resource group id.
        /// </summary>
        public string RecoveryResourceGroupId { get; set; }

        /// <summary>
        /// Gets or sets the recovery target disk AccountType.
        /// </summary>

        public string RecoveryTargetDiskAccountType { get; set; }

        /// <summary>
        /// Gets or sets the recovery target disk Id.
        /// </summary>
        public string RecoveryTargetDiskId { get; set; }

        /// <summary>
        /// Gets or sets the disk uri.
        /// </summary>
        public string DiskUri { get; set; }

        /// <summary>
        /// Gets or sets the primary disk storage account. 
        /// </summary>
        public string PrimaryDiskAzureStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the primary staging storage account.
        /// </summary>
        public string PrimaryStagingAzureStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the recovery disk storage account. 
        /// </summary>
        public string RecoveryAzureStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the disk capacity in bytes. 
        /// </summary>

        public long? DiskCapacityInBytes { get; set; }

        /// <summary>
        /// Gets or sets the disk name. 
        /// </summary>
        public string DiskName { get; set; }

        /// <summary>
        /// Gets or sets the diskType. 
        /// </summary>
        public string DiskType { get; set; }

        /// <summary>
        /// Gets or sets recovery disk uri.
        /// </summary>
        public string RecoveryDiskUri { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether resync is required for this disk.
        /// </summary>
        public bool? ResyncRequired { get; set; }

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
        /// Gets or sets the data pending for replication in MB at staging account.
        /// </summary>
        public double? DataPendingInStagingStorageAccountInMB { get; set; }

        /// <summary>
        /// Gets or sets the data pending at source virtual machine in MB.
        /// </summary>
        public double? DataPendingAtSourceAgentInMB { get; set; }
    }

    /// <summary>
    /// Azure to Azure VM synced configuration details.
    /// </summary>
    public class ASRAzureToAzureVmSyncedConfigDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRAzureToAzureVmSyncedConfigDetails" />
        /// class.
        /// </summary>
        public ASRAzureToAzureVmSyncedConfigDetails()
        {
            this.Tags = new Dictionary<string, string>();
            this.RoleAssignments = new List<ASRRoleAssignment>();
            this.InputEndpoints = new List<ASRInputEndpoint>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRAzureToAzureVmSyncedConfigDetails" />
        /// class.
        /// </summary>
        public ASRAzureToAzureVmSyncedConfigDetails(AzureToAzureVmSyncedConfigDetails details)
        {
            if (details.Tags == null)
            {
                this.Tags = new Dictionary<string, string>();
            }
            else
            {
                this.Tags = new Dictionary<string, string>(details.Tags);
            }

            if (details.RoleAssignments != null)
            {
                this.RoleAssignments =
                    details.RoleAssignments.ToList()
                    .ConvertAll(role => new ASRRoleAssignment(role));
            }

            if (details.InputEndpoints != null)
            {
                this.InputEndpoints =
                    details.InputEndpoints.ToList()
                    .ConvertAll(endpoint => new ASRInputEndpoint(endpoint));
            }
        }

        /// <summary>
        /// Gets or sets the Azure VM tags.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the Azure role assignments.
        /// </summary>
        public List<ASRRoleAssignment> RoleAssignments { get; set; }

        /// <summary>
        /// Gets or sets the Azure VM input endpoints.
        /// </summary>
        public List<ASRInputEndpoint> InputEndpoints { get; set; }
    }

    /// <summary>
    /// Azure VM input endpoint details.
    /// </summary>
    public class ASRInputEndpoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRInputEndpoint" /> class.
        /// </summary>
        public ASRInputEndpoint(InputEndpoint endpoint)
        {
            this.EndpointName = endpoint.EndpointName;
            this.PrivatePort = endpoint.PrivatePort;
            this.PublicPort = endpoint.PublicPort;
            this.Protocol = endpoint.Protocol;
        }

        /// <summary>
        /// Gets or sets the input endpoint name.
        /// </summary>
        public string EndpointName { get; set; }

        /// <summary>
        /// Gets or sets the input endpoint private port.
        /// </summary>
        public int? PrivatePort { get; set; }

        /// <summary>
        /// Gets or sets the input endpoint public port.
        /// </summary>
        public int? PublicPort { get; set; }

        /// <summary>
        /// Gets or sets the input endpoint protocol.
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// Returns a string representation of the object.
        /// </summary>
        /// <returns>Returns a string representing the object.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("EndpointName     : " + this.EndpointName);
            sb.AppendLine("PrivatePort      : " + this.PrivatePort);
            sb.AppendLine("PublicPort       : " + this.PublicPort);
            sb.AppendLine("Protocol         : " + this.Protocol);

            return sb.ToString();
        }
    }

    /// <summary>
    /// Azure role assignment details.
    /// </summary>
    public class ASRRoleAssignment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRRoleAssignment" /> class.
        /// </summary>
        public ASRRoleAssignment(RoleAssignment role)
        {
            this.Id = role.Id;
            this.Name = role.Name;
            this.Scope = role.Scope;
            this.PrincipalId = role.PrincipalId;
            this.RoleDefinitionId = role.RoleDefinitionId;
        }

        /// <summary>
        /// Gets or sets the ARM Id of the role assignment.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the role assignment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets role assignment scope.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets principal Id.
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// Gets or sets role definition id.
        /// </summary>
        public string RoleDefinitionId { get; set; }

        /// <summary>
        /// Returns a string representation of the object.
        /// </summary>
        /// <returns>Returns a string representing the object.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Id: " + this.Id);
            sb.AppendLine("Name: " + this.Name);
            sb.AppendLine("Scope: " + this.Scope);
            sb.AppendLine("PrincipalId: " + this.PrincipalId);
            sb.AppendLine("RoleDefinitionId: " + this.RoleDefinitionId);

            return sb.ToString();
        }
    }
}
