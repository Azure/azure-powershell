### Example 1: List with specified catalog by resource group 
```powershell
Get-AzSphereProduct -ResourceGroupName group-test -CatalogName test2024
```

```output
Name        SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----        ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
product2024                                                                                                                                                group-test
product0207                                                                                                                                                group-test
```

This command gets list of product with specified catalog by resource group.

### Example 2: Get product with specified catalog and resource group
```powershell
Get-AzSphereProduct -ResourceGroupName group-test -CatalogName test2024 -Name product2024
```

```output
Description                  : 222
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

This command gets specific product with specified catalog and resource group.

