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
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;

    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementApiSchema", DefaultParameterSetName = ExpandedParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementApiSchema), ParameterSetName = new[] { ExpandedParameterSet, ByInputObjectParameterSet, ByResourceIdParameterSet })]
    public class SetAzureApiManagementApiSchema : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names

        protected const string ExpandedParameterSet = "ExpandedParameter";
        protected const string ByInputObjectParameterSet = "ByInputObject";
        protected const string ByResourceIdParameterSet = "ByResourceId";

        #endregion

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing API. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ApiId { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing Schema. This parameter is required.")]
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
            HelpMessage = "Arm ResourceId of Diagnostic or Api Schema. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "ContentType of the api Schema. This parameter is optional.")]
        [PSArgumentCompleter(Constants.SwaggerDefinitions, Constants.OpenApiComponents, Constants.XsdSchema, Constants.WadlGrammar)]
        public String SchemaDocumentContentType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Api schema document as a string. This parameter is required is -SchemaDocumentFile is not specified.")]
        public String SchemaDocument { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Api schema document file path. This parameter is required is -SchemaDocument is not specified.")]
        public String SchemaDocumentFilePath { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of" +
                          " Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApiSchema type " +
                          "representing the set API Schema.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourcegroupName;
            string serviceName;
            string apiId;
            string schemaId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                resourcegroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
                apiId = InputObject.ApiId;
                schemaId = InputObject.SchemaId;
            }
            else if(ParameterSetName.Equals(ExpandedParameterSet))
            {
                resourcegroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                apiId = ApiId;
                schemaId = SchemaId;
            }
            else
            {
                var psApiSchema = new PsApiManagementApiSchema(ResourceId);
                resourcegroupName = psApiSchema.ResourceGroupName;
                serviceName = psApiSchema.ServiceName;
                apiId = psApiSchema.ApiId;
                schemaId = psApiSchema.SchemaId;
            }

            if (ShouldProcess(schemaId, Resources.SetApiSchema))
            {
                string schemaDocument = null;
                if (!string.IsNullOrWhiteSpace(SchemaDocument))
                {
                    schemaDocument = SchemaDocument;
                }
                else if (!string.IsNullOrEmpty(SchemaDocumentFilePath))
                {
                    schemaDocument = File.ReadAllText(SchemaDocumentFilePath);
                }

                var apiSchema = Client.ApiSchemaSet(
                    resourcegroupName,
                    serviceName,
                    apiId,
                    schemaId,
                    SchemaDocumentContentType,
                    schemaDocument,
                    InputObject);

                if (PassThru.IsPresent)
                {
                    WriteObject(apiSchema);
                }
            }
        }
    }
}
