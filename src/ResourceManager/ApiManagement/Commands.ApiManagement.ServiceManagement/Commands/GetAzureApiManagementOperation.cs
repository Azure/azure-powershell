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
    using System.Collections.Generic;
    using System.Management.Automation;
    using Management.ApiManagement.Models;

    [Cmdlet(VerbsCommon.Get, Constants.ApiManagementOperation, DefaultParameterSetName = AllApiOperations)]
    [OutputType(typeof(IList<PsApiManagementOperation>), ParameterSetName = new[] { AllApiOperations })]
    [OutputType(typeof(PsApiManagementOperation), ParameterSetName = new[] { FindById })]
    public class GetAzureApiManagementOperation : AzureApiManagementCmdletBase
    {
        private const string FindById = "GetById";
        private const string AllApiOperations = "GetAllApiOperations";

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = AllApiOperations,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of API Operation belongs to. This parameter is required.")]
        [Parameter(
            ParameterSetName = FindById,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of API Operation belongs to. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ApiId { get; set; }

        [Parameter(
            ParameterSetName = AllApiOperations,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of API Revision. This parameter is optional. If not specified, the operation will be " +
            "retrieved from the currently active api revision.")]
        [Parameter(
            ParameterSetName = FindById,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of API Revision. This parameter is optional. If not specified, the operation will be " +
            "retrieved from the currently active api revision.")]
        public String ApiRevision { get; set; }

        [Parameter(
            ParameterSetName = FindById,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier operation to look for. This parameter is optional.")]
        public String OperationId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string apiId = ApiId;
            if (!string.IsNullOrEmpty(ApiRevision))
            {
                apiId = ApiId.ApiRevisionIdentifier(ApiRevision);
            }

            if (ParameterSetName.Equals(AllApiOperations))
            {
                WriteObject(Client.OperationList(Context, apiId), true);
            }
            else if (ParameterSetName.Equals(FindById))
            {
                WriteObject(Client.OperationById(Context, apiId, OperationId));
            }
            else
            {
                throw new InvalidOperationException(string.Format("Parameter set name '{0}' is not supported.", ParameterSetName));
            }
        }
    }
}
