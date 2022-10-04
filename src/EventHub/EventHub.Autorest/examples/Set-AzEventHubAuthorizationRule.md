### Example 1: Update an authorization rule for an EventHub namespace
```powershell
Set-AzEventHubAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAuthRule -Rights @('Manage', 'Send', 'Listen')
```

```output
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/authorizationRules/myAuthRule
Location                     : Central US
Name                         : myAuthRule
ResourceGroupName            : myResourceGroup
Rights                       : {Listen, Manage, Send}
```

Updates authorization rule `myAuthRule` on namespace `myNamespace`.

### Example 2: Update an authorization rule for an EventHub entity
```powershell
Set-AzEventHubAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -EventHubName myEventHub -Name myAuthRule -Rights @('Manage', 'Send', 'Listen')
```

```output
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myEventHub/authorizationRules/myAuthRule
Location                     : Central US
Name                         : myAuthRule
ResourceGroupName            : myResourceGroup
Rights                       : {Listen, Manage, Send}
```

Updates authorization rule `myAuthRule` on EventHubs entity `myEventHub` from namespace `myNamespace`.