### Example 1: Deletes an existing namespace.
```powershell    
Remove-AzServiceBusNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace
```

Deletes an ServiceBus namespace `myNamespace` under resource group `myResourceGroup`.


### Example 2: Delete an ServiceBus namespace using InputObject parameter set
```powershell
$namespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace
Remove-AzServiceBusNamespaceV2 -InputObject $namespace
```

Deletes an ServiceBus namespace `myNamespace` under resource group `myResourceGroup` using InputObject parameter set.


