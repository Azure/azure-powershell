### Example 1: Create a product with description
```powershell
New-AzSphereProduct -CatalogName newCatalog -Name MyProd815 -ResourceGroupName ps1-test -Description "Contoso DW100 models"
```

```output
Description                  : Contoso DW100 models
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/ps1-test/providers/Microsoft.AzureSphere/catalogs/newCatalog/ 
                               products/MyProd815
Name                         : MyProd815
ProvisioningState            : Succeeded
ResourceGroupName            : ps1-test
RetryAfter                   : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products
```

This command create a product with description.
