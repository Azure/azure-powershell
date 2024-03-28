### Example 1: Create a image for device group
```powershell
$imagefile1 = 'D:\GitHub\azure-powershell\src\Sphere\Sphere.Autorest\test\imagefile\AzureSphereBlink1.imagepackage'
$encf1 = [system.io.file]::ReadAllBytes($imagefile1)
$base64str = [system.convert]::ToBase64String($encf1)
New-AzSphereImage -CatalogName test2024 -ResourceGroupName joyer-test -Name 14a6729e-5819-4737-8713-37b4798533f8 -Image $base64str
```

```output
ComponentId                  : 42257ad6-382d-405f-b7cc-e110fbda2d0b
Description                  : 
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024/images/14a6729e-5819-4737-8713-37b4798533f8
ImageId                      : 14a6729e-5819-4737-8713-37b4798533f8
ImageName                    : 
ImageType                    : Applications
Name                         : 14a6729e-5819-4737-8713-37b4798533f8
PropertiesImage              : AzureSphereBlink1
ProvisioningState            : Succeeded
RegionalDataBoundary         : None
ResourceGroupName            : joyer-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/images
Uri                          : https://as3imgptint003.blob.core.windows.net/7de8a199-bb33-4eda-9600-583103317243/imagesaks/14a6729e-5819-4737-8713-37b4798533f8?skoid=cc6e3fcf-ab4d-4b0d-b3f9-9769 
                               604c1e52&sktid=72f988bf-86f1-41af-91ab-2d7cd011db47&skt=2024-02-23T02%3A31%3A35Z&ske=2024-02-23T03%3A36%3A35Z&sks=b&skv=2021-12-02&sv=2021-12-02&spr=https,http&se= 
                               2024-02-23T10%3A36%3A35Z&sr=b&sp=r&sig=7ZNckgqdazn9Af8fHUfsEEA2JrZO0SjDZpUgbh0jEZI%3D
```

This command creates a image for the device group.

