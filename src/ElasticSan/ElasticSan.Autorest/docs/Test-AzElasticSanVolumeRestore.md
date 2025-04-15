---
external help file:
Module Name: Az.ElasticSan
online version: https://learn.microsoft.com/powershell/module/az.elasticsan/test-azelasticsanvolumerestore
schema: 2.0.0
---

# Test-AzElasticSanVolumeRestore

## SYNOPSIS
Validate whether a list of backed up disk snapshots can be restored into ElasticSan volumes.

## SYNTAX

### RestoreExpanded (Default)
```
Test-AzElasticSanVolumeRestore -ElasticSanName <String> -ResourceGroupName <String> -VolumeGroupName <String>
 -DiskSnapshotId <String[]> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Restore
```
Test-AzElasticSanVolumeRestore -ElasticSanName <String> -ResourceGroupName <String> -VolumeGroupName <String>
 -Parameter <IDiskSnapshotList> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaIdentity
```
Test-AzElasticSanVolumeRestore -InputObject <IElasticSanIdentity> -Parameter <IDiskSnapshotList>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaIdentityElasticSan
```
Test-AzElasticSanVolumeRestore -ElasticSanInputObject <IElasticSanIdentity> -VolumeGroupName <String>
 -Parameter <IDiskSnapshotList> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RestoreViaIdentityElasticSanExpanded
```
Test-AzElasticSanVolumeRestore -ElasticSanInputObject <IElasticSanIdentity> -VolumeGroupName <String>
 -DiskSnapshotId <String[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RestoreViaIdentityExpanded
```
Test-AzElasticSanVolumeRestore -InputObject <IElasticSanIdentity> -DiskSnapshotId <String[]>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaJsonFilePath
```
Test-AzElasticSanVolumeRestore -ElasticSanName <String> -ResourceGroupName <String> -VolumeGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### RestoreViaJsonString
```
Test-AzElasticSanVolumeRestore -ElasticSanName <String> -ResourceGroupName <String> -VolumeGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validate whether a list of backed up disk snapshots can be restored into ElasticSan volumes.

## EXAMPLES

### Example 1: Validate whether a list of backed up disk snapshots can be restored into ElasticSan volumes.
```powershell
Test-AzElasticSanVolumeRestore -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -DiskSnapshotId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Compute/snapshots/mydisksnapshot"
```

```output
ValidationStatus
----------------
Success
```

This command validates whether a list of backed up disk snapshots can be restored into ElasticSan volumes.

## PARAMETERS

### -AsJob
Run the command as a job

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
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskSnapshotId
array of DiskSnapshot ARM IDs

```yaml
Type: System.String[]
Parameter Sets: RestoreExpanded, RestoreViaIdentityElasticSanExpanded, RestoreViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ElasticSanInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: RestoreViaIdentityElasticSan, RestoreViaIdentityElasticSanExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ElasticSanName
The name of the ElasticSan.

```yaml
Type: System.String
Parameter Sets: Restore, RestoreExpanded, RestoreViaJsonFilePath, RestoreViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: RestoreViaIdentity, RestoreViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Restore operation

```yaml
Type: System.String
Parameter Sets: RestoreViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Restore operation

```yaml
Type: System.String
Parameter Sets: RestoreViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -Parameter
object to hold array of Disk Snapshot ARM IDs

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IDiskSnapshotList
Parameter Sets: Restore, RestoreViaIdentity, RestoreViaIdentityElasticSan
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Restore, RestoreExpanded, RestoreViaJsonFilePath, RestoreViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Restore, RestoreExpanded, RestoreViaJsonFilePath, RestoreViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VolumeGroupName
The name of the VolumeGroup.

```yaml
Type: System.String
Parameter Sets: Restore, RestoreExpanded, RestoreViaIdentityElasticSan, RestoreViaIdentityElasticSanExpanded, RestoreViaJsonFilePath, RestoreViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IDiskSnapshotList

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IPreValidationResponse

## NOTES

## RELATED LINKS

