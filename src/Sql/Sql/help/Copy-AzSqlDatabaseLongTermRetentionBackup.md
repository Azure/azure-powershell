---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/copy-azsqldatabaselongtermretentionbackup
schema: 2.0.0
---

# Copy-AzSqlDatabaseLongTermRetentionBackup

## SYNOPSIS
Copies a long term retention backup to a target database.  

## SYNTAX

### CopyBackupDefault (Default)
```
Copy-AzSqlDatabaseLongTermRetentionBackup [-Location] <String> [-ServerName] <String> [-DatabaseName] <String>
 [-BackupName] <String> [-ResourceGroupName <String>] -TargetDatabaseName <String>
 [-TargetServerFullyQualifiedDomainName <String>] [-TargetServerName <String>] -TargetSubscriptionId <String>
 -TargetResourceGroupName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CopyBackupByResourceId
```
Copy-AzSqlDatabaseLongTermRetentionBackup [-ResourceId] <String> -TargetDatabaseName <String>
 [-TargetServerFullyQualifiedDomainName <String>] [-TargetServerName <String>] -TargetSubscriptionId <String>
 -TargetResourceGroupName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CopyBackupByInputObject
```
Copy-AzSqlDatabaseLongTermRetentionBackup [-InputObject] <AzureSqlDatabaseLongTermRetentionBackupModel>
 -TargetDatabaseName <String> [-TargetServerFullyQualifiedDomainName <String>] [-TargetServerName <String>]
 -TargetSubscriptionId <String> -TargetResourceGroupName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Copies a long term retention backup to a target database.  Target database may be in different cluster than backup source.  

## EXAMPLES

### Example 1: Copy a long term retention backup to another server within the same environment.
```powershell
Copy-AzSqlDatabaseLongTermRetentionBackup -Location southeastasia -ServerName test-server -DatabaseName test-database -BackupName 'e5c20f43-494c-4925-89d1-58e0f4569fb3;132579992320000000' -ResourceGroupName testrg -TargetDatabaseName ltr1 -TargetServerName ayang-eas -TargetSubscriptionId '01c4ec88-e179-44f7-9eb0-e9719a5087ab' -TargetResourceGroupName testrg
```

```output
SourceResourceGroupName              : test-rg
SourceLocation                       : southeastasia
SourceServerName                     : test-server
SourceDatabaseName                   : test-database
SourceBackupName                     : e5c20f43-494c-4925-89d1-58e0f4569fb3;132579992320000000
SourceBackupResourceId               : /subscriptions/01c4ec88-e179-44f7-9eb0-e9719a5087ab/resourceGroups/test-rg/providers/Microsoft.Sql/locations/SoutheastAsia/longTermRetentionServers/test-server/longTermRetentionDatabases/test-database/longTermRetentionBackups/e5c20f43-494c-4925-89d1-58e0f4569fb3;132579992320000000
SourceBackupStorageRedundancy        : Geo
TargetSubscriptionId                 : 01c4ec88-e179-44f7-9eb0-e9719a5087ab
TargetResourceGroupName              : test-rg
TargetLocation                       : East Asia
TargetServerName                     : ayang-eas
TargetServerFullyQualifiedDomainName :
TargetServerResourceId               : /subscriptions/01c4ec88-e179-44f7-9eb0-e9719a5087ab/resourceGroups/test-rg/providers/Microsoft.Sql/servers/ayang-eas
TargetDatabaseName                   : ltr1
TargetBackupName                     : 70554a1f-ae6e-479e-99b1-50ea320654eb;132579992320000000
TargetBackupResourceId               : /subscriptions/01c4ec88-e179-44f7-9eb0-e9719a5087ab/resourceGroups/test-rg/providers/Microsoft.Sql/locations/East Asia/longTermRetentionServers/ayang-eas/longTermRetentionDatabases/ltr1/longTermRetentionBackups/70554a1f-ae6e-479e-99b1-50ea320654eb;132579992320000000
```

This copies a long term retention backup from a source database in Southeast Asia to a target database in East Asia.

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

### -BackupName
The name of the backup.

```yaml
Type: System.String
Parameter Sets: CopyBackupDefault
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DatabaseName
The name of the Azure SQL Database the backup is from.

```yaml
Type: System.String
Parameter Sets: CopyBackupDefault
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
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

### -InputObject
The Database Long Term Retention Backup object to remove.

```yaml
Type: Microsoft.Azure.Commands.Sql.Backup.Model.AzureSqlDatabaseLongTermRetentionBackupModel
Parameter Sets: CopyBackupByInputObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The location of the backups' source server.

```yaml
Type: System.String
Parameter Sets: CopyBackupDefault
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: CopyBackupDefault
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Resource ID of the Database Long Term Retention Backup to remove.

```yaml
Type: System.String
Parameter Sets: CopyBackupByResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerName
The name of the Azure SQL Server the backup is under.

```yaml
Type: System.String
Parameter Sets: CopyBackupDefault
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDatabaseName
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

### -TargetResourceGroupName
The resource ID of the target subscription.

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

### -TargetServerFullyQualifiedDomainName
The fully qualified domain name of the target server.

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

### -TargetServerName
The name of the target server.

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

### -TargetSubscriptionId
The resource ID of the target subscription.

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

### System.String

### Microsoft.Azure.Commands.Sql.Backup.Model.AzureSqlDatabaseLongTermRetentionBackupModel

## OUTPUTS

### Microsoft.Azure.Commands.Sql.Backup.Model.AzureSqlDatabaseLongTermRetentionBackupModel

## NOTES

## RELATED LINKS

[Get-AzSqlDatabaseLongTermRetentionBackup](./Get-AzSqlDatabaseLongTermRetentionBackup.md)

[Update-AzSqlDatabaseLongTermRetentionBackup](./Update-AzSqlDatabaseLongTermRetentionBackup.md)

[Remove-AzSqlDatabaseLongTermRetentionBackup](./Remove-AzSqlDatabaseLongTermRetentionBackup.md)

[Get-AzSqlDatabaseBackupLongTermRetentionPolicy](./Get-AzSqlDatabaseBackupLongTermRetentionPolicy.md)

[Set-AzSqlDatabaseBackupLongTermRetentionPolicy](./Set-AzSqlDatabaseBackupLongTermRetentionPolicy.md)

[SQL Database Documentation](https://docs.microsoft.com/azure/sql-database/)