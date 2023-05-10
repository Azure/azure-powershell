### Example 1: Delete an EventHub namespace
```powershell
Remove-AzEventHubNamespace -ResourceGroupName myResourceGroup -Name myNamespace
```

Deletes an EventHub namespace `myNamespace` under resource group `myResourceGroup`.

### Example 2: Delete an EventHub namespace using InputObject parameter set
```powershell
$namespace = Get-AzEventHubNamespace -ResourceGroupName myResourceGroup -Name myNamespace
Remove-AzEventHubNamespace -InputObject $namespace
```

Deletes an EventHub namespace `myNamespace` under resource group `myResourceGroup` using InputObject parameter set.

