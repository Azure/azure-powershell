### Example 1: Get error details for an image definition
```powershell
Get-AzDevCenterAdminProjectCatalogImageDefinitionErrorDetail `
  -CatalogName "CentralCatalog" `
  -ImageDefinitionName "DefaultDevImage" `
  -ProjectName "DevProject" `
  -ResourceGroupName "rg1" `
  -SubscriptionId "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
```
This command gets error details for the image definition "DefaultDevImage" in the catalog "CentralCatalog" for the project "DevProject".

### Example 2: Get error details using InputObject
```powershell
$inputObject = @{
    ResourceGroupName = "rg1"
    ProjectName = "DevProject"
    CatalogName = "CentralCatalog"
    ImageDefinitionName = "DefaultDevImage"
    SubscriptionId = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
}
Get-AzDevCenterAdminProjectCatalogImageDefinitionErrorDetail -InputObject $inputObject
```
This command gets error details for the image definition "DefaultDevImage" using an input object.