### Example 1: List Network Tap by Subscription
```powershell
Get-AzNetworkFabricTap -SubscriptionId $subscriptionId
```

```output
AdministrativeState Annotation ConfigurationState Destination
------------------- ---------- ------------------ -----------
Disabled                       Succeeded          
```

This command lists all the Network Tap under the given Subscription.

### Example 2: List Network Tap by Resource Group
```powershell
Get-AzNetworkFabricTap -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState Destination
------------------- ---------- ------------------ -----------
Disabled                       Succeeded          
```

This command lists all the Network Tap under the given Resource Group.

### Example 3: Get Network Tap
```powershell
Get-AzNetworkFabricTap -Name $name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState Destination
------------------- ---------- ------------------ -----------
Disabled                       Succeeded          
```

This command gets details of the given Network Tap.

