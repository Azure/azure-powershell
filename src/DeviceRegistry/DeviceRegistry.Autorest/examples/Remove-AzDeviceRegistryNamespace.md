### Example 1: Remove a namespace by name
```powershell
Remove-AzDeviceRegistryNamespace -Name "my-namespace" -ResourceGroupName "my-resource-group"
```

Removes a namespace by specifying the namespace name and resource group name.

### Example 2: Remove a namespace using an input object
```powershell
$namespace = Get-AzDeviceRegistryNamespace -Name "my-namespace" -ResourceGroupName "my-resource-group"
Remove-AzDeviceRegistryNamespace -InputObject $namespace
```

Removes a namespace using an InputObject.

