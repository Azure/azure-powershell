---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/restore-azsqlinstancedatabase
schema: 2.0.0
---

# Restore-AzSqlInstanceDatabase

## SYNOPSIS
Restores an Azure SQL Managed Instance database.

## SYNTAX

### PointInTimeSameInstanceRestoreInstanceDatabaseFromInputParameters (Default)
```
Restore-AzSqlInstanceDatabase [-FromPointInTimeBackup] [-SubscriptionId <String>] [-ResourceGroupName] <String>
 [-InstanceName] <String> [-Name] <String> -PointInTime <DateTime> -TargetInstanceDatabaseName <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PointInTimeSameInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition
```
Restore-AzSqlInstanceDatabase [-FromPointInTimeBackup] [-InputObject] <AzureSqlManagedDatabaseBaseModel>
 -PointInTime <DateTime> -TargetInstanceDatabaseName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PointInTimeSameInstanceRestoreInstanceDatabaseFromAzureResourceId
```
Restore-AzSqlInstanceDatabase [-FromPointInTimeBackup] [-ResourceId] <String> -PointInTime <DateTime>
 -TargetInstanceDatabaseName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters
```
Restore-AzSqlInstanceDatabase [-FromPointInTimeBackup] [-SubscriptionId <String>] [-ResourceGroupName] <String>
 [-InstanceName] <String> [-Name] <String> -PointInTime <DateTime> -TargetInstanceDatabaseName <String>
 -TargetInstanceName <String> -TargetResourceGroupName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition
```
Restore-AzSqlInstanceDatabase [-FromPointInTimeBackup] [-InputObject] <AzureSqlManagedDatabaseBaseModel>
 -PointInTime <DateTime> -TargetInstanceDatabaseName <String> -TargetInstanceName <String>
 -TargetResourceGroupName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureResourceId
```
Restore-AzSqlInstanceDatabase [-FromPointInTimeBackup] [-ResourceId] <String> -PointInTime <DateTime>
 -TargetInstanceDatabaseName <String> -TargetInstanceName <String> -TargetResourceGroupName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PointInTimeDeletedDatabasesSameInstanceRestoreInstanceDatabaseFromInputParameters
```
Restore-AzSqlInstanceDatabase [-FromPointInTimeBackup] [-SubscriptionId <String>] [-ResourceGroupName] <String>
 [-InstanceName] <String> [-Name] <String> [-DeletionDate] <DateTime> -PointInTime <DateTime>
 -TargetInstanceDatabaseName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PointInTimeDeletedDatabasesCrossInstanceRestoreInstanceDatabaseFromInputParameters
```
Restore-AzSqlInstanceDatabase [-FromPointInTimeBackup] [-SubscriptionId <String>] [-ResourceGroupName] <String>
 [-InstanceName] <String> [-Name] <String> [-DeletionDate] <DateTime> -PointInTime <DateTime>
 -TargetInstanceDatabaseName <String> -TargetInstanceName <String> -TargetResourceGroupName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PointInTimeCrossSubscriptionRestoreFromNameAndResourceGroup
```
Restore-AzSqlInstanceDatabase [-FromPointInTimeBackup] -SubscriptionId <String> [-ResourceGroupName] <String>
 [-InstanceName] <String> [-Name] <String> -PointInTime <DateTime> -TargetInstanceDatabaseName <String>
 -TargetInstanceName <String> -TargetResourceGroupName <String> -TargetSubscriptionId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PointInTimeCrossSubscriptionRestoreFromInputObjectParameter
```
Restore-AzSqlInstanceDatabase [-FromPointInTimeBackup] [-InputObject] <AzureSqlManagedDatabaseBaseModel>
 -PointInTime <DateTime> -TargetInstanceDatabaseName <String> -TargetInstanceName <String>
 -TargetResourceGroupName <String> -TargetSubscriptionId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PointInTimeCrossSubscriptionRestoreFromResourceIdParameter
```
Restore-AzSqlInstanceDatabase [-FromPointInTimeBackup] [-ResourceId] <String> -PointInTime <DateTime>
 -TargetInstanceDatabaseName <String> -TargetInstanceName <String> -TargetResourceGroupName <String>
 -TargetSubscriptionId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PointInTimeDeletedCrossSubscriptionRestoreFromNameAndResourceGroup
```
Restore-AzSqlInstanceDatabase [-FromPointInTimeBackup] -SubscriptionId <String> [-ResourceGroupName] <String>
 [-InstanceName] <String> [-Name] <String> [-DeletionDate] <DateTime> -PointInTime <DateTime>
 -TargetInstanceDatabaseName <String> -TargetInstanceName <String> -TargetResourceGroupName <String>
 -TargetSubscriptionId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### GeoRestoreFromGeoBackupSetNameFromGeoBackupObjectParameter
```
Restore-AzSqlInstanceDatabase [-FromGeoBackup] [-GeoBackupObject] <AzureSqlRecoverableManagedDatabaseModel>
 -TargetInstanceDatabaseName <String> -TargetInstanceName <String> -TargetResourceGroupName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GeoRestoreFromGeoBackupSetNameFromResourceIdParameter
```
Restore-AzSqlInstanceDatabase [-FromGeoBackup] [-ResourceId] <String> -TargetInstanceDatabaseName <String>
 -TargetInstanceName <String> -TargetResourceGroupName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GeoRestoreFromGeoBackupSetNameFromNameAndResourceGroupParameter
```
Restore-AzSqlInstanceDatabase [-FromGeoBackup] [-ResourceGroupName] <String> [-InstanceName] <String>
 [-Name] <String> -TargetInstanceDatabaseName <String> -TargetInstanceName <String>
 -TargetResourceGroupName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### LongTermRetentionBackupRestoreParameter
```
Restore-AzSqlInstanceDatabase [-FromLongTermRetentionBackup] [-SubscriptionId <String>] [-ResourceId] <String>
 -TargetInstanceDatabaseName <String> -TargetInstanceName <String> -TargetResourceGroupName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Restore-AzSqlInstanceDatabase** cmdlet restores an instance database from a geo-redundant backup, a point in time in a live database, or a long term retention backup.
The restored database is created as a new instance database.

## EXAMPLES

### Example 1: Restore an instance database from a point in time
```powershell
Restore-AzSqlInstanceDatabase -Name "Database01" -InstanceName "managedInstance1" -ResourceGroupName "ResourceGroup01" -PointInTime UTCDateTime -TargetInstanceDatabaseName "Database01_restored"
```

The command restores the instance database Database01 from the specified point-in-time backup to the instance database named Database01_restored.

### Example 2: Restore an instance database from a point in time to another instance on different resource group
```powershell
Restore-AzSqlInstanceDatabase -Name "Database01" -InstanceName "managedInstance1" -ResourceGroupName "ResourceGroup01" -PointInTime UTCDateTime -TargetInstanceDatabaseName "Database01_restored" -TargetInstanceName "managedInstance1" -TargetResourceGroupName "ResourceGroup02"
```

The command restores the instance database Database01 on instance managedInstance1 on resource group ResourceGroup01 from the specified point-in-time backup to the instance database named Database01_restored on instance managedInstance2 on resource group ResourceGroup02.

### Example 3: Geo-Restore an instance database
```powershell
$GeoBackup = Get-AzSqlInstanceDatabaseGeoBackup -ResourceGroupName "ResourceGroup01" -InstanceName "managedInstance1" -Name "Database01"
$GeoBackup | Restore-AzSqlInstanceDatabase -FromGeoBackup -TargetInstanceDatabaseName "Database01_restored" -TargetInstanceName "managedInstance2" -TargetResourceGroupName "ResourceGroup02"
```

The first command gets the geo-redundant backup for the database named Database01, and then stores it in the $GeoBackup variable.
The second command restores the backup in $GeoBackup to the instance database named Database01_restored.

### Example 4: Restore a deleted instance database from a point in time
```powershell
$deletedDatabase = Get-AzSqlDeletedInstanceDatabaseBackup -ResourceGroupName "ResourceGroup01" -InstanceName "managedInstance1" -DatabaseName "DB1"
Restore-AzSqlInstanceDatabase -FromPointInTimeBackup -Name $deletedDatabase.Name -InstanceName $deletedDatabase.ManagedInstanceName -ResourceGroupName $deletedDatabase.ResourceGroupName -DeletionDate $deletedDatabase.DeletionDate -PointInTime UTCDateTime -TargetInstanceDatabaseName "Database01_restored"
```

The first command gets the deleted instance databases named 'DB1' on Instance 'managedInstance1'.
The second command restores the fetched database, from the specified point-in-time backup to the instance database named Database01_restored.

### Example 5: Restore a deleted instance database from a point in time
```powershell
$deletedDatabase = Get-AzSqlDeletedInstanceDatabaseBackup -ResourceGroupName "ResourceGroup01" -InstanceName "managedInstance1" -DatabaseName "DB1"
Restore-AzSqlInstanceDatabase -FromPointInTimeBackup -InputObject $deletedDatabase[0] -PointInTime UTCDateTime -TargetInstanceDatabaseName "Database01_restored"
```

The first command gets the deleted instance databases named 'DB1' on Instance 'managedInstance1'.
The second command restores the fetched database, from the specified point-in-time backup to the instance database named Database01_restored using input object.

### Example 6: Restore a database from LTR backup.
```powershell
Restore-AzSqlInstanceDatabase -FromLongTermRetentionBackup -ResourceId "/subscriptions/f46521f3-5bb0-4eea-a3c2-c2d5987df96b/resourceGroups/testResourceGroup/providers/Microsoft.Sql/locations/southeastasia/longTermRetentionManagedInstances/testInstance/longTermRetentionDatabases/test/longTermRetentionManagedInstanceBackups/15be823c-7e2c-49d8-819f-a3fdcad92215;132268250550000000" -TargetInstanceDatabaseName "restoreTarget" -TargetInstanceName "testInstance" -TargetResourceGroupName "testResourceGroup"
```

```output
Location                          : southeastasia
Tags                              :
Collation                         : SQL_Latin1_General_CP1_CI_AS
Status                            : Online
RestorePointInTime                :
DefaultSecondaryLocation          : northeurope
CatalogCollation                  :
CreateMode                        :
StorageContainerUri               :
StorageContainerSasToken          :
SourceDatabaseId                  :
FailoverGroupId                   :
RecoverableDatabaseId             :
RestorableDroppedDatabaseId       :
LongTermRetentionBackupResourceId :
ResourceGroupName                 : testResourceGroup
ManagedInstanceName               : testInstance
Name                              : restoreTarget
CreationDate                      : 3/4/2020 8:12:56 AM
EarliestRestorePoint              : 3/4/2020 8:14:29 AM
Id                                : /subscriptions/f46521f3-5bb0-4eea-a3c2-c2d5987df96b/resourceGroups/testResourceGroup/providers/Microsoft.Sql/managedInstances/testInstance/databases/restoreTarget
```

Restores LTR backup with the given resource ID (which can be found by running Get-AzSqlInstanceDatabaseLongTermRetentionBackup).

### Example 7. Restore database from different subscription
```powershell
Restore-AzSqlInstanceDatabase -FromPointInTimeBackup `
			-SubscriptionId "sourceSubscriptionID" `
			-ResourceGroupName "sourceRGName" `
			-InstanceName "sourceManagedInstanceName" `
			-Name "sourceDatabaseName" `
			-PointInTime $pointInTime `
			-TargetInstanceDatabaseName "targetDatabaseName" `
			-TargetInstanceName "targetManagedInstanceName" `
			-TargetResourceGroupName "targetResourceGroupName" `
			-TargetSubscriptionId "targetSubscriptionId"
```
The command restores database backup from instance in one subscription to database `targetDatabaseName` on instance `targetManagedInstanceName` to different subscription `targetSubscriptionId`.

### Example 8. Restore database from different subscription using source object and pipping
```powershell
Set-AzContext -SubscriptionId "sourceSubscriptionId"
$sourceDatabase = Get-AzSqlInstanceDatabase -Name "sourceDatabaseName" -InstanceName "sourceManagedInstanceName" -ResourceGroupName "sourceRGName"

Set-AzContext -SubscriptionId "targetSubscriptionId"
$sourceDatabase | Restore-AzSqlInstanceDatabase -FromPointInTimeBackup `
			-PointInTime $pointInTime `
			-TargetInstanceDatabaseName "targetDatabaseName" `
			-TargetInstanceName "targetManagedInstanceName" `
			-TargetResourceGroupName "targetResourceGroupName" `
			-TargetSubscriptionId "targetSubscriptionId"
```
First command gets source managed database object and stores in variable sourceDatabase.
Second command executes restore from source to the given target database using point in time restore.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure

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

### -DeletionDate
The deletion date of deleted database.

```yaml
Type: System.DateTime
Parameter Sets: PointInTimeDeletedDatabasesSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeDeletedDatabasesCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeDeletedCrossSubscriptionRestoreFromNameAndResourceGroup
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FromGeoBackup
Restore from a geo backup.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GeoRestoreFromGeoBackupSetNameFromGeoBackupObjectParameter, GeoRestoreFromGeoBackupSetNameFromResourceIdParameter, GeoRestoreFromGeoBackupSetNameFromNameAndResourceGroupParameter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FromLongTermRetentionBackup
Restore from a Long Term Retention backup.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: LongTermRetentionBackupRestoreParameter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FromPointInTimeBackup
Restore from a point-in-time backup.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PointInTimeSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeSameInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition, PointInTimeSameInstanceRestoreInstanceDatabaseFromAzureResourceId, PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureResourceId, PointInTimeDeletedDatabasesSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeDeletedDatabasesCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossSubscriptionRestoreFromNameAndResourceGroup, PointInTimeCrossSubscriptionRestoreFromInputObjectParameter, PointInTimeCrossSubscriptionRestoreFromResourceIdParameter, PointInTimeDeletedCrossSubscriptionRestoreFromNameAndResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GeoBackupObject
The recoverable instance database object to restore

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlRecoverableManagedDatabaseModel
Parameter Sets: GeoRestoreFromGeoBackupSetNameFromGeoBackupObjectParameter
Aliases: RecoverableInstanceDatabase

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
The Instance Database object to restore

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlManagedDatabaseBaseModel
Parameter Sets: PointInTimeSameInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition, PointInTimeCrossSubscriptionRestoreFromInputObjectParameter
Aliases: InstanceDatabase

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceName
The instance name.

```yaml
Type: System.String
Parameter Sets: PointInTimeSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeDeletedDatabasesSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeDeletedDatabasesCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossSubscriptionRestoreFromNameAndResourceGroup, PointInTimeDeletedCrossSubscriptionRestoreFromNameAndResourceGroup, GeoRestoreFromGeoBackupSetNameFromNameAndResourceGroupParameter
Aliases: SourceInstanceName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The instance database name to restore.

```yaml
Type: System.String
Parameter Sets: PointInTimeSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeDeletedDatabasesSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeDeletedDatabasesCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossSubscriptionRestoreFromNameAndResourceGroup, PointInTimeDeletedCrossSubscriptionRestoreFromNameAndResourceGroup, GeoRestoreFromGeoBackupSetNameFromNameAndResourceGroupParameter
Aliases: InstanceDatabaseName, SourceInstanceDatabaseName

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PointInTime
The point in time to restore the database to.

```yaml
Type: System.DateTime
Parameter Sets: PointInTimeSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeSameInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition, PointInTimeSameInstanceRestoreInstanceDatabaseFromAzureResourceId, PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureResourceId, PointInTimeDeletedDatabasesSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeDeletedDatabasesCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossSubscriptionRestoreFromNameAndResourceGroup, PointInTimeCrossSubscriptionRestoreFromInputObjectParameter, PointInTimeCrossSubscriptionRestoreFromResourceIdParameter, PointInTimeDeletedCrossSubscriptionRestoreFromNameAndResourceGroup
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
Type: System.String
Parameter Sets: PointInTimeSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeDeletedDatabasesSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeDeletedDatabasesCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossSubscriptionRestoreFromNameAndResourceGroup, PointInTimeDeletedCrossSubscriptionRestoreFromNameAndResourceGroup, GeoRestoreFromGeoBackupSetNameFromNameAndResourceGroupParameter
Aliases: SourceResourceGroupName

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of Instance Database object to restore

```yaml
Type: System.String
Parameter Sets: PointInTimeSameInstanceRestoreInstanceDatabaseFromAzureResourceId, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureResourceId, PointInTimeCrossSubscriptionRestoreFromResourceIdParameter, LongTermRetentionBackupRestoreParameter
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: GeoRestoreFromGeoBackupSetNameFromResourceIdParameter
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionId
Source subscription id.

```yaml
Type: System.String
Parameter Sets: PointInTimeSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeDeletedDatabasesSameInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeDeletedDatabasesCrossInstanceRestoreInstanceDatabaseFromInputParameters, LongTermRetentionBackupRestoreParameter
Aliases: SourceSubscriptionId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: PointInTimeCrossSubscriptionRestoreFromNameAndResourceGroup, PointInTimeDeletedCrossSubscriptionRestoreFromNameAndResourceGroup
Aliases: SourceSubscriptionId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetInstanceDatabaseName
The name of the target instance database to restore to.

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

### -TargetInstanceName
The name of the target instance to restore to.
If not specified, the target instance is the same as the source instance.

```yaml
Type: System.String
Parameter Sets: PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureResourceId, PointInTimeDeletedDatabasesCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossSubscriptionRestoreFromNameAndResourceGroup, PointInTimeCrossSubscriptionRestoreFromInputObjectParameter, PointInTimeCrossSubscriptionRestoreFromResourceIdParameter, PointInTimeDeletedCrossSubscriptionRestoreFromNameAndResourceGroup, GeoRestoreFromGeoBackupSetNameFromGeoBackupObjectParameter, GeoRestoreFromGeoBackupSetNameFromResourceIdParameter, GeoRestoreFromGeoBackupSetNameFromNameAndResourceGroupParameter, LongTermRetentionBackupRestoreParameter
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
Type: System.String
Parameter Sets: PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition, PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureResourceId, PointInTimeDeletedDatabasesCrossInstanceRestoreInstanceDatabaseFromInputParameters, PointInTimeCrossSubscriptionRestoreFromNameAndResourceGroup, PointInTimeCrossSubscriptionRestoreFromInputObjectParameter, PointInTimeCrossSubscriptionRestoreFromResourceIdParameter, PointInTimeDeletedCrossSubscriptionRestoreFromNameAndResourceGroup, GeoRestoreFromGeoBackupSetNameFromGeoBackupObjectParameter, GeoRestoreFromGeoBackupSetNameFromResourceIdParameter, GeoRestoreFromGeoBackupSetNameFromNameAndResourceGroupParameter, LongTermRetentionBackupRestoreParameter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetSubscriptionId
The name of the target subscription id to restore to.

```yaml
Type: System.String
Parameter Sets: PointInTimeCrossSubscriptionRestoreFromNameAndResourceGroup, PointInTimeCrossSubscriptionRestoreFromInputObjectParameter, PointInTimeCrossSubscriptionRestoreFromResourceIdParameter, PointInTimeDeletedCrossSubscriptionRestoreFromNameAndResourceGroup
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlManagedDatabaseBaseModel

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlRecoverableManagedDatabaseModel

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlManagedDatabaseModel

## NOTES

## RELATED LINKS
