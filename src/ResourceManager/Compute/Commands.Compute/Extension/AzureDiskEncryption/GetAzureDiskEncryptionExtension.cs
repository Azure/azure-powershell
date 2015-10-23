using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using System;
using System.Management.Automation;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    [Cmdlet(
        VerbsCommon.Get,
        ProfileNouns.AzureDiskEncryptionExtension),
    OutputType(typeof(AzureDiskEncryptionExtensionContext))]
    public class GetAzureDiskEncryptionExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource group name of the virtual machine")]
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

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To show the status view.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Status { get; set; }


        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            ExecuteClientAction(() =>
            {
                VirtualMachineExtensionGetResponse result = (Status.IsPresent == true) ?
                                                        this.VirtualMachineExtensionClient.GetWithInstanceView(this.ResourceGroupName, this.VMName, this.Name) :
                                                        this.VirtualMachineExtensionClient.Get(this.ResourceGroupName, this.VMName, this.Name);

                PSVirtualMachineExtension returnedExtension = result.ToPSVirtualMachineExtension(this.ResourceGroupName);

                if (returnedExtension.Publisher.Equals(AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher, StringComparison.InvariantCultureIgnoreCase) &&
                    returnedExtension.ExtensionType.Equals(AzureDiskEncryptionExtensionContext.ExtensionDefaultName, StringComparison.InvariantCultureIgnoreCase))
                {
                    WriteObject(new AzureDiskEncryptionExtensionContext(returnedExtension));
                }
                else
                {
                    WriteObject(null);
                }
            });

        }
    }
}