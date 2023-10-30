### Example 1: List cloud services networks by resource group
```powershell
Get-AzNetworkCloudServicesNetwork -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location Name                     SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
-------- ----                     ------------------- -------------------    ----------------------- ------------------------ ------------------------
eastus   cloudNetworkServicesName 06/30/2023 13:32:28 User1                  User                    06/30/2023 13:32:39      resourceGroupName
```

This command lists all cloud services network in a resource group.

### Example 2: Get cloud services network
```powershell
Get-AzNetworkCloudServicesNetwork -ResourceGroupName resourceGroupName -CloudServicesNetworkName cloudNetworkServicesName
```

```output
Location Name                     SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
-------- ----                     ------------------- -------------------    ----------------------- ------------------------ ------------------------
eastus   cloudNetworkServicesName 06/30/2023 13:32:28 User1                  User                    06/30/2023 13:32:39      resourceGroupName
```

This command gets cloud services network by name.

### Example 3: List cloud services networks by subscription
```powershell
Get-AzNetworkCloudServicesNetwork -SubscriptionId subscriptionId
```

```output
Location Name                     SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
-------- ----                     ------------------- -------------------    ----------------------- ------------------------ ------------------------
eastus   cloudNetworkServicesName 06/30/2023 13:32:28 User1                  User                    06/30/2023 13:32:39      resourceGroupName
```

This command lists all cloud services networks by subscription.
