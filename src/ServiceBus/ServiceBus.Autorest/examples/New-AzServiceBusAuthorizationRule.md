### Example 1: Create an authorization rule for a ServiceBus namespace
```powershell
New-AzServiceBusAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAuthRule -Rights @('Manage','Send','Listen')
```

```output
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/authorizationRules/myAuthRule
Location                     : Central US
Name                         : myAuthRule
ResourceGroupName            : myResourceGroup
Rights                       : {Listen, Manage, Send}
```

Creates a new authorization rule `myAuthRule` on namespace `myNamespace`.

### Example 2: Create an authorization rule for a ServiceBus queue
```powershell
New-AzServiceBusAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -QueueName myQueue -Name myAuthRule -Rights @('Manage', 'Send', 'Listen')
```

```output
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/queues/myQueue/authorizationRules/myAuthRule
Location                     : Central US
Name                         : myAuthRule
ResourceGroupName            : myResourceGroup
Rights                       : {Listen, Manage, Send}
```

Creates a new authorization rule `myAuthRule` on ServiceBus queue `myQueue` from namespace `myNamespace`.