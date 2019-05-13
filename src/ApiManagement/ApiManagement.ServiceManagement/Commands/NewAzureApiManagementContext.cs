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

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementContext", DefaultParameterSetName = ContextParameterSet)]
    [OutputType(typeof(PsApiManagementContext), ParameterSetName = new[] { ContextParameterSet, ResourceIdParameterSet } )]
    public class NewAzureApiManagementContext : AzureApiManagementCmdletBase
    {
        #region ParameterSetNames
        private const string ContextParameterSet = "ContextParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        #endregion

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which an API Management service is deployed.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of deployed API Management service.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm Resource Identifier of a ApiManagement service. This parameter is required.")]
        public string ResourceId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                var resourceIdentifier = new PsApiManagementArmResource(ResourceId);
                resourceGroupName = resourceIdentifier.ResourceGroupName;
                serviceName = resourceIdentifier.ServiceName;
            }
            else
            {
                resourceGroupName = ResourceGroupName;
                serviceName = ServiceName;
            }
            
            WriteObject(
                new PsApiManagementContext
                {
                    ResourceGroupName = resourceGroupName,
                    ServiceName = serviceName
                });
        }
    }
}
