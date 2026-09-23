### Example 1: Build an image for an image definition
```powershell
Build-AzDevCenterAdminProjectCatalogImageDefinitionImage `
  -CatalogName "CentralCatalog" `
  -ImageDefinitionName "DefaultDevImage" `
  -ProjectName "DevProject" `
  -ResourceGroupName "rg1" `
  -SubscriptionId "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
```

This command starts a build for the image definition "DefaultDevImage" in the catalog "CentralCatalog" under project "DevProject".

### Example 2: Build an image using InputObject
```powershell
$inputObject = @{
    ResourceGroupName = "rg1"
    ProjectName = "DevProject"
    CatalogName = "CentralCatalog"
    ImageDefinitionName = "DefaultDevImage"
    SubscriptionId = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
}
Build-AzDevCenterAdminProjectCatalogImageDefinitionImage -InputObject $inputObject
```

This command starts a build for the specified image definition using an input object.