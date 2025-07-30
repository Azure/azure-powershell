---
document type: cmdlet
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
HelpUri: 
Module Name: Az.Sql
ms.date: 07/30/2025
PlatyPS schema version: 2024-05-01
---

# Set-AzSqlDatabaseLongTermRetentionBackupLegalHold

## SYNOPSIS

Set legal hold immutability on an LTR backup.

## SYNTAX

### SetLegalHoldDefault (Default)

```
Set-AzSqlDatabaseLongTermRetentionBackupLegalHold [-Location] <string> [-ServerName] <string>
 [-DatabaseName] <string> [-BackupName] <string> [-ResourceGroupName <string>] [-Force] [-PassThru]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetLegalHoldByInputObject

```
Set-AzSqlDatabaseLongTermRetentionBackupLegalHold
 [-InputObject] <AzureSqlDatabaseLongTermRetentionBackupModel> [-Force] [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetLegalHoldByResourceId

```
Set-AzSqlDatabaseLongTermRetentionBackupLegalHold [-ResourceId] <string> [-Force] [-PassThru]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

The **Set-AzSqlDatabaseLongTermRetentionBackupLegalHold** sets a legal hold on the given LTR backup. The backup cannot be deleted and will not expire until the legal hold is removed.

## EXAMPLES

### Example 1: Set legal hold on a single backup

```powershell
PS C:\> Set-AzSqlDatabaseLongTermRetentionBackupLegalHold -Location northeurope -ServerName server01 -DatabaseName testdb -BackupName "601061b7-d10b-46e0-bf77-a2bfb16a6add;131655666550000000" -PassThru

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
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -BackupName

The name of the backup.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: SetLegalHoldDefault
  Position: 3
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Confirm

Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases:
- cf
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -DatabaseName

The name of the Azure SQL Database the backup is from.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: SetLegalHoldDefault
  Position: 2
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -DefaultProfile

The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
DefaultValue: None
SupportsWildcards: false
Aliases:
- AzContext
- AzureRmContext
- AzureCredential
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Force

Skip confirmation message for performing the action

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -InputObject

The Database Long Term Retention Backup object for which to set legal hold.

```yaml
Type: Microsoft.Azure.Commands.Sql.Backup.Model.AzureSqlDatabaseLongTermRetentionBackupModel
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: SetLegalHoldByInputObject
  Position: 0
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Location

The location of the backups' source server.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: SetLegalHoldDefault
  Position: 0
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -PassThru

Whether to output the model at the end of execution

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ProgressAction

{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
DefaultValue: None
SupportsWildcards: false
Aliases:
- proga
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ResourceGroupName

The name of the resource group.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: SetLegalHoldDefault
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ResourceId

The Resource ID of the Database Long Term Retention Backup for which to set legal hold.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: SetLegalHoldByResourceId
  Position: 0
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ServerName

The name of the Azure SQL Server the backup is under.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: SetLegalHoldDefault
  Position: 1
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -WhatIf

Shows what would happen if the cmdlet runs.
The cmdlet is not run.
Runs the command in a mode that only reports what would happen without performing the actions.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases:
- wi
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

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

