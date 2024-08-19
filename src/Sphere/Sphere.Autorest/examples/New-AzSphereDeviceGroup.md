### Example 1: Create a device group into specified catalog and product
```powershell
New-AzSphereDeviceGroup -CatalogName anotherCatalog -Name testgroup -ProductName test -ResourceGroupName Sphere-test
```

```output
AllowCrashDumpsCollection    : Disabled
Description                  : 
HasDeployment                : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/Sphere-test/providers/Microsoft.AzureSphere/catalogs/anotherCatalog/products/test/deviceGroups/testgroup
Name                         : testgroup
OSFeedType                   : Retail
ProvisioningState            : Succeeded
RegionalDataBoundary         : None
ResourceGroupName            : Sphere-test
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

This command creates a device group into specified catalog and product.
