### Example 1: Get build details for a specific image definition build
```powershell
Get-AzDevCenterAdminProjectCatalogImageDefinitionBuildDetail `
  -BuildName "0a28fc61-6f87-4611-8fe2-32df44ab93b7" `
  -CatalogName "CentralCatalog" `
  -ImageDefinitionName "DefaultDevImage" `
  -ProjectName "DevProject" `
  -ResourceGroupName "rg1" `
  -SubscriptionId "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
```
This command gets the details for the build with ID "0a28fc61-6f87-4611-8fe2-32df44ab93b7" for the image definition "DefaultDevImage" in the catalog "CentralCatalog" under project "DevProject".

### Example 2: Get build details using InputObject
```powershell
$inputObject = @{
    ResourceGroupName = "rg1"
    ProjectName = "DevProject"
    CatalogName = "CentralCatalog"
    ImageDefinitionName = "DefaultDevImage"
    BuildName = "0a28fc61-6f87-4611-8fe2-32df44ab93b7"
    SubscriptionId = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
}
Get-AzDevCenterAdminProjectCatalogImageDefinitionBuildDetail -InputObject $inputObject
```
This command gets the build details using an input object.