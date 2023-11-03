### Example 1: Get the resource SKU definition.
```powershell
Get-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default"
```

```output
Name                        Type
----                        ----
testResourceType            Microsoft.ProviderHub/providerRegistrations/skus
```

Get the resource SKU definition.

### Example 2: Get the nested resource type SKU definition.
```powershell
Get-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -Sku "default"
```

```output
Name                                        Type
----                                        ----
testResourceType/nestedResourceType         Microsoft.ProviderHub/providerRegistrations/skus
```

Get the nested resource type SKU definition.


