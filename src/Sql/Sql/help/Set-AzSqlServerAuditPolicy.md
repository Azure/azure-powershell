---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
ms.assetid: 14814BF3-51AF-4E51-A8A6-661825BD88D1
online version: https://docs.microsoft.com/en-us/powershell/module/az.sql/set-azsqlserverauditpolicy
schema: 2.0.0
---

# Set-AzSqlServerAuditPolicy

## SYNOPSIS
Changes the auditing settings of an Azure SQL server.

## SYNTAX

### AuditPolicyObjectParameterSet (Default)
```
Set-AzSqlServerAuditPolicy -ServerAuditPolicyObject <ServerAuditPolicyModel> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ServerParameterSet
```
Set-AzSqlServerAuditPolicy [-AuditActionGroup <AuditActionGroups[]>] [-PredicateExpression <String>]
 [-BlobStorageAuditState <String>] [-StorageAccountName <String>] [-StorageAccountSubscriptionId <Guid>]
 [-StorageKeyType <String>] [-RetentionInDays <UInt32>] [-EventHubAuditState <String>] [-EventHubName <String>]
 [-EventHubAuthorizationRuleResourceId <String>] [-LogAnalyticsAuditState <String>]
 [-WorkspaceResourceId <String>] [-PassThru] [-ResourceGroupName] <String> [-ServerName] <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ServerObjectParameterSet
```
Set-AzSqlServerAuditPolicy [-AuditActionGroup <AuditActionGroups[]>] [-PredicateExpression <String>]
 [-BlobStorageAuditState <String>] [-StorageAccountName <String>] [-StorageAccountSubscriptionId <Guid>]
 [-StorageKeyType <String>] [-RetentionInDays <UInt32>] [-EventHubAuditState <String>] [-EventHubName <String>]
 [-EventHubAuthorizationRuleResourceId <String>] [-LogAnalyticsAuditState <String>]
 [-WorkspaceResourceId <String>] [-PassThru] -ServerObject <AzureSqlServerModel> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzSqlServerAuditPolicy** cmdlet changes the auditing settings of an Azure SQL server.
To use the cmdlet, use the *ResourceGroupName* and *ServerName* parameters to identify the server.
When audit logs destination is blob storage, specify the *StorageAccountName* parameter to determine the storage account for the audit logs and the *StorageKeyType* parameter to define the storage keys. You can also define retention for the audit logs by setting the value of the *RetentionInDays* parameter to define the period for the audit logs.

## EXAMPLES

### Example 1: Enable the blob storage auditing policy of an Azure SQL server
```
PS C:\>Set-AzSqlServerAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -BlobStorageAuditState Enabled -StorageAccountName "Storage22"
```

### Example 2: Disable the blob storage auditing policy of an Azure SQL server
```
PS C:\>Set-AzSqlServerAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -BlobStorageAuditState Disabled
```

### Example 3: Enable the blob storage auditing policy of an Azure SQL server using a storage account from a different subscription
```
PS C:\>Set-AzSqlServerAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -BlobStorageAuditState Enabled -StorageAccountName "Storage22" -StorageAccountSubscriptionId "7fe3301d-31d3-4668-af5e-211a890ba6e3"
```

### Example 4.1: Enable the blob storage auditing policy of an Azure SQL server with advanced filtering using a T-SQL predicate
```
PS C:\>Set-AzSqlServerAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -BlobStorageAuditState Enabled -StorageAccountName "Storage22" -PredicateExpression "statement <> 'select 1'"
```

### Example 4.2: Remove the advanced filtering setting from the auditing policy of an Azure SQL server
```
PS C:\>Set-AzSqlServerAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -PredicateExpression ""
```

### Example 5: Enable the event hub auditing policy of an Azure SQL server
```
PS C:\>Set-AzSqlServerAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -EventHubAuditState Enabled -EventHubName "EventHubName" -EventHubAuthorizationRuleResourceId "EventHubAuthorizationRuleResourceId"
```

### Example 6: Disable the event hub auditing policy of an Azure SQL server
```
PS C:\>Set-AzSqlServerAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -EventHubAuditState Disabled
```

### Example 7: Enable the log analytics auditing policy of an Azure SQL server
```
PS C:\>Set-AzSqlServerAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -LogAnalyticsAuditState Enabled -WorkspaceResourceId "/subscriptions/4b9e8510-67ab-4e9a-95a9-e2f1e570ea9c/resourceGroups/insights-integration/providers/Microsoft.OperationalInsights/workspaces/viruela2"
```

### Example 8: Disable the log analytics auditing policy of an Azure SQL server
```
PS C:\>Set-AzSqlServerAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -LogAnalyticsAuditState Disabled
```

### Example 9: Disable, through pipeline, the log analytics auditing policy of an Azure SQL server
```
PS C:\>Get-AzSqlServer -ResourceGroupName "ResourceGroup01" -ServerName "Server01" | Set-AzSqlServerAuditPolicy -LogAnalyticsAuditState Disabled
```

### Example 10: Disable sending audit records of an Azure SQL server to blob storage, and enable sending them to log analytics.
```
PS C:\>Set-AzSqlServerAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -LogAnalyticsAuditState Enabled -WorkspaceResourceId "/subscriptions/4b9e8510-67ab-4e9a-95a9-e2f1e570ea9c/resourceGroups/insights-integration/providers/Microsoft.OperationalInsights/workspaces/viruela2" -BlobStorageAuditState Disabled
```

### Example 11: Enable sending audit records of an Azure SQL server to blob storage, event hub and log analytics.
```
PS C:\>Set-AzSqlServerAuditPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -BlobStorageAuditState Enabled -StorageAccountName "Storage22" -EventHubAuditState Enabled -EventHubName "EventHubName" -EventHubAuthorizationRuleResourceId "EventHubAuthorizationRuleResourceId" -LogAnalyticsAuditState Enabled  -WorkspaceResourceId "/subscriptions/4b9e8510-67ab-4e9a-95a9-e2f1e570ea9c/resourceGroups/insights-integration/providers/Microsoft.OperationalInsights/workspaces/viruela2"
```

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -AuditActionGroup
The recommended set of action groups to use is the following combination - this will audit all the queries and stored procedures executed against the database, as well as successful and failed logins:  
  
"BATCH_COMPLETED_GROUP",  
"SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP",  
"FAILED_DATABASE_AUTHENTICATION_GROUP"  
This above combination is also the set that is configured by default. These groups cover all SQL statements and stored procedures executed against the database, and should not be used in combination with other groups as this will result in duplicate audit logs.
For more information, see https://docs.microsoft.com/en-us/sql/relational-databases/security/auditing/sql-server-audit-action-groups-and-actions#database-level-audit-action-groups.

```yaml
Type: Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups[]
Parameter Sets: ServerParameterSet, ServerObjectParameterSet
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
Parameter Sets: ServerParameterSet, ServerObjectParameterSet
Aliases:
Accepted values: Enabled, Disabled

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Parameter Sets: ServerParameterSet, ServerObjectParameterSet
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
Parameter Sets: ServerParameterSet, ServerObjectParameterSet
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
Parameter Sets: ServerParameterSet, ServerObjectParameterSet
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
Parameter Sets: ServerParameterSet, ServerObjectParameterSet
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
Parameter Sets: ServerParameterSet, ServerObjectParameterSet
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
Parameter Sets: ServerParameterSet
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
Parameter Sets: ServerParameterSet, ServerObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerAuditPolicyObject
An object representing the audit policy.

```yaml
Type: Microsoft.Azure.Commands.Sql.Auditing.Model.ServerAuditPolicyModel
Parameter Sets: AuditPolicyObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServerName
SQL server name.

```yaml
Type: System.String
Parameter Sets: ServerParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerObject
The server object to manage its audit policy.

```yaml
Type: Microsoft.Azure.Commands.Sql.Server.Model.AzureSqlServerModel
Parameter Sets: ServerObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StorageAccountName
The name of the storage account.

```yaml
Type: System.String
Parameter Sets: ServerParameterSet, ServerObjectParameterSet
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
Parameter Sets: ServerParameterSet, ServerObjectParameterSet
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
Parameter Sets: ServerParameterSet, ServerObjectParameterSet
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
Parameter Sets: ServerParameterSet, ServerObjectParameterSet
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

### Microsoft.Azure.Commands.Sql.Server.Model.AzureSqlServerModel

### Microsoft.Azure.Commands.Sql.Auditing.Model.AuditActionGroups[]

### System.Guid

### System.Nullable`1[[System.UInt32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### Microsoft.Azure.Commands.Sql.Auditing.Model.ServerAuditPolicyModel

## OUTPUTS

### Microsoft.Azure.Commands.Sql.Auditing.Model.ServerAuditPolicyModel

## NOTES

## RELATED LINKS
