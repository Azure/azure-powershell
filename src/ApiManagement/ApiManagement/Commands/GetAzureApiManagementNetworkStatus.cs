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

namespace Microsoft.Azure.Commands.ApiManagement.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.Models;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementNetworkStatus", DefaultParameterSetName = ByInputObjectParameterSet)]
    [OutputType(typeof(PsApiManagementNetworkStatus), ParameterSetName = new[] { ExpandedParameterSet, ByInputObjectParameterSet})]
    public class GetAzureApiManagementNetworkStatus : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names

        protected const string ExpandedParameterSet = "ExpandedParameter";
        protected const string ByInputObjectParameterSet = "ByInputObject";

        #endregion

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagement. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagement ApiManagementObject { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which API Management exists.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of API Management.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Location of the API Management Service.")]
        [LocationCompleter("Microsoft.ApiManagement/service")]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                resourceGroupName = ApiManagementObject.ResourceGroupName;
                serviceName = ApiManagementObject.Name;
            }
            else
            {
                resourceGroupName = ResourceGroupName;
                serviceName = Name;
            }

            if (string.IsNullOrEmpty(Location))
            {
                var networkStatusEnumeration = Client.GetNetworkStatus(resourceGroupName, serviceName);
                WriteObject(networkStatusEnumeration.ToList(), true);
            }
            else
            {
                var networkStatus = Client.GetNetworkStatusByLocation(resourceGroupName, serviceName, Location);
                WriteObject(networkStatus);
            }
        }
    }
}
