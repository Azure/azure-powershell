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
    using System.Globalization;
    using System.Management.Automation;
    using Management.Intune;
    using Management.Intune.Models;
    using Microsoft.Azure.Commands.Intune.Properties;
    using Microsoft.Rest.Serialization;

    /// <summary>
    /// A cmdlet that creates a new Android Intune MAM policy Azure resource.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmIntuneAndroidMAMPolicy"), OutputType(typeof(AndroidMAMPolicy))]
    public sealed class NewIntuneAndroidMAMPolicyCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the name of policy
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy friendly name.")]
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
        [ValidateNotNullOrEmpty, ValidateSet("none", "policyManagedApps", "allApps"), PSDefaultValue(Value = AppSharingType.none)]
        public AppSharingType AppSharingFromLevel { get; set; }

        /// <summary>
        /// The AppSharingToLevel of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether the application is allowed to share information with other applications. Information can be shared with no applications, only managed applications, or shared to all applications.")]
        [ValidateNotNullOrEmpty, ValidateSet("none", "policyManagedApps", "allApps"), PSDefaultValue(Value = AppSharingType.none)]
        public AppSharingType AppSharingToLevel { get; set; }

        /// <summary>
        /// The Authentication of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether corporate credentials are required to access the application.")]
        [ValidateNotNullOrEmpty, ValidateSet("required", "notRequired"), PSDefaultValue(Value = ChoiceType.required)]
        public ChoiceType Authentication { get; set; }

        /// <summary>
        /// The ClipboardSharingLevel of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether to restrict cut, copy and paste with other applications.")]
        [ValidateNotNullOrEmpty, ValidateSet("blocked", "policyManagedApps", "policyManagedAppsWithPasteIn", "allApps"), PSDefaultValue(Value = ClipboardSharingLevelType.blocked)]
        public ClipboardSharingLevelType ClipboardSharingLevel { get; set; }

        /// <summary>
        /// The DataBackup of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether to prevent iTunes and iCloud backups.")]
        [ValidateNotNullOrEmpty, ValidateSet("allow", "block"), PSDefaultValue(Value = FilterType.allow)]
        public FilterType DataBackup { get; set; }

        /// <summary>
        /// The FileSharingSaveAs of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether to prevent ‘Save As’ from the application.")]
        [ValidateNotNullOrEmpty, ValidateSet("allow", "block"), PSDefaultValue(Value = FilterType.allow)]
        public FilterType FileSharingSaveAs { get; set; }

        /// <summary>
        /// The Pin of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether simple PIN is required to access the application.")]
        [ValidateNotNullOrEmpty, ValidateSet("required", "notRequired"), PSDefaultValue(Value = ChoiceType.required)]
        public ChoiceType Pin { get; set; }

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
        [ValidateNotNullOrEmpty, ValidateSet("enable", "disable"), PSDefaultValue(Value = OptionType.enable)]
        public OptionType DeviceCompliance { get; set; }

        /// <summary>
        /// The ManagedBrowser of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether web content from the application is forced to run in the managed browser.")]
        [ValidateNotNullOrEmpty, ValidateSet("required", "notRequired"), PSDefaultValue(Value = ChoiceType.required)]
        public ChoiceType ManagedBrowser { get; set; }

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
        /// The FileEncryption of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether to encrypt application data.")]
        [ValidateNotNullOrEmpty, PSDefaultValue(Value = ChoiceType.required)]
        public ChoiceType FileEncryption { get; set; }

        /// <summary>
        /// The ScreenCapture of the policy
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates whether screen capture is allowed for the application.")]
        [ValidateNotNullOrEmpty, PSDefaultValue(Value = FilterType.allow, Help = "Defaults to 'allow'")]
        public FilterType ScreenCapture { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            InitializeDefaultValuesForParams();
            ValidateNumericParameters();

            var policyId = (IntuneBaseCmdlet.AndroidPolicyIdsQueue.Count == 0 ? Guid.NewGuid() : IntuneBaseCmdlet.AndroidPolicyIdsQueue.Dequeue()).ToString();
            var policyObjToCreate = this.PrepareAndroidPolicyBody();
            var policyObj = this.IntuneClient.Android.CreateOrUpdateMAMPolicy(this.AsuHostName, policyId, this.PrepareAndroidPolicyBody());
            this.WriteObject(policyObj);            
        }

        /// <summary>
        /// Verify that numeric parameters are non negative
        /// </summary>
        private void ValidateNumericParameters()
        {
            NumericParameterValueChecker.CheckIfNegativeAndThrowException(
                new System.Collections.Generic.Dictionary<string, int>
                {
                    {IntuneConstants.PinNumRetryProperty, PinNumRetry.Value},
                    {IntuneConstants.AccessRecheckOfflineTimeoutProperty, this.AccessRecheckOfflineTimeout.Value},
                    {IntuneConstants.AccessRecheckOnlineTimeoutProperty, this.AccessRecheckOnlineTimeout.Value},
                    {IntuneConstants.OfflineWipeTimeoutProperty, this.OfflineWipeTimeout.Value }
                });
        }

        /// <summary>
        /// Initialize the number & string parameters if the value is not provided as part of commandlet execution..
        /// Seems that Parameter PSDefaultValue() does not initialize integers & string params and so explicitly initializing them.
        /// </summary>
        private void InitializeDefaultValuesForParams()
        {
            this.PinNumRetry = this.PinNumRetry ?? IntuneConstants.DefaultPinNumRetry;
            this.AccessRecheckOfflineTimeout = this.AccessRecheckOfflineTimeout ?? IntuneConstants.DefaultAccessRecheckOfflineTimeout;
            this.AccessRecheckOnlineTimeout = this.AccessRecheckOnlineTimeout ?? IntuneConstants.DefaultAccessRecheckOnlineTimeout;
            this.OfflineWipeTimeout = this.OfflineWipeTimeout ?? IntuneConstants.DefaultOfflineWipeTimeout;
            this.Description = this.Description ?? string.Format(CultureInfo.CurrentCulture, Resources.NewResource, Resources.AndroidPolicy);
        }

        /// <summary>
        /// Prepares iOS Policy body for the new policy request
        /// </summary>
        /// <returns>policy request body</returns>
        private AndroidMAMPolicy PrepareAndroidPolicyBody()
        {
            var policyBody = new AndroidMAMPolicy()
            {
                FriendlyName = this.FriendlyName,
                Description = this.Description,
                AppSharingFromLevel = this.AppSharingFromLevel.ToString(),
                AppSharingToLevel = this.AppSharingToLevel.ToString(),
                Authentication = this.Authentication.ToString(),
                ClipboardSharingLevel = this.ClipboardSharingLevel.ToString(),
                DataBackup = this.DataBackup.ToString(),
                FileSharingSaveAs = this.FileSharingSaveAs.ToString(),
                Pin = this.Pin.ToString(),
                PinNumRetry = this.PinNumRetry,
                DeviceCompliance = this.DeviceCompliance.ToString(),
                ManagedBrowser = this.ManagedBrowser.ToString(),
                AccessRecheckOfflineTimeout = TimeSpan.FromMinutes(this.AccessRecheckOfflineTimeout.Value),
                AccessRecheckOnlineTimeout = TimeSpan.FromMinutes(this.AccessRecheckOnlineTimeout.Value),
                OfflineWipeTimeout = TimeSpan.FromDays(this.OfflineWipeTimeout.Value),
                FileEncryption = this.FileEncryption.ToString(),
                ScreenCapture = this.ScreenCapture.ToString()
            };

            return policyBody;
        }
    }
}