### Example 1: List Layer 3 (L3) networks by resource group
```powershell
Get-AzNetworkCloudL3Network -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType AzureAsyncOperation ResourceGroupName
--------    ----              ------------------- -------------------   ----------------------- ------------------------ ------------------------   ---------------------------- ------------------- -----------------
eastus      l3NetworkName     05/08/2023 20:59:18 user1                 User                    05/08/2023 20:59:18      user2                      User                                             resourceGroupName
```

This command lists all L3Networks by resource group.

### Example 2: Get Layer 3 (L3) network
```powershell
Get-AzNetworkCloudL3Network -ResourceGroupName resourceGroupName -Name l3NetworkName -SubscriptionId subscriptionId
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType AzureAsyncOperation ResourceGroupName
--------    ----              ------------------- -------------------   ----------------------- ------------------------ ------------------------   ---------------------------- ------------------- -----------------
eastus      l3NetworkName     05/08/2023 20:59:18 user1                 User                    05/08/2023 20:59:18      user2                      User                                             resourceGroupName
```

This command gets details of an L3Network.

### Example 3: List Layer 3 (L3) networks by subscription

```powershell
Get-AzNetworkCloudL3Network -SubscriptionId subscriptionId
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType   Type                              AzureAsyncOperation
--------    ----              ------------------- -------------------  ----------------------- ------------------------ ------------------------    ----------------------------  ----                              -----------------
eastus      l3NetworkName      03/13/2023 16:09:59 user1               User                    03/13/2023 16:20:31     user2                       User                           microsoft.networkcloud/l3networks
```

This command lists L3Networks by subscription.
