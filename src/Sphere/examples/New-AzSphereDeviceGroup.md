### Example 1: Create a device group with description
```powershell
New-AzSphereDeviceGroup -CatalogName newCatalog -Name Marketing -ProductName MyProd815 -ResourceGroupName ps1-test -Description "test device group"
```

```output
AllowCrashDumpsCollection    : Disabled
Description                  : test device group
HasDeployment                : 
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/ps1-test/providers/Microsoft.AzureSphere/catalogs/newCatalog/ 
                               products/MyProd815/deviceGroups/Marketing
Name                         : Marketing
OSFeedType                   : Retail
ProvisioningState            : Succeeded
RegionalDataBoundary         : None
ResourceGroupName            : ps1-test
RetryAfter                   : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products/deviceGroups
UpdatePolicy                 : UpdateAll
```

This command creates a device group with catalog and product.
