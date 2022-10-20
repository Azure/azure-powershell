### Example 1: Remove an authorization rule from a ServiceBus namespace
```powershell
Remove-AzServiceBusAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAuthRule
```

Deletes authorization rule `myAuthRule` from ServiceBus namespace `myNamespace`.

### Example 2: Remove an authorization rule from a ServiceBus queue
```powershell
Remove-AzServiceBusAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -QueueName myQueue -Name myAuthRule
```

Deletes authorization rule `myAuthRule` from ServiceBus `myQueue` on namespace `myNamespace`.
