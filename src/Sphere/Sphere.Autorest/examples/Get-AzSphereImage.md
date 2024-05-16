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
fa0bdab1-42bc-4871-84d5-fa05c8c0c895
5f05300e-b0e0-47d5-8255-e4bddb2ddd81
```

This command lists images.

### Example 2: Get specific image with specified catalog and resource group
```powershell
Get-AzSphereImage -CatalogName anotherCatalog -Name 14a6729e-5819-4737-8713-37b4798533f8 -ResourceGroupName Sphere-test
```

```output
ComponentId                  : 42257ad6-382d-405f-b7cc-e110fbda2d0b
Description                  : 
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/Sphere-test/providers/Microsoft.AzureSphere/catalogs/anotherCatalog/images/14a6729e-5819-4737-8713-37b4798533f8
ImageId                      : 14a6729e-5819-4737-8713-37b4798533f8
ImageName                    : 
ImageType                    : Applications
Name                         : 14a6729e-5819-4737-8713-37b4798533f8
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
Uri                          : https://as3imgptint003.blob.core.windows.net/9e508310-247c-4bba-add7-39169e9b7482/imagesaks/14a6729e-5819-4737-8713-37b4798533f8?skoid=41781aa8-e455-49b8-8db3-eb9232b581c2&sktid=72f988bf-86f1-41af-91ab-2d7cd011db47&skt=2024-01-30T08%3A27%3A57Z&ske=2024-01-30T09%3A32%3A57Z&sks=b&skv=2021-12-02&sv=2021-12-02&spr=https,http&se=2024-01-30T16%3A32%3A57Z&sr=b&sp=r&sig=EiMxkiDu6yHzV%2BB2LSqMp27AnJc3lKice%2Fm2AJ63r%2Bg%3D
```

This command get specific image.

