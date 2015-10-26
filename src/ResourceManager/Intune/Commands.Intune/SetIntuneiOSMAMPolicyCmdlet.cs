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
    using System;
    using System.Management.Automation;
    using RestClient;
    using RestClient.Models;
    using System.Xml;
    using System.Collections.Generic;

    /// <summary>
    /// A cmdlet that edits an existing iOS intune policy.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmIntuneiOSMAMPolicy", SupportsShouldProcess = true, DefaultParameterSetName = SetIntuneiOSMAMPolicyCmdlet.TypeBasedParameterSet), OutputType(typeof(IOSMAMPolicy))]
    public sealed class SetIntuneiOSMAMPolicyCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The policy id to patch.")]
        [ValidateNotNullOrEmpty]
        public string PolicyId { get; set; }

        /// <summary>
        /// Gets or sets the policy name.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The policy friendly name.")]
        [Alias("FriendlyName"), ValidateNotNullOrEmpty]
        public string PolicyName { get; set; }

        /// <summary>
        /// The description of the policy
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The policy description.")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// The AppSharingFromLevel of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether the application is allowed to receive information shared by other applications.  Information can be restricted to no applications, only managed applications, or be allowed from all applications.")]
        [Alias("AppSharingFromLevel"), ValidateNotNullOrEmpty, ValidateSet("none", "policyManagedApps", "allApps")]
        public AppSharingType? AllowDataTransferToApps { get; set; }

        /// <summary>
        /// The AppSharingToLevel of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether the application is allowed to share information with other applications.  Information can be shared with no applications, only managed applications, or shared to all applications.")]
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
        /// The FileEncryptionLevel of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates the level of encryption for application data.")]
        [ValidateNotNullOrEmpty]
        public DeviceLockType? FileEncryptionLevel { get; set; }

        /// <summary>
        /// The TouchId of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether fingerprints are allowed instead of PIN to access the application.")]
        [Alias("TouchId"), ValidateNotNullOrEmpty]
        public OptionType? AllowFingerprint { get; set; }
        /// <summary>
        /// The tenant level parameter set.
        /// </summary>
        internal const string TypeBasedParameterSet = "Create a new Intune policy.";

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void ProcessRecord()
        {      
            Action action = () =>
            {
                ValidateNumericParameters();
                this.ConfirmAction(
                    this.Force,
                    "Are you sure you want to update the iOS policy with Id:" + this.PolicyId,
                    "Updating the iOS policy resource ",
                    this.PolicyId,
                    () =>
                    {
                        var policyObj = this.IntuneClient.PatchiOSMAMPolicy(this.AsuHostName, this.PolicyId, PrepareiOSMAMPolicyBody());
                        this.WriteObject(policyObj);
                    });
            };

            base.SafeExecutor(action);
        }

        /// <summary>
        /// Verify that numeric parameters are non negative
        /// </summary>
        private void ValidateNumericParameters()
        {
            Dictionary<string, int> paramsToValidate = new Dictionary<string, int>();
            if (PinRetries.HasValue)
            {
                paramsToValidate.Add("PinRetries", PinRetries.Value);
            }
            if (this.RecheckAccessOfflineGracePeriodMinutes.HasValue)
            {
                paramsToValidate.Add("RecheckAccessOfflineGracePeriodMinutes", this.RecheckAccessOfflineGracePeriodMinutes.Value);
            }
            if (this.RecheckAccessTimeoutMinutes.HasValue)
            {
                paramsToValidate.Add("RecheckAccessTimeoutMinutes", this.RecheckAccessTimeoutMinutes.Value);
            }
            if (this.OfflineWipeIntervalDays.HasValue)
            {
                paramsToValidate.Add("OfflineWipeIntervalDays", this.OfflineWipeIntervalDays.Value);
            }

            NumericParameterValueChecker.CheckIfNegativeAndThrowException(paramsToValidate);
        }
        /// <summary>
        /// Prepares iOS Policy body for the new policy request
        /// </summary>
        /// <returns>policy request body</returns>
        private IOSMAMPolicyRequestBody PrepareiOSMAMPolicyBody()
        {
            var policyBody = new IOSMAMPolicyRequestBody();
            policyBody.Properties = new IOSMAMPolicyProperties()
            {
                FriendlyName = this.PolicyName,
                Description = this.Description,
                AppSharingFromLevel = this.AllowDataTransferToApps.HasValue? AllowDataTransferToApps.ToString():null,
                AppSharingToLevel = this.AllowDataTransferFromApps.HasValue?this.AllowDataTransferFromApps.ToString():null,
                Authentication = this.Authentication.HasValue?this.Authentication.ToString():null,
                ClipboardSharingLevel = this.ClipboardSharing.HasValue?this.ClipboardSharing.ToString():null,
                DataBackup = this.DataBackup.HasValue?this.DataBackup.ToString():null,
                FileSharingSaveAs = this.FileSharingSaveAs.HasValue?this.FileSharingSaveAs.ToString():null,
                Pin = this.Pin.HasValue?this.Pin.ToString():null,
                PinNumRetry = this.PinRetries,
                DeviceCompliance = this.DeviceCompliance.HasValue?this.DeviceCompliance.ToString():null,
                ManagedBrowser = this.ManagedBrowser.HasValue?this.ManagedBrowser.ToString():null,
                AccessRecheckOfflineTimeout = this.RecheckAccessOfflineGracePeriodMinutes.HasValue?XmlConvert.ToString(TimeSpan.FromMinutes(this.RecheckAccessOfflineGracePeriodMinutes.Value)):null,
                AccessRecheckOnlineTimeout = this.RecheckAccessTimeoutMinutes.HasValue?XmlConvert.ToString(TimeSpan.FromMinutes(this.RecheckAccessTimeoutMinutes.Value)):null,
                OfflineWipeTimeout = this.OfflineWipeIntervalDays.HasValue?XmlConvert.ToString(TimeSpan.FromDays(this.OfflineWipeIntervalDays.Value)):null,

                FileEncryptionLevel = this.FileEncryptionLevel.HasValue?this.FileEncryptionLevel.ToString():null,
                TouchId = this.AllowFingerprint.HasValue?this.AllowFingerprint.ToString():null
            };

            return policyBody;
        }
    }
}
