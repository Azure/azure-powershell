### Example 1: Create an Elastic SAN
```powershell
New-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan -BaseSizeTib 1 -ExtendedCapacitySizeTib 6 -Location eastus -SkuName 'Premium_LRS' -Tag @{tag1="value1";tag2="value2"}
```

```output
AutoScalePolicyEnforcement   :
AvailabilityZone             :
BaseSizeTiB                  : 1
CapacityUnitScaleUpLimitTiB  :
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan
IncreaseCapacityUnitByTiB    :
Location                     : eastus
Name                         : myelasticsan
PrivateEndpointConnection    :
ProvisioningState            : Succeeded
PublicNetworkAccess          :
ResourceGroupName            : myresourcegroup
SkuName                      : Premium_LRS
SkuTier                      :
SystemDataCreatedAt          : 9/30/2024 3:43:44 AM
SystemDataCreatedBy          : example@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 9/30/2024 3:43:44 AM
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
UnusedSizeTiB                :
VolumeGroupCount             : 0
```

This command creates an Elastic SAN.

### Example 2: Create an Elastic SAN with auto scale policy
```powershell
New-AzElasticSan -ResourceGroupName myresourcegroup -Name myelasticsan -BaseSizeTiB 1 -ExtendedCapacitySizeTiB 6 -Location eastus2 -SkuName Premium_LRS -AutoScalePolicyEnforcement Enabled -CapacityUnitScaleUpLimitTiB 24 -IncreaseCapacityUnitByTiB 1 -UnusedSizeTiB 5
```

```output
AutoScalePolicyEnforcement   : Enabled
AvailabilityZone             :
BaseSizeTiB                  : 1
CapacityUnitScaleUpLimitTiB  : 24
ExtendedCapacitySizeTiB      : 6
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.ElasticSan/elasticSans/myelasticsan
IncreaseCapacityUnitByTiB    : 1
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
SystemDataLastModifiedAt     : 9/30/2024 3:41:50 AM
SystemDataLastModifiedBy     : example@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
TotalIops                    : 5000
TotalMBps                    : 200
TotalSizeTiB                 : 7
TotalVolumeSizeGiB           : 0
Type                         : Microsoft.ElasticSan/ElasticSans
UnusedSizeTiB                : 5
VolumeGroupCount             : 0
```

This command creates an Elastic SAN with auto scale policy.
