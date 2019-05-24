using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using MC = Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Compute.Extension.DSC
{
    /// <summary>
    /// This cmdlet removes DSC extension handler from a VM in a resource group
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMDscExtension",SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class RemoveAzureVMDscExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the virtual machine.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the ARM resource that represents the extension. The Set-AzVMDscExtension cmdlet sets this name to  " +
            "'Microsoft.Powershell.DSC', which is the same value used by Get-AzVMDscExtension. Specify this parameter only if you changed " +
            "the default name in the Set cmdlet or used a different resource name in an ARM template.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines/extensions", "ResourceGroupName", "VMName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has sucessufuly been completed, use some other mechanism.")]
        public SwitchParameter NoWait { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (String.IsNullOrEmpty(Name))
            {
                Name = DscExtensionCmdletConstants.ExtensionPublishedNamespace + "." + DscExtensionCmdletConstants.ExtensionPublishedName;
            }

            if (ShouldProcess(string.Format(CultureInfo.CurrentUICulture, Microsoft.Azure.Commands.Compute.Properties.Resources.DscExtensionRemovalConfirmation, Name), Microsoft.Azure.Commands.Compute.Properties.Resources.DscExtensionRemovalCaption))
            {
                //Add retry logic due to CRP service restart known issue CRP bug: 3564713
                var count = 1;
                Rest.Azure.AzureOperationResponse op = null;

                if (NoWait.IsPresent)
                {
                    op = VirtualMachineExtensionClient.BeginDeleteWithHttpMessagesAsync(
                            ResourceGroupName,
                            VMName,
                            Name).GetAwaiter().GetResult();
                }
                else
                {
                    while (true)
                    {
                        try
                        {
                            op = VirtualMachineExtensionClient.DeleteWithHttpMessagesAsync(
                                ResourceGroupName,
                                VMName,
                                Name).GetAwaiter().GetResult();
                            break;
                        }
                        catch (Rest.Azure.CloudException ex)
                        {
                            var errorReturned = JsonConvert.DeserializeObject<PSComputeLongRunningOperation>(ex.Response.Content);

                            if ("Failed".Equals(errorReturned.Status)
                                && errorReturned.Error != null && "InternalExecutionError".Equals(errorReturned.Error.Code))
                            {
                                count++;
                                if (count <= 2)
                                {
                                    continue;
                                }
                            }
                            ThrowTerminatingError(new ErrorRecord(ex, "InvalidResult", ErrorCategory.InvalidResult, null));
                        }
                    }
                }

                var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                WriteObject(result);
            }
        }
    }
}
