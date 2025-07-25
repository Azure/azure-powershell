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

using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Automation.Models;
using System.Collections;
using System.Management.Automation;
using System.Security.Permissions;
using AutomationAccount = Microsoft.Azure.Commands.Automation.Model.AutomationAccount;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Creates azure automation accounts based on automation account name and location.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationAccount", DefaultParameterSetName = AutomationServicesEncryptionParameterSet)]
    [OutputType(typeof(AutomationAccount))]
    public class SetAzureAutomationAccount : ResourceManager.Common.AzureRMCmdlet
    {
        /// <summary>
        /// AutomationServices Encryption parameter set name
        /// </summary>
        private const string AutomationServicesEncryptionParameterSet = "AutomationServicesEncryption";

        /// <summary>
        /// KeyVault Encryption parameter set name
        /// </summary>
        private const string KeyVaultEncryptionParameterSet = "KeyVaultEncryption";

        /// <summary>
        /// The automation client.
        /// </summary>
        private IAutomationPSClient automationClient;

        /// <summary>
        /// Gets or sets the automation client base.
        /// </summary>
        public IAutomationPSClient AutomationClient
        {
            get
            {
                return this.automationClient = this.automationClient ?? new AutomationPSClient(DefaultProfile.DefaultContext);
            }

            set
            {
                this.automationClient = value;
            }
        }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The automation account name.")]
        [Alias("AutomationAccountName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the plan.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The plan of the automation account")]
        [ValidateSet(SkuNameEnum.Free, SkuNameEnum.Basic, IgnoreCase = true)]
        public string Plan { get; set; }

        /// <summary>
        /// Gets or sets the module tags.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The automation account tags.")]
        [Alias("Tag")]
        public IDictionary Tags { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Generate and assign a new System Identity for this automation account")]
        public SwitchParameter AssignSystemIdentity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Assign the User Assigned Identities to this automation account")]
        [ValidateNotNullOrEmpty]
        public string[] AssignUserIdentity { get; set; }

        [Parameter(HelpMessage = "Whether to set Automation Account KeySource to Microsoft.Automation or not.",
            Mandatory = false,
            ParameterSetName = AutomationServicesEncryptionParameterSet)]
        public SwitchParameter AutomationServicesEncryption { get; set; }

        [Parameter(HelpMessage = "Whether to set Automation Account KeySource to Microsoft.KeyVault(enable CMK) or not.",
            Mandatory = false,
            ParameterSetName = KeyVaultEncryptionParameterSet)]
        public SwitchParameter KeyVaultEncryption { get; set; }

        [Parameter(HelpMessage = "CMK KeyName",
                    Mandatory = true,
                    ParameterSetName = KeyVaultEncryptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(HelpMessage = "CMK KeyVersion",
            Mandatory = true,
            ParameterSetName = KeyVaultEncryptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyVersion { get; set; }

        [Parameter(HelpMessage = "CMK KeyVaultUri",
            Mandatory = true,
            ParameterSetName = KeyVaultEncryptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyVaultUri { get; set; }

        [Parameter(HelpMessage = "User Assigned Identity used for encryption",
            Mandatory = false,
            ParameterSetName = KeyVaultEncryptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string UserIdentityEncryption { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Whether to disable traffic on the non-ARM endpoints (Webhook/Agent) from the public internet")]
        public SwitchParameter DisablePublicNetworkAccess { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            bool addSystemId = AssignSystemIdentity.IsPresent;
            bool enableAMK = AutomationServicesEncryption.IsPresent;
            bool enableCMK =  (ParameterSetName == KeyVaultEncryptionParameterSet);
            bool disablePublicNetworkAccess = DisablePublicNetworkAccess.IsPresent;

            var account = this.AutomationClient.UpdateAutomationAccount(this.ResourceGroupName, this.Name, this.Plan, this.Tags, addSystemId, AssignUserIdentity, enableAMK, enableCMK, KeyName, KeyVersion, KeyVaultUri, UserIdentityEncryption, disablePublicNetworkAccess);
            this.WriteObject(account);
        }
    }
}
