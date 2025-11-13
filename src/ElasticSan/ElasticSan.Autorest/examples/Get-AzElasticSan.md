### Example 1: Get all Elastic SANs in a subscription
```powershell
Get-AzElasticSan
```

```output
AvailabilityZone             :
BaseSizeTiB                  : 1
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup
                               /providers/Microsoft.ElasticSan/elasticSans/myelasticsan1
Location                     : eastus
Name                         : myelasticsan1
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 9/19/2022 9:50:25 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 9/19/2022 9:50:25 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 5000
TotalMBps                    : 80
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 0

AvailabilityZone             :
BaseSizeTiB                  : 1
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Micr
                               osoft.ElasticSan/elasticSans/myelasticsan2
Location                     : eastus
Name                         : myelasticsan2
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 8/18/2022 8:42:21 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/18/2022 8:42:21 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 5000
TotalMBps                    : 80
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 100
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 7
```

This command gets all the Elastic SANs in a subscription.

### Example 2: Get all Elastic Sans in a resource group
```powershell
Get-AzElasticSan -ResourceGroupName myresourcegroup
```

```output
AvailabilityZone             :
BaseSizeTiB                  : 1
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup
                               /providers/Microsoft.ElasticSan/elasticSans/myelasticsan1
Location                     : eastus
Name                         : myelasticsan1
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 9/19/2022 9:50:25 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 9/19/2022 9:50:25 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 5000
TotalMBps                    : 80
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 0

AvailabilityZone             :
BaseSizeTiB                  : 1
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Micr
                               osoft.ElasticSan/elasticSans/myelasticsan2
Location                     : eastus
Name                         : myelasticsan2
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 8/18/2022 8:42:21 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/18/2022 8:42:21 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 5000
TotalMBps                    : 80
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 100
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 7
```

This command gets all Elastic SANs in a resource group. 

### Example 3: Get a specific Elastic SAN
```powershell
Get-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan
```

```output
AvailabilityZone             :
BaseSizeTiB                  : 1
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Micr
                               osoft.ElasticSan/elasticSans/myelasticsan
Location                     : eastus
Name                         : myelasticsan
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 8/18/2022 8:42:21 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/18/2022 8:42:21 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 5000
TotalMBps                    : 80
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 100
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 7
```

This command gets a specific Elastic SAN.

