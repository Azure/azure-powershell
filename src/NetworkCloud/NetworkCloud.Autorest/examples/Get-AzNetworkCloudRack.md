### Example 1: List racks by resource group
```powershell
Get-AzNetworkCloudRack -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType       ResourceGroupName
--------    ----              ------------------- -------------------  ----------------------- ------------------------ ------------------------    ----------------------------      -----------------
eastus      rackName            07/11/2023 16:09:59 user1               User                    07/11/2023 16:20:31     user2                       User                               sim
```

This command lists all racks by resource group.

### Example 2: Get rack
```powershell
Get-AzNetworkCloudRack -ResourceGroupName resourceGroupName -Name rackName -SubscriptionId subscriptionId
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType       ResourceGroupName
--------    ----              ------------------- -------------------  ----------------------- ------------------------ ------------------------    ----------------------------      -----------------
eastus      rackName            07/11/2023 16:09:59 user1               User                    07/11/2023 16:20:31     user2                       User                               sim
```

This command gets details of a rack.

### Example 3: List racks by subscription
```powershell
Get-AzNetworkCloudRack -SubscriptionId subscriptionId
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType       ResourceGroupName
--------    ----              ------------------- -------------------  ----------------------- ------------------------ ------------------------    ----------------------------      -----------------
eastus      rackName            07/11/2023 16:09:59 user1               User                    07/11/2023 16:20:31     user2                       User                               sim
```

This command lists racks by subscription.
