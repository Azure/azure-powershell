### Example 1: Assign a device to another device group
```powershell
Update-AzSphereDevice -ResourceGroupName joyer-test -CatalogName test2024 -GroupName testdevicegroup -ProductName product2024 -Name ******** -DeviceGroupId /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/product2024/deviceGroups/testdevicegroup2
```

```output
ChipSku                      : 
DeviceId                     : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/providers/Microsoft.AzureSphere/locations/WESTCENTRALUS/operationStatuses/dc3e0b1a-59ae-4b00-bb84-9a7ea253f4e8*648856149066E98CE43CF51B8F3FC827768BFF5C8740097AD36EDFC456E7B110
LastAvailableOSVersion       : 
LastInstalledOSVersion       : 
LastOSUpdateUtc              : 
LastUpdateRequestUtc         : 
Name                         : dc3e0b1a-59ae-4b00-bb84-9a7ea253f4e8*648856149066E98CE43CF51B8F3FC827768BFF5C8740097AD36EDFC456E7B110
ProvisioningState            : 
ResourceGroupName            : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : 
```

This command assign a device to another device group.

### Example 2: unassign a device
```powershell
Update-AzSphereDevice -ResourceGroupName joyer-test -CatalogName test2024 -GroupName testdevicegroup -ProductName product2024 -Name ******** -DeviceGroupId /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/.default/deviceGroups/.default
```

```output
ChipSku                      : 
DeviceId                     : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/providers/Microsoft.AzureSphere/locations/WESTCENTRALUS/operationStatuses/*******
LastAvailableOSVersion       : 
LastInstalledOSVersion       : 
LastOSUpdateUtc              : 
LastUpdateRequestUtc         : 
Name                         : *******
ProvisioningState            : 
ResourceGroupName            : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : 
```

This command unassign a device to catalog.

