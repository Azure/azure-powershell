### Example 1: List with specified catalog by resource group 
```powershell
Get-AzSphereProduct -ResourceGroupName joyer-test -CatalogName test2024
```

```output
Name        SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----        ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
product2024                                                                                                                                                joyer-test
product0207                                                                                                                                                joyer-test
```

This command gets list of product with specified catalog by resource group.

### Example 2: Get product with specified catalog and resource group
```powershell
Get-AzSphereProduct -ResourceGroupName joyer-test -CatalogName test2024 -Name product2024
```

```output
Description                  : 222
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/product2024
Name                         : product2024
ProvisioningState            : Succeeded
ResourceGroupName            : joyer-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products
```

This command gets specific product with specified catalog and resource group.

