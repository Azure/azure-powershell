### Example 1: Get file shares provisioning parameters recommendation
```powershell
Get-AzFileShareProvisioningRecommendation -Location uaecentral -ProvisionedStorageGiB 100
```

```output
AvailableRedundancyOption ProvisionedIoPerSec ProvisionedThroughputMiBPerSec
------------------------- ------------------- ------------------------------
{Local}                                  3050                            130
```

This command gets file shares provisioning parameters recommendation.

