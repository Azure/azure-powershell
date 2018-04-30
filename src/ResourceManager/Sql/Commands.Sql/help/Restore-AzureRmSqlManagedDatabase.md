---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version:
schema: 2.0.0
---

# Restore-AzureRmSqlManagedDatabase

## SYNOPSIS
Restores a SQL Managed database.

## SYNTAX

### RestoreManagedDatabaseFromInputParameters
```
Restore-AzureRmSqlManagedDatabase [-ManagedDatabaseName] <String> [-ManagedInstanceName] <String>
 [-ResourceGroupName] <String> -PointInTime <DateTime> -TargetManagedDatabaseName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreManagedDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition
```
Restore-AzureRmSqlManagedDatabase -InputObject <AzureSqlManagedDatabaseModel> -PointInTime <DateTime>
 -TargetManagedDatabaseName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RestoreManagedDatabaseFromAzureResourceId
```
Restore-AzureRmSqlManagedDatabase -ResourceId <String> -PointInTime <DateTime>
 -TargetManagedDatabaseName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Restore-AzureRmSqlManagedDatabase** cmdlet restores a SQL Managed database from a point in time in a live database.
The restored database is created as a new managed database.

## EXAMPLES

### Example 1: Restore a managed database from a point in time
```
PS C:\> Restore-AzureRmSqlManagedDatabase -ResourceGroupName "ResourceGroup01" -ManagedInstanceName "managedInstance1" -ManagedDatabaseName "Database01" -PointInTime UTCDateTime -TargetManagedDatabaseName "Database01_restored"
```

The command restores the managed database Database01 from the specified point-in-time backup to the managed database named Database01_restored.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The Managed Database object to restore

```yaml
Type: AzureSqlManagedDatabaseModel
Parameter Sets: RestoreManagedDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition
Aliases: ManagedDatabase

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedDatabaseName
The managed database name to restore.

```yaml
Type: String
Parameter Sets: RestoreManagedDatabaseFromInputParameters
Aliases: Name

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedInstanceName
The Managed instance name.

```yaml
Type: String
Parameter Sets: RestoreManagedDatabaseFromInputParameters
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PointInTime
The point in time to restore the database to.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: RestoreManagedDatabaseFromInputParameters
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of Managed Database object to restore

```yaml
Type: String
Parameter Sets: RestoreManagedDatabaseFromAzureResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetManagedDatabaseName
The name of the target managed database to restore to.

```yaml
Type: String
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
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlManagedDatabaseModel
System.String


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
