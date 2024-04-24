### Example 1: Create/Update a resource SKU definition.
```powershell
$skuSetting1 = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting" -Property @{Name = "freeSku"; Tier = "Tier1"; Kind = "Standard"}
$skuSetting2 = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting" -Property @{Name = "freeSku2"; Tier = "Tier1"; Kind = "Standard"}

New-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default" -SkuSetting $skuSetting1, $skuSetting2
```

```output
Name      Type
----      ----
default   Microsoft.ProviderHub/providerRegistrations/skus
```

Create/Update a resource SKU definition.

### Example 2: Create/Update a nested resource type SKU definition.
```powershell
$skuSetting1 = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting" -Property @{Name = "freeSku"; Tier = "Tier1"; Kind = "Standard"}

New-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -Sku "default" -SkuSetting $skuSetting1
```

```output
Name      Type
----      ----
default   Microsoft.ProviderHub/providerRegistrations/skus
```

Create/Update a nested resource type SKU definition.
