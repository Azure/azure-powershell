---
external help file:
Module Name: Az.ElasticSan
online version: https://docs.microsoft.com/powershell/module/az.elasticsan/get-azelasticsanvolume
schema: 2.0.0
---

# Get-AzElasticSanVolume

## SYNOPSIS
Get either a list of all volumes from a volume group or get a single volume from a volume group.

## SYNTAX

### List (Default)
```
Get-AzElasticSanVolume -ElasticSanName <String> -ResourceGroupName <String> -VolumeGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzElasticSanVolume -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 -VolumeGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzElasticSanVolume -InputObject <IElasticSanIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get either a list of all volumes from a volume group or get a single volume from a volume group.

## EXAMPLES

### Example 1: Get all volumes in a volume group
```powershell
Get-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup
```

```output
CreationDataCreateSource       : 
CreationDataSourceUri          : 
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup/volumes/myvolume1
Name                           : myvolume1
SizeGiB                        : 120
StorageTargetIqn               : iqn.2022-09.net.windows.core.blob.ElasticSan.es-3ibot5m2r3y0:myvolume1
StorageTargetPortalHostname    : es-3ibot5m2r3y0.z1.blob.storage.azure.net
StorageTargetPortalPort        : 3260
StorageTargetProvisioningState : Succeeded
StorageTargetStatus            : Running
SystemDataCreatedAt            : 9/19/2022 2:39:28 AM
SystemDataCreatedBy            : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType        : Application
SystemDataLastModifiedAt       : 9/19/2022 2:39:28 AM
SystemDataLastModifiedBy       : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType   : Application
Tag                            : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
Type                           : Microsoft.ElasticSan/ElasticSans
VolumeId                       : abababab-abab-abab-abab-abababababab

CreationDataCreateSource       : 
CreationDataSourceUri          : 
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup/volumes/myvolume2
Name                           : myvolume2
SizeGiB                        : 100
StorageTargetIqn               : iqn.2022-09.net.windows.core.blob.ElasticSan.es-3ibot5m2r3y0:myvolume2
StorageTargetPortalHostname    : es-3ibot5m2r3y0.z1.blob.storage.azure.net
StorageTargetPortalPort        : 3260
StorageTargetProvisioningState : Succeeded
StorageTargetStatus            : Running
SystemDataCreatedAt            : 9/19/2022 2:39:28 AM
SystemDataCreatedBy            : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType        : Application
SystemDataLastModifiedAt       : 9/19/2022 2:39:28 AM
SystemDataLastModifiedBy       : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType   : Application
Tag                            : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
Type                           : Microsoft.ElasticSan/ElasticSans
VolumeId                       : cdcdcdcd-cdcd-cdcd-cdcd-cdcdcdcdcdcd
```

This command gets all the volumes in a volume group.

### Example 2: Get a specific volume 
```powershell
Get-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Name myvolume
```

```output
CreationDataCreateSource       : 
CreationDataSourceUri          : 
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup/volumes/myvolume
Name                           : myvolume
SizeGiB                        : 100
StorageTargetIqn               : iqn.2022-09.net.windows.core.blob.ElasticSan.es-3ibot5m2r3y0:myvolume
StorageTargetPortalHostname    : es-3ibot5m2r3y0.z1.blob.storage.azure.net
StorageTargetPortalPort        : 3260
StorageTargetProvisioningState : Succeeded
StorageTargetStatus            : Running
SystemDataCreatedAt            : 9/19/2022 2:39:28 AM
SystemDataCreatedBy            : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType        : Application
SystemDataLastModifiedAt       : 9/19/2022 2:39:28 AM
SystemDataLastModifiedBy       : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType   : Application
Tag                            : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
Type                           : Microsoft.ElasticSan/ElasticSans
VolumeId                       : abababab-abab-abab-abab-abababababab
```

This command gets a specific volume.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -ElasticSanName
The name of the ElasticSan.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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
The name of the Volume.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: VolumeName

Required: True
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.IVolume

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IElasticSanIdentity>`: Identity Parameter
  - `[ElasticSanName <String>]`: The name of the ElasticSan.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VolumeGroupName <String>]`: The name of the VolumeGroup.
  - `[VolumeName <String>]`: The name of the Volume.

## RELATED LINKS

