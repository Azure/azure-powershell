### Example 1: List cluster managers by subscription
```powershell
Get-AzNetworkCloudClusterManager -SubscriptionId subscriptionId
```

```output
Location    Name                          SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
--------    ----                          ------------------- -------------------                  ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus      cmName                        08/26/2022 15:26:43 <identity>                           User                    10/17/2022 21:24:16      <identity>                           User                         resourceGroupName

```

This command lists all cluster managers by subscription.

### Example 2: Get cluster manager
```powershell
Get-AzNetworkCloudClusterManager -Name clusterManagerName -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName
```

```output
Location Name   SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----   ------------------- -------------------    ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus   cmName 07/31/2023 17:38:44 <identity>             User                    07/31/2023 17:38:44      <identity>               User                         resourceGroupName
```

This command gets a cluster manager by name.

### Example 3: List cluster managers by resource group
```powershell
Get-AzNetworkCloudClusterManager -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location Name   SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----   ------------------- -------------------    ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus   cmName 07/31/2023 17:38:44 <identity>             User                    07/31/2023 17:38:44      <identity>               User                         resourceGroupName
```
This command lists all cluster managers in a resource group.
