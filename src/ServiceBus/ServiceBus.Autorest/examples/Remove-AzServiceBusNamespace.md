### Example 1: Deletes an existing namespace.
```powershell    
Remove-AzServiceBusNamespace -ResourceGroupName myResourceGroup -Name myNamespace
```

Deletes an ServiceBus namespace `myNamespace` under resource group `myResourceGroup`.


### Example 2: Delete an ServiceBus namespace using InputObject parameter set
```powershell
$namespace = Get-AzServiceBusNamespace -ResourceGroupName myResourceGroup -Name myNamespace
Remove-AzServiceBusNamespace -InputObject $namespace
```

Deletes an ServiceBus namespace `myNamespace` under resource group `myResourceGroup` using InputObject parameter set.


