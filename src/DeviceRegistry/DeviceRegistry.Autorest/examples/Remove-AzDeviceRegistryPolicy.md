### Example 1: Remove a policy from a namespace
```powershell
Remove-AzDeviceRegistryPolicy -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -Name "my-policy"
```

Removes the specified policy from the Device Registry namespace.

### Example 2: Remove a policy using pipeline input
```powershell
$policy = Get-AzDeviceRegistryPolicy -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -Name "my-policy"
Remove-AzDeviceRegistryPolicy -InputObject $policy
```

Removes a policy by passing the policy object via the InputObject parameter.

{{ Add description here }}

