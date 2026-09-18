### Example 1: Update an Elastic SAN
```powershell
$elasticSan = Update-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan -BaseSizeTib 5 -ExtendedCapacitySizeTib 20 -Tag @{"tag3" = "value3"} -CapacityUnitScaleUpLimitTiB 20 -IncreaseCapacityUnitByTiB 2 -UnusedSizeTiB 5 -AutoScalePolicyEnforcement Disabled
```

```output
AutoScalePolicyEnforcement   : Disabled
AvailabilityZone             : 1 
BaseSizeTiB                  : 5
CapacityUnitScaleUpLimitTiB  : 20
ExtendedCapacitySizeTiB      : 20
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan
IncreaseCapacityUnitByTiB    : 2
Location                     : eastus2
Name                         : myelasticsan
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          :
ResourceGroupName            : myresourcegroup
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 9/30/2024 3:41:50 AM
SystemDataCreatedBy          : example@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 9/30/2024 3:55:11 AM
SystemDataLastModifiedBy     : example@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "tag3": "value3"
                               }
TotalIops                    : 25000
TotalMBps                    : 1000
TotalSizeTiB                 : 25
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
UnusedSizeTiB                : 5
VolumeGroupCount             : 0
```

This command updates properties of an Elastic SAN. 
