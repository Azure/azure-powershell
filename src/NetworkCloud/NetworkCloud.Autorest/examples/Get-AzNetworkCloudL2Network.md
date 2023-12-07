### Example 1: List Layer 2 (L2) networks by resource group
```powershell
Get-AzNetworkCloudL2Network -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location Name       SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt   SystemDataLastModifiedBy             SystemDataLastModifiedByType Type                              AzureAsyncOperation
-------- ----       ------------------- -------------------   ----------------------- ------------------------   ------------------------             ---------------------------- ----                              -------------------
eastus   l2Network  05/25/2023 05:14:09 user1                 User                   05/25/2023 06:14:09         user2                                User                         microsoft.networkcloud/l2networks
```

This command lists all L2Networks by resource group.

### Example 2: Get Layer 2 (L2) network
```powershell
Get-AzNetworkCloudL2Network -ResourceGroupName resourceGroupName -Name l2network -SubscriptionId subscriptionId
```

```output
Location Name      SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Type                              AzureAsyncOperation
-------- ----      ------------------- -------------------      ----------------------- ------------------------ ------------------------ ---------------------------- ----                              -------------------
eastus   l2Network 05/25/2023 05:14:09 user1                    User                    05/25/2023 06:14:09      user2                    User                         microsoft.networkcloud/l2networks
```

This command gets details of an L2Network.

### Example 3: List Layer 2 (L2) networks by subscription
```powershell
Get-AzNetworkCloudL2Network -SubscriptionId subscriptionId
```

```output
Location    Name            SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy    SystemDataLastModifiedByType Type                              AzureAsyncOperation
--------    ----            ------------------- -------------------     ----------------------- ------------------------ ------------------------    ---------------------------- ----                              -------------------
eastus      l2NetworkName1  05/09/2023 06:05:38 app1                    Application             05/24/2023 23:54:00      app2                        Application                  microsoft.networkcloud/l2networks
eastus      l2NetworkName2  05/24/2023 16:50:36 user1                   User                    05/24/2023 20:50:36      user2                       User                         microsoft.networkcloud/l2networks
```

This command lists L2Networks by subscription.
