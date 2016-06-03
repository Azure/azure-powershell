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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Setup the virtual machine's OS profile.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.OperatingSystem,
        DefaultParameterSetName = WindowsParamSet),
    OutputType(
        typeof(PSVirtualMachine))]
    public class SetAzureVMOperatingSystemCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        protected const string WindowsParamSet = "Windows";
        protected const string WinRmHttpsParamSet = "WindowsWinRmHttps";
        protected const string LinuxParamSet = "Linux";

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
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Windows")]
        [Parameter(
            ParameterSetName = WinRmHttpsParamSet,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Windows")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Windows { get; set; }

        [Parameter(
            ParameterSetName = LinuxParamSet,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Linux")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Linux { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMComputerName)]
        [ValidateNotNullOrEmpty]
        public string ComputerName { get; set; }

        [Parameter(
            Mandatory = true,
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
            ParameterSetName = WindowsParamSet,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable Automatic Update")]
        [Parameter(
            ParameterSetName = WinRmHttpsParamSet,
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
        [ValidateNotNullOrEmpty]
        public SwitchParameter WinRMHttp { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = WinRmHttpsParamSet,
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
        [ValidateNotNullOrEmpty]
        public Uri WinRMCertificateUrl { get; set; }

        // Linux Parameter Sets
        [Parameter(
            ParameterSetName = LinuxParamSet,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable WinRM Https protocol")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter DisablePasswordAuthentication { get; set; }

        public override void ExecuteCmdlet()
        {
            this.VM.OSProfile = new OSProfile
            {
                ComputerName = this.ComputerName,
                AdminUsername = this.Credential.UserName,
                AdminPassword = SecureStringExtensions.ConvertToString(this.Credential.Password),
                CustomData = string.IsNullOrWhiteSpace(this.CustomData) ? null : Convert.ToBase64String(Encoding.UTF8.GetBytes(this.CustomData)),
            };

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

                this.VM.OSProfile.LinuxConfiguration.DisablePasswordAuthentication =
                    (this.DisablePasswordAuthentication.IsPresent)
                    ? (bool?)true
                    : null;
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

                // OS Profile
                this.VM.OSProfile.WindowsConfiguration.ProvisionVMAgent =
                    (this.ProvisionVMAgent.IsPresent)
                    ? (bool?)true
                    : null;

                this.VM.OSProfile.WindowsConfiguration.EnableAutomaticUpdates =
                    this.EnableAutoUpdate.IsPresent
                    ? (bool?)true
                    : null;

                this.VM.OSProfile.WindowsConfiguration.TimeZone = this.TimeZone;

                this.VM.OSProfile.WindowsConfiguration.WinRM =
                    !(this.WinRMHttp.IsPresent || this.WinRMHttps.IsPresent)
                    ? null
                    : new WinRMConfiguration
                    {
                        Listeners = listenerList,
                    };
            }

            WriteObject(this.VM);
        }
    }
}
