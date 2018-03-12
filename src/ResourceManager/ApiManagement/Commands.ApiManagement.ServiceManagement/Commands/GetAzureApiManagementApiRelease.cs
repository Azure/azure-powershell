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

    [Cmdlet(VerbsCommon.Get, Constants.ApiManagementApiRelease, DefaultParameterSetName = AllApis)]
    [OutputType(typeof(IList<PsApiManagementApiRelease>), ParameterSetName = new[] { AllApis })]
    [OutputType(typeof(PsApiManagementApiRelease), ParameterSetName = new[] { FindById })]
    public class GetAzureApiManagementApiRelease : AzureApiManagementCmdletBase
    {
        private const string FindById = "GetByApiId";
        private const string AllApis = "GetAllApis";
        
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = AllApis,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "API identifier to look for. If specified will try to get the API by the Id.")]
        [Parameter(
            ParameterSetName = FindById,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "API identifier to look for. If specified will try to get the API by the Id.")]
        public String ApiId { get; set; }

        [Parameter(
            ParameterSetName = FindById,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "The identifier of the Release.")]
        public String ReleaseId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ParameterSetName.Equals(AllApis))
            {
                WriteObject(Client.GetApiReleases(Context, ApiId), true);
            }
            else if (ParameterSetName.Equals(FindById))
            {
                WriteObject(Client.GetApiReleaseById(Context, ApiId, ReleaseId));
            }
        }
    }
}
