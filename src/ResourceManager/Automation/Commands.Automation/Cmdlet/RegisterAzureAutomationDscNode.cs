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
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Registers the dsc node.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "AzureRmAutomationDscNode")]
    // [OutputType(typeof(DscNode))]
    public class RegisterAzureAutomationDscNode : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// True to reboot the node if needed. False otherwise.
        /// </summary>
        private bool rebootIfNeeded = false;

        /// <summary>
        /// True to overwrite modules. False otherwise.
        /// </summary>
        private bool overwriteModulesFlag = false;

        /// <summary>
        /// Default value for ConfigurationModeFrequencyMins
        /// </summary>
        private int configurationModeFrequencyMins = 15;

        /// <summary>
        /// Default value for RefreshFrequencyMins
        /// </summary>
        private int refreshFrequencyMins = 30;

        /// <summary>
        /// Default value for ActionAfterReboot
        /// </summary>
        private string actionAfterReboot = "ContinueConfiguration";

        /// <summary>
        /// Default value for NodeConfigurationName
        /// </summary>
        private string nodeConfigurationName = String.Empty;

        /// <summary>
        /// Default value for ConfigurationMode
        /// </summary>
        private string configurationMode = "ApplyAndMonitor";

        /// <summary>
        /// Default value for AzureVMResourceGroup
        /// </summary>
        private string azureVmResourceGroup = String.Empty;

        /// <summary>
        /// Default value for AzureVmLocation
        /// </summary>
        private string azureVmLocation = String.Empty;

        /// <summary> 
        /// Gets or sets the VM name.
        /// </summary> 
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the Azure virtual machine to register for management with Azure Automation DSC.")]
        [ValidateNotNullOrEmpty]
        public string AzureVMName { get; set; }

        /// <summary> 
        /// Gets or sets the node configuration name.
        /// </summary> 
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the node configuration that the VM should be configured to pull from Azure Automation DSC.")]
        public string NodeConfigurationName
        {
            get { return this.nodeConfigurationName; }
            set { this.nodeConfigurationName = value; }
        }

        /// <summary> 
        /// Gets or sets the configuration mode
        /// </summary> 
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "DSC configuration mode.")]
        [ValidateSet("ApplyAndMonitor", "ApplyAndAutocorrect", "ApplyOnly", IgnoreCase = true)]
        public string ConfigurationMode
        {
            get { return this.configurationMode; }
            set { this.configurationMode = value; }
        }

        /// <summary> 
        /// Gets or sets the configuration mode frequency in minutes.
        /// </summary> 
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Represents the frequency (in minutes) at which the background application of DSC attempts to implement the current configuration on the target node.")]
        [ValidateRange(15, 44640)]
        public int ConfigurationModeFrequencyMins
        {
            get { return this.configurationModeFrequencyMins; }
            set { this.configurationModeFrequencyMins = value; }
        }

        /// <summary> 
        /// Gets or sets the refresh frequency in minutes.
        /// </summary> 
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Represents the frequency (in minutes) at which the Local Configuration Manager contacts the Azure Automation DSC pull server to download the latest node configuration.")]
        [ValidateRange(30, 44640)]
        public int RefreshFrequencyMins
        {
            get { return this.refreshFrequencyMins; }
            set { this.refreshFrequencyMins = value; }
        }

        /// <summary> 
        /// Gets or sets a value indicating whether to reboot the node if needed.
        /// </summary> 
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "True to Reboot the node if needed.")]
        public bool RebootNodeIfNeeded
        {
            get { return this.rebootIfNeeded; }
            set { this.rebootIfNeeded = value; }
        }

        /// <summary> 
        /// Gets or sets the action to perform post reboot.
        /// </summary> 
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Action to perform after a reboot.")]
        [ValidateSet("ContinueConfiguration", "StopConfiguration", IgnoreCase = true)]
        public string ActionAfterReboot
        {
            get { return this.actionAfterReboot; }
            set { this.actionAfterReboot = value; }
        }

        /// <summary> 
        /// Gets or sets a value indicating whether to overwrite the module.
        /// </summary> 
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Controls whether new configurations downloaded from the Azure Automation DSC pull server are allowed to overwrite the old modules already on the target node.")]
        public bool AllowModuleOverwrite
        {
            get { return this.overwriteModulesFlag; }
            set { this.overwriteModulesFlag = value; }
        }

        /// <summary>
        /// Gets or sets the azure VM resource group name.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The Azure VM resource group name.")]
        public string AzureVMResourceGroup
        {
            get { return this.azureVmResourceGroup; }
            set { this.azureVmResourceGroup = value; }
        }

        /// <summary>
        /// Gets or sets the azure VM location.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The Azure VM location.")]
        public string AzureVMLocation
        {
            get { return this.azureVmLocation; }
            set { this.azureVmLocation = value; }
        }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            this.AutomationClient.RegisterDscNode(this.ResourceGroupName, this.AutomationAccountName, this.AzureVMName, this.NodeConfigurationName, this.ConfigurationMode, this.ConfigurationModeFrequencyMins, this.RefreshFrequencyMins, this.RebootNodeIfNeeded, this.ActionAfterReboot, this.AllowModuleOverwrite, this.AzureVMResourceGroup, this.AzureVMLocation);
        }
    }
}
