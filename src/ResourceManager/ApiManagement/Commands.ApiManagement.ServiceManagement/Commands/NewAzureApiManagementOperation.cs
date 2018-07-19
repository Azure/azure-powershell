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
    using Management.ApiManagement.Models;

    [Cmdlet(VerbsCommon.New, Constants.ApiManagementOperation)]
    [OutputType(typeof(PsApiManagementOperation))]
    public class NewAzureApiManagementOperation : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of API. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ApiId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of API Revision. This parameter is optional. If not specified, the operation will be " +
            "attached to the currently active api revision.")]
        public String ApiRevision { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of new operation. This parameter is optional." +
                          " If not specified will be generated.")]
        public String OperationId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Display name of new operation. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "HTTP method of new operation. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Method { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "URL template. Example: customers/{cid}/orders/{oid}/?date={date}. " +
                          "This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String UrlTemplate { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Description of new operation. This parameter is optional.")]
        public String Description { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Array or parameters defined in UrlTemplate. This parameter is optional." +
                          " If not specified default value will be generated based on the UrlTemplate." +
                          " Use the parameter to give more details on parameters like description, type, possible values.")]
        public PsApiManagementParameter[] TemplateParameters { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Operation request details. This parameter is optional.")]
        public PsApiManagementRequest Request { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Array of possible operation responses. This parameter is optional.")]
        public PsApiManagementResponse[] Responses { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string operationId = OperationId ?? Guid.NewGuid().ToString("N");

            string apiId = ApiId;
            if (!string.IsNullOrEmpty(ApiRevision))
            {
                apiId = ApiId.ApiRevisionIdentifier(ApiRevision);
            }

            var newOperation = Client.OperationCreate(
                Context,
                ApiId,
                operationId,
                Name,
                Method,
                UrlTemplate,
                Description,
                TemplateParameters,
                Request,
                Responses);

            WriteObject(newOperation);
        }
    }
}
