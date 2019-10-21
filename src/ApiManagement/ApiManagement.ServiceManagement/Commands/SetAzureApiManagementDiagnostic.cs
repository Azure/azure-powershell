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
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementDiagnostic", DefaultParameterSetName = ExpandedParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementDiagnostic), ParameterSetName = new[] { ExpandedParameterSet, ByInputObjectParameterSet, ByResourceIdParameterSet })]
    public class SetAzureApiManagementDiagnostic : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names

        protected const string ExpandedParameterSet = "ExpandedParameter";
        protected const string ByInputObjectParameterSet = "ByInputObject";
        protected const string ByResourceIdParameterSet = "ByResourceId";

        #endregion

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }        

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing Diagnostic. This parameter is required.")]
        [PSArgumentCompleter(Constants.ApplicationInsightsDiagnostics, Constants.AzureMonitorDiagnostic)]
        [ValidateNotNullOrEmpty]
        public String DiagnosticId { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementDiagnostic. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementDiagnostic InputObject { get; set; }

        [Parameter(
            ParameterSetName = ByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm ResourceId of Diagnostic or Api Diagnostic. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of the API whose Diagnostic need to be updated." +
            " If not provided Diagnostic at the Global level will be updated. " +
            "This parameter is optional.")]        
        public String ApiId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of the logger to push diagnostics to. This parameter is optional.")]
        public String LoggerId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Specifies for what type of messages sampling settings should not apply. This parameter is optional.")]
        [PSArgumentCompleter(Constants.AllErrors)]
        public String AlwaysLog { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Sampling Setting of the Diagnostic. This parameter is optional.")]
        public PsApiManagementSamplingSetting SamplingSetting { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Diagnostic setting for incoming/outgoing Http Messages to the Gateway. This parameter is optional.")]
        public PsApiManagementPipelineDiagnosticSetting FrontEndSetting { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Diagnostic setting for incoming/outgoing Http Messages to the Backend. This parameter is optional.")]
        public PsApiManagementPipelineDiagnosticSetting BackendSetting { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of" +
                          " Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementDiagnostic type " +
                          "representing the set Diagnostic.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourcegroupName;
            string serviceName;
            string diagnosticId;
            string apiId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                resourcegroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
                diagnosticId = InputObject.DiagnosticId;
                apiId = InputObject.ApiId;
            }
            else if (ParameterSetName.Equals(ExpandedParameterSet))
            {
                resourcegroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                diagnosticId = Utils.GetDiagnosticId(DiagnosticId);
                apiId = ApiId;
            }
            else
            {
                var psDiagnostic = new PsApiManagementDiagnostic(ResourceId);
                resourcegroupName = psDiagnostic.ResourceGroupName;
                serviceName = psDiagnostic.ServiceName;
                diagnosticId = psDiagnostic.DiagnosticId;
                apiId = psDiagnostic.ApiId;
            }

            if (ShouldProcess(diagnosticId, Resources.SetDiagnostics))
            {
                PsApiManagementDiagnostic diagnostic;
                if (string.IsNullOrEmpty(apiId))
                {
                    diagnostic = Client.DiagnosticSetTenantLevel(
                        resourcegroupName,
                        serviceName,
                        diagnosticId,
                        LoggerId,
                        AlwaysLog,
                        SamplingSetting,
                        FrontEndSetting,
                        BackendSetting,
                        InputObject);
                }
                else
                {
                    diagnostic = Client.DiagnosticSetApiLevel(
                        resourcegroupName,
                        serviceName,
                        apiId,
                        diagnosticId,
                        LoggerId,
                        AlwaysLog,
                        SamplingSetting,
                        FrontEndSetting,
                        BackendSetting,
                        InputObject);
                }

                if (PassThru.IsPresent)
                {
                    WriteObject(diagnostic);
                }
            }
        }
    }
}
