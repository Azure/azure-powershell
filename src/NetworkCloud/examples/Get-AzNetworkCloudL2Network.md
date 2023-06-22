### Example 1: Get Layer 2 (L2) networks by resourcegroup
```powershell
 Get-AzNetworkCloudL2Network -ResourceGroupName resourceGroupName
```

```output
Location Name       SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt   SystemDataLastModifiedBy             SystemDataLastModifiedByType Type                              AzureAsyncOperation
-------- ----       ------------------- -------------------   ----------------------- ------------------------   ------------------------             ---------------------------- ----                              -------------------
eastus   l2Network  05/25/2023 05:14:09 user1                 User                   05/25/2023 06:14:09         user2                                User                         microsoft.networkcloud/l2networks
```

This command gets all L2Networks in a resource group.

### Example 2: Get Layer 2 (L2) networks by name
```powershell
 Get-AzNetworkCloudL2Network -ResourceGroupName resourceGroupName -Name l2network
```

```output
Location Name      SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Type                              AzureAsyncOperation
-------- ----      ------------------- -------------------      ----------------------- ------------------------ ------------------------ ---------------------------- ----                              -------------------
eastus   l2Network 05/25/2023 05:14:09 user1                    User                    05/25/2023 06:14:09      user2                    User                         microsoft.networkcloud/l2networks
```

This command gets the L2Networks in a resource group by its name.

### Example 3: Get all Layer 2 (L2) networks under a subscription
```powershell
Get-AzNetworkCloudL2Network
```

```output
Location    Name            SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy    SystemDataLastModifiedByType Type                              AzureAsyncOperation
--------    ----            ------------------- -------------------     ----------------------- ------------------------ ------------------------    ---------------------------- ----                              -------------------
eastus      l2NetworkName1  05/09/2023 06:05:38 app1                    Application             05/24/2023 23:54:00      app2                        Application                  microsoft.networkcloud/l2networks
eastus      l2NetworkName2  05/24/2023 16:50:36 user1                   User                    05/24/2023 20:50:36      user2                       User                         microsoft.networkcloud/l2networks
```

This command gets L2Networks under a subscription.
