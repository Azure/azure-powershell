---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.sql/restore-azurermsqlmanageddatabase
schema: 2.0.0
---

# Restore-AzureRmSqlManagedDatabase

## SYNOPSIS
Restores a SQL Managed database.

## SYNTAX

### PointInTimeSameInstanceRestoreManagedDatabaseFromInputParameters
```
Restore-AzureRmSqlManagedDatabase [-FromPointInTimeBackup] [-Name] <String> [-ManagedInstanceName] <String>
 [-ResourceGroupName] <String> -PointInTime <DateTime> -TargetManagedDatabaseName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PointInTimeSameInstanceRestoreManagedDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition
```
Restore-AzureRmSqlManagedDatabase [-FromPointInTimeBackup] [-InputObject] <AzureSqlManagedDatabaseModel>
 -PointInTime <DateTime> -TargetManagedDatabaseName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PointInTimeSameInstanceRestoreManagedDatabaseFromAzureResourceId
```
Restore-AzureRmSqlManagedDatabase [-FromPointInTimeBackup] [-ResourceId] <String> -PointInTime <DateTime>
 -TargetManagedDatabaseName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PointInTimeCrossInstanceRestoreManagedDatabaseFromInputParameters
```
Restore-AzureRmSqlManagedDatabase [-FromPointInTimeBackup] [-Name] <String> [-ManagedInstanceName] <String>
 [-ResourceGroupName] <String> -PointInTime <DateTime> -TargetManagedDatabaseName <String>
 -TargetManagedInstanceName <String> -TargetResourceGroupName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PointInTimeCrossInstanceRestoreManagedDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition
```
Restore-AzureRmSqlManagedDatabase [-FromPointInTimeBackup] [-InputObject] <AzureSqlManagedDatabaseModel>
 -PointInTime <DateTime> -TargetManagedDatabaseName <String> -TargetManagedInstanceName <String>
 -TargetResourceGroupName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PointInTimeCrossInstanceRestoreManagedDatabaseFromAzureResourceId
```
Restore-AzureRmSqlManagedDatabase [-FromPointInTimeBackup] [-ResourceId] <String> -PointInTime <DateTime>
 -TargetManagedDatabaseName <String> -TargetManagedInstanceName <String> -TargetResourceGroupName <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Restore-AzureRmSqlManagedDatabase** cmdlet restores a SQL Managed database from a point in time in a live database.
The restored database is created as a new managed database.

## EXAMPLES

### Example 1: Restore a managed database from a point in time
```
PS C:\> Restore-AzureRmSqlManagedDatabase -Name "Database01" -ManagedInstanceName "managedInstance1" -ResourceGroupName "ResourceGroup01" -PointInTime UTCDateTime -TargetManagedDatabaseName "Database01_restored"
```

The command restores the managed database Database01 from the specified point-in-time backup to the managed database named Database01_restored.

### Example 2: Restore a managed database from a point in time to another managed instance on different resource group
```
PS C:\> Restore-AzureRmSqlManagedDatabase -Name "Database01" -ManagedInstanceName "managedInstance1" -ResourceGroupName "ResourceGroup01" -PointInTime UTCDateTime -TargetManagedDatabaseName "Database01_restored" -TargetManagedInstanceName "managedInstance1" -TargetResourceGroupName "ResourceGroup02"
```

The command restores the managed database Database01 on managed instance managedInstance1 on resource group ResourceGroup01 from the specified point-in-time backup to the managed database named Database01_restored on managed instance managedInstance2 on resource group ResourceGroup02.

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

### -FromPointInTimeBackup
Restore from a point-in-time backup.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The Managed Database object to restore

```yaml
Type: AzureSqlManagedDatabaseModel
Parameter Sets: PointInTimeSameInstanceRestoreManagedDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition, PointInTimeCrossInstanceRestoreManagedDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition
Aliases: ManagedDatabase

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedInstanceName
The Managed instance name.

```yaml
Type: String
Parameter Sets: PointInTimeSameInstanceRestoreManagedDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreManagedDatabaseFromInputParameters
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The managed database name to restore.

```yaml
Type: String
Parameter Sets: PointInTimeSameInstanceRestoreManagedDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreManagedDatabaseFromInputParameters
Aliases: ManagedDatabaseName

Required: True
Position: 0
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
Parameter Sets: PointInTimeSameInstanceRestoreManagedDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreManagedDatabaseFromInputParameters
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
Parameter Sets: PointInTimeSameInstanceRestoreManagedDatabaseFromAzureResourceId, PointInTimeCrossInstanceRestoreManagedDatabaseFromAzureResourceId
Aliases:

Required: True
Position: 0
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

### -TargetManagedInstanceName
The name of the target managed instance to restore to.

```yaml
Type: String
Parameter Sets: PointInTimeCrossInstanceRestoreManagedDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreManagedDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition, PointInTimeCrossInstanceRestoreManagedDatabaseFromAzureResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceGroupName
The name of the target resource group to restore to.

```yaml
Type: String
Parameter Sets: PointInTimeCrossInstanceRestoreManagedDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreManagedDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition, PointInTimeCrossInstanceRestoreManagedDatabaseFromAzureResourceId
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

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlManagedDatabaseModel


## NOTES

## RELATED LINKS
