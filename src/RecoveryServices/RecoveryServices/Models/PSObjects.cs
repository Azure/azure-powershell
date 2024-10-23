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

using Microsoft.Azure.Management.RecoveryServices.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Constant definition
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Vault type
        /// </summary>
        public const string VaultType = "HyperVRecoveryManagerVault";

        /// <summary>
        /// Backup vault type
        /// </summary>
        public const string BackupVaultType = "Vaults";

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
        /// RecoveryServicesProviderAuthType string coming from service.
        /// </summary>
        public const string RecoveryServicesProviderAuthType = "RecoveryServicesProviderAuthType";
    }

    /// <summary>
    /// Azure Recovery Services Vault.
    /// </summary>
    public class ARSVault
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ARSVault" /> class.
        /// </summary>
        public ARSVault()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ARSVault" /> class.
        /// </summary>
        /// <param name="vault">vault object</param>
        public ARSVault(Vault vault)
        {
            this.ID = vault.Id;
            this.Name = vault.Name;
            this.Type = vault.Type;
            this.Location = vault.Location;
            this.ResourceGroupName = PSRecoveryServicesClient.GetResourceGroup(vault.Id);
            this.SubscriptionId = PSRecoveryServicesClient.GetSubscriptionId(vault.Id);
            this.Properties = new ARSVaultProperties();
            this.Properties.ProvisioningState = vault.Properties.ProvisioningState;
            this.Properties.PrivateEndpointStateForBackup = vault.Properties.PrivateEndpointStateForBackup;
            this.Properties.PrivateEndpointStateForSiteRecovery = vault.Properties.PrivateEndpointStateForSiteRecovery;
            this.Properties.PublicNetworkAccess = vault.Properties.PublicNetworkAccess;
            this.Properties.RestoreSettings = vault.Properties.RestoreSettings;
            this.Properties.MoveDetails = vault.Properties.MoveDetails;
            this.Properties.MoveState = vault.Properties.MoveState;
            this.Properties.RedundancySettings = vault.Properties.RedundancySettings;
            this.Properties.SecureScore = vault.Properties.SecureScore;
            this.Properties.BcdrSecurityLevel = vault.Properties.BcdrSecurityLevel;

            if (vault.Properties.PrivateEndpointConnections != null)
            {
                this.Properties.PrivateEndpointConnections = new List<PrivateEndpointConnection>();
                
                foreach (var serviceClientPEC in vault.Properties.PrivateEndpointConnections)
                {
                    PrivateEndpointConnection pec = new PrivateEndpointConnection();

                    pec.ID = serviceClientPEC.Id;
                    pec.Name = serviceClientPEC.Name;
                    pec.Type = serviceClientPEC.Type;

                    if (serviceClientPEC.Properties != null)
                    {
                        pec.ProvisioningState = serviceClientPEC.Properties.ProvisioningState;

                        if(serviceClientPEC.Properties.GroupIds != null)
                        {
                            pec.GroupID = new List<string>();

                            foreach(var groupID in serviceClientPEC.Properties.GroupIds)
                            {
                                pec.GroupID.Add(groupID);
                            }                            
                        }

                        if (serviceClientPEC.Properties.PrivateLinkServiceConnectionState != null)
                        {
                            pec.Description = serviceClientPEC.Properties.PrivateLinkServiceConnectionState.Description;
                            pec.ConnectionState = serviceClientPEC.Properties.PrivateLinkServiceConnectionState.Status;
                            pec.ActionRequired = serviceClientPEC.Properties.PrivateLinkServiceConnectionState.ActionsRequired;
                        }

                        if (serviceClientPEC.Properties.PrivateEndpoint != null) pec.PrivateEndpointID = serviceClientPEC.Properties.PrivateEndpoint.Id;                        
                    }                    
                        
                    this.Properties.PrivateEndpointConnections.Add(pec);
                }                
            }
            
            if(vault.Properties.MonitoringSettings != null)
            {
                this.Properties.AlertSettings = new AlertSettings();

                if (vault.Properties.MonitoringSettings.AzureMonitorAlertSettings != null)
                {
                    this.Properties.AlertSettings.AzureMonitorAlertsForAllJobFailure = vault.Properties.MonitoringSettings.AzureMonitorAlertSettings.AlertsForAllJobFailures;
                    this.Properties.AlertSettings.AzureMonitorAlertsForAllReplicationIssues = vault.Properties.MonitoringSettings.AzureMonitorAlertSettings.AlertsForAllReplicationIssues;
                    this.Properties.AlertSettings.AzureMonitorAlertsForAllFailoverIssues = vault.Properties.MonitoringSettings.AzureMonitorAlertSettings.AlertsForAllFailoverIssues;
                }

                if (vault.Properties.MonitoringSettings.ClassicAlertSettings != null)
                {
                    this.Properties.AlertSettings.ClassicAlertsForCriticalOperations = vault.Properties.MonitoringSettings.ClassicAlertSettings.AlertsForCriticalOperations;
                    this.Properties.AlertSettings.EmailNotificationsForSiteRecovery = vault.Properties.MonitoringSettings.ClassicAlertSettings.EmailNotificationsForSiteRecovery;
                }
            }

            if(vault.Properties.SecuritySettings != null && vault.Properties.SecuritySettings.ImmutabilitySettings != null)
            {
                this.Properties.ImmutabilitySettings = new ImmutabilitySettings();

                if(vault.Properties.SecuritySettings.ImmutabilitySettings.State != null)
                {
                    ImmutabilityState immutabilityState;
                    Enum.TryParse<ImmutabilityState>(vault.Properties.SecuritySettings.ImmutabilitySettings.State, true, out immutabilityState);
                    this.Properties.ImmutabilitySettings.ImmutabilityState = immutabilityState;
                }
            }

            this.Identity = vault.Identity;

            if (vault.Properties.Encryption != null)
            {
                var encryption = vault.Properties.Encryption;
                this.Properties.EncryptionProperty = new VaultPropertiesEncryption
                {
                    KeyVaultProperties = new CmkKeyVaultProperties
                    {
                        KeyUri = encryption.KeyVaultProperties?.KeyUri
                    },
                    KekIdentity = new CmkKekIdentity
                    {
                        UseSystemAssignedIdentity = encryption.KekIdentity?.UseSystemAssignedIdentity,
                        UserAssignedIdentity = encryption.KekIdentity?.UserAssignedIdentity
                    },
                    InfrastructureEncryption = encryption.InfrastructureEncryption
                };
            }

            if (vault.Properties.SecuritySettings != null)
            {
                this.Properties.SoftDeleteSettings = vault.Properties.SecuritySettings.SoftDeleteSettings;
                this.Properties.MultiUserAuthorization = vault.Properties.SecuritySettings.MultiUserAuthorization;
            }
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
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Subscription.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets Properties.
        /// </summary>
        public ARSVaultProperties Properties { get; set; }

        /// <summary>
        /// Gets or sets Identity.
        /// </summary>
        public IdentityData Identity { get; set; }

        #endregion
    }

    /// <summary>
    /// Azure Site Recovery Vault properties.
    /// </summary>
    public class ARSVaultProperties
    {
        #region Properties

        /// <summary>
        /// Gets or sets Provisioning State.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets PrivateEndpointStateForBackup.
        /// </summary>
        public string PrivateEndpointStateForBackup { get; set; }

        /// <summary>
        /// Gets or sets PrivateEndpointStateForSiteRecovery.
        /// </summary>
        public string PrivateEndpointStateForSiteRecovery { get; set; }

        /// <summary>
        /// Gets or sets RestoreSettings.
        /// </summary>
        public RestoreSettings RestoreSettings { get; set; }

        /// <summary>
        /// Gets or sets PublicNetworkAccess.
        /// </summary>
        public string PublicNetworkAccess { get; set; }

        public ImmutabilitySettings ImmutabilitySettings { get; set; }

        /// <summary>
        /// Gets or sets MonitoringSettings.
        /// </summary>
        public AlertSettings AlertSettings { get; set; }

        public List<PrivateEndpointConnection> PrivateEndpointConnections { get; set; }

        public VaultPropertiesEncryption EncryptionProperty { get; set; }

        public VaultPropertiesMoveDetails MoveDetails { get; set; }
        public string MoveState { get; set; }

        public VaultPropertiesRedundancySettings RedundancySettings { get; set; }
        public SoftDeleteSettings SoftDeleteSettings {get; set; }
        public string MultiUserAuthorization { get; set; }

        public string SecureScore { get; set; }
        public string BcdrSecurityLevel { get; set; }

        #endregion
    }

    public class ImmutabilitySettings
    {
        #region Properties            
            public ImmutabilityState ImmutabilityState { get; set; }
        #endregion

        public override string ToString()
        {            
            return string.Format("ImmutabilityState: {0}", ImmutabilityState.ToString());            
        }
    }

    public class PrivateEndpointConnection
    {
        #region Properties

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the ProvisioningState.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets the ConnectionState.
        /// </summary>
        public string ConnectionState { get; set; }

        /// <summary>
        /// Gets or sets the ActionsRequired.
        /// </summary>
        public string ActionRequired { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the GroupID.
        /// </summary>
        public List<string> GroupID { get; set; }

        /// <summary>
        /// Gets or sets the PrivateEndpointID.
        /// </summary>
        public string PrivateEndpointID { get; set; }

        #endregion

        public override string ToString()
        {
            return string.Format("Name: {0}, ConnectionState: {1}", Name.Split('.')[0], ConnectionState);
        }
    }

    public class AlertSettings
    {
        #region Properties

        /// <summary>
        /// Gets or sets the monitor alerts for all job failures.
        /// </summary>
        public string AzureMonitorAlertsForAllJobFailure { get; set; }

        /// <summary>
        /// Gets or sets the monitor alerts for replication issues.
        /// </summary>
        public string AzureMonitorAlertsForAllReplicationIssues { get; set; }

        /// <summary>
        /// Gets or sets the monitor alerts for failover issues.
        /// </summary>
        public string AzureMonitorAlertsForAllFailoverIssues { get; set; }

        /// <summary>
        /// Gets or sets the email notifications for site recovery.
        /// </summary>
        public string EmailNotificationsForSiteRecovery { get; set; }

        /// <summary>
        /// Gets or sets AlertsForCriticalOperations.
        /// </summary>
        public string ClassicAlertsForCriticalOperations { get; set; }

        #endregion

        public override string ToString()
        {
            string alerts = string.Empty;

            if (AzureMonitorAlertsForAllJobFailure != null)
            {
                alerts += string.Format("AzureMonitorAlertsForAllJobFailure: {0}", AzureMonitorAlertsForAllJobFailure.ToString());
            }

            if (ClassicAlertsForCriticalOperations != null)
            {
                alerts += string.Format("ClassicAlertsForCriticalOperations: {0}", ClassicAlertsForCriticalOperations.ToString());
            }

            if (AzureMonitorAlertsForAllReplicationIssues != null)
            {
                alerts += string.Format("AzureMonitorAlertsForAllReplicationIssues: {0}", AzureMonitorAlertsForAllReplicationIssues.ToString());
            }

            if (AzureMonitorAlertsForAllFailoverIssues != null)
            {
                alerts += string.Format("AzureMonitorAlertsForAllFailoverIssues: {0}", AzureMonitorAlertsForAllFailoverIssues.ToString());
            }

            if (EmailNotificationsForSiteRecovery != null)
            {
                alerts += string.Format("EmailNotificationsForSiteRecovery: {0}", EmailNotificationsForSiteRecovery.ToString());
            }

            return alerts;
        }
    }

    public class ASRVaultBackupProperties
    {
        #region Properties

        /// <summary>
        /// Gets or sets BackupStorageRedundancy type.
        /// </summary>
        public string BackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets CrossRegionRestore Flag.
        /// </summary>
        public bool CrossRegionRestore { get; set; }

        #endregion
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
    /// Class to define the vault BackupStorageRedundancy settings.
    /// </summary>
    public enum AzureRmRecoveryServicesBackupStorageRedundancyType
    {
        GeoRedundant = 1,
        ZoneRedundant,
        LocallyRedundant
    }

    /// <summary>
    /// Enum to define the vault Immutability state.
    /// </summary>
    public enum ImmutabilityState
    {
        Disabled = 1,
        Unlocked,
        Locked
    }

    /// <summary>
    /// Enum to define the cross subscription restore state of the vault.
    /// </summary>
    public enum CrossSubscriptionRestoreState
    {
        Enabled = 1,
        Disabled,
        PermanentlyDisabled
    }

    public enum PublicNetworkAccess
    {
        Enabled = 1,
        Disabled
    }

    /// <summary>
    /// Class to define the vault BackupStorageRedundancy settings.
    /// </summary>
    public enum MSIdentity
    {
        SystemAssigned = 1,
        None,
        UserAssigned
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
}
