### Example 1: List storage appliances by subscription
```powershell
Get-AzNetworkCloudStorageAppliance -SubscriptionId subscriptionId
```

```output
Location Name                SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType ResourceGroupName
-------- ----                ------------------- -------------------  ----------------------- ------------------------ ------------------------  ---------------------------- -----------------
westus3  storage-appliance     07/12/2023 10:42:00 user1                   Application            07/12/2023 12:58:10      user2                      Application                resourceGroup
eastus   storage-appliance     11/03/2022 16:59:20 user1                   Application            12/09/2022 19:46:26      user2                      Application                resourceGroup
```

This command lists all storage appliances in the subscription.

### Example 2: List storage appliances by resource group
```powershell
Get-AzNetworkCloudStorageAppliance -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location Name                SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType ResourceGroupName
-------- ----                ------------------- -------------------  ----------------------- ------------------------ ------------------------  ---------------------------- -----------------
westus3  storage-appliance     07/12/2023 10:42:00 user1                   Application            07/12/2023 12:58:10      user2                      Application                resourceGroup
eastus   storage-appliance     11/03/2022 16:59:20 user1                   Application            12/09/2022 19:46:26      user2                      Application                resourceGroup
```

This command lists all storage appliances in the ResourceGroup.

### Example 3: Get storage appliance
```powershell
Get-AzNetworkCloudStorageAppliance -Name storageApplianceName -SubscriptionId subscriptionId -ResourceGroupName resourceGroup
```

```output
Location Name                SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType ResourceGroupName
-------- ----                ------------------- -------------------  ----------------------- ------------------------ ------------------------  ---------------------------- -----------------
westus3  storage-appliance     07/12/2023 10:42:00 user1                   Application            07/12/2023 12:58:10      user2                      Application                resourceGroup
```

This command gets a storage appliance by its name.
