### Example 1: List rack SKUs by subscription
```powershell
Get-AzNetworkCloudRackSku -SubscriptionId subscriptionId
```

```output
Name                          SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                          ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
rackSkuName                     07/10/2023 16:09:59 user1               User                    07/10/2023 16:20:31     user2                       User                     resourceGroupName
```

This command lists all rack SKUs by subscription.

### Example 2: Get rack SKU
```powershell
Get-AzNetworkCloudRackSku -Name rackSkuName -SubscriptionId subscriptionId
```

```output
Name                         SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                         ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
rackSkuName                     07/10/2023 16:09:59 user1               User                    07/10/2023 16:20:31     user2                       User                    resourceGroupName
```

This command gets a rack SKU.
