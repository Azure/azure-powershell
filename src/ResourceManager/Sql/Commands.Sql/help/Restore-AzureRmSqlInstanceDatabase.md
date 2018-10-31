---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.sql/restore-azurermsqlinstancedatabase
schema: 2.0.0
---

# Restore-AzureRmSqlInstanceDatabase

## SYNOPSIS
Restores a SQL Managed instance database.

## SYNTAX

### PointInTimeSameInstanceRestoreInstanceDatabaseFromInputParameters (Default)
```
Restore-AzureRmSqlInstanceDatabase [-FromPointInTimeBackup] [-Name] <String> [-ManagedInstanceName] <String>
 [-ResourceGroupName] <String> -PointInTime <DateTime> -TargetInstanceDatabaseName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PointInTimeSameInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition
```
Restore-AzureRmSqlInstanceDatabase [-FromPointInTimeBackup] [-InputObject] <AzureSqlManagedDatabaseModel>
 -PointInTime <DateTime> -TargetInstanceDatabaseName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PointInTimeSameInstanceRestoreInstanceDatabaseFromAzureResourceId
```
Restore-AzureRmSqlInstanceDatabase [-FromPointInTimeBackup] [-ResourceId] <String> -PointInTime <DateTime>
 -TargetInstanceDatabaseName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters
```
Restore-AzureRmSqlInstanceDatabase [-FromPointInTimeBackup] [-Name] <String> [-ManagedInstanceName] <String>
 [-ResourceGroupName] <String> -PointInTime <DateTime> -TargetInstanceDatabaseName <String>
 -TargetManagedInstanceName <String> -TargetResourceGroupName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition
```
Restore-AzureRmSqlInstanceDatabase [-FromPointInTimeBackup] [-InputObject] <AzureSqlManagedDatabaseModel>
 -PointInTime <DateTime> -TargetInstanceDatabaseName <String> -TargetManagedInstanceName <String>
 -TargetResourceGroupName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureResourceId
```
Restore-AzureRmSqlInstanceDatabase [-FromPointInTimeBackup] [-ResourceId] <String> -PointInTime <DateTime>
 -TargetInstanceDatabaseName <String> -TargetManagedInstanceName <String> -TargetResourceGroupName <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Restore-AzureRmSqlInstanceDatabase** cmdlet restores a SQL Managed database from a point in time in a live database.
The restored database is created as a new managed instance database.

## EXAMPLES

## EXAMPLES

### Example 1: Restore a managed instance database from a point in time
```
PS C:\> Restore-AzureRmSqlinstanceDatabase -Name "Database01" -ManagedInstanceName "managedInstance1" -ResourceGroupName "ResourceGroup01" -PointInTime UTCDateTime -TargetInstanceDatabaseName "Database01_restored"
```

The command restores the managed instance database Database01 from the specified point-in-time backup to the managed instance database named Database01_restored.

### Example 2: Restore a managed instance database from a point in time to another managed instance on different resource group
```
PS C:\> Restore-AzureRmSqlInstanceDatabase -Name "Database01" -ManagedInstanceName "managedInstance1" -ResourceGroupName "ResourceGroup01" -PointInTime UTCDateTime -TargetInstanceDatabaseName "Database01_restored" -TargetManagedInstanceName "managedInstance1" -TargetResourceGroupName "ResourceGroup02"
```

The command restores the managed instance database Database01 on managed instance managedInstance1 on resource group ResourceGroup01 from the specified point-in-time backup to the managed instance database named Database01_restored on managed instance managedInstance2 on resource group ResourceGroup02.

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
The Instance Database object to restore

```yaml
Type: AzureSqlManagedDatabaseModel
Parameter Sets: PointInTimeSameInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition
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
Parameter Sets: PointInTimeSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The instance database name to restore.

```yaml
Type: String
Parameter Sets: PointInTimeSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters
Aliases: InstanceDatabaseName

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
Parameter Sets: PointInTimeSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of Instance Database object to restore

```yaml
Type: String
Parameter Sets: PointInTimeSameInstanceRestoreInstanceDatabaseFromAzureResourceId, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetInstanceDatabaseName
The name of the target instance database to restore to.

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
If not specified, the target managed instance is the same as the source managed instance.

```yaml
Type: String
Parameter Sets: PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceGroupName
The name of the target resource group to restore to.
If not specified, the target resource group is the same as the source resource group.

```yaml
Type: String
Parameter Sets: PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureResourceId
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlManagedDatabaseModel
System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlManagedDatabaseModel

## NOTES

## RELATED LINKS
