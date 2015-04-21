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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
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
    public class SetAzureVMOperatingSystemCommand : AzurePSCmdlet
    {
        protected const string WindowsParamSet = "Windows";
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
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "List of Certificates for Addition to the VM.")]
        [ValidateNotNullOrEmpty]
        public List<PSVaultSecretGroup> Secrets { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Provision VM Agent.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ProvisionVMAgent { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable Automatic Update")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter EnableAutoUpdate { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            Position = 8,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Time Zone")]
        [ValidateNotNullOrEmpty]
        public string TimeZone { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            Position = 9,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable WinRM Http protocol")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter WinRMHttp { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            Position = 10,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable WinRM Https protocol")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter WinRMHttps { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            Position = 11,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Url for WinRM certificate")]
        [ValidateNotNullOrEmpty]
        public Uri WinRMCertUrl { get; set; }

        [Parameter(
            ParameterSetName = WindowsParamSet,
            Position = 12,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Additional Unattend Content")]
        [ValidateNotNullOrEmpty]
        public List<PSAdditionalUnattendContent> AdditionalUnattendContents { get; set; }

        // Linux Parameter Sets
        [Parameter(
            ParameterSetName = LinuxParamSet,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "SSH Public Keys")]
        [ValidateNotNullOrEmpty]
        public List<PSSshPublicKey> SSHPublicKeys { get; set; }

        [Parameter(
            ParameterSetName = LinuxParamSet,
            Position = 7,
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
                Secrets = (this.Secrets == null) ? null : this.Secrets.ConvertAll<VaultSecretGroup>(e => e.ToVaultSecretGroup()),
            };

            if (this.ParameterSetName == LinuxParamSet)
            {
                this.VM.OSProfile.LinuxConfiguration =
                    (!this.DisablePasswordAuthentication.IsPresent && this.SSHPublicKeys == null)
                    ? null
                    : new LinuxConfiguration
                    {
                        DisablePasswordAuthentication = this.DisablePasswordAuthentication.IsPresent
                                                      ? (bool?) true
                                                      : null,

                        SshConfiguration = (this.SSHPublicKeys == null)
                                         ? null
                                         : new SshConfiguration
                                         {
                                             PublicKeys = this.SSHPublicKeys.ConvertAll<SshPublicKey>(e => e.ToSshPublicKey()),
                                         }
                    };
            }
            else
            {
                var listenerList  = new List<WinRMListener>();

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
                        CertificateUrl = this.WinRMCertUrl,
                    });
                }

                // OS Profile
                this.VM.OSProfile.WindowsConfiguration =
                    ! (this.ProvisionVMAgent.IsPresent || this.EnableAutoUpdate.IsPresent || this.WinRMHttp.IsPresent || this.WinRMHttps.IsPresent) &&
                      string.IsNullOrEmpty(this.TimeZone) && AdditionalUnattendContents == null
                    ? null
                    : new WindowsConfiguration
                    {
                        ProvisionVMAgent = this.ProvisionVMAgent.IsPresent ? (bool?) true : null,
                        EnableAutomaticUpdates = this.EnableAutoUpdate.IsPresent ? (bool?) true : null,
                        TimeZone = this.TimeZone,
                        AdditionalUnattendContents = (this.AdditionalUnattendContents == null)
                                                   ? null
                                                   : this.AdditionalUnattendContents.ConvertAll<AdditionalUnattendContent>(e => e.ToAdditionalUnattendContent()),
                        WinRMConfiguration = ! (this.WinRMHttp.IsPresent || this.WinRMHttps.IsPresent)
                                           ? null
                                           : new WinRMConfiguration
                                           {
                                               Listeners = listenerList,
                                           },
                    };
            }
            WriteObject(this.VM);
        }
    }
}
