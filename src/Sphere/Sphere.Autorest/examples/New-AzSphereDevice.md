### Example 1: Create a device
```powershell
New-AzSphereDevice -CatalogName "anotherNewOne" -GroupName ".default" -Name "45ffd2afe82d77b2b70f1daed2054abc64853a27395c6112d9adaf01047bae5a0caa72219f93db02e1a93f2c159ba2090a783077138e7fa542459621e6091e4c" -ProductName ".default" -ResourceGroupName "goyedokun"
```

```output
ChipSku                      : MT3620AN
DeviceId                     : fc9085337153e47eca0d42dcae83819f18ae90d916ae3b87d0206fef6acb9ca44f9e21b93c01311e83168393d112841decc5ef6d48c3d1d07be6b0bf8fec6e2b
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/goyedokun/providers/Microsoft.AzureSphere/catalogs/anotherNewOne/products/.default/deviceGroups/.default/devices/FC9085337153E47ECA0D42DCAE83819F18AE90D916AE3B87D0206FEF6ACB9CA44F9E21B93C01311E83168393D112841DECC5EF6D48C3D1D07BE6B0BF8FEC6E2B
LastAvailableOSVersion       :
LastInstalledOSVersion       :
LastOSUpdateUtc              :
LastUpdateRequestUtc         :
Name                         : fc9085337153e47eca0d42dcae83819f18ae90d916ae3b87d0206fef6acb9ca44f9e21b93c01311e83168393d112841decc5ef6d48c3d1d07be6b0bf8fec6e2b
ProvisioningState            : Succeeded
ResourceGroupName            : goyedokun
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

