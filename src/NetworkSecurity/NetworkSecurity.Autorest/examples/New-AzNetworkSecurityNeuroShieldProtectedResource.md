### Example 1: Register a virtual machine as a protected resource
```powershell
$targetResourceId = '/subscriptions/<subscription-id>/resourceGroups/myResourceGroup/providers/Microsoft.Compute/virtualMachines/myVM'
New-AzNetworkSecurityNeuroShieldProtectedResource -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -ProtectedResourceName 'myProtectedResource' -TargetResourceId $targetResourceId
```

Registers the target resource and waits for the asynchronous operation to complete.
