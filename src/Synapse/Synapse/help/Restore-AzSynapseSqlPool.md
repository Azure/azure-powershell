---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/restore-azsynapsesqlpool
schema: 2.0.0
---

# Restore-AzSynapseSqlPool

## SYNOPSIS
Restores a Synapse Analytics SQL pool.

## SYNTAX

### RestoreFromBackupIdByNameParameterSet (Default)
```
Restore-AzSynapseSqlPool [-FromBackup] [-ResourceGroupName <String>] -WorkspaceName <String> -Name <String>
 -ResourceId <String> [-Tag <Hashtable>] [-StorageAccountType <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RestoreFromBackupIdByParentObjectParameterSet
```
Restore-AzSynapseSqlPool [-FromBackup] -WorkspaceObject <PSSynapseWorkspace> -Name <String>
 -ResourceId <String> [-Tag <Hashtable>] [-StorageAccountType <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RestoreFromRestorePointIdByNameParameterSet
```
Restore-AzSynapseSqlPool [-FromRestorePoint] [-ResourceGroupName <String>] -WorkspaceName <String>
 -Name <String> -PerformanceLevel <String> -ResourceId <String> -RestorePoint <DateTime> [-Tag <Hashtable>]
 [-StorageAccountType <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreFromRestorePointIdByParentObjectParameterSet
```
Restore-AzSynapseSqlPool [-FromRestorePoint] -WorkspaceObject <PSSynapseWorkspace> -Name <String>
 -PerformanceLevel <String> -ResourceId <String> -RestorePoint <DateTime> [-Tag <Hashtable>]
 [-StorageAccountType <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreFromDroppedSqlPoolByNameParameterSet
```
Restore-AzSynapseSqlPool [-FromDroppedSqlPool] [-ResourceGroupName <String>] -WorkspaceName <String>
 -Name <String> -ResourceId <String> -DeletionDate <DateTime> [-Tag <Hashtable>] [-StorageAccountType <String>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RestoreFromDroppedSqlPoolByParentObjectParameterSet
```
Restore-AzSynapseSqlPool [-FromDroppedSqlPool] -WorkspaceObject <PSSynapseWorkspace> -Name <String>
 -ResourceId <String> -DeletionDate <DateTime> [-Tag <Hashtable>] [-StorageAccountType <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Restore-AzSynapseSqlPool** cmdlet restores an Azure Synapse Analytics SQL pool from a geo-redundant backup, a backup of a deleted SQL pool or a restore point of any SQL pool.
The restored SQL pool is created as a new SQL pool.

## EXAMPLES

### Example 1
```powershell
# Transform Synapse SQL pool resource ID to SQL database ID because 
# currently the command only accepts the SQL databse ID. For example: /subscriptions/<SubscriptionId>/resourceGroups/<ResourceGroupName>/providers/Microsoft.Sql/servers/<WorkspaceName>/databases/<DatabaseName>
$pool = Get-AzSynapseSqlPool -ResourceGroupName ContosoResourceGroup -WorkspaceName ContosoWorkspace -Name ContosoSqlPool
$databaseId = $pool.Id -replace "Microsoft.Synapse", "Microsoft.Sql" `
	-replace "workspaces", "servers" `
	-replace "sqlPools", "databases"
 
# Get the latest restore point
$restorePoint = $pool | Get-AzSynapseSqlPoolRestorePoint | Select-Object -Last 1

# Restore to same workspace with source SQL pool
$restoredPool = Restore-AzSynapseSqlPool -FromRestorePoint -RestorePoint $restorePoint.RestorePointCreationDate -TargetSqlPoolName ContosoRestoredSqlPool -ResourceGroupName $pool.ResourceGroupName -WorkspaceName $pool.WorkspaceName -ResourceId $databaseId -PerformanceLevel DW200c
```

This command creates an Azure Synapse Analytics SQL pool by leveraging a restore point from any existing SQL pool to recover or copy from a previous state.

### Example 2
```powershell
# Transform Synapse SQL pool resource ID to SQL database ID because
# currently the command only accepts the SQL databse ID. For example: /subscriptions/<SubscriptionId>/resourceGroups/<ResourceGroupName>/providers/Microsoft.Sql/servers/<WorkspaceName>/recoverabledatabases/<DatabaseName>
$pool = Get-AzSynapseSqlPoolGeoBackup -ResourceGroupName ContosoResourceGroup -WorkspaceName ContosoWorkspace -Name ContosoSqlPool
$databaseId = $pool.Id -replace "Microsoft.Synapse", "Microsoft.Sql" `
    -replace "workspaces", "servers"

# Restore to same workspace with source SQL pool
$restoredPool = Restore-AzSynapseSqlPool -FromBackup -TargetSqlPoolName ContosoRestoredSqlPool -ResourceGroupName $pool.ResourceGroupName -WorkspaceName $pool.WorkspaceName -ResourceId $databaseId
```

This command creates an Azure Synapse Analytics SQL pool which restores from the SQL pool backup.

### Example 3
```powershell
# Transform Synapse dropped SQL pool resource ID to SQL pool resource ID
$pool = Get-AzSynapseDroppedSqlPool -ResourceGroupName ContosoResourceGroup -WorkspaceName ContosoWorkspace -Name ContosoSqlPool
$poolId = $pool.Id.Split(",")[0]
$poolId = $poolId -replace "restorableDroppedSqlPools", "sqlPools"

# Restore to same workspace with source SQL pool
$restoredPool = Restore-AzSynapseSqlPool -FromDroppedSqlPool -DeletionDate $pool.DeletionDate -TargetSqlPoolName ContosoRestoredSqlPool -ResourceGroupName $pool.ResourceGroupName -WorkspaceName $pool.WorkspaceName -ResourceId $poolId
```

This command creates an Azure Synapse Analytics SQL pool which restores from the deleted SQL pool backup.

### Example 4
```powershell
# Transform Synapse SQL pool resource ID to SQL database ID because 
# currently the command only accepts the SQL databse ID. For example: /subscriptions/<SubscriptionId>/resourceGroups/<ResourceGroupName>/providers/Microsoft.Sql/servers/<WorkspaceName>/databases/<DatabaseName>
$pool = Get-AzSynapseSqlPool -ResourceGroupName ContosoResourceGroup -WorkspaceName ContosoWorkspace -Name ContosoSqlPool
$databaseId = $pool.Id -replace "Microsoft.Synapse", "Microsoft.Sql" `
	-replace "workspaces", "servers" `
	-replace "sqlPools", "databases"

# Get the latest restore point
$restorePoint = $pool | Get-AzSynapseSqlPoolRestorePoint | Select-Object -Last 1

# Restore to same workspace with source SQL pool
$restoredPool = Restore-AzSynapseSqlPool -FromRestorePoint -RestorePoint $restorePoint.RestorePointCreationDate -TargetSqlPoolName ContosoRestoredSqlPool -ResourceGroupName $pool.ResourceGroupName -WorkspaceName $pool.WorkspaceName -ResourceId $databaseId -PerformanceLevel DW200c -Tag @{"tagName" = "tagValue"} -StorageAccountType LRS
```

This command creates an Azure Synapse Analytics SQL pool with specified tags and storage account type by leveraging a restore point from any existing SQL pool to recover or copy from a previous state.

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

### -DeletionDate
The deletion date of the Azure Synaspe SQL Database to retrieve backups for, with millisecond precision (e.g. 2016-02-23T00:21:22.847Z)

```yaml
Type: System.DateTime
Parameter Sets: RestoreFromDroppedSqlPoolByNameParameterSet, RestoreFromDroppedSqlPoolByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FromBackup
Indicates to restore from the most recent backup of any SQL pool in this subscription.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RestoreFromBackupIdByNameParameterSet, RestoreFromBackupIdByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FromDroppedSqlPool
Indicates to leverage a restore point from any SQL pool in this subscription to recover or copy from a previous state.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RestoreFromDroppedSqlPoolByNameParameterSet, RestoreFromDroppedSqlPoolByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FromRestorePoint
Indicates to leverage a restore point from any SQL pool in this subscription to recover or copy from a previous state.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RestoreFromRestorePointIdByNameParameterSet, RestoreFromRestorePointIdByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Synapse SQL pool.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: TargetSqlPoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PerformanceLevel
The SQL Service tier and performance level to assign to the SQL pool.
For example, DW2000c.

```yaml
Type: System.String
Parameter Sets: RestoreFromRestorePointIdByNameParameterSet, RestoreFromRestorePointIdByParentObjectParameterSet
Aliases:

Required: True
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
Resource group name.

```yaml
Type: System.String
Parameter Sets: RestoreFromBackupIdByNameParameterSet, RestoreFromRestorePointIdByNameParameterSet, RestoreFromDroppedSqlPoolByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource ID of the database to restore.

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

### -RestorePoint
Snapshot time to restore.

```yaml
Type: System.DateTime
Parameter Sets: RestoreFromRestorePointIdByNameParameterSet, RestoreFromRestorePointIdByParentObjectParameterSet
Aliases: PointInTime

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountType
The storage account type used to store backups for the sql pool. Possible values include: 'GRS', 'LRS'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: GRS, LRS

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
A string,string dictionary of tags associated with the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
Name of Synapse workspace.

```yaml
Type: System.String
Parameter Sets: RestoreFromBackupIdByNameParameterSet, RestoreFromRestorePointIdByNameParameterSet, RestoreFromDroppedSqlPoolByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceObject
workspace input object, usually passed through the pipeline.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace
Parameter Sets: RestoreFromBackupIdByParentObjectParameterSet, RestoreFromRestorePointIdByParentObjectParameterSet, RestoreFromDroppedSqlPoolByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace

## OUTPUTS

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseSqlPool

## NOTES

## RELATED LINKS
