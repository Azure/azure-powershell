### Example 1: Remove a namespace discovered device by name
```powershell
Remove-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredDeviceName "my-discovered-device"
```

This example removes a namespace discovered device by specifying the resource group name, namespace name, and discovered device name directly.

### Example 2: Remove a namespace discovered device using namespace identity object
```powershell
$namespaceIdentity = @{
    SubscriptionId = "12345678-1234-1234-1234-123456789abc"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Remove-AzDeviceRegistryNamespaceDiscoveredDevice -NamespaceInputObject $namespaceIdentity -DiscoveredDeviceName "my-discovered-device"
```

This example removes a namespace discovered device by using a namespace identity object that contains the subscription ID, resource group name, and namespace name, along with the discovered device name.

### Example 3: Remove a namespace discovered device using discovered device identity object
```powershell
$discoveredDevice = Get-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredDeviceName "my-discovered-device"
Remove-AzDeviceRegistryNamespaceDiscoveredDevice -InputObject $discoveredDevice
```

This example removes a namespace discovered device by first retrieving the discovered device object and then passing it directly to the Remove command using the InputObject parameter.

