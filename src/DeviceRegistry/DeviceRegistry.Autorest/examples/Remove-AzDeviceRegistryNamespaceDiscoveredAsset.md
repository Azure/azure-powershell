### Example 1: Remove a namespace discovered asset by name
```powershell
Remove-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredAssetName "my-discovered-asset"
```

Removes a namespace discovered asset by specifying the resource group name, namespace name, and discovered asset name directly.

### Example 2: Remove a namespace discovered asset using namespace identity object
```powershell
$namespaceIdentity = @{
    SubscriptionId = "12345678-1234-1234-1234-123456789abc"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Remove-AzDeviceRegistryNamespaceDiscoveredAsset -NamespaceInputObject $namespaceIdentity -DiscoveredAssetName "my-discovered-asset"
```

Removes a namespace discovered asset by using the parent namespace's identity object that contains the subscription ID, resource group name, and namespace name.

### Example 3: Remove a namespace discovered asset using discovered asset identity object
```powershell
$discoveredAsset = Get-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredAssetName "my-discovered-asset"
Remove-AzDeviceRegistryNamespaceDiscoveredAsset -InputObject $discoveredAsset
```

Removes a namespace discovered asset by using the asset's InputObject parameter.

