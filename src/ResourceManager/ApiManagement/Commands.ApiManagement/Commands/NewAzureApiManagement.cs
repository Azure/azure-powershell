using System.Management.Automation;
using Microsoft.Azure.Commands.ApiManagement.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.ApiManagement
{
    [Cmdlet(VerbsCommon.New, "AzureApiManagement"), OutputType(typeof(ApiManagementAttributes))]
    public class NewAzureApiManagement : AzurePSCmdlet
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true, 
            Mandatory = true, 
            HelpMessage = "Name of resource group under which you want to create API Management service.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of API Management service.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Location where want to create API Management service.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            "North Central US", "South Central US", "Central US", "West Europe", "North Europe", "West US", "East US",
            "East US 2", "Japan East", "Japan West", "Brazil South", "Southeast Asia", "East Asia", "Australia East", 
            "Australia Southeast", IgnoreCase = false)]
        public string Location { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true, 
            Mandatory = true, 
            HelpMessage = "The name of the organization for use in the developer portal in e-mail notifications.")]
        [ValidateNotNullOrEmpty]
        public string Organization { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "The originating e-mail address for all e-mail notifications sent from the API Management system.")]
        [ValidateNotNullOrEmpty]
        public string AdminEmail { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The tier of the Azure API Management service. Valid values are Developer, Standard and Premium (preview).")]
        [ValidateNotNullOrEmpty]
        public string Sku { get; set; }
    }
}