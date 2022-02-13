### Example 1: Delete a resource SKU definition.
```powershell
PS C:\> Remove-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default"
```

Delete a resource type SKU definition.

### Example 2: Delete a nested resource SKU definition.
```powershell
PS C:\> Remove-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -Sku "default"
```

Delete a nested resource type SKU definition.
