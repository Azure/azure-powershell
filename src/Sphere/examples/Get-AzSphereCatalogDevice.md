### Example 1: List devices with specified catalog
```powershell
Get-AzSphereCatalogDevice -CatalogName "MyCEVtest" -ResourceGroupName "glumenCEVRG"
```

```output
ChipSku                      : MT3620AN
DeviceId                     : F9DE980873CC1878693BE5146D42BB5BCC432EE075ED13F7F1249D2606A2114F0F1F18937E67FC45E44EB72586D6F59CE736ACC25E3A51FE4D171E0D5240176D
Id                           : /subscriptions/82f138e0-1c79-4708-bda1-5e224cd688b2/resourceGroups/glumenCEVRG/providers/Microsoft.AzureSphere/catalogs/MyCEVtest/products/MyCEVProd42/deviceGroups/Field 
                               Test/devices/F9DE980873CC1878693BE5146D42BB5BCC432EE075ED13F7F1249D2606A2114F0F1F18937E67FC45E44EB72586D6F59CE736ACC25E3A51FE4D171E0D5240176D
LastAvailableOSVersion       : 
LastInstalledOSVersion       : 
LastOSUpdateUtc              : 
LastUpdateRequestUtc         : 
Name                         : F9DE980873CC1878693BE5146D42BB5BCC432EE075ED13F7F1249D2606A2114F0F1F18937E67FC45E44EB72586D6F59CE736ACC25E3A51FE4D171E0D5240176D
ProvisioningState            : Succeeded
ResourceGroupName            : glumenCEVRG
RetryAfter                   : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products/deviceGroups/devices
```

This command lists devices for catalog with filter and other options.