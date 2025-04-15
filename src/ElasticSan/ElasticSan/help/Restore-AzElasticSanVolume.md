---
external help file: Az.ElasticSan-help.xml
Module Name: Az.ElasticSan
online version: https://learn.microsoft.com/powershell/module/az.elasticsan/restore-azelasticsanvolume
schema: 2.0.0
---

# Restore-AzElasticSanVolume

## SYNOPSIS
Restore Soft Deleted Volumes.
The volume name is obtained by using the API to list soft deleted volumes by volume group

## SYNTAX

### Restore (Default)
```
Restore-AzElasticSanVolume -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -VolumeGroupName <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreViaIdentityVolumegroup
```
Restore-AzElasticSanVolume -Name <String> -VolumegroupInputObject <IElasticSanIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RestoreViaIdentityElasticSan
```
Restore-AzElasticSanVolume -Name <String> -VolumeGroupName <String>
 -ElasticSanInputObject <IElasticSanIdentity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreViaIdentity
```
Restore-AzElasticSanVolume -InputObject <IElasticSanIdentity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Restore Soft Deleted Volumes.
The volume name is obtained by using the API to list soft deleted volumes by volume group

## EXAMPLES

### Example 1: Restore a soft deleted volume
```powershell
$deletevolume = Get-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -AccessSoftDeletedResource true
Restore-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -VolumeName $deletevolume[0].Name
```

```output
CreationDataCreateSource       : None
CreationDataSourceId           :
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup/volumes/myvolume
ManagedByResourceId            : None
Name                           : myvolume
ProvisioningState              : Succeeded
ResourceGroupName              : myresourcegroup
SizeGiB                        : 12
StorageTargetIqn               : iqn.2025-04.net.azure.storage.blob.z29.es-ddmmw4sqemc1:es-cb1d1bizlds0:myvolume
StorageTargetPortalHostname    : es-cb1d1bizlds0.z1.blob.storage.azure.net
StorageTargetPortalPort        : 3260
StorageTargetProvisioningState : Succeeded
StorageTargetStatus            : Running
SystemDataCreatedAt            : 4/8/2025 7:53:46 AM
SystemDataCreatedBy            : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType        : User
SystemDataLastModifiedAt       : 4/8/2025 7:53:46 AM
SystemDataLastModifiedBy       : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType   : User
Type                           : Microsoft.ElasticSan/elasticSans/volumeGroups/volumes
VolumeId                       : abababab-abab-abab-abab-abababababab
```

This command restores a specific volume.

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

### -ElasticSanInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: RestoreViaIdentityElasticSan
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
Parameter Sets: Restore
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
Parameter Sets: RestoreViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Volume.

```yaml
Type: System.String
Parameter Sets: Restore, RestoreViaIdentityVolumegroup, RestoreViaIdentityElasticSan
Aliases: VolumeName

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
Parameter Sets: Restore
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
Parameter Sets: Restore
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
Parameter Sets: RestoreViaIdentityVolumegroup
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
Parameter Sets: Restore, RestoreViaIdentityElasticSan
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

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IVolume

## NOTES

## RELATED LINKS
