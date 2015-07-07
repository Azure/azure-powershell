using System;
using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using System.Management.Automation;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Extension.DSC
{
    /// <summary>
    /// This cmdlet removes DSC extension handler from a VM in a resource group
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        ProfileNouns.VirtualMachineDscExtension,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSComputeLongRunningOperation))]
    public class RemoveAzureVMDscExtensionCommand : VirtualMachineDscExtensionBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension handler name. This is defaulted to 'Microsoft.Powershell.DSC'")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (String.IsNullOrEmpty(Name))
            {
                Name = ExtensionNamespace + "." + ExtensionName;
            }

            if (ShouldProcess(Properties.Resources.VirtualMachineExtensionRemovalConfirmation, Properties.Resources.VirtualMachineExtensionRemovalCaption))
            {
                //Add retry logic due to CRP service restart known issue CRP bug: 3564713
                var count = 1;
                DeleteOperationResponse op = null;
                while (count <= 2)
                {
                    op = VirtualMachineExtensionClient.Delete(ResourceGroupName, VMName, Name);

                    if (ComputeOperationStatus.Failed.Equals(op.Status) && op.Error != null && "InternalExecutionError".Equals(op.Error.Code))
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                var result = Mapper.Map<PSComputeLongRunningOperation>(op);
                WriteObject(result);
            }
        }
    }
}
