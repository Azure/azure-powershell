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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Models;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementDiagnostic", SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementDiagnostic))]
    public class NewAzureApiManagementDiagnostic : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of the logger to push diagnostics to. This parameter is required.")]
        public String LoggerId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of the diagnostics entity. This parameter is optional.")]
        [PSArgumentCompleter(Constants.ApplicationInsightsDiagnostics, Constants.AzureMonitorDiagnostic)]
        public String DiagnosticId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Specifies for what type of messages sampling settings should not apply. This parameter is optional.")]
        [PSArgumentCompleter(Constants.AllErrors)]
        public String AlwaysLog { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of existing API. If specified will set API-scope policy. This parameters is optional.")]
        public String ApiId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Sampling Setting of the Diagnostic. This parameter is optional.")]
        public PsApiManagementSamplingSetting SamplingSetting { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Diagnostic setting for incoming/outgoing Http Messsages to the Gateway. This parameter is optional.")]
        public PsApiManagementPipelineDiagnosticSetting FrontEndSetting { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Diagnostic setting for incoming/outgoing Http Messsages to the Backend. This parameter is optional.")]
        public PsApiManagementPipelineDiagnosticSetting BackendSetting { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            var diagnosticId =  Utils.GetDiagnosticId(DiagnosticId) ?? "azuremonitor";
            PsApiManagementDiagnostic diagnostic;
            
            if (ShouldProcess(diagnosticId, Resources.CreateDiagnostics))
            {
                diagnostic = Client.DiagnosticCreate(
                    Context,
                    diagnosticId,
                    ApiId,
                    LoggerId,
                    AlwaysLog,
                    SamplingSetting,
                    FrontEndSetting,
                    BackendSetting);
                
                WriteObject(diagnostic);
            }
        }
    }
}
