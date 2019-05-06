---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
ms.assetid: F7EF35E3-BC53-43D9-A71E-0B4316260A08
online version: https://docs.microsoft.com/en-us/powershell/module/az.sql/set-azsqldatabaseauditpolicy
schema: 2.0.0
---

# Set-AzSqlDatabaseAuditPolicy

## SYNOPSIS
Changes the auditing settings for an Azure SQL database.

## SYNTAX

### AuditPolicyObjectParameterSet (Default)
```
Set-AzSqlDatabaseAuditPolicy -DatabaseAuditPolicyObject <DatabaseAuditPolicyModel> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DatabaseParameterSet
```
Set-AzSqlDatabaseAuditPolicy [-AuditActionGroup <AuditActionGroups[]>] [-AuditAction <String[]>]
 [-PredicateExpression <String>] [-BlobStorageAuditState <String>] [-StorageAccountName <String>]
 [-StorageAccountSubscriptionId <Guid>] [-StorageKeyType <String>] [-RetentionInDays <UInt32>]
 [-EventHubAuditState <String>] [-EventHubName <String>] [-EventHubAuthorizationRuleResourceId <String>]
 [-LogAnalyticsAuditState <String>] [-WorkspaceResourceId <String>] [-PassThru] [-ResourceGroupName] <String>
 [-ServerName] <String> [-DatabaseName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DatabaseObjectParameterSet
```
Set-AzSqlDatabaseAuditPolicy [-AuditActionGroup <AuditActionGroups[]>] [-AuditAction <String[]>]
 [-PredicateExpression <String>] [-BlobStorageAuditState <String>] [-StorageAccountName <String>]
 [-StorageAccountSubscriptionId <Guid>] [-StorageKeyType <String>] [-RetentionInDays <UInt32>]
 [-EventHubAuditState <String>] [-EventHubName <String>] [-EventHubAuthorizationRuleResourceId <String>]
 [-LogAnalyticsAuditState <String>] [-WorkspaceResourceId <String>] [-PassThru]
 -DatabaseObject <AzureSqlDatabaseModel> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzSqlDatabaseAuditPolicy** cmdlet changes the auditing settings of an Azure SQL database.
To use the cmdlet, use the *ResourceGroupName*, *ServerName*, and *DatabaseName* parameters to identify the database.
When audit logs destination is blob storage, specify the *StorageAccountName* parameter to determine the storage account for the audit logs and the *StorageKeyType* parameter to define the storage keys. You can also define retention for the audit logs by setting the value of the *RetentionInDays* parameter to define the period for the audit logs.

## EXAMPLES

### Example 1: Enable the blob storage auditing policy of an Azure SQL database
```
PS C:\>Set-AzSqlDatabaseAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -BlobStorageAuditState Enabled  -StorageAccountName "Storage22"
```

### Example 2: Disable the blob storage auditing policy of an Azure SQL database
```
PS C:\>Set-AzSqlDatabaseAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -BlobStorageAuditState Disabled 
```

### Example 3: Enable the blob storage auditing policy of an Azure SQL database using a storage account from a different subscription
```
PS C:\>Set-AzSqlDatabaseAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -BlobStorageAuditState Enabled -StorageAccountName "Storage22" -StorageAccountSubscriptionId "7fe3301d-31d3-4668-af5e-211a890ba6e3"
```

### Example 4: Enable the blob storage auditing policy of an Azure SQL database with advanced filtering using a T-SQL predicate
```
PS C:\>Set-AzSqlDatabaseAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -PredicateExpression "statement <> 'select 1'" -BlobStorageAuditState Enabled -StorageAccountName "Storage22"
```

### Example 5: Remove the advanced filtering setting from the blob storage auditing policy of an Azure SQL database
```
PS C:\>Set-AzSqlDatabaseAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -PredicateExpression "" -BlobStorageAuditState Enabled -StorageAccountName "Storage22"
```

### Example 6: Enable the event hub auditing policy of an Azure SQL database
```
PS C:\>Set-AzSqlDatabaseAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -EventHubAuditState Enabled -EventHubName "EventHubName" -EventHubAuthorizationRuleResourceId "EventHubAuthorizationRuleResourceId"
```

### Example 7: Disable the event hub auditing policy of an Azure SQL database
```
PS C:\>Set-AzSqlDatabaseAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -EventHubAuditState Disabled
```

### Example 8: Enable the log analytics auditing policy of an Azure SQL database
```
PS C:\>Set-AzSqlDatabaseAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -LogAnalyticsAuditState Enabled -WorkspaceResourceId "/subscriptions/4b9e8510-67ab-4e9a-95a9-e2f1e570ea9c/resourceGroups/insights-integration/providers/Microsoft.OperationalInsights/workspaces/viruela2"
```

### Example 9: Disable the log analytics auditing policy of an Azure SQL database
```
PS C:\>Set-AzSqlDatabaseAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -LogAnalyticsAuditState Disabled
```

### Example 10: Disable, through pipeline, the log analytics auditing policy of an Azure SQL database
```
PS C:\>Get-AzSqlDatabase -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" | Set-AzSqlDatabaseAuditPolicy -LogAnalyticsAuditState Disabled
```

### Example 11: Disable sending audit records of an Azure SQL database to blob storage, and enable sending them to log analytics.
```
PS C:\>Set-AzSqlDatabaseAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -LogAnalyticsAuditState Enabled  -WorkspaceResourceId "/subscriptions/4b9e8510-67ab-4e9a-95a9-e2f1e570ea9c/resourceGroups/insights-integration/providers/Microsoft.OperationalInsights/workspaces/viruela2" -BlobStorageAuditState Disabled
```

### Example 12: Enable sending audit records of an Azure SQL database to blob storage, event hub and log analytics.
```
PS C:\>Set-AzSqlDatabaseAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -BlobStorageAuditState Enabled -StorageAccountName "Storage22" -EventHubAuditState Enabled -EventHubName "EventHubName" -EventHubAuthorizationRuleResourceId "EventHubAuthorizationRuleResourceId" -LogAnalyticsAuditState Enabled  -WorkspaceResourceId "/subscriptions/4b9e8510-67ab-4e9a-95a9-e2f1e570ea9c/resourceGroups/insights-integration/providers/Microsoft.OperationalInsights/workspaces/viruela2"
```

## PARAMETERS

### -AuditAction
The set of audit actions.  
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
For more information, see https://docs.microsoft.com/en-us/sql/relational-databases/security/auditing/sql-server-audit-action-groups-and-actions#database-level-audit-actions.

```yaml
Type: System.String[]
Parameter Sets: DatabaseParameterSet, DatabaseObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AuditActionGroup
The recommended set of action groups to use is the following combination - this will audit all the queries and stored procedures executed against the database, as well as successful and failed logins:  
  
"BATCH_COMPLETED_GROUP",  
"SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP",  
"FAILED_DATABASE_AUTHENTICATION_GROUP"  
This above combination is also the set that is configured by default. These groups cover all SQL statements and stored procedures executed against the database, and should not be used in combination with other groups as this will result in duplicate audit logs.
For more information, see https://docs.microsoft.com/en-us/sql/relational-databases/security/auditing/sql-server-audit-action-groups-and-actions#database-level-audit-action-groups.

```yaml
Type: Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups[]
Parameter Sets: DatabaseParameterSet, DatabaseObjectParameterSet
Aliases:
Accepted values: BATCH_STARTED_GROUP, BATCH_COMPLETED_GROUP, APPLICATION_ROLE_CHANGE_PASSWORD_GROUP, BACKUP_RESTORE_GROUP, DATABASE_LOGOUT_GROUP, DATABASE_OBJECT_CHANGE_GROUP, DATABASE_OBJECT_OWNERSHIP_CHANGE_GROUP, DATABASE_OBJECT_PERMISSION_CHANGE_GROUP, DATABASE_OPERATION_GROUP, DATABASE_PERMISSION_CHANGE_GROUP, DATABASE_PRINCIPAL_CHANGE_GROUP, DATABASE_PRINCIPAL_IMPERSONATION_GROUP, DATABASE_ROLE_MEMBER_CHANGE_GROUP, FAILED_DATABASE_AUTHENTICATION_GROUP, SCHEMA_OBJECT_ACCESS_GROUP, SCHEMA_OBJECT_CHANGE_GROUP, SCHEMA_OBJECT_OWNERSHIP_CHANGE_GROUP, SCHEMA_OBJECT_PERMISSION_CHANGE_GROUP, SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP, USER_CHANGE_PASSWORD_GROUP

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -BlobStorageAuditState
Indicates whether blob storage is a destination for audit records.

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet, DatabaseObjectParameterSet
Aliases:
Accepted values: Enabled, Disabled

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DatabaseAuditPolicyObject
An object representing the audit policy.

```yaml
Type: Microsoft.Azure.Commands.Sql.Auditing.Model.DatabaseAuditPolicyModel
Parameter Sets: AuditPolicyObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DatabaseName
SQL Database name.

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DatabaseObject
The database object to manage its audit policy.

```yaml
Type: Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel
Parameter Sets: DatabaseObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventHubAuditState
Indicates whether event hub is a destination for audit records.

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet, DatabaseObjectParameterSet
Aliases:
Accepted values: Enabled, Disabled

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EventHubAuthorizationRuleResourceId
The resource Id for the event hub authorization rule

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet, DatabaseObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EventHubName
The name of the event hub. If none is specified when providing EventHubAuthorizationRuleResourceId, the default event hub will be selected.

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet, DatabaseObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -LogAnalyticsAuditState
Indicates whether log analytics is a destination for audit records.

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet, DatabaseObjectParameterSet
Aliases:
Accepted values: Enabled, Disabled

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Specifies whether to output the auditing policy at end of cmdlet execution

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PredicateExpression
The T-SQL predicate (WHERE clause) used to filter audit logs.

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet, DatabaseObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RetentionInDays
The number of retention days for the audit logs.

```yaml
Type: System.Nullable`1[System.UInt32]
Parameter Sets: DatabaseParameterSet, DatabaseObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerName
SQL server name.

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageAccountName
The name of the storage account.

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet, DatabaseObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageAccountSubscriptionId
The storage account subscription id

```yaml
Type: System.Guid
Parameter Sets: DatabaseParameterSet, DatabaseObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageKeyType
Specifies which of the storage access keys to use.

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet, DatabaseObjectParameterSet
Aliases:
Accepted values: Primary, Secondary

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WorkspaceResourceId
The workspace ID (resource ID of a Log Analytics workspace) for a Log Analytics workspace to which you would like to send Audit Logs. Example: /subscriptions/4b9e8510-67ab-4e9a-95a9-e2f1e570ea9c/resourceGroups/insights-integration/providers/Microsoft.OperationalInsights/workspaces/viruela2

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet, DatabaseObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel

### Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups[]

### System.String[]

### System.Guid

### System.Nullable`1[[System.UInt32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### Microsoft.Azure.Commands.Sql.Auditing.Model.DatabaseAuditPolicyModel

## OUTPUTS

### Microsoft.Azure.Commands.Sql.Auditing.Model.DatabaseAuditPolicyModel

## NOTES

## RELATED LINKS
