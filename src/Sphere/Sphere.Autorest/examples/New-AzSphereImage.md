### Example 1: Create a image for device group
```powershell
$imagefile1 = 'D:\GitHub\azure-powershell\src\Sphere\Sphere.Autorest\test\imagefile\AzureSphereBlink1.imagepackage'
$encf1 = [system.io.file]::ReadAllBytes($imagefile1)
$base64str = [system.convert]::ToBase64String($encf1)
New-AzSphereImage -CatalogName test2024 -ResourceGroupName group-test -Name 11111111-2222-3333-4444-123456789108 -Image $base64str
```

```output
ComponentId                  : 42257ad6-382d-405f-b7cc-e110fbda2d0b
Description                  : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/group-test/providers/Microsoft.AzureSphere/catalogs/test2024/images/11111111-2222-3333-4444-123456789108
ImageId                      : 11111111-2222-3333-4444-123456789108
ImageName                    : 
ImageType                    : Applications
Name                         : 11111111-2222-3333-4444-123456789108
PropertiesImage              : AzureSphereBlink1
ProvisioningState            : Succeeded
RegionalDataBoundary         : None
ResourceGroupName            : group-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/images
Uri                          : ********************************************************************************
```

This command creates a image for the device group.

