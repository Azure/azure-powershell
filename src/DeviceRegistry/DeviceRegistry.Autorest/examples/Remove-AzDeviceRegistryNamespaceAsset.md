### Example 1: Remove a namespace asset by name
```powershell
Remove-AzDeviceRegistryNamespaceAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -AssetName "my-asset"
```

Removes a namespace asset by specifying the resource group name, namespace name, and asset name directly.

### Example 2: Remove a namespace asset using namespace identity object
```powershell
$namespaceIdentity = @{
    SubscriptionId = "12345678-1234-1234-1234-123456789abc"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Remove-AzDeviceRegistryNamespaceAsset -NamespaceInputObject $namespaceIdentity -AssetName "my-asset"
```

Removes a namespace asset by using the parent namespace's identity object that contains the subscription ID, resource group name, and namespace name.

### Example 3: Remove a namespace asset using asset identity object
```powershell
$asset = Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -AssetName "my-asset"
Remove-AzDeviceRegistryNamespaceAsset -InputObject $asset
```

Removes a namespace asset by using the asset's InputObject.

