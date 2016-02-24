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

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute;
using System.Globalization;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Remove,
        ProfileNouns.VirtualMachineDiagnosticsExtension)]
    public class RemoveAzureRmVMDiagnosticsExtensionCommand : VirtualMachineExtensionBaseCmdlet
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

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    var virtualMachine = ComputeClient.ComputeManagementClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName).VirtualMachine;
                    var diagnosticsExtension = virtualMachine.Extensions != null
                            ? virtualMachine.Extensions.FirstOrDefault(extension =>
                                extension.Publisher.Equals(DiagnosticsExtensionConstants.ExtensionPublisher, StringComparison.InvariantCultureIgnoreCase) &&
                                extension.ExtensionType.Equals(DiagnosticsExtensionConstants.ExtensionType, StringComparison.InvariantCultureIgnoreCase))
                            : null;

                    if (diagnosticsExtension == null)
                    {
                        WriteWarning(string.Format(CultureInfo.InvariantCulture, Properties.Resources.DiagnosticsExtensionNotFound, this.ResourceGroupName, this.VMName));
                        return;
                    }
                    else
                    {
                        this.Name = diagnosticsExtension.Name;
                    }
                }

                var op = this.VirtualMachineExtensionClient.Delete(this.ResourceGroupName, this.VMName,
                    this.Name);
                WriteObject(op);
            });
        }
    }
}
