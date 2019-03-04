using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing
{
    public static class DefinitionsCommon
    {
        internal const string WhatIfParameterName = "WhatIf";
        internal const string ConfirmParameterName = "Confirm";
        internal const string StorageAccountNameParameterName = "StorageAccountName";
        internal const string ServerAuditingCmdletsSuffix = "SqlServerAuditing";
        internal const string DatabaseAuditingCmdletsSuffix = "SqlDatabaseAuditing";
        internal const string BlobStorageParameterSetName = "DefaultParameterSet";
        internal const string BlobStorageByParentResourceParameterSetName = "BlobStorageByParentResourceSet";
        internal const string EventHubParameterSetName = "EventHubSet";
        internal const string EventHubByParentResourceParameterSetName = "EventHubByParentResourceSet";
        internal const string LogAnalyticsParameterSetName = "LogAnalyticsSet";
        internal const string LogAnalyticsByParentResourceParameterSetName = "LogAnalyticsByParentResourceSet";
        internal const string StorageAccountSubscriptionIdParameterSetName = "StorageAccountSubscriptionIdSet";
        internal const string StorageAccountSubscriptionIdByParentResourceParameterSetName = "StorageAccountSubscriptionIdByParentResourceSet";
        internal const string DiagnosticSettingsNamePrefix = "SQLSecurityAuditEvents_3d229c42-c7e7-4c97-9a99-ec0d0d8b86c1_";
        internal const string SQLSecurityAuditCategory = "SQLSecurityAuditEvents";
        internal const string BlobStorageParameterName = "BlobStorage";
        internal static readonly string AuditLogsDestinationWasNotSpecifiedWarning = $"Audit logs destination was not specified, {BlobStorageParameterName} is the default destination.";
        internal static readonly string MultipleDiagnosticsErrorMessage = $"Operation is not supported when multiple Diagnostic Settings enable {SQLSecurityAuditCategory}";
        internal static readonly Exception SetAuditingSettingsException = new Exception("Setting Auditing Settings failed.");
        internal static readonly Exception UpdateDiagnosticSettingsException = new Exception("Updating Diagnostic Settings failed.");
        internal static readonly Exception CreateDiagnosticSettingsException = new Exception("Creating Diagnostic Settings failed.");
        internal static readonly Exception EventHubAuthorizationRuleResourceIdParameterException =
            new PSArgumentException("Event hub authorization rule resource id is not provided", "EventHubAuthorizationRuleResourceId");
        internal static readonly Exception WorkspaceResourceIdParameterException =
            new PSArgumentException("Workspace resource id is not provided", "WorkspaceResourceId");

    }
}
