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
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;
    using System;
    using System.Globalization;
    using System.Management.Automation;

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementGatewayHostnameConfiguration", SupportsShouldProcess = true, DefaultParameterSetName = ContextParameterSet)]
    [OutputType(typeof(bool), ParameterSetName = new[] { ContextParameterSet, ByInputObjectParameterSet, ByResourceIdParameterSet })]
    public class RemoveAzureApiManagementGatewayHostnameConfiguration : AzureApiManagementCmdletBase
    {
        const string ContextParameterSet = "ContextParameterSetName";
        const string ByInputObjectParameterSet = "ByInputObjectParameterSet";
        const string ByResourceIdParameterSet = "ByResourceIdParameterSet";

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
            HelpMessage = "Identifier of existing gateway. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String GatewayId { get; set; }

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing gateway hostname configuration. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String GatewayHostnameConfigurationId { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementGatewayHostnameConfiguration. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementGatewayHostnameConfiguration InputObject { get; set; }

        [Parameter(
            ParameterSetName = ByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm ResourceId of the GatewayHostnameConfiguration. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ResourceId { get; set; }


        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified will write true in case operation succeeds. This parameter is optional. Default value is false.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string gatewayId;
            string gatewayHostnameConfigurationId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                resourceGroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
                gatewayId = InputObject.GatewayId;
                gatewayHostnameConfigurationId = InputObject.GatewayHostnameConfigurationId;
            }
            else if (ParameterSetName.Equals(ByResourceIdParameterSet))
            {
                var gateway = new PsApiManagementGatewayHostnameConfiguration(ResourceId);
                resourceGroupName = gateway.ResourceGroupName;
                serviceName = gateway.ServiceName;
                gatewayId = gateway.GatewayId;
                gatewayHostnameConfigurationId = gateway.GatewayHostnameConfigurationId;
            }
            else
            {
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                gatewayId = GatewayId;
                gatewayHostnameConfigurationId = GatewayHostnameConfigurationId;
            }

            var actionDescription = string.Format(CultureInfo.CurrentCulture, Resources.GatewayHostnameConfigurationRemoveDescription, gatewayId, gatewayHostnameConfigurationId);
            var actionWarning = string.Format(CultureInfo.CurrentCulture, Resources.GatewayHostnameConfigurationRemoveWarning, gatewayId, gatewayHostnameConfigurationId);

            // Do nothing if force is not specified and user cancelled the operation
            if (!ShouldProcess(
                    actionDescription,
                    actionWarning,
                    Resources.ShouldProcessCaption))
            {
                return;
            }

            Client.GatewayHostnameConfigurationRemove(resourceGroupName, serviceName, gatewayId, gatewayHostnameConfigurationId);

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
