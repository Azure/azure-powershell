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


