### Example 1: Remove a namespace by name
```powershell
Remove-AzDeviceRegistryNamespace -Name "my-namespace" -ResourceGroupName "my-resource-group"
```

Removes a namespace by specifying the namespace name and resource group name. This is the most common way to delete a namespace when you know its name and resource group.

### Example 2: Remove a namespace using an input object
```powershell
$namespace = Get-AzDeviceRegistryNamespace -Name "my-namespace" -ResourceGroupName "my-resource-group"
Remove-AzDeviceRegistryNamespace -InputObject $namespace
```

Removes a namespace using an input object. This approach is useful when you already have a namespace object from a previous operation or when working with pipelines.

