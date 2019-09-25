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

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementApiRelease", DefaultParameterSetName = ContextParameterSet)]
    [OutputType(typeof(PsApiManagementApiRelease), ParameterSetName = new [] { ContextParameterSet, ResourceIdParameterSet })]
    public class GetAzureApiManagementApiRelease : AzureApiManagementCmdletBase
    {
        #region ParameterSetNames
        private const string ContextParameterSet = "ContextParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        #endregion

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }
        
        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "API identifier to look for. If specified will try to get the API by the Id.")]
        public String ApiId { get; set; }

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The identifier of the Release.")]
        public String ReleaseId { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm Resource Identifier of a Api Release." +
            " If specified will try to find api release by the identifier. This parameter is required.")]
        public String ResourceId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string apiId;
            string releaseId;

            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                var psApiRelease = new PsApiManagementApiRelease(ResourceId);
                resourceGroupName = psApiRelease.ResourceGroupName;
                serviceName = psApiRelease.ServiceName;
                apiId = psApiRelease.ApiId;
                releaseId = psApiRelease.ReleaseId;

                WriteObject(Client.GetApiReleaseById(resourceGroupName, serviceName, apiId, releaseId));
            }
            else if (string.IsNullOrEmpty(ReleaseId))
            {
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                apiId = ApiId;
                WriteObject(Client.GetApiReleases(resourceGroupName, serviceName, apiId), true);
            }
            else 
            {
                WriteObject(Client.GetApiReleaseById(Context.ResourceGroupName, Context.ServiceName, ApiId, ReleaseId));
            }
        }
    }
}
