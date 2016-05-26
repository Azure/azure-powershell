using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Extension.DSC
{
    /// <summary>
    /// This cmdlet removes DSC extension handler from a VM in a resource group
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        ProfileNouns.VirtualMachineDscExtension,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureOperationResponse))]
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
            HelpMessage = "Name of the ARM resource that represents the extension. The Set-AzureRmVMDscExtension cmdlet sets this name to  " +
            "'Microsoft.Powershell.DSC', which is the same value used by Get-AzureRmVMDscExtension. Specify this parameter only if you changed " +
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

            if (ShouldProcess(string.Format(CultureInfo.CurrentUICulture, Microsoft.Azure.Commands.Compute.Properties.Resources.DscExtensionRemovalConfirmation, Name), Microsoft.Azure.Commands.Compute.Properties.Resources.DscExtensionRemovalCaption))
            {
                //Add retry logic due to CRP service restart known issue CRP bug: 3564713
                var count = 1;
                Rest.Azure.AzureOperationResponse op = null;

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

                var result = Mapper.Map<PSAzureOperationResponse>(op);
                WriteObject(result);
            }
        }
    }
}
