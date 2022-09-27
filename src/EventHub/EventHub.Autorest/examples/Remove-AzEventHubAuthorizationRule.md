### Example 1: Remove authorization rule from an EventHub namespace
```powershell
Remove-AzEventHubAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAuthRule
```

Deletes authorization rule `myAuthRule` from EventHub namespace `myNamespace`.

### Example 2: Remove authorization rule from an EventHub entity
```powershell
Remove-AzEventHubAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -EventHubName myEventHub -Name myAuthRule
```

Deletes authorization rule `myAuthRule` from EventHub entity `myEventHub` on namespace `myNamespace`.

