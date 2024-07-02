### Example 1: List Network Fabric Controllers by Subscription
```powershell
Get-AzNetworkFabricController -SubscriptionId $subscriptionId
```

```output
Location    Name                         SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy      SystemDataLastModifiedByType
--------    ----                         ------------------- -------------------    ----------------------- ------------------------ ------------------------      -----
eastus2euap nfa-tool-ts-GA-nfc071323     07/13/2023 09:34:40 <identity>             User                    09/05/2023 10:32:49      <identity>                    Appl…
eastus2euap nfa-automation-testing-nfc-1 08/07/2023 12:16:05 <identity>             Application             08/07/2023 13:19:01      <identity>                    Appl…
eastus2euap nfa-automation-testing-nfc-2 08/07/2023 14:31:19 <identity>             Application             08/07/2023 15:37:20      <identity>                    Appl…
eastus2euap nfa-tool-ts-GA-nfc081023     08/10/2023 06:43:29 <identity>             User                    09/21/2023 10:35:20      <identity>                    Appl…
eastus2euap nfcfab3-4-0                  09/07/2023 08:56:12 <identity>             Application             09/20/2023 14:22:59      <identity>                    Appl…
eastus2euap acctest3523                  09/15/2023 05:41:52 <identity>             User                    09/15/2023 05:41:52      <identity>                    User
eastus      controller092123             09/21/2023 11:51:54 <identity>             User                    09/22/2023 13:22:21      <identity>                    Appl…
```

This command lists all the Network Fabric Controllers under the given Subscription.

### Example 2: List Network Fabric Controllers by Resource Group
```powershell
Get-AzNetworkFabricController -ResourceGroupName $resourceGroupName
```

```output
Annotation Id
---------- --
           /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkFabricControllers/controller09…
```

This command lists all the Network Fabric Controllers under the given Resource Group.

### Example 3: Get Network Fabric Controller
```powershell
Get-AzNetworkFabricController -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation Id
---------- --
           /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkFabricControllers/controller09…
```

This command gets details of the given Network Fabric Controller.