---
external help file: Az.ElasticSan-help.xml
Module Name: Az.ElasticSan
online version: https://learn.microsoft.com/powershell/module/az.elasticsan/get-azelasticsanvolumesnapshot
schema: 2.0.0
---

# Get-AzElasticSanVolumeSnapshot

## SYNOPSIS
Get a Volume Snapshot.

## SYNTAX

### List (Default)
```
Get-AzElasticSanVolumeSnapshot -ElasticSanName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -VolumeGroupName <String> [-Filter <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzElasticSanVolumeSnapshot -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -VolumeGroupName <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentityVolumegroup
```
Get-AzElasticSanVolumeSnapshot -Name <String> -VolumegroupInputObject <IElasticSanIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentityElasticSan
```
Get-AzElasticSanVolumeSnapshot -Name <String> -VolumeGroupName <String>
 -ElasticSanInputObject <IElasticSanIdentity> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzElasticSanVolumeSnapshot -InputObject <IElasticSanIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get a Volume Snapshot.

## EXAMPLES

### Example 1: List snapshots under a volume group
```powershell
Get-AzElasticSanVolumeSnapshot -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup
```

```output
CreationDataSourceId         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/volumes/myvolume
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/snapshots/mysnap1
Name                         : mysnap1
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
VolumeName                   : myvolume

CreationDataSourceId         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/volumes/myvolume
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/snapshots/mysnap2
Name                         : mysnap2
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
SourceVolumeSizeGiB          : 1
SystemDataCreatedAt          : 10/7/2023 4:06:13 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 10/7/2023 4:06:13 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : Microsoft.ElasticSan/elasticSans/volumeGroups/snapshots
VolumeName                   : myvolume
```

This command lists all snapshots under a volume group.

### Example 2: Get a specific snapshot
```powershell
Get-AzElasticSanVolumeSnapshot -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Name mysnap1
```

```output
CreationDataSourceId         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/volumes/myvolume
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/snapshots/mysnap1
Name                         : mysnap1
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
VolumeName                   : myvolume
```

This command gets a snapshot named "mysnap1" under the volume group "myvolumegroup"

### Example 3: List snapshots of a volume with filter
```powershell
Get-AzElasticSanVolumeSnapshot -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Filter 'volumeName eq myvolume'
```

```output
CreationDataSourceId         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/volumes/myvolume
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/snapshots/mysnap1
Name                         : mysnap1
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
VolumeName                   : myvolume

CreationDataSourceId         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/volumes/myvolume
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumeGroups/myvolumegroup/snapshots/mysnap2
Name                         : mysnap2
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
SourceVolumeSizeGiB          : 1
SystemDataCreatedAt          : 10/7/2023 4:06:13 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 10/7/2023 4:06:13 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : Microsoft.ElasticSan/elasticSans/volumeGroups/snapshots
VolumeName                   : myvolume
```

This command lists snapshots of volume "myvolume" under volume group "myvolumegroup".

## PARAMETERS

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
Parameter Sets: GetViaIdentityElasticSan
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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Specify $filter='volumeName eq \<volume name\>' to filter on volume.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get, GetViaIdentityVolumegroup, GetViaIdentityElasticSan
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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, Get
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
Type: System.String[]
Parameter Sets: List, Get
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
Parameter Sets: GetViaIdentityVolumegroup
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
Parameter Sets: List, Get, GetViaIdentityElasticSan
Aliases:

Required: True
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
