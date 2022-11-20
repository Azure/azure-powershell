### Example 1: Delete an EventHub namespace
```powershell
Remove-AzEventHubNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace
```

Deletes an EventHub namespace `myNamespace` under resource group `myResourceGroup`.

### Example 2: Delete an EventHub namespace using InputObject parameter set
```powershell
$namespace = Get-AzEventHubNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace
Remove-AzEventHubNamespaceV2 -InputObject $namespace
```

Deletes an EventHub namespace `myNamespace` under resource group `myResourceGroup` using InputObject parameter set.

