### Example 1: Register a virtual machine as a protected resource
```powershell
$targetResourceId = '/subscriptions/<subscription-id>/resourceGroups/myResourceGroup/providers/Microsoft.Compute/virtualMachines/myVM'
New-AzNetworkSecurityNeuroShieldProtectedResource -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -ProtectedResourceName 'myProtectedResource' -TargetResourceId $targetResourceId
```

Registers the target resource and waits for the asynchronous operation to complete.

Inventory assessments and remediation also require the `Microsoft.Azure.Networking/Neuron` VM extension, installed separately using the service-provided settings.
Its managed identity must be attached to the VM and match the protected-resource registration.
This cmdlet does not install the VM extension, and installing the VM extension alone does not register the protected resource.
