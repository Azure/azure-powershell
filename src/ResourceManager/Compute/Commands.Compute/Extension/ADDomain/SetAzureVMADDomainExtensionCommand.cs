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

using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineADDomainExtension,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureVMADDomainExtensionCommand : SetAzureVMExtensionBaseCmdlet
    {
        private const string nameKey = "Name";
        private const string ouPathKey = "OUPath";
        private const string optionKey = "Options";
        private const string restartKey = "Restart";
        private const string userKey = "User";
        private const string passwordKey = "Password";

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Name of the Domain.")]
        [ValidateNotNullOrEmpty]
        public string DomainName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The OU Path")]
        [ValidateNotNullOrEmpty]
        public string OUPath { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Join Options")]
        [ValidateNotNull]
        public uint? JoinOption { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Credential")]
        [ValidateNotNullOrEmpty]
        public PSCredential Credential { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Restart")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Restart { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(VirtualMachineADDomainExtensionContext.ExtensionDefaultName, VerbsCommon.Set))
            {
                ExecuteClientAction(() =>
                {
                    Hashtable publicSettings = new Hashtable();
                    publicSettings.Add(nameKey, this.DomainName);

                    if (this.OUPath != null)
                    {
                        publicSettings.Add(ouPathKey, this.OUPath);
                    }

                    if (this.JoinOption != null)
                    {
                        publicSettings.Add(optionKey, this.JoinOption);
                    }

                    publicSettings.Add(restartKey, Restart.IsPresent);

                    Hashtable privateSettings = new Hashtable();
                    if (Credential != null)
                    {
                        publicSettings.Add(userKey, Credential.UserName);
                        privateSettings.Add(passwordKey, SecureStringExtensions.ConvertToString(this.Credential.Password));
                    }

                    if (string.IsNullOrEmpty(this.Location))
                    {
                        this.Location = GetLocationFromVm(this.ResourceGroupName, this.VMName);
                    }

                    var parameters = new VirtualMachineExtension
                    {
                        Location = this.Location,
                        Publisher = VirtualMachineADDomainExtensionContext.ExtensionDefaultPublisher,
                        VirtualMachineExtensionType = VirtualMachineADDomainExtensionContext.ExtensionDefaultName,
                        TypeHandlerVersion = this.TypeHandlerVersion ?? VirtualMachineADDomainExtensionContext.ExtensionDefaultVersion,
                        AutoUpgradeMinorVersion = !this.DisableAutoUpgradeMinorVersion.IsPresent,
                        ForceUpdateTag = this.ForceRerun,
                        Settings = publicSettings,
                        ProtectedSettings = privateSettings
                    };

                    var op = this.VirtualMachineExtensionClient.CreateOrUpdateWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.VMName,
                        this.Name ?? VirtualMachineADDomainExtensionContext.ExtensionDefaultName,
                        parameters).GetAwaiter().GetResult();

                    var result = Mapper.Map<PSAzureOperationResponse>(op);
                    WriteObject(result);
                });
            }
        }
    }
}

