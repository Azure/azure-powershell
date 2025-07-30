---
document type: cmdlet
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
HelpUri: https://learn.microsoft.com/powershell/module/az.sql/set-azsqldatabasebackuplongtermretentionpolicy
Module Name: Az.Sql
ms.date: 07/30/2025
PlatyPS schema version: 2024-05-01
---

# Set-AzSqlDatabaseBackupLongTermRetentionPolicy

## SYNOPSIS

Sets a server long term retention policy.

## SYNTAX

### WeeklyRetentionRequired (Default)

```
Set-AzSqlDatabaseBackupLongTermRetentionPolicy [-ResourceGroupName] <string> [-ServerName] <string>
 [-DatabaseName] <string> -WeeklyRetention <string> [-TimeBasedImmutability <string>]
 [-TimeBasedImmutabilityMode <string>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RemovePolicy

```
Set-AzSqlDatabaseBackupLongTermRetentionPolicy [-ResourceGroupName] <string> [-ServerName] <string>
 [-DatabaseName] <string> -RemovePolicy [-TimeBasedImmutability <string>]
 [-TimeBasedImmutabilityMode <string>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### MonthlyRetentionRequired

```
Set-AzSqlDatabaseBackupLongTermRetentionPolicy [-ResourceGroupName] <string> [-ServerName] <string>
 [-DatabaseName] <string> -MonthlyRetention <string> [-WeeklyRetention <string>]
 [-TimeBasedImmutability <string>] [-TimeBasedImmutabilityMode <string>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### YearlyRetentionRequired

```
Set-AzSqlDatabaseBackupLongTermRetentionPolicy [-ResourceGroupName] <string> [-ServerName] <string>
 [-DatabaseName] <string> -YearlyRetention <string> -WeekOfYear <int> [-WeeklyRetention <string>]
 [-MonthlyRetention <string>] [-TimeBasedImmutability <string>]
 [-TimeBasedImmutabilityMode <string>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

The **Set-AzSqlDatabaseBackupLongTermRetentionPolicy** cmdlet sets the long term retention policy registered to this database.
The policy is an Azure Backup resource used to define backup storage policy.

## EXAMPLES

### Example 1: Set the weekly retention for the current version of long term retention policy

```powershell
Set-AzSqlDatabaseBackupLongTermRetentionPolicy -ResourceGroupName resourcegroup01 -ServerName server01 -DatabaseName database01 -WeeklyRetention P2W
```

```output
ResourceGroupName                      : resourcegroup01
ServerName                             : server01
DatabaseName                           : database01
WeeklyRetention                        : P2W
MonthlyRetention                       : PT0S
YearlyRetention                        : PT0S
WeekOfYear                             : 0
Location                               :
TimeBasedImmutability                  : Disabled
TimeBasedImmutabilityMode              : Unlocked
```

This sets the long term retention policy of database01 to save every weekly full backup for 2 weeks

### Example 2: Set the monthly retention for the current version of long term retention policy

```powershell
Set-AzSqlDatabaseBackupLongTermRetentionPolicy -ResourceGroupName resourcegroup01 -ServerName server01 -DatabaseName database01 -MonthlyRetention P5Y
```

```output
ResourceGroupName                      : resourcegroup01
ServerName                             : server01
DatabaseName                           : database01
WeeklyRetention                        : PT0S
MonthlyRetention                       : P5Y
YearlyRetention                        : PT0S
WeekOfYear                             : 0
Location                               :
TimeBasedImmutability                  : Disabled
TimeBasedImmutabilityMode              : Unlocked
```

This sets the long term retention policy of database01 to save the first full backup of each month for 5 years

### Example 3: Set the yearly retention for the current version of long term retention policy

```powershell
Set-AzSqlDatabaseBackupLongTermRetentionPolicy -ResourceGroupName resourcegroup01 -ServerName server01 -DatabaseName database01 -YearlyRetention P10Y -WeekOfYear 26
```

```output
ResourceGroupName                      : resourcegroup01
ServerName                             : server01
DatabaseName                           : database01
WeeklyRetention                        : PT0S
MonthlyRetention                       : PT0S
YearlyRetention                        : P10Y
WeekOfYear                             : 26
Location                               :
TimeBasedImmutability                  : Disabled
TimeBasedImmutabilityMode              : Unlocked
```

This sets the long term retention policy of database01 to save the full backup taken on the 26th week of the year for 10 years

### Example 4: Set the yearly retention for the current version of long term retention policy with an unlocked time-based immutability enabled

```powershell
Set-AzSqlDatabaseBackupLongTermRetentionPolicy -ResourceGroupName resourcegroup01 -ServerName server01 -DatabaseName database01 -YearlyRetention P10Y -WeekOfYear 26 -TimeBasedImmutability Enabled
```

```output
ResourceGroupName                      : resourcegroup01
ServerName                             : server01
DatabaseName                           : database01
WeeklyRetention                        : PT0S
MonthlyRetention                       : PT0S
YearlyRetention                        : P10Y
WeekOfYear                             : 26
Location                               :
TimeBasedImmutability                  : Enabled
TimeBasedImmutabilityMode              : Unlocked
```

This sets the long term retention policy of database01 to save the full backup taken on the 26th week of the year for 10 years. 
Additionally, the backups will be created with an unlocked time-based immutability policy. 
These backups can later have their immutability locked or removed.

### Example 5: Set the yearly retention for the current version of long term retention policy with a locked time-based immutability enabled

```powershell
Set-AzSqlDatabaseBackupLongTermRetentionPolicy -ResourceGroupName resourcegroup01 -ServerName server01 -DatabaseName database01 -YearlyRetention P10Y -WeekOfYear 26 -TimeBasedImmutability Enabled -TimeBasedImmutabilityMode Locked
```

```output
ResourceGroupName                      : resourcegroup01
ServerName                             : server01
DatabaseName                           : database01
WeeklyRetention                        : PT0S
MonthlyRetention                       : PT0S
YearlyRetention                        : P10Y
WeekOfYear                             : 26
Location                               :
TimeBasedImmutability                  : Enabled
TimeBasedImmutabilityMode              : Unlocked
```

This sets the long term retention policy of database01 to save the full backup taken on the 26th week of the year for 10 years. 
Additionally, the backups will be created with a locked time-based immutability policy. 
These backups can not be deleted manually and will only be dropped on expiration.

### Example 6: Set each retention for the current version of long term retention policy

```powershell
Set-AzSqlDatabaseBackupLongTermRetentionPolicy -ResourceGroupName resourcegroup01 -ServerName server01 -DatabaseName database01 -WeeklyRetention 14 -MonthlyRetention P24W -YearlyRetention P10Y -WeekOfYear 26
```

```output
ResourceGroupName                      : resourcegroup01
ServerName                             : server01
DatabaseName                           : database01
WeeklyRetention                        : P14D
MonthlyRetention                       : P24W
YearlyRetention                        : P10Y
WeekOfYear                             : 26
Location                               :
TimeBasedImmutability                  : Disabled
TimeBasedImmutabilityMode              : Unlocked
```

This sets the long term retention policy of database01 to save each full backup for 14 days, the first full backup of each month for 24 weeks, and the full backup taken on the 26th week of the year for 10 years

### Example 7: Remove the long term retention policy

```powershell
Set-AzSqlDatabaseBackupLongTermRetentionPolicy -ResourceGroupName resourcegroup01 -ServerName server01 -DatabaseName database01 -RemovePolicy
```

```output
ResourceGroupName                      : resourcegroup01
ServerName                             : server01
DatabaseName                           : database01
WeeklyRetention                        : PT0S
MonthlyRetention                       : PT0S
YearlyRetention                        : PT0S
WeekOfYear                             : 0
Location                               :
TimeBasedImmutability                  : Disabled
TimeBasedImmutabilityMode              : Unlocked
```

Removes the policy for database01 so it no longer saves any long term retention backups.
This will not affect backups that have already been taken.

### Example 8: Remove the long term retention policy

```powershell
Set-AzSqlDatabaseBackupLongTermRetentionPolicy -ResourceGroupName resourcegroup01 -ServerName server01 -DatabaseName database01 -WeeklyRetention P0D
```

```output
ResourceGroupName                      : resourcegroup01
ServerName                             : server01
DatabaseName                           : database01
WeeklyRetention                        : PT0S
MonthlyRetention                       : PT0S
YearlyRetention                        : PT0S
WeekOfYear                             : 0
Location                               :
TimeBasedImmutability                  : Disabled
TimeBasedImmutabilityMode              : Unlocked
```

This is another way of removing the policy for database01 so it no longer saves any long term retention backups.
This will not affect backups that have already been taken

## PARAMETERS

### -Confirm

Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: False
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

The name of the Azure SQL Database to use.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: 2
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
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

### -MonthlyRetention

The Monthly Retention.
If just a number is passed instead of an ISO 8601 string, days will be assumed as the units.
There is a minimum of 7 days and a maximum of 10 years.
The Monthly Retention. If just a number is passed instead of an ISO 8601 string, days will be assumed as the units. There is a minimum of 7 days and a maximum of 10 years.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: MonthlyRetentionRequired
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
- Name: YearlyRetentionRequired
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -RemovePolicy

If provided, the policy for the database will be removed.
If provided, the policy for the database will be cleared.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: RemovePolicy
  Position: Named
  IsRequired: true
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
- Name: (All)
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

The name of the Azure SQL Server the database is in.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: 1
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -TimeBasedImmutability

When set, future backups will have TimeBasedImmutability enabled.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -TimeBasedImmutabilityMode

The setting for time-based immutability mode for future backups. Only effective if TimeBasedImmutability is enabled. Value can be either Locked or Unlocked. Caution: Immutability of LTR backup cannot be removed if TimeBasedImmutabilityMode is Locked.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -WeeklyRetention

The Weekly Retention.
If just a number is passed instead of an ISO 8601 string, days will be assumed as the units.
There is a minimum of 7 days and a maximum of 10 years.
The Weekly Retention. If just a number is passed instead of an ISO 8601 string, days will be assumed as the units. There is a minimum of 7 days and a maximum of 10 years.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: WeeklyRetentionRequired
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
- Name: MonthlyRetentionRequired
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
- Name: YearlyRetentionRequired
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -WeekOfYear

The Week of Year, 1 to 52, to save for the Yearly Retention.

```yaml
Type: System.Int32
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: YearlyRetentionRequired
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
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
DefaultValue: False
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

### -YearlyRetention

The Yearly Retention.
If just a number is passed instead of an ISO 8601 string, days will be assumed as the units.
There is a minimum of 7 days and a maximum of 10 years.
The Yearly Retention. If just a number is passed instead of an ISO 8601 string, days will be assumed as the units. There is a minimum of 7 days and a maximum of 10 years.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: YearlyRetentionRequired
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
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

### System.String

### System.Int32

## OUTPUTS

### Microsoft.Azure.Commands.Sql.Backup.Model.AzureSqlDatabaseBackupLongTermRetentionPolicyModel

## NOTES

## RELATED LINKS

- [Get-AzSqlDatabaseLongTermRetentionBackup](./Get-AzSqlDatabaseLongTermRetentionBackup.md)
- [Update-AzSqlDatabaseLongTermRetentionBackup](./Update-AzSqlDatabaseLongTermRetentionBackup.md)
- [Copy-AzSqlDatabaseLongTermRetentionBackup](./Copy-AzSqlDatabaseLongTermRetentionBackup.md)
- [Remove-AzSqlDatabaseLongTermRetentionBackup](./Remove-AzSqlDatabaseLongTermRetentionBackup.md)
- [Get-AzSqlDatabaseBackupLongTermRetentionPolicy](./Get-AzSqlDatabaseBackupLongTermRetentionPolicy.md)
- [SQL Database Documentation](https://learn.microsoft.com/azure/sql-database/)
