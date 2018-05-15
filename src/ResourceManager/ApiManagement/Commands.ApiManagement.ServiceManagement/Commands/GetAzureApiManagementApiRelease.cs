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

    [Cmdlet(VerbsCommon.Get, Constants.ApiManagementApiRelease)]
    [OutputType(typeof(IList<PsApiManagementApiRelease>))]
    [OutputType(typeof(PsApiManagementApiRelease))]
    public class GetAzureApiManagementApiRelease : AzureApiManagementCmdletBase
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
            HelpMessage = "API identifier to look for. If specified will try to get the API by the Id.")]
        public String ApiId { get; set; }

        [Parameter(            
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The identifier of the Release.")]
        public String ReleaseId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (string.IsNullOrEmpty(ReleaseId))
            {
                WriteObject(Client.GetApiReleases(Context, ApiId), true);
            }
            else 
            {
                WriteObject(Client.GetApiReleaseById(Context.ResourceGroupName, Context.ServiceName, ApiId, ReleaseId));
            }
        }
    }
}
