---
external help file:
Module Name: Az.ElasticSan
online version: https://learn.microsoft.com/powershell/module/az.elasticsan/new-azelasticsanvolumesnapshot
schema: 2.0.0
---

# New-AzElasticSanVolumeSnapshot

## SYNOPSIS
Create a Volume Snapshot.

## SYNTAX

### CreateExpanded (Default)
```
New-AzElasticSanVolumeSnapshot -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 -VolumeGroupName <String> -CreationDataSourceId <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityElasticSanExpanded
```
New-AzElasticSanVolumeSnapshot -ElasticSanInputObject <IElasticSanIdentity> -Name <String>
 -VolumeGroupName <String> -CreationDataSourceId <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzElasticSanVolumeSnapshot -InputObject <IElasticSanIdentity> -CreationDataSourceId <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityVolumegroupExpanded
```
New-AzElasticSanVolumeSnapshot -Name <String> -VolumegroupInputObject <IElasticSanIdentity>
 -CreationDataSourceId <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Volume Snapshot.

## EXAMPLES

### Example 1: Create a volume snapshot 
```powershell
 $volume = New-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Name myvolume -SizeGiB 1
 New-AzElasticSanVolumeSnapshot -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -CreationDataSourceId $volume.Id -Name mysnapshot
```

```output
CreationDataSourceId         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/volumes/myvolume
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/snapshots/mysnapshot
Name                         : mysnapshot
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
SourceVolumeSizeGiB          : 1
SystemDataCreatedAt          : 10/7/2023 3:37:01 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 10/7/2023 3:37:01 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : Microsoft.ElasticSan/elasticSans/volumeGroups/snapshots
VolumeName                   : testvol1
```

The first command creates a volume, and the second command creates a snapshot of the volume.

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

### -CreationDataSourceId
Fully qualified resource ID of the volume.
E.g.
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ElasticSan/elasticSans/{elasticSanName}/volumegroups/{volumeGroupName}/volumes/{volumeName}"

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

### -ElasticSanInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: CreateViaIdentityElasticSanExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the volume snapshot within the given volume group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityElasticSanExpanded, CreateViaIdentityVolumegroupExpanded
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VolumegroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: CreateViaIdentityVolumegroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VolumeGroupName
The name of the VolumeGroup.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityElasticSanExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.ISnapshot

## NOTES

## RELATED LINKS

