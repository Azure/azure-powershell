### Example 1: Delete a resource SKU definition.
```powershell
<<<<<<< HEAD
Remove-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default"
=======
PS C:\> Remove-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default"
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Delete a resource type SKU definition.

### Example 2: Delete a nested resource SKU definition.
```powershell
<<<<<<< HEAD
Remove-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -Sku "default"
=======
PS C:\> Remove-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -Sku "default"
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Delete a nested resource type SKU definition.
