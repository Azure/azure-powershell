### Example 1: Remove a namespace device by name
```powershell
Remove-AzDeviceRegistryNamespaceDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DeviceName "my-device"
```

Removes a namespace device by specifying the resource group name, namespace name, and device name directly.

### Example 2: Remove a namespace device using namespace identity object
```powershell
$namespaceIdentity = @{
    SubscriptionId = "12345678-1234-1234-1234-123456789abc"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Remove-AzDeviceRegistryNamespaceDevice -NamespaceInputObject $namespaceIdentity -DeviceName "my-device"
```

Removes a namespace device by using the parent namespace's identity object that contains the subscription ID, resource group name, and namespace name.

### Example 3: Remove a namespace device using device identity object
```powershell
$device = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DeviceName "my-device"
Remove-AzDeviceRegistryNamespaceDevice -InputObject $device
```

Removes a namespace device by using the device's InputObject parameter.

