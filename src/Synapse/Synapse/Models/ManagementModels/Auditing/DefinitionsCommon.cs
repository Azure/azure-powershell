// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse.Models.Auditing
{
    public static class DefinitionsCommon
    {
        internal const string WhatIfParameterName = "WhatIf";
        internal const string ConfirmParameterName = "Confirm";
        internal const string WorkspaceAuditCmdletsSuffix = "SqlAuditSetting";
        internal const string SqlPoolAuditCmdletsSuffix = "SqlPoolAuditSetting";
        internal const string BlobStorageParameterSetName = "DefaultParameterSet";
        internal const string BlobStorageByParentResourceParameterSetName = "BlobStorageByParentResourceSet";
        internal const string EventHubParameterSetName = "EventHubSet";
        internal const string EventHubByParentResourceParameterSetName = "EventHubByParentResourceSet";
        internal const string LogAnalyticsParameterSetName = "LogAnalyticsSet";
        internal const string LogAnalyticsByParentResourceParameterSetName = "LogAnalyticsByParentResourceSet";
        internal const string StorageAccountSubscriptionIdParameterSetName = "StorageAccountSubscriptionIdSet";
        internal const string StorageAccountSubscriptionIdByParentResourceParameterSetName = "StorageAccountSubscriptionIdByParentResourceSet";
        internal const string SqlPoolParameterSetName = "SqlPoolParameterSet";
        internal const string SqlPoolParentObjectParameterSetName = "SqlPoolParentObjectParameterSet";
        internal const string SqlPoolObjectParameterSetName = "SqlPoolObjectParameterSet";
        internal const string SqlPoolResourceIdParameterSetName = "SqlPoolResourceIdParameterSet";
        internal const string WorkspaceParameterSetName = "WorkspaceParameterSet";
        internal const string WorkspaceObjectParameterSetName = "WorkspaceObjectParameterSet";
        internal const string WorkspaceResourceIdParameterSetName = "WorkspaceResourceIdParameterSetName";
        internal const string SQLSecurityAuditCategory = "SQLSecurityAuditEvents";
        internal const string DiagnosticSettingsNamePrefixSQLSecurityAuditEvents = SQLSecurityAuditCategory + "_3d229c42-c7e7-4c97-9a99-ec0d0d8b86c1_";
        internal const string BlobStorageParameterName = "BlobStorage";
        internal static readonly string AuditLogsDestinationWasNotSpecifiedWarning = $"Audit logs destination was not specified, {BlobStorageParameterName} is the default destination.";
        internal static readonly Exception SetAuditingSettingsException = new Exception("Setting Auditing Settings failed.");
        internal static readonly Exception UpdateDiagnosticSettingsException = new Exception("Failed to update Diagnostic Settings.");
        internal static readonly Exception CreateDiagnosticSettingsException = new Exception("Failed to create Diagnostic Settings.");
        internal static readonly Exception RemoveDiagnosticSettingsException = new Exception("Failed to remove Diagnostic Settings.");
        internal static readonly Exception EventHubAuthorizationRuleResourceIdParameterException =
            new PSArgumentException("Event hub authorization rule resource id is not provided", "EventHubAuthorizationRuleResourceId");
        internal static readonly Exception WorkspaceResourceIdParameterException =
            new PSArgumentException("Workspace resource id is not provided", "WorkspaceResourceId");
        internal static readonly Exception StorageAccountNameParameterException =
            new PSArgumentException("Storage acount name is not provided", "StorageAccountName");
    }
}
