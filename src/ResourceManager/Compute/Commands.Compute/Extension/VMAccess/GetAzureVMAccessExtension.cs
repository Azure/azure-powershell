﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMAccessExtension"),OutputType(typeof(VirtualMachineAccessExtensionContext))]
    public class GetAzureVMAccessExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines/extensions", "ResourceGroupName", "VMName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To show the status.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Status { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (Status.IsPresent)
                {
                    var result = this.VirtualMachineExtensionClient.GetWithInstanceView(this.ResourceGroupName, this.VMName, this.Name);
                    var returnedExtension = result.ToPSVirtualMachineExtension(this.ResourceGroupName, this.VMName);

                    if (returnedExtension.Publisher.Equals(VirtualMachineAccessExtensionContext.ExtensionDefaultPublisher, StringComparison.InvariantCultureIgnoreCase) &&
                        returnedExtension.ExtensionType.Equals(VirtualMachineAccessExtensionContext.ExtensionDefaultName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        WriteObject(new VirtualMachineAccessExtensionContext(returnedExtension));
                    }
                    else
                    {
                        WriteObject(null);
                    }
                }
                else
                {
                    var result = this.VirtualMachineExtensionClient.Get(this.ResourceGroupName, this.VMName, this.Name);
                    var returnedExtension = result.ToPSVirtualMachineExtension(this.ResourceGroupName, this.VMName);

                    if (returnedExtension.Publisher.Equals(VirtualMachineAccessExtensionContext.ExtensionDefaultPublisher, StringComparison.InvariantCultureIgnoreCase) &&
                        returnedExtension.ExtensionType.Equals(VirtualMachineAccessExtensionContext.ExtensionDefaultName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        WriteObject(new VirtualMachineAccessExtensionContext(returnedExtension));
                    }
                    else
                    {
                        WriteObject(null);
                    }
                }
            });
        }
    }
}
