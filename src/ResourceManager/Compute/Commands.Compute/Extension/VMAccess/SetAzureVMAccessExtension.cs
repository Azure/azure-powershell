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
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineAccessExtension,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureVMAccessExtensionCommand : SetAzureVMExtensionBaseCmdlet
    {
        private const string userNameKey = "UserName";
        private const string passwordKey = "Password";

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "New or Existing User Name")]
        public string UserName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "New or Existing User Password")]
        public string Password { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(VirtualMachineAccessExtensionContext.ExtensionDefaultName, VerbsCommon.Set))
            {
                ExecuteClientAction(() =>
                {
                    Hashtable publicSettings = new Hashtable();
                    publicSettings.Add(userNameKey, UserName ?? "");

                    Hashtable privateSettings = new Hashtable();
                    privateSettings.Add(passwordKey, Password ?? "");

                    if (string.IsNullOrEmpty(this.Location))
                    {
                        this.Location = GetLocationFromVm(this.ResourceGroupName, this.VMName);
                    }

                    var parameters = new VirtualMachineExtension
                    {
                        Location = this.Location,
                        VirtualMachineExtensionType = VirtualMachineAccessExtensionContext.ExtensionDefaultName,
                        Publisher = VirtualMachineAccessExtensionContext.ExtensionDefaultPublisher,
                        TypeHandlerVersion = (this.TypeHandlerVersion) ?? VirtualMachineAccessExtensionContext.ExtensionDefaultVersion,
                        Settings = publicSettings,
                        ProtectedSettings = privateSettings,
                        AutoUpgradeMinorVersion = !this.DisableAutoUpgradeMinorVersion.IsPresent,
                        ForceUpdateTag = this.ForceRerun
                    };

                    var op = this.VirtualMachineExtensionClient.CreateOrUpdateWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.VMName,
                        this.Name,
                        parameters).GetAwaiter().GetResult();
                    var result = Mapper.Map<PSAzureOperationResponse>(op);
                    WriteObject(result);
                });
            }
        }
    }
}
