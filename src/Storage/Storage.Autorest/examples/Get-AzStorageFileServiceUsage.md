### Example 1: Get a Storage account file service usage data
```powershell
Get-AzStorageFileServiceUsage -StorageAccountName myaccount -ResourceGroupName myresroucegroup
```

```output
BurstingConstantBurstFloorIops                      : 10000
BurstingConstantBurstIoScalar                       : 3
BurstingConstantBurstTimeframeSecond                : 3600
FileShareLimitMaxProvisionedBandwidthMiBPerSec      : 10340
FileShareLimitMaxProvisionedIops                    : 102400
FileShareLimitMaxProvisionedStorageGiB              : 262144
FileShareLimitMinProvisionedBandwidthMiBPerSec      : 125
FileShareLimitMinProvisionedIops                    : 3000
FileShareLimitMinProvisionedStorageGiB              : 32
FileShareRecommendationBandwidthScalar              : 0.1
FileShareRecommendationBaseBandwidthMiBPerSec       : 125
FileShareRecommendationBaseIops                     : 3000
FileShareRecommendationIoScalar                     : 1
Id                                                  : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresroucegroup/providers/Microsoft.Storage/storageAccounts/myaccount/fileServices/default/usages/default
LiveShareFileShareCount                             : 1
LiveShareProvisionedBandwidthMiBPerSec              : 129
LiveShareProvisionedIops                            : 3032
LiveShareProvisionedStorageGiB                      : 32
Name                                                : default
ResourceGroupName                                   : myresroucegroup
SoftDeletedShareFileShareCount                      : 0
SoftDeletedShareProvisionedBandwidthMiBPerSec       : 0
SoftDeletedShareProvisionedIops                     : 0
SoftDeletedShareProvisionedStorageGiB               : 0
StorageAccountLimitMaxFileShare                     : 50
StorageAccountLimitMaxProvisionedBandwidthMiBPerSec : 10340
StorageAccountLimitMaxProvisionedIops               : 102400
StorageAccountLimitMaxProvisionedStorageGiB         : 262144
Type                                                : Microsoft.Storage/storageAccounts/fileServices/usages
```

This command gets the usage of file service in storage account including account limits, file share limits and constants used in recommendations and bursting formula.

