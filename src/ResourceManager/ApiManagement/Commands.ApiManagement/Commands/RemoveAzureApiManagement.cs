using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.ApiManagement
{
    [Cmdlet(VerbsCommon.Remove, "AzureApiManagement"), OutputType(typeof(bool))]
    public class RemoveAzureApiManagement : AzurePSCmdlet
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which API Management service exists.")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of API Management service.")]
        public string Name { get; set; }
    }
}