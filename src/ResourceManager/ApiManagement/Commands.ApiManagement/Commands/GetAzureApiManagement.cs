using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ApiManagement.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.ApiManagement
{
    [Cmdlet(VerbsCommon.Get, "AzureApiManagement", DefaultParameterSetName = BaseParameterSetName), OutputType(typeof(List<ApiManagementAttributes>))]
    public class GetAzureApiManagement : AzurePSCmdlet
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
            //TODO: implement

            if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(Name))
            {
                // Get for single API Management service
                WriteObject(new ApiManagementAttributes());
            }
            else
            {
                // List all services in given resource group if avaliable otherwise all services in given subscription
                List<ApiManagementAttributes> list = new List<ApiManagementAttributes>();
                WriteObject(list, true);
            }
        }
    }
}