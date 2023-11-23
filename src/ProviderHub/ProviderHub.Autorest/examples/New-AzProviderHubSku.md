### Example 1: Create/Update a resource SKU definition.
```powershell
PS C:\> New-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default" -SkuSetting @{Name = "freeSku"; Tier = "Tier1"; Kind = "Standard"}

Name      Type
----      ----
default   Microsoft.ProviderHub/providerRegistrations/skus
```

Create/Update a resource SKU definition.

### Example 2: Create/Update a nested resource type SKU definition.
```powershell
PS C:\> New-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -Sku "default" -SkuSetting @{Name = "freeSku"; Tier = "Tier1"; Kind = "Standard"}

Name      Type
----      ----
default   Microsoft.ProviderHub/providerRegistrations/skus
```

Create/Update a nested resource type SKU definition.
