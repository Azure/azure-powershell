### Example 1: List Internet Gateway Rules by Subscription
```powershell
Get-AzNetworkFabricInternetGatewayRule -SubscriptionId $subscriptionId
```

```output
Location    Name                          SystemDataCreatedAt SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy      SystemDataLastModifiedByType
--------    ----                          ------------------- -------------------        ----------------------- ------------------------ ------------------------      ----
eastus2euap nfcfab3-4-1-GF1-infra-system  09/21/2023 08:47:10 <identity>                 Application             09/21/2023 08:47:22      <identity>                    App…
eastus2euap nfa-tool-ts-GA-IGwRule081023  08/10/2023 11:05:30 <identity>                 User                    09/04/2023 15:35:53      <identity>                    App…
eastus2euap nfcfab1-4-1-BF-infra-system   09/22/2023 02:33:21 <identity>                 Application             09/22/2023 02:33:29      <identity>                    App…
eastus      controller092123-infra-system 09/21/2023 12:14:52 <identity>                 Application             09/21/2023 12:15:03      <identity>                    App…
```

This command lists all the Internet Gateway Rules under the given Subscription.

### Example 2: List Internet Gateway Rules by Resource Group
```powershell
Get-AzNetworkFabricInternetGatewayRule -ResourceGroupName $resourceGroupName
```

```output
Annotation Id
---------- --
           /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/InternetGatewayRules/controller092123…
```

This command lists all the Internet Gateway Rules under the given Resource Group.

### Example 3: Get Internet Gateway Rule
```powershell
Get-AzNetworkFabricInternetGatewayRule -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation Id
---------- --
           /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/InternetGatewayRules/controller092123…
```

This command gets details of the given Internet Gateway Rule.

