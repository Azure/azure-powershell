### Example 1: List Network Tap Rule by Subscription
```powershell
Get-AzNetworkFabricTapRule -SubscriptionId $subscriptionId
```

```output
AdministrativeState Annotation ConfigurationState ConfigurationType DynamicMatchConfiguration Id
------------------- ---------- ------------------ ----------------- ------------------------- --
Disabled                       Succeeded          File                                        /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg09…
```

This command lists all the Network Tap Rule under the given Subscription.

### Example 2: List Network Tap Rule by Resource Group
```powershell
Get-AzNetworkFabricTapRule -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState ConfigurationType DynamicMatchConfiguration Id
------------------- ---------- ------------------ ----------------- ------------------------- --
Disabled                       Succeeded          File                                        /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg09…
```

This command lists all the Network Tap Rule under the given Resource Group.

### Example 3: Get Network Tap Rule
```powershell
Get-AzNetworkFabricTapRule -Name $name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState ConfigurationType DynamicMatchConfiguration Id
------------------- ---------- ------------------ ----------------- ------------------------- --
Disabled                       Succeeded          File                                        /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg09…
```

This command gets details of the given Network Tap Rule.

