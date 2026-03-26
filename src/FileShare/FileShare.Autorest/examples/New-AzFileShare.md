### Example 1: Create a file share
```powershell
New-AzFileShare -ResourceName "testshare" -ResourceGroupName "myresourcegroup" -Location uaecentral -MediaTier SSD -NfProtocolPropertyRootSquash AllSquash -Protocol NFS -ProvisionedIoPerSec 5000 -ProvisionedStorageGiB 100 -ProvisionedThroughputMiBPerSec 125 -PublicAccessPropertyAllowedSubnet $vnet1,$vnet2 -Tag @{"tag1" = "value1"; "tag2" = "value2" }
```

```output
HostName                                  : fs-xxxxxxxxxxxxxxxxx.z41.file.storage.azure.net
Id                                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.FileShares/fileShares/testshare
IncludedBurstIoPerSec                     : 15000
Location                                  : uaecentral
MaxBurstIoPerSecCredit                    : 36000000
MediaTier                                 : SSD
MountName                                 : testshare
Name                                      : testshare
NfProtocolPropertyRootSquash              : AllSquash
PrivateEndpointConnection                 : {}
Protocol                                  : NFS
ProvisionedIoPerSec                       : 5000
ProvisionedIoPerSecNextAllowedDowngrade   : 2/26/2026 6:56:35 AM
ProvisionedStorageGiB                     : 100
ProvisionedStorageNextAllowedDowngrade    : 2/26/2026 6:56:35 AM
ProvisionedThroughputMiBPerSec            : 125
ProvisionedThroughputNextAllowedDowngrade : 2/26/2026 6:56:35 AM
ProvisioningState                         : Succeeded
PublicAccessPropertyAllowedSubnet         : {/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1,
                                            /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet2}
PublicNetworkAccess                       : Enabled
Redundancy                                : Local
ResourceGroupName                         : myresourcegroup
SystemDataCreatedAt                       :
SystemDataCreatedBy                       :
SystemDataCreatedByType                   :
SystemDataLastModifiedAt                  : 2/25/2026 6:51:08 AM
SystemDataLastModifiedBy                  : username@microsoft.com
SystemDataLastModifiedByType              : User
Tag                                       : {
                                              "tag2": "value2",
                                              "tag1": "value1"
                                            }
Type                                      : Microsoft.FileShares/fileShares
```

This command creates a file share.

