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
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementDiagnostic", SupportsShouldProcess = true, DefaultParameterSetName = ByResourceIdParameterSet)]
    [OutputType(typeof(bool), ParameterSetName = new[] { ExpandParameterSetName, ByInputObjectParameterSet, ByResourceIdParameterSet })]
    public class RemoveAzureApiManagementDiagnostic : AzureApiManagementCmdletBase
    {
        #region ParameterSets
        const string ExpandParameterSetName = "ExpandParameterSetName";
        const string ByInputObjectParameterSet = "ByInputObjectParameterSet";
        const string ByResourceIdParameterSet = "ByResourceIdParameterSet";
        #endregion

        [Parameter(
            ParameterSetName = ExpandParameterSetName,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ExpandParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of the API whose Diagnostic needs to be removed." +
            " If not specified, Diagnostic at the Tenant level will be removed. " +
            "This parameter is optional.")]        
        public String ApiId { get; set; }

        [Parameter(
            ParameterSetName = ExpandParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of diagnostics entity to remove. " +
            " This parameters is required.")]
        [PSArgumentCompleter(Constants.ApplicationInsightsDiagnostics, Constants.AzureMonitorDiagnostic)]
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
            HelpMessage = "Arm ResourceId of Diagnostic. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ResourceId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified will write true in case operation succeeds. This parameter is optional.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string diagnosticId;
            string apiId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                resourceGroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
                diagnosticId = InputObject.DiagnosticId;
                apiId = InputObject.ApiId;
            }
            else if (ParameterSetName.Equals(ByResourceIdParameterSet))
            {
                var diagnostic = new PsApiManagementDiagnostic(ResourceId);
                resourceGroupName = diagnostic.ResourceGroupName;
                serviceName = diagnostic.ServiceName;
                diagnosticId = diagnostic.DiagnosticId;
                apiId = diagnostic.ApiId;
            }
            else
            {
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                diagnosticId = Utils.GetDiagnosticId(DiagnosticId);
                apiId = ApiId;
            }

            // build description for cmdlet
            string actionDescription;
            string actionWarning;
            if (string.IsNullOrEmpty(apiId))
            {
                actionDescription = string.Format(CultureInfo.CurrentCulture, Resources.DiagnosticRemoveDescription, DiagnosticId);
                actionWarning = string.Format(CultureInfo.CurrentCulture, Resources.DiagnosticRemoveWarning, DiagnosticId);
            }
            else
            {
                actionDescription = string.Format(CultureInfo.CurrentCulture, Resources.ApiDiagnosticRemoveDescription, DiagnosticId, ApiId);
                actionWarning = string.Format(CultureInfo.CurrentCulture, Resources.ApiDiagnosticRemoveWarning, DiagnosticId, ApiId);
            }

            // Do nothing if force is not specified and user cancelled the operation
            if (!ShouldProcess(
                    actionDescription,
                    actionWarning,
                    Resources.ShouldProcessCaption))
            {
                return;
            }

            if (string.IsNullOrEmpty(apiId))
            {
                Client.DiagnosticRemoveTenantLevel(resourceGroupName, serviceName, diagnosticId);
            }
            else
            {
                Client.DiagnosticRemoveApiLevel(resourceGroupName, serviceName, apiId, diagnosticId);
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
