//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

namespace Microsoft.Azure.Commands.ApiManagement.Commands
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.Models;

    [Cmdlet(VerbsData.Update, "AzureApiManagementDeployment"), OutputType(typeof(ApiManagement))]
    public class UpdateAzureApiManagementDeployment : ApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "ApiManagementAttributes returned by Get-AzureApiManagement. Use Sku, Capacity, VirtualNetwork and " +
                          "AdditionalRegions properties to manage deployments.")]
        [ValidateNotNull]
        public ApiManagement ApiManagement { get; set; }

        //[Parameter(
        //    ValueFromPipelineByPropertyName = true,
        //    Mandatory = true,
        //    HelpMessage = "Name of resource group of the API Management service.")]
        //[ValidateNotNullOrEmpty]
        //public string ResourceGroupName { get; set; }

        //[Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of API Management service.")]
        //[ValidateNotNullOrEmpty]
        //public string Name { get; set; }

        //[Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Location of master API Management service deployment.")]
        //[ValidateNotNullOrEmpty]
        //[ValidateSet(
        //    "North Central US", "South Central US", "Central US", "West Europe", "North Europe", "West US", "East US",
        //    "East US 2", "Japan East", "Japan West", "Brazil South", "Southeast Asia", "East Asia", "Australia East",
        //    "Australia Southeast", IgnoreCase = false)]
        //public string Location { get; set; }

        //[Parameter(
        //    ValueFromPipelineByPropertyName = true,
        //    Mandatory = true,
        //    HelpMessage = "The tier of the Azure API Management service. Valid values are Developer, Standard and Premium .")]
        //[ValidateNotNullOrEmpty]
        //public ApiManagementSku Sku { get; set; }

        //[Parameter(
        //    ValueFromPipelineByPropertyName = true,
        //    Mandatory = true,
        //    HelpMessage = "Sku capacity of the Azure API Management service.")]
        //[ValidateNotNullOrEmpty]
        //public int Capacity { get; set; }

        //[Parameter(
        //    ValueFromPipelineByPropertyName = true,
        //    Mandatory = true,
        //    HelpMessage = "Virtual Network Configuration of master Azure API Management service deployment.")]
        //[ValidateNotNullOrEmpty]
        //public ApiManagementVirtualNetwork VirtualNetwork { get; set; }

        //[Parameter(
        //    ValueFromPipelineByPropertyName = true,
        //    Mandatory = true,
        //    HelpMessage = "Additional deployment regions of Azure API Management service.")]
        //[ValidateNotNullOrEmpty]
        //public IList<ApiManagementRegionAttributes> AdditionalRegions { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecuteCmdLetWrap(() =>
            {
                WriteObject(ApiManagement);

                ApiManagementLongRunningOperation longRunningOperation =
                    Client.BeginManageDeployments(
                        ApiManagement.ResourceGroupName,
                        ApiManagement.Name,
                        ApiManagement.Location,
                        ApiManagement.Sku,
                        ApiManagement.Capacity,
                        ApiManagement.VirtualNetwork,
                        ApiManagement.AdditionalRegions);

                longRunningOperation = WaitForOperationToComplete(longRunningOperation);
                bool success = string.IsNullOrWhiteSpace(longRunningOperation.Error);
                if (!success)
                {
                    WriteErrorWithTimestamp(longRunningOperation.Error);
                }
                else
                {
                    WriteObject(longRunningOperation.ApiManagement);
                }
            });
        }
    }
}