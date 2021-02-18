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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using System.Linq;
<<<<<<< HEAD

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMExtension")]
    [OutputType(typeof(PSVirtualMachineExtension))]
    public class GetAzureVMExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
=======
using System;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMExtension", DefaultParameterSetName = GetExtensionParamSetName)]
    [OutputType(typeof(PSVirtualMachineExtension))]
    public class GetAzureVMExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {

        private const string GetExtensionParamSetName = "GetExtensionParameterSet",
            VMParameterSetName = "VMParameterSet",
            ResourceIdParameterSet = "ResourceIdParameterSet";

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
<<<<<<< HEAD
=======
           ParameterSetName = GetExtensionParamSetName,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
<<<<<<< HEAD
=======
            ParameterSetName = GetExtensionParamSetName,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = "The virtual machine name.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
<<<<<<< HEAD
=======
            ParameterSetName = GetExtensionParamSetName,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
=======
        [Parameter(
            ParameterSetName = VMParameterSetName,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the virtual machine object the extension is on.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VMObject { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Resource id specifying the virtual machine object the extension is on.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
<<<<<<< HEAD
=======
                string virtualMachineName = "";
                string resourceGroup = "";

                switch (ParameterSetName)
                {

                    case VMParameterSetName:
                        virtualMachineName = this.VMObject.Name;
                        if (this.VMObject.ResourceGroupName == null)
                        {
                            WriteError("The incoming virtual machine must have a 'resourceGroupName'.", this.VMObject);
                        }
                        resourceGroup = this.VMObject.ResourceGroupName;

                        break;

                    case ResourceIdParameterSet:
                        ResourceIdentifier identifier = new ResourceIdentifier(this.ResourceId);
                        resourceGroup = identifier.ResourceGroupName;
                        virtualMachineName = identifier.ResourceName;

                        break;

                    default:
                        virtualMachineName = VMName;
                        resourceGroup = ResourceGroupName;

                        break;

                }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                if (!string.IsNullOrEmpty(Name))
                {
                    if (Status.IsPresent)
                    {
<<<<<<< HEAD
                        var result = this.VirtualMachineExtensionClient.GetWithInstanceView(this.ResourceGroupName, this.VMName, this.Name);
                        WriteObject(result.ToPSVirtualMachineExtension(this.ResourceGroupName, this.VMName));
                    }
                    else
                    {
                        var result = this.VirtualMachineExtensionClient.GetWithHttpMessagesAsync(this.ResourceGroupName,
                            this.VMName, this.Name).GetAwaiter().GetResult();
                        WriteObject(result.ToPSVirtualMachineExtension(this.ResourceGroupName, this.VMName));
=======
                        var result = this.VirtualMachineExtensionClient.GetWithInstanceView(resourceGroup, virtualMachineName, this.Name);
                        WriteObject(result.ToPSVirtualMachineExtension(resourceGroup, virtualMachineName));
                    }
                    else
                    {
                        var result = this.VirtualMachineExtensionClient.GetWithHttpMessagesAsync(resourceGroup,
                            virtualMachineName, this.Name).GetAwaiter().GetResult();
                        WriteObject(result.ToPSVirtualMachineExtension(resourceGroup, virtualMachineName));
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    }
                }
                else
                {
                    if (Status.IsPresent)
                    {
<<<<<<< HEAD
                        var result = this.VirtualMachineExtensionClient.ListWithInstanceView(this.ResourceGroupName, this.VMName).Body.Value;
                        WriteObject(result.ToList().Select(t => t.ToPSVirtualMachineExtension(this.ResourceGroupName, this.VMName)), true);
                    }
                    else
                    {
                        var result = this.VirtualMachineExtensionClient.ListWithHttpMessagesAsync(this.ResourceGroupName, this.VMName).GetAwaiter().GetResult().Body.Value;
                        WriteObject(result.ToList().Select(t => t.ToPSVirtualMachineExtension(this.ResourceGroupName, this.VMName)), true);
=======
                        var result = this.VirtualMachineExtensionClient.ListWithInstanceView(resourceGroup, virtualMachineName).Body.Value;
                        WriteObject(result.ToList().Select(t => t.ToPSVirtualMachineExtension(resourceGroup, virtualMachineName)), true);
                    }
                    else
                    {
                        var result = this.VirtualMachineExtensionClient.ListWithHttpMessagesAsync(resourceGroup, virtualMachineName).GetAwaiter().GetResult().Body.Value;
                        WriteObject(result.ToList().Select(t => t.ToPSVirtualMachineExtension(resourceGroup, virtualMachineName)), true);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    }
                }
            });
        }
<<<<<<< HEAD
=======

        private void WriteError(string message, params object[] args)
        {
            base.WriteError(new ErrorRecord(new Exception(String.Format(message, args)), "Error", ErrorCategory.NotSpecified, null));
        }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
