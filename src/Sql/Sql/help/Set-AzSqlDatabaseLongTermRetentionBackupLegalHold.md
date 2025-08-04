---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version:
schema: 2.0.0
---

# Set-AzSqlDatabaseLongTermRetentionBackupLegalHold

## SYNOPSIS
Set legal hold immutability on an LTR backup.

## SYNTAX

### SetLegalHoldDefault (Default)
```
Set-AzSqlDatabaseLongTermRetentionBackupLegalHold [-Location] <String> [-ServerName] <String>
 [-DatabaseName] <String> [-BackupName] <String> [-ResourceGroupName <String>] [-Force] [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetLegalHoldByInputObject
```
Set-AzSqlDatabaseLongTermRetentionBackupLegalHold [-InputObject] <AzureSqlDatabaseLongTermRetentionBackupModel>
 [-Force] [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetLegalHoldByResourceId
```
Set-AzSqlDatabaseLongTermRetentionBackupLegalHold [-ResourceId] <String> [-Force] [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION

The **Set-AzSqlDatabaseLongTermRetentionBackupLegalHold** sets a legal hold on the given LTR backup. The backup cannot be deleted and will not expire until the legal hold is removed.

## EXAMPLES

### Example 1: Set legal hold on a single backup

```powershell
PS C:\> Set-AzSqlDatabaseLongTermRetentionBackupLegalHold -Location northeurope -ServerName server01 -DatabaseName testdb -BackupName "601061b7-d10b-46e0-bf77-a2bfb16a6add;131655666550000000" -PassThru
```

```output
Setting legal hold immutability for the Long Term Retention backup
'601061b7-d10b-46e0-bf77-a2bfb16a6add;131655666550000000' on database 'testdb' on server 'server01' in
location 'northeurope'.
Are you sure you want to set a legal hold for the Long Term Retention backup
'601061b7-d10b-46e0-bf77-a2bfb16a6add;131655666550000000' on database 'testdb' on server 'server01' in
location 'northeurope'? The backup will not be deleted, even once expired, until the legal hold is removed.
[Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"): Y

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
LegalHoldImmutability     : Enabled
```

This sets legal hold on the backup 601061b7-d10b-46e0-bf77-a2bfb16a6add;131655666550000000


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
Parameter Sets: SetLegalHoldDefault
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
Parameter Sets: SetLegalHoldDefault
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

### -InputObject
The Database Long Term Retention Backup object for which to set legal hold.

```yaml
Type: Microsoft.Azure.Commands.Sql.Backup.Model.AzureSqlDatabaseLongTermRetentionBackupModel
Parameter Sets: SetLegalHoldByInputObject
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
Parameter Sets: SetLegalHoldDefault
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: SetLegalHoldDefault
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Resource ID of the Database Long Term Retention Backup for which to set legal hold.

```yaml
Type: System.String
Parameter Sets: SetLegalHoldByResourceId
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
Parameter Sets: SetLegalHoldDefault
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

[Remove-AzSqlDatabaseLongTermRetentionBackupLegalHold](./Remove-AzSqlDatabaseLongTermRetentionBackupLegalHold.md)

[Get-AzSqlDatabaseLongTermRetentionBackup](./Get-AzSqlDatabaseLongTermRetentionBackup.md)

[Get-AzSqlDatabaseBackupLongTermRetentionPolicy](./Get-AzSqlDatabaseBackupLongTermRetentionPolicy.md)

[Set-AzSqlDatabaseBackupLongTermRetentionPolicy](./Set-AzSqlDatabaseBackupLongTermRetentionPolicy.md)

[SQL Database Documentation](https://learn.microsoft.com/azure/sql-database/)

