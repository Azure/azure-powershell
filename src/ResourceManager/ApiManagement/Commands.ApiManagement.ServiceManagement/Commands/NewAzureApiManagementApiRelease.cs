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
    using Properties;
    using System;
    using System.Linq;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New, Constants.ApiManagementApiRelease, SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementApiRelease))]
    public class NewAzureApiManagementApiRelease : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipeline =true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier for new API.")]
        public String ApiId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier for the Api Revision.")]
        public String ApiRevision { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier for the Api Release. This parameter is optional. If not specified identifier will be generated.")]
        public String ReleaseId { get; set; }
        
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Api Release Notes. This parameter is optional")]
        public String Note { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string id = ReleaseId ?? Guid.NewGuid().ToString("N");
            if (ShouldProcess(id, Resources.CreateApiRelease))
            {
                var apiRelease = Client.CreateApiRelease(
                    Context,
                    ApiId,
                    ApiRevision,
                    id,
                    Note);

                WriteObject(apiRelease);
            }
        }
    }
}
