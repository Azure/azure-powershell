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
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementApiVersionSet", DefaultParameterSetName = ContextParameterSet)]
    [OutputType(typeof(PsApiManagementApiVersionSet), ParameterSetName = new[] { ContextParameterSet, ResourceIdParameterSet })]
    public class GetAzureApiManagementApiVersionSet : AzureApiManagementCmdletBase
    {
        #region ParameterSetNames
        private const string ContextParameterSet = "ContextParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        #endregion

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }
                
        [Parameter(     
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "API identifier to look for. If specified will try to get the API by the Id.")]
        public String ApiVersionSetId { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm Resource Identifier of the ApiVersionSet." +
            " If specified will try to find apiVersionSet by the identifier. This parameter is required.")]
        public String ResourceId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string apiVersionSetId;            

            if (ParameterSetName.Equals(ContextParameterSet))
            {
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                apiVersionSetId = ApiVersionSetId;
            }
            else
            {
                var apiVersionSet = new PsApiManagementApiVersionSet(ResourceId);
                resourceGroupName = apiVersionSet.ResourceGroupName;
                serviceName = apiVersionSet.ServiceName;
                apiVersionSetId = apiVersionSet.ApiVersionSetId;
            }

            if (string.IsNullOrEmpty(ApiVersionSetId))
            {
                WriteObject(Client.GetApiVersionSets(resourceGroupName, serviceName), true);
            }
            else
            {
                WriteObject(Client.GetApiVersionSet(resourceGroupName, serviceName, ApiVersionSetId));
            }
        }
    }
}
