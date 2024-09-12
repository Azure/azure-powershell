### Example 1: Create a product into specified catalog
```powershell
New-AzSphereProduct -CatalogName test2024 -ResourceGroupName group-test -Name product2024
```

```output
Description                  : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/group-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/product2024
Name                         : product2024
ProvisioningState            : Succeeded
ResourceGroupName            : group-test
RetryAfter                   : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products
```

This command create a product into specified catalog.
