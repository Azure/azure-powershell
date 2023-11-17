### Example 1: Create an Elastic SAN
```powershell
New-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan -BaseSizeTib 1 -ExtendedCapacitySizeTib 6 -Location eastus -SkuName 'Premium_LRS' -Tag @{tag1="value1";tag2="value2"}
```

```output
AvailabilityZone             : 
BaseSizeTiB                  : 1
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan
Location                     : eastus
Name                         : myelasticsan
ProvisioningState            : Succeeded
SkuName                      : Premium_LRS
SkuTier                      : 
SystemDataCreatedAt          : 9/19/2022 9:47:26 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 9/19/2022 9:47:26 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ResourceTags
TotalIops                    : 5000
TotalMBps                    : 80
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
VolumeGroupCount             : 0
```

This command creates an Elastic SAN.
