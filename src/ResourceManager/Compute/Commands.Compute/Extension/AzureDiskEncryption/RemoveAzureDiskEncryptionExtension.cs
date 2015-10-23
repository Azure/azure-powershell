using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    [Cmdlet(
        VerbsCommon.Remove,
        ProfileNouns.AzureDiskEncryptionExtension)]
    public class RemoveAzureDiskEncryptionExtensionCommand : VirtualMachineExtensionBaseCmdlet
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
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "To force the removal.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            ExecuteClientAction(() =>
            {
                if (this.Force.IsPresent
             || this.ShouldContinue(Properties.Resources.VirtualMachineExtensionRemovalConfirmation, Properties.Resources.VirtualMachineExtensionRemovalCaption))
                {
                    var op = this.VirtualMachineExtensionClient.Delete(this.ResourceGroupName, this.VMName, this.Name);
                    WriteObject(op);
                }
            });
        }
    }
}
