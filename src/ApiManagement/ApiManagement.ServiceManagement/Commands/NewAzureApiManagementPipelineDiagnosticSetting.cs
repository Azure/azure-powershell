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
    using System.Management.Automation;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementPipelineDiagnosticSetting")]
    [OutputType(typeof(PsApiManagementPipelineDiagnosticSetting))]
    public class NewAzureApiManagementPipelineDiagnosticSetting : AzureApiManagementCmdletBase
    {
        [Parameter(
           ValueFromPipelineByPropertyName = false,
           Mandatory = false,
           HelpMessage = "Diagnostic setting for Request. This parameter is optional.")]
        public PsApiManagementHttpMessageDiagnostic Request { get; set; }

        [Parameter(
           ValueFromPipelineByPropertyName = false,
           Mandatory = false,
           HelpMessage = "Diagnostic setting for Response. This parameter is optional.")]
        public PsApiManagementHttpMessageDiagnostic Response { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            WriteObject(
                new PsApiManagementPipelineDiagnosticSetting
                {
                    Request = Request,
                    Response = Response
                });
        }
    }
}
