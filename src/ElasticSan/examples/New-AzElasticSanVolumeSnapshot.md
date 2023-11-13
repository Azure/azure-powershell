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
