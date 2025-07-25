### Example 1: Get an EventHub Namespace Authorization Rule
```powershell
Get-AzEventHubAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAuthRule
```

```output
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/authorizationRules
                               /myAuthRule
Location                     : Central US
Name                         : myAuthRule
ResourceGroupName            : myResourceGroup
Rights                       : {Listen, Manage, Send}
```

Gets details of authorization rule `myAuthRule` of EventHub namespace `myNamespace`.

### Example 2: Get an EventHub entity authorization rule
```powershell
Get-AzEventHubAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -EventHubName myEventHub -Name myAuthRule
```

```output
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myEventHub/authorizationRules
                               /myAuthRule
Location                     : Central US
Name                         : myAuthRule
ResourceGroupName            : myResourceGroup
Rights                       : {Listen, Manage, Send}
```

Gets details of authorization rule `myAuthRule` of EventHub entity `myEventHub` from namespace `myNamespace`.

