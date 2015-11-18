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

namespace Microsoft.Azure.Commands.Intune
{
    using Management.Intune;
    using Management.Intune.Models;
    using Microsoft.Azure.Commands.Intune.Properties;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;

    /// <summary>
    /// A cmdlet that edits an existing Android Intune MAM policy.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmIntuneAndroidMAMPolicy", SupportsShouldProcess = true, DefaultParameterSetName = SetIntuneAndroidMAMPolicyCmdlet.TypeBasedParameterSet), OutputType(typeof(AndroidMAMPolicy))]
    public sealed class SetIntuneAndroidMAMPolicyCmdlet : IntuneBaseCmdlet
    {
        #region params
        /// <summary>
        /// The policy name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy name to patch.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy name.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy friendly name.")]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        /// The description of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy description.")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// The AppSharingFromLevel of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether the application is allowed to receive information shared by other applications. Information can be restricted to no applications, only managed applications, or be allowed from all applications.")]
        [Alias("AppSharingFromLevel"), ValidateNotNullOrEmpty, ValidateSet("none", "policyManagedApps", "allApps")]
        public AppSharingType? AllowDataTransferToApps { get; set; }

        /// <summary>
        /// The AppSharingToLevel of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether the application is allowed to share information with other applications. Information can be shared with no applications, only managed applications, or shared to all applications.")]
        [Alias("AppSharingToLevel"), ValidateNotNullOrEmpty, ValidateSet("none", "policyManagedApps", "allApps")]
        public AppSharingType? AllowDataTransferFromApps { get; set; }

        /// <summary>
        /// The Authentication of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether corporate credentials are required to access the application.")]
        [ValidateNotNullOrEmpty, ValidateSet("required", "notRequired")]
        public ChoiceType? Authentication { get; set; }

        /// <summary>
        /// The ClipboardSharingLevel of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether to restrict cut, copy and paste with other applications.")]
        [Alias("ClipboardSharingLevel"), ValidateNotNullOrEmpty, ValidateSet("blocked", "policyManagedApps", "policyManagedAppsWithPasteIn", "allApps")]
        public ClipboardSharingLevelType? ClipboardSharing { get; set; }

        /// <summary>
        /// The DataBackup of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether to prevent iTunes and iCloud backups.")]
        [ValidateNotNullOrEmpty, ValidateSet("allow", "block")]
        public FilterType? DataBackup { get; set; }

        /// <summary>
        /// The FileSharingSaveAs of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether to prevent ‘Save As’ from the application.")]
        [ValidateNotNullOrEmpty, ValidateSet("allow", "block")]
        public FilterType? FileSharingSaveAs { get; set; }

        /// <summary>
        /// The Pin of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether simple PIN is required to access the application.")]
        [ValidateNotNullOrEmpty, ValidateSet("required", "notRequired")]
        public ChoiceType? Pin { get; set; }

        /// <summary>
        /// The PinNumRetry  of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "When a simple PIN is required to access the application, this indicates the number of attempts before a PIN reset.")]
        [Alias("PinNumRetry"), ValidateNotNullOrEmpty, ValidateRange(0, 200)]
        public int? PinRetries { get; set; }

        /// <summary>
        /// The DeviceCompliance  of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether managed applications are blocked from running on rooted or jailbroken devices.")]
        [ValidateNotNullOrEmpty, ValidateSet("enable", "disable")]
        public OptionType? DeviceCompliance { get; set; }

        /// <summary>
        /// The ManagedBrowser of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether web content from the application is forced to run in the managed browser.")]
        [ValidateNotNullOrEmpty, ValidateSet("required", "notRequired")]
        public ChoiceType? ManagedBrowser { get; set; }

        /// <summary>
        /// The AccessRecheckOfflineTimeout of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates how long to wait in minutes before re-checking access requirements on the device if the device is offline.")]
        [Alias("AccessRecheckOfflineTimeout"), ValidateNotNullOrEmpty]
        public int? RecheckAccessOfflineGracePeriodMinutes { get; set; }

        /// <summary>
        /// The AccessRecheckOnlineTimeout of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates how long to wait in minutes before re-checking access requirements on the device.")]
        [Alias("AccessRecheckOnlineTimeout")]
        public int? RecheckAccessTimeoutMinutes { get; set; }

        /// <summary>
        /// The OfflineWipeTimeout of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates the number of days a device must be offline before application data is automatically wiped.")]
        [Alias("OfflineWipeTimeout")]
        public int? OfflineWipeIntervalDays { get; set; }

        /// <summary>
        /// The FileEncryption of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether to encrypt application data.")]
        [ValidateNotNullOrEmpty]
        public ChoiceType? FileEncryption { get; set; }

        /// <summary>
        /// The TouchId of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether fingerprints are allowed instead of PIN to access the application.")]
        [ValidateNotNullOrEmpty]
        public FilterType? ScreenCapture { get; set; }

        /// <summary>
        /// The tenant level parameter set.
        /// </summary>
        internal const string TypeBasedParameterSet = "Parameter Set to create a new Intune policy.";

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        #endregion params

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void ProcessRecord()
        {
            ValidateNumericParameters();
            this.ConfirmAction(
                this.Force,
                string.Format(CultureInfo.CurrentCulture, Resources.SetResource_ActionMessage, Resources.AndroidPolicy, this.Name),
                string.Format(CultureInfo.CurrentCulture, Resources.SetResource_ProcessMessage, Resources.AndroidPolicy, this.Name),
                this.Name,
                () =>
                {
                    var policyObj = this.IntuneClient.Android.PatchMAMPolicy(this.AsuHostName, this.Name, PrepareAndriodPolicyBody());
                    this.WriteObject(policyObj);
                });
        }

        /// <summary>
        /// Verify that numeric parameters are non negative
        /// </summary>
        private void ValidateNumericParameters()
        {
            Dictionary<string, int> paramsToValidate = new Dictionary<string, int>();
            if(PinRetries.HasValue)
            {
                paramsToValidate.Add(IntuneConstants.PinRetriesProperty, PinRetries.Value);                
            }
            if(this.RecheckAccessOfflineGracePeriodMinutes.HasValue)
            {
                paramsToValidate.Add(IntuneConstants.RecheckAccessOfflineGracePeriodMinutesProperty, this.RecheckAccessOfflineGracePeriodMinutes.Value);
            }
            if(this.RecheckAccessTimeoutMinutes.HasValue)
            {
                paramsToValidate.Add(IntuneConstants.RecheckAccessTimeoutMinutesProperty, this.RecheckAccessTimeoutMinutes.Value);
            }
            if(this.OfflineWipeIntervalDays.HasValue)
            {
                paramsToValidate.Add(IntuneConstants.OfflineWipeIntervalDaysProperty, this.OfflineWipeIntervalDays.Value);
            }

            NumericParameterValueChecker.CheckIfNegativeAndThrowException(paramsToValidate);
        }

        /// <summary>
        /// Prepares iOS Policy body for the new policy request
        /// </summary>
        /// <returns>policy request body</returns>
        private AndroidMAMPolicy PrepareAndriodPolicyBody()
        {
            TimeSpan? accessRecheckOfflineTimeout = null, accessRecheckOnlineTimeout = null, offlineWipeTimeout = null;
            if(RecheckAccessOfflineGracePeriodMinutes.HasValue)
            {
                accessRecheckOfflineTimeout = TimeSpan.FromMinutes(RecheckAccessOfflineGracePeriodMinutes.Value);
            }

            if(RecheckAccessTimeoutMinutes.HasValue)
            {
                accessRecheckOnlineTimeout = TimeSpan.FromMinutes(RecheckAccessTimeoutMinutes.Value);
            }

            if (OfflineWipeIntervalDays.HasValue)
            {
                offlineWipeTimeout = TimeSpan.FromDays(OfflineWipeIntervalDays.Value);
            }
            
            var policyBody = new AndroidMAMPolicy() {             
                FriendlyName = this.FriendlyName,
                Description = this.Description,
                AppSharingFromLevel = this.AllowDataTransferToApps.HasValue ? AllowDataTransferToApps.ToString() : null,
                AppSharingToLevel = this.AllowDataTransferFromApps.HasValue ? this.AllowDataTransferFromApps.ToString() : null,
                Authentication = this.Authentication.HasValue ? this.Authentication.ToString() : null,
                ClipboardSharingLevel = this.ClipboardSharing.HasValue ? this.ClipboardSharing.ToString() : null,
                DataBackup = this.DataBackup.HasValue ? this.DataBackup.ToString() : null,
                FileSharingSaveAs = this.FileSharingSaveAs.HasValue ? this.FileSharingSaveAs.ToString() : null,
                Pin = this.Pin.HasValue ? this.Pin.ToString() : null,
                PinNumRetry = this.PinRetries,
                DeviceCompliance = this.DeviceCompliance.HasValue ? this.DeviceCompliance.ToString() : null,
                ManagedBrowser = this.ManagedBrowser.HasValue ? this.ManagedBrowser.ToString() : null,
                AccessRecheckOfflineTimeout = accessRecheckOfflineTimeout,
                AccessRecheckOnlineTimeout = accessRecheckOnlineTimeout,
                OfflineWipeTimeout = offlineWipeTimeout,
                FileEncryption = this.FileEncryption.HasValue? this.FileEncryption.ToString():null,
                ScreenCapture = this.ScreenCapture.HasValue?this.ScreenCapture.ToString():null
            };

            return policyBody;
        }
    }
}
