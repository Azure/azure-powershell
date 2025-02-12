### Example 1: Create a device
```powershell
New-AzSphereDevice -CatalogName "anotherNewOne" -GroupName ".default" -Name "45ffd2afe82d77b2b70f1daed2054abc64853a27395c6112d9adaf01047bae5a0caa72219f93db02e1a93f2c159ba2090a783077138e7fa542459621e6091e4c" -ProductName ".default" -ResourceGroupName "testgroup"
```

```output
ChipSku                      : MT3620AN
DeviceId                     : ******
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/testgroup/providers/Microsoft.AzureSphere/catalogs/anotherNewOne/products/.default/deviceGroups/.default/devices/******
LastAvailableOSVersion       :
LastInstalledOSVersion       :
LastOSUpdateUtc              :
LastUpdateRequestUtc         :
Name                         : ******
ProvisioningState            : Succeeded
ResourceGroupName            : testgroup
RetryAfter                   :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AzureSphere/catalogs/products/deviceGroups/devices

```

This command creates a device.

