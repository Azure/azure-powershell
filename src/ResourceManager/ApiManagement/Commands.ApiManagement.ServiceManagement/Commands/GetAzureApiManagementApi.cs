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

    [Cmdlet(VerbsCommon.Get, Constants.ApiManagementApi, DefaultParameterSetName = AllApis)]
    [OutputType(typeof(IList<PsApiManagementApi>), ParameterSetName = new[] { AllApis, FindByName, FindByProductId })]
    [OutputType(typeof(PsApiManagementApi), ParameterSetName = new[] { FindById })]
    public class GetAzureApiManagementApi : AzureApiManagementCmdletBase
    {
        private const string FindByProductId = "Find by product ID";
        private const string FindByName = "Find by Name";
        private const string FindById = "Find by ID";
        private const string AllApis = "All APIs";

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = FindById,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "API identifier to look for. If specified will try to get the API by the Id. This parameter is optional.")]
        public String ApiId { get; set; }

        [Parameter(
            ParameterSetName = FindByName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of the API. If specified will try to get the API by name. This parameter is optional.")]
        public String Name { get; set; }

        [Parameter(
            ParameterSetName = FindByProductId,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "If specified will try to get all Product APIs. This parameter is optional.")]
        public String ProductId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ParameterSetName.Equals(AllApis))
            {
                WriteObject(Client.ApiList(Context), true);
            }
            else if (ParameterSetName.Equals(FindById))
            {
                WriteObject(Client.ApiById(Context, ApiId));
            }
            else if (ParameterSetName.Equals(FindByName))
            {
                WriteObject(Client.ApiByName(Context, Name), true);
            }
            else if (ParameterSetName.Equals(FindByProductId))
            {
                WriteObject(Client.ApiByProductId(Context, ProductId), true);
            }
        }
    }
}
