### Example 1: Remove a namespace device by name
```powershell
Remove-AzDeviceRegistryNamespaceDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DeviceName "my-device"
```

This example removes a namespace device by specifying the resource group name, namespace name, and device name directly.

### Example 2: Remove a namespace device using namespace identity object
```powershell
$namespaceIdentity = @{
    SubscriptionId = "12345678-1234-1234-1234-123456789abc"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Remove-AzDeviceRegistryNamespaceDevice -NamespaceInputObject $namespaceIdentity -DeviceName "my-device"
```

This example removes a namespace device by using a namespace identity object that contains the subscription ID, resource group name, and namespace name, along with the device name.

### Example 3: Remove a namespace device using device identity object
```powershell
$device = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DeviceName "my-device"
Remove-AzDeviceRegistryNamespaceDevice -InputObject $device
```

This example removes a namespace device by first retrieving the device object and then passing it directly to the Remove command using the InputObject parameter.

