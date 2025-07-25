### Example 1: Remove Disaster Recovery Config from an EventHub namespace
```powershell
Remove-AzEventHubGeoDRConfiguration -Name myAlias -ResourceGroupName myResourceGroup -NamespaceName myPrimaryNamespace
```

Deletes alias `myAlias` from EventHub namespace `myPrimaryNamespace`.

