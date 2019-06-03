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
    using System.IO;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementApiSchema", SupportsShouldProcess = true, DefaultParameterSetName = SchemaDocumentInlineParameterSet)]
    [OutputType(typeof(PsApiManagementApiSchema), ParameterSetName = new[] { SchemaDocumentInlineParameterSet, SchemaDocumentFromFileParameterSet })]
    public class NewAzureApiManagementApiSchema : AzureApiManagementCmdletBase
    {
        #region ParameterSets
        private const string SchemaDocumentInlineParameterSet = "SchemaDocumentInline";
        private const string SchemaDocumentFromFileParameterSet = "SchemaDocumentFromFile";
        #endregion

        [Parameter(
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of api. This parameter is required.")]
        public String ApiId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of schema in the api. This parameter is optional. If not specified we will generate it.")]
        public String SchemaId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "ContentType of the api Schema. This parameter is required.")]
        [PSArgumentCompleter(Constants.SwaggerDefinitions, Constants.OpenApiComponents, Constants.XsdSchema, Constants.WadlGrammar)]
        public String SchemaDocumentContentType { get; set; }

        [Parameter(
            ParameterSetName = SchemaDocumentInlineParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Api schema document as a string. This parameter is required is -SchemaDocumentFile is not specified.")]
        public String SchemaDocument { get; set; }

        [Parameter(
            ParameterSetName = SchemaDocumentFromFileParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Api schema document file path. This parameter is required is -SchemaDocument is not specified.")]
        public String SchemaDocumentFilePath { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string schemaID = SchemaId ?? Guid.NewGuid().ToString();
            string schemaDocument;

            if (ParameterSetName.Equals(SchemaDocumentInlineParameterSet))
            {
                schemaDocument = SchemaDocument;
            }
            else 
            {
                schemaDocument = File.ReadAllText(SchemaDocumentFilePath);                
            }

            if (ShouldProcess(schemaID, Resources.CreateApiSchema))
            {
                var apiSchema = Client.ApiSchemaCreate(
                    Context.ResourceGroupName,
                    Context.ServiceName,
                    ApiId,
                    schemaID,
                    SchemaDocumentContentType,
                    schemaDocument);

                WriteObject(apiSchema);
            }
        }
    }
}
