### Example 1: Get a file share
```powershell
Get-AzFileShare -ResourceName "testshare" -ResourceGroupName "myresourcegroup"
```

```output
HostName                                  : fs-xxxxxxxxxxxxxxxxx.z41.file.storage.azure.net
Id                                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.FileShares/fileShares/testshare
IncludedBurstIoPerSec                     : 15000
Location                                  : eastus2euap
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

This command gets a file share properties.

### Example 2: List file shares in a resource group and format the output
```powershell
Get-AzFileShare -ResourceGroupName $resourceGroup | ft Name,Location,Protocol,ProvisionedStorageGiB,MediaTier
```

```output
Name       Location    Protocol ProvisionedStorageGiB MediaTier
----       --------    -------- --------------------- ---------
testshare1 eastus2euap NFS                        100 SSD
testshare2 uaecentral  NFS                         50 SSD
```

This command lists all file shares in a resource group and format the output to a table with selected properties.

### Example 3: List file shares in the current subscription
```powershell
Get-AzFileShare
```

```output
Location    Name       SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------    ----       -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus2euap testshare1 8/7/2025 3:36:39 AM  user11@microsoft.com   User                  8/7/2025 3:36:39 AM      user11@microsoft.com     User                         myresourcegroup
uaecentral  testshare2 2/26/2026 8:13:58 AM user11@microsoft.com   User                  2/26/2026 8:13:58 AM     user11@microsoft.com     User                         myresourcegroup
eastus2euap testshare3 5/14/2025 9:24:49 AM user11@microsoft.com   User                  5/14/2025 9:24:49 AM     user11@microsoft.com     User                         resourcegroup2
```

This command lists all file shares in the current subscription.
