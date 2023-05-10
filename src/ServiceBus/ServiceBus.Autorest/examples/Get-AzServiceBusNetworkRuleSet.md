### Example 1: Gets the network rule set of a ServiceBus namespace
```powershell
Get-AzServiceBusNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

```output
DefaultAction                : Allow
IPRule                       : {}
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/networkRuleSets/default
Location                     : Central US
Name                         : default
PublicNetworkAccess          : Enabled
ResourceGroupName            : myResourceGroup
VirtualNetworkRule           :
```

Gets the network rule set of ServiceBus namespace `myNamespace`.