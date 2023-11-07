### Example 1: Update an Elastic SAN
```powershell
$elasticSan = Update-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan -BaseSizeTib 64 -ExtendedCapacitySizeTib 128 -Tag @{"tag3" = "value3"}
```

```output
AvailabilityZone             : 
BaseSizeTiB                  : 64
ExtendedCapacitySizeTiB      : 128
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan
Location                     : eastus
Name                         : myelasticsan
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      : 
SystemDataCreatedAt          : 8/16/2022 4:59:54 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/16/2022 4:59:54 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 320000
TotalMBps                    : 5120
TotalSizeTiB                 : 192
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 0
```

This command updates the BaseSizeTib, ExtendedCapacitySizeTib, and Tag properties of an Elastic SAN.

