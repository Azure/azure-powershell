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
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Management.Automation;
using AutoMapper;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineAccessExtension)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureVMAccessExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        private const string userNameKey = "UserName";
        private const string passwordKey = "Password";

        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("HandlerVersion", "Version")]
        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The type handler version.")]
        [ValidateNotNullOrEmpty]
        public string TypeHandlerVersion { get; set; }

        [Parameter(
           Mandatory = false,
           Position = 4,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "New or Existing User Name")]
        public string UserName { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "New or Existing User Password")]
        public string Password { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

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
                    AutoUpgradeMinorVersion = true
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
