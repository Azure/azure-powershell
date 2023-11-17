### Example 1: List virtual machines by subscription
```powershell
Get-AzNetworkCloudVirtualMachine -SubscriptionId subscriptionId
```

```output
Location Name       SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType  SystemDataLastModifiedAt  SystemDataLastModifiedBy SystemDataLastModifiedByType AzureAsyncOperation
--------        ----                   -------------------                  -------------------                    -----------------------                       ------------------------                        ------------------------             -
eastus      testVM123       07/07/2023 16:50:12    <user>                                  User                                             07/08/2023 03:19:08                  <Identity>                           A
```

This command gets all virtual machines under a subscription.

### Example 2: Get virtual machine
```powershell
Get-AzNetworkCloudVirtualMachine -Name vmName -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location Name       SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType  SystemDataLastModifiedAt  SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------        ----                   -------------------                  -------------------                    -----------------------                       ------------------------                        ------------------------                       ---------------------------------------------  ------------------------
eastus      <VM name>    07/07/2023 16:50:12    <user>                                  User                                             07/08/2023 03:19:08                  <Identity>                                       Application                                          <RG>
```

This command gets a virtual machine by name.

### Example 2: List virtual machines by resource group
```powershell
Get-AzNetworkCloudVirtualMachine -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location Name       SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType  SystemDataLastModifiedAt  SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------        ----                   -------------------                  -------------------                    -----------------------                       ------------------------                        ------------------------                       ---------------------------------------------  ------------------------
eastus      <VM name>    07/07/2023 16:50:12    <user>                                  User                                             07/08/2023 03:19:08                  <Identity>                                       Application                                          <RG>
eastus      <VM name>    07/07/2023 16:50:12    <user>                                  User                                             07/08/2023 03:19:08                  <Identity>                                       Application                                          <RG>
eastus      <VM name>    07/07/2023 16:50:12    <user>                                  User                                             07/08/2023 03:19:08                  <Identity>                                       Application                                          <RG>
```
This command lists all virtual machines in a resource group.
