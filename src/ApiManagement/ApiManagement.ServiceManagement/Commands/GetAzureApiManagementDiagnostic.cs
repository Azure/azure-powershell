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
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementDiagnostic", DefaultParameterSetName = ContextParameterSet)]
    [OutputType(typeof(PsApiManagementDiagnostic), ParameterSetName = new[] { ContextParameterSet, ResourceIdParameterSet })]
    public class GetAzureApiManagementDiagnostic : AzureApiManagementCmdletBase
    {
        #region ParameterSetNames
        private const string ContextParameterSet = "ContextParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        #endregion

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm Resource Identifier of a Diagnostic or Api Diagnostic." +
            " If specified will try to find diagnostic by the identifier. This parameter is required.")]
        public String ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ContextParameterSet,
            Mandatory = false,
            HelpMessage = "Identifier of existing diagnostic." +
                " If not specified, and ApiId was provided, it returns all " +
                "api diagnostics are returned. If ApiId is not provided, it returns all global diagnostics." +
                " This parameters is optional.")]
        [PSArgumentCompleter(Constants.ApplicationInsightsDiagnostics, Constants.AzureMonitorDiagnostic)]
        public String DiagnosticId { get; set; }

        [Parameter(
            ParameterSetName = ContextParameterSet,
            Mandatory = false,
            HelpMessage = "Identifier of the API. " +
            "If specified, it will find out the diagnostic associated with an API." +
            "This parameters is optional.")]
        public String ApiId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string diagnosticId;
            string apiId;

            if (ParameterSetName.Equals(ContextParameterSet))
            {
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                diagnosticId = Utils.GetDiagnosticId(DiagnosticId);
                apiId = ApiId;
            }
            else
            {
                var diagnostic = new PsApiManagementDiagnostic(ResourceId);
                resourceGroupName = diagnostic.ResourceGroupName;
                serviceName = diagnostic.ServiceName;
                diagnosticId = diagnostic.DiagnosticId;
                apiId = diagnostic.ApiId;
            }

            if (string.IsNullOrEmpty(diagnosticId) && string.IsNullOrEmpty(apiId))
            {
                WriteObject(Client.DiagnosticListTenantLevel(resourceGroupName, serviceName), true);
            }
            else if (string.IsNullOrEmpty(diagnosticId))
            {
                // get all api diagnostics
                WriteObject(Client.DiagnosticListApiLevel(resourceGroupName, serviceName, apiId), true);
            }
            else if (string.IsNullOrEmpty(apiId))
            {
                // get the global diagnostic
                WriteObject(Client.DiagnosticGetTenantLevel(resourceGroupName, serviceName, diagnosticId));
            }
            else
            {
                WriteObject(Client.DiagnosticGetApiLevel(resourceGroupName, serviceName, apiId, diagnosticId));
            }
        }
    }
}
