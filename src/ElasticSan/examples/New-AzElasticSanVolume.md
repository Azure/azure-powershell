### Example 1: Create a volume
```powershell
New-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Name myvolumegroup -SizeGib 100  -CreationDataSourceUri 'https://abc.com' -Tag @{tag1="value1";tag2="value2"}
```

```output
CreationDataCreateSource       : 
CreationDataSourceUri          : https://abc.com
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

This command creates a volume. 

