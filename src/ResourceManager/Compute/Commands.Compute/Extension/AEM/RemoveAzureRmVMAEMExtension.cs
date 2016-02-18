using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Commands.Compute.Extension.AEM;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Remove,
        ProfileNouns.VirtualMachineAEMExtension)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class RemoveAzureRmVMAEMExtension : VirtualMachineExtensionBaseCmdlet
    {
        private AEMHelper _Helper = null;

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
            HelpMessage = "Name of the ARM resource that represents the extension.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
                Mandatory = false,
                Position = 3,
                ValueFromPipelineByPropertyName = false,
                HelpMessage = "Operating System Type of the virtual machines. Possible values: Windows | Linux")]
        public string OSType { get; set; }

        public override void ExecuteCmdlet()
        {
            this._Helper = new AEMHelper((err) => this.WriteError(err), (msg) => this.WriteVerbose(msg), (msg) => this.WriteWarning(msg),
                this.CommandRuntime.Host.UI,
                AzureSession.ClientFactory.CreateClient<StorageManagementClient>(DefaultProfile.Context, AzureEnvironment.Endpoint.ResourceManager),
                this.DefaultContext.Subscription);

            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                VirtualMachine virtualMachine = null;
                if (String.IsNullOrEmpty(this.OSType))
                {
                    virtualMachine = ComputeClient.ComputeManagementClient.VirtualMachines.Get(
                       this.ResourceGroupName, this.VMName);
                    this.OSType = virtualMachine.StorageProfile.OsDisk.OsType;
                }
                if (String.IsNullOrEmpty(this.OSType))
                {
                    this._Helper.WriteError("Could not determine Operating System of the VM. Please provide the Operating System type ({0} or {1}) via parameter OSType",
                        AEMExtensionConstants.OSTypeWindows, AEMExtensionConstants.OSTypeLinux);
                    return;
                }

                if (string.IsNullOrEmpty(this.Name))
                {
                    if (virtualMachine == null)
                    {
                        virtualMachine = ComputeClient.ComputeManagementClient.VirtualMachines.Get(
                            this.ResourceGroupName, this.VMName);
                    }
                    var aemExtension = virtualMachine.Resources != null
                            ? virtualMachine.Resources.FirstOrDefault(extension =>
                                extension.Publisher.Equals(AEMExtensionConstants.AEMExtensionPublisher[this.OSType], StringComparison.InvariantCultureIgnoreCase) &&
                                extension.VirtualMachineExtensionType.Equals(AEMExtensionConstants.AEMExtensionType[this.OSType], StringComparison.InvariantCultureIgnoreCase))
                            : null;

                    if (aemExtension == null)
                    {
                        WriteWarning(string.Format(CultureInfo.InvariantCulture, Properties.Resources.AEMExtensionNotFound, this.ResourceGroupName, this.VMName));
                        return;
                    }
                    else
                    {
                        this.Name = aemExtension.Name;
                    }
                }


                var op = this.VirtualMachineExtensionClient.DeleteWithHttpMessagesAsync(
                    this.ResourceGroupName,
                    this.VMName,
                    this.Name).GetAwaiter().GetResult();
                var result = Mapper.Map<PSAzureOperationResponse>(op);
                WriteObject(result);
            });
        }
    }
}
