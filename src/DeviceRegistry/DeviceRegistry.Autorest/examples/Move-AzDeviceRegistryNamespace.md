### Example 1: Migrate Asset Resource to Namespace with Expanded Parameters
```powershell
Move-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace" -ResourceId "/subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/assets/my-asset1","/subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/assets/my-asset2"
```

Migrates list of Device Registry Asset resources to a Namespace using expanded parameters.  The commandlet takes a list of resource IDs of the Asset resource(s) to migrate under the specified Namespace, and will become a Namespace Asset, and the AssetEndpointProfile resource(s) associated with the Asset(s) will be migrated to a Namespace Device resource(s) also under the specified Namespace.

### Example 2: Migrate Resources to Namespace via JSON String
```powershell
$migrateRequest = @{
    resourceIds = @("/subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/assets/my-asset")
}
$jsonString = $migrateRequest | ConvertTo-Json -Depth 10
Move-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace" -JsonString $jsonString
```

Migrates Device Registry Asset resources to a Namespace using a JSON string containing the migration request. The provided list of resource IDs of the Asset resource(s) specifies to the commandlet to migrate them under the specified Namespace, and will become a Namespace Asset, and the AssetEndpointProfile resource(s) associated with the Asset(s) will be migrated to a Namespace Device resource(s) also under the specified Namespace.

### Example 3: Migrate Resources to Namespace via JSON File Path
```powershell
Move-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace" -JsonFilePath "C:\path\to\migrate-request.json"
```

Migrates Device Registry Asset resources to a namespace using a JSON file containing the migration request. The provided list of resource IDs of the Asset resource(s) specifies to the commandlet to migrate them under the specified Namespace, and will become a Namespace Asset, and the AssetEndpointProfile resource(s) associated with the Asset(s) will be migrated to a Namespace Device resource(s) also under the specified Namespace.

### Example 4: Migrate Multiple Resources to Namespace
```powershell
$resourceIds = @("/subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/assets/my-asset")
Move-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace" -ResourceId $resourceIds
```

Migrates multiple Device Registry Asset resources to a namespace using an array of resource IDs. The provided list of resource IDs of the Asset resource(s) specifies to the commandlet to migrate them under the specified Namespace, and will become a Namespace Asset, and the AssetEndpointProfile resource(s) associated with the Asset(s) will be migrated to a Namespace Device resource(s) also under the specified Namespace.

### Example 5: Migrate Resources to Namespace via Identity with Expanded Parameters
```powershell
$namespace = Get-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace"
Move-AzDeviceRegistryNamespace -InputObject $namespace -ResourceId "/subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/assets/my-asset"
```

Migrates Device Registry Asset resources to a namespace using the namespace's Identity object with expanded parameters. The provided list of resource IDs of the Asset resource(s) specifies to the commandlet to migrate them under the specified Namespace, and will become a Namespace Asset, and the AssetEndpointProfile resource(s) associated with the Asset(s) will be migrated to a Namespace Device resource(s) also under the specified Namespace.

### Example 6: Migrate Resources to Namespace via Identity
```powershell
$namespace = Get-AzDeviceRegistryNamespace -ResourceGroupName "my-resource-group" -Name "my-namespace"
$resourceIds = @("/subscriptions/my-subscription/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/assets/my-asset")
Move-AzDeviceRegistryNamespace -InputObject $namespace -ResourceId $resourceIds
```

Migrates Device Registry Asset resources to a namespace using the namespace's Identity object with multiple resource IDs. The provided list of resource IDs of the Asset resource(s) specifies to the commandlet to migrate them under the specified Namespace, and will become a Namespace Asset, and the AssetEndpointProfile resource(s) associated with the Asset(s) will be migrated to a Namespace Device resource(s) also under the specified Namespace.

