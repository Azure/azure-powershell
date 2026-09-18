---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/remove-azsqldatabaselongtermretentionbackuplegalhold
schema: 2.0.0
---

# Remove-AzSqlDatabaseLongTermRetentionBackupLegalHold

## SYNOPSIS
Removes legal hold immutability on an LTR backup. (Public Preview)

## SYNTAX

### RemoveBackupLegalHoldDefault (Default)
```
Remove-AzSqlDatabaseLongTermRetentionBackupLegalHold [-Location] <String> [-ServerName] <String>
 [-DatabaseName] <String> [-BackupName] <String> [-ResourceGroupName <String>] [-Force] [-ForceDropExpired]
 [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RemoveBackupLegalHoldByInputObject
```
Remove-AzSqlDatabaseLongTermRetentionBackupLegalHold
 [-InputObject] <AzureSqlDatabaseLongTermRetentionBackupModel> [-Force] [-ForceDropExpired] [-PassThru]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RemoveBackupLegalHoldByResourceId
```
Remove-AzSqlDatabaseLongTermRetentionBackupLegalHold [-ResourceId] <String> [-Force] [-ForceDropExpired]
 [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzSqlDatabaseLongTermRetentionBackupLegalHold** removes a legal hold on the given LTR backup. Once removed, the backup can be manually deleted. If the backup is expired, it will be dropped immediately after removal.

## EXAMPLES

### Example 1: Remove legal hold for a single backup
```powershell
Remove-AzSqlDatabaseLongTermRetentionBackupLegalHold -Location northeurope -ServerName server01 -DatabaseName testdb -BackupName "601061b7-d10b-46e0-bf77-a2bfb16a6add;131655666550000000" -PassThru:$true
```

```output
BackupExpirationTime      : 8/5/2025 8:08:27 PM
BackupName                : 601061b7-d10b-46e0-bf77-a2bfb16a6add;131655666550000000
BackupTime                : 7/29/2025 8:08:27 PM
DatabaseName              : testdb
DatabaseDeletionTime      :
Location                  : northeurope
ResourceId                : /subscriptions/b75889fa-6661-44e0-a844-cd96ec938991/resourceGroups/resourcegroup01/providers/Microsoft.Sql/locations/northeurope/longTermRetentionServers/server01/longTermRetentionDatabases/testdb/longTermRetentionBackups/601061b7-d10b-46e0-bf77-a2bfb16a6add;131655666550000000
ServerName                : server01
ServerCreateTime          : 7/29/2025 7:28:46 PM
ResourceGroupName         : resourcegroup01
BackupStorageRedundancy   : Geo
TimeBasedImmutability     : Disabled
TimeBasedImmutabilityMode : Unlocked
LegalHoldImmutability     : Disabled
```

This removes the legal hold for a single backup.

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
Parameter Sets: RemoveBackupLegalHoldDefault
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
Parameter Sets: RemoveBackupLegalHoldDefault
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

### -Force
Skip confirmation message for performing the action

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

### -ForceDropExpired
Skip confirmation message for removing a legal hold from an expired backup.

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

### -InputObject
The Database Long Term Retention Backup object for which to remove legal hold.

```yaml
Type: Microsoft.Azure.Commands.Sql.Backup.Model.AzureSqlDatabaseLongTermRetentionBackupModel
Parameter Sets: RemoveBackupLegalHoldByInputObject
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
Parameter Sets: RemoveBackupLegalHoldDefault
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Whether to output the model at the end of execution

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
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: RemoveBackupLegalHoldDefault
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Resource ID of the Database Long Term Retention Backup for which to remove legal hold.

```yaml
Type: System.String
Parameter Sets: RemoveBackupLegalHoldByResourceId
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
Parameter Sets: RemoveBackupLegalHoldDefault
Aliases:

Required: True
Position: 1
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

### Microsoft.Azure.Commands.Sql.Backup.Model.AzureSqlDatabaseLongTermRetentionBackupModel

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.Backup.Model.AzureSqlDatabaseLongTermRetentionBackupModel

## NOTES

## RELATED LINKS

[Set-AzSqlDatabaseLongTermRetentionBackupLegalHold](./Set-AzSqlDatabaseLongTermRetentionBackupLegalHold.md)

[Remove-AzSqlDatabaseLongTermRetentionBackup](./Remove-AzSqlDatabaseLongTermRetentionBackup.md)

[Get-AzSqlDatabaseLongTermRetentionBackup](./Get-AzSqlDatabaseLongTermRetentionBackup.md)

[Get-AzSqlDatabaseBackupLongTermRetentionPolicy](./Get-AzSqlDatabaseBackupLongTermRetentionPolicy.md)

[Set-AzSqlDatabaseBackupLongTermRetentionPolicy](./Set-AzSqlDatabaseBackupLongTermRetentionPolicy.md)

[SQL Database Documentation](https://learn.microsoft.com/azure/sql-database/)
