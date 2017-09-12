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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Sets Azure Site Revcovery Notification / Alert.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        "AzureRmRecoveryServicesAsrAlertSetting",
        DefaultParameterSetName = ASRParameterSets.Set)]
    [Alias(
        "Set-ASRNotificationSetting",
        "Set-AzureRmRecoveryServicesAsrNotificationSetting",
        "Set-ASRAlertSetting")]
    [OutputType(typeof(IEnumerable<ASRAlertSetting>))]
    public class SetAzureRmRecoveryServicesAsrAlertSetting : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets switch parameter. On passing, command waits till completion.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Set, Mandatory = false)]
        public SwitchParameter EmailSubscriptionOwner { get; set; }

        /// <summary>
        ///     Gets or sets the custom email list.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Set, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string[] CustomEmailAddress { get; set; }

        /// <summary>
        ///     Gets or sets locale.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Set, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string LocaleID { get; set; }

        /// <summary>
        ///     Gets or sets switch parameter. On passing, command waits till completion.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Disable, Mandatory = true)]
        public SwitchParameter DisableNotification { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            if (this.ShouldProcess(
                "Alerts",
                VerbsCommon.Set))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.Disable:
                        this.DisableAlerts();
                        break;
                    case ASRParameterSets.Set:
                        this.ConfigureAlertSettings();
                        break;
                }
            }
        }

        /// <summary>
        ///     Configure the Notification / Alert settings.
        /// </summary>
        private void ConfigureAlertSettings()
        {
            var alertProps =
                new ConfigureAlertRequestProperties();
            alertProps.CustomEmailAddresses = new List<string>();
            alertProps.Locale = Thread.CurrentThread.CurrentCulture.ToString();
            alertProps.SendToOwners = SendToOwners.DoNotSend;

            if (this.EmailSubscriptionOwner.IsPresent)
            {
                alertProps.SendToOwners = SendToOwners.Send;
            }

            if (!string.IsNullOrEmpty(this.LocaleID))
            {
                alertProps.Locale = this.LocaleID;
            }

            if (this.CustomEmailAddress != null && this.CustomEmailAddress.Length != 0)
            {
                Utilities.ValidateCustomEmails(this.CustomEmailAddress);
                alertProps.CustomEmailAddresses = this.CustomEmailAddress;
            }


            var alertRequest = new ConfigureAlertRequest();
            alertRequest.Properties = alertProps;
            var job =
                this.RecoveryServicesClient.SetAzureSiteRecoveryAlertSetting(alertRequest);

            var alert =
                this.RecoveryServicesClient.GetAzureSiteRecoveryAlertSetting();

            this.WriteAlert(alert);
        }

        /// <summary>
        ///     Disable the alerts.
        /// </summary>
        private void DisableAlerts()
        {
            var alertProps =
                new ConfigureAlertRequestProperties();
            alertProps.CustomEmailAddresses = new List<string>();
            alertProps.Locale = Thread.CurrentThread.CurrentCulture.ToString();
            alertProps.SendToOwners = SendToOwners.DoNotSend;

            var alertRequest = new ConfigureAlertRequest();
            alertRequest.Properties = alertProps;
            var response =
                this.RecoveryServicesClient.SetAzureSiteRecoveryAlertSetting(alertRequest);

            var alert =
                this.RecoveryServicesClient.GetAzureSiteRecoveryAlertSetting();

            this.WriteAlert(alert);
        }

        /// <summary>
        ///     Write alerts.
        /// </summary>
        /// <param name="alertSettings"></param>
        private void WriteAlert(List<Alert> alertSettings)
        {
            this.WriteObject(alertSettings.Select(p => new ASRAlertSetting(p)), true);
        }
    }
}