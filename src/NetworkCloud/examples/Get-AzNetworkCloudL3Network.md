### Example 1: Get Layer 3 (L3) networks by resourcegroup
```powershell
 Get-AzNetworkCloudL3Network -ResourceGroupName resourceGroupName                       
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType AzureAsyncOperation ResourceGroupName
--------    ----              ------------------- -------------------   ----------------------- ------------------------ ------------------------   ---------------------------- ------------------- -----------------
eastus      l3NetworkName     05/08/2023 20:59:18 user1                 User                    05/08/2023 20:59:18      user2                      User                                             resourceGroupName
```

This command gets all L3Networks in a resource group.

### Example 2: Get Layer 3 (L3) network by name
```powershell
Get-AzNetworkCloudL3Network -ResourceGroupName resourceGroupName -Name l3NetworkName
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType AzureAsyncOperation ResourceGroupName
--------    ----              ------------------- -------------------   ----------------------- ------------------------ ------------------------   ---------------------------- ------------------- -----------------
eastus      l3NetworkName     05/08/2023 20:59:18 user1                 User                    05/08/2023 20:59:18      user2                      User                                             resourceGroupName
```

This command gets L3Network in resource group by name.

### Example 3: Get all Layer 3 (L3) networks under a subscription

```powershell
Get-AzNetworkCloudL3Network 
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType   Type                              AzureAsyncOperation
--------    ----              ------------------- -------------------  ----------------------- ------------------------ ------------------------    ----------------------------  ----                              -----------------
eastus      l3NetworkName      03/13/2023 16:09:59 user1               User                    03/13/2023 16:20:31     user2                       User                           microsoft.networkcloud/l3networks 
```

This command gets L3Networks under a subscription.
