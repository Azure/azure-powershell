### Example 1: Get all image definitions in a catalog for a project
```powershell
Get-AzDevCenterAdminProjectCatalogImageDefinition -CatalogName "CentralCatalog" -ProjectName "DevProject" -ResourceGroupName "rg1" -SubscriptionId "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
```
This command gets all image definitions in the catalog "CentralCatalog" for the project "DevProject".

### Example 2: Get a specific image definition by name
```powershell
Get-AzDevCenterAdminProjectCatalogImageDefinition -CatalogName "CentralCatalog" -ImageDefinitionName "DefaultDevImage" -ProjectName "DevProject" -ResourceGroupName "rg1" -SubscriptionId "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
```
This command gets the image definition "DefaultDevImage" in the catalog "CentralCatalog" for the project "DevProject".

### Example 3: Get a specific image definition using InputObject
```powershell
$inputObject = @{
    ResourceGroupName = "rg1"
    ProjectName = "DevProject"
    CatalogName = "CentralCatalog"
    ImageDefinitionName = "DefaultDevImage"
    SubscriptionId = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
}
Get-AzDevCenterAdminProjectCatalogImageDefinition -InputObject $inputObject
```
This command gets the image definition "DefaultDevImage" in the catalog "CentralCatalog" for the project "DevProject" using an input object.