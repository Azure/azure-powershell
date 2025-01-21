### Example 1: List images for specific catalog with specified resource group
```powershell
Get-AzSphereImage -CatalogName MyCatalog1 -ResourceGroupName ResourceGroup1
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDa 
                                                                                                                                                       taLastMo 
                                                                                                                                                       difiedBy 
                                                                                                                                                       Type     
----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ -------- 
11111111-2222-3333-4444-123456789104
11111111-2222-3333-4444-123456789105
```

This command lists images.

### Example 2: Get specific image with specified catalog and resource group
```powershell
Get-AzSphereImage -CatalogName anotherCatalog -Name 11111111-2222-3333-4444-123456789104 -ResourceGroupName Sphere-test
```

```output
ComponentId                  : 42257ad6-382d-405f-b7cc-e110fbda2d0b
Description                  : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/Sphere-test/providers/Microsoft.AzureSphere/catalogs/anotherCatalog/images/11111111-2222-3333-4444-123456789104
ImageId                      : 11111111-2222-3333-4444-123456789104
ImageName                    : 
ImageType                    : Applications
Name                         : 11111111-2222-3333-4444-123456789104
PropertiesImage              : AzureSphereBlink1
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
Type                         : Microsoft.AzureSphere/catalogs/images
Uri                          : ****************
```

This command get specific image.

