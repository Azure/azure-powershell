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

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementHttpMessageDiagnostic")]
    [OutputType(typeof(PsApiManagementHttpMessageDiagnostic))]
    public class NewAzureApiManagementHttpMessageDiagnostic : AzureApiManagementCmdletBase
    {
        [Parameter(
           ValueFromPipelineByPropertyName = false,
           Mandatory = false,
           HelpMessage = "The array of headers to log. This parameter is optional.")]        
        public string[] HeadersToLog { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Number of request body bytes to log. This parameter is optional.")]
        public int? BodyBytesToLog { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            PsApiManagementBodyDiagnosticSetting psBodyBytes = null;
            if (BodyBytesToLog != null)
            {
                psBodyBytes = new PsApiManagementBodyDiagnosticSetting();
                psBodyBytes.BodyBytesToLog = BodyBytesToLog;

            }
            WriteObject(
                new PsApiManagementHttpMessageDiagnostic
                {
                    HeadersToLog = HeadersToLog,
                    Body = psBodyBytes
                });
        }
    }
}
