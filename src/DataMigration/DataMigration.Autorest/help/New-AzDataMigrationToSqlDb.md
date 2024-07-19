---
external help file:
Module Name: Az.DataMigration
online version: https://learn.microsoft.com/powershell/module/az.datamigration/new-azdatamigrationtosqldb
schema: 2.0.0
---

# New-AzDataMigrationToSqlDb

## SYNOPSIS
Create a new database migration to a given SQL Db.
This command can migrate data from the selected source database tables to the target database tables.
If the target database have no table existing, please use [New-AzDataMigrationSqlServerSchema](https://learn.microsoft.com/powershell/module/az.datamigration/new-azdatamigrationsqlserverschema) command to migrate schema objects from source database to target databse.

## SYNTAX

```
New-AzDataMigrationToSqlDb -ResourceGroupName <String> -SqlDbInstanceName <String> -TargetDbName <String>
 [-SubscriptionId <String>] [-Kind <ResourceType>] [-MigrationService <String>] [-Scope <String>]
 [-SourceDatabaseName <String>] [-SourceSqlConnectionAuthentication <String>]
 [-SourceSqlConnectionDataSource <String>] [-SourceSqlConnectionEncryptConnection]
 [-SourceSqlConnectionPassword <SecureString>] [-SourceSqlConnectionTrustServerCertificate]
 [-SourceSqlConnectionUserName <String>] [-TableList <String[]>] [-TargetDatabaseCollation <String>]
 [-TargetSqlConnectionAuthentication <String>] [-TargetSqlConnectionDataSource <String>]
 [-TargetSqlConnectionEncryptConnection] [-TargetSqlConnectionPassword <SecureString>]
 [-TargetSqlConnectionTrustServerCertificate] [-TargetSqlConnectionUserName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new database migration to a given SQL Db.
This command can migrate data from the selected source database tables to the target database tables.
If the target database have no table existing, please use [New-AzDataMigrationSqlServerSchema](https://learn.microsoft.com/powershell/module/az.datamigration/new-azdatamigrationsqlserverschema) command to migrate schema objects from source database to target databse.

## EXAMPLES

### Example 1: Start a Database Migration from the on-premise Source Sql Server to target Sql Db
```powershell
$sourcePassword = ConvertTo-SecureString -String $password -AsPlainText -Force
$targetPassword = ConvertTo-SecureString -String $password -AsPlainText -Force
New-AzDataMigrationToSqlDb -ResourceGroupName myRG -SqlDbInstanceName "mysqldb" -MigrationService  "/subscriptions/1111-2222-3333-4444/resourceGroups/myRG/providers/Microsoft.DataMigration/SqlMigrationServices/myDMS" -TargetSqlConnectionAuthentication "SqlAuthentication" -TargetSqlConnectionDataSource "mydb.windows.net" -TargetSqlConnectionPassword $targetPassword -TargetSqlConnectionUserName "user" -SourceSqlConnectionAuthentication "SqlAuthentication" -SourceSqlConnectionDataSource "xyz.MICROSOFT.COM" -SourceSqlConnectionUserName "user1" -SourceSqlConnectionPassword $sourcePassword -SourceDatabaseName "sourcedb" -TargetDbName "mydb1" -Scope  "/subscriptions/1111-2222-3333-4444/resourceGroups/myRG/providers/Microsoft.Sql/servers/mysqldb"
```

```output
Name       Kind  ProvisioningState MigrationStatus
-----       ----  ----------------- ---------------
mydb1       SqlDb   Succeeded         InProgress
```

Start a Database Migration from the on-premise Source Sql Server to target Sql Db

### Example 2: Start a Database Migration with some selcted tables from the on-premise Source Sql Server to target Sql Db
```powershell
$sourcePassword = ConvertTo-SecureString -String $password -AsPlainText -Force
$targetPassword = ConvertTo-SecureString -String $password -AsPlainText -Force
New-AzDataMigrationToSqlDb -ResourceGroupName myRG -SqlDbInstanceName "mysqldb" -MigrationService  "/subscriptions/1111-2222-3333-4444/resourceGroups/myRG/providers/Microsoft.DataMigration/SqlMigrationServices/myDMS" -TargetSqlConnectionAuthentication "SqlAuthentication" -TargetSqlConnectionDataSource "mydb.windows.net" -TargetSqlConnectionPassword $targetPassword -TargetSqlConnectionUserName "user" -SourceSqlConnectionAuthentication "SqlAuthentication" -SourceSqlConnectionDataSource "xyz.MICROSOFT.COM" -SourceSqlConnectionUserName "user1" -SourceSqlConnectionPassword $sourcePassword -SourceDatabaseName "sourcedb" -TargetDbName "mydb1" -Scope  "/subscriptions/1111-2222-3333-4444/resourceGroups/myRG/providers/Microsoft.Sql/servers/mysqldb"  -TableList "table_1"
```

```output
Name       Kind  ProvisioningState MigrationStatus
-----       ----  ----------------- ---------------
mydb1       SqlDb   Succeeded         InProgress
```

Start a Database Migration with some selcted tables from the on-premise Source Sql Server to target Sql Db

## PARAMETERS

### -AsJob
Run the command as a job

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.ResourceType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MigrationService
Resource Id of the Migration Service.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -PassThru
Returns true when the command succeeds

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

### -ResourceGroupName
Name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Resource Id of the target resource (SQL VM or SQL Managed Instance)

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceDatabaseName
Name of the source database.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceSqlConnectionAuthentication
Authentication type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceSqlConnectionDataSource
Data source.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceSqlConnectionEncryptConnection
Whether to encrypt connection or not.

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

### -SourceSqlConnectionPassword
Password to connect to source SQL.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceSqlConnectionTrustServerCertificate
Whether to trust server certificate or not.

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

### -SourceSqlConnectionUserName
User name to connect to source SQL.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlDbInstanceName
.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription ID that identifies an Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableList
List of tables to copy.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDatabaseCollation
Database collation to be used for the target database.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDbName
The name of the target database.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetSqlConnectionAuthentication
Authentication type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetSqlConnectionDataSource
Data source.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetSqlConnectionEncryptConnection
Whether to encrypt connection or not.

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

### -TargetSqlConnectionPassword
Password to connect to source SQL.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetSqlConnectionTrustServerCertificate
Whether to trust server certificate or not.

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

### -TargetSqlConnectionUserName
User name to connect to source SQL.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.IDatabaseMigrationSqlDb

## NOTES

## RELATED LINKS

