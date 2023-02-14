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
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using System;
    using System.Management.Automation;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementGatewayHostnameConfiguration", DefaultParameterSetName = GetByGatewayId)]
    [OutputType(typeof(PsApiManagementGatewayHostnameConfiguration), ParameterSetName = new[] { GetByGatewayId, GetByGatewayHostnameId })]
    public class GetAzureApiManagementGatewayHostnameConfiguration : AzureApiManagementCmdletBase
    {
        private const string GetByGatewayId = "GetByGatewayId";
        private const string GetByGatewayHostnameId = "GetByGatewayHostnameId";

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = GetByGatewayId,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Gateway identifier. This parameter is required.")]
        [Parameter(
            ParameterSetName = GetByGatewayHostnameId,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Gateway identifier. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String GatewayId { get; set; }

        [Parameter(
            ParameterSetName = GetByGatewayHostnameId,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Hostname Configuration identifier.")]
        public String GatewayHostnameConfigurationId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ParameterSetName.Equals(GetByGatewayId))
            {
                var gateways = Client.GatewayHostnameConfigurationByGateway(
                    Context.ResourceGroupName,
                    Context.ServiceName,
                    GatewayId);
                WriteObject(gateways, true);
            }
            else if (ParameterSetName.Equals(GetByGatewayHostnameId))
            {
                var gateway = Client.GatewayHostnameConfigurationById(
                    Context.ResourceGroupName, 
                    Context.ServiceName,
                    GatewayId,
                    GatewayHostnameConfigurationId);
                WriteObject(gateway);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Parameter set name '{0}' is not supported.", ParameterSetName));
            }
        }
    }
}
