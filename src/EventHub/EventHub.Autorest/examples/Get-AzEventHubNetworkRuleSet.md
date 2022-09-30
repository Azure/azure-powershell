### Example 1: Gets the network rule set of an EventHub namespace
```powershell
Get-AzEventHubNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

```output
DefaultAction                : Allow
IPRule                       : {}
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/networkRuleSets/default
Location                     : Central US
Name                         : default
PublicNetworkAccess          : Enabled
ResourceGroupName            : myResourceGroup
VirtualNetworkRule           :
```

Gets the network rule set of EventHub namespace `myNamespace`.