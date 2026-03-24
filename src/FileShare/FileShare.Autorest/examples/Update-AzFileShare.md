### Example 1: Update a file share
```powershell
Update-AzFileShare -ResourceName "testshare" -ResourceGroupName "myresourcegroup" -NfProtocolPropertyRootSquash RootSquash -ProvisionedIoPerSec 5001 -ProvisionedStorageGiB 101 -ProvisionedThroughputMiBPerSec 126 -PublicNetworkAccess Disabled -Tag @{tag1="value1"} -PublicAccessPropertyAllowedSubnet $vnet1
```

```output
HostName                                  : fs-xxxxxxxxxxxxxxxxx.z41.file.storage.azure.net
Id                                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.FileShares/fileShares/testshare
IncludedBurstIoPerSec                     : 15000
Location                                  : uaecentral
MaxBurstIoPerSecCredit                    : 36007200
MediaTier                                 : SSD
MountName                                 : testshare
Name                                      : testshare
NfProtocolPropertyRootSquash              : RootSquash
PrivateEndpointConnection                 :
Protocol                                  : NFS
ProvisionedIoPerSec                       : 5001
ProvisionedIoPerSecNextAllowedDowngrade   : 2/27/2026 8:38:36 AM
ProvisionedStorageGiB                     : 101
ProvisionedStorageNextAllowedDowngrade    : 2/27/2026 8:38:36 AM
ProvisionedThroughputMiBPerSec            : 126
ProvisionedThroughputNextAllowedDowngrade : 2/27/2026 8:38:36 AM
ProvisioningState                         : Succeeded
PublicAccessPropertyAllowedSubnet         : {/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1}
PublicNetworkAccess                       : Disabled
Redundancy                                : Local
ResourceGroupName                         : myresourcegroup
SystemDataCreatedAt                       :
SystemDataCreatedBy                       :
SystemDataCreatedByType                   :
SystemDataLastModifiedAt                  : 2/25/2026 6:51:08 AM
SystemDataLastModifiedBy                  : username@microsoft.com
SystemDataLastModifiedByType              : User
Tag                                       : {
                                              "tag1": "value1"
                                            }
Type                                      : Microsoft.FileShares/fileShares
```

This command updates a file share.

