using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Globalization;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC;

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
    public class RemoveAzureVMDscExtensionCommand : VirtualMachineExtensionBaseCmdlet
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

            if (ShouldProcess(string.Format(CultureInfo.CurrentUICulture, Properties.Resources.DscExtensionRemovalConfirmation, Name), Properties.Resources.DscExtensionRemovalCaption))
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
