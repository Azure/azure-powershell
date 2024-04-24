### Example 1: List Neighbor Groups by Subscription
```powershell
Get-AzNetworkFabricNeighborGroup -SubscriptionId $subscriptionId
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType ResourceGroupName
--------    ----              ------------------- -------------------        ----------------------- ------------------------ ------------------------   ---------------------------- -------
eastus2euap neighborgroupName 09/21/2023 10:52:59 <identity>                 User                    09/21/2023 10:52:59      <identity>                 User                         nfa-to…
eastus      NeighborGroupName 09/25/2023 05:33:29 <identity>                 User                    09/25/2023 05:33:29      <identity>                 User                         nfa-to…
```

This command lists all the Neighbor Groups under the given Subscription.

### Example 2: List Neighbor Groups by Resource Group
```powershell
Get-AzNetworkFabricNeighborGroup -ResourceGroupName $resourceGroupName
```

```output
Annotation Destination       Id
---------- -----------       --
                             /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/pr…
```

This command lists all the Neighbor Groups under the given Resource Group.

### Example 3: Get Neighbor Groups
```powershell
Get-AzNetworkFabricNeighborGroup -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation Destination       Id
---------- -----------       --
                             /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/pr…
```

This command gets details of the given Neighbor Groups.

