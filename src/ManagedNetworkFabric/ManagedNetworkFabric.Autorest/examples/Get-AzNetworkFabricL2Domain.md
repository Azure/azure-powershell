### Example 1: List L2 Isolation Domains by Subscription
```powershell
Get-AzNetworkFabricL2Domain -SubscriptionId $subscriptionId
```

```output
Location    Name                                SystemDataCreatedAt SystemDataCreatedBy         SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------    ----                                ------------------- -------------------         ----------------------- ------------------------ ------------------------
eastus2euap l2domain-2007                       07/25/2023 07:02:50 <identity>                  User                    07/31/2023 09:35:55      <identity>
eastus2euap l2domain-2008                       07/25/2023 07:18:57 <identity>                  User                    07/25/2023 07:21:16      <identity>
eastus2euap l2domain-sep22-01                   09/22/2023 06:06:56 <identity>                  User                    09/22/2023 06:16:49      <identity>
eastus2euap nffab3-4-1-GF1-l2isd-2000           09/22/2023 07:21:17 <identity>                  Application             09/22/2023 07:21:44      <identity>
eastus2euap nffab3-4-1-GF1-l2isd-1209           09/22/2023 07:30:05 <identity>                  Application             09/22/2023 07:30:32      <identity>
eastus2euap nffab3-4-1-GF1-l2isd-3001           09/22/2023 07:30:51 <identity>                  Application             09/22/2023 07:31:14      <identity>
eastus2euap nffab3-4-1-GF1-l2isd-2020           09/22/2023 07:31:23 <identity>                  Application             09/22/2023 07:31:45      <identity>
eastus      pipeline-nf082823-l2isd2-2088       09/22/2023 06:36:17 <identity>                  User                    09/22/2023 06:36:17      <identity>
eastus      l2DomainName                        09/25/2023 11:06:26 <identity>                  User                    09/25/2023 11:06:26      <identity>
```

This command lists all the L2 Isolation Domains under the given Subscription.

### Example 2: List L2 Isolation Domains by Resource Group
```powershell
Get-AzNetworkFabricL2Domain -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState Id
------------------- ---------- ------------------ --
Disabled                                          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabri…
```

This command lists all the L2 Isolation Domains under the given Resource Group.

### Example 3: Get L2 Isolation Domain
```powershell
Get-AzNetworkFabricL2Domain -Name $name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState Id
------------------- ---------- ------------------ --
Disabled                                          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabri…
```

This command gets details of the given L2 Isolation Domain.

