### Example 1: Update a Device Registry Namespace Asset with expanded parameters
```powershell
Update-AzDeviceRegistryNamespaceAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -AssetName "my-asset" -DocumentationUri "https://www.example.com/docs" -DisplayName "My Updated Asset"
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

This example updates a Device Registry Namespace Asset by modifying its documentation URI and display name using individual parameters. This approach is useful when you want to update specific properties of an existing asset.

### Example 2: Update a Device Registry Namespace Asset using JSON string
```powershell
$updateJson = '{
  "properties": {
    "documentationUri": "https://www.example.com/docs",
    "displayName": "My Updated Asset"
  }
}'
Update-AzDeviceRegistryNamespaceAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -AssetName "my-asset" -JsonString $updateJson
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

This example updates a Device Registry Namespace Asset using a JSON string. This approach is useful when you have complex asset configurations or when you want to update multiple properties at once using a structured JSON format.

### Example 3: Update a Device Registry Namespace Asset using JSON file path
```powershell
Update-AzDeviceRegistryNamespaceAsset -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -AssetName "my-asset" -JsonFilePath "C:\path\to\update-asset.json"
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

This example updates a Device Registry Namespace Asset using a JSON file. This approach is useful when you have predefined asset configurations stored in files or when working with complex asset properties that are easier to manage in a separate file.

### Example 4: Update a Device Registry Namespace Asset using namespace identity object
```powershell
$namespaceIdentity = @{
    SubscriptionId = "00000000-0000-0000-0000-000000000000"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Update-AzDeviceRegistryNamespaceAsset -NamespaceInputObject $namespaceIdentity -AssetName "my-asset" -DocumentationUri "https://www.example.com/docs" -DisplayName "My Updated Asset"
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

This example updates a Device Registry Namespace Asset using a namespace identity object. This approach is useful when you want to work with namespace identity objects rather than specifying individual resource group and namespace parameters.

### Example 5: Update a Device Registry Namespace Asset using asset identity object
```powershell
Update-AzDeviceRegistryNamespaceAsset -InputObject $assetObject -DocumentationUri "https://www.example.com/docs" -DisplayName "My Updated Asset"
```

```output
Id                                            : /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxx/providers/Microsoft.DeviceRegistry/locations/EASTUS2/operationStatuses/01e004d3-5ee4-4e48-b0f3-5d095967ff2f*22287DDA3F72A2BF66887E7D826E011DF68F456D735B7BE37C83763585936277
```

This example updates a Device Registry Namespace Asset using an asset identity object obtained from a previous operation. This approach is useful when you already have an asset object from another cmdlet like Get-AzDeviceRegistryNamespaceAsset or New-AzDeviceRegistryNamespaceAsset.

