using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Extension.DSC
{
    /// <summary>
    /// This cmdlet is used to get the status of the DSC extension handler for a VM
    /// in a resource group. When a configuration is applied this cmdlet produces output 
    /// consistent with Start-DscConfiguration. 
    /// 
    /// Note: To get detailed output -Verbose flag need to be specified
    /// 
    /// Example Usage:
    /// Get-AzureVMDscExtensionStatus -ResourceGroupName resgrp1 -VMName vm1
    /// /// Get-AzureVMDscExtensionStatus -ResourceGroupName resgrp1 -VMName vm1 -Name DSC
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        ProfileNouns.VirtualMachineDscExtensionStatus),
     OutputType(
         typeof(PSVirtualMachineInstanceView))]
    public class GetAzureVMDscExtensionStatusCommand : VirtualMachineExtensionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the ARM resource that represents the extension. The Set-AzureVMDscExtension cmdlet sets this name to  " +
            "'Microsoft.Powershell.DSC', which is the same value used by Get-AzureVMDscExtension. Specify this parameter only if you changed " +
            "the default name in the Set cmdlet or used a different resource name in an ARM template.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (String.IsNullOrEmpty(Name))
            {
                Name = DscExtensionCmdletConstants.ExtensionPublishedNamespace + "." + DscExtensionCmdletConstants.ExtensionPublishedName;
            }

            var result = VirtualMachineExtensionClient.GetWithInstanceView(ResourceGroupName, VMName, Name);
            if (result != null && result.Body != null)
            {
                WriteObject(GetDscExtensionStatusContext(result.Body, ResourceGroupName, VMName));
            }
            else
            {
                WriteObject(null);
            }
        }

        private VirtualMachineDscExtensionStatusContext GetDscExtensionStatusContext(
            VirtualMachineExtension virtualMachineExtension, string resourceGroupName, string vmName)
        {
            var context = new VirtualMachineDscExtensionStatusContext
            {
                ResourceGroupName = resourceGroupName,
                VmName = vmName,
                Version = virtualMachineExtension.TypeHandlerVersion,
            };

            var instanceView = virtualMachineExtension.InstanceView;
            if (instanceView == null) return context;

            var statuses = instanceView.Statuses;
            var substatuses = instanceView.Substatuses;

            if (statuses != null && statuses.Count > 0)
            {
                context.StatusCode = statuses[0].Code;
                context.Status = statuses[0].DisplayStatus;
                context.StatusMessage = statuses[0].Message;
                context.Timestamp = statuses[0].Time == null ? DateTime.MinValue : statuses[0].Time.GetValueOrDefault();
            }

            if (substatuses != null && substatuses.Count > 0)
            {
                context.DscConfigurationLog = !string.Empty.Equals(substatuses[0].Message)
                    ? substatuses[0].Message.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                    : new List<String>().ToArray();
            }

            return context;
        }
    }
}
