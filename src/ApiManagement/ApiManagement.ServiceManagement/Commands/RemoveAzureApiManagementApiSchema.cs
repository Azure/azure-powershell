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
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementApiSchema", DefaultParameterSetName = ByApiSchemaIdParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(bool), ParameterSetName = new[] { ByApiSchemaIdParameterSet, ByInputObjectParameterSet, ByResourceIdParameterSet })]
    public class RemoveAzureApiManagementApiSchema : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names

        private const string ByApiSchemaIdParameterSet = "ByApiSchemaId";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceIdParameterSet";

        #endregion

        [Parameter(
            ParameterSetName = ByApiSchemaIdParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }
        
        [Parameter(
            ParameterSetName = ByApiSchemaIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of the API. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ApiId { get; set; }

        [Parameter(
            ParameterSetName = ByApiSchemaIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of the API Schema. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String SchemaId { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementApiSchema. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementApiSchema InputObject { get; set; }

        [Parameter(
            ParameterSetName = ByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm ResourceId of ApiSchema. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "If specified will write true in case operation succeeds. This parameter is optional.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string apiId;
            string schemaId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                apiId = InputObject.ApiId;
                schemaId = InputObject.SchemaId;
                resourceGroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
            }
            else if (ParameterSetName.Equals(ByApiSchemaIdParameterSet))
            {
                apiId = ApiId;
                schemaId = SchemaId;
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
            }
            else
            {
                var apiSchema = new PsApiManagementApiSchema(ResourceId);
                resourceGroupName = apiSchema.ResourceGroupName;
                serviceName = apiSchema.ServiceName;
                apiId = apiSchema.ApiId;
                schemaId = apiSchema.SchemaId;
            }

            var actionDescription = string.Format(CultureInfo.CurrentCulture, Resources.ApiSchemaRemoveDescription, schemaId, apiId);
            var actionWarning = string.Format(CultureInfo.CurrentCulture, Resources.ApiSchemaRemoveWarning, schemaId, apiId);

            // Do nothing if force is not specified and user cancelled the operation
            if (!ShouldProcess(
                    actionDescription,
                    actionWarning,
                    Resources.ShouldProcessCaption))
            {
                return;
            }

            Client.ApiSchemaRemove(resourceGroupName, serviceName, apiId, schemaId);

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
