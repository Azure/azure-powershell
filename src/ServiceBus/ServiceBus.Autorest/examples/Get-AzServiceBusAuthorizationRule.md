### Example 1: Get a ServiceBus Namespace Authorization Rule
```powershell
Get-AzServiceBusAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAuthRule
```

```output
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/authorizationRules
                               /myAuthRule
Location                     : Central US
Name                         : myAuthRule
ResourceGroupName            : myResourceGroup
Rights                       : {Listen, Manage, Send}
```

Gets details of authorization rule `myAuthRule` of ServiceBus namespace `myNamespace`.

### Example 2: Get a ServiceBus queue authorization rule
```powershell
Get-AzServiceBusAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -QueueName queue1 -Name myAuthRule
```

```output
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/queues/queue1/authorizationRules
                               /myAuthRule
Location                     : Central US
Name                         : myAuthRule
ResourceGroupName            : myResourceGroup
Rights                       : {Listen, Manage, Send}
```

Gets details of authorization rule `myAuthRule` of ServiceBus queue `queue1` from namespace `myNamespace`.

### Example 3: List all authorization rules in a ServiceBus namespace
```powershell
Get-AzServiceBusAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

Lists all authorization rules in ServiceBus namespace `myNamespace`.
