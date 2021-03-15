### Example 1: Create/Update a resource SKU definition.
```powershell
PS C:\> New-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default" -SkuSetting @{Name = "freeSku"; Tier = "Tier1", Kind = "Standard"}
```
