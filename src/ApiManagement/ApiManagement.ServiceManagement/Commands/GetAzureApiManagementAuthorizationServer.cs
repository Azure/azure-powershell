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

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementAuthorizationServer", DefaultParameterSetName = ContextParameterSet)]
    [OutputType(typeof(PsApiManagementOAuth2AuthorizationServer))]
    public class GetAzureApiManagementAuthorizationServer : AzureApiManagementCmdletBase
    {
        #region ParameterSet
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
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of the authorization server. If specified will find authorization server by the identifier." +
                          " This parameter is optional. ")]
        public String ServerId { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm Resource Identifier of the authorization server." +
    " If specified will try to find authorization server by the identifier. This parameter is required.")]
        public String ResourceId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string authorizationserverId;

            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                var authorizationServer = new PsApiManagementOAuth2AuthorizationServer(ResourceId);
                resourceGroupName = authorizationServer.ResourceGroupName;
                serviceName = authorizationServer.ServiceName;
                authorizationserverId = authorizationServer.ServerId;
            }
            else
            {
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                authorizationserverId = ServerId;
            }

            if (string.IsNullOrEmpty(authorizationserverId))
            {
                var servers = Client.AuthorizationServerList(resourceGroupName, serviceName);
                WriteObject(servers, true);
            }
            else
            {
                var server = Client.AuthorizationServerById(resourceGroupName, serviceName, authorizationserverId);
                WriteObject(server);
            }        
        }
    }
}
