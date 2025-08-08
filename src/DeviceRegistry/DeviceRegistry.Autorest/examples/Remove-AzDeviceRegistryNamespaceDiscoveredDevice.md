### Example 1: Remove a namespace discovered device by name
```powershell
Remove-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredDeviceName "my-discovered-device"
```

Removes a namespace discovered device by specifying the resource group name, namespace name, and discovered device name directly.

### Example 2: Remove a namespace discovered device using namespace identity object
```powershell
$namespaceIdentity = @{
    SubscriptionId = "12345678-1234-1234-1234-123456789abc"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Remove-AzDeviceRegistryNamespaceDiscoveredDevice -NamespaceInputObject $namespaceIdentity -DiscoveredDeviceName "my-discovered-device"
```

Removes a namespace discovered device by using the parent namespace's identity object that contains the subscription ID, resource group name, and namespace name.

### Example 3: Remove a namespace discovered device using discovered device identity object
```powershell
$discoveredDevice = Get-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredDeviceName "my-discovered-device"
Remove-AzDeviceRegistryNamespaceDiscoveredDevice -InputObject $discoveredDevice
```

Removes a namespace discovered device by using the device's InputObject parameter.

