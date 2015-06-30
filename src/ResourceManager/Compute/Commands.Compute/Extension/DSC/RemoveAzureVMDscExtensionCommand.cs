using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Extension.DSC
{
    /// <summary>
    /// This cmdlet removes DSC extension handler from a VM in a resource group
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        ProfileNouns.VirtualMachineDscExtension)]
    [OutputType(typeof(PSComputeLongRunningOperation))]
    public class RemoveAzureVMDscExtensionCommand : VirtualMachineDscExtensionBaseCmdlet
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

        [Parameter(HelpMessage = "To force the removal.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.Force.IsPresent
             || this.ShouldContinue(Properties.Resources.VirtualMachineExtensionRemovalConfirmation, Properties.Resources.VirtualMachineExtensionRemovalCaption))
            {
                var op = this.VirtualMachineExtensionClient.Delete(ResourceGroupName, VMName, ExtensionNamespace + "." + ExtensionName);
                var result = Mapper.Map<PSComputeLongRunningOperation>(op);
                WriteObject(result);
            }
        }
    }
}
