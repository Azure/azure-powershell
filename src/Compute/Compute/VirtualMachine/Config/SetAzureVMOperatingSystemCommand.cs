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
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Setup the virtual machine's OS profile.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMOperatingSystem",DefaultParameterSetName = WindowsParamSet),OutputType(typeof(PSVirtualMachine))]
    public class SetAzureVMOperatingSystemCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        protected const string WindowsParamSet = "Windows";
        protected const string WinRmHttpsParamSet = "WindowsWinRmHttps";
        protected const string WindowsDisableVMAgentParamSet = "WindowsDisableVMAgent";
        protected const string WindowsDisableVMAgentWinRmHttpsParamSet = "WindowsDisableVMAgentWinRmHttps";
        protected const string LinuxParamSet = "Linux";

        // BREAKING CHANGE
        // all the parameters are positional including switch parameters. there are over 10 positional parameters. Needs to be fixed.
        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Windows")]
        [Parameter(
            ParameterSetName = WinRmHttpsParamSet,
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Windows")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentParamSet,
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Windows")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentWinRmHttpsParamSet,
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Windows")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Windows { get; set; }

        [Parameter(
            ParameterSetName = LinuxParamSet,
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Linux")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Linux { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMComputerName)]
        [ValidateNotNullOrEmpty]
        public string ComputerName { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMCredential)]
        [ValidateNotNullOrEmpty]
        public PSCredential Credential { get; set; }

        [Parameter(
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Custom data")]
        [ValidateNotNullOrEmpty]
        public string CustomData { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Provision VM Agent.")]
        [Parameter(
            ParameterSetName = WinRmHttpsParamSet,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Provision VM Agent.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ProvisionVMAgent { get; set; }

        [Parameter(
            ParameterSetName = WindowsDisableVMAgentParamSet,
            HelpMessage = "Disable Provision VM Agent.")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentWinRmHttpsParamSet,
            HelpMessage = "Disable Provision VM Agent.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter DisableVMAgent { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable Automatic Update")]
        [Parameter(
            ParameterSetName = WinRmHttpsParamSet,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable Automatic Update")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentParamSet,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable Automatic Update")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentWinRmHttpsParamSet,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable Automatic Update")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter EnableAutoUpdate { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Time Zone")]
        [Parameter(
            ParameterSetName = WinRmHttpsParamSet,
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Time Zone")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentParamSet,
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Time Zone")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentWinRmHttpsParamSet,
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Time Zone")]
        [ValidateNotNullOrEmpty]
        public string TimeZone { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            Position = 8,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable WinRM Http protocol")]
        [Parameter(
            ParameterSetName = WinRmHttpsParamSet,
            Position = 8,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable WinRM Http protocol")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentParamSet,
            Position = 8,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable WinRM Http protocol")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentWinRmHttpsParamSet,
            Position = 8,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable WinRM Http protocol")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter WinRMHttp { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = WinRmHttpsParamSet,
            Position = 9,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable WinRM Https protocol")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = WindowsDisableVMAgentWinRmHttpsParamSet,
            Position = 9,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable WinRM Https protocol")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter WinRMHttps { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = WinRmHttpsParamSet,
            Position = 10,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Url for WinRM certificate")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = WindowsDisableVMAgentWinRmHttpsParamSet,
            Position = 10,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Url for WinRM certificate")]
        [ValidateNotNullOrEmpty]
        public Uri WinRMCertificateUrl { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Choose one of the following settings: 'Manual', 'AutomaticByOS', or 'AutomaticByPlatform'")]
        [Parameter(
            ParameterSetName = WinRmHttpsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Choose one of the following settings: 'Manual', 'AutomaticByOS', or 'AutomaticByPlatform'")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Choose one of the following settings: 'Manual', 'AutomaticByOS', or 'AutomaticByPlatform'")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentWinRmHttpsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Choose one of the following settings: 'Manual', 'AutomaticByOS', or 'AutomaticByPlatform'")]
        [Parameter(
            ParameterSetName = LinuxParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Choose one of the following settings: 'Manual', 'AutomaticByOS', or 'AutomaticByPlatform'")]
        [PSArgumentCompleter("Manual", "AutomaticByOS", "AutomaticByPlatform")]
        public string PatchMode { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enables customers to patch their Azure VMs without requiring a reboot. For enableHotpatching, the 'provisionVMAgent' must be set to true and 'patchMode' must be set to 'AutomaticByPlatform'.")]
        [Parameter(
            ParameterSetName = WinRmHttpsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enables customers to patch their Azure VMs without requiring a reboot. For enableHotpatching, the 'provisionVMAgent' must be set to true and 'patchMode' must be set to 'AutomaticByPlatform'.")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enables customers to patch their Azure VMs without requiring a reboot. For enableHotpatching, the 'provisionVMAgent' must be set to true and 'patchMode' must be set to 'AutomaticByPlatform'.")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentWinRmHttpsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enables customers to patch their Azure VMs without requiring a reboot. For enableHotpatching, the 'provisionVMAgent' must be set to true and 'patchMode' must be set to 'AutomaticByPlatform'.")]
        public SwitchParameter EnableHotpatching { get; set; }

        // Linux Parameter Sets
        [Parameter(
            ParameterSetName = LinuxParamSet,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable WinRM Https protocol")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter DisablePasswordAuthentication { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Automatic assessment mode value for the virtual machine. Possible values are ImageDefault and AutomaticByPlatform.")]
        [Parameter(
            ParameterSetName = WinRmHttpsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Automatic assessment mode value for the virtual machine. Possible values are ImageDefault and AutomaticByPlatform.")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Automatic assessment mode value for the virtual machine. Possible values are ImageDefault and AutomaticByPlatform.")]
        [Parameter(
            ParameterSetName = WindowsDisableVMAgentWinRmHttpsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Automatic assessment mode value for the virtual machine. Possible values are ImageDefault and AutomaticByPlatform.")]
        [Parameter(
            ParameterSetName = LinuxParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Automatic assessment mode value for the virtual machine. Possible values are ImageDefault and AutomaticByPlatform.")]
        [PSArgumentCompleter("ImageDefault", "AutomaticByPlatform")]
        public string AssessmentMode { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.VM.OSProfile == null)
            {

                this.VM.OSProfile = new OSProfile
                {
                    ComputerName = string.IsNullOrWhiteSpace(this.ComputerName) ? null : this.ComputerName,
                    AdminUsername = this.Credential?.UserName == null ? null : this.Credential.UserName,
                    AdminPassword = this.Credential?.Password == null ? null : ConversionUtilities.SecureStringToString(this.Credential?.Password),
                    CustomData = string.IsNullOrWhiteSpace(this.CustomData) ? null : Convert.ToBase64String(Encoding.UTF8.GetBytes(this.CustomData)),
                };
            }
            // These two checks below are present to allow users to change the OS type in the VM object.
            // This behavior may change in the future. 
            else if ((this.ParameterSetName == LinuxParamSet) & this.VM.OSProfile.WindowsConfiguration != null)
            {
                this.VM.OSProfile.WindowsConfiguration = null;
            }
            else if ((this.ParameterSetName == WindowsParamSet) & this.VM.OSProfile.LinuxConfiguration != null)
            {
                this.VM.OSProfile.LinuxConfiguration = null;
            }
            
            if (this.ParameterSetName == LinuxParamSet)
            {
                if (this.VM.OSProfile.WindowsConfiguration != null)
                {
                    throw new ArgumentException(Microsoft.Azure.Commands.Compute.Properties.Resources.BothWindowsAndLinuxConfigurationsSpecified);
                }

                if (this.VM.OSProfile.LinuxConfiguration == null)
                {
                    this.VM.OSProfile.LinuxConfiguration = new LinuxConfiguration();
                }

                //seting patchmode
                if (this.IsParameterBound(c => c.PatchMode))
                {
                    if (this.VM.OSProfile.LinuxConfiguration.PatchSettings == null)
                    {
                        this.VM.OSProfile.LinuxConfiguration.PatchSettings = new LinuxPatchSettings();
                    }
                    this.VM.OSProfile.LinuxConfiguration.PatchSettings.PatchMode = this.PatchMode;
                }

                this.VM.OSProfile.LinuxConfiguration.DisablePasswordAuthentication =
                    (this.DisablePasswordAuthentication.IsPresent)
                    ? (bool?)true
                    : null;

                if (this.IsParameterBound(c => c.AssessmentMode))
                {
                    if (this.VM.OSProfile.LinuxConfiguration == null)
                    {
                        this.VM.OSProfile.LinuxConfiguration = new LinuxConfiguration();
                    }
                    if (this.VM.OSProfile.LinuxConfiguration.PatchSettings == null)
                    {
                        this.VM.OSProfile.LinuxConfiguration.PatchSettings = new LinuxPatchSettings();
                    }
                    this.VM.OSProfile.LinuxConfiguration.PatchSettings.AssessmentMode = this.AssessmentMode;
                }
            }
            else
            {
                if (this.VM.OSProfile.LinuxConfiguration != null)
                {
                    throw new ArgumentException(Microsoft.Azure.Commands.Compute.Properties.Resources.BothWindowsAndLinuxConfigurationsSpecified);
                }

                if (this.VM.OSProfile.WindowsConfiguration == null)
                {
                    this.VM.OSProfile.WindowsConfiguration = new WindowsConfiguration();
                    this.VM.OSProfile.WindowsConfiguration.AdditionalUnattendContent = null;
                }

                if (this.IsParameterBound(c => c.AssessmentMode))
                {
                    if (this.VM.OSProfile.WindowsConfiguration == null)
                    {
                        this.VM.OSProfile.WindowsConfiguration = new WindowsConfiguration();
                    }
                    if (this.VM.OSProfile.WindowsConfiguration.PatchSettings == null)
                    {
                        this.VM.OSProfile.WindowsConfiguration.PatchSettings = new PatchSettings();
                    }
                    this.VM.OSProfile.WindowsConfiguration.PatchSettings.AssessmentMode = this.AssessmentMode;
                }

                var listenerList = new List<WinRMListener>();

                if (this.WinRMHttp.IsPresent)
                {
                    listenerList.Add(new WinRMListener
                    {
                        Protocol = ProtocolTypes.Http,
                        CertificateUrl = null,
                    });
                }

                if (this.WinRMHttps.IsPresent)
                {
                    listenerList.Add(new WinRMListener
                    {
                        Protocol = ProtocolTypes.Https,
                        CertificateUrl = this.WinRMCertificateUrl.ToString(),
                    });
                }

                if (this.ProvisionVMAgent.IsPresent)
                {
                    this.VM.OSProfile.WindowsConfiguration.ProvisionVMAgent = true;
                }

                if (this.DisableVMAgent.IsPresent)
                {
                    this.VM.OSProfile.WindowsConfiguration.ProvisionVMAgent = false;
                }

                if (this.IsParameterBound(c => c.EnableAutoUpdate))
                {
                    this.VM.OSProfile.WindowsConfiguration.EnableAutomaticUpdates = this.EnableAutoUpdate;
                }

                //adam tmp removal, if (this.IsParameterBound(c => c.TimeZone))
                //{
                    this.VM.OSProfile.WindowsConfiguration.TimeZone = this.TimeZone;
                //}

                this.VM.OSProfile.WindowsConfiguration.WinRM =
                    !(this.WinRMHttp.IsPresent || this.WinRMHttps.IsPresent)
                    ? null
                    : new WinRMConfiguration
                    {
                        Listeners = listenerList,
                    };

                //seting patchmode
                if (this.IsParameterBound(c => c.PatchMode))
                {
                    if (this.VM.OSProfile.WindowsConfiguration.PatchSettings == null)
                    {
                        this.VM.OSProfile.WindowsConfiguration.PatchSettings = new PatchSettings();
                    }
                    this.VM.OSProfile.WindowsConfiguration.PatchSettings.PatchMode = this.PatchMode;
                }

                if (this.IsParameterBound(c => c.EnableHotpatching))
                {
                    this.VM.OSProfile.WindowsConfiguration.PatchSettings.EnableHotpatching = this.EnableHotpatching;
                }


            }

            WriteObject(this.VM);
        }
    }
}
