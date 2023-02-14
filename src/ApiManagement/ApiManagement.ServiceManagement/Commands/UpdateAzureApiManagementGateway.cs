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
    using System.Management.Automation;

    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementGateway", SupportsShouldProcess = true, DefaultParameterSetName = ExpandedParameterSet)]
    [OutputType(typeof(PsApiManagementGateway), ParameterSetName = new[] { ExpandedParameterSet, ByInputObjectParameterSet, ByResourceIdParameterSet })]
    public class UpdateAzureApiManagementGateway : AzureApiManagementCmdletBase
    {
        protected const string ExpandedParameterSet = "ExpandedParameter";
        protected const string ByInputObjectParameterSet = "ByInputObject";
        protected const string ByResourceIdParameterSet = "ByResourceId";

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing gateway. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String GatewayId { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementGateway. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementGateway InputObject { get; set; }

        [Parameter(
            ParameterSetName = ByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm ResourceId of the Gateway. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ResourceId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Gateway description. This parameter is optional.")]
        public String Description { get; set; }

        [Parameter(
                   ValueFromPipelineByPropertyName = true,
                   Mandatory = false,
                   HelpMessage = "Gateway location. This parameter is optional.")]
        public PsApiManagementResourceLocation LocationData { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of " +
                          "Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementGateway type " +
                          "representing the modified gateway.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string gatewayId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                resourceGroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
                gatewayId = InputObject.GatewayId;
            }
            else if (ParameterSetName.Equals(ExpandedParameterSet))
            {
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                gatewayId = GatewayId;
            }
            else
            {
                var gateway = new PsApiManagementGateway(ResourceId);
                resourceGroupName = gateway.ResourceGroupName;
                serviceName = gateway.ServiceName;
                gatewayId = gateway.GatewayId;
            }


            if (ShouldProcess(GatewayId, Resources.SetGateway))
            {
                Client.GatewaySet(resourceGroupName, serviceName, gatewayId, Description, LocationData, InputObject);

                if (PassThru)
                {
                    var @gateway = Client.GatewayById(resourceGroupName, serviceName, gatewayId);
                    WriteObject(@gateway);
                }
            }
        }
    }
}
