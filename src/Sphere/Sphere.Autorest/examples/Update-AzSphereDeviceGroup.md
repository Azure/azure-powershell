### Example 1: Update device group
```powershell
Update-AzSphereDeviceGroup -ResourceGroupName group-test -CatalogName test2024 -ProductName product2024 -Name testdevicegroup -Description test
```

```output
AllowCrashDumpsCollection    : 
Description                  : test
HasDeployment                : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/group-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/product2024/deviceGroups/testdevicegroup
Name                         : testdevicegroup
OSFeedType                   : 
ProvisioningState            : Succeeded
RegionalDataBoundary         : 
ResourceGroupName            : group-test
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

