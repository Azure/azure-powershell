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
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.Models;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Models;
using cmdletModel = Microsoft.Azure.Commands.RecoveryServices;
using Microsoft.Azure.Commands.RecoveryServices.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Used to Update MSI for RSVault
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesVault", DefaultParameterSetName = AzureRSVaultRemoveMSIdentity, SupportsShouldProcess = true), OutputType(typeof(ARSVault))]
    public class UpdateAzureRmRecoveryServicesVault : RecoveryServicesCmdletBase
    {
        #region parameters    

        internal const string AzureRSVaultAddMSIdentity = "AzureRSVaultAddMSIdentity";
        internal const string AzureRSVaultRemoveMSIdentity = "AzureRSVaultRemoveMSIdentity";

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the vault name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The MSI type assigned to Recovery Services Vault. Input 'None' if all MSIs have to be removed.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = false, ParameterSetName = AzureRSVaultAddMSIdentity)] // , HelpMessage = ParamHelpMsgs.Common.IdentityType
        [ValidateNotNullOrEmpty]
        [ValidateSet("SystemAssigned", "None", "UserAssigned")]
        public MSIdentity IdentityType { get; set; }

        /// <summary>
        /// The UserAssigned Identity assigned to Recovery Services Vault. 
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ParameterSetName = AzureRSVaultAddMSIdentity)]
        [Parameter(Mandatory = false, ValueFromPipeline = false, ParameterSetName = AzureRSVaultRemoveMSIdentity)]
        [ValidateNotNullOrEmpty]        
        public string[] IdentityId { get; set; } 

        /// <summary>
        /// The UserAssigned Identity assigned to Recovery Services Vault. 
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ParameterSetName = AzureRSVaultRemoveMSIdentity)]  
        [ValidateNotNullOrEmpty]
        public SwitchParameter RemoveUserAssigned { get; set; } 

        /// <summary>
        /// The UserAssigned Identity assigned to Recovery Services Vault. 
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ParameterSetName = AzureRSVaultRemoveMSIdentity)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter RemoveSystemAssigned { get; set; }

        /// <summary>
        /// Enables or disables Classic alerts for RS vault.
        /// </summary>
        [Parameter(Mandatory = false)]        
        public bool? DisableClassicAlerts { get; set; }

        /// <summary>
        /// Enables or disables monitor alerts for RS vault.
        /// </summary>
        [Parameter(Mandatory = false)]        
        public bool? DisableAzureMonitorAlertsForJobFailure { get; set; }

        /// <summary>
        /// Enables or disables classic email notifications for Site Recovery in RS vault.
        /// </summary>
        [Parameter(Mandatory = false)]
        public bool? DisableEmailNotificationsForSiteRecovery { get; set; }

        /// <summary>
        /// Enables or disables monitor alerts for replication issue in RS vault.
        /// </summary>
        [Parameter(Mandatory = false)]
        public bool? DisableAzureMonitorAlertsForAllReplicationIssue { get; set; }

        /// <summary>
        /// Enables or disables monitor alerts for failover issue in RS vault.
        /// </summary>
        [Parameter(Mandatory = false)]
        public bool? DisableAzureMonitorAlertsForAllFailoverIssue { get; set; }

        /// <summary>
        /// Enables or disables public network access for RS vault.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Parameter to Enable/Disable public network access of the vault. This setting is useful with Private Endpoints.")]
        public PublicNetworkAccess? PublicNetworkAccess { get; set; }

        /// <summary>
        /// Enables or disables Immutability for RS vault. Allowed values are Disabled, Unlocked, Locked.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Immutability State of the vault. Allowed values are \"Disabled\", \"Unlocked\", \"Locked\". \r\nUnlocked means Enabled and can be changed, Locked means Enabled and can't be changed.")]
        [ValidateSet("Disabled", "Unlocked", "Locked")]
        public ImmutabilityState? ImmutabilityState { get; set; }

        /// <summary>
        /// Parameter to authorize operations protected by cross tenant resource guard. Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").Token to fetch authorization token for different tenant.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Parameter to authorize operations protected by cross tenant resource guard. Use command (Get-AzAccessToken -TenantId \"xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\").Token to fetch authorization token for different tenant")]        
        public string Token;

        /// <summary>
        /// Enables or disables cross subscription restore state for RS vault. Allowed values are Enabled, Disabled, PermanentlyDisabled.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Cross subscription restore state of the vault. Allowed values are \"Enabled\", \"Disabled\", \"PermanentlyDisabled\".")]
        [ValidateSet("Enabled", "Disabled", "PermanentlyDisabled")]
        public CrossSubscriptionRestoreState? CrossSubscriptionRestoreState { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Resources.VaultTarget, "set"))
            {
                try
                {   
                    IdentityData MSI = new IdentityData();
                    Vault vault = RecoveryServicesClient.GetVault(this.ResourceGroupName, this.Name);

                    if (ParameterSetName == AzureRSVaultAddMSIdentity) 
                    {
                        if (IdentityType == MSIdentity.SystemAssigned)
                        {
                            if (IdentityId != null)
                            {
                                throw new ArgumentException(Resources.InvalidParameterIdentityId);
                            }
                            
                            if (vault.Identity != null && vault.Identity.Type.ToLower().Contains("userassigned"))
                            {
                                MSI.Type = MSIdentity.SystemAssigned.ToString() + "," + MSIdentity.UserAssigned.ToString();
                            }
                            else
                            {
                                MSI.Type = MSIdentity.SystemAssigned.ToString();
                            }                            
                        }
                        else if (IdentityType == MSIdentity.None)
                        {
                            MSI.Type = MSIdentity.None.ToString();
                        }
                        else if (IdentityType == MSIdentity.UserAssigned)
                        {
                            if (IdentityId == null)
                            {
                                throw new ArgumentException(Resources.IdentityIdRequired);
                            }

                            if (vault.Identity != null && vault.Identity.Type.ToLower().Contains("systemassigned"))
                            {
                                MSI.Type = MSIdentity.SystemAssigned.ToString() + "," + MSIdentity.UserAssigned.ToString();
                            }
                            else
                            {
                                MSI.Type = MSIdentity.UserAssigned.ToString();
                            }

                            MSI.UserAssignedIdentities = new Dictionary<string, UserIdentity>();
                            foreach (string userIdentityId in IdentityId)
                            {
                                MSI.UserAssignedIdentities.Add(userIdentityId, new UserIdentity());
                            }
                        }
                    }
                    else
                    {
                        if (RemoveSystemAssigned.IsPresent)
                        {   
                            if (IdentityId != null || RemoveUserAssigned.IsPresent)
                            {
                                throw new ArgumentException(Resources.InvalidIdentityRemove);
                            }

                            if (vault.Identity != null && vault.Identity.Type.ToLower().Contains("systemassigned"))
                            {
                                if (vault.Identity.Type.ToLower().Contains("userassigned"))
                                {
                                    MSI.Type = MSIdentity.UserAssigned.ToString();
                                }
                                else
                                {
                                    MSI.Type = MSIdentity.None.ToString();
                                }
                            }
                        }
                        else if (RemoveUserAssigned.IsPresent)
                        {
                            if (IdentityId == null)
                            {
                                throw new ArgumentException(Resources.IdentityIdRequired);
                            }

                            foreach (string identity in IdentityId)
                            {
                                if (!vault.Identity.UserAssignedIdentities.ContainsKey(identity))
                                {
                                    throw new ArgumentException(String.Format(Resources.InvalidIdentityId, identity));
                                }
                            }

                            if (vault.Identity != null && vault.Identity.Type.ToLower().Contains("userassigned"))
                            {
                                if (vault.Identity.Type.ToLower().Contains("systemassigned"))
                                {
                                    if(vault.Identity.UserAssignedIdentities.Keys.Count == IdentityId.Length)
                                    {
                                        MSI.Type = MSIdentity.SystemAssigned.ToString();
                                    }
                                    else
                                    {
                                        MSI.Type = MSIdentity.SystemAssigned.ToString() + "," + MSIdentity.UserAssigned.ToString();
                                    }                                    
                                }
                                else
                                {
                                    if (vault.Identity.UserAssignedIdentities.Keys.Count == IdentityId.Length) 
                                    {
                                        MSI.Type = MSIdentity.None.ToString();
                                    }
                                    else
                                    {
                                        MSI.Type = MSIdentity.UserAssigned.ToString();
                                    }                                        
                                }

                                if(MSI.Type != "SystemAssigned" && MSI.Type != "None")
                                {
                                    MSI.UserAssignedIdentities = new Dictionary<string, UserIdentity>();
                                    foreach (string userIdentityId in IdentityId)
                                    {
                                        MSI.UserAssignedIdentities.Add(userIdentityId, null);
                                    }
                                }                                
                            }
                        }
                        
                        else if (DisableAzureMonitorAlertsForJobFailure == null && DisableClassicAlerts == null && PublicNetworkAccess == null && ImmutabilityState == null && CrossSubscriptionRestoreState == null && DisableEmailNotificationsForSiteRecovery == null && DisableAzureMonitorAlertsForAllReplicationIssue == null && DisableAzureMonitorAlertsForAllFailoverIssue == null)
                        {
                            throw new ArgumentException(Resources.InvalidParameterSet);
                        }
                    }

                    bool isMUAProtected = false;
                    PatchVault patchVault = new PatchVault();

                    #region patch vault                    

                    if (MSI != null && MSI.Type != null && (MSI.Type.ToLower().Contains("none") || MSI.Type.ToLower().Contains("assigned")))
                    {
                        patchVault.Identity = MSI;
                    }

                    // alerts V1 changes 
                    if (DisableAzureMonitorAlertsForJobFailure != null || DisableClassicAlerts != null || DisableAzureMonitorAlertsForAllReplicationIssue != null || DisableAzureMonitorAlertsForAllFailoverIssue != null || DisableEmailNotificationsForSiteRecovery != null)
                    {                        
                        MonitoringSettings alerts = (vault.Properties!= null && vault.Properties.MonitoringSettings != null) ? vault.Properties.MonitoringSettings : new MonitoringSettings();

                        if(DisableAzureMonitorAlertsForJobFailure != null || DisableAzureMonitorAlertsForAllReplicationIssue != null || DisableAzureMonitorAlertsForAllFailoverIssue != null)
                        {
                            alerts.AzureMonitorAlertSettings = new AzureMonitorAlertSettings();
                            alerts.AzureMonitorAlertSettings.AlertsForAllJobFailures = (DisableAzureMonitorAlertsForJobFailure == true) ? "Disabled" : "Enabled";
                            alerts.AzureMonitorAlertSettings.AlertsForAllReplicationIssues = (DisableAzureMonitorAlertsForAllReplicationIssue == true) ? "Disabled" : "Enabled";
                            alerts.AzureMonitorAlertSettings.AlertsForAllFailoverIssues = (DisableAzureMonitorAlertsForAllFailoverIssue == true) ? "Disabled" : "Enabled";
                        }

                        if(DisableClassicAlerts != null || DisableEmailNotificationsForSiteRecovery != null)
                        {
                            alerts.ClassicAlertSettings = new ClassicAlertSettings();
                            alerts.ClassicAlertSettings.AlertsForCriticalOperations = (DisableClassicAlerts == true) ? "Disabled" : "Enabled";
                            alerts.ClassicAlertSettings.EmailNotificationsForSiteRecovery = (DisableEmailNotificationsForSiteRecovery == true) ? "Disabled" : "Enabled";
                        }

                        if (patchVault.Properties == null) { patchVault.Properties = new VaultProperties(); }
                        patchVault.Properties.MonitoringSettings = alerts;  
                    }

                    // update Public Network Access
                    if(PublicNetworkAccess != null)
                    {
                        if(patchVault.Properties == null) { patchVault.Properties = new VaultProperties();}

                        patchVault.Properties.PublicNetworkAccess = (PublicNetworkAccess == cmdletModel.PublicNetworkAccess.Disabled) ? "Disabled": "Enabled" ; 
                    }

                    if (ImmutabilityState != null)
                    {
                        if (patchVault.Properties == null) { patchVault.Properties = new VaultProperties(); }
                        if (patchVault.Properties.SecuritySettings == null) { patchVault.Properties.SecuritySettings = new SecuritySettings(); }
                        if (patchVault.Properties.SecuritySettings.ImmutabilitySettings == null) { patchVault.Properties.SecuritySettings.ImmutabilitySettings = new ServiceClientModel.ImmutabilitySettings(); }

                        if (vault.Properties != null && vault.Properties.SecuritySettings != null && vault.Properties.SecuritySettings.ImmutabilitySettings != null )
                        {                            
                            // check if MUA operation/MUA protected
                            if (vault.Properties.SecuritySettings.ImmutabilitySettings.State == "Unlocked" && ImmutabilityState == cmdletModel.ImmutabilityState.Disabled)
                            {
                                isMUAProtected = true;
                            }

                            // set immutability
                            if (vault.Properties.SecuritySettings.ImmutabilitySettings.State == "Locked")
                            {
                                if (ImmutabilityState != cmdletModel.ImmutabilityState.Locked)
                                {
                                    throw new ArgumentException(Resources.ImmutabilityNotUnlocked);
                                }
                                else
                                {
                                    patchVault.Properties.SecuritySettings.ImmutabilitySettings.State = "Locked";
                                }
                            }                            
                            else if (ImmutabilityState == cmdletModel.ImmutabilityState.Locked) 
                            {
                                if (vault.Properties.SecuritySettings.ImmutabilitySettings.State == "Disabled")
                                    throw new ArgumentException(Resources.ImmutabilityCantBeLocked);
                                else
                                    patchVault.Properties.SecuritySettings.ImmutabilitySettings.State = "Locked";
                            }
                            else patchVault.Properties.SecuritySettings.ImmutabilitySettings.State = ImmutabilityState.ToString();
                        }
                        else if (ImmutabilityState == cmdletModel.ImmutabilityState.Locked)
                        {
                            throw new ArgumentException(Resources.ImmutabilityCantBeLocked);
                        }
                        else patchVault.Properties.SecuritySettings.ImmutabilitySettings.State = ImmutabilityState.ToString();                                               
                    }

                    // update cross subscription restore state of the vault
                    if (CrossSubscriptionRestoreState != null)
                    {
                        RestoreSettings csrSetting = (vault.Properties != null && vault.Properties.RestoreSettings != null) ? vault.Properties.RestoreSettings : new RestoreSettings();
                        if (csrSetting.CrossSubscriptionRestoreSettings == null) { csrSetting.CrossSubscriptionRestoreSettings = new CrossSubscriptionRestoreSettings();  }
                        csrSetting.CrossSubscriptionRestoreSettings.CrossSubscriptionRestoreState = CrossSubscriptionRestoreState.ToString();

                        if (patchVault.Properties == null) { patchVault.Properties = new VaultProperties(); }
                        patchVault.Properties.RestoreSettings = csrSetting;
                    }

                    #endregion

                    vault = RecoveryServicesClient.UpdateRSVault(this.ResourceGroupName, this.Name, patchVault, Token, isMUAProtected);                                                         
                    WriteObject(new ARSVault(vault));
                }
                catch (Exception exception)
                {
                    WriteExceptionError(exception);
                }
            }
        }
    }
}
