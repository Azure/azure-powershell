### Example 1: Get the resource SKU definition.
```powershell
<<<<<<< HEAD
Get-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default"
```

```output
=======
PS C:\> Get-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                        Type
----                        ----
testResourceType            Microsoft.ProviderHub/providerRegistrations/skus
```

Get the resource SKU definition.

### Example 2: Get the nested resource type SKU definition.
```powershell
<<<<<<< HEAD
Get-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -Sku "default"
```

```output
=======
PS C:\> Get-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -Sku "default"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                                        Type
----                                        ----
testResourceType/nestedResourceType         Microsoft.ProviderHub/providerRegistrations/skus
```

Get the nested resource type SKU definition.


