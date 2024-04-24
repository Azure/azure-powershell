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
using Microsoft.Azure.Commands.RecoveryServices.Properties;
using Microsoft.Azure.Management.RecoveryServices.Models;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Models;
using cmdletModel = Microsoft.Azure.Commands.RecoveryServices;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Collections;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Used to initiate a vault create operation.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesVault", SupportsShouldProcess = true),OutputType(typeof(ARSVault))]
    public class NewAzureRmRecoveryServicesVault : RecoveryServicesCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets the vault name.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the location of the vault
        /// </summary>
        [Parameter(Mandatory = true)]
        [LocationCompleter("Microsoft.RecoveryServices/vaults")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the tags of the vault
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Enables or disables classic alerts for RS vault.
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
        /// Enables or disables Immutability for RS vault. Allowed values are Disabled, Unlocked.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Immutability State of the vault. Allowed values are \"Disabled\", \"Unlocked\", \"Locked\". \r\nUnlocked means Enabled and can be changed, Locked means Enabled and can't be changed.")]
        [ValidateSet("Disabled", "Unlocked")]
        public ImmutabilityState? ImmutabilityState { get; set; }

        #endregion

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Resources.VaultTarget, "new"))
            {
                try
                {
                    Vault vaultCreateArgs = new Vault();

                    if (Tag != null)
                    {
                        IDictionary<string, string> vaultTags = new Dictionary<string, string>();
                        foreach (string key in Tag.Keys)
                        {
                            vaultTags.Add(key, Tag[key].ToString());
                        }

                        vaultCreateArgs.Tags = vaultTags;
                    }
                    vaultCreateArgs.Location = this.Location;
                    vaultCreateArgs.Properties = new VaultProperties();
                    vaultCreateArgs.Sku = new Sku();
                    vaultCreateArgs.Sku.Name = SkuName.Standard;

                    if (DisableAzureMonitorAlertsForJobFailure != null || DisableClassicAlerts != null || DisableEmailNotificationsForSiteRecovery != null || DisableAzureMonitorAlertsForAllReplicationIssue != null || DisableAzureMonitorAlertsForAllFailoverIssue != null)
                    {   
                        if(DisableAzureMonitorAlertsForJobFailure != null && DisableClassicAlerts != null && DisableEmailNotificationsForSiteRecovery != null && DisableAzureMonitorAlertsForAllReplicationIssue != null && DisableAzureMonitorAlertsForAllFailoverIssue != null)
                        {
                            MonitoringSettings alerts = new MonitoringSettings();

                            alerts.AzureMonitorAlertSettings = new AzureMonitorAlertSettings();
                            alerts.AzureMonitorAlertSettings.AlertsForAllJobFailures = (DisableAzureMonitorAlertsForJobFailure == true) ? "Disabled" : "Enabled";
                            alerts.AzureMonitorAlertSettings.AlertsForAllReplicationIssues = (DisableAzureMonitorAlertsForAllReplicationIssue == true) ? "Disabled" : "Enabled";
                            alerts.AzureMonitorAlertSettings.AlertsForAllFailoverIssues = (DisableAzureMonitorAlertsForAllFailoverIssue == true) ? "Disabled" : "Enabled";

                            alerts.ClassicAlertSettings = new ClassicAlertSettings();
                            alerts.ClassicAlertSettings.AlertsForCriticalOperations = (DisableClassicAlerts == true) ? "Disabled" : "Enabled";
                            alerts.ClassicAlertSettings.EmailNotificationsForSiteRecovery = (DisableEmailNotificationsForSiteRecovery == true) ? "Disabled" : "Enabled";

                            vaultCreateArgs.Properties.MonitoringSettings = alerts;
                        }
                        else
                        {
                            throw new ArgumentException(Resources.MissingParameterForAlerts); 
                        }
                    }

                    if (PublicNetworkAccess != null)
                    {
                        vaultCreateArgs.Properties.PublicNetworkAccess = (PublicNetworkAccess == cmdletModel.PublicNetworkAccess.Disabled) ? "Disabled" : "Enabled";
                    }
                    else
                    {
                        vaultCreateArgs.Properties.PublicNetworkAccess = "Enabled";                        
                        Logger.Instance.WriteWarning(String.Format(Resources.PublicNetworkAccessEnabledByDefault));
                    }

                    if (ImmutabilityState != null)
                    {                        
                        if (vaultCreateArgs.Properties.SecuritySettings == null) { vaultCreateArgs.Properties.SecuritySettings = new SecuritySettings(); }
                        if (vaultCreateArgs.Properties.SecuritySettings.ImmutabilitySettings == null) { vaultCreateArgs.Properties.SecuritySettings.ImmutabilitySettings = new ServiceClientModel.ImmutabilitySettings(); }
                       
                        if (ImmutabilityState != 0)
                            vaultCreateArgs.Properties.SecuritySettings.ImmutabilitySettings.State = ImmutabilityState.ToString();
                    }

                    Vault response = RecoveryServicesClient.CreateVault(this.ResourceGroupName, this.Name, vaultCreateArgs);

                    this.WriteObject(new ARSVault(response));
                }
                catch (Exception exception)
                {
                    this.HandleException(exception);
                }
            }
        }
    }
}
