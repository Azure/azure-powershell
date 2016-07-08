using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Compute.Extension.Chef
{
    [Cmdlet(
        VerbsCommon.Get,
        ProfileNouns.VirtualMachineChefExtension),
    OutputType(
        typeof(PSVirtualMachineExtension))]
    public class GetAzureRmVMChefExtension : VirtualMachineExtensionBaseCmdlet
    {
        private string ExtensionDefaultPublisher = "Chef.Bootstrap.WindowsAzure";
        private string ExtensionDefaultName = "ChefClient";
        private string LinuxExtensionName = "LinuxChefClient";

        protected const string LinuxParameterSetName = "Linux";
        protected const string WindowsParameterSetName = "Windows";

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
            Mandatory = true,
            ParameterSetName = LinuxParameterSetName,
            HelpMessage = "Set extension for Linux.")]
        public SwitchParameter Linux { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = WindowsParameterSetName,
            HelpMessage = "Set extension for Windows.")]
        public SwitchParameter Windows { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.Linux.IsPresent)
            {
                this.Name = LinuxExtensionName;
            }
            else if (this.Windows.IsPresent)
            {
                this.Name = ExtensionDefaultName;
            }

            ExecuteClientAction(() =>
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    var virtualMachine = ComputeClient.ComputeManagementClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);
                    var chefExtension = virtualMachine.Resources != null
                            ? virtualMachine.Resources.FirstOrDefault(extension =>
                                extension.Publisher.Equals(ExtensionDefaultPublisher, StringComparison.InvariantCultureIgnoreCase) &&
                                extension.VirtualMachineExtensionType.Equals(this.Name, StringComparison.InvariantCultureIgnoreCase))
                            : null;

                    if (chefExtension == null)
                    {
                        WriteObject(null);
                        return;
                    }
                    else
                    {
                        this.Name = chefExtension.Name;
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

                var returnedExtension = virtualMachineExtensionGetResponse.ToPSVirtualMachineExtension(this.ResourceGroupName, this.VMName);
                WriteObject(returnedExtension);
            });
        }
    }
}
