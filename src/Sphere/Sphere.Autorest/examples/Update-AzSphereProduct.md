### Example 1: Update description
```powershell
Update-AzSphereProduct -ResourceGroupName group-test -CatalogName test2024 -Name product2024 -Description 2222
```

```output
Description                  : 2222
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/group-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/product2024
Name                         : product2024
ProvisioningState            : Succeeded
ResourceGroupName            : group-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products
```

This command updates product description.

