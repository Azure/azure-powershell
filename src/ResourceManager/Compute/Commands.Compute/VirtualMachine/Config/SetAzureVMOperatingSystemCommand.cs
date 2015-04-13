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
using System.Management.Automation;

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
            HelpMessage = "The Provision VM Agent.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ProvisionVMAgent { get; set; }

        [Parameter(
            DontShow = true, /* Not in the client library yet */
            ParameterSetName = LinuxParamSet,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "SSH Public Keys")]
        [ValidateNotNullOrEmpty]
        public string[] SSHPublicKey { get; set; }

        public override void ExecuteCmdlet()
        {
            // OS Profile
            this.VM.OSProfile = new OSProfile
            {
                ComputerName = this.ComputerName,
                AdminUsername = this.Credential.UserName,
                AdminPassword = SecureStringExtensions.ConvertToString(this.Credential.Password),
                WindowsConfiguration = !this.ProvisionVMAgent ? null : new WindowsConfiguration
                {
                    ProvisionVMAgent = this.ProvisionVMAgent.IsPresent ? (bool?)true : null
                }
            };

            WriteObject(this.VM);
        }
    }
}
