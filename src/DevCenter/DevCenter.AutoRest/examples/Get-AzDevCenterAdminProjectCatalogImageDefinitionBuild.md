### Example 1: Get all image definitions builds in a image definition for a project
```powershell
Get-AzDevCenterAdminProjectCatalogImageDefinitionBuild -ImageDefinitionName "DefaultDevImage" -CatalogName "CentralCatalog" -ProjectName "DevProject" -ResourceGroupName "rg1" -SubscriptionId "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
```

This command gets all image definitions in the catalog "CentralCatalog" for the project "DevProject".

### Example 2: Get a specific image definition build by name
```powershell
Get-AzDevCenterAdminProjectCatalogImageDefinitionBuild -BuildName "0a28fc61-6f87-4611-8fe2-32df44ab93b7" -CatalogName "CentralCatalog" -ImageDefinitionName "DefaultDevImage" -ProjectName "DevProject" -ResourceGroupName "rg1" -SubscriptionId "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
```

This command gets the image definition build "0a28fc61-6f87-4611-8fe2-32df44ab93b7" in the image definition "DefaultDevImage" for the project "DevProject".

### Example 3: Get a specific image definition build using InputObject
```powershell
$inputObject = @{
    ResourceGroupName = "rg1"
    ProjectName = "DevProject"
    CatalogName = "CentralCatalog"
    ImageDefinitionName = "DefaultDevImage"
    SubscriptionId = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
    BuildName = "0a28fc61-6f87-4611-8fe2-32df44ab93b7"
}
Get-AzDevCenterAdminProjectCatalogImageDefinitionBuild -InputObject $inputObject
```

This command gets the image definition build "0a28fc61-6f87-4611-8fe2-32df44ab93b7" in the image definition "DefaultDevImage" for the project "DevProject" using an input object.
