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

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementApiSchema", DefaultParameterSetName = ContextParameterSet)]
    [OutputType(typeof(PsApiManagementApiSchema), ParameterSetName = new[] { ContextParameterSet, ResourceIdParameterSet } )]
    public class GetAzureApiManagementApiSchema : AzureApiManagementCmdletBase
    {
        #region ParameterSetNames
        private const string ContextParameterSet = "ContextParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        #endregion

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm Resource Identifier of a Api Schema." +
            " If specified will try to find api schema by the identifier. This parameter is required.")]
        public String ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ContextParameterSet,
            Mandatory = true,
            HelpMessage = "API identifier to look for. This parameter is required.")]
        public String ApiId { get; set; }

        [Parameter(
            ParameterSetName = ContextParameterSet,
            Mandatory = false,
            HelpMessage = "The identifier of the Schema. If not specified, will return all the Schema")]
        public String SchemaId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string schemaId;
            string apiId;

            if (ParameterSetName.Equals(ContextParameterSet))
            {
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                schemaId = SchemaId;
                apiId = ApiId;
            }
            else
            {
                var diagnostic = new PsApiManagementApiSchema(ResourceId);
                resourceGroupName = diagnostic.ResourceGroupName;
                serviceName = diagnostic.ServiceName;
                schemaId = diagnostic.SchemaId;
                apiId = diagnostic.ApiId;
            }

            if (string.IsNullOrEmpty(schemaId))
            {
                var apiSchemas = Client.ApiSchemaList(resourceGroupName, serviceName, apiId);
                WriteObject(apiSchemas, true);
            }
            else
            {
                var apiSchema = Client.ApiSchemaById(resourceGroupName, serviceName, apiId, schemaId);
                WriteObject(apiSchema);
            }
        }
    }
}
