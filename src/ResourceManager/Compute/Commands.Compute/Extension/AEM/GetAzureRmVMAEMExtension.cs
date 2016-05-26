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
using Microsoft.Rest.Azure;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Get,
        ProfileNouns.VirtualMachineAEMExtension),
    OutputType(
        typeof(PSVirtualMachineExtension))]
    public class GetAzureRmVMAEMExtension : VirtualMachineExtensionBaseCmdlet
    {
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
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Extension Name.")]
        public string Name { get; set; }

        [Parameter(
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To show the status.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Status { get; set; }

        [Parameter(
        Mandatory = false,
        Position = 4,
        ValueFromPipelineByPropertyName = false,
        HelpMessage = "Operating System Type of the virtual machines. Possible values: Windows | Linux")]
        public string OSType { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    var virtualMachine = ComputeClient.ComputeManagementClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);

                    var osdisk = virtualMachine.StorageProfile.OsDisk;
                    if (String.IsNullOrEmpty(this.OSType))
                    {
                        this.OSType = osdisk.OsType.ToString();
                    }
                    if (String.IsNullOrEmpty(this.OSType))
                    {
                        WriteError("Could not determine Operating System of the VM. Please provide the Operating System type ({0} or {1}) via parameter OSType",
                            AEMExtensionConstants.OSTypeWindows, AEMExtensionConstants.OSTypeLinux);
                        return;
                    }

                    var aemExtension = virtualMachine.Resources != null
                            ? virtualMachine.Resources.FirstOrDefault(extension =>
                                extension.Publisher.Equals(AEMExtensionConstants.AEMExtensionPublisher[OSType], StringComparison.InvariantCultureIgnoreCase) &&
                                extension.VirtualMachineExtensionType.Equals(AEMExtensionConstants.AEMExtensionType[OSType], StringComparison.InvariantCultureIgnoreCase))
                            : null;

                    if (aemExtension == null)
                    {
                        WriteObject(null);
                        return;
                    }
                    else {
                        this.Name = aemExtension.Name;
                    }
                }

                AzureOperationResponse<VirtualMachineExtension> virtualMachineExtensionGetResponse = null;
                if (Status.IsPresent)
                {
                    virtualMachineExtensionGetResponse =
                        this.VirtualMachineExtensionClient.GetWithInstanceView(this.ResourceGroupName,
                            this.VMName, this.Name);
                }
                else
                {
                    virtualMachineExtensionGetResponse = this.VirtualMachineExtensionClient.GetWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.VMName,
                        this.Name).GetAwaiter().GetResult();
                }

                var returnedExtension = virtualMachineExtensionGetResponse.ToPSVirtualMachineExtension(
                    this.ResourceGroupName, this.VMName);

                WriteObject(returnedExtension);
            });
        }

        private void WriteError(string message, params object[] args)
        {
            base.WriteError(new ErrorRecord(new Exception(String.Format(message, args)), "Error", ErrorCategory.NotSpecified, null));
        }
    }
}
