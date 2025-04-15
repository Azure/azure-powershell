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

