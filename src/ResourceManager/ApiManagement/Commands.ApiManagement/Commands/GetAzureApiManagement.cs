namespace Microsoft.Azure.Commands.ApiManagement.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.Models;

    [Cmdlet(VerbsCommon.Get, "AzureApiManagement", DefaultParameterSetName = BaseParameterSetName), OutputType(typeof(List<ApiManagementAttributes>))]
    public class GetAzureApiManagement : ApiManagementCmdletBase
    {
        internal const string BaseParameterSetName = "All In Subscription";
        internal const string ResourceGroupParameterSetName = "All In Resource Group";
        internal const string ApiManagementParameterSetName = "Specific API Management Service";

        [Parameter(
            ParameterSetName = ResourceGroupParameterSetName,
            ValueFromPipelineByPropertyName = true, 
            Mandatory = true, 
            HelpMessage = "Name of resource group under which want to create API Management service.")]
        [Parameter(
            ParameterSetName = ApiManagementParameterSetName, 
            ValueFromPipelineByPropertyName = true, 
            Mandatory = true, 
            HelpMessage = "Name of resource group under which want to create API Management service.")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ApiManagementParameterSetName, 
            ValueFromPipelineByPropertyName = true, 
            Mandatory = true, 
            HelpMessage = "Name of API Management service.")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(Name))
            {
                // Get for single API Management service
                ApiManagementAttributes attributes = Client.GetApiManagement(ResourceGroupName, Name);
                WriteObject(attributes);
            }
            else
            {
                // List all services in given resource group if avaliable otherwise all services in given subscription
                IEnumerable<ApiManagementAttributes> enumeration = Client.ListApiManagements(ResourceGroupName);
                WriteObject(enumeration.ToList(), true);
            }
        }
    }
}