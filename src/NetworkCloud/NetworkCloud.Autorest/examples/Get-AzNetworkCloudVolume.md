### Example 1: List volumes by subscription
```powershell
Get-AzNetworkCloudVolume -SubscriptionId subscriptionId
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                  -------------------                 -------------------                  -----------------------                   ------------------------                 --------
eastus      <name>         08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity> Application
eastus      <name2>       08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity> Application
eastus      <name3>       08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity> Application
```

This command lists all volumes under a subscription.

### Example 2: Get volume
```powershell
Get-AzNetworkCloudVolume -Name volumeName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                  -------------------                 -------------------                  -----------------------                   ------------------------                 --------
eastus      <name>         08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity> Application
```

This command gets a volume by name.

### Example 3: List volumes by resource group
```powershell
Get-AzNetworkCloudVolume -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                  -------------------                 -------------------                  -----------------------                   ------------------------                 --------
eastus      <name>         08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity> Application
```

This command lists all volumes in a resource group.
