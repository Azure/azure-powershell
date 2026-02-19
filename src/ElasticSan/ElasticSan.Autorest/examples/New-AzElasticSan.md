### Example 1: Create an Elastic SAN
```powershell
New-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan -BaseSizeTib 1 -ExtendedCapacitySizeTib 6 -Location eastus -SkuName 'Premium_LRS' -AvailabilityZone 1 -Tag @{tag1="value1";tag2="value2"} -AutoScalePolicyEnforcement Enabled -CapacityUnitScaleUpLimitTiB 30 -IncreaseCapacityUnitByTiB 2 -UnusedSizeTiB 6
```

```output
AutoScalePolicyEnforcement   : Enabled
AvailabilityZone             : {1}
BaseSizeTiB                  : 1
CapacityUnitScaleUpLimitTiB  : 30
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan
IncreaseCapacityUnitByTiB    : 2 
Location                     : eastus2euap
Name                         : myelasticsan
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          :
ResourceGroupName            : myresourcegroup
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 10/29/2025 3:07:36 AM
SystemDataCreatedBy          : example@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/29/2025 3:07:36 AM
SystemDataLastModifiedBy     : example@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "tag1": "value1",
                                 "tag2": "value2"
                               }
TotalIops                    : 5000
TotalMBps                    : 200
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
UnusedSizeTiB                : 6 
VolumeGroupCount             : 0
```

This command creates an Elastic SAN.

### Example 2: Create an Elastic SAN with default base size and extended capacity size
```powershell
New-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan -Location eastus -SkuName 'Premium_LRS' -Tag @{tag1="value1";tag2="value2"}
```

```output
AutoScalePolicyEnforcement   :
AvailabilityZone             : {1}
BaseSizeTiB                  : 20
CapacityUnitScaleUpLimitTiB  :
ExtendedCapacitySizeTiB      : 0
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan
IncreaseCapacityUnitByTiB    :
Location                     : eastus2euap
Name                         : myelasticsan
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          :
ResourceGroupName            : myresourcegroup
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 10/29/2025 6:00:04 AM
SystemDataCreatedBy          : example@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/29/2025 6:00:04 AM
SystemDataLastModifiedBy     : example@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
TotalIops                    : 100000
TotalMBps                    : 4000
TotalSizeTiB                 : 20
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
UnusedSizeTiB                :
VolumeGroupCount             : 0
```

This command creates an Elastic SAN.
