---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/set-azsqldatabasebackupshorttermretentionpolicy
schema: 2.0.0
---

# Set-AzSqlDatabaseBackupShortTermRetentionPolicy

## SYNOPSIS
Sets a backup short term retention policy.

## SYNTAX

### PolicyByResourceServerDatabaseSet (Default)
```
Set-AzSqlDatabaseBackupShortTermRetentionPolicy [-RetentionDays <Int32>] [-DiffBackupIntervalInHours <Int32>]
 [-ResourceGroupName] <String> [-ServerName] <String> [-DatabaseName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PolicyByInputObjectSet
```
Set-AzSqlDatabaseBackupShortTermRetentionPolicy [-RetentionDays <Int32>] [-DiffBackupIntervalInHours <Int32>]
 -AzureSqlDatabaseObject <AzureSqlDatabaseModel> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### PolicyByResourceIdSet
```
Set-AzSqlDatabaseBackupShortTermRetentionPolicy [-RetentionDays <Int32>] [-DiffBackupIntervalInHours <Int32>]
 -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzSqlDatabaseBackupShortTermRetentionPolicy** cmdlet sets the short term retention policy for this database.
The policy is the retention period, in days, for point-in-time restore backups and differential backup frequency, in hours.

## EXAMPLES

### Example 1
```powershell
Set-AzSqlDatabaseBackupShortTermRetentionPolicy -ResourceGroupName resourcegroup01 -ServerName server01 -DatabaseName database01 -RetentionDays 6 -DiffBackupIntervalInHours 24
```

```output
ResourceGroupName ServerName DatabaseName RetentionDays DiffBackupIntervalInHours
----------------- ---------- ------------ ------------- -------------------------
resourcegroup01   server01   database01   6             24
```

This command sets the short term retention policy for database01 to 6 retention days and 24 differential backup interval hours.

### Example 2
```powershell
Get-AzSqlDatabase -ResourceGroupName resourcegroup01 -ServerName server01 -DatabaseName database01 | Set-AzSqlDatabaseBackupShortTermRetentionPolicy -RetentionDays 5 -DiffBackupIntervalInHours 12
```

```output
ResourceGroupName ServerName DatabaseName RetentionDays DiffBackupIntervalInHours
----------------- ---------- ------------ ------------- ------------------------
resourcegroup01   server01   database01   5             12
```

This command sets the short term retention policy for database01 to 5 retention days and 12 differential backup interval hours via piping in a database object.

### Example 3
```powershell
Set-AzSqlDatabaseBackupShortTermRetentionPolicy -ResourceGroupName resourcegroup01 -ServerName server01 -DatabaseName database01 -RetentionDays 7
```

```output
ResourceGroupName ServerName DatabaseName RetentionDays DiffBackupIntervalInHours
----------------- ---------- ------------ ------------- -------------------------
resourcegroup01   server01   database01   7             12
```

This command sets the short term retention policy for database01 to 7 retention days only. DiffBackupIntervalInHours is unchanged.  

## PARAMETERS

### -AzureSqlDatabaseObject
The database object to get the policy for.

```yaml
Type: Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel
Parameter Sets: PolicyByInputObjectSet
Aliases: AzureSqlDatabase

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DatabaseName
The name of the Azure SQL Database to use.

```yaml
Type: System.String
Parameter Sets: PolicyByResourceServerDatabaseSet
Aliases:

Required: True
Position: 2
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

### -DiffBackupIntervalInHours
Differential backup frequency in hours.

```yaml
Type: System.Int32
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
Parameter Sets: PolicyByResourceServerDatabaseSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The short term retention policy resource Id.

```yaml
Type: System.String
Parameter Sets: PolicyByResourceIdSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RetentionDays
The backup retention setting, in days.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 7
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerName
The name of the Azure SQL Server the database is in.

```yaml
Type: System.String
Parameter Sets: PolicyByResourceServerDatabaseSet
Aliases:

Required: True
Position: 1
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

### Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.Backup.Model.AzureSqlDatabaseBackupShortTermRetentionPolicyModel

## NOTES

## RELATED LINKS
