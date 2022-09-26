### Example 1: Remove authorization rule from an a ServiceBus namespace
```powershell
Remove-AzEventHubAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAuthRule
```

Deletes authorization rule `myAuthRule` from EventHub namespace `myNamespace`.

### Example 2: Remove authorization rule from a ServiceBus queue
```powershell
Remove-AzEventHubAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -QueueName myQueue -Name myAuthRule
```

Deletes authorization rule `myAuthRule` from ServiceBus `myQueue` on namespace `myNamespace`.
