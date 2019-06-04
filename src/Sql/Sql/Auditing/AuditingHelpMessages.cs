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

namespace Microsoft.Azure.Commands.Sql.Auditing
{
    public static class AuditingHelpMessages
    {
        public const string ResourceGroupNameHelpMessage = "The name of the resource group.";

        public const string ServerNameHelpMessage = "SQL server name.";

        public const string DatabaseNameHelpMessage = "SQL Database name.";

        public const string DatabaseInputObjectHelpMessage = "The database object to manage its audit policy.";

        public const string ServerInputObjectHelpMessage = "The server object to manage its audit policy.";

        public const string StateHelpMessage = "The state of the policy.";

        public const string AuditStorageAccountNameHelpMessage = "The name of the storage account.";

        public const string AuditStorageAccountSubscriptionIdHelpMessage = "The storage account subscription id";

        public const string StorageKeyTypeHelpMessage = "Specifies which of the storage access keys to use.";

        public const string RetentionInDaysHelpMessage = "The number of retention days for the audit logs.";

        public const string PredicateExpressionHelpMessage = "The T-SQL predicate (WHERE clause) used to filter audit logs.";

        public const string EventHubNameHelpMessage = "The name of the event hub. If none is specified when providing EventHubAuthorizationRuleResourceId, the default event hub will be selected.";

        public const string EventHubAuthorizationRuleIdHelpMessage = "The resource Id for the event hub authorization rule";

        public const string WorkspaceIdHelpMessage = "The workspace ID (resource ID of a Log Analytics workspace) for a Log Analytics workspace to which you would like to send Audit Logs. Example: /subscriptions/4b9e8510-67ab-4e9a-95a9-e2f1e570ea9c/resourceGroups/insights-integration/providers/Microsoft.OperationalInsights/workspaces/viruela2";

        public const string PassThruHelpMessage = "Specifies whether to output the auditing policy at end of cmdlet execution";

        public const string BlobStorageHelpMessage = "Specifies that audit logs destination is blob storage";

        public const string EventHubHelpMessage = "Specifies that audit logs destination is event hub";

        public const string LogAnalyticsHelpMessage = "Specifies that audit logs destination is log analytics";

        public const string AsJobHelpMessage = "Run cmdlet in the background";

        public const string AuditActionHelpMessage =
@"The set of audit actions.  
The supported actions to audit are:  
SELECT  
UPDATE  
INSERT  
DELETE  
EXECUTE  
RECEIVE  
REFERENCES  
The general form for defining an action to be audited is:
[action] ON [object] BY [principal]
Note that [object] in the above format can refer to an object like a table, view, or stored procedure, or an entire database or schema. For the latter cases, the forms DATABASE::[dbname] and SCHEMA::[schemaname] are used, respectively.
For example:  
SELECT on dbo.myTable by public  
SELECT on DATABASE::myDatabase by public  
SELECT on SCHEMA::mySchema by public  
For more information, see https://docs.microsoft.com/en-us/sql/relational-databases/security/auditing/sql-server-audit-action-groups-and-actions#database-level-audit-actions.";

        public const string AuditActionGroupsHelpMessage =
@"The recommended set of action groups to use is the following combination - this will audit all the queries and stored procedures executed against the database, as well as successful and failed logins:  
  
“BATCH_COMPLETED_GROUP“,  
“SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP“,  
“FAILED_DATABASE_AUTHENTICATION_GROUP“  
This above combination is also the set that is configured by default. These groups cover all SQL statements and stored procedures executed against the database, and should not be used in combination with other groups as this will result in duplicate audit logs.
For more information, see https://docs.microsoft.com/en-us/sql/relational-databases/security/auditing/sql-server-audit-action-groups-and-actions#database-level-audit-action-groups.";

    }
}