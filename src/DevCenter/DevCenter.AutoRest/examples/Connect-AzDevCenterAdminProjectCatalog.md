### Example 1: Connect a project catalog
```powershell
Connect-AzDevCenterAdminProjectCatalog -ProjectName DevProject -CatalogName CentralCatalog -ResourceGroupName testRg
```
This command connects the project catalog named "CentralCatalog" in the project "DevProject" under the resource group "testRg".

### Example 2: Connect a project catalog using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
$catalog = Connect-AzDevCenterAdminProjectCatalog -InputObject $catalog
```
This command connects the project catalog named "CentralCatalog" in the project "DevProject" under the resource group "testRg".

