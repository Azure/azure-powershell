### Example 1: Cancel a build for an image definition
```powershell
Stop-AzDevCenterAdminProjectCatalogImageDefinitionBuild `
  -BuildName "0a28fc61-6f87-4611-8fe2-32df44ab93b7" `
  -CatalogName "CentralCatalog" `
  -ImageDefinitionName "DefaultDevImage" `
  -ProjectName "DevProject" `
  -ResourceGroupName "rg1" `
  -SubscriptionId "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
```

```output
True
```

This command cancels the build with ID "0a28fc61-6f87-4611-8fe2-32df44ab93b7" for the image definition "DefaultDevImage" in the catalog "CentralCatalog" under project "DevProject".

### Example 2: Cancel a build using InputObject
```powershell
$inputObject = @{
    ResourceGroupName = "rg1"
    ProjectName = "DevProject"
    CatalogName = "CentralCatalog"
    ImageDefinitionName = "DefaultDevImage"
    BuildName = "0a28fc61-6f87-4611-8fe2-32df44ab93b7"
    SubscriptionId = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
}
Stop-AzDevCenterAdminProjectCatalogImageDefinitionBuild -InputObject $inputObject
```

```output
True
```

This command cancels the specified build using an input object.