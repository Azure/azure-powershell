### Example 1: Update a Device Registry Namespace Discovered Asset with expanded parameters
```powershell
Update-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredAssetName "my-discovered-asset" -DocumentationUri "https://www.example.com/docs" -SerialNumber "SN123456789"
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

Updates a Device Registry Namespace Discovered Asset by modifying its properties using individual parameters.

### Example 2: Update a Device Registry Namespace Discovered Asset using JSON string
```powershell
$updateJson = '{
  "properties": {
    "documentationUri": "https://www.example.com/docs",
    "serialNumber": "SN123456789"
  }
}'
Update-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredAssetName "my-discovered-asset" -JsonString $updateJson
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

Updates a Device Registry Namespace Discovered Asset using a JSON string containing the properties to update.

### Example 3: Update a Device Registry Namespace Discovered Asset using JSON file path
```powershell
Update-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -DiscoveredAssetName "my-discovered-asset" -JsonFilePath "C:\path\to\update-discovered-asset.json"
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

Updates a Device Registry Namespace Discovered Asset using a JSON file containing the properties to update.

### Example 4: Update a Device Registry Namespace Discovered Asset using namespace identity object
```powershell
$namespaceIdentity = @{
    SubscriptionId = "00000000-0000-0000-0000-000000000000"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Update-AzDeviceRegistryNamespaceDiscoveredAsset -NamespaceInputObject $namespaceIdentity -DiscoveredAssetName "my-discovered-asset" -DocumentationUri "https://www.example.com/docs" -SerialNumber "SN123456789"
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

Updates a Device Registry Namespace Discovered Asset using the parent namespace's identity object.

### Example 5: Update a Device Registry Namespace Discovered Asset using discovered asset identity object
```powershell
Update-AzDeviceRegistryNamespaceDiscoveredAsset -InputObject $discoveredAssetObject -DocumentationUri "https://www.example.com/docs" -SerialNumber "SN123456789"
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

Updates a Device Registry Namespace Discovered Asset using the discovered asset's identity object.

