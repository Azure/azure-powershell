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

    [Cmdlet("Disable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementApiDiagnostic")]
    [OutputType(typeof(PsApiManagementLogger))]
    public class RemoveAzureApiManagementApiDiagnostic : AzureApiManagementCmdletBase
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
            HelpMessage = "Identifier of existing Api. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ApiId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of the diagnostic. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String DiagnosticId { get; set; }

        [Parameter(
           ValueFromPipelineByPropertyName = true,
           Mandatory = false,
           HelpMessage = "If specified then instance of " +
                         "Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementLogger type " +
                         " representing the logger will be written to output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            Client.DisableDiagnosticApi(Context, ApiId, DiagnosticId);

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
