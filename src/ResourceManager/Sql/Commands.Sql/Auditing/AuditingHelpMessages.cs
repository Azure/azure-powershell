namespace Microsoft.Azure.Commands.Sql.Auditing
{
    public static class AuditingHelpMessages
    {
        public const string StateHelpMessage = "The state of the policy.";

        public const string AuditStorageAccountNameHelpMessage =
@"The name of the storage account. Wildcard characters are not permitted.  
This parameter is not required.  
If you do not specify this parameter, the cmdlet uses the storage account that was defined previously as part of the auditing policy.  
If this is the first time an auditing policy is defined and you do not specify this parameter, the cmdlet fails.";

        public const string StorageKeyTypeHelpMessage = "Specifies which of the storage access keys to use.";

        public const string RetentionInDaysHelpMessage = "The number of retention days for the audit logs.";

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
