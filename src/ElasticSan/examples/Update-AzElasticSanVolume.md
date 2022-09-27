### Example 1: Update an Elastic SAN volume
```powershell
$volume = Update-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Name myvolume -Tag @{tag3 = "value3"} -SizeGib 120
```

```output
CreationDataCreateSource       : 
CreationDataSourceUri          : 
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan/volumegroups/myvolumegroup/volumes/myvolume
Name                           : myvolume
SizeGiB                        : 120
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

This command updates the SizeGib and Tag properties of a volume. 

