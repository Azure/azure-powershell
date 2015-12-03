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
    /// A cmdlet that edits an existing iOS Intune MAM policy.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmIntuneiOSMAMPolicy", SupportsShouldProcess = true, DefaultParameterSetName = SetIntuneiOSMAMPolicyCmdlet.TypeBasedParameterSet), OutputType(typeof(IOSMAMPolicy))]
    public sealed class SetIntuneiOSMAMPolicyCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the kind.
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
        [ValidateNotNullOrEmpty, ValidateSet("none", "policyManagedApps", "allApps")]
        public AppSharingType? AppSharingFromLevel { get; set; }

        /// <summary>
        /// The AppSharingToLevel of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether the application is allowed to share information with other applications. Information can be shared with no applications, only managed applications, or shared to all applications.")]
        [ValidateNotNullOrEmpty, ValidateSet("none", "policyManagedApps", "allApps")]
        public AppSharingType? AppSharingToLevel { get; set; }

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
        [ValidateNotNullOrEmpty, ValidateSet("blocked", "policyManagedApps", "policyManagedAppsWithPasteIn", "allApps")]
        public ClipboardSharingLevelType? ClipboardSharingLevel { get; set; }

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
        [ValidateNotNullOrEmpty, ValidateRange(0, 200)]
        public int? PinNumRetry { get; set; }

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
        [ValidateNotNullOrEmpty]
        public int? AccessRecheckOfflineTimeout { get; set; }

        /// <summary>
        /// The AccessRecheckOnlineTimeout of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates how long to wait in minutes before re-checking access requirements on the device.")]        
        public int? AccessRecheckOnlineTimeout { get; set; }

        /// <summary>
        /// The OfflineWipeTimeout of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates the number of days a device must be offline before application data is automatically wiped.")]        
        public int? OfflineWipeTimeout { get; set; }

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
        [ValidateNotNullOrEmpty]
        public OptionType? TouchId { get; set; }
        /// <summary>
        /// The tenant level parameter set.
        /// </summary>
        internal const string TypeBasedParameterSet = "Create a new Intune policy.";

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {    
            ValidateNumericParameters();
            this.ConfirmAction(
                this.Force,
                string.Format(CultureInfo.CurrentCulture, Resources.SetResource_ActionMessage, Resources.IosPolicy, this.Name),
                string.Format(CultureInfo.CurrentCulture, Resources.SetResource_ProcessMessage, Resources.IosPolicy, this.Name),
                this.Name,
                () =>
                {
                    var policyObj = this.IntuneClient.Ios.PatchMAMPolicy(this.AsuHostName, this.Name, PrepareiOSMAMPolicyBody());
                    this.WriteObject(policyObj);
                });
        }

        /// <summary>
        /// Verify that numeric parameters are non negative
        /// </summary>
        private void ValidateNumericParameters()
        {
            Dictionary<string, int> paramsToValidate = new Dictionary<string, int>();
            if (PinNumRetry.HasValue)
            {
                paramsToValidate.Add(IntuneConstants.PinNumRetryProperty, PinNumRetry.Value);
            }
            if (this.AccessRecheckOfflineTimeout.HasValue)
            {
                paramsToValidate.Add(IntuneConstants.AccessRecheckOfflineTimeoutProperty, this.AccessRecheckOfflineTimeout.Value);
            }
            if (this.AccessRecheckOnlineTimeout.HasValue)
            {
                paramsToValidate.Add(IntuneConstants.AccessRecheckOnlineTimeoutProperty, this.AccessRecheckOnlineTimeout.Value);
            }
            if (this.OfflineWipeTimeout.HasValue)
            {
                paramsToValidate.Add(IntuneConstants.OfflineWipeTimeoutProperty, this.OfflineWipeTimeout.Value);
            }

            NumericParameterValueChecker.CheckIfNegativeAndThrowException(paramsToValidate);
        }
        /// <summary>
        /// Prepares iOS Policy body for the new policy request
        /// </summary>
        /// <returns>policy request body</returns>
        private IOSMAMPolicy PrepareiOSMAMPolicyBody()
        {
            TimeSpan? accessRecheckOfflineTimeout = null, accessRecheckOnlineTimeout = null, offlineWipeTimeout = null;
            if (AccessRecheckOfflineTimeout.HasValue)
            {
                accessRecheckOfflineTimeout = TimeSpan.FromMinutes(AccessRecheckOfflineTimeout.Value);
            }

            if (AccessRecheckOnlineTimeout.HasValue)
            {
                accessRecheckOnlineTimeout = TimeSpan.FromMinutes(AccessRecheckOnlineTimeout.Value);
            }

            if (OfflineWipeTimeout.HasValue)
            {
                offlineWipeTimeout = TimeSpan.FromDays(OfflineWipeTimeout.Value);
            }

            var policyBody = new IOSMAMPolicy() { 
                FriendlyName = this.FriendlyName,
                Description = this.Description,
                AppSharingFromLevel = this.AppSharingFromLevel.HasValue? AppSharingFromLevel.ToString():null,
                AppSharingToLevel = this.AppSharingToLevel.HasValue?this.AppSharingToLevel.ToString():null,
                Authentication = this.Authentication.HasValue?this.Authentication.ToString():null,
                ClipboardSharingLevel = this.ClipboardSharingLevel.HasValue?this.ClipboardSharingLevel.ToString():null,
                DataBackup = this.DataBackup.HasValue?this.DataBackup.ToString():null,
                FileSharingSaveAs = this.FileSharingSaveAs.HasValue?this.FileSharingSaveAs.ToString():null,
                Pin = this.Pin.HasValue?this.Pin.ToString():null,
                PinNumRetry = this.PinNumRetry,
                DeviceCompliance = this.DeviceCompliance.HasValue?this.DeviceCompliance.ToString():null,
                ManagedBrowser = this.ManagedBrowser.HasValue?this.ManagedBrowser.ToString():null,
                AccessRecheckOfflineTimeout = accessRecheckOfflineTimeout,
                AccessRecheckOnlineTimeout = accessRecheckOnlineTimeout,
                OfflineWipeTimeout = offlineWipeTimeout,
                FileEncryptionLevel = this.FileEncryptionLevel.HasValue?this.FileEncryptionLevel.ToString():null,
                TouchId = this.TouchId.HasValue?this.TouchId.ToString():null
            };

            return policyBody;
        }
    }
}
