### Example 1: List trunked networks by subscription
```powershell
Get-AzNetworkCloudTrunkedNetwork -SubscriptionId subscriptionId
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                  -------------------                 -------------------                  -----------------------                   ------------------------                 --------
eastus      <name>         08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity>
eastus      <name>         08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity>                                         08/02/2023 21:39:33          <identity>
```

This command lists all trunked networks under a subscription.

### Example 2: Get trunked network
```powershell
Get-AzNetworkCloudTrunkedNetwork -Name trunkedNetworkName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                  -------------------                 -------------------                  -----------------------                   ------------------------                 --------
eastus      <name>         08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity>
```

This command gets a trunked network by name.

### Example 3: List trunked networks by resource group
```powershell
Get-AzNetworkCloudTrunkedNetwork -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                  -------------------                 -------------------                  -----------------------                   ------------------------                 --------
eastus      <name>         08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity>
eastus      <name>         08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity>
```

This command lists all trunked networks in a resource group.