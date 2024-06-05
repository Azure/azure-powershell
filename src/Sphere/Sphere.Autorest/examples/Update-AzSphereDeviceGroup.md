### Example 1: Update device group
```powershell
Update-AzSphereDeviceGroup -ResourceGroupName joyer-test -CatalogName test2024 -ProductName product2024 -Name testdevicegroup -Description test
```

```output
AllowCrashDumpsCollection    : 
Description                  : test
HasDeployment                : 
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/product2024/deviceGroups/testdevicegroup
Name                         : testdevicegroup
OSFeedType                   : 
ProvisioningState            : Succeeded
RegionalDataBoundary         : 
ResourceGroupName            : joyer-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products/deviceGroups
UpdatePolicy                 : 
```

This command updates device group.

